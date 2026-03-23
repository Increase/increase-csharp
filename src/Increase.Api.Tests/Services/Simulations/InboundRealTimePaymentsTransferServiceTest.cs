using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundRealTimePaymentsTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundRealTimePaymentsTransfer =
            await this.client.Simulations.InboundRealTimePaymentsTransfers.Create(
                new() { AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2", Amount = 1000 },
                TestContext.Current.CancellationToken
            );
        inboundRealTimePaymentsTransfer.Validate();
    }
}
