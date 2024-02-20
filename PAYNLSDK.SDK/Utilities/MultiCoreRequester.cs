using PayNlSdk.Sdk.Client;
using PayNlSdk.Sdk.DataTransferModels;

namespace PayNlSdk.Sdk.Utilities;

internal class MultiCoreRequester
{
	private readonly MultiCorePayClient _client;
	private int _tries;
	private readonly int _startedAt;

	public MultiCoreRequester(MultiCorePayClient client)
	{
		_client = client;
		_startedAt = client.ActiveEndpointIndex;
	}

	internal async Task<TResponse> ExecuteWithAutomaticCoreSwitching<TResponse>(Func<Task<TResponse>> apiFunction)
	{
		if (!MultiCorePayClient.IsInitialized)
		{
			throw new MutliCoreUninitializedException();
		}

		try
		{
			if (!MultiCorePayClient.AvailableCores[_client.ActiveEndpointIndex].IsHealthy)
			{
				var core = MultiCorePayClient.AvailableCores[_client.ActiveEndpointIndex];
				throw new PayNlSdkException($"Attempted to use unhealthy core {core.Text} ({core.Url})");
			}

			if (_client.ActiveEndpointIndex != MultiCorePayClient.PreferredEndpointIndex
			    && _tries > _client.RetryCount)
			{
				_client.ActiveEndpointIndex = MultiCorePayClient.PreferredEndpointIndex;
				_tries = 0;
			}

			_tries++;

			var result = await apiFunction();
			return result;
		}
		catch (Exception e) when (e is not MutliCoreUninitializedException)
		{
			if (_client.ActiveEndpointIndex == _startedAt && _tries > 1)
			{
				throw;
			}

			if (_client.ActiveEndpointIndex != MultiCorePayClient.AvailableCores.Count - 1)
			{
				_client.ActiveEndpointIndex++;
			}
			else
			{
				_client.ActiveEndpointIndex = 0;
			}

			return await ExecuteWithAutomaticCoreSwitching(apiFunction);
		}
	}
}
