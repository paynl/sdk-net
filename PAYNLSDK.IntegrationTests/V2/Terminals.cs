using System.Text;
using System.Text.Json;
using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.DataTransferModels.Terminals;

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

    [Fact]
    public async Task CanParseSupplier()
    {
	    const string inputInt = "{\"id\":11,\"name\":\"Test Supplier\",\"terminalId\":\"test123\"}";
	    const string inputString = "{\"id\":\"12\",\"name\":\"Test Supplier\",\"terminalId\":\"test123\"}";

	    var convertedInt = await Json.DeserializeAsync<TerminalSupplier>(new MemoryStream(Encoding.UTF8.GetBytes(inputInt)));
	    Assert.Equal(convertedInt?.Id, 11);
	    var convertedString = await Json.DeserializeAsync<TerminalSupplier>(new MemoryStream(Encoding.UTF8.GetBytes(inputString)));
	    Assert.Equal(convertedString?.Id, 12);
    }
}
