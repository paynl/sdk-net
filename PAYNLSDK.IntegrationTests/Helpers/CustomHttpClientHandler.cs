namespace PayNlSdk.IntegrationTests.Helpers;

public class CustomHttpClientHandler : HttpClientHandler
{
    public static readonly List<string> BlockedDomains = [];
    public readonly List<string> FailedCalls = [];
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var requestUri = request.RequestUri!;

        // Check if the requested domain is in the blocked domains list
        if (IsDomainBlocked(requestUri))
        {
            // You can log the block here if needed
            Console.WriteLine($"Blocked request to {requestUri}");
            FailedCalls.Add(requestUri.ToString());
            return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
        }

        // Continue with the request if the domain is not blocked
        return await base.SendAsync(request, cancellationToken);
    }

    private static bool IsDomainBlocked(Uri uri)
    {
	    return BlockedDomains.Any(blockedDomain => uri.Host.EndsWith(blockedDomain, StringComparison.OrdinalIgnoreCase));
    }
}
