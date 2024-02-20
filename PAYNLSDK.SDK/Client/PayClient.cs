using System.Net;
using PayNlSdk.Sdk.DataTransferModels.Currencies;
using PayNlSdk.Sdk.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.DataTransferModels.Ip;
using PayNlSdk.Sdk.DataTransferModels.Issuers;
using PayNlSdk.Sdk.DataTransferModels.Merchants;
using PayNlSdk.Sdk.DataTransferModels.PaymentMethods;
using PayNlSdk.Sdk.DataTransferModels.Services;
using PayNlSdk.Sdk.DataTransferModels.SignupProfiles;
using PayNlSdk.Sdk.DataTransferModels.TerminalPayments;
using PayNlSdk.Sdk.DataTransferModels.Terminals;
using PayNlSdk.Sdk.DataTransferModels.Trademarks;
using PayNlSdk.Sdk.DataTransferModels.Transaction;
using PayNlSdk.Sdk.DataTransferModels.Vouchers;
using PayNlSdk.Sdk.Utilities;
using Service = PayNlSdk.Sdk.DataTransferModels.Merchants.Service;

namespace PayNlSdk.Sdk.Client;

public class PayClient : PayClientBase, IPayClient
{
    /// <summary>
    ///     Create a new PAY client.
    /// </summary>
    /// <param name="apiSecret">PAYNL Api secret</param>
    /// <param name="at">PAYNL AT</param>
    /// <param name="serviceId">PAYNL Service ID</param>
    /// <param name="httpClient">Optional http client to handle requests</param>
    /// <param name="onRequest">Optional callback to run each request</param>
    public PayClient(string apiSecret, string at, string serviceId, HttpClient? httpClient = null,
        Action<PayRequestLog>? onRequest = default) : base(apiSecret, at, serviceId, httpClient, onRequest)
    { }

    public Task<CurrencyCollection?> GetAllCurrencies() => HttpClient.GetAsync<CurrencyCollection>("currencies");

    public Task<IssuerListResponse?> GetAllPaymentIssuers() => HttpClient.GetAsync<IssuerListResponse>("issuers");

    public Task<DirectDebitResponse> CreateDirectDebit(string incassoOrderId, CreateDirectDebitRequest body) => HttpClient.PostAsync<DirectDebitResponse>($"directdebits/{incassoOrderId}/debits", body)!;

    public Task<DirectDebitResponse> GetDirectDebit(string incassoOrderId) => HttpClient.GetAsync<DirectDebitResponse>($"directdebits/{incassoOrderId}")!;

    public Task DeleteDirectDebit(string incassoOrderId) => HttpClient.DeleteAsync($"directdebits/{incassoOrderId}");

    public Task<DirectDebitResponse> UpdateDirectDebit(string incassoOrderId, UpdateDirectDebitRequest body) => HttpClient.PatchAsync<DirectDebitResponse>($"directdebits/{incassoOrderId}", body)!;

    public async Task<bool> IpIsPay(string ip)
    {
        var res = await HttpClient.GetAsyncNoExceptionHandling($"ispay/ip?value={ip}");
        if (res.StatusCode == HttpStatusCode.NotFound)
        {
            return false;
        }

        if (res.IsSuccessStatusCode)
        {
            return true;
        }
        await res.HandleException();
        return false;
    }

    public Task<IpListResponse> GetAllIps() => HttpClient.GetAsync<IpListResponse>("ipaddresses")!;

    public Task<MerchantResponseWrapper> CreateMerchant(CreateMerchantRequest body) => HttpClient.GetAsync<MerchantResponseWrapper>("merchants")!;

    public Task<MerchantResponse> GetMerchant(string merchantCode) => HttpClient.GetAsync<MerchantResponse>($"merchants/{merchantCode}")!;

    public Task<MerchantListResponse> ListMerchants() => HttpClient.GetAsync<MerchantListResponse>("merchants")!;

    public Task DeleteMerchant(string merchantCode) => HttpClient.DeleteAsync($"merchants/{merchantCode}");

    public Task<MerchantResponse> UpdateMerchant(string merchantCode, UpdateMerchantRequest body) => HttpClient.PatchAsync<MerchantResponse>($"merchants/{merchantCode}", body)!;

    public Task RequestMerchantReview(string merchantCode) => HttpClient.PatchAsync($"merchants/{merchantCode}/ready");

    public Task<GetAllPackagesResponse> GetAllPackages() => HttpClient.GetAsync<GetAllPackagesResponse>("packages")!;

    public async Task<IssuerListResponse?> GetAllPaymentIssuersForId(int paymentMethodId)
    {
        var res = await GetAllPaymentIssuers();
        res!.Issuers = res.Issuers?.Where(x => x.PaymentMethod?.Id == paymentMethodId).ToList();
        return res;
    }

    public Task<PaymentMethodCollection> GetAllPaymentMethods() => HttpClient.GetAsync<PaymentMethodCollection>("paymentmethods")!;

    public Task<ServiceListResponse> GetAllServices() => HttpClient.GetAsync<ServiceListResponse>("services")!;

    public Task<Service> GetService(string serviceId) => HttpClient.GetAsync<Service>($"services/{serviceId}")!;

    public Task<PinPaymentStatusResponse> GetPinTransactionStatus(string transactionHash, int timeout = 5) => HttpClient.GetAsync<PinPaymentStatusResponse>($"https://pin.pay.nl/api/status?hash={transactionHash}&timeout={timeout}")!;

    public Task<PinTransactionCancelResponse> CancelPinTransaction(string transactionHash) => HttpClient.GetAsync<PinTransactionCancelResponse>($"https://pin.pay.nl/api/cancel?hash={transactionHash}")!;

    public Task<GetTerminalResponse> GetTerminal(string terminalCode) => HttpClient.GetAsync<GetTerminalResponse>($"terminals/{terminalCode}")!;

    public Task<TerminalListResponse> GetAllTerminals() => HttpClient.GetAsync<TerminalListResponse>("terminals")!;

    public Task<TrademarkResponse> GetTrademark(string trademarkCode) => HttpClient.GetAsync<TrademarkResponse>($"trademarks/{trademarkCode}")!;

    public Task<TrademarkListResponse> GetAllTrademarks() => HttpClient.GetAsync<TrademarkListResponse>("trademarks")!;

    public Task<TrademarkResponse> CreateTrademark(CreateTrademarkRequest body) => HttpClient.PostAsync<TrademarkResponse>("trademarks", body)!;

    public Task<TrademarkResponse> UnsuspendTrademark(string trademarkCode) => HttpClient.PostAsync<TrademarkResponse>($"trademarks/{trademarkCode}/unsuspend")!;

    public Task SuspendTrademark(string trademarkCode) => HttpClient.DeleteAsync($"trademarks/{trademarkCode}/unsuspend");

    public Task<VoucherCreationResponse?> CreateVoucher(VoucherCreationRequest request)
    {
        request.Transaction ??= new Transaction();
        request.Transaction.ServiceId ??= ServiceId;

        return HttpClient.PostAsync<VoucherCreationResponse>("vouchers/transaction", request);
    }

    public async Task<CreateTransactionResponse?> CreateTransaction(CreateTransactionRequest body, Core? core = null)
    {
        core ??= PayClient.DefaultCore;
        body.ServiceId = string.IsNullOrEmpty(body.ServiceId) ? ServiceId : body.ServiceId;

        return await HttpClient.PostAsync<CreateTransactionResponse>(core.Url.AbsoluteUri + "transactions", body);
    }

    public Task<GetTransactionResponse?> GetTransactionInfo(string transactionId, Core? core = null)
    {
        core ??= PayClient.DefaultCore;
        return HttpClient.GetAsync<GetTransactionResponse>($"{core.Url.AbsoluteUri}transactions/{transactionId}");
    }

    public Task<CancelTransactionResponse?> CancelTransaction(string transactionId, Core? core = null)
    {
        core ??= PayClient.DefaultCore;
        return HttpClient.PatchAsync<CancelTransactionResponse>($"{core.Url.AbsoluteUri}transactions/{transactionId}/cancel");
    }

    public Task<SuccessfulRefundResponse> RefundTransaction(string transactionId, RefundTransactionRequest body) => HttpClient.PatchAsync<SuccessfulRefundResponse>($"transactions/{transactionId}/refund", body)!;

    public Task<ApproveDenyTransactionResponse> ApproveTransaction(string transactionId) => HttpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/refund")!;

    public Task<ApproveDenyTransactionResponse> DeclineTransaction(string transactionId) => HttpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/decline")!;

    public Task<ApproveDenyTransactionResponse> CaptureTransaction(string transactionId, CaptureTransactionRequest body) => HttpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/capture", body)!;

    public Task<ApproveDenyTransactionResponse> VoidTransaction(string transactionId) => HttpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/void")!;

    public Task<LoadTransactionResponse> LoadTransaction(string transactionId) => HttpClient.PatchAsync<LoadTransactionResponse>($"transactions/{transactionId}/load")!;
}
