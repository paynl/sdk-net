using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class Layout
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("cssUrl")]
    public string? CssUrl { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("supportingColor")]
    public string? SupportingColor { get; set; }

    [JsonPropertyName("headerTextColor")]
    public string? HeaderTextColor { get; set; }

    [JsonPropertyName("buttonColor")]
    public string? ButtonColor { get; set; }

    [JsonPropertyName("buttonTextColor")]
    public string? ButtonTextColor { get; set; }
}