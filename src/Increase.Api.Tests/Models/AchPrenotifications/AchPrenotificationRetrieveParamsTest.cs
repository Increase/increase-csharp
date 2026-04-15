using System;
using Increase.Api.Models.AchPrenotifications;

namespace Increase.Api.Tests.Models.AchPrenotifications;

public class AchPrenotificationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchPrenotificationRetrieveParams
        {
            AchPrenotificationID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
        };

        string expectedAchPrenotificationID = "ach_prenotification_ubjf9qqsxl3obbcn1u34";

        Assert.Equal(expectedAchPrenotificationID, parameters.AchPrenotificationID);
    }

    [Fact]
    public void Url_Works()
    {
        AchPrenotificationRetrieveParams parameters = new()
        {
            AchPrenotificationID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/ach_prenotifications/ach_prenotification_ubjf9qqsxl3obbcn1u34"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchPrenotificationRetrieveParams
        {
            AchPrenotificationID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
        };

        AchPrenotificationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
