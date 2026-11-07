using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Checkbooks = Increase.Api.Models.Checkbooks;

namespace Increase.Api.Tests.Models.Checkbooks;

public class CheckbookListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checkbooks::CheckbookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Payer =
                    [
                        new("National Phonograph Company"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    ReturnAddress = new()
                    {
                        City = "San Francisco",
                        Line1 = "244 Kearny St",
                        Line2 = "Floor 8",
                        Name = "Undeliverable Mail",
                        PostalCode = "94108",
                        State = "CA",
                    },
                    Status = Checkbooks::CheckbookStatus.Mailed,
                    Style = Checkbooks::Style.ThreeRingBinder,
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = Checkbooks::Category.InTransit,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                        new()
                        {
                            Category = Checkbooks::Category.Delivered,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                    ],
                    Type = Checkbooks::Type.Checkbook,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Checkbooks::Checkbook> expectedData =
        [
            new()
            {
                ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IdempotencyKey = null,
                MailingAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                },
                Payer =
                [
                    new("National Phonograph Company"),
                    new("33 Liberty Street"),
                    new("New York, NY 10045"),
                ],
                ReturnAddress = new()
                {
                    City = "San Francisco",
                    Line1 = "244 Kearny St",
                    Line2 = "Floor 8",
                    Name = "Undeliverable Mail",
                    PostalCode = "94108",
                    State = "CA",
                },
                Status = Checkbooks::CheckbookStatus.Mailed,
                Style = Checkbooks::Style.ThreeRingBinder,
                TrackingUpdates =
                [
                    new()
                    {
                        Category = Checkbooks::Category.InTransit,
                        Country = "US",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        PostalCode = "10045",
                    },
                    new()
                    {
                        Category = Checkbooks::Category.Delivered,
                        Country = "US",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        PostalCode = "10045",
                    },
                ],
                Type = Checkbooks::Type.Checkbook,
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
        var model = new Checkbooks::CheckbookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Payer =
                    [
                        new("National Phonograph Company"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    ReturnAddress = new()
                    {
                        City = "San Francisco",
                        Line1 = "244 Kearny St",
                        Line2 = "Floor 8",
                        Name = "Undeliverable Mail",
                        PostalCode = "94108",
                        State = "CA",
                    },
                    Status = Checkbooks::CheckbookStatus.Mailed,
                    Style = Checkbooks::Style.ThreeRingBinder,
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = Checkbooks::Category.InTransit,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                        new()
                        {
                            Category = Checkbooks::Category.Delivered,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                    ],
                    Type = Checkbooks::Type.Checkbook,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::CheckbookListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checkbooks::CheckbookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Payer =
                    [
                        new("National Phonograph Company"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    ReturnAddress = new()
                    {
                        City = "San Francisco",
                        Line1 = "244 Kearny St",
                        Line2 = "Floor 8",
                        Name = "Undeliverable Mail",
                        PostalCode = "94108",
                        State = "CA",
                    },
                    Status = Checkbooks::CheckbookStatus.Mailed,
                    Style = Checkbooks::Style.ThreeRingBinder,
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = Checkbooks::Category.InTransit,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                        new()
                        {
                            Category = Checkbooks::Category.Delivered,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                    ],
                    Type = Checkbooks::Type.Checkbook,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::CheckbookListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Checkbooks::Checkbook> expectedData =
        [
            new()
            {
                ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IdempotencyKey = null,
                MailingAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                },
                Payer =
                [
                    new("National Phonograph Company"),
                    new("33 Liberty Street"),
                    new("New York, NY 10045"),
                ],
                ReturnAddress = new()
                {
                    City = "San Francisco",
                    Line1 = "244 Kearny St",
                    Line2 = "Floor 8",
                    Name = "Undeliverable Mail",
                    PostalCode = "94108",
                    State = "CA",
                },
                Status = Checkbooks::CheckbookStatus.Mailed,
                Style = Checkbooks::Style.ThreeRingBinder,
                TrackingUpdates =
                [
                    new()
                    {
                        Category = Checkbooks::Category.InTransit,
                        Country = "US",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        PostalCode = "10045",
                    },
                    new()
                    {
                        Category = Checkbooks::Category.Delivered,
                        Country = "US",
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        PostalCode = "10045",
                    },
                ],
                Type = Checkbooks::Type.Checkbook,
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
        var model = new Checkbooks::CheckbookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Payer =
                    [
                        new("National Phonograph Company"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    ReturnAddress = new()
                    {
                        City = "San Francisco",
                        Line1 = "244 Kearny St",
                        Line2 = "Floor 8",
                        Name = "Undeliverable Mail",
                        PostalCode = "94108",
                        State = "CA",
                    },
                    Status = Checkbooks::CheckbookStatus.Mailed,
                    Style = Checkbooks::Style.ThreeRingBinder,
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = Checkbooks::Category.InTransit,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                        new()
                        {
                            Category = Checkbooks::Category.Delivered,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                    ],
                    Type = Checkbooks::Type.Checkbook,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checkbooks::CheckbookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Payer =
                    [
                        new("National Phonograph Company"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    ReturnAddress = new()
                    {
                        City = "San Francisco",
                        Line1 = "244 Kearny St",
                        Line2 = "Floor 8",
                        Name = "Undeliverable Mail",
                        PostalCode = "94108",
                        State = "CA",
                    },
                    Status = Checkbooks::CheckbookStatus.Mailed,
                    Style = Checkbooks::Style.ThreeRingBinder,
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = Checkbooks::Category.InTransit,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                        new()
                        {
                            Category = Checkbooks::Category.Delivered,
                            Country = "US",
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            PostalCode = "10045",
                        },
                    ],
                    Type = Checkbooks::Type.Checkbook,
                },
            ],
            NextCursor = "v57w5d",
        };

        Checkbooks::CheckbookListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
