using System;
using Increase.Api.Models.RoutingNumbers;

namespace Increase.Api.Tests.Models.RoutingNumbers;

public class RoutingNumberListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RoutingNumberListParams
        {
            RoutingNumber = "xxxxxxxxx",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedRoutingNumber = "xxxxxxxxx";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingNumberListParams { RoutingNumber = "xxxxxxxxx" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RoutingNumberListParams
        {
            RoutingNumber = "xxxxxxxxx",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        RoutingNumberListParams parameters = new()
        {
            RoutingNumber = "xxxxxxxxx",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/routing_numbers?routing_number=xxxxxxxxx&cursor=cursor&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RoutingNumberListParams
        {
            RoutingNumber = "xxxxxxxxx",
            Cursor = "cursor",
            Limit = 1,
        };

        RoutingNumberListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
