namespace PayNlSdk.Sdk.Utilities;

internal class MutliCoreUninitializedException : Exception
{
	public MutliCoreUninitializedException() : base("MultiCorePayClient is not initialized. Please call MultiCorePayClient.Initialize() first.")
	{
	}
}
