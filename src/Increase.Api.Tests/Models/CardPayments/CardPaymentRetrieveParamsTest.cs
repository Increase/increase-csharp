using System;
using Increase.Api.Models.CardPayments;

namespace Increase.Api.Tests.Models.CardPayments;

public class CardPaymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardPaymentRetrieveParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";

        Assert.Equal(expectedCardPaymentID, parameters.CardPaymentID);
    }

    [Fact]
    public void Url_Works()
    {
        CardPaymentRetrieveParams parameters = new()
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/card_payments/card_payment_nd3k2kacrqjli8482ave"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardPaymentRetrieveParams
        {
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
        };

        CardPaymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
