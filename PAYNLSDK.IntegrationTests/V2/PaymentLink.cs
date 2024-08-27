using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.Services;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.IntegrationTests.V2;

public class PaymentLink
{
	[Fact]
	public async Task PaymentLinkCreate()
	{
		var client = TestHelper.CreateClientV2();

		var paymentLink = await client.PaymentLinkCreate("SL-3490-4320", new PaymentLinkRequest
		{
			SecurityMode = 0,
			Language = "nl_NL",
			Amount = new Amount
			{
				Value = 1
			},
			AmountMin = new Amount
			{
				Value = 1
			},
		});

		Assert.NotNull(paymentLink);
		Assert.NotNull(paymentLink.Url);
		Assert.Equal(0, paymentLink.SecurityMode);
	}
}
