using System;
using Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Tests.Models.IntrafiExclusions;

public class IntrafiExclusionArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiExclusionArchiveParams
        {
            IntrafiExclusionID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
        };

        string expectedIntrafiExclusionID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh";

        Assert.Equal(expectedIntrafiExclusionID, parameters.IntrafiExclusionID);
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiExclusionArchiveParams parameters = new()
        {
            IntrafiExclusionID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/intrafi_exclusions/intrafi_exclusion_ygfqduuzpau3jqof6jyh/archive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiExclusionArchiveParams
        {
            IntrafiExclusionID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
        };

        IntrafiExclusionArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
