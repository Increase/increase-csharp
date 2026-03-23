using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using BookkeepingEntrySets = Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Tests.Models.BookkeepingEntrySets;

public class BookkeepingEntrySetListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<BookkeepingEntrySets::BookkeepingEntrySet> expectedData =
        [
            new()
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
        var model = new BookkeepingEntrySets::BookkeepingEntrySetListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BookkeepingEntrySets::BookkeepingEntrySetListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BookkeepingEntrySets::BookkeepingEntrySetListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<BookkeepingEntrySets::BookkeepingEntrySet> expectedData =
        [
            new()
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
        var model = new BookkeepingEntrySets::BookkeepingEntrySetListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingEntrySets::BookkeepingEntrySetListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        BookkeepingEntrySets::BookkeepingEntrySetListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
