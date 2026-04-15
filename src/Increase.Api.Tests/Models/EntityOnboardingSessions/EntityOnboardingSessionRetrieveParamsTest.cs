using System;
using Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.EntityOnboardingSessions;

public class EntityOnboardingSessionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityOnboardingSessionRetrieveParams
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        string expectedEntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd";

        Assert.Equal(expectedEntityOnboardingSessionID, parameters.EntityOnboardingSessionID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityOnboardingSessionRetrieveParams parameters = new()
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/entity_onboarding_sessions/entity_onboarding_session_wid2ug11fsmvh3k9hymd"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityOnboardingSessionRetrieveParams
        {
            EntityOnboardingSessionID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
        };

        EntityOnboardingSessionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
