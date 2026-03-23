using System.Threading.Tasks;
using Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Tests.Services;

public class InboundWireTransferServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundWireTransfer = await this.client.InboundWireTransfers.Retrieve(
            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundWireTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundWireTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Reverse_Works()
    {
        var inboundWireTransfer = await this.client.InboundWireTransfers.Reverse(
            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            new() { Reason = Reason.CreditorRequest },
            TestContext.Current.CancellationToken
        );
        inboundWireTransfer.Validate();
    }
}
