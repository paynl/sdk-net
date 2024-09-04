using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class MandateResultResponse
{
	[JsonPropertyName("mandate")]
	public MandateInfoResponse? Mandate { get; set; }

	[JsonPropertyName("directDebit")]
	public List<MandateDirectDebitInfoResponse>? DirectDebits { get; set; }
}
