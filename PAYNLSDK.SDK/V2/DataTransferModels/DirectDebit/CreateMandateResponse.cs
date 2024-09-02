using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class CreateMandateResponse
{
	/// <summary>
	/// The mandate ID of the relevant direct debit, beginning with 'IO-'. This can be used to define the status of the relevant direct debit's ('IL'-code).
	/// </summary>
	[JsonPropertyName("result")]
	public string? MandateId { get; set; }
}