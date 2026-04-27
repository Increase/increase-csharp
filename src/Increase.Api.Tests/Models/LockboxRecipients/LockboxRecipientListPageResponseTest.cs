using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using LockboxRecipients = Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Tests.Models.LockboxRecipients;

public class LockboxRecipientListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LockboxRecipients::LockboxRecipientListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = null,
                    IdempotencyKey = null,
                    LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    MailStopCode = "VRE6P",
                    RecipientName = "Company Inc.",
                    Status = LockboxRecipients::LockboxRecipientStatus.Active,
                    Type = LockboxRecipients::Type.LockboxRecipient,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<LockboxRecipients::LockboxRecipient> expectedData =
        [
            new()
            {
                ID = "lockbox_3xt21ok13q19advds4t5",
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = null,
                IdempotencyKey = null,
                LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                MailStopCode = "VRE6P",
                RecipientName = "Company Inc.",
                Status = LockboxRecipients::LockboxRecipientStatus.Active,
                Type = LockboxRecipients::Type.LockboxRecipient,
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
        var model = new LockboxRecipients::LockboxRecipientListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = null,
                    IdempotencyKey = null,
                    LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    MailStopCode = "VRE6P",
                    RecipientName = "Company Inc.",
                    Status = LockboxRecipients::LockboxRecipientStatus.Active,
                    Type = LockboxRecipients::Type.LockboxRecipient,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<LockboxRecipients::LockboxRecipientListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LockboxRecipients::LockboxRecipientListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = null,
                    IdempotencyKey = null,
                    LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    MailStopCode = "VRE6P",
                    RecipientName = "Company Inc.",
                    Status = LockboxRecipients::LockboxRecipientStatus.Active,
                    Type = LockboxRecipients::Type.LockboxRecipient,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<LockboxRecipients::LockboxRecipientListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<LockboxRecipients::LockboxRecipient> expectedData =
        [
            new()
            {
                ID = "lockbox_3xt21ok13q19advds4t5",
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = null,
                IdempotencyKey = null,
                LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                MailStopCode = "VRE6P",
                RecipientName = "Company Inc.",
                Status = LockboxRecipients::LockboxRecipientStatus.Active,
                Type = LockboxRecipients::Type.LockboxRecipient,
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
        var model = new LockboxRecipients::LockboxRecipientListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = null,
                    IdempotencyKey = null,
                    LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    MailStopCode = "VRE6P",
                    RecipientName = "Company Inc.",
                    Status = LockboxRecipients::LockboxRecipientStatus.Active,
                    Type = LockboxRecipients::Type.LockboxRecipient,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LockboxRecipients::LockboxRecipientListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_3xt21ok13q19advds4t5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = null,
                    IdempotencyKey = null,
                    LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    MailStopCode = "VRE6P",
                    RecipientName = "Company Inc.",
                    Status = LockboxRecipients::LockboxRecipientStatus.Active,
                    Type = LockboxRecipients::Type.LockboxRecipient,
                },
            ],
            NextCursor = "v57w5d",
        };

        LockboxRecipients::LockboxRecipientListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
