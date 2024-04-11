using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Order
{
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("deliveryDate")]
    public string? DeliveryDate { get; set; }

    [JsonPropertyName("invoiceDate")]
    public string? InvoiceDate { get; set; }

    [JsonPropertyName("deliveryAddress")]
    public Address? DeliveryAddress { get; set; }

    [JsonPropertyName("invoiceAddress")]
    public Address? InvoiceAddress { get; set; }

    [JsonPropertyName("products")]
    public List<Product>? Products { get; set; }
}
