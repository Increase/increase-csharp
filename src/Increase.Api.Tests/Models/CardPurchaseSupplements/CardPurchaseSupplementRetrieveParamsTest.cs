using System;
using Increase.Api.Models.CardPurchaseSupplements;

namespace Increase.Api.Tests.Models.CardPurchaseSupplements;

public class CardPurchaseSupplementRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardPurchaseSupplementRetrieveParams
        {
            CardPurchaseSupplementID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
        };

        string expectedCardPurchaseSupplementID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3";

        Assert.Equal(expectedCardPurchaseSupplementID, parameters.CardPurchaseSupplementID);
    }

    [Fact]
    public void Url_Works()
    {
        CardPurchaseSupplementRetrieveParams parameters = new()
        {
            CardPurchaseSupplementID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/card_purchase_supplements/card_purchase_supplement_ijuc45iym4jchnh2sfk3"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardPurchaseSupplementRetrieveParams
        {
            CardPurchaseSupplementID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
        };

        CardPurchaseSupplementRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
