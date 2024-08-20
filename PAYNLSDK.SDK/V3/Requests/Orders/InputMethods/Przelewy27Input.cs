using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class Przelewy27Input : V3InputMethod
{
	[JsonPropertyName("email")]
	public string Email { get; set; }
}
