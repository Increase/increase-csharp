using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class AccountTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var accountTransfer = await this.client.AccountTransfers.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                Description = "Creating liquidity",
                DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            },
            TestContext.Current.CancellationToken
        );
        accountTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var accountTransfer = await this.client.AccountTransfers.Retrieve(
            "account_transfer_7k9qe1ysdgqztnt63l7n",
            new(),
            TestContext.Current.CancellationToken
        );
        accountTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.AccountTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var accountTransfer = await this.client.AccountTransfers.Approve(
            "account_transfer_7k9qe1ysdgqztnt63l7n",
            new(),
            TestContext.Current.CancellationToken
        );
        accountTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var accountTransfer = await this.client.AccountTransfers.Cancel(
            "account_transfer_7k9qe1ysdgqztnt63l7n",
            new(),
            TestContext.Current.CancellationToken
        );
        accountTransfer.Validate();
    }
}
