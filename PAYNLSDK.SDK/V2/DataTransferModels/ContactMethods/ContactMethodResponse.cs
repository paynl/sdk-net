using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;

public class ContactMethodResponse : ContactMethod
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("marchant")]
	public Merchant? Merchant { get; set; }

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

	[JsonPropertyName("_links")]
	public List<Link>? Links { get; set; }
}
