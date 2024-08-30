using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Licenses;

public class Roles
{
	[JsonPropertyName("primaryContactPerson")]
	public bool? PrimaryContactPerson { get; set; }

	[JsonPropertyName("internalAdministrator")]
	public bool? InternalAdministrator { get; set; }
}
