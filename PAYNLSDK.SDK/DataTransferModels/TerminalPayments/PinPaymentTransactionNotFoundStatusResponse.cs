using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.TerminalPayments;

public class PinPaymentTransactionNotFoundStatusResponse : PinPaymentStatusResponse
{
    [JsonPropertyName("errormsg")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}