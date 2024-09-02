using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;

public class AuthenticationToken
{
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Specify which kind of authorisation is applicable for the token.
	/// all: all merchant rights
	/// specified: specify which authorisation groups should be enabled from the token. At least one authorisation group (in the authorisationGroups array) is mandatory
	/// </summary>
	[JsonPropertyName("authorisation")]
	public string? Authorisation { get; set; }

	[JsonPropertyName("authorisationGroups")]
	public List<string>? AuthorisationGroups { get; set; }
}
