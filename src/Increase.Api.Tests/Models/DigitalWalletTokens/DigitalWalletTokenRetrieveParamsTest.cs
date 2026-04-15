using System;
using Increase.Api.Models.DigitalWalletTokens;

namespace Increase.Api.Tests.Models.DigitalWalletTokens;

public class DigitalWalletTokenRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalWalletTokenRetrieveParams
        {
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
        };

        string expectedDigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0";

        Assert.Equal(expectedDigitalWalletTokenID, parameters.DigitalWalletTokenID);
    }

    [Fact]
    public void Url_Works()
    {
        DigitalWalletTokenRetrieveParams parameters = new()
        {
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/digital_wallet_tokens/digital_wallet_token_izi62go3h51p369jrie0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalWalletTokenRetrieveParams
        {
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
        };

        DigitalWalletTokenRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
