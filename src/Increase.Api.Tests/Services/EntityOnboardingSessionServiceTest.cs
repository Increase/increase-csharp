using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class EntityOnboardingSessionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var entityOnboardingSession = await this.client.EntityOnboardingSessions.Create(
            new()
            {
                ProgramID = "program_i2v2os4mwza1oetokh9i",
                RedirectUrl = "https://example.com/onboarding/session",
            },
            TestContext.Current.CancellationToken
        );
        entityOnboardingSession.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var entityOnboardingSession = await this.client.EntityOnboardingSessions.Retrieve(
            "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            new(),
            TestContext.Current.CancellationToken
        );
        entityOnboardingSession.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.EntityOnboardingSessions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Expire_Works()
    {
        var entityOnboardingSession = await this.client.EntityOnboardingSessions.Expire(
            "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            new(),
            TestContext.Current.CancellationToken
        );
        entityOnboardingSession.Validate();
    }
}
