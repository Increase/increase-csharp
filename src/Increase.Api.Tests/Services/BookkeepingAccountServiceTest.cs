using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class BookkeepingAccountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var bookkeepingAccount = await this.client.BookkeepingAccounts.Create(
            new() { Name = "New Account!" },
            TestContext.Current.CancellationToken
        );
        bookkeepingAccount.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var bookkeepingAccount = await this.client.BookkeepingAccounts.Update(
            "bookkeeping_account_e37p1f1iuocw5intf35v",
            new() { Name = "Deprecated Account" },
            TestContext.Current.CancellationToken
        );
        bookkeepingAccount.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.BookkeepingAccounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Balance_Works()
    {
        var bookkeepingBalanceLookup = await this.client.BookkeepingAccounts.Balance(
            "bookkeeping_account_e37p1f1iuocw5intf35v",
            new(),
            TestContext.Current.CancellationToken
        );
        bookkeepingBalanceLookup.Validate();
    }
}
