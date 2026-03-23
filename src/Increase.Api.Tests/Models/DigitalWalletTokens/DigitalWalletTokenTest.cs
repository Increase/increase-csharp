using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using DigitalWalletTokens = Increase.Api.Models.DigitalWalletTokens;

namespace Increase.Api.Tests.Models.DigitalWalletTokens;

public class DigitalWalletTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletToken
        {
            ID = "digital_wallet_token_izi62go3h51p369jrie0",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("John Smith"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Device = new()
            {
                DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            DynamicPrimaryAccountNumber = new() { First6 = "first6", Last4 = "last4" },
            Status = DigitalWalletTokens::Status.Active,
            TokenRequestor = DigitalWalletTokens::TokenRequestor.ApplePay,
            Type = DigitalWalletTokens::Type.DigitalWalletToken,
            Updates =
            [
                new()
                {
                    Status = DigitalWalletTokens::UpdateStatus.Inactive,
                    Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
        };

        string expectedID = "digital_wallet_token_izi62go3h51p369jrie0";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        DigitalWalletTokens::Cardholder expectedCardholder = new("John Smith");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DigitalWalletTokens::Device expectedDevice = new()
        {
            DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
            Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
            IPAddress = "1.2.3.4",
            Name = "My Work Phone",
        };
        DigitalWalletTokens::DynamicPrimaryAccountNumber expectedDynamicPrimaryAccountNumber = new()
        {
            First6 = "first6",
            Last4 = "last4",
        };
        ApiEnum<string, DigitalWalletTokens::Status> expectedStatus =
            DigitalWalletTokens::Status.Active;
        ApiEnum<string, DigitalWalletTokens::TokenRequestor> expectedTokenRequestor =
            DigitalWalletTokens::TokenRequestor.ApplePay;
        ApiEnum<string, DigitalWalletTokens::Type> expectedType =
            DigitalWalletTokens::Type.DigitalWalletToken;
        List<DigitalWalletTokens::Update> expectedUpdates =
        [
            new()
            {
                Status = DigitalWalletTokens::UpdateStatus.Inactive,
                Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedCardholder, model.Cardholder);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedDynamicPrimaryAccountNumber, model.DynamicPrimaryAccountNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTokenRequestor, model.TokenRequestor);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdates.Count, model.Updates.Count);
        for (int i = 0; i < expectedUpdates.Count; i++)
        {
            Assert.Equal(expectedUpdates[i], model.Updates[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletToken
        {
            ID = "digital_wallet_token_izi62go3h51p369jrie0",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("John Smith"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Device = new()
            {
                DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            DynamicPrimaryAccountNumber = new() { First6 = "first6", Last4 = "last4" },
            Status = DigitalWalletTokens::Status.Active,
            TokenRequestor = DigitalWalletTokens::TokenRequestor.ApplePay,
            Type = DigitalWalletTokens::Type.DigitalWalletToken,
            Updates =
            [
                new()
                {
                    Status = DigitalWalletTokens::UpdateStatus.Inactive,
                    Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::DigitalWalletToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletToken
        {
            ID = "digital_wallet_token_izi62go3h51p369jrie0",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("John Smith"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Device = new()
            {
                DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            DynamicPrimaryAccountNumber = new() { First6 = "first6", Last4 = "last4" },
            Status = DigitalWalletTokens::Status.Active,
            TokenRequestor = DigitalWalletTokens::TokenRequestor.ApplePay,
            Type = DigitalWalletTokens::Type.DigitalWalletToken,
            Updates =
            [
                new()
                {
                    Status = DigitalWalletTokens::UpdateStatus.Inactive,
                    Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::DigitalWalletToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "digital_wallet_token_izi62go3h51p369jrie0";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        DigitalWalletTokens::Cardholder expectedCardholder = new("John Smith");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DigitalWalletTokens::Device expectedDevice = new()
        {
            DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
            Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
            IPAddress = "1.2.3.4",
            Name = "My Work Phone",
        };
        DigitalWalletTokens::DynamicPrimaryAccountNumber expectedDynamicPrimaryAccountNumber = new()
        {
            First6 = "first6",
            Last4 = "last4",
        };
        ApiEnum<string, DigitalWalletTokens::Status> expectedStatus =
            DigitalWalletTokens::Status.Active;
        ApiEnum<string, DigitalWalletTokens::TokenRequestor> expectedTokenRequestor =
            DigitalWalletTokens::TokenRequestor.ApplePay;
        ApiEnum<string, DigitalWalletTokens::Type> expectedType =
            DigitalWalletTokens::Type.DigitalWalletToken;
        List<DigitalWalletTokens::Update> expectedUpdates =
        [
            new()
            {
                Status = DigitalWalletTokens::UpdateStatus.Inactive,
                Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedCardholder, deserialized.Cardholder);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedDynamicPrimaryAccountNumber, deserialized.DynamicPrimaryAccountNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTokenRequestor, deserialized.TokenRequestor);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdates.Count, deserialized.Updates.Count);
        for (int i = 0; i < expectedUpdates.Count; i++)
        {
            Assert.Equal(expectedUpdates[i], deserialized.Updates[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletToken
        {
            ID = "digital_wallet_token_izi62go3h51p369jrie0",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("John Smith"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Device = new()
            {
                DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            DynamicPrimaryAccountNumber = new() { First6 = "first6", Last4 = "last4" },
            Status = DigitalWalletTokens::Status.Active,
            TokenRequestor = DigitalWalletTokens::TokenRequestor.ApplePay,
            Type = DigitalWalletTokens::Type.DigitalWalletToken,
            Updates =
            [
                new()
                {
                    Status = DigitalWalletTokens::UpdateStatus.Inactive,
                    Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletToken
        {
            ID = "digital_wallet_token_izi62go3h51p369jrie0",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("John Smith"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Device = new()
            {
                DeviceType = DigitalWalletTokens::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            DynamicPrimaryAccountNumber = new() { First6 = "first6", Last4 = "last4" },
            Status = DigitalWalletTokens::Status.Active,
            TokenRequestor = DigitalWalletTokens::TokenRequestor.ApplePay,
            Type = DigitalWalletTokens::Type.DigitalWalletToken,
            Updates =
            [
                new()
                {
                    Status = DigitalWalletTokens::UpdateStatus.Inactive,
                    Timestamp = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
        };

        DigitalWalletTokens::DigitalWalletToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::Cardholder { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::Cardholder { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::Cardholder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokens::Cardholder { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::Cardholder>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokens::Cardholder { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokens::Cardholder { Name = "name" };

        DigitalWalletTokens::Cardholder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::Device
        {
            DeviceType = DigitalWalletTokens::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        ApiEnum<string, DigitalWalletTokens::DeviceType> expectedDeviceType =
            DigitalWalletTokens::DeviceType.Unknown;
        string expectedIdentifier = "identifier";
        string expectedIPAddress = "ip_address";
        string expectedName = "name";

        Assert.Equal(expectedDeviceType, model.DeviceType);
        Assert.Equal(expectedIdentifier, model.Identifier);
        Assert.Equal(expectedIPAddress, model.IPAddress);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::Device
        {
            DeviceType = DigitalWalletTokens::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::Device>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokens::Device
        {
            DeviceType = DigitalWalletTokens::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::Device>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DigitalWalletTokens::DeviceType> expectedDeviceType =
            DigitalWalletTokens::DeviceType.Unknown;
        string expectedIdentifier = "identifier";
        string expectedIPAddress = "ip_address";
        string expectedName = "name";

        Assert.Equal(expectedDeviceType, deserialized.DeviceType);
        Assert.Equal(expectedIdentifier, deserialized.Identifier);
        Assert.Equal(expectedIPAddress, deserialized.IPAddress);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokens::Device
        {
            DeviceType = DigitalWalletTokens::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokens::Device
        {
            DeviceType = DigitalWalletTokens::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        DigitalWalletTokens::Device copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceTypeTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokens::DeviceType.Unknown)]
    [InlineData(DigitalWalletTokens::DeviceType.MobilePhone)]
    [InlineData(DigitalWalletTokens::DeviceType.Tablet)]
    [InlineData(DigitalWalletTokens::DeviceType.Watch)]
    [InlineData(DigitalWalletTokens::DeviceType.MobilephoneOrTablet)]
    [InlineData(DigitalWalletTokens::DeviceType.Pc)]
    [InlineData(DigitalWalletTokens::DeviceType.HouseholdDevice)]
    [InlineData(DigitalWalletTokens::DeviceType.WearableDevice)]
    [InlineData(DigitalWalletTokens::DeviceType.AutomobileDevice)]
    public void Validation_Works(DigitalWalletTokens::DeviceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::DeviceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::DeviceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokens::DeviceType.Unknown)]
    [InlineData(DigitalWalletTokens::DeviceType.MobilePhone)]
    [InlineData(DigitalWalletTokens::DeviceType.Tablet)]
    [InlineData(DigitalWalletTokens::DeviceType.Watch)]
    [InlineData(DigitalWalletTokens::DeviceType.MobilephoneOrTablet)]
    [InlineData(DigitalWalletTokens::DeviceType.Pc)]
    [InlineData(DigitalWalletTokens::DeviceType.HouseholdDevice)]
    [InlineData(DigitalWalletTokens::DeviceType.WearableDevice)]
    [InlineData(DigitalWalletTokens::DeviceType.AutomobileDevice)]
    public void SerializationRoundtrip_Works(DigitalWalletTokens::DeviceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::DeviceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::DeviceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::DeviceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::DeviceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DynamicPrimaryAccountNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::DynamicPrimaryAccountNumber
        {
            First6 = "first6",
            Last4 = "last4",
        };

        string expectedFirst6 = "first6";
        string expectedLast4 = "last4";

        Assert.Equal(expectedFirst6, model.First6);
        Assert.Equal(expectedLast4, model.Last4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::DynamicPrimaryAccountNumber
        {
            First6 = "first6",
            Last4 = "last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokens::DynamicPrimaryAccountNumber>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokens::DynamicPrimaryAccountNumber
        {
            First6 = "first6",
            Last4 = "last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokens::DynamicPrimaryAccountNumber>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFirst6 = "first6";
        string expectedLast4 = "last4";

        Assert.Equal(expectedFirst6, deserialized.First6);
        Assert.Equal(expectedLast4, deserialized.Last4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokens::DynamicPrimaryAccountNumber
        {
            First6 = "first6",
            Last4 = "last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokens::DynamicPrimaryAccountNumber
        {
            First6 = "first6",
            Last4 = "last4",
        };

        DigitalWalletTokens::DynamicPrimaryAccountNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokens::Status.Active)]
    [InlineData(DigitalWalletTokens::Status.Inactive)]
    [InlineData(DigitalWalletTokens::Status.Suspended)]
    [InlineData(DigitalWalletTokens::Status.Deactivated)]
    public void Validation_Works(DigitalWalletTokens::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokens::Status.Active)]
    [InlineData(DigitalWalletTokens::Status.Inactive)]
    [InlineData(DigitalWalletTokens::Status.Suspended)]
    [InlineData(DigitalWalletTokens::Status.Deactivated)]
    public void SerializationRoundtrip_Works(DigitalWalletTokens::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TokenRequestorTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokens::TokenRequestor.ApplePay)]
    [InlineData(DigitalWalletTokens::TokenRequestor.GooglePay)]
    [InlineData(DigitalWalletTokens::TokenRequestor.SamsungPay)]
    [InlineData(DigitalWalletTokens::TokenRequestor.Unknown)]
    public void Validation_Works(DigitalWalletTokens::TokenRequestor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::TokenRequestor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::TokenRequestor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokens::TokenRequestor.ApplePay)]
    [InlineData(DigitalWalletTokens::TokenRequestor.GooglePay)]
    [InlineData(DigitalWalletTokens::TokenRequestor.SamsungPay)]
    [InlineData(DigitalWalletTokens::TokenRequestor.Unknown)]
    public void SerializationRoundtrip_Works(DigitalWalletTokens::TokenRequestor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::TokenRequestor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::TokenRequestor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::TokenRequestor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::TokenRequestor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokens::Type.DigitalWalletToken)]
    public void Validation_Works(DigitalWalletTokens::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokens::Type.DigitalWalletToken)]
    public void SerializationRoundtrip_Works(DigitalWalletTokens::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::Update
        {
            Status = DigitalWalletTokens::UpdateStatus.Active,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, DigitalWalletTokens::UpdateStatus> expectedStatus =
            DigitalWalletTokens::UpdateStatus.Active;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::Update
        {
            Status = DigitalWalletTokens::UpdateStatus.Active,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::Update>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokens::Update
        {
            Status = DigitalWalletTokens::UpdateStatus.Active,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokens::Update>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DigitalWalletTokens::UpdateStatus> expectedStatus =
            DigitalWalletTokens::UpdateStatus.Active;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokens::Update
        {
            Status = DigitalWalletTokens::UpdateStatus.Active,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokens::Update
        {
            Status = DigitalWalletTokens::UpdateStatus.Active,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DigitalWalletTokens::Update copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateStatusTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokens::UpdateStatus.Active)]
    [InlineData(DigitalWalletTokens::UpdateStatus.Inactive)]
    [InlineData(DigitalWalletTokens::UpdateStatus.Suspended)]
    [InlineData(DigitalWalletTokens::UpdateStatus.Deactivated)]
    public void Validation_Works(DigitalWalletTokens::UpdateStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::UpdateStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::UpdateStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokens::UpdateStatus.Active)]
    [InlineData(DigitalWalletTokens::UpdateStatus.Inactive)]
    [InlineData(DigitalWalletTokens::UpdateStatus.Suspended)]
    [InlineData(DigitalWalletTokens::UpdateStatus.Deactivated)]
    public void SerializationRoundtrip_Works(DigitalWalletTokens::UpdateStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokens::UpdateStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::UpdateStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokens::UpdateStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokens::UpdateStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
