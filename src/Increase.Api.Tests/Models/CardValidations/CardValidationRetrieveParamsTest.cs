using System;
using Increase.Api.Models.CardValidations;

namespace Increase.Api.Tests.Models.CardValidations;

public class CardValidationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardValidationRetrieveParams
        {
            CardValidationID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
        };

        string expectedCardValidationID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24";

        Assert.Equal(expectedCardValidationID, parameters.CardValidationID);
    }

    [Fact]
    public void Url_Works()
    {
        CardValidationRetrieveParams parameters = new()
        {
            CardValidationID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/card_validations/outbound_card_validation_qqlzagpc6v1x2gcdhe24"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardValidationRetrieveParams
        {
            CardValidationID = "outbound_card_validation_qqlzagpc6v1x2gcdhe24",
        };

        CardValidationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
