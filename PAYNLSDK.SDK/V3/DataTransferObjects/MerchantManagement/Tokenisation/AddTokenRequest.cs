using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V3.DataTransferObjects.PaymentInformation;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.MerchantManagement.Tokenisation;

public class AddTokenRequest
{
	[JsonPropertyName("payment")]
	public Payment? Payment { get; set; }

	[JsonPropertyName("options")]
	public Options? Options { get; set; }

	[JsonPropertyName("customer")]
	public Customer? Customer { get; set; }
}
