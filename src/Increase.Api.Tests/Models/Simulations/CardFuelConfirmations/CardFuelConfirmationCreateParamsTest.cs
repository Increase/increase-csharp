using System;
using Increase.Api.Models.Simulations.CardFuelConfirmations;

namespace Increase.Api.Tests.Models.Simulations.CardFuelConfirmations;

public class CardFuelConfirmationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardFuelConfirmationCreateParams
        {
            Amount = 5000,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        long expectedAmount = 5000;
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        CardFuelConfirmationCreateParams parameters = new()
        {
            Amount = 5000,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/card_fuel_confirmations"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardFuelConfirmationCreateParams
        {
            Amount = 5000,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        CardFuelConfirmationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
