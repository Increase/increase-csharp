using System;
using Increase.Api.Models.Simulations.DigitalWalletTokenRequests;

namespace Increase.Api.Tests.Models.Simulations.DigitalWalletTokenRequests;

public class DigitalWalletTokenRequestCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalWalletTokenRequestCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";

        Assert.Equal(expectedCardID, parameters.CardID);
    }

    [Fact]
    public void Url_Works()
    {
        DigitalWalletTokenRequestCreateParams parameters = new()
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/digital_wallet_token_requests"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalWalletTokenRequestCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
        };

        DigitalWalletTokenRequestCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
