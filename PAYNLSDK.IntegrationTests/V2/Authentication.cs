using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;

namespace PayNlSdk.IntegrationTests.V2;

public class Authentication
{
	[Fact(Skip = "No rights issue")]
	public async Task AuthenticateLogin()
	{
		var client = TestHelper.CreateClientV2();
		// TODO: Getting 403 on Classic Card Parts
		var authenticationResponse = await client.AuthenticateLogin(new AuthenticateLoginRequest
		{
			Login = new Login
			{
				InactivityExpire = 1800,
				InternalId = "Test",
				DeviceId = "",
				IpAddress = "",
				UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36 Edg/128.0.0.0",
			},
			Account = new Account
			{
				LicenseCode = "AL-0000-0000",
				LogoutRedirectUrl = "https://google.com",
				Label = "",
				LanguageId = "nl_NL"
			}
		});

		Assert.NotNull(authenticationResponse);
	}

	[Fact]
	public async Task AuthenticationTokenCreateAndDelete()
	{
		var client = TestHelper.CreateClientV2();
		var authenticationTokenResponse = await client.AuthenticationTokenCreate(new AuthenticationTokenCreateRequest
		{
			MerchantCode = "M-3421-2120",
			AuthenticationToken = new AuthenticationToken
			{
				Description = "SDK Xunit Test Token",
				Authorisation = "all",
			}
		});

		Assert.NotNull(authenticationTokenResponse);
		Assert.NotNull(authenticationTokenResponse.Code);

		await client.DeleteAuthenticationToken(authenticationTokenResponse.Code);
	}

	[Fact]
	public async Task AuthenticationTokenCreateDeleteAndUndelete()
	{
		var client = TestHelper.CreateClientV2();
		var authenticationTokenResponse = await client.AuthenticationTokenCreate(new AuthenticationTokenCreateRequest
		{
			MerchantCode = "M-3421-2120",
			AuthenticationToken = new AuthenticationToken
			{
				Description = "SDK Xunit Test Token",
				Authorisation = "all",
			}
		});

		Assert.NotNull(authenticationTokenResponse);
		Assert.NotNull(authenticationTokenResponse.Code);

		await client.DeleteAuthenticationToken(authenticationTokenResponse.Code);
		var undeleted = await client.UndeleteAuthenticationToken(authenticationTokenResponse.Code);

		Assert.NotNull(undeleted.Code);
		Assert.Equal(authenticationTokenResponse.Code, undeleted.Code);
		await client.DeleteAuthenticationToken(undeleted.Code);
	}

	[Fact]
	public async Task AuthenticationTokenGet()
	{
		var client = TestHelper.CreateClientV2();
		var authenticationTokenResponse = await client.AuthenticationTokenCreate(new AuthenticationTokenCreateRequest
		{
			MerchantCode = "M-3421-2120",
			AuthenticationToken = new AuthenticationToken
			{
				Description = "SDK Xunit Test Token",
				Authorisation = "all",
			}
		});

		Assert.NotNull(authenticationTokenResponse);
		Assert.NotNull(authenticationTokenResponse.Code);

		var response = await client.AuthenticationTokenGet(authenticationTokenResponse.Code);
		Assert.NotNull(response);
		Assert.Equal(response.Code, authenticationTokenResponse.Code);
		await client.DeleteAuthenticationToken(authenticationTokenResponse.Code);
	}

	[Fact]
	public async Task AuthenticationTokenBrowse()
	{
		var client = TestHelper.CreateClientV2();
		var authenticationTokenResponse = await client.AuthenticationTokenCreate(new AuthenticationTokenCreateRequest
		{
			MerchantCode = "M-3421-2120",
			AuthenticationToken = new AuthenticationToken
			{
				Description = "SDK Xunit Test Token",
				Authorisation = "all",
			}
		});

		Assert.NotNull(authenticationTokenResponse);
		Assert.NotNull(authenticationTokenResponse.Code);

		var response = await client.AuthenticationTokenBrowse("M-3421-2120");
		Assert.NotNull(response);
		Assert.NotNull(response.AuthenticationTokens);
		Assert.Contains(authenticationTokenResponse.Code, response.AuthenticationTokens.Select(x => x.Code).ToList());
		await client.DeleteAuthenticationToken(authenticationTokenResponse.Code);
	}
}
