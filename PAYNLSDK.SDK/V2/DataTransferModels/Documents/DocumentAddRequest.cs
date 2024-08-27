using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Documents;

public class DocumentAddRequest
{
	/// <summary>
	/// Code of the acceptance document.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Name of the file.
	/// </summary>
	[JsonPropertyName("fileName")]
	public string? FileName { get; set; }

	/// <summary>
	/// Base64 encoding of the file.
	/// </summary>
	[JsonPropertyName("documentFile")]
	public string DocumentFile { get; set; }

	/// <summary>
	/// Array of base64 encoded files.
	/// </summary>
	[JsonPropertyName("files")]
	public List<string> Files { get; set; }
}
