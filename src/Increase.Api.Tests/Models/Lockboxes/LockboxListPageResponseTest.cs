using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Lockboxes = Increase.Api.Models.Lockboxes;

namespace Increase.Api.Tests.Models.Lockboxes;

public class LockboxListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Lockboxes::LockboxListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        Recipient = "Company Inc. ATTN: VRE6P",
                        State = "CA",
                    },
                    CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox 1",
                    IdempotencyKey = null,
                    RecipientName = "Company Inc.",
                    Type = Lockboxes::Type.Lockbox,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Lockboxes::Lockbox> expectedData =
        [
            new()
            {
                ID = "lockbox_3xt21ok13q19advds4t5",
                AccountID = "account_in71c4amph0vgo2qllky",
                Address = new()
                {
                    City = "San Francisco",
                    Line1 = "1234 Market St",
                    Line2 = "Ste 567",
                    PostalCode = "94114",
                    Recipient = "Company Inc. ATTN: VRE6P",
                    State = "CA",
                },
                CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Lockbox 1",
                IdempotencyKey = null,
                RecipientName = "Company Inc.",
                Type = Lockboxes::Type.Lockbox,
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
        var model = new Lockboxes::LockboxListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        Recipient = "Company Inc. ATTN: VRE6P",
                        State = "CA",
                    },
                    CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox 1",
                    IdempotencyKey = null,
                    RecipientName = "Company Inc.",
                    Type = Lockboxes::Type.Lockbox,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lockboxes::LockboxListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Lockboxes::LockboxListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        Recipient = "Company Inc. ATTN: VRE6P",
                        State = "CA",
                    },
                    CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox 1",
                    IdempotencyKey = null,
                    RecipientName = "Company Inc.",
                    Type = Lockboxes::Type.Lockbox,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lockboxes::LockboxListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Lockboxes::Lockbox> expectedData =
        [
            new()
            {
                ID = "lockbox_3xt21ok13q19advds4t5",
                AccountID = "account_in71c4amph0vgo2qllky",
                Address = new()
                {
                    City = "San Francisco",
                    Line1 = "1234 Market St",
                    Line2 = "Ste 567",
                    PostalCode = "94114",
                    Recipient = "Company Inc. ATTN: VRE6P",
                    State = "CA",
                },
                CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Lockbox 1",
                IdempotencyKey = null,
                RecipientName = "Company Inc.",
                Type = Lockboxes::Type.Lockbox,
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
        var model = new Lockboxes::LockboxListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        Recipient = "Company Inc. ATTN: VRE6P",
                        State = "CA",
                    },
                    CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox 1",
                    IdempotencyKey = null,
                    RecipientName = "Company Inc.",
                    Type = Lockboxes::Type.Lockbox,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Lockboxes::LockboxListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        Recipient = "Company Inc. ATTN: VRE6P",
                        State = "CA",
                    },
                    CheckDepositBehavior = Lockboxes::LockboxCheckDepositBehavior.Enabled,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox 1",
                    IdempotencyKey = null,
                    RecipientName = "Company Inc.",
                    Type = Lockboxes::Type.Lockbox,
                },
            ],
            NextCursor = "v57w5d",
        };

        Lockboxes::LockboxListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
