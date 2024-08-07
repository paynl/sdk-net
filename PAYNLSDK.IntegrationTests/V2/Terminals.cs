using PayNlSdk.IntegrationTests.Helpers;

#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests.V2;

public class Terminals
{
    [Fact(Skip = "No rights to access this endpoint")]
    public async Task GetTerminals()
    {
        var client = TestHelper.CreateClientV2();
        var terminals = await client.GetAllTerminals();

        Assert.NotNull(terminals);
        Assert.NotEmpty(terminals.Terminals);
        Assert.True(terminals.Total > 0);
        Assert.Equal(terminals.Total, terminals.Terminals.Count());
    }
}