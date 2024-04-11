using PayNlSdk.IntegrationTests.Helpers;

#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests.V2;

public class Ip
{
    [Theory]
    [InlineData("10.10.10.10", false)]
    [InlineData("213.126.82.230", false)]
    [InlineData("37.46.137.138", true)]
    public async Task CanCheckIp(string ip, bool expected)
    {
        var client = TestHelper.CreateClientV2();
        var isPay = await client.IpIsPay(ip);

        Assert.Equal(expected, isPay);
    }

    [Fact]
    public async Task GetIps()
    {
        var client = TestHelper.CreateClientV2();
        var ips = await client.GetAllIps();

        Assert.NotNull(ips);
        Assert.NotEmpty(ips.IpAddresses);
        Assert.True(ips.Total > 0);
        Assert.Equal(ips.Total, ips.IpAddresses.Count());
    }
}