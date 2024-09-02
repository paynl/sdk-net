using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;

namespace PayNlSdk.IntegrationTests.V2;

public class TurnoverGroups
{
	[Fact]
	public async Task CreateTurnoverGroups()
	{
		var client = TestHelper.CreateClientV2();

		var turnoverGroup = await client.CreateTurnoverGroup(new TurnoverGroupRequest
		{
			MerchantCode = "M-3421-2120",
			TurnoverGroup = new TurnoverGroup
			{
				Name = "Standaard",
				Default = true,
				Description = "Test"
			}
		});

		Assert.NotNull(turnoverGroup.Code);

		await client.DeleteTurnoverGroup(turnoverGroup.Code);
		var undeletedAccount = await client.UndeleteTurnoverGroup(turnoverGroup.Code);
		Assert.NotNull(undeletedAccount);
		Assert.Equal(undeletedAccount.Code, turnoverGroup.Code);

		await client.DeleteTurnoverGroup(turnoverGroup.Code);
	}

	[Fact]
	public async Task GetTurnoverGroups()
	{
		var client = TestHelper.CreateClientV2();
		var turnoverGroups = await client.BrowseTurnoverGroups("M-3421-2120");

		Assert.NotNull(turnoverGroups.TurnoverGroups);
		Assert.NotNull(turnoverGroups.TurnoverGroups[0].Code);
		var turnoverGroup = await client.GetTurnoverGroup(turnoverGroups.TurnoverGroups[0].Code!);

		Assert.NotNull(turnoverGroup);
	}
}
