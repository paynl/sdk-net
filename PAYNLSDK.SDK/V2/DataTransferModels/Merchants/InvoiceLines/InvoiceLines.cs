using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants.InvoiceLines;

public class InvoiceLines
{
	[JsonPropertyName("transactions")]
	public int Transactions { get; set; }

	[JsonPropertyName("payers")]
	public int Payers { get; set; }

	[JsonPropertyName("vatPercentage")]
	public int VatPercentage { get; set; }

	[JsonPropertyName("date")]
	public DateTime? Date { get; set; }

	[JsonPropertyName("valueDate")]
	public DateTime? ValueDate { get; set; }

	[JsonPropertyName("paymentDate")]
	public DateTime? PaymentDate { get; set; }

	[JsonPropertyName("state")]
	public string? State { get; set; }

	[JsonPropertyName("invoiceID")]
	public string? InvoiceId { get; set; }

	[JsonPropertyName("lines")]
	public List<Line>? Lines { get; set; }
}
