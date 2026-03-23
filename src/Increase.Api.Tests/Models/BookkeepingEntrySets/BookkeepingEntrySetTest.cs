using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using BookkeepingEntrySets = Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Tests.Models.BookkeepingEntrySets;

public class BookkeepingEntrySetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySet
        {
            ID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            CreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z"),
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Entries =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                },
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = -1750,
                },
            ],
            IdempotencyKey = null,
            TransactionID = null,
            Type = BookkeepingEntrySets::Type.BookkeepingEntrySet,
        };

        string expectedID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z");
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        List<BookkeepingEntrySets::BookkeepingEntrySetEntry> expectedEntries =
        [
            new()
            {
                ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                Amount = 1750,
            },
            new()
            {
                ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                Amount = -1750,
            },
        ];
        ApiEnum<string, BookkeepingEntrySets::Type> expectedType =
            BookkeepingEntrySets::Type.BookkeepingEntrySet;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.TransactionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySet
        {
            ID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            CreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z"),
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Entries =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                },
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = -1750,
                },
            ],
            IdempotencyKey = null,
            TransactionID = null,
            Type = BookkeepingEntrySets::Type.BookkeepingEntrySet,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingEntrySets::BookkeepingEntrySet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySet
        {
            ID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            CreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z"),
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Entries =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                },
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = -1750,
                },
            ],
            IdempotencyKey = null,
            TransactionID = null,
            Type = BookkeepingEntrySets::Type.BookkeepingEntrySet,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingEntrySets::BookkeepingEntrySet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z");
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        List<BookkeepingEntrySets::BookkeepingEntrySetEntry> expectedEntries =
        [
            new()
            {
                ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                Amount = 1750,
            },
            new()
            {
                ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                Amount = -1750,
            },
        ];
        ApiEnum<string, BookkeepingEntrySets::Type> expectedType =
            BookkeepingEntrySets::Type.BookkeepingEntrySet;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySet
        {
            ID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            CreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z"),
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Entries =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                },
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = -1750,
                },
            ],
            IdempotencyKey = null,
            TransactionID = null,
            Type = BookkeepingEntrySets::Type.BookkeepingEntrySet,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySet
        {
            ID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            CreatedAt = DateTimeOffset.Parse("2023-02-11T02:11:59Z"),
            Date = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Entries =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                },
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = -1750,
                },
            ],
            IdempotencyKey = null,
            TransactionID = null,
            Type = BookkeepingEntrySets::Type.BookkeepingEntrySet,
        };

        BookkeepingEntrySets::BookkeepingEntrySet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BookkeepingEntrySetEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetEntry
        {
            ID = "id",
            AccountID = "account_id",
            Amount = 0,
        };

        string expectedID = "id";
        string expectedAccountID = "account_id";
        long expectedAmount = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetEntry
        {
            ID = "id",
            AccountID = "account_id",
            Amount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BookkeepingEntrySets::BookkeepingEntrySetEntry>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetEntry
        {
            ID = "id",
            AccountID = "account_id",
            Amount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BookkeepingEntrySets::BookkeepingEntrySetEntry>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAccountID = "account_id";
        long expectedAmount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetEntry
        {
            ID = "id",
            AccountID = "account_id",
            Amount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetEntry
        {
            ID = "id",
            AccountID = "account_id",
            Amount = 0,
        };

        BookkeepingEntrySets::BookkeepingEntrySetEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(BookkeepingEntrySets::Type.BookkeepingEntrySet)]
    public void Validation_Works(BookkeepingEntrySets::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingEntrySets::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntrySets::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BookkeepingEntrySets::Type.BookkeepingEntrySet)]
    public void SerializationRoundtrip_Works(BookkeepingEntrySets::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingEntrySets::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntrySets::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntrySets::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntrySets::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
