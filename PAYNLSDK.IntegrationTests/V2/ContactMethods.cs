using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;

namespace PayNlSdk.IntegrationTests.V2;

public class ContactMethods
{
	[Fact]
	public async Task CreateContactMethod()
	{
		var client = TestHelper.CreateClientV2();

		var clearingAccount = await client.CreateContactMethod(new CreateContactMethodsRequest
		{
			MerchantCode = "M-3421-2120",
			ContactMethod = new ContactMethod
			{
				Type = "email",
				Value = "test@mail.com",
				Public = true,
				Notifications = false,
				Description = "Test"
			}
		});

		Assert.NotNull(clearingAccount.Code);

		var updatedClearingAccount = await client.UpdateContactMethod(clearingAccount.Code,
			new ContactMethod()
			{
				Type = "email",
				Value = "test2@mail.com",
				Public = false,
				Notifications = false,
				Description = "Test"
			});

		Assert.False(updatedClearingAccount.Public);
		Assert.Equal("test2@mail.com", updatedClearingAccount.Value);


		await client.DeleteContactMethod(clearingAccount.Code);
		var undeletedAccount = await client.UndeleteContactMethod(clearingAccount.Code);
		Assert.NotNull(undeletedAccount);
		Assert.Equal(undeletedAccount.Code, clearingAccount.Code);

		await client.DeleteContactMethod(clearingAccount.Code);
	}

	[Fact]
	public async Task GetContactMethod()
	{
		var client = TestHelper.CreateClientV2();
		var clearingAccounts = await client.BrowseContactMethods("M-3421-2120");

		Assert.NotNull(clearingAccounts.ContactMethods);
		Assert.NotNull(clearingAccounts.ContactMethods[0].Code);
		var clearingAccount = await client.GetClearingAccount(clearingAccounts.ContactMethods[0].Code!);

		Assert.NotNull(clearingAccount);
	}
}
