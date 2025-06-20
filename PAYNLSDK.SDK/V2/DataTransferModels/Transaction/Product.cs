using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Product
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("type")]
	public string? Type { get; set; }

	[JsonPropertyName("price")]
	public Price? Price { get; set; }

	[JsonPropertyName("quantity")]
	public decimal? Quantity { get; set; }

	[JsonPropertyName("vatCode")]
	public string? VatCode { get; set; }
}
