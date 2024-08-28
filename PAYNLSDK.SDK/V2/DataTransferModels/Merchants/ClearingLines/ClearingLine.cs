using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants.ClearingLines;

public class ClearingLine
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("merchant")]
	public Merchant? Type { get; set; }

	[JsonPropertyName("turnoverGroup")]
	public TurnoverGroup? TurnoverGroup { get; set; }

	[JsonPropertyName("clearingLineType")]
	public ClearingLineType? ClearingLineType { get; set; }

	[JsonPropertyName("unitType")]
	public UnitType? UnitType { get; set; }

	[JsonPropertyName("amount")]
	public Amount? Amount { get; set; }

	[JsonPropertyName("valueDate")]
	public DateTime? ValueDate { get; set; }

	[JsonPropertyName("clearingDate")]
	public DateTime? ClearingDate { get; set; }

	[JsonPropertyName("settlementDate")]
	public DateTime? SettlementDate { get; set; }

	[JsonPropertyName("processedDate")]
	public DateTime? ProcessedDate { get; set; }

	[JsonPropertyName("state")]
	public string? State { get; set; }

	[JsonPropertyName("clearingId")]
	public string? ClearingId { get; set; }
}
