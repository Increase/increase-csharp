using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class PendingTransactionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var pendingTransaction = await this.client.PendingTransactions.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky", Amount = -1000 },
            TestContext.Current.CancellationToken
        );
        pendingTransaction.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var pendingTransaction = await this.client.PendingTransactions.Retrieve(
            "pending_transaction_k1sfetcau2qbvjbzgju4",
            new(),
            TestContext.Current.CancellationToken
        );
        pendingTransaction.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.PendingTransactions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Release_Works()
    {
        var pendingTransaction = await this.client.PendingTransactions.Release(
            "pending_transaction_k1sfetcau2qbvjbzgju4",
            new(),
            TestContext.Current.CancellationToken
        );
        pendingTransaction.Validate();
    }
}
