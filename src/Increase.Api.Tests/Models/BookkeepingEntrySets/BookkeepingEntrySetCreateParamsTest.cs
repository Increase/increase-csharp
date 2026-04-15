using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Tests.Models.BookkeepingEntrySets;

public class BookkeepingEntrySetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingEntrySetCreateParams
        {
            Entries =
            [
                new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
                new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
            ],
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        List<Entry> expectedEntries =
        [
            new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
            new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
        ];
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedEntries.Count, parameters.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], parameters.Entries[i]);
        }
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedTransactionID, parameters.TransactionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookkeepingEntrySetCreateParams
        {
            Entries =
            [
                new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
                new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
            ],
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawBodyData.ContainsKey("date"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookkeepingEntrySetCreateParams
        {
            Entries =
            [
                new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
                new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
            ],

            // Null should be interpreted as omitted for these properties
            Date = null,
            TransactionID = null,
        };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawBodyData.ContainsKey("date"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingEntrySetCreateParams parameters = new()
        {
            Entries =
            [
                new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
                new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/bookkeeping_entry_sets"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingEntrySetCreateParams
        {
            Entries =
            [
                new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
                new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
            ],
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        BookkeepingEntrySetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entry { AccountID = "account_id", Amount = 0 };

        string expectedAccountID = "account_id";
        long expectedAmount = 0;

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entry { AccountID = "account_id", Amount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entry { AccountID = "account_id", Amount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        long expectedAmount = 0;

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entry { AccountID = "account_id", Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entry { AccountID = "account_id", Amount = 0 };

        Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}
