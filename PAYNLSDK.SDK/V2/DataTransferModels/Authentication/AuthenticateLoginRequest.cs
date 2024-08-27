using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication;

public class AuthenticateLoginRequest
{
	[JsonPropertyName("login")]
	public Login? Login { get; set; }

	[JsonPropertyName("account")]
	public Account? Account { get; set; }
}
