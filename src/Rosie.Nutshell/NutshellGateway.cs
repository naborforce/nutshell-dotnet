﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Rosie.Nutshell.Exceptions;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Endpoint;
using Rosie.Platform.Abstractions.Unions;
using Rosie.Platform.Factories;
using Secret = Rosie.Nutshell.Secrets.Nutshell;

namespace Rosie.Nutshell;

public class NutshellGateway : INutshellGateway
{
    private readonly Secret secret;
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ILogger<NutshellGateway> logger;
    private readonly AsyncLazy<HttpClient> client;
    private static readonly Uri endpointDiscoverUrl = new Uri("https://api.nutshell.com/v1/json");

    public NutshellGateway(Secret secret, IHttpClientFactory httpClientFactory, ILogger<NutshellGateway> logger)
    {
        this.secret = secret;
        this.httpClientFactory = httpClientFactory;
        this.logger = logger;

        client = new AsyncLazy<HttpClient>(CreateHttpClientAsync);
    }

    private async Task<HttpClient> CreateHttpClientAsync()
    {
        var httpClient = httpClientFactory.CreateClient(nameof(NutshellGateway));
        httpClient.BaseAddress = await GetApiEndpointForUserAsync(secret.Username);
        var authData = Encoding.UTF8.GetBytes($"{secret.Username}:{secret.ApiKey}");
        var basicAuthParameterValue = Convert.ToBase64String(authData);
        var authHeader = new AuthenticationHeaderValue("Basic", basicAuthParameterValue);
        httpClient.DefaultRequestHeaders.Authorization = authHeader;
        return httpClient;
    }

    private async Task<Uri> GetApiEndpointForUserAsync(string username)
    {
        var request = new GetEndpointRequest(username);
        using var httpClient = httpClientFactory.CreateClient(nameof(NutshellGateway));
        var endpoint = await CallAsync(NutshellMethods.GetApiForUsername, request, httpClient, endpointDiscoverUrl);
        return new Uri($"https://{endpoint.Api}/api/v1/json");
    }

    private static string GenerateRequestId() => Guid.NewGuid().ToString("N");

    public async Task<TOut> CallAsync<TOut, TIn>(NutshellMethods<TOut, TIn> method, TIn input)
        where TIn : class
        => await CallAsync(method, input, await client.Value);

    private async Task<TOut> CallAsync<TOut, TIn>(
        NutshellMethods<TOut, TIn> method,
        TIn input,
        HttpClient httpClient,
        Uri? requestUri = null)
        where TIn : class
    {
        if (!new UnionValue(NutshellMethods.UnionType).TrySetValue(method.Name))
        {
            throw new NutshellApiException($"Invalid method: `{method.Name}`");
        }

        var payload = new
        {
            method = method.Name,
            @params = input,
            id = GenerateRequestId()
        };

        var request = new HttpRequestMessage();

        if (requestUri is not null)
        {
            request.RequestUri = requestUri;
        }

        request.Method = HttpMethod.Post;
        var data = payload is IProjection projection ? projection.GetProjection() : payload;
        request.Content = JsonContent.Create(data);
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
}