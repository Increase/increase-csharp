using System;
using Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.EntityOnboardingSessions;

public class EntityOnboardingSessionExpireParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityOnboardingSessionExpireParams
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        string expectedEntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd";

        Assert.Equal(expectedEntityOnboardingSessionID, parameters.EntityOnboardingSessionID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityOnboardingSessionExpireParams parameters = new()
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/entity_onboarding_sessions/entity_onboarding_session_wid2ug11fsmvh3k9hymd/expire"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityOnboardingSessionExpireParams
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        EntityOnboardingSessionExpireParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
