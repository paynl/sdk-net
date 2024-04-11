using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Vouchers;

public class Voucher
{
    [JsonPropertyName("cardNumber")]
    public string? CardNumber { get; set; }

    [JsonPropertyName("pinCode")]
    public string? PinCode { get; set; }
}