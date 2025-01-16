namespace PayNlSdk.Sdk.V2.DataTransferModels;

[Serializable]
public class PayNlSdkUnauthorizedException : PayNlSdkException
{
	public PayNlSdkUnauthorizedException(Error error, Exception innerException) : base(error, innerException)
	{
	}

	public PayNlSdkUnauthorizedException(Error error) : base(error)
	{
	}

	public PayNlSdkUnauthorizedException(ApiError? error) : base(error)
	{
	}

	public PayNlSdkUnauthorizedException(string? message, Exception innerException) : base(message, innerException)
	{
	}

	public PayNlSdkUnauthorizedException(string? message) : base(message)
	{
	}
}
