using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.Documents;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Licenses;

public class LicenseResponse
{
	/// <summary>
	/// License code.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Name of the license.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The language code consisting of 2 uppercase letters.
	/// Can be one of the following: EN, NL, DE, FR, ES, IT.
	/// You can find all available languages here: https://paynl.readme.io/reference/languages
	/// </summary>
	[JsonPropertyName("language")]
	public string? Language { get; set; }

	[JsonPropertyName("complianceData")]
	public ComplianceData? ComplianceData { get; set; }

	[JsonPropertyName("notificationGroup")]
	public NotificationGroup? NotificationGroup { get; set; }

	[JsonPropertyName("platform")]
	public Platform? Platform { get; set; }

	[JsonPropertyName("merchant")]
	public Merchant? Merchant { get; set; }

	[JsonPropertyName("documents")]
	public List<Document>? Documents { get; set; }

	[JsonPropertyName("roles")]
	public Roles? Roles { get; set; }

	/// <summary>
	/// The creation date time presented in the correct ISO-8601 (a.k.a. ATOM) notation
	/// </summary>
	[JsonPropertyName("createdAt")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The reference to an account or token whom created the entity
	/// </summary>
	[JsonPropertyName("createdBy")]
	public string? CreatedBy { get; set; }

	/// <summary>
	/// The modification date time presented in the correct ISO-8601 (a.k.a. ATOM) notation
	/// </summary>
	[JsonPropertyName("modifiedAt")]
	public DateTime? ModifiedAt { get; set; }

	/// <summary>
	/// The reference to an account or token whom modified the entity
	/// </summary>
	[JsonPropertyName("modifiedBy")]
	public string? ModifiedBy { get; set; }

	/// <summary>
	/// The deletion date time presented in the correct ISO-8601 (a.k.a. ATOM) notation. Can be empty (null)
	/// </summary>
	[JsonPropertyName("deletedAt")]
	public DateTime? DeletedAt { get; set; }

	/// <summary>
	/// The reference to an account or token whome deleted the entity
	/// </summary>
	[JsonPropertyName("deletedBy")]
	public string? DeletedBy { get; set; }

	[JsonPropertyName("links")]
	public List<Link>? Links { get; set; }
}
