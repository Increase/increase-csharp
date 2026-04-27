using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using LockboxRecipients = Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Tests.Models.LockboxRecipients;

public class LockboxRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LockboxRecipients::LockboxRecipient
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
        };

        string expectedID = "lockbox_3xt21ok13q19advds4t5";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedLockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        string expectedMailStopCode = "VRE6P";
        string expectedRecipientName = "Company Inc.";
        ApiEnum<string, LockboxRecipients::LockboxRecipientStatus> expectedStatus =
            LockboxRecipients::LockboxRecipientStatus.Active;
        ApiEnum<string, LockboxRecipients::Type> expectedType =
            LockboxRecipients::Type.LockboxRecipient;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.Description);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedLockboxAddressID, model.LockboxAddressID);
        Assert.Equal(expectedMailStopCode, model.MailStopCode);
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LockboxRecipients::LockboxRecipient
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LockboxRecipients::LockboxRecipient>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LockboxRecipients::LockboxRecipient
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LockboxRecipients::LockboxRecipient>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "lockbox_3xt21ok13q19advds4t5";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedLockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        string expectedMailStopCode = "VRE6P";
        string expectedRecipientName = "Company Inc.";
        ApiEnum<string, LockboxRecipients::LockboxRecipientStatus> expectedStatus =
            LockboxRecipients::LockboxRecipientStatus.Active;
        ApiEnum<string, LockboxRecipients::Type> expectedType =
            LockboxRecipients::Type.LockboxRecipient;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.Description);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedLockboxAddressID, deserialized.LockboxAddressID);
        Assert.Equal(expectedMailStopCode, deserialized.MailStopCode);
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LockboxRecipients::LockboxRecipient
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LockboxRecipients::LockboxRecipient
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
        };

        LockboxRecipients::LockboxRecipient copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LockboxRecipientStatusTest : TestBase
{
    [Theory]
    [InlineData(LockboxRecipients::LockboxRecipientStatus.Active)]
    [InlineData(LockboxRecipients::LockboxRecipientStatus.Disabled)]
    [InlineData(LockboxRecipients::LockboxRecipientStatus.Canceled)]
    public void Validation_Works(LockboxRecipients::LockboxRecipientStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxRecipients::LockboxRecipientStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxRecipients::LockboxRecipientStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LockboxRecipients::LockboxRecipientStatus.Active)]
    [InlineData(LockboxRecipients::LockboxRecipientStatus.Disabled)]
    [InlineData(LockboxRecipients::LockboxRecipientStatus.Canceled)]
    public void SerializationRoundtrip_Works(LockboxRecipients::LockboxRecipientStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxRecipients::LockboxRecipientStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxRecipients::LockboxRecipientStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxRecipients::LockboxRecipientStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxRecipients::LockboxRecipientStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(LockboxRecipients::Type.LockboxRecipient)]
    public void Validation_Works(LockboxRecipients::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxRecipients::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LockboxRecipients::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LockboxRecipients::Type.LockboxRecipient)]
    public void SerializationRoundtrip_Works(LockboxRecipients::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxRecipients::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LockboxRecipients::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LockboxRecipients::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LockboxRecipients::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
