using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class InboundRealTimePaymentsTransferServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundRealTimePaymentsTransfer =
            await this.client.InboundRealTimePaymentsTransfers.Retrieve(
                "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                new(),
                TestContext.Current.CancellationToken
            );
        inboundRealTimePaymentsTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundRealTimePaymentsTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
