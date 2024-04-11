using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class PinInput
{
	[JsonPropertyName("terminalCode")]
	public string TerminalCode { get; set; }
}
