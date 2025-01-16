using System.Net;
using System.Text.Json;
using PayNlSdk.Sdk.V2.DataTransferModels;

namespace PayNlSdk.Sdk.Utilities;

internal static class ExceptionHandlingExtension
{
    internal static async Task HandleException(this HttpResponseMessage response)
    {
	    if (response.IsSuccessStatusCode)
	    {
		    return;
	    }

        switch ((int)response.StatusCode)
        {
            case (int)HttpStatusCode.NotFound when response.Content != null:
            case (int)HttpStatusCode.MethodNotAllowed when response.Content != null:
            case (int)HttpStatusCode.BadRequest when response.Content != null:
	        case 422 when response.Content != null:
		        try
		        {
			        var content = await response.Content.ReadAsStringAsync();
			        var error = JsonSerializer.Deserialize<ApiError>(content);
			        if (error != null)
			        {
				        throw new PayNlSdkException(error);
			        }

			        var body = string.IsNullOrWhiteSpace(content) ? string.Empty : $", Response body: {content}";
			        throw new PayNlSdkException($"Unknown error for {response.StatusCode} when calling {response.RequestMessage.RequestUri.AbsoluteUri}{body}");
		        }
		        catch (JsonException)
		        {
			        var content = await response.Content.ReadAsStringAsync() ?? "No body provided in response";
			        throw new PayNlSdkException($"Unknown error for {response.StatusCode}, Response body: {content}");
		        }
	        case (int)HttpStatusCode.Unauthorized:
				throw new PayNlSdkUnauthorizedException("Unauthorized");
            case (int)HttpStatusCode.InternalServerError:
            case (int)HttpStatusCode.NotImplemented:
            case (int)HttpStatusCode.BadGateway:
            case (int)HttpStatusCode.ServiceUnavailable:
            case (int)HttpStatusCode.GatewayTimeout:
            case (int)HttpStatusCode.HttpVersionNotSupported:
                throw new PayNlSdkException("Something went wrong on our end, please try again");
            default:
                throw new PayNlSdkException($"Unhandled status code {response.StatusCode}, body: {(response.Content != null ? (await response.Content.ReadAsStringAsync()) : "No content provided" )}");
        }
    }
}
