using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Licenses;

public class PersonLicense : Person
{
	[JsonPropertyName("roles")]
	public Roles? Roles { get; set; }
}
