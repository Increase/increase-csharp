using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class RealTimePaymentsTransferServiceTest : TestBase
{
    [Fact]
    public async Task Complete_Works()
    {
        var realTimePaymentsTransfer =
            await this.client.Simulations.RealTimePaymentsTransfers.Complete(
                "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                new(),
                TestContext.Current.CancellationToken
            );
        realTimePaymentsTransfer.Validate();
    }
}
