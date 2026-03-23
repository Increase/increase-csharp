using System;
using Increase.Api.Models.Simulations.CardAuthentications;

namespace Increase.Api.Tests.Models.Simulations.CardAuthentications;

public class CardAuthenticationChallengesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardAuthenticationChallengesParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";

        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        CardAuthenticationChallengesParams parameters = new()
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/card_authentications/card_payment_nd3k2kacrqjli8482ave/challenges"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardAuthenticationChallengesParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        CardAuthenticationChallengesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
