using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundWireTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundWireTransfer = await this.client.Simulations.InboundWireTransfers.Create(
            new() { AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2", Amount = 1000 },
            TestContext.Current.CancellationToken
        );
        inboundWireTransfer.Validate();
    }
}
