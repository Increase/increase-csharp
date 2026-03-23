using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class PendingTransactionServiceTest : TestBase
{
    [Fact]
    public async Task ReleaseInboundFundsHold_Works()
    {
        var pendingTransaction =
            await this.client.Simulations.PendingTransactions.ReleaseInboundFundsHold(
                "pending_transaction_k1sfetcau2qbvjbzgju4",
                new(),
                TestContext.Current.CancellationToken
            );
        pendingTransaction.Validate();
    }
}
