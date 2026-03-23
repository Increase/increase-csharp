using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class AccountStatementServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var accountStatement = await this.client.Simulations.AccountStatements.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky" },
            TestContext.Current.CancellationToken
        );
        accountStatement.Validate();
    }
}
