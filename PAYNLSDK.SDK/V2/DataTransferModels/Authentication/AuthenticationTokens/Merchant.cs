using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;

public class Merchant
{
	/// <summary>
	/// The merchant id of your company starting with M.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// The name of your merchant.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Merchant state
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// The incorporationCountry field represents the country in which the entity is legally registered or incorporated.
	/// </summary>
	[JsonPropertyName("incorporationCountry")]
	public string? IncorporationCountry { get; set; }
}
