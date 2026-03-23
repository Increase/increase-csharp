using System;
using Increase.Api.Models.Simulations.CardReversals;

namespace Increase.Api.Tests.Models.Simulations.CardReversals;

public class CardReversalCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardReversalCreateParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Amount = 1,
        };

        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        long expectedAmount = 1;

        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
        Assert.Equal(expectedAmount, parameters.Amount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardReversalCreateParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardReversalCreateParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",

            // Null should be interpreted as omitted for these properties
            Amount = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void Url_Works()
    {
        CardReversalCreateParams parameters = new()
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/card_reversals"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardReversalCreateParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Amount = 1,
        };

        CardReversalCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
