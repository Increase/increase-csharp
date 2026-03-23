using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class WireTransferServiceTest : TestBase
{
    [Fact]
    public async Task Reverse_Works()
    {
        var wireTransfer = await this.client.Simulations.WireTransfers.Reverse(
            "wire_transfer_5akynk7dqsq25qwk9q2u",
            new(),
            TestContext.Current.CancellationToken
        );
        wireTransfer.Validate();
    }

    [Fact]
    public async Task Submit_Works()
    {
        var wireTransfer = await this.client.Simulations.WireTransfers.Submit(
            "wire_transfer_5akynk7dqsq25qwk9q2u",
            new(),
            TestContext.Current.CancellationToken
        );
        wireTransfer.Validate();
    }
}
