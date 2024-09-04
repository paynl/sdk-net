namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public enum MandateDeclineCode
{
	Unset = 0,
	AdministrativeReason = 109,
	AccountCanceled = 112,
	AccountUnknown = 115,
	NoDebitAuthorization = 118,
	IncassoDisallowed = 121,
	IncassoExecutedTwice = 124,
	NoMatch = 271,
	AccountBlocked = 274,
	SelectiveDebitBlockade = 277,
	AccountWKA = 280,
	ReasonNotSupplied = 286,
	ReportWrongfulDebit = 331
}
