using System;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingAccountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingAccountListParams
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
        };

        string expectedCursor = "cursor";
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookkeepingAccountListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookkeepingAccountListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            IdempotencyKey = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingAccountListParams parameters = new()
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/bookkeeping_accounts?cursor=cursor&idempotency_key=x&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingAccountListParams
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
        };

        BookkeepingAccountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
