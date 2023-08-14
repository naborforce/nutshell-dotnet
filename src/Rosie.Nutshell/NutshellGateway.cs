using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Rosie.Nutshell.Exceptions;
using Rosie.Nutshell.Secrets;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Endpoint;
using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell;

internal class NutshellGateway : INutshellGateway
{
    private readonly NutshellCredential _secret;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<NutshellGateway> _logger;
    private readonly AsyncLazy<HttpClient> _client;
    private static readonly Uri _endpointDiscoverUrl = new(Constants.DiscoveryEndpointUri);

    static NutshellGateway() => DotEnv.Load(".env");

    public NutshellGateway(
        NutshellCredential? secret, 
        IHttpClientFactory httpClientFactory,
        ILogger<NutshellGateway> logger)
    {
        _secret = secret ?? new NutshellCredential();
        _httpClientFactory = httpClientFactory;
        _logger = logger;

        _client = new AsyncLazy<HttpClient>(CreateHttpClientAsync);
    }

    private async Task<HttpClient> CreateHttpClientAsync()
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient(nameof(NutshellGateway));
            httpClient.BaseAddress = await GetApiEndpointForUserAsync(_secret.Username);
            var authData = Encoding.UTF8.GetBytes($"{_secret.Username}:{_secret.ApiKey}");
            var basicAuthParameterValue = Convert.ToBase64String(authData);
            var authHeader = new AuthenticationHeaderValue("Basic", basicAuthParameterValue);
            httpClient.DefaultRequestHeaders.Authorization = authHeader;
            return httpClient;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating HTTP client");
            throw;
        }
    }

    private async Task<Uri> GetApiEndpointForUserAsync(string username)
    {
        try
        {
            var request = new GetEndpointRequest(username);
            using var httpClient = _httpClientFactory.CreateClient(nameof(NutshellGateway));

            var endpoint = await ExecuteRemoteProcedureCallAsync(
                NutshellRpc.GetApiForUsername,
                request,
                httpClient,
                _endpointDiscoverUrl);

            return new Uri($"https://{endpoint.Api}/api/v1/json");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error while getting API endpoint for user `{Username}`", username);
            throw;
        }
    }

    private static string GenerateRequestId() => Guid.NewGuid().ToString("N");

    public async Task<TOut> CallAsync<TOut, TIn>(NutshellRpc<TOut, TIn> method, TIn input)
        where TIn : class
        => await ExecuteRemoteProcedureCallAsync(method, input, await _client.Value);

    public async Task<TOut> CallAsync<TOut>(NutshellFunc<TOut> method)
        => await ExecuteRemoteProcedureCallAsync(method, null, await _client.Value);

    public async Task CallAsync<TIn>(NutshellAction<TIn> method, TIn input) where TIn : class
        => await ExecuteRemoteProcedureCallAsync(method, input, await _client.Value);

    private async Task<TOut> ExecuteRemoteProcedureCallAsync<TOut, TIn>(
        AbstractNutshellRpc<TOut, TIn> method,
        TIn? input,
        HttpClient httpClient,
        Uri? requestUri = null)
        where TIn : class
    {
        var request = CreateRequest(method, input, requestUri);
        return await GetResponseAsync(method, httpClient, request);
    }

    private async Task<TOut> GetResponseAsync<TOut, TIn>(
        AbstractNutshellRpc<TOut, TIn> method,
        HttpClient httpClient,
        HttpRequestMessage request) where TIn : class
    {
        try
        {
            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new NutshellApiException($"Error while calling method `{method}`: {response.ReasonPhrase}");
            }

            var decoded = await response.Content.ReadFromJsonAsync<RpcResponse<TOut>>();

            if (decoded?.Error != null)
            {
                throw new NutshellApiException(
                    $"Error while calling method `{method}`: {decoded.Error.Message}",
                    decoded.Error.Code,
                    decoded.Error.Data);
            }

            if (decoded is null || decoded.Result is null)
            {
                throw new NutshellApiException("Error while calling method `{method}`: no response");
            }

            return decoded.Result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while calling method `{Method}`", method);
            throw;
        }
    }

    private HttpRequestMessage CreateRequest(
        Enumeration method,
        object? input,
        Uri? requestUri)
    {
        try
        {
            var payload = new
            {
                method = method.Name,
                @params = input is IProjection projection ? projection.GetProjection() : input,
                id = GenerateRequestId()
            };

            var request = new HttpRequestMessage();

            if (requestUri is not null)
            {
                request.RequestUri = requestUri;
            }

            request.Method = HttpMethod.Post;
            request.Content = JsonContent.Create(payload);
            return request;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating request for method `{Method}`", method);
            throw;
        }
    }
}