using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class DeclinedTransactionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var declinedTransaction = await this.client.DeclinedTransactions.Retrieve(
            "declined_transaction_17jbn0yyhvkt4v4ooym8",
            new(),
            TestContext.Current.CancellationToken
        );
        declinedTransaction.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.DeclinedTransactions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
