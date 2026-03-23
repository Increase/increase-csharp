using System.Threading.Tasks;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Services;

public class InboundAchTransferServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundAchTransfer = await this.client.InboundAchTransfers.Retrieve(
            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundAchTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundAchTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task CreateNotificationOfChange_Works()
    {
        var inboundAchTransfer = await this.client.InboundAchTransfers.CreateNotificationOfChange(
            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundAchTransfer.Validate();
    }

    [Fact]
    public async Task Decline_Works()
    {
        var inboundAchTransfer = await this.client.InboundAchTransfers.Decline(
            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            new(),
            TestContext.Current.CancellationToken
        );
        inboundAchTransfer.Validate();
    }

    [Fact]
    public async Task TransferReturn_Works()
    {
        var inboundAchTransfer = await this.client.InboundAchTransfers.TransferReturn(
            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            new() { Reason = InboundAchTransferTransferReturnParamsReason.PaymentStopped },
            TestContext.Current.CancellationToken
        );
        inboundAchTransfer.Validate();
    }
}
