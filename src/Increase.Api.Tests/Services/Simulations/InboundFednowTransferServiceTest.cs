using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundFednowTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundFednowTransfer = await this.client.Simulations.InboundFednowTransfers.Create(
            new() { AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2", Amount = 1000 },
            TestContext.Current.CancellationToken
        );
        inboundFednowTransfer.Validate();
    }
}
