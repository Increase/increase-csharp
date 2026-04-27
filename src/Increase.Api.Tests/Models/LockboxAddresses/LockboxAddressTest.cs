using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using LockboxAddresses = Increase.Api.Models.LockboxAddresses;

namespace Increase.Api.Tests.Models.LockboxAddresses;

public class LockboxAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LockboxAddresses::LockboxAddress
        {
            ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Address = new()
            {
                City = "San Francisco",
                Line1 = "1234 Market St",
                Line2 = "Ste 567",
                PostalCode = "94114",
                State = "CA",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Lockbox Address 1",
            IdempotencyKey = null,
            Status = LockboxAddresses::LockboxAddressStatus.Active,
            Type = LockboxAddresses::Type.LockboxAddress,
        };

        string expectedID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        LockboxAddresses::Address expectedAddress = new()
        {
            City = "San Francisco",
            Line1 = "1234 Market St",
            Line2 = "Ste 567",
            PostalCode = "94114",
            State = "CA",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Lockbox Address 1";
        ApiEnum<string, LockboxAddresses::LockboxAddressStatus> expectedStatus =
            LockboxAddresses::LockboxAddressStatus.Active;
        ApiEnum<string, LockboxAddresses::Type> expectedType =
            LockboxAddresses::Type.LockboxAddress;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LockboxAddresses::LockboxAddress
        {
            ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Address = new()
            {
                City = "San Francisco",
                Line1 = "1234 Market St",
                Line2 = "Ste 567",
                PostalCode = "94114",
                State = "CA",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Lockbox Address 1",
            IdempotencyKey = null,
            Status = LockboxAddresses::LockboxAddressStatus.Active,
            Type = LockboxAddresses::Type.LockboxAddress,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LockboxAddresses::LockboxAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LockboxAddresses::LockboxAddress
        {
            ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Address = new()
            {
                City = "San Francisco",
                Line1 = "1234 Market St",
                Line2 = "Ste 567",
                PostalCode = "94114",
                State = "CA",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Lockbox Address 1",
            IdempotencyKey = null,
            Status = LockboxAddresses::LockboxAddressStatus.Active,
            Type = LockboxAddresses::Type.LockboxAddress,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LockboxAddresses::LockboxAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        LockboxAddresses::Address expectedAddress = new()
        {
            City = "San Francisco",
            Line1 = "1234 Market St",
            Line2 = "Ste 567",
            PostalCode = "94114",
            State = "CA",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Lockbox Address 1";
        ApiEnum<string, LockboxAddresses::LockboxAddressStatus> expectedStatus =
            LockboxAddresses::LockboxAddressStatus.Active;
        ApiEnum<string, LockboxAddresses::Type> expectedType =
            LockboxAddresses::Type.LockboxAddress;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LockboxAddresses::LockboxAddress
        {
            ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Address = new()
            {
                City = "San Francisco",
                Line1 = "1234 Market St",
                Line2 = "Ste 567",
                PostalCode = "94114",
                State = "CA",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Lockbox Address 1",
            IdempotencyKey = null,
            Status = LockboxAddresses::LockboxAddressStatus.Active,
            Type = LockboxAddresses::Type.LockboxAddress,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LockboxAddresses::LockboxAddress
        {
            ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            Address = new()
            {
                City = "San Francisco",
                Line1 = "1234 Market St",
                Line2 = "Ste 567",
                PostalCode = "94114",
                State = "CA",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Lockbox Address 1",
            IdempotencyKey = null,
            Status = LockboxAddresses::LockboxAddressStatus.Active,
            Type = LockboxAddresses::Type.LockboxAddress,
        };

        LockboxAddresses::LockboxAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LockboxAddresses::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LockboxAddresses::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LockboxAddresses::Address>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LockboxAddresses::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LockboxAddresses::Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LockboxAddresses::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LockboxAddresses::Address
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        LockboxAddresses::Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LockboxAddressStatusTest : TestBase
{
    [Theory]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Pending)]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Active)]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Disabled)]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Canceled)]
    public void Validation_Works(LockboxAddresses::LockboxAddressStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxAddresses::LockboxAddressStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxAddresses::LockboxAddressStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Pending)]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Active)]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Disabled)]
    [InlineData(LockboxAddresses::LockboxAddressStatus.Canceled)]
    public void SerializationRoundtrip_Works(LockboxAddresses::LockboxAddressStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxAddresses::LockboxAddressStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxAddresses::LockboxAddressStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxAddresses::LockboxAddressStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LockboxAddresses::LockboxAddressStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(LockboxAddresses::Type.LockboxAddress)]
    public void Validation_Works(LockboxAddresses::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxAddresses::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LockboxAddresses::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LockboxAddresses::Type.LockboxAddress)]
    public void SerializationRoundtrip_Works(LockboxAddresses::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LockboxAddresses::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LockboxAddresses::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LockboxAddresses::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LockboxAddresses::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
