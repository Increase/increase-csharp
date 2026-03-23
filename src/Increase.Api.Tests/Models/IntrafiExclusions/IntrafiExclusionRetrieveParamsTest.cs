using System;
using Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Tests.Models.IntrafiExclusions;

public class IntrafiExclusionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiExclusionRetrieveParams
        {
            IntrafiExclusionID = "account_in71c4amph0vgo2qllky",
        };

        string expectedIntrafiExclusionID = "account_in71c4amph0vgo2qllky";

        Assert.Equal(expectedIntrafiExclusionID, parameters.IntrafiExclusionID);
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiExclusionRetrieveParams parameters = new()
        {
            IntrafiExclusionID = "account_in71c4amph0vgo2qllky",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/intrafi_exclusions/account_in71c4amph0vgo2qllky"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiExclusionRetrieveParams
        {
            IntrafiExclusionID = "account_in71c4amph0vgo2qllky",
        };

        IntrafiExclusionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
