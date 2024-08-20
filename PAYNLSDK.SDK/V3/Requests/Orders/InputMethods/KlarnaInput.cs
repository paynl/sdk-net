using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class KlarnaInput : V3InputMethod
{
	[JsonPropertyName("countryCode")]
	public string CountryCode { get; set; }
}
