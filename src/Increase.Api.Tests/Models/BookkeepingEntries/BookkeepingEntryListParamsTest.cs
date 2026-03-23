using System;
using Increase.Api.Models.BookkeepingEntries;

namespace Increase.Api.Tests.Models.BookkeepingEntries;

public class BookkeepingEntryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingEntryListParams
        {
            AccountID = "account_id",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedAccountID = "account_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookkeepingEntryListParams { };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookkeepingEntryListParams
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingEntryListParams parameters = new()
        {
            AccountID = "account_id",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/bookkeeping_entries?account_id=account_id&cursor=cursor&limit=1"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingEntryListParams
        {
            AccountID = "account_id",
            Cursor = "cursor",
            Limit = 1,
        };

        BookkeepingEntryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
