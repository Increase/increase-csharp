using System;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardUpdatePinParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardUpdatePinParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Pin = "1234",
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        string expectedPin = "1234";

        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedPin, parameters.Pin);
    }

    [Fact]
    public void Url_Works()
    {
        CardUpdatePinParams parameters = new()
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Pin = "1234",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/cards/card_oubs0hwk5rn6knuecxg2/update_pin"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardUpdatePinParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Pin = "1234",
        };

        CardUpdatePinParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
