using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.Utilities.QueryFilterExtensions;

namespace PayNlSdk.IntegrationTests.V2;

public class InvoiceLines
{
	[Fact]
	public void QueryBuilderTest()
	{
		var queryString = new InvoiceLineFilter()
			.WithPage(1)
			.WithLimit(1)
			.WithDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithProcessedDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithProcessedDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithMerchant(StringFilter.NotEqual, "M-1234-4321")
			.WithBillingLineType(10)
			.WithTurnoverGroup("CT-1234-4321")
			.WithState(InvoiceState.Open)
			.WithInvoiceId("INVOICE-12345")
			.WithType(InvoiceType.Buy)
			.Build();

		Assert.Equal("page=1&limit=1&date[gt]=2015-01-01&date[lt]=2025-01-01&processedDate[gt]=2015-01-01&processedDate[lt]=2025-01-01&merchant[neq]=M-1234-4321&billingLineType[eq]=10&turnoverGroup[eq]=CT-1234-4321&state[eq]=OPEN&invoiceID[eq]=INVOICE-12345&type[eq]=BUY", queryString);
	}

	[Fact]
	public async Task GetInvoices()
	{
		var client = TestHelper.CreateClientV2();

		var queryString = new InvoiceLineFilter()
			.WithPage(1)
			.WithLimit(1)
			.WithDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"))
			.WithProcessedDate(DateFilter.GreaterThan, DateTime.Parse("2015-01-01"))
			.WithProcessedDate(DateFilter.LessThan, DateTime.Parse("2025-01-01"));

		var invoices = await client.GetInvoiceLines(queryString);

		Assert.NotNull(invoices);
		Assert.Equal(1, invoices.Count);
	}
}
