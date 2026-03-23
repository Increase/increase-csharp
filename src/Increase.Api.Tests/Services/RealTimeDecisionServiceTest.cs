using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class RealTimeDecisionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var realTimeDecision = await this.client.RealTimeDecisions.Retrieve(
            "real_time_decision_j76n2e810ezcg3zh5qtn",
            new(),
            TestContext.Current.CancellationToken
        );
        realTimeDecision.Validate();
    }

    [Fact]
    public async Task Action_Works()
    {
        var realTimeDecision = await this.client.RealTimeDecisions.Action(
            "real_time_decision_j76n2e810ezcg3zh5qtn",
            new(),
            TestContext.Current.CancellationToken
        );
        realTimeDecision.Validate();
    }
}
