using System;
using Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Tests.Models.BookkeepingEntrySets;

public class BookkeepingEntrySetListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingEntrySetListParams
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            TransactionID = "transaction_id",
        };

        string expectedCursor = "cursor";
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedTransactionID, parameters.TransactionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookkeepingEntrySetListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawQueryData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookkeepingEntrySetListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            IdempotencyKey = null,
            Limit = null,
            TransactionID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawQueryData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingEntrySetListParams parameters = new()
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            TransactionID = "transaction_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/bookkeeping_entry_sets?cursor=cursor&idempotency_key=x&limit=1&transaction_id=transaction_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingEntrySetListParams
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            TransactionID = "transaction_id",
        };

        BookkeepingEntrySetListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
