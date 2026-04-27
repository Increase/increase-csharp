using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class InboundMailItemServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var inboundMailItem = await this.client.Simulations.InboundMailItems.Create(
            new() { Amount = 1000 },
            TestContext.Current.CancellationToken
        );
        inboundMailItem.Validate();
    }
}
