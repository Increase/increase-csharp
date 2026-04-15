using System;
using Increase.Api.Models.Simulations.CardIncrements;

namespace Increase.Api.Tests.Models.Simulations.CardIncrements;

public class CardIncrementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardIncrementCreateParams
        {
            Amount = 500,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            EventSubscriptionID = "event_subscription_id",
        };

        long expectedAmount = 500;
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        string expectedEventSubscriptionID = "event_subscription_id";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
        Assert.Equal(expectedEventSubscriptionID, parameters.EventSubscriptionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardIncrementCreateParams
        {
            Amount = 500,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        Assert.Null(parameters.EventSubscriptionID);
        Assert.False(parameters.RawBodyData.ContainsKey("event_subscription_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardIncrementCreateParams
        {
            Amount = 500,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",

            // Null should be interpreted as omitted for these properties
            EventSubscriptionID = null,
        };

        Assert.Null(parameters.EventSubscriptionID);
        Assert.False(parameters.RawBodyData.ContainsKey("event_subscription_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CardIncrementCreateParams parameters = new()
        {
            Amount = 500,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/simulations/card_increments"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardIncrementCreateParams
        {
            Amount = 500,
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            EventSubscriptionID = "event_subscription_id",
        };

        CardIncrementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
