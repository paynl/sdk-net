using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V2.DataTransferModels.Vouchers;

namespace PayNlSdk.IntegrationTests.V2;

public class Vouchers
{
    [Fact(Skip = "Broken on API side")]
    public async Task CreateVoucher()
    {
        var client = TestHelper.CreateClientV2();
        
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