using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.DataTransferModels.Transaction;
using PayNlSdk.Sdk.DataTransferModels.Vouchers;


namespace PayNlSdk.IntegrationTests;

public class Vouchers
{
    [Fact(Skip = "Broken on API side")]
    public async Task CreateVoucher()
    {
        var client = TestHelper.CreateClient();
        
        var response = await client.CreateVoucher(new VoucherCreationRequest
        {
            Transaction = new Transaction
            {
                Type = "ECOM",
                Amount = new Amount
                {
                    Value = 1000,
                }
            },
            Voucher = new Voucher
            {
                CardNumber = "12345678",
                PinCode = "5087"
            },
            
        });
        
        Assert.NotNull(response);
    }
}