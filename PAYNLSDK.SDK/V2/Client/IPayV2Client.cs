using PayNlSdk.Sdk.Utilities;
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
using PayNlSdk.Sdk.V3.DataTransferObjects.MerchantManagement.Tokenisation;
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
    /// <param name="body"></param>
    /// <returns></returns>
    Task<DirectDebitResponse> CreateDirectDebitOrder(CreateDirectDebitOrderRequest body);

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
    ///     Get the details of a specific merchant
    /// </summary>
    Task<MerchantResponse> GetMerchant(string merchantCode);

    /// <summary>
    ///     Get the details of a specific merchant
    /// </summary>
    Task<MerchantListResponse> ListMerchants();

    /// <summary>
    ///     Delete a merchant. The merchant is not able to process payments anymore and cannot login to Pay anymore
    /// </summary>
    Task DeleteMerchant(string merchantCode);

    /// <summary>
    ///     Update the merchant data. If you want to update the relating objects (e.g. authentication tokens or accounts etc)
    ///     you can use the specific endpoints for that.
    ///     You need to have access to the merchantCode that you supply or it needs to be your own merchantCode.
    ///     You need to authenticate with an AT-code as username and the corresponding token as password
    /// </summary>
    Task<MerchantResponse> UpdateMerchant(string merchantCode, UpdateMerchantRequest body);

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
    /// <param name="body"></param>
    /// <returns></returns>
    Task<DocumentAddResponse> AddDocuments(DocumentAddRequest body);
}
