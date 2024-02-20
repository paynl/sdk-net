using PayNlSdk.Sdk.DataTransferModels;
using PayNlSdk.Sdk.DataTransferModels.Config;
using PayNlSdk.Sdk.DataTransferModels.Transaction;
using PayNlSdk.Sdk.Utilities;

namespace PayNlSdk.Sdk.Client;

public class MultiCorePayClient : PayClientBase
{
    // Multicore switching variables
    internal int ActiveEndpointIndex = 0;
    internal const int PreferredEndpointIndex = 0;
    internal readonly int RetryCount = 10;

    internal static bool IsInitialized;
    public static List<Core> AvailableCores = new List<Core> { DefaultCore };
    private readonly MultiCoreRequester _multiCoreRequester;
    private readonly IPayClient _payClient;

    /// <summary>
    ///     Create a new Multicore PAY client. Call <see cref="MultiCorePayClient.Initialize"/> first.
    /// </summary>
    /// <param name="apiSecret">PAYNL Api secret</param>
    /// <param name="at">PAYNL AT</param>
    /// <param name="serviceId">PAYNL Service ID</param>
    /// <param name="httpClient">Optional http client to handle requests</param>
    /// <param name="onRequest">Optional callback to call after each request</param>
    public MultiCorePayClient(string apiSecret, string at, string serviceId, HttpClient? httpClient = null, Action<PayRequestLog>? onRequest = default) : base(apiSecret, at, serviceId, httpClient, onRequest)
    {
        _multiCoreRequester = new MultiCoreRequester(this);
        _payClient = new PayClient(apiSecret, at, serviceId, httpClient, onRequest);
    }

    /// <summary>
    /// Initialize the multicore client. This will fetch the available cores from the PAY API.
    /// </summary>
    public void Initialize()
    {
        if (!IsInitialized)
        {
            var response = HttpClient
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
    public Task<CreateTransactionResponse?> CreateTransactionMultiCore(CreateTransactionRequest body) => _multiCoreRequester.ExecuteWithAutomaticCoreSwitching(() => _payClient.CreateTransaction(body, MultiCorePayClient.AvailableCores[ActiveEndpointIndex]));

    /// <summary>
    /// Retrieve new transaction using the multi core system. (https://developer.pay.nl/docs/transaction-gateway-unit)
    /// </summary>
    /// <returns>Class containing information about the transaction</returns>
    public Task<GetTransactionResponse?> GetTransactionMultiCore(string transactionId) => _multiCoreRequester.ExecuteWithAutomaticCoreSwitching(() => _payClient.GetTransactionInfo(transactionId, MultiCorePayClient.AvailableCores[ActiveEndpointIndex]));

    /// <summary>
    /// Cancel a transaction using the multi core system. (https://developer.pay.nl/docs/transaction-gateway-unit)
    /// </summary>
    /// <returns>Class containing information about the cancelled transaction</returns>
    public Task<CancelTransactionResponse?> CancelTransactionMultiCore(string transactionId) => _multiCoreRequester.ExecuteWithAutomaticCoreSwitching(() => _payClient.CancelTransaction(transactionId, MultiCorePayClient.AvailableCores[ActiveEndpointIndex]));
}
