using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;

public class ClearingDocuments
{
	/// <summary>
	/// The filename for the document file, which can be a PDF, PNG, GIF or JP(E)G
	/// </summary>
	[JsonPropertyName("fileName")]
	public string? FileName { get; set; }

	/// <summary>
	/// An array of (base64 encoded) content (strings) of the files for the document
	/// </summary>
	[JsonPropertyName("files")]
	public List<string>? Files { get; set; }
}
