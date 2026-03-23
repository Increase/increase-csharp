using System;
using Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Tests.Models.DigitalCardProfiles;

public class DigitalCardProfileArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalCardProfileArchiveParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
        };

        string expectedDigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga";

        Assert.Equal(expectedDigitalCardProfileID, parameters.DigitalCardProfileID);
    }

    [Fact]
    public void Url_Works()
    {
        DigitalCardProfileArchiveParams parameters = new()
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/digital_card_profiles/digital_card_profile_s3puplu90f04xhcwkiga/archive"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalCardProfileArchiveParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
        };

        DigitalCardProfileArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
