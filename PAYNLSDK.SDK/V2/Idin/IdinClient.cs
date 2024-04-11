using System.Net.Http.Headers;
using System.Text;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.Idin.Requests;
using PayNlSdk.Sdk.V2.Idin.Responses;

namespace PayNlSdk.Sdk.V2.Idin;

public class IdinClient
{
    private readonly PayHttpClient _restClient;

    /// <summary>
    /// Creates a new instance of the Idin client, using the given API secret and access token.
    /// </summary>
    /// <param name="apiSecret">Secret token that corresponds with the AT</param>
    /// <param name="at">AT Token, e.g AT-1234-5678</param>
    /// <param name="httpClient">Optional, custom HttpClient. Requires base address and accept headers to be set manually.</param>
    public IdinClient(string apiSecret, string at, HttpClient? httpClient = null)
    {
        httpClient ??= new HttpClient
        {
            BaseAddress = new Uri("https://rest-api.pay.nl/v1/Idin/"),
            DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") }}
        };
        httpClient.DefaultRequestHeaders.Add("Authorization",
            "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(at + ":" + apiSecret)));
        _restClient = new PayHttpClient(httpClient, null);
    }

    /// <summary>
    /// List all available issuers for our iDIN provider
    /// </summary>
    /// <returns>A list of available issuers</returns>
    public Task<IdinIssuerResponse> ListIssuers() => _restClient.PostAsync<IdinIssuerResponse>("getIssuers/json")!;

    /// <summary>
    /// Requesting the consumer's data is done via the API iDIN: authenticate.
    /// When calling, it must be stated which information is requested from the consumer.
    /// The merchant can do this using the "data" parameter. By adding the value "true" to the desired options, data from the consumer will be requested.
    /// </summary>
    public Task<IdinAuthenticationResponse> Authenticate(IdinAuthenticationRequest body)
    {
        var parameters = new Dictionary<string, string>();
        parameters.Add("serviceId", body.ServiceId ?? throw new ArgumentNullException(nameof(body.ServiceId)));
        parameters.Add("reference", body.Reference ?? throw new ArgumentNullException(nameof(body.Reference)));
        parameters.Add("issuerId", body.IssuerId ?? throw new ArgumentNullException(nameof(body.IssuerId)));
        parameters.Add("data[name]", body.Data is { Name: true } ? "1" : "0");
        parameters.Add("data[address]", body.Data is { Address: true } ? "1" : "0");
        parameters.Add("data[isEighteen]", body.Data is { IsEighteen: true } ? "1" : "0");
        parameters.Add("data[dateOfBirth]", body.Data is { DateOfBirth: true } ? "1" : "0");
        parameters.Add("data[gender]", body.Data is { Gender: true } ? "1" : "0");
        parameters.Add("data[email]", body.Data is { Email: true } ? "1" : "0");
        parameters.Add("data[phone]", body.Data is { Phone: true } ? "1" : "0");
        parameters.Add("returnUrl", body.ReturnUrl ?? throw new ArgumentNullException(nameof(body.ReturnUrl)));

        return _restClient.PostUrlEncodedAsync<IdinAuthenticationResponse>("authenticate/json", parameters)!;
    }

    /// <summary>
    /// After the authentication has been completed, the consumer's data is forwarded to the merchant by means of an exchange request.
    /// The merchant has the option to request the data again later via this API.
    /// </summary>
    public Task<IdinAuthenticationStatusResponse> GetStatus(string transactionId)
    {
	    var request = new Dictionary<string, string> { { "trxid", transactionId } };
	    return _restClient.PostUrlEncodedAsync<IdinAuthenticationStatusResponse>("status/json", request)!;
    }
}
