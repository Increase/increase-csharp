using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class AccountTransferServiceTest : TestBase
{
    [Fact]
    public async Task Complete_Works()
    {
        var accountTransfer = await this.client.Simulations.AccountTransfers.Complete(
            "account_transfer_7k9qe1ysdgqztnt63l7n",
            new(),
            TestContext.Current.CancellationToken
        );
        accountTransfer.Validate();
    }
}
