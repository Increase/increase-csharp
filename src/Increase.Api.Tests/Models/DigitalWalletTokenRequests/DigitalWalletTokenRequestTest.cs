using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using DigitalWalletTokenRequests = Increase.Api.Models.DigitalWalletTokenRequests;

namespace Increase.Api.Tests.Models.DigitalWalletTokenRequests;

public class DigitalWalletTokenRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
        };

        string expectedID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DigitalWalletTokenRequests::Declined expectedDeclined = new(
            DigitalWalletTokenRequests::Reason.CardNotActive
        );
        DigitalWalletTokenRequests::Device expectedDevice = new()
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
            Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
            IPAddress = "1.2.3.4",
            Name = "My Work Phone",
        };
        ApiEnum<string, DigitalWalletTokenRequests::Outcome> expectedOutcome =
            DigitalWalletTokenRequests::Outcome.Provisioned;
        DigitalWalletTokenRequests::Provisioned expectedProvisioned = new(
            "digital_wallet_token_izi62go3h51p369jrie0"
        );
        string expectedTokenReferenceIdentifier = "DNITHE000000000000000000000";
        ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor> expectedTokenRequestor =
            DigitalWalletTokenRequests::TokenRequestor.ApplePay;
        ApiEnum<string, DigitalWalletTokenRequests::Type> expectedType =
            DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeclined, model.Declined);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedProvisioned, model.Provisioned);
        Assert.Equal(expectedTokenReferenceIdentifier, model.TokenReferenceIdentifier);
        Assert.Equal(expectedTokenRequestor, model.TokenRequestor);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::DigitalWalletTokenRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::DigitalWalletTokenRequest>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DigitalWalletTokenRequests::Declined expectedDeclined = new(
            DigitalWalletTokenRequests::Reason.CardNotActive
        );
        DigitalWalletTokenRequests::Device expectedDevice = new()
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
            Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
            IPAddress = "1.2.3.4",
            Name = "My Work Phone",
        };
        ApiEnum<string, DigitalWalletTokenRequests::Outcome> expectedOutcome =
            DigitalWalletTokenRequests::Outcome.Provisioned;
        DigitalWalletTokenRequests::Provisioned expectedProvisioned = new(
            "digital_wallet_token_izi62go3h51p369jrie0"
        );
        string expectedTokenReferenceIdentifier = "DNITHE000000000000000000000";
        ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor> expectedTokenRequestor =
            DigitalWalletTokenRequests::TokenRequestor.ApplePay;
        ApiEnum<string, DigitalWalletTokenRequests::Type> expectedType =
            DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeclined, deserialized.Declined);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedProvisioned, deserialized.Provisioned);
        Assert.Equal(expectedTokenReferenceIdentifier, deserialized.TokenReferenceIdentifier);
        Assert.Equal(expectedTokenRequestor, deserialized.TokenRequestor);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
        };

        DigitalWalletTokenRequests::DigitalWalletTokenRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclinedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Declined
        {
            Reason = DigitalWalletTokenRequests::Reason.CardNotActive,
        };

        ApiEnum<string, DigitalWalletTokenRequests::Reason> expectedReason =
            DigitalWalletTokenRequests::Reason.CardNotActive;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Declined
        {
            Reason = DigitalWalletTokenRequests::Reason.CardNotActive,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Declined>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Declined
        {
            Reason = DigitalWalletTokenRequests::Reason.CardNotActive,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Declined>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DigitalWalletTokenRequests::Reason> expectedReason =
            DigitalWalletTokenRequests::Reason.CardNotActive;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::Declined
        {
            Reason = DigitalWalletTokenRequests::Reason.CardNotActive,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Declined
        {
            Reason = DigitalWalletTokenRequests::Reason.CardNotActive,
        };

        DigitalWalletTokenRequests::Declined copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::Reason.CardNotActive)]
    [InlineData(DigitalWalletTokenRequests::Reason.NoVerificationMethod)]
    [InlineData(DigitalWalletTokenRequests::Reason.WebhookTimedOut)]
    [InlineData(DigitalWalletTokenRequests::Reason.WebhookDeclined)]
    [InlineData(DigitalWalletTokenRequests::Reason.IncorrectCardVerificationCode)]
    [InlineData(DigitalWalletTokenRequests::Reason.DeclinedByTokenRequestor)]
    [InlineData(DigitalWalletTokenRequests::Reason.GroupLocked)]
    [InlineData(DigitalWalletTokenRequests::Reason.AccountClosed)]
    [InlineData(DigitalWalletTokenRequests::Reason.EntityNotActive)]
    public void Validation_Works(DigitalWalletTokenRequests::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokenRequests::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::Reason.CardNotActive)]
    [InlineData(DigitalWalletTokenRequests::Reason.NoVerificationMethod)]
    [InlineData(DigitalWalletTokenRequests::Reason.WebhookTimedOut)]
    [InlineData(DigitalWalletTokenRequests::Reason.WebhookDeclined)]
    [InlineData(DigitalWalletTokenRequests::Reason.IncorrectCardVerificationCode)]
    [InlineData(DigitalWalletTokenRequests::Reason.DeclinedByTokenRequestor)]
    [InlineData(DigitalWalletTokenRequests::Reason.GroupLocked)]
    [InlineData(DigitalWalletTokenRequests::Reason.AccountClosed)]
    [InlineData(DigitalWalletTokenRequests::Reason.EntityNotActive)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokenRequests::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Device
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        ApiEnum<string, DigitalWalletTokenRequests::DeviceType> expectedDeviceType =
            DigitalWalletTokenRequests::DeviceType.Unknown;
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
        var model = new DigitalWalletTokenRequests::Device
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Device>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Device
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Device>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DigitalWalletTokenRequests::DeviceType> expectedDeviceType =
            DigitalWalletTokenRequests::DeviceType.Unknown;
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
        var model = new DigitalWalletTokenRequests::Device
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Device
        {
            DeviceType = DigitalWalletTokenRequests::DeviceType.Unknown,
            Identifier = "identifier",
            IPAddress = "ip_address",
            Name = "name",
        };

        DigitalWalletTokenRequests::Device copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeviceTypeTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Unknown)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.MobilePhone)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Tablet)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Watch)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.MobilephoneOrTablet)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Pc)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.HouseholdDevice)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.WearableDevice)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.AutomobileDevice)]
    public void Validation_Works(DigitalWalletTokenRequests::DeviceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::DeviceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::DeviceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Unknown)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.MobilePhone)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Tablet)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Watch)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.MobilephoneOrTablet)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.Pc)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.HouseholdDevice)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.WearableDevice)]
    [InlineData(DigitalWalletTokenRequests::DeviceType.AutomobileDevice)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::DeviceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::DeviceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::DeviceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::DeviceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::DeviceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutcomeTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::Outcome.Provisioned)]
    [InlineData(DigitalWalletTokenRequests::Outcome.Declined)]
    public void Validation_Works(DigitalWalletTokenRequests::Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Outcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Outcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::Outcome.Provisioned)]
    [InlineData(DigitalWalletTokenRequests::Outcome.Declined)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Outcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Outcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Outcome>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Outcome>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProvisionedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Provisioned
        {
            DigitalWalletTokenID = "digital_wallet_token_id",
        };

        string expectedDigitalWalletTokenID = "digital_wallet_token_id";

        Assert.Equal(expectedDigitalWalletTokenID, model.DigitalWalletTokenID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Provisioned
        {
            DigitalWalletTokenID = "digital_wallet_token_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Provisioned>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Provisioned
        {
            DigitalWalletTokenID = "digital_wallet_token_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Provisioned>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDigitalWalletTokenID = "digital_wallet_token_id";

        Assert.Equal(expectedDigitalWalletTokenID, deserialized.DigitalWalletTokenID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::Provisioned
        {
            DigitalWalletTokenID = "digital_wallet_token_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Provisioned
        {
            DigitalWalletTokenID = "digital_wallet_token_id",
        };

        DigitalWalletTokenRequests::Provisioned copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenRequestorTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.ApplePay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.GooglePay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.SamsungPay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.GarminPay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.Unknown)]
    public void Validation_Works(DigitalWalletTokenRequests::TokenRequestor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.ApplePay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.GooglePay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.SamsungPay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.GarminPay)]
    [InlineData(DigitalWalletTokenRequests::TokenRequestor.Unknown)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::TokenRequestor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest)]
    public void Validation_Works(DigitalWalletTokenRequests::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokenRequests::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokenRequests::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
