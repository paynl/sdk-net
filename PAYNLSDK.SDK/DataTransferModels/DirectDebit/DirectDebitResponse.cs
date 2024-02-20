using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.DirectDebit;

public class DirectDebitResponse
{
    [JsonPropertyName("mandate")]
    public Mandate? Mandate { get; set; }

    [JsonPropertyName("directDebits")]
    public DirectDebit? DirectDebits { get; set; }
}