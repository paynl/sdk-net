using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Idin.Requests;

public class IdinAuthenticationData
{
    /// <summary>
    /// Name of the consumer, including initials, first name, and last name.
    /// </summary>
    [JsonPropertyName("name")]
    public bool Name { get; set; }

    /// <summary>
    /// Address of the consumer (street name, postal code, city, country).
    /// </summary>
    [JsonPropertyName("address")]
    public bool Address { get; set; }

    /// <summary>
    /// Indicates whether the consumer is 18 years or older.
    /// </summary>
    [JsonPropertyName("isEighteen")]
    public bool IsEighteen { get; set; }

    /// <summary>
    /// Birthdate of the consumer.
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public bool DateOfBirth { get; set; }

    /// <summary>
    /// Gender of the consumer (male, female, not specified, unknown).
    /// </summary>
    [JsonPropertyName("gender")]
    public bool Gender { get; set; }

    /// <summary>
    /// Email address of the consumer (if known).
    /// </summary>
    [JsonPropertyName("email")]
    public bool Email { get; set; }

    /// <summary>
    /// Phone number of the consumer (if known).
    /// </summary>
    [JsonPropertyName("phone")]
    public bool Phone { get; set; }
}