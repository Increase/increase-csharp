using System;
using Increase.Api.Models.Simulations.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.Simulations.EntityOnboardingSessions;

public class EntityOnboardingSessionSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityOnboardingSessionSubmitParams
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        string expectedEntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd";

        Assert.Equal(expectedEntityOnboardingSessionID, parameters.EntityOnboardingSessionID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityOnboardingSessionSubmitParams parameters = new()
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/entity_onboarding_sessions/entity_onboarding_session_wid2ug11fsmvh3k9hymd/submit"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityOnboardingSessionSubmitParams
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        EntityOnboardingSessionSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
