using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TerminalPayments;

public abstract class PinPaymentStatusResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("terminal")]
    public string? Terminal { get; set; }
}