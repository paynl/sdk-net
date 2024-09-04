namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public enum MandateStatusCode
{
	Unset = 0,
	Added= 91,
	InBatch=526,
	Processed = 94,
	// See https://my.pay.nl/docpanel/api/DirectDebit/info/4/pdf for reference
	Processed_2 = 97,
	Cashed= 100,
	Deleted = 103,
	Reversal = 106,
	RefusedByBank = 127,
	Relist = 199
}
