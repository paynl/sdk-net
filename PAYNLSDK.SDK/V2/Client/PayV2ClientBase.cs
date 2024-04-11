using System.Runtime.CompilerServices;
using System.Text;
using PayNlSdk.Sdk.Utilities;

[assembly: InternalsVisibleTo("PayNlSdk.IntegrationTests")]
namespace PayNlSdk.Sdk.V2.Client;

public abstract class PayV2ClientBase : IDisposable
{
    public string ServiceId { get; }
    private string At { get; }
    private string ApiSecret { get; }

    protected virtual string ClientVersion => "1.0.0.0";
    private string UserAgent => $"PAYNL-Sdk/{ClientVersion} (DotNet)";

    protected virtual Core DefaultCore => new Core(new Uri("https://rest.pay.nl/v2/"), "Pay.nl (Default)");
    public static Core s_DefaultCore;
    internal readonly PayHttpClient  _httpClient;
    private readonly HttpClient _backingHttpClient;

    protected PayV2ClientBase(string apiSecret, string at, string serviceId, HttpClient? httpClient = default,
        Action<PayRequestLog>? onRequest = default)
    {
	    s_DefaultCore = DefaultCore;
        ApiSecret = apiSecret;
        At = at;
        ServiceId = serviceId;

        _backingHttpClient = httpClient ?? new HttpClient();
        _backingHttpClient.BaseAddress = DefaultCore.Url;
        if (_backingHttpClient.DefaultRequestHeaders.All(x => x.Key != "Authorization"))
        {
            _backingHttpClient.DefaultRequestHeaders.Add("Authorization",
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(At + ":" + ApiSecret)));
        }
        if (_backingHttpClient.DefaultRequestHeaders.All(x => x.Key != "Accept"))
        {
            _backingHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        if (_backingHttpClient.DefaultRequestHeaders.All(x => x.Key != "User-Agent"))
        {
            _backingHttpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }
        _httpClient = new PayHttpClient(_backingHttpClient, onRequest);
    }

    public void Dispose()
    {
        _backingHttpClient.Dispose();
    }
}
