using System;
using Increase.Api.Models.Simulations.CardAuthorizationExpirations;

namespace Increase.Api.Tests.Models.Simulations.CardAuthorizationExpirations;

public class CardAuthorizationExpirationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardAuthorizationExpirationCreateParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";

        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        CardAuthorizationExpirationCreateParams parameters = new()
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/card_authorization_expirations"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardAuthorizationExpirationCreateParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        CardAuthorizationExpirationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
