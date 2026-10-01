using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class FednowTransferServiceTest : TestBase
{
    [Fact]
    public async Task Complete_Works()
    {
        var fednowTransfer = await this.client.Simulations.FednowTransfers.Complete(
            "fednow_transfer_4i0mptrdu1mueg1196bg",
            new(),
            TestContext.Current.CancellationToken
        );
        fednowTransfer.Validate();
    }
}
