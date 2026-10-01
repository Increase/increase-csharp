using System;
using Increase.Api.Models.DigitalWalletTokenRequests;

namespace Increase.Api.Tests.Models.DigitalWalletTokenRequests;

public class DigitalWalletTokenRequestRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalWalletTokenRequestRetrieveParams
        {
            DigitalWalletTokenRequestID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
        };

        string expectedDigitalWalletTokenRequestID =
            "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek";

        Assert.Equal(expectedDigitalWalletTokenRequestID, parameters.DigitalWalletTokenRequestID);
    }

    [Fact]
    public void Url_Works()
    {
        DigitalWalletTokenRequestRetrieveParams parameters = new()
        {
            DigitalWalletTokenRequestID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/digital_wallet_token_requests/digital_wallet_token_request_dlsq0yabf7ev4xvke6ek"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalWalletTokenRequestRetrieveParams
        {
            DigitalWalletTokenRequestID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
        };

        DigitalWalletTokenRequestRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
