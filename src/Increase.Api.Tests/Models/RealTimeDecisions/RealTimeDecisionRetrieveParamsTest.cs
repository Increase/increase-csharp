using System;
using Increase.Api.Models.RealTimeDecisions;

namespace Increase.Api.Tests.Models.RealTimeDecisions;

public class RealTimeDecisionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimeDecisionRetrieveParams
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
        };

        string expectedRealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn";

        Assert.Equal(expectedRealTimeDecisionID, parameters.RealTimeDecisionID);
    }

    [Fact]
    public void Url_Works()
    {
        RealTimeDecisionRetrieveParams parameters = new()
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/real_time_decisions/real_time_decision_j76n2e810ezcg3zh5qtn"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimeDecisionRetrieveParams
        {
            RealTimeDecisionID = "real_time_decision_j76n2e810ezcg3zh5qtn",
        };

        RealTimeDecisionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
