using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using BookkeepingEntries = Increase.Api.Models.BookkeepingEntries;

namespace Increase.Api.Tests.Models.BookkeepingEntries;

public class BookkeepingEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntry
        {
            ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
            AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Amount = 1750,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            Type = BookkeepingEntries::Type.BookkeepingEntry,
        };

        string expectedID = "bookkeeping_entry_ctjpajsj3ks2blx10375";
        string expectedAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        long expectedAmount = 1750;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf";
        ApiEnum<string, BookkeepingEntries::Type> expectedType =
            BookkeepingEntries::Type.BookkeepingEntry;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntrySetID, model.EntrySetID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntry
        {
            ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
            AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Amount = 1750,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            Type = BookkeepingEntries::Type.BookkeepingEntry,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingEntries::BookkeepingEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntry
        {
            ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
            AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Amount = 1750,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            Type = BookkeepingEntries::Type.BookkeepingEntry,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingEntries::BookkeepingEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "bookkeeping_entry_ctjpajsj3ks2blx10375";
        string expectedAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        long expectedAmount = 1750;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf";
        ApiEnum<string, BookkeepingEntries::Type> expectedType =
            BookkeepingEntries::Type.BookkeepingEntry;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntrySetID, deserialized.EntrySetID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntry
        {
            ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
            AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Amount = 1750,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            Type = BookkeepingEntries::Type.BookkeepingEntry,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntry
        {
            ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
            AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Amount = 1750,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            Type = BookkeepingEntries::Type.BookkeepingEntry,
        };

        BookkeepingEntries::BookkeepingEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(BookkeepingEntries::Type.BookkeepingEntry)]
    public void Validation_Works(BookkeepingEntries::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingEntries::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntries::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BookkeepingEntries::Type.BookkeepingEntry)]
    public void SerializationRoundtrip_Works(BookkeepingEntries::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingEntries::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntries::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntries::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingEntries::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
