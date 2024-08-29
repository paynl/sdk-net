using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Documents;

public class Document
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("type")]
	public string? Type { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("createdAt")]
	public DateTime? CreatedAt { get; set; }

	[JsonPropertyName("createdBy")]
	public string? CreatedBy { get; set; }

	[JsonPropertyName("acceptedAt")]
	public DateTime? AcceptedAt { get; set; }

	[JsonPropertyName("suspendedAt")]
	public DateTime? SuspendedAt { get; set; }

	[JsonPropertyName("suspendedBy")]
	public string? SuspendedBy { get; set; }

	[JsonPropertyName("modifiedAt")]
	public DateTime? ModifiedAt { get; set; }

	[JsonPropertyName("modifiedBy")]
	public string? ModifiedBy { get; set; }

	[JsonPropertyName("deletedAt")]
	public DateTime? DeletedAt { get; set; }

	[JsonPropertyName("deletedBy")]
	public string? DeletedBy { get; set; }
}
