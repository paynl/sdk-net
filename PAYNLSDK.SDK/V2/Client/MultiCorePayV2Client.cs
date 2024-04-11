using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.DataTransferModels;
using PayNlSdk.Sdk.V2.DataTransferModels.Config;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.Client;

public class MultiCorePayV2Client : PayV2ClientBase
{
    // Multicore switching variables
    internal int ActiveEndpointIndex = 0;
    internal const int PreferredEndpointIndex = 0;
    internal readonly int RetryCount = 10;

    internal static bool IsInitialized;
    public static List<Core> AvailableCores = new List<Core> { s_DefaultCore };
    private readonly MultiCoreRequester _multiCoreRequester;
    private readonly IPayV2Client _payV2Client;

    /// <summary>
    ///     Create a new Multicore PAY client. Call <see cref="MultiCorePayV2Client.Initialize"/> first.
    /// </summary>
    /// <param name="apiSecret">PAYNL Api secret</param>
    /// <param name="at">PAYNL AT</param>
    /// <param name="serviceId">PAYNL Service ID</param>
    /// <param name="httpClient">Optional http client to handle requests</param>
    /// <param name="onRequest">Optional callback to call after each request</param>
    public MultiCorePayV2Client(string apiSecret, string at, string serviceId, HttpClient? httpClient = null, Action<PayRequestLog>? onRequest = default) : base(apiSecret, at, serviceId, httpClient, onRequest)
    {
        _multiCoreRequester = new MultiCoreRequester(this);
        _payV2Client = new PayV2Client(apiSecret, at, serviceId, httpClient, onRequest);
    }

    /// <summary>
    /// Initialize the multicore client. This will fetch the available cores from the PAY API.
    /// </summary>
    public void Initialize()
    {
        if (!IsInitialized)
        {
            var response = _httpClient
                .GetAsync<GetConfigResponse>($"{DefaultCore.Url}/services/config?serviceId={ServiceId}").Result;

            if (response?.TguList == null)
            {
                throw new PayNlSdkException("Unable to retrieve available cores from PAY");
            }

            var coresList = response.TguList.OrderBy(x => x.Id).Select(c =>
                new Core(new Uri($"https://rest.{c.Domain!}/v2/"), c.Domain!, c.Status == "ACTIVE")).ToList();
            AvailableCores = coresList;
        }

        IsInitialized = true;
    }

    /// <summary>
    /// Create a new transaction using the multi core system. (https://developer.pay.nl/docs/transaction-gateway-unit)
    /// </summary>
    /// <returns>Class containing information about the created transaction</returns>
    public Task<CreateTransactionResponse?> CreateTransactionMultiCore(CreateTransactionRequest body) => _multiCoreRequester.ExecuteWithAutomaticCoreSwitching(() => _payV2Client.CreateTransaction(body, MultiCorePayV2Client.AvailableCores[ActiveEndpointIndex]));

    /// <summary>
    /// Retrieve new transaction using the multi core system. (https://developer.pay.nl/docs/transaction-gateway-unit)
    /// </summary>
    /// <returns>Class containing information about the transaction</returns>
    public Task<GetTransactionResponse?> GetTransactionMultiCore(string transactionId) => _multiCoreRequester.ExecuteWithAutomaticCoreSwitching(() => _payV2Client.GetTransactionInfo(transactionId, MultiCorePayV2Client.AvailableCores[ActiveEndpointIndex]));

    /// <summary>
    /// Cancel a transaction using the multi core system. (https://developer.pay.nl/docs/transaction-gateway-unit)
    /// </summary>
    /// <returns>Class containing information about the cancelled transaction</returns>
    public Task<CancelTransactionResponse?> CancelTransactionMultiCore(string transactionId) => _multiCoreRequester.ExecuteWithAutomaticCoreSwitching(() => _payV2Client.CancelTransaction(transactionId, MultiCorePayV2Client.AvailableCores[ActiveEndpointIndex]));
}
