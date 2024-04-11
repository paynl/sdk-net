using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class Przelewy27Input
{
	[JsonPropertyName("email")]
	public string Email { get; set; }
}
