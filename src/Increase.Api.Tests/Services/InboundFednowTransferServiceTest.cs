using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class InboundFednowTransferServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundFednowTransfer = await this.client.InboundFednowTransfers.Retrieve(
            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundFednowTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundFednowTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
