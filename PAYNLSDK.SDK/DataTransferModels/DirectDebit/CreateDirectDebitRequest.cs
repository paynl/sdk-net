using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.DataTransferModels.DirectDebit;

public class CreateDirectDebitRequest
{
    [JsonPropertyName("isLastOrder")]
    public bool? IsLastOrder { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("processDate")]
    public string? ProcessDate { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }
}
