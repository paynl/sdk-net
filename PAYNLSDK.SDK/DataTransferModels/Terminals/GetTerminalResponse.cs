using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Shared;

namespace PayNlSdk.Sdk.DataTransferModels.Terminals;

public class GetTerminalResponse
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("attribution")]
    public string? Attribution { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("connectionStatus")]
    public string? ConnectionStatus { get; set; }

    [JsonPropertyName("merchant")]
    public SmallMerchantInfo? Merchant { get; set; }

    [JsonPropertyName("service")]
    public TerminalService? Service { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("terminalType")]
    public string? TerminalType { get; set; }

    [JsonPropertyName("supplier")]
    public TerminalSupplier? Supplier { get; set; }

    [JsonPropertyName("ecrProtocol")]
    public string? EcrProtocol { get; set; }

    [JsonPropertyName("contractStartDate")]
    public string? ContractStartDate { get; set; }

    [JsonPropertyName("contractEndDate")]
    public string? ContractEndDate { get; set; }

    [JsonPropertyName("paymentTypes")]
    public List<string>? PaymentTypes { get; set; }

    [JsonPropertyName("terminalBrands")]
    public List<TerminalBrand>? TerminalBrands { get; set; }

    [JsonPropertyName("location")]
    public TerminalLocation? Location { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("modifiedAt")]
    public DateTime? ModifiedAt { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("deletedAt")]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("deletedBy")]
    public string? DeletedBy { get; set; }
}