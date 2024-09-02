using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.Idin.Responses;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class GetMandateResponse
{
	[JsonPropertyName("request")]
	public Request? Request { get; set; }

	[JsonPropertyName("result")]
	public MandateResultResponse? Response { get; set; }
}
