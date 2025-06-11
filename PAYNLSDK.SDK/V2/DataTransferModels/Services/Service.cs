using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Services;

public class Service
{
	/// <summary>
	/// Legacy API support
	/// </summary>
	public string? Id => Code;

	/// <summary>
	/// Legacy API support
	/// </summary>
	public int? TestMode => TestModeBool.HasValue ? TestModeBool.Value ? 1 : 0 : null;

	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("testMode")]
	public bool? TestModeBool { get; set; }

	[JsonPropertyName("secret")]
	public string? Secret { get; set; }

	[JsonPropertyName("createdAt")]
	public DateTime CreatedAt { get; set; }
}
