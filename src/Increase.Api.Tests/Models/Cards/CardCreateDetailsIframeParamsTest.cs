using System;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardCreateDetailsIframeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardCreateDetailsIframeParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PhysicalCardID = "physical_card_id",
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        string expectedPhysicalCardID = "physical_card_id";

        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedPhysicalCardID, parameters.PhysicalCardID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardCreateDetailsIframeParams { CardID = "card_oubs0hwk5rn6knuecxg2" };

        Assert.Null(parameters.PhysicalCardID);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_card_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardCreateDetailsIframeParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",

            // Null should be interpreted as omitted for these properties
            PhysicalCardID = null,
        };

        Assert.Null(parameters.PhysicalCardID);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_card_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CardCreateDetailsIframeParams parameters = new() { CardID = "card_oubs0hwk5rn6knuecxg2" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/cards/card_oubs0hwk5rn6knuecxg2/create_details_iframe"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardCreateDetailsIframeParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PhysicalCardID = "physical_card_id",
        };

        CardCreateDetailsIframeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
