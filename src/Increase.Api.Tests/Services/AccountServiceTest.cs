using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class AccountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var account = await this.client.Accounts.Create(
            new() { Name = "New Account!" },
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var account = await this.client.Accounts.Retrieve(
            "account_in71c4amph0vgo2qllky",
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var account = await this.client.Accounts.Update(
            "account_in71c4amph0vgo2qllky",
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Accounts.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Balance_Works()
    {
        var balanceLookup = await this.client.Accounts.Balance(
            "account_in71c4amph0vgo2qllky",
            new(),
            TestContext.Current.CancellationToken
        );
        balanceLookup.Validate();
    }

    [Fact]
    public async Task Close_Works()
    {
        var account = await this.client.Accounts.Close(
            "account_in71c4amph0vgo2qllky",
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }
}
