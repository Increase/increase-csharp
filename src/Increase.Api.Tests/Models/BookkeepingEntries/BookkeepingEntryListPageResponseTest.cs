using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using BookkeepingEntries = Increase.Api.Models.BookkeepingEntries;

namespace Increase.Api.Tests.Models.BookkeepingEntries;

public class BookkeepingEntryListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntryListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                    Type = BookkeepingEntries::Type.BookkeepingEntry,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<BookkeepingEntries::BookkeepingEntry> expectedData =
        [
            new()
            {
                ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                Amount = 1750,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                Type = BookkeepingEntries::Type.BookkeepingEntry,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntryListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                    Type = BookkeepingEntries::Type.BookkeepingEntry,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BookkeepingEntries::BookkeepingEntryListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntryListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                    Type = BookkeepingEntries::Type.BookkeepingEntry,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BookkeepingEntries::BookkeepingEntryListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<BookkeepingEntries::BookkeepingEntry> expectedData =
        [
            new()
            {
                ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                Amount = 1750,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                Type = BookkeepingEntries::Type.BookkeepingEntry,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntryListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                    Type = BookkeepingEntries::Type.BookkeepingEntry,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingEntries::BookkeepingEntryListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
                    AccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    Amount = 1750,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
                    Type = BookkeepingEntries::Type.BookkeepingEntry,
                },
            ],
            NextCursor = "v57w5d",
        };

        BookkeepingEntries::BookkeepingEntryListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
