using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class PaymentData
{
    [JsonPropertyName("method")]
    public string? Method { get; set; } // Payment method of the transaction.

    [JsonPropertyName("customerKey")]
    public string? CustomerKey { get; set; } // Customer key of the customer from the transaction.

    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; } // Customer id of the customer from the transaction.

    [JsonPropertyName("customerName")]
    public string? CustomerName { get; set; } // Customer name of the customer from the transaction.

    [JsonPropertyName("customerIpAddress")]
    public string? CustomerIpAddress { get; set; } // Ip address of the customer from the transaction.

    [JsonPropertyName("secureStatus")]
    public bool? SecureStatus { get; set; } // Secure status of the transaction.

    [JsonPropertyName("paymentVerificationMethod")]
    public int? PaymentVerificationMethod { get; set; }
    
    [JsonPropertyName("iban")]
    public Iban? Iban { get; set; }
}