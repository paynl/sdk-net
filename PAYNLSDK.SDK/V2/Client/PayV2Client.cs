using System.Net;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.Utilities.QueryFilterExtensions;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;
using PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;
using PayNlSdk.Sdk.V2.DataTransferModels.Currencies;
using PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.V2.DataTransferModels.Documents;
using PayNlSdk.Sdk.V2.DataTransferModels.Ip;
using PayNlSdk.Sdk.V2.DataTransferModels.Issuers;
using PayNlSdk.Sdk.V2.DataTransferModels.Licenses;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants.ClearingLines;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants.InvoiceLines;
using PayNlSdk.Sdk.V2.DataTransferModels.PaymentMethods;
using PayNlSdk.Sdk.V2.DataTransferModels.Services;
using PayNlSdk.Sdk.V2.DataTransferModels.SignupProfiles;
using PayNlSdk.Sdk.V2.DataTransferModels.TerminalPayments;
using PayNlSdk.Sdk.V2.DataTransferModels.Terminals;
using PayNlSdk.Sdk.V2.DataTransferModels.Trademarks;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;
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

    public Task<CreateMandateResponse> CreateMandate(CreateMandateRequest body, string? baseurl = "https://rest-api.pay.nl/v3/") => _httpClient.PostAsync<CreateMandateResponse>($"{baseurl}DirectDebit/mandateAdd/json", body)!;

    public Task<FlexibleDirectDebitResponse> CreateFlexibleDirectDebit(FlexibleDirectDebitRequest body, string? baseurl = "https://rest-api.pay.nl/v3/") => _httpClient.PostAsync<FlexibleDirectDebitResponse>($"{baseurl}DirectDebit/mandateDebit/json", body)!;

    public Task<GetMandateResponse> GetMandate(string mandateId, string? baseurl = "https://rest-api.pay.nl/v3/") => _httpClient.GetAsync<GetMandateResponse>($"{baseurl}DirectDebit/info/json?mandateId={mandateId}")!;

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

    public Task<ClearingLinesResponse> GetClearingLines(ClearingLineFilter queryParams) => _httpClient.GetAsync<ClearingLinesResponse>($"clearinglines{queryParams.Build()}")!;

    public Task<InvoiceLinesResponse> GetInvoiceLines(InvoiceLineFilter queryParams) => _httpClient.GetAsync<InvoiceLinesResponse>($"invoicelines{queryParams.Build()}")!;

    public Task<MerchantResponseWrapper> CreateMerchant(CreateMerchantRequest body) => _httpClient.PostAsync<MerchantResponseWrapper>("merchants", body)!;

    public Task<MerchantResponse> GetMerchant(string merchantCode) => _httpClient.GetAsync<MerchantResponse>($"merchants/{merchantCode}")!;

    public Task<MerchantDetailedResponse> GetMerchantDetailed(string merchantCode) => _httpClient.GetAsync<MerchantDetailedResponse>($"merchants/{merchantCode}/info")!;

    public Task<MerchantListResponse> ListMerchants() => _httpClient.GetAsync<MerchantListResponse>("merchants")!;

    public Task DeleteMerchant(string merchantCode) => _httpClient.DeleteAsync($"merchants/{merchantCode}");

    public Task<MerchantResponse> UnDeleteMerchant(string merchantCode) => _httpClient.PostAsync<MerchantResponse>($"merchants/{merchantCode}/undelete")!;

    public Task<MerchantResponse> UpdateMerchant(string merchantCode, UpdateMerchantRequest body) => _httpClient.PatchAsync<MerchantResponse>($"merchants/{merchantCode}", body)!;

    public Task UpdateMerchantPackage(string merchantCode, string referralProfileCode) => _httpClient.PatchAsync<MerchantResponse>($"merchants/{merchantCode}/package", referralProfileCode)!;

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

    public Task<GetTerminalResponse> CreateTerminal(TerminalRequest body) => _httpClient.PostAsync<GetTerminalResponse>("terminals", body)!;

    public Task<GetTerminalResponse> GetTerminal(string terminalCode) => _httpClient.GetAsync<GetTerminalResponse>($"terminals/{terminalCode}")!;

    public Task<TerminalListResponse> GetAllTerminals() => _httpClient.GetAsync<TerminalListResponse>("terminals")!;

    public Task DeleteTerminal(string terminalCode) => _httpClient.DeleteAsync($"terminals/{terminalCode}");

    public Task<TerminalListResponse> UndeleteTerminal(string terminalCode) => _httpClient.PostAsync<TerminalListResponse>($"terminals/{terminalCode}/undelete")!;

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

    public Task<ClearingAccountResponse> CreateClearingAccount(CreateClearingAccountRequest body) => _httpClient.PostAsync<ClearingAccountResponse>("clearingaccounts", body)!;

    public Task<ClearingAccountResponse> GetClearingAccount(string clearingAccountCode) => _httpClient.GetAsync<ClearingAccountResponse>($"clearingaccounts/{clearingAccountCode}")!;

    public Task<ClearingAccountBrowseResponse> BrowseClearingAccounts(string merchantCode) => _httpClient.GetAsync<ClearingAccountBrowseResponse>($"clearingaccounts?merchant={merchantCode}")!;

    public Task DeleteClearingAccount(string clearingAccountCode) => _httpClient.DeleteAsync($"clearingaccounts/{clearingAccountCode}");

    public Task<ClearingAccountResponse> UndeleteClearingAccount(string clearingAccountCode) => _httpClient.PostAsync<ClearingAccountResponse>($"clearingaccounts/{clearingAccountCode}/undelete")!;

    public Task<ContactMethodResponse> CreateContactMethod(CreateContactMethodsRequest body) => _httpClient.PostAsync<ContactMethodResponse>("contactmethods", body)!;

    public Task<ContactMethodResponse> UpdateContactMethod(string contactMethodCode, ContactMethod body) => _httpClient.PatchAsync<ContactMethodResponse>($"contactmethods/{contactMethodCode}", body)!;

    public Task<ContactMethodResponse> GetContactMethod(string contactMethodCode) => _httpClient.GetAsync<ContactMethodResponse>($"contactmethods/{contactMethodCode}")!;

    public Task<ContactMethodsResponse> BrowseContactMethods(string merchantCode) => _httpClient.GetAsync<ContactMethodsResponse>($"contactmethods?merchant={merchantCode}")!;

    public Task DeleteContactMethod(string contactMethodCode) => _httpClient.DeleteAsync($"contactmethods/{contactMethodCode}");

    public Task<ContactMethodResponse> UndeleteContactMethod(string clearingAccountCode) => _httpClient.PostAsync<ContactMethodResponse>($"clearingaccounts/{clearingAccountCode}/undelete")!;

    public Task<LicenseResponse> CreateLicense(LicenseRequest body) => _httpClient.PostAsync<LicenseResponse>("licenses", body)!;

    public Task<LicenseResponse> UpdateLicense(string licenseCode, LicenseUpdateRequest body) => _httpClient.PatchAsync<LicenseResponse>($"licenses/{licenseCode}", body)!;

    public Task<LicenseResponse> GetLicense(string licenseCode) => _httpClient.GetAsync<LicenseResponse>($"licenses/{licenseCode}")!;

    public Task<LicensesBrowseResponse> BrowseLicenses(string merchantCode) => _httpClient.GetAsync<LicensesBrowseResponse>($"licenses?merchant={merchantCode}")!;

    public Task DeleteLicense(string licenseCode) => _httpClient.DeleteAsync($"licenses/{licenseCode}");

    public Task<LicenseResponse> UndeleteLicense(string licenseCode) => _httpClient.PostAsync<LicenseResponse>($"licenses/{licenseCode}/undelete")!;

    public Task<TurnoverGroupResponse> CreateTurnoverGroup(TurnoverGroupRequest body) => _httpClient.PostAsync<TurnoverGroupResponse>("turnovergroups", body)!;

    public Task<TurnoverGroupResponse> GetTurnoverGroup(string turnoverGroupCode) => _httpClient.GetAsync<TurnoverGroupResponse>($"turnovergroups/{turnoverGroupCode}")!;

    public Task<TurnoverGroupBrowseResponse> BrowseTurnoverGroups(string merchantCode) => _httpClient.GetAsync<TurnoverGroupBrowseResponse>($"turnovergroups?merchant={merchantCode}")!;

    public Task DeleteTurnoverGroup(string turnoverGroupCode) => _httpClient.DeleteAsync($"turnovergroups/{turnoverGroupCode}");

    public Task<TurnoverGroupResponse> UndeleteTurnoverGroup(string turnoverGroupCode) => _httpClient.PostAsync<TurnoverGroupResponse>($"turnovergroups/{turnoverGroupCode}/undelete")!;
}
