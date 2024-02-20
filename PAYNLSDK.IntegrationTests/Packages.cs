using PayNlSdk.IntegrationTests.Helpers;

#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests;

public class Packages
{
    [Fact]
    public async Task ListPackages()
    {
        var client = TestHelper.CreateClient();

        var packages = await client.GetAllPackages();

        Assert.NotNull(packages);
        Assert.NotEmpty(packages.Packages);
        Assert.True(packages.Total > 0);
        Assert.Equal(packages.Total, packages.Packages.Count);
    }
}