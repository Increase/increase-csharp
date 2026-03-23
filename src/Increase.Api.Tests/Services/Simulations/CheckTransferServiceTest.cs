using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CheckTransferServiceTest : TestBase
{
    [Fact]
    public async Task Mail_Works()
    {
        var checkTransfer = await this.client.Simulations.CheckTransfers.Mail(
            "check_transfer_30b43acfu9vw8fyc4f5",
            new(),
            TestContext.Current.CancellationToken
        );
        checkTransfer.Validate();
    }
}
