using System.Net;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.Currencies;
using PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.V2.DataTransferModels.Documents;
using PayNlSdk.Sdk.V2.DataTransferModels.Ip;
using PayNlSdk.Sdk.V2.DataTransferModels.Issuers;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;
using PayNlSdk.Sdk.V2.DataTransferModels.PaymentMethods;
using PayNlSdk.Sdk.V2.DataTransferModels.Services;
using PayNlSdk.Sdk.V2.DataTransferModels.SignupProfiles;
using PayNlSdk.Sdk.V2.DataTransferModels.TerminalPayments;
using PayNlSdk.Sdk.V2.DataTransferModels.Terminals;
using PayNlSdk.Sdk.V2.DataTransferModels.Trademarks;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V2.DataTransferModels.Vouchers;
using Service = PayNlSdk.Sdk.V2.DataTransferModels.Merchants.Service;

namespace PayNlSdk.Sdk.V2.Client;

public class PayV2Client : PayV2ClientBase, IPayV2Client
{
    /// <summary>
    ///     Create a new PAY client.
    /// </summary>
    /// <param name="apiSecret">PAYNL Api secret</param>
    /// <param name="at">PAYNL AT</param>
    /// <param name="serviceId">PAYNL Service ID</param>
    /// <param name="httpClient">Optional http client to handle requests</param>
    /// <param name="onRequest">Optional callback to run each request</param>
    public PayV2Client(string apiSecret, string at, string serviceId, HttpClient? httpClient = null,
        Action<PayRequestLog>? onRequest = default) : base(apiSecret, at, serviceId, httpClient, onRequest)
    { }

    public Task<CurrencyCollection?> GetAllCurrencies() => _httpClient.GetAsync<CurrencyCollection>("currencies");

    public Task<IssuerListResponse?> GetAllPaymentIssuers() => _httpClient.GetAsync<IssuerListResponse>("issuers");

    public Task<DirectDebitResponse> CreateDirectDebit(string incassoOrderId, CreateDirectDebitRequest body) => _httpClient.PostAsync<DirectDebitResponse>($"directdebits/{incassoOrderId}/debits", body)!;

    public Task<DirectDebitResponse> GetDirectDebit(string incassoOrderId) => _httpClient.GetAsync<DirectDebitResponse>($"directdebits/{incassoOrderId}")!;

    public Task DeleteDirectDebit(string incassoOrderId) => _httpClient.DeleteAsync($"directdebits/{incassoOrderId}");

    public Task<DirectDebitResponse> UpdateDirectDebit(string incassoOrderId, UpdateDirectDebitRequest body) => _httpClient.PatchAsync<DirectDebitResponse>($"directdebits/{incassoOrderId}", body)!;

    public Task<DirectDebitResponse> CreateDirectDebitOrder(CreateDirectDebitOrderRequest body) => _httpClient.PostAsync<DirectDebitResponse>("directdebits", body)!;

    public async Task<bool> IpIsPay(string ip)
    {
        var res = await _httpClient.GetAsyncNoExceptionHandling($"ispay/ip?value={ip}");
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

    public Task<IpListResponse> GetAllIps() => _httpClient.GetAsync<IpListResponse>("ipaddresses")!;

    public Task<MerchantResponseWrapper> CreateMerchant(CreateMerchantRequest body) => _httpClient.GetAsync<MerchantResponseWrapper>("merchants")!;

    public Task<MerchantResponse> GetMerchant(string merchantCode) => _httpClient.GetAsync<MerchantResponse>($"merchants/{merchantCode}")!;

    public Task<MerchantListResponse> ListMerchants() => _httpClient.GetAsync<MerchantListResponse>("merchants")!;

    public Task DeleteMerchant(string merchantCode) => _httpClient.DeleteAsync($"merchants/{merchantCode}");

    public Task<MerchantResponse> UpdateMerchant(string merchantCode, UpdateMerchantRequest body) => _httpClient.PatchAsync<MerchantResponse>($"merchants/{merchantCode}", body)!;

    public Task RequestMerchantReview(string merchantCode) => _httpClient.PatchAsync($"merchants/{merchantCode}/ready");

    public Task<GetAllPackagesResponse> GetAllPackages() => _httpClient.GetAsync<GetAllPackagesResponse>("packages")!;

    public async Task<IssuerListResponse?> GetAllPaymentIssuersForId(int paymentMethodId)
    {
        var res = await GetAllPaymentIssuers();
        res!.Issuers = res.Issuers?.Where(x => x.PaymentMethod?.Id == paymentMethodId).ToList();
        return res;
    }

    public Task<PaymentMethodCollection> GetAllPaymentMethods() => _httpClient.GetAsync<PaymentMethodCollection>("paymentmethods")!;

    public Task<ServiceListResponse> GetAllServices() => _httpClient.GetAsync<ServiceListResponse>("services")!;

    public Task<Service> GetService(string serviceId) => _httpClient.GetAsync<Service>($"services/{serviceId}")!;

    public Task<PinPaymentStatusResponse> GetPinTransactionStatus(string transactionHash, int timeout = 5) => _httpClient.GetAsync<PinPaymentStatusResponse>($"https://pin.pay.nl/api/status?hash={transactionHash}&timeout={timeout}")!;

    public Task<PinTransactionCancelResponse> CancelPinTransaction(string transactionHash) => _httpClient.GetAsync<PinTransactionCancelResponse>($"https://pin.pay.nl/api/cancel?hash={transactionHash}")!;

    public Task<GetTerminalResponse> GetTerminal(string terminalCode) => _httpClient.GetAsync<GetTerminalResponse>($"terminals/{terminalCode}")!;

    public Task<TerminalListResponse> GetAllTerminals() => _httpClient.GetAsync<TerminalListResponse>("terminals")!;

    public Task<TrademarkResponse> GetTrademark(string trademarkCode) => _httpClient.GetAsync<TrademarkResponse>($"trademarks/{trademarkCode}")!;

    public Task<TrademarkListResponse> GetAllTrademarks() => _httpClient.GetAsync<TrademarkListResponse>("trademarks")!;

    public Task<TrademarkResponse> CreateTrademark(CreateTrademarkRequest body) => _httpClient.PostAsync<TrademarkResponse>("trademarks", body)!;

    public Task<TrademarkResponse> UnsuspendTrademark(string trademarkCode) => _httpClient.PostAsync<TrademarkResponse>($"trademarks/{trademarkCode}/unsuspend")!;

    public Task SuspendTrademark(string trademarkCode) => _httpClient.DeleteAsync($"trademarks/{trademarkCode}/unsuspend");

    public Task<VoucherCreationResponse?> CreateVoucher(VoucherCreationRequest request)
    {
        request.Transaction ??= new Transaction();
        request.Transaction.ServiceId ??= ServiceId;

        return _httpClient.PostAsync<VoucherCreationResponse>("vouchers/transaction", request);
    }

    public async Task<CreateTransactionResponse?> CreateTransaction(CreateTransactionRequest body, Core? core = null)
    {
        core ??= s_DefaultCore;
        body.ServiceId = string.IsNullOrEmpty(body.ServiceId) ? ServiceId : body.ServiceId;

        return await _httpClient.PostAsync<CreateTransactionResponse>(core.Url.AbsoluteUri + "transactions", body);
    }

    public Task<GetTransactionResponse?> GetTransactionInfo(string transactionId, Core? core = null)
    {
        core ??= s_DefaultCore;
        return _httpClient.GetAsync<GetTransactionResponse>($"{core.Url.AbsoluteUri}transactions/{transactionId}");
    }

    public Task<CancelTransactionResponse?> CancelTransaction(string transactionId, Core? core = null)
    {
        core ??= s_DefaultCore;
        return _httpClient.PatchAsync<CancelTransactionResponse>($"{core.Url.AbsoluteUri}transactions/{transactionId}/cancel");
    }

    public Task<SuccessfulRefundResponse> RefundTransaction(string transactionId, RefundTransactionRequest body) => _httpClient.PatchAsync<SuccessfulRefundResponse>($"transactions/{transactionId}/refund", body)!;

    public Task<ApproveDenyTransactionResponse> ApproveTransaction(string transactionId) => _httpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/refund")!;

    public Task<ApproveDenyTransactionResponse> DeclineTransaction(string transactionId) => _httpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/decline")!;

    public Task<ApproveDenyTransactionResponse> CaptureTransaction(string transactionId, CaptureTransactionRequest body) => _httpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/capture", body)!;

    public Task<ApproveDenyTransactionResponse> VoidTransaction(string transactionId) => _httpClient.PatchAsync<ApproveDenyTransactionResponse>($"transactions/{transactionId}/void")!;

    public Task<LoadTransactionResponse> LoadTransaction(string transactionId) => _httpClient.PatchAsync<LoadTransactionResponse>($"transactions/{transactionId}/load")!;

    public Task<DocumentAddResponse> AddDocuments(DocumentAddRequest body) => _httpClient.PostAsync<DocumentAddResponse>("documents", body)!;

    public Task<PaymentLinkResponse> PaymentLinkCreate(string serviceId, PaymentLinkRequest body) => _httpClient.PostAsync<PaymentLinkResponse>($"services/{serviceId}/paymentlink", body)!;

    public Task<AuthenticateLoginResponse> AuthenticateLogin(AuthenticateLoginRequest body) => _httpClient.PostAsync<AuthenticateLoginResponse>("login/authenticate", body)!;

    public Task<AuthenticationTokenResponse> AuthenticationTokenCreate(AuthenticationTokenCreateRequest body) => _httpClient.PostAsync<AuthenticationTokenResponse>("authenticationtokens", body)!;

    public Task<AuthenticationTokenResponse> AuthenticationTokenGet(string authenticationTokenCode) => _httpClient.GetAsync<AuthenticationTokenResponse>($"authenticationtokens/{authenticationTokenCode}")!;

    public Task<AuthenticationTokensResponse> AuthenticationTokenBrowse(string merchantCode) => _httpClient.GetAsync<AuthenticationTokensResponse>($"authenticationtokens?merchant={merchantCode}")!;

    public Task DeleteAuthenticationToken(string authenticationTokenCode) => _httpClient.DeleteAsync($"authenticationtokens/{authenticationTokenCode}");

    public Task<AuthenticationTokenResponse> UndeleteAuthenticationToken(string authenticationTokenCode) => _httpClient.PostAsync<AuthenticationTokenResponse>($"authenticationtokens/{authenticationTokenCode}/undelete")!;
}
