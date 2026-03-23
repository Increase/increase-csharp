using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class TransactionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var transaction = await this.client.Transactions.Retrieve(
            "transaction_uyrp7fld2ium70oa7oi",
            new(),
            TestContext.Current.CancellationToken
        );
        transaction.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Transactions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
