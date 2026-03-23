using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class InboundWireDrawdownRequestServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundWireDrawdownRequest = await this.client.InboundWireDrawdownRequests.Retrieve(
            "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundWireDrawdownRequest.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundWireDrawdownRequests.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
