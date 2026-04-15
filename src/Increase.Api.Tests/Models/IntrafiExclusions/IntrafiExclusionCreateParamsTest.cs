using System;
using Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Tests.Models.IntrafiExclusions;

public class IntrafiExclusionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiExclusionCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FdicCertificateNumber = "314159",
        };

        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        string expectedFdicCertificateNumber = "314159";

        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedFdicCertificateNumber, parameters.FdicCertificateNumber);
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiExclusionCreateParams parameters = new()
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FdicCertificateNumber = "314159",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/intrafi_exclusions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiExclusionCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FdicCertificateNumber = "314159",
        };

        IntrafiExclusionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
