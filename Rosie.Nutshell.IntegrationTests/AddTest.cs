using Rosie.Nutshell.Types.Test;

namespace Rosie.Nutshell.IntegrationTests;

public class AddTest : NutshellTestContainer
{
    [Fact(Skip = "Only active when debugging")]
    public async Task Test()
    {
        // given a valid request
        var request = new AddRequest(1, 2);
        
        // when logging in
        var sut = GetSubjectUnderTest();
        var sum = await sut.CallAsync(NutshellRpc.Add, request);

        // then the result is correct
        Assert.Equal(3, sum);
    }
}