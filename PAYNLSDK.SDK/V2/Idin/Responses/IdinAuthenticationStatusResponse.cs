using System.Text.Json.Serialization;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.Idin.Responses.Authentication;

namespace PayNlSdk.Sdk.V2.Idin.Responses;

public class IdinAuthenticationStatusResponse
{
    [JsonPropertyName("request")]
    public Request? Request { get; set; }

    [JsonPropertyName("data")]
    [JsonConverter(typeof (EmptyStringToNullConverter<IdinAuthenticationData>))]
    public IdinAuthenticationData? Data { get; set; }
}
