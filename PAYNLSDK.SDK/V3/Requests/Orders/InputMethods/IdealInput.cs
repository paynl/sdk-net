using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class IdealInput
{
	[JsonPropertyName("issuerId")]
	public string IssuerId { get; set; }
}
