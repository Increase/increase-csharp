using System;
using Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Tests.Models.PhysicalCards;

public class PhysicalCardRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardRetrieveParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
        };

        string expectedPhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl";

        Assert.Equal(expectedPhysicalCardID, parameters.PhysicalCardID);
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardRetrieveParams parameters = new()
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/physical_cards/physical_card_ode8duyq5v2ynhjoharl"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardRetrieveParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
        };

        PhysicalCardRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
