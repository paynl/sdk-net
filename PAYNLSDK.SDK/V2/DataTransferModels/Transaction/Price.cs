using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Price
{
    [JsonPropertyName("value")]
    public int? Value { get; set; }

    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    [JsonPropertyName("vatCode")]
    public string? VatCode { get; set; }
}