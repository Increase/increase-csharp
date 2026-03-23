using System;
using Increase.Api.Models.Simulations.CardAuthentications;

namespace Increase.Api.Tests.Models.Simulations.CardAuthentications;

public class CardAuthenticationChallengeAttemptsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardAuthenticationChallengeAttemptsParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            OneTimeCode = "123456",
        };

        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        string expectedOneTimeCode = "123456";

        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
        Assert.Equal(expectedOneTimeCode, parameters.OneTimeCode);
    }

    [Fact]
    public void Url_Works()
    {
        CardAuthenticationChallengeAttemptsParams parameters = new()
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            OneTimeCode = "123456",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/card_authentications/card_payment_nd3k2kacrqjli8482ave/challenge_attempts"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardAuthenticationChallengeAttemptsParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            OneTimeCode = "123456",
        };

        CardAuthenticationChallengeAttemptsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
