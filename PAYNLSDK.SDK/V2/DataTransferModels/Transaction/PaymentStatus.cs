namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public enum PaymentStatus
{
    CANCEL = -90,
    PARTIAL_REFUND = -82,
    REFUND = -81,
    EXPIRED = -80,
    REFUNDING = -72,
    CHARGEBACK_1 = -71,
    CHARGEBACK_2 = -70,
    DENIED = -63,
    CANCEL_2 = -60,
    PAID_CHECKAMOUNT = -51,
    WAIT = 0,
    PENDING_1 = 20,
    PENDING_2 = 25,
    PENDING_3 = 50,
    OPEN = 60,
    CONFIRMED_1 = 75,
    CONFIRMED_2 = 76,
    PARTIAL_PAYMENT = 80,
    VERIFY = 85,
    PENDING_4 = 90,
    AUTHORIZE = 95,
    PAID = 100,
}