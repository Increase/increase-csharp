using System;
using Increase.Api.Models.CardTokens;

namespace Increase.Api.Tests.Models.CardTokens;

public class CardTokenRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardTokenRetrieveParams
        {
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
        };

        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";

        Assert.Equal(expectedCardTokenID, parameters.CardTokenID);
    }

    [Fact]
    public void Url_Works()
    {
        CardTokenRetrieveParams parameters = new()
        {
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/card_tokens/outbound_card_token_zlt0ml6youq3q7vcdlg0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardTokenRetrieveParams
        {
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
        };

        CardTokenRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
