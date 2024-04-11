using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class BankAccount
{
    [JsonPropertyName("company")]
    public Company? Company { get; set; }

    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    /// <summary>
    /// When used, this countryCode takes preference over the one set in the deliveryAddress and is then used as the countryCode for this transaction
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("deliveryDate")]
    public DateTime? DeliveryDate { get; set; }

    [JsonPropertyName("invoiceDate")]
    public DateTime? InvoiceDate { get; set; }

    [JsonPropertyName("deliveryAddress")]
    public Address? DeliveryAddress { get; set; }

    [JsonPropertyName("invoiceAddress")]
    public Address? InvoiceAddress { get; set; }

    [JsonPropertyName("products")]
    public List<Product>? Products { get; set; }

    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }
}