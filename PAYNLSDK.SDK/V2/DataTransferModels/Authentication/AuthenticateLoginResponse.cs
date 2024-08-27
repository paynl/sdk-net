using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication;

public class AuthenticateLoginResponse
{
	[JsonPropertyName("session")]
	public Session? Session { get; set; }

	[JsonPropertyName("_links")]
	public List<Links>? Links { get; set; }
}
