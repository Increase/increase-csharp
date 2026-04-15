using System;
using Increase.Api.Models.CardTokens;

namespace Increase.Api.Tests.Models.CardTokens;

public class CardTokenCapabilitiesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardTokenCapabilitiesParams
        {
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
        };

        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";

        Assert.Equal(expectedCardTokenID, parameters.CardTokenID);
    }

    [Fact]
    public void Url_Works()
    {
        CardTokenCapabilitiesParams parameters = new()
        {
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/card_tokens/outbound_card_token_zlt0ml6youq3q7vcdlg0/capabilities"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardTokenCapabilitiesParams
        {
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
        };

        CardTokenCapabilitiesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
