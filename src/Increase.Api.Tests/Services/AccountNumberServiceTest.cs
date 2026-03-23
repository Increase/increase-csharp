using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class AccountNumberServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var accountNumber = await this.client.AccountNumbers.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky", Name = "Rent payments" },
            TestContext.Current.CancellationToken
        );
        accountNumber.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var accountNumber = await this.client.AccountNumbers.Retrieve(
            "account_number_v18nkfqm6afpsrvy82b2",
            new(),
            TestContext.Current.CancellationToken
        );
        accountNumber.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var accountNumber = await this.client.AccountNumbers.Update(
            "account_number_v18nkfqm6afpsrvy82b2",
            new(),
            TestContext.Current.CancellationToken
        );
        accountNumber.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.AccountNumbers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
