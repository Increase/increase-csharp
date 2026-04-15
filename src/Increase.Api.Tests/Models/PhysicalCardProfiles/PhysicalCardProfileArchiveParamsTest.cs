using System;
using Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Tests.Models.PhysicalCardProfiles;

public class PhysicalCardProfileArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardProfileArchiveParams
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
        };

        string expectedPhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec";

        Assert.Equal(expectedPhysicalCardProfileID, parameters.PhysicalCardProfileID);
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardProfileArchiveParams parameters = new()
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/physical_card_profiles/physical_card_profile_m534d5rn9qyy9ufqxoec/archive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardProfileArchiveParams
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
        };

        PhysicalCardProfileArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
