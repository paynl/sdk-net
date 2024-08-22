namespace PayNlSdk.Sdk.V2.DataTransferModels;

/// <summary>
///     PayNlSdkException implementation
/// </summary>
[Serializable]
public class PayNlSdkException : Exception
{
    /// <summary>
    ///     Create a new PayNlSdkException with an Error attached
    /// </summary>
    /// <param name="error">Error object</param>
    /// <param name="innerException">Inner Exception</param>
    public PayNlSdkException(Error error, Exception innerException)
        : base(error.Message, innerException)
    {
    }

    /// <summary>
    ///     Create a new PayNlSdkException with an Error attached
    /// </summary>
    /// <param name="error">Error object</param>
    public PayNlSdkException(Error error)
        : base(error.Message, null)
    {
    }

    /// <summary>
    ///     Create a new PayNlSdkException with an Error attached
    /// </summary>
    /// <param name="error">Error object</param>
    public PayNlSdkException(ApiError? error)
        : base(error?.Detail ?? error?.Title, null)
    {
        foreach (var v in error?.Violations?.Where(v => v.PropertyPath != null) ?? new List<Violation>())
        {
            if (v is { PropertyPath: not null, Message: not null })
            {
                base.Data.Add(v.PropertyPath, v.Message);
            }
        }
    }

    /// <summary>
    ///     Creates an PayNlSdkException from a string
    /// </summary>
    /// <param name="message">error message</param>
    /// <param name="innerException">inner Exception</param>
    public PayNlSdkException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    ///     Creates an PayNlSdkException from a string
    /// </summary>
    /// <param name="message">error message</param>
    public PayNlSdkException(string? message)
        : base(message)
    {
    }
}
