using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.Utilities.QueryFilterExtensions;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.IntegrationTests.V2;

public class ClearingLines
{
	[Fact]
	public void QueryBuilderTest()
	{
		var queryString = new ClearingLineFilter()
			.WithPage(1)
			.WithLimit(1)
			.WithDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithProcessedDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithProcessedDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithMerchant(StringFilter.NotEqual, "M-1234-4321")
			.WithClearingLineType(10)
			.WithTurnoverGroup("CT-1234-4321")
			.WithState(ClearingState.Cleared)
			.WithClearingId("CLEARING-12345")
			.Build();

		Assert.Equal("page=1&limit=1&date[gt]=2015-01-01&date[lt]=2025-01-01&processedDate[gt]=2015-01-01&processedDate[lt]=2025-01-01&merchant[neq]=M-1234-4321&clearingLineType[eq]=10&turnoverGroup[eq]=CT-1234-4321&state[eq]=CLEARED&clearingID[eq]=CLEARING-12345", queryString);
	}

	[Fact]
	public async Task GetClearings()
	{
		var client = TestHelper.CreateClientV2();

		var queryString = new ClearingLineFilter()
			.WithPage(1)
			.WithLimit(1)
			.WithDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithProcessedDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithProcessedDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithMerchant(StringFilter.NotEqual, "M-1234-4321")
			.WithState(ClearingState.Cleared);

		var clearings = await client.GetClearingLines(queryString);

		Assert.NotNull(clearings);
		Assert.Equal(1, clearings.Count);
	}
}
