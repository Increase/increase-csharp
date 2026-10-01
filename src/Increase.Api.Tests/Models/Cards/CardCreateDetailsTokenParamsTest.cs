using System;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardCreateDetailsTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardCreateDetailsTokenParams { CardID = "card_oubs0hwk5rn6knuecxg2" };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";

        Assert.Equal(expectedCardID, parameters.CardID);
    }

    [Fact]
    public void Url_Works()
    {
        CardCreateDetailsTokenParams parameters = new() { CardID = "card_oubs0hwk5rn6knuecxg2" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/cards/card_oubs0hwk5rn6knuecxg2/create_details_token"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardCreateDetailsTokenParams { CardID = "card_oubs0hwk5rn6knuecxg2" };

        CardCreateDetailsTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
