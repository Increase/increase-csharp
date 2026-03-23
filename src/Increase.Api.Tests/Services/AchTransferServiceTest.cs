using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class AchTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var achTransfer = await this.client.AchTransfers.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                StatementDescriptor = "New ACH transfer",
            },
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var achTransfer = await this.client.AchTransfers.Retrieve(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.AchTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var achTransfer = await this.client.AchTransfers.Approve(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var achTransfer = await this.client.AchTransfers.Cancel(
            "ach_transfer_uoxatyh3lt5evrsdvo7q",
            new(),
            TestContext.Current.CancellationToken
        );
        achTransfer.Validate();
    }
}
