using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class IdealInput : V3InputMethod
{
	[JsonPropertyName("issuerId")]
	public string IssuerId { get; set; }
}
