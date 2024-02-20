using System.Net;
using System.Text.Json;
using PayNlSdk.Sdk.DataTransferModels;

namespace PayNlSdk.Sdk.Utilities;

internal static class ExceptionHandlingExtension
{
    internal static async Task HandleException(this HttpResponseMessage response)
    {
	    if (response.IsSuccessStatusCode)
	    {
		    return;
	    }

        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized when response.Content != null:
            case HttpStatusCode.NotFound when response.Content != null:
            case HttpStatusCode.MethodNotAllowed when response.Content != null:
            case HttpStatusCode.UnprocessableEntity when response.Content != null:
            case HttpStatusCode.BadRequest when response.Content != null:
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
                catch (JsonException ex1)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new PayNlSdkException($"Unknown error for {response.StatusCode}, Response body: {content}", ex1);
                }
            case HttpStatusCode.InternalServerError:
            case HttpStatusCode.NotImplemented:
            case HttpStatusCode.BadGateway:
            case HttpStatusCode.ServiceUnavailable:
            case HttpStatusCode.GatewayTimeout:
            case HttpStatusCode.HttpVersionNotSupported:
            case HttpStatusCode.VariantAlsoNegotiates:
            case HttpStatusCode.InsufficientStorage:
            case HttpStatusCode.LoopDetected:
            case HttpStatusCode.NotExtended:
            case HttpStatusCode.NetworkAuthenticationRequired:
                throw new PayNlSdkException("Something went wrong on our end, please try again");
            default:
                throw new PayNlSdkException($"Unhandled status code {response.StatusCode}");
        }
    }
}
