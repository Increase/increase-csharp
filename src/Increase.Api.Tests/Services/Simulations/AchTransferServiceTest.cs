using System.Threading.Tasks;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Tests.Services.Simulations;

public class AchTransferServiceTest : TestBase
{
    [Fact]
    public async Task Acknowledge_Works()
    {
        var achTransfer = await this.client.Simulations.AchTransfers.Acknowledge(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task CreateNotificationOfChange_Works()
    {
        var achTransfer = await this.client.Simulations.AchTransfers.CreateNotificationOfChange(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new() { ChangeCode = ChangeCode.IncorrectRoutingNumber, CorrectedData = "123456789" },
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task Return_Works()
    {
        var achTransfer = await this.client.Simulations.AchTransfers.Return(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task Settle_Works()
    {
        var achTransfer = await this.client.Simulations.AchTransfers.Settle(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task Submit_Works()
    {
        var achTransfer = await this.client.Simulations.AchTransfers.Submit(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }
}
