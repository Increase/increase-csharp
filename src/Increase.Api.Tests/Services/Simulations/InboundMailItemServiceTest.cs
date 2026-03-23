using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundMailItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundMailItem = await this.client.Simulations.InboundMailItems.Create(
            new() { Amount = 1000, LockboxID = "lockbox_3xt21ok13q19advds4t5" },
            TestContext.Current.CancellationToken
        );
        inboundMailItem.Validate();
    }
}
