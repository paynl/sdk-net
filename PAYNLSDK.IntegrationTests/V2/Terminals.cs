using System.Text;
using System.Text.Json;
using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.DataTransferModels.Terminals;

#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests.V2;

public class Terminals
{
	[Fact(Skip="No valid ActivationCode for test terminal")]
	public async Task CreateTerminal()
	{
		var client = TestHelper.CreateClientV2();
		var terminal = await client.CreateTerminal(new TerminalRequest
		{
			ServiceId = Environment.GetEnvironmentVariable("PAY_SERVICEID"),
			ActivationCode = "1234-5678-9101",
			Name = "PAX",
			Description = "Test"
		});

		Assert.NotNull(terminal);
	}

    [Fact]
    public async Task GetTerminals()
    {
        var client = TestHelper.CreateClientV2();
        var terminals = await client.GetAllTerminals();

        Assert.NotNull(terminals);
        Assert.NotEmpty(terminals.Terminals);
        Assert.True(terminals.Total > 0);

        var terminal = await client.GetTerminal(terminals.Terminals[0].Code);
        Assert.NotNull(terminal);
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

    [Fact]
    public async Task DeleteAndUndelete()
    {
	    var client = TestHelper.CreateClientV2();
	    await client.DeleteTerminal("TH-4880-4720");

	    var terminal = client.UndeleteTerminal("TH-4880-4720");
	    Assert.NotNull(terminal);
    }
}
