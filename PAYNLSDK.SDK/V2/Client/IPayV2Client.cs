using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;
using PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;
using PayNlSdk.Sdk.V2.DataTransferModels.Currencies;
using PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.V2.DataTransferModels.Documents;
using PayNlSdk.Sdk.V2.DataTransferModels.Ip;
using PayNlSdk.Sdk.V2.DataTransferModels.Issuers;
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
using PayNlSdk.Sdk.V2.DataTransferModels.Vouchers;
using Service = PayNlSdk.Sdk.V2.DataTransferModels.Merchants.Service;

namespace PayNlSdk.Sdk.V2.Client;

public interface IPayV2Client
{
	public string ServiceId { get; }

    /// <summary>
    ///     Get all currencies.
    /// </summary>
    Task<CurrencyCollection?> GetAllCurrencies();

    /// <summary>
    /// Get all issuers.
    /// </summary>
    Task<IssuerListResponse?> GetAllPaymentIssuers();

    /// <summary>
    /// To use flexible direct debit, a mandate must be created for each end user. This process is described in the following steps.
    /// </summary>
    Task<CreateMandateResponse> CreateMandate(CreateMandateRequest body, string? baseurl = "https://rest-api.pay.nl/v3/");

    /// <summary>
    /// Create flexible direct debit
    /// </summary>
    Task<FlexibleDirectDebitResponse> CreateFlexibleDirectDebit(FlexibleDirectDebitRequest body, string? baseurl = "https://rest-api.pay.nl/v3/");

    /// <summary>
    ///     Create a recurring debit.
    /// </summary>
    Task<DirectDebitResponse> CreateDirectDebit(string incassoOrderId, CreateDirectDebitRequest body);

    /// <summary>
    ///     Fetch a directdebit order.
    /// </summary>
    Task<DirectDebitResponse> GetDirectDebit(string incassoOrderId);

    /// <summary>
    ///     Delete a directdebit order.
    /// </summary>
    Task DeleteDirectDebit(string incassoOrderId);

    /// <summary>
    ///     Update a directdebit order.
    /// </summary>
    Task<DirectDebitResponse> UpdateDirectDebit(string incassoOrderId, UpdateDirectDebitRequest body);

    /// <summary>
    ///		Creates a direct debit order which provides an incassoOrderId needed for all other Direct debit end points.
    ///		Note: In order to create a recurring debit you will need too set "allow recurring" in the admin panel.
    /// </summary>
    Task<DirectDebitResponse> CreateDirectDebitOrder(CreateDirectDebitOrderRequest bodsy);

    /// <summary>
    ///     Return true if the ip provided is an ip owned by Pay, otherwise it will return false.
    /// </summary>
    Task<bool> IpIsPay(string ip);

    /// <summary>
    ///     Get all IP addresses that are in use by Pay.
    /// </summary>
    Task<IpListResponse> GetAllIps();

    /// <summary>
    ///     Register a merchant so that the merchant is able to use Pay. to process payments
    /// </summary>
    Task<MerchantResponseWrapper> CreateMerchant(CreateMerchantRequest body);

    /// <summary>
    ///		A Pay. clearing contains multiple clearing lines. This API returns all clearing lines for a specified period.
    ///		If you are a partner, and you have rights to your merchants you can retrieve the clearing lines also for your merchants.
    /// </summary>
    /// <param name="queryParams">Use <see cref="ClearingLineFilter"/> too build your query parameter</param>
    /// <returns></returns>
    Task<ClearingLinesResponse> GetClearingLines(ClearingLineFilter queryParams);

    /// <summary>
    ///		A Pay. clearing contains multiple clearing lines. This API returns all clearing lines for a specified period.
    ///		If you are a partner, and you have rights to your merchants you can retrieve the clearing lines also for your merchants.
    /// </summary>
    /// <param name="queryParams">Use <see cref="ClearingLineFilter"/> too build your query parameter</param>
    /// <returns></returns>
    Task<InvoiceLinesResponse> GetInvoiceLines(InvoiceLineFilter queryParams);

    /// <summary>
    ///     Get the details of a specific merchant
    /// </summary>
    Task<MerchantResponse> GetMerchant(string merchantCode);

    /// <summary>
    ///		Get detailed information of a specific merchant
    /// </summary>
    Task<MerchantDetailedResponse> GetMerchantDetailed(string merchantCode);

    /// <summary>
    ///     Get the details of a specific merchant
    /// </summary>
    Task<MerchantListResponse> ListMerchants();

    /// <summary>
    ///     Delete a merchant. The merchant is not able to process payments anymore and cannot login to Pay anymore
    /// </summary>
    Task DeleteMerchant(string merchantCode);

    /// <summary>
    ///		Undelete a merchant that was recently deleted. This can only be done within a 15 minute time window
    /// </summary>
    Task<MerchantResponse> UnDeleteMerchant(string merchantCode);

    /// <summary>
    ///     Update the merchant data. If you want to update the relating objects (e.g. authentication tokens or accounts etc)
    ///     you can use the specific endpoints for that.
    ///     You need to have access to the merchantCode that you supply or it needs to be your own merchantCode.
    ///     You need to authenticate with an AT-code as username and the corresponding token as password
    /// </summary>
    Task<MerchantResponse> UpdateMerchant(string merchantCode, UpdateMerchantRequest body);

    /// <summary>
    /// Update the package. If a merchantCode is supplied then you need to have access to that merchant.
    /// You need to authenticate with an AT-code as username and the corresponding token as password.
    /// </summary>
    Task UpdateMerchantPackage(string merchantCode, string referralProfileCode);

    /// <summary>
    ///     When all documents for a merchant are delivered to Pay and the merchant data is ready to be reviewed by our
    ///     boarding department you can call this endpoint to notify our boarding department to review your merchant.
    ///     Note you need to have access to the merchant to call this endpoint
    /// </summary>
    Task RequestMerchantReview(string merchantCode);

    /// <summary>
    ///     Get the packages (sign up profiles) that are configured for the merchant/partner.
    ///     The CP code or the action code can be used to register a merchant so that the correct settings are configured when
    ///     the merchant is created
    /// </summary>
    Task<GetAllPackagesResponse> GetAllPackages();

    /// <summary>
    ///     Get all payment issuers for a given ID, e.g. iDEAL is 10. See: services/get/sl-xxxx-xxx.
    /// </summary>
    Task<IssuerListResponse?> GetAllPaymentIssuersForId(int paymentMethodId);

    /// <summary>
    ///     Get all payment methods
    /// </summary>
    Task<PaymentMethodCollection> GetAllPaymentMethods();

    /// <summary>
    ///     Return a list of all services linked to the current merchant
    /// </summary>
    Task<ServiceListResponse> GetAllServices();

    /// <summary>
    ///     Fetch a service.
    /// </summary>
    Task<Service> GetService(string serviceId);

    /// <summary>
    ///     Get the status of a pin transaction
    /// </summary>
    Task<PinPaymentStatusResponse> GetPinTransactionStatus(string transactionHash, int timeout = 5);

    /// <summary>
    ///     Cancel a pin transaction
    /// </summary>
    Task<PinTransactionCancelResponse> CancelPinTransaction(string transactionHash);

    /// <summary>
    ///		Create a terminal for a service location from a merchant so that the terminal can be used.
    /// </summary>
    Task<GetTerminalResponse> CreateTerminal(TerminalRequest body);

    /// <summary>
    ///     Get for a specific terminal linked to your account the contract details, active terminal brands and the actual
    ///     status of the terminal
    /// </summary>
    Task<GetTerminalResponse> GetTerminal(string terminalCode);

    /// <summary>
    ///     Get a list of all terminals linked to your account. Including the contract details, active terminal brands and the
    ///     actual status of a terminal
    /// </summary>
    Task<TerminalListResponse> GetAllTerminals();

    /// <summary>
    /// Remove a terminal from a merchant. You can undelete within a 15 minute time window
    /// </summary>
    Task DeleteTerminal(string terminalCode);

    /// <summary>
    ///	Undelete a terminal that was rececently deleted. This can only be done witin a 15 minute time window
    /// </summary>
    Task<TerminalListResponse> UndeleteTerminal(string terminalCode);

    /// <summary>
    ///     Get a specific trademark.
    /// </summary>
    /// <param name="trademarkCode">Identifier of the trademark</param>
    Task<TrademarkResponse> GetTrademark(string trademarkCode);

    /// <summary>
    ///     Get all trademarks.
    /// </summary>
    Task<TrademarkListResponse> GetAllTrademarks();

    /// <summary>
    ///     Create a trademark for a merchant. This trademark can be assigned to a sales location. Trademarks will be shown on the statement of the payer.
    /// </summary>
    Task<TrademarkResponse> CreateTrademark(CreateTrademarkRequest body);

    /// <summary>
    ///     Unsuspend a Trademark that was recently deleted. This can only be done within a 15 minute time window.
    /// </summary>
    Task<TrademarkResponse> UnsuspendTrademark(string trademarkCode);

    /// <summary>
    ///     A suspended trademark will not be used in any communication. You can unsuspend within a 15 minute time window.
    /// </summary>
    Task SuspendTrademark(string trademarkCode);

    /// <summary>
    ///     To capture funds of a gift card via a point of sale or eCommerce environment you can call this API.
    ///     The gift card must be activated on the sales location.
    /// </summary>
    Task<VoucherCreationResponse?> CreateVoucher(VoucherCreationRequest request);

    /// <summary>
    ///     This endpoint is used to create a transaction in redirect mode. By calling this endpoint, you get a transactionID
    ///     and a paymentUrl which can be used to redirect the payer.
    ///     After the payment, the payer will be redirected to the provided returnUrl, where you can check the status and
    ///     process the order.
    ///     You need to authenticate with an AT code (as username) and the corresponding token (as password) or you can
    ///     authenticate with a SL code (as username) and the corresponding secret (as password)
    /// </summary>
    Task<CreateTransactionResponse?> CreateTransaction(CreateTransactionRequest body, Core? core = null);

    /// <summary>
    ///     Get all detailed information of a transaction. You can use the EX code or the order ID to retrieve the detailed
    ///     transaction information
    /// </summary>
    Task<GetTransactionResponse?> GetTransactionInfo(string transactionId, Core? core = null);

    /// <summary>
    ///     Transactions that have the status pending (which implies that the payment is waiting for an action) can be
    ///     cancelled.
    ///     If you cancel a transaction a new processing action cannot be started.
    ///     A cancel of the transaction will not stop the money flow. The payment state of the transaction will be set to
    ///     CANCEL (-90).
    ///     You can use the EX code or the order ID to cancel the transaction
    /// </summary>
    Task<CancelTransactionResponse?> CancelTransaction(string transactionId, Core? core = null);

    /// <summary>
    ///     Add a refund for a transaction. You can use the EX code or the order ID to refund the transaction
    /// </summary>
    Task<SuccessfulRefundResponse> RefundTransaction(string transactionId, RefundTransactionRequest body);

    /// <summary>
    ///     Transactions that have the status verify (which implies that a transaction needs to be checked) can be approved to
    ///     collect the funds and to set the payment state to PAID (100).
    ///     You can use the EX code or the order ID to approve the transaction
    /// </summary>
    Task<ApproveDenyTransactionResponse> ApproveTransaction(string transactionId);

    /// <summary>
    ///     Transactions that have the status verify (which implies that a transaction needs to be checked) can be declined to
    ///     release the authorisation on a card or to refund the original transaction.
    ///     The payment state is set to CANCEL (-64). You can use the EX code or the order ID to decline the transaction
    /// </summary>
    Task<ApproveDenyTransactionResponse> DeclineTransaction(string transactionId);

    /// <summary>
    ///     Transactions that have the status authorize (is used by credit card payments or Buy now, Pay later payments) needs
    ///     an extra action to convert the payment state to a PAID (100) transaction.
    ///     This can be achieved by capturing the transaction. You can use the EX code or the order Id to capture the
    ///     transaction
    /// </summary>
    Task<ApproveDenyTransactionResponse> CaptureTransaction(string transactionId, CaptureTransactionRequest body);

    /// <summary>
    ///     Transactions that have the status authorize (is used by credit card payments or Buy now, Pay later payments)
    ///     can be voided to reverse the authorisation and to set the payment state to CANCEL (-90).
    ///     You can use the EX Code or the order Id to void the transaction
    /// </summary>
    Task<ApproveDenyTransactionResponse> VoidTransaction(string transactionId);

    /// <summary>
    ///     Load a transaction which has been started, so that the transaction can be finalized on another device. The
    ///     transaction can only be loaded if a transaction has the status 20, 50 and 90 (PENDING)
    /// </summary>
    Task<LoadTransactionResponse> LoadTransaction(string transactionId);

    /// <summary>
    /// Upload a (compliance) document as base64. Uploading is done based on a document code, the content of the document needs to be encoded to base64. You can also specify the filename.
    /// You need to authenticate with an AT code (as username) and the corresponding token (as password) or you can authenticate with an AL code (as username) and the corresponding secret (as password)
    /// </summary>
    Task<DocumentAddResponse> AddDocuments(DocumentAddRequest body);

    /// <summary>
    /// You can create a payment page for invoice payments & donations
    /// </summary>
    Task<PaymentLinkResponse> PaymentLinkCreate(string serviceId, PaymentLinkRequest body);

    /// <summary>
    /// Retrieve a handshake to redirect a user to the Pay platform so that a user can access the Pay platform without entering login credentials.
    /// Note that the user needs to have the correct rights to use this feature. You need to authenticate this API with the AT-code as username and the token as password
    /// </summary>
    Task<AuthenticateLoginResponse> AuthenticateLogin(AuthenticateLoginRequest body);

    /// <summary>
    /// Creates a new authentication token under a merchant.
    /// You can also specify which authorisation groups needs to be linked to the token.
    /// You can also supply a merchantCode. If a merchantCode is supplied then you need to have access to that merchant.
    /// You need to authenticate with an AT-code as username and a token as password
    /// </summary>
    Task<AuthenticationTokenResponse> AuthenticationTokenCreate(AuthenticationTokenCreateRequest body);

    /// <summary>
    /// Get the details of a specific authentication token.
    /// Note you need to have access to the merchant if the authentication token is not available under your own merchant registration
    /// </summary>
    Task<AuthenticationTokenResponse> AuthenticationTokenGet(string authenticationTokenCode);

    /// <summary>
    /// Get all authentication tokens.
    /// If you do not supply a merchantCode we return the authentication tokens that are available under your own merchant registration.
    /// If you supply a merchantCode you need to have access to that merchant
    /// </summary>
    Task<AuthenticationTokensResponse> AuthenticationTokenBrowse(string merchantCode);

    /// <summary>
    /// Deletes an authentication token.
    /// Note you need to have access to the merchant if the authentication token is not available under your own merchant registration
    /// </summary>
    Task DeleteAuthenticationToken(string authenticationTokenCode);

    /// <summary>
    /// Undelete an authentication token that was recently deleted.
    /// This can only be done within a 15-minute time window
    /// </summary>
    Task<AuthenticationTokenResponse> UndeleteAuthenticationToken(string authenticationTokenCode);

    /// <summary>
    /// Creates a new clearing account for a merchant.
    /// The clearing accounts needs to be a business clearing account, private accounts are not accepted.
    /// You can also supply a merchantCode.
    /// If a merchantCode is supplied then you need to have access to that merchant
    /// </summary>
    Task<ClearingAccountResponse> CreateClearingAccount(CreateClearingAccountRequest body);

    /// <summary>
    ///	Get the details of a specific clearing account.
    /// Note you need to have access to the merchant if the clearing account is not available under your own merchant registration.
    /// </summary>
    Task<ClearingAccountResponse> GetClearingAccount(string clearingAccountCode);

    /// <summary>
    /// Get all clearing accounts.
    /// If you do not supply a merchantCode we return the clearing accounts that are available under your own merchant registration.
    /// If you supply a merchantCode you need to have access to that merchant
    /// </summary>
    Task<ClearingAccountBrowseResponse> BrowseClearingAccounts(string merchantCode);

    /// <summary>
    ///	Deletes a clearing account.
    /// Note you need to have access to the merchant if the clearing account is not available under your own merchant registration
    /// </summary>
    Task DeleteClearingAccount(string clearingAccountCode);

    /// <summary>
    /// Undelete a clearing account that was recently deleted.
    /// This can only be done within a 15 minute time window.
    /// </summary>
    Task<ClearingAccountResponse> UndeleteClearingAccount(string clearingAccountCode);

    /// <summary>
    /// Creates a new contact method for a merchant. You can indicate per contact method if the contact details are public.
    /// If they are public they can be used in communication with end users. You can also supply a merchantCode.
    /// If a merchantCode is supplied then you need to have access to that merchant
    /// </summary>
    Task<ContactMethodResponse> CreateContactMethod(CreateContactMethodsRequest body);

    /// <summary>
    /// Updates a contact method for a merchant.
    /// All fields for the request are optional.
    /// Note you need to have access to the merchant if the contact method that you want to update is not available under your own merchant registration
    /// </summary>
    Task<ContactMethodResponse> UpdateContactMethod(string contactMethodCode, ContactMethod body);

    /// <summary>
    /// Get the details of a specific contact method.
    /// Note you need to have access to the merchant if the contact method is not available under your own merchant registration
    /// </summary>
    Task<ContactMethodResponse> GetContactMethod(string contactMethodCode);

    /// <summary>
    /// Get all contact methods. If you do not supply a merchantCode we return the contact methods that are available under your own merchant registration.
    /// If you supply a merchantCode you need to have access to that merchant
    /// </summary>
    Task<ContactMethodsResponse> BrowseContactMethods(string merchantCode);

    /// <summary>
    /// Deletes a contact method. Note you need to have access to the merchant if the contact method is not available under your own merchant registration
    /// </summary>
    Task DeleteContactMethod(string contactMethodCode);

    /// <summary>
    /// Undelete a contact method that was recently deleted. This can only be done within a 15 minute time window
    /// </summary>
    Task<ContactMethodResponse> UndeleteContactMethod(string clearingAccountCode);
}
