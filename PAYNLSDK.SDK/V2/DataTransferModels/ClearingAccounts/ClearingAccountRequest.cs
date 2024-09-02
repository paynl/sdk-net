using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;

public class ClearingAccountRequest
{
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("iban")]
    public Iban? Iban { get; set; }

    [JsonPropertyName("documents")]
    public ClearingDocuments? Documents { get; set; }
}
