using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class EntityOnboardingSessionServiceTest : TestBase
{
    [Fact]
    public async Task Submit_Works()
    {
        var entityOnboardingSession = await this.client.Simulations.EntityOnboardingSessions.Submit(
            "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            new(),
            TestContext.Current.CancellationToken
        );
        entityOnboardingSession.Validate();
    }
}
