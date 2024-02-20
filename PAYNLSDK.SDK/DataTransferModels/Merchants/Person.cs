using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class Person
{
    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("newsletter")]
    public bool Newsletter { get; set; }

    [JsonPropertyName("visitAddress")]
    public Address? VisitAddress { get; set; }

    [JsonPropertyName("notificationGroup")]
    public NotificationGroup? NotificationGroup { get; set; }

    [JsonPropertyName("complianceData")]
    public ComplianceData? ComplianceData { get; set; }

    [JsonPropertyName("platform")]
    public Platform? Platform { get; set; }
}