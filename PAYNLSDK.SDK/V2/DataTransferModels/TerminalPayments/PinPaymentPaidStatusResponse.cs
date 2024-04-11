using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TerminalPayments;

public class PinPaymentPaidStatusResponse : PinPaymentStatusResponse
{
    [JsonPropertyName("cardbrandlabelname")]
    public string? CardBrandLabelName { get; set; }

    [JsonPropertyName("cardbrandidentifier")]
    public string? CardBrandIdentifier { get; set; }

    [JsonPropertyName("approvalID")]
    public string? ApprovalId { get; set; }

    [JsonPropertyName("ticket")]
    public string? Ticket { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("incidentcode")]
    public string? IncidentCode { get; set; }

    [JsonPropertyName("incidentcodetext")]
    public string? IncidentCodeText { get; set; }

    [JsonPropertyName("cancelled")]
    public string? Cancelled { get; set; }

    [JsonPropertyName("approved")]
    public string? Approved { get; set; }
}