using System.Runtime.CompilerServices;
using System.Text;
using PayNlSdk.Sdk.Utilities;

[assembly: InternalsVisibleTo("PayNlSdk.IntegrationTests")]
namespace PayNlSdk.Sdk.Client;

public class PayClientBase : IDisposable
{
    public string ServiceId { get; }
    private string At { get; }
    private string ApiSecret { get; }

    private static string ClientVersion => "1.0.0.0";
    private static string UserAgent => $"PAYNL-Sdk/{ClientVersion} (DotNet)";

    internal static readonly Core DefaultCore = new Core(new Uri("https://rest.pay.nl/v2/"), "Pay.nl (Default)");
    internal readonly PayHttpClient  HttpClient;
    private readonly HttpClient _backingHttpClient;

    protected PayClientBase(string apiSecret, string at, string serviceId, HttpClient? httpClient = default,
        Action<PayRequestLog>? onRequest = default)
    {
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
        HttpClient = new PayHttpClient(_backingHttpClient, onRequest);
    }
    
    public void Dispose()
    {
        _backingHttpClient.Dispose();
    }
}