using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.TerminalPayments;

public abstract class PinPaymentStatusResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("terminal")]
    public string? Terminal { get; set; }
}