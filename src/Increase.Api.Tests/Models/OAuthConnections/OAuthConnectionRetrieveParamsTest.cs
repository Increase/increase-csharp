using System;
using Increase.Api.Models.OAuthConnections;

namespace Increase.Api.Tests.Models.OAuthConnections;

public class OAuthConnectionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OAuthConnectionRetrieveParams
        {
            OAuthConnectionID = "connection_dauknoksyr4wilz4e6my",
        };

        string expectedOAuthConnectionID = "connection_dauknoksyr4wilz4e6my";

        Assert.Equal(expectedOAuthConnectionID, parameters.OAuthConnectionID);
    }

    [Fact]
    public void Url_Works()
    {
        OAuthConnectionRetrieveParams parameters = new()
        {
            OAuthConnectionID = "connection_dauknoksyr4wilz4e6my",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/oauth_connections/connection_dauknoksyr4wilz4e6my"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OAuthConnectionRetrieveParams
        {
            OAuthConnectionID = "connection_dauknoksyr4wilz4e6my",
        };

        OAuthConnectionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
