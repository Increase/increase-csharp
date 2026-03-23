using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Lockboxes = Increase.Api.Models.Lockboxes;

namespace Increase.Api.Tests.Models.Lockboxes;

public class LockboxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Lockboxes::Lockbox
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
        };

        string expectedID = "lockbox_3xt21ok13q19advds4t5";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        Lockboxes::Address expectedAddress = new()
        {
            City = "San Francisco",
            Line1 = "1234 Market St",
            Line2 = "Ste 567",
            PostalCode = "94114",
            Recipient = "Company Inc. ATTN: VRE6P",
            State = "CA",
        };
        ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior> expectedCheckDepositBehavior =
            Lockboxes::LockboxCheckDepositBehavior.Enabled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Lockbox 1";
        string expectedRecipientName = "Company Inc.";
        ApiEnum<string, Lockboxes::Type> expectedType = Lockboxes::Type.Lockbox;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCheckDepositBehavior, model.CheckDepositBehavior);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Lockboxes::Lockbox
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lockboxes::Lockbox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Lockboxes::Lockbox
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lockboxes::Lockbox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "lockbox_3xt21ok13q19advds4t5";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        Lockboxes::Address expectedAddress = new()
        {
            City = "San Francisco",
            Line1 = "1234 Market St",
            Line2 = "Ste 567",
            PostalCode = "94114",
            Recipient = "Company Inc. ATTN: VRE6P",
            State = "CA",
        };
        ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior> expectedCheckDepositBehavior =
            Lockboxes::LockboxCheckDepositBehavior.Enabled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Lockbox 1";
        string expectedRecipientName = "Company Inc.";
        ApiEnum<string, Lockboxes::Type> expectedType = Lockboxes::Type.Lockbox;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCheckDepositBehavior, deserialized.CheckDepositBehavior);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Lockboxes::Lockbox
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Lockboxes::Lockbox
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
        };

        Lockboxes::Lockbox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Lockboxes::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            Recipient = "recipient",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedRecipient = "recipient";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Lockboxes::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            Recipient = "recipient",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lockboxes::Address>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Lockboxes::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            Recipient = "recipient",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lockboxes::Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedRecipient = "recipient";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Lockboxes::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            Recipient = "recipient",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Lockboxes::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            Recipient = "recipient",
            State = "state",
        };

        Lockboxes::Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LockboxCheckDepositBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Lockboxes::LockboxCheckDepositBehavior.Enabled)]
    [InlineData(Lockboxes::LockboxCheckDepositBehavior.Disabled)]
    [InlineData(Lockboxes::LockboxCheckDepositBehavior.PendForProcessing)]
    public void Validation_Works(Lockboxes::LockboxCheckDepositBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Lockboxes::LockboxCheckDepositBehavior.Enabled)]
    [InlineData(Lockboxes::LockboxCheckDepositBehavior.Disabled)]
    [InlineData(Lockboxes::LockboxCheckDepositBehavior.PendForProcessing)]
    public void SerializationRoundtrip_Works(Lockboxes::LockboxCheckDepositBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Lockboxes::LockboxCheckDepositBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Lockboxes::Type.Lockbox)]
    public void Validation_Works(Lockboxes::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Lockboxes::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Lockboxes::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Lockboxes::Type.Lockbox)]
    public void SerializationRoundtrip_Works(Lockboxes::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Lockboxes::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Lockboxes::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Lockboxes::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Lockboxes::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
