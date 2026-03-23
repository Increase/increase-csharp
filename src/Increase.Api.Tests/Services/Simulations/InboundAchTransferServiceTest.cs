using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundAchTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundAchTransfer = await this.client.Simulations.InboundAchTransfers.Create(
            new() { AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2", Amount = 1000 },
            TestContext.Current.CancellationToken
        );
        inboundAchTransfer.Validate();
    }
}
