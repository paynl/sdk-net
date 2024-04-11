using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class KlarnaInput
{
	[JsonPropertyName("countryCode")]
	public string CountryCode { get; set; }
}
