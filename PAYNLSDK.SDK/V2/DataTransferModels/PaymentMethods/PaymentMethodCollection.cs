using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.PaymentMethods;

public class PaymentMethodCollection
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("paymentMethods")]
    public List<PaymentMethod>? PaymentMethods { get; set; }
}