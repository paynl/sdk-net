using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.Licenses;

namespace PayNlSdk.IntegrationTests.V2;

public class Licenses
{
	[Fact]
	public async Task CreateLicense()
	{
		var client = TestHelper.CreateClientV2();

		var license = await client.CreateLicense(new LicenseRequest
		{
			MerchantCode = "M-3421-2120",
			Person = new PersonLicense
			{
				FirstName = "Mister",
				LastName = "Rogers",
				Email = "MisterRogers@testmail.com",
				Roles = new Roles
				{
					InternalAdministrator = true,
					PrimaryContactPerson = true
				}
			},
		});

		Assert.NotNull(license.Code);
		Assert.True(license.Roles?.InternalAdministrator);

		var updatedLicense = await client.UpdateLicense(license.Code,
			new LicenseUpdateRequest
			{
				Name = "Update Test",
				Roles = new Roles
				{
					InternalAdministrator = false,
					PrimaryContactPerson = false
				}
			});

		Assert.False(updatedLicense.Roles?.InternalAdministrator);
		Assert.False(updatedLicense.Roles?.PrimaryContactPerson);

		await client.DeleteLicense(license.Code);
		var undeletedAccount = await client.UndeleteLicense(license.Code);
		Assert.NotNull(undeletedAccount);
		Assert.Equal(undeletedAccount.Code, license.Code);

		await client.DeleteLicense(license.Code);
	}

	[Fact]
	public async Task GetLicenses()
	{
		var client = TestHelper.CreateClientV2();
		var licenses = await client.BrowseLicenses("M-3421-2120");

		Assert.NotNull(licenses.Licenses);
		Assert.NotNull(licenses.Licenses[0].Code);
		var license = await client.GetLicense(licenses.Licenses[0].Code!);

		Assert.NotNull(license);
	}
}
