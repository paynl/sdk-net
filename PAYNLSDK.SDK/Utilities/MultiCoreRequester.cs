using PayNlSdk.Sdk.V2.Client;
using PayNlSdk.Sdk.V2.DataTransferModels;

namespace PayNlSdk.Sdk.Utilities;

internal class MultiCoreRequester
{
	private readonly MultiCorePayV2Client _v2Client;
	private int _tries;
	private readonly int _startedAt;

	public MultiCoreRequester(MultiCorePayV2Client v2Client)
	{
		_v2Client = v2Client;
		_startedAt = v2Client.ActiveEndpointIndex;
	}

	internal async Task<TResponse> ExecuteWithAutomaticCoreSwitching<TResponse>(Func<Task<TResponse>> apiFunction)
	{
		try
		{
			if (!MultiCorePayV2Client.AvailableCores[_v2Client.ActiveEndpointIndex].IsHealthy)
			{
				var core = MultiCorePayV2Client.AvailableCores[_v2Client.ActiveEndpointIndex];
				throw new PayNlSdkException($"Attempted to use unhealthy core {core.Text} ({core.Url})");
			}

			if (_v2Client.ActiveEndpointIndex != MultiCorePayV2Client.PreferredEndpointIndex
			    && _tries > _v2Client.RetryCount)
			{
				_v2Client.ActiveEndpointIndex = MultiCorePayV2Client.PreferredEndpointIndex;
				_tries = 0;
			}

			_tries++;

			var result = await apiFunction();
			return result;
		}
		catch (Exception e) when (e is not MutliCoreUninitializedException)
		{
			if (_v2Client.ActiveEndpointIndex == _startedAt && _tries > 1)
			{
				throw;
			}

			if (_v2Client.ActiveEndpointIndex != MultiCorePayV2Client.AvailableCores.Count - 1)
			{
				_v2Client.ActiveEndpointIndex++;
			}
			else
			{
				_v2Client.ActiveEndpointIndex = 0;
			}

			return await ExecuteWithAutomaticCoreSwitching(apiFunction);
		}
	}
}
