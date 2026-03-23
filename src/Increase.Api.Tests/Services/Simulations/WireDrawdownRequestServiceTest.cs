using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class WireDrawdownRequestServiceTest : TestBase
{
    [Fact]
    public async Task Refuse_Works()
    {
        var wireDrawdownRequest = await this.client.Simulations.WireDrawdownRequests.Refuse(
            "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
            new(),
            TestContext.Current.CancellationToken
        );
        wireDrawdownRequest.Validate();
    }

    [Fact]
    public async Task Submit_Works()
    {
        var wireDrawdownRequest = await this.client.Simulations.WireDrawdownRequests.Submit(
            "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
            new(),
            TestContext.Current.CancellationToken
        );
        wireDrawdownRequest.Validate();
    }
}
