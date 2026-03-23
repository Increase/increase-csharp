using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class AccountStatementServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var accountStatement = await this.client.AccountStatements.Retrieve(
            "account_statement_lkc03a4skm2k7f38vj15",
            new(),
            TestContext.Current.CancellationToken
        );
        accountStatement.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.AccountStatements.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
