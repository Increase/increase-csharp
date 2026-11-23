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
            Cardholder = new("Ian Crease"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Network = DigitalWalletTokenRequests::Network.Visa,
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            TokenRequestorDetails = new() { Identifier = "40010030273", Name = "Apple Inc." },
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
            Verification = new(
                new DigitalWalletTokenRequests::CardholderAddress()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94132",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result = DigitalWalletTokenRequests::Result.Match,
                }
            ),
            Visa = new() { NetworkRiskScore = 26, ProvisioningRiskScore = 7 },
            Wallet = new()
            {
                AccountEmailAgeDays = 720,
                AccountIdentifier = "0E51EC2F85C4ABF0",
                AccountScore = 5,
                DeviceScore = 5,
                EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
            },
        };

        string expectedID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        DigitalWalletTokenRequests::Cardholder expectedCardholder = new("Ian Crease");
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
        ApiEnum<string, DigitalWalletTokenRequests::Network> expectedNetwork =
            DigitalWalletTokenRequests::Network.Visa;
        ApiEnum<string, DigitalWalletTokenRequests::Outcome> expectedOutcome =
            DigitalWalletTokenRequests::Outcome.Provisioned;
        DigitalWalletTokenRequests::Provisioned expectedProvisioned = new(
            "digital_wallet_token_izi62go3h51p369jrie0"
        );
        string expectedTokenReferenceIdentifier = "DNITHE000000000000000000000";
        ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor> expectedTokenRequestor =
            DigitalWalletTokenRequests::TokenRequestor.ApplePay;
        DigitalWalletTokenRequests::TokenRequestorDetails expectedTokenRequestorDetails = new()
        {
            Identifier = "40010030273",
            Name = "Apple Inc.",
        };
        ApiEnum<string, DigitalWalletTokenRequests::Type> expectedType =
            DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest;
        DigitalWalletTokenRequests::Verification expectedVerification = new(
            new DigitalWalletTokenRequests::CardholderAddress()
            {
                ActualLine1 = "33 Liberty Street",
                ActualPostalCode = "94132",
                ProvidedLine1 = "33 Liberty Street",
                ProvidedPostalCode = "94132",
                Result = DigitalWalletTokenRequests::Result.Match,
            }
        );
        DigitalWalletTokenRequests::Visa expectedVisa = new()
        {
            NetworkRiskScore = 26,
            ProvisioningRiskScore = 7,
        };
        DigitalWalletTokenRequests::Wallet expectedWallet = new()
        {
            AccountEmailAgeDays = 720,
            AccountIdentifier = "0E51EC2F85C4ABF0",
            AccountScore = 5,
            DeviceScore = 5,
            EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedCardholder, model.Cardholder);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeclined, model.Declined);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedNetwork, model.Network);
        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedProvisioned, model.Provisioned);
        Assert.Equal(expectedTokenReferenceIdentifier, model.TokenReferenceIdentifier);
        Assert.Equal(expectedTokenRequestor, model.TokenRequestor);
        Assert.Equal(expectedTokenRequestorDetails, model.TokenRequestorDetails);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVerification, model.Verification);
        Assert.Equal(expectedVisa, model.Visa);
        Assert.Equal(expectedWallet, model.Wallet);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("Ian Crease"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Network = DigitalWalletTokenRequests::Network.Visa,
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            TokenRequestorDetails = new() { Identifier = "40010030273", Name = "Apple Inc." },
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
            Verification = new(
                new DigitalWalletTokenRequests::CardholderAddress()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94132",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result = DigitalWalletTokenRequests::Result.Match,
                }
            ),
            Visa = new() { NetworkRiskScore = 26, ProvisioningRiskScore = 7 },
            Wallet = new()
            {
                AccountEmailAgeDays = 720,
                AccountIdentifier = "0E51EC2F85C4ABF0",
                AccountScore = 5,
                DeviceScore = 5,
                EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
            },
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
            Cardholder = new("Ian Crease"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Network = DigitalWalletTokenRequests::Network.Visa,
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            TokenRequestorDetails = new() { Identifier = "40010030273", Name = "Apple Inc." },
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
            Verification = new(
                new DigitalWalletTokenRequests::CardholderAddress()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94132",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result = DigitalWalletTokenRequests::Result.Match,
                }
            ),
            Visa = new() { NetworkRiskScore = 26, ProvisioningRiskScore = 7 },
            Wallet = new()
            {
                AccountEmailAgeDays = 720,
                AccountIdentifier = "0E51EC2F85C4ABF0",
                AccountScore = 5,
                DeviceScore = 5,
                EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
            },
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
        DigitalWalletTokenRequests::Cardholder expectedCardholder = new("Ian Crease");
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
        ApiEnum<string, DigitalWalletTokenRequests::Network> expectedNetwork =
            DigitalWalletTokenRequests::Network.Visa;
        ApiEnum<string, DigitalWalletTokenRequests::Outcome> expectedOutcome =
            DigitalWalletTokenRequests::Outcome.Provisioned;
        DigitalWalletTokenRequests::Provisioned expectedProvisioned = new(
            "digital_wallet_token_izi62go3h51p369jrie0"
        );
        string expectedTokenReferenceIdentifier = "DNITHE000000000000000000000";
        ApiEnum<string, DigitalWalletTokenRequests::TokenRequestor> expectedTokenRequestor =
            DigitalWalletTokenRequests::TokenRequestor.ApplePay;
        DigitalWalletTokenRequests::TokenRequestorDetails expectedTokenRequestorDetails = new()
        {
            Identifier = "40010030273",
            Name = "Apple Inc.",
        };
        ApiEnum<string, DigitalWalletTokenRequests::Type> expectedType =
            DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest;
        DigitalWalletTokenRequests::Verification expectedVerification = new(
            new DigitalWalletTokenRequests::CardholderAddress()
            {
                ActualLine1 = "33 Liberty Street",
                ActualPostalCode = "94132",
                ProvidedLine1 = "33 Liberty Street",
                ProvidedPostalCode = "94132",
                Result = DigitalWalletTokenRequests::Result.Match,
            }
        );
        DigitalWalletTokenRequests::Visa expectedVisa = new()
        {
            NetworkRiskScore = 26,
            ProvisioningRiskScore = 7,
        };
        DigitalWalletTokenRequests::Wallet expectedWallet = new()
        {
            AccountEmailAgeDays = 720,
            AccountIdentifier = "0E51EC2F85C4ABF0",
            AccountScore = 5,
            DeviceScore = 5,
            EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedCardholder, deserialized.Cardholder);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeclined, deserialized.Declined);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedNetwork, deserialized.Network);
        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedProvisioned, deserialized.Provisioned);
        Assert.Equal(expectedTokenReferenceIdentifier, deserialized.TokenReferenceIdentifier);
        Assert.Equal(expectedTokenRequestor, deserialized.TokenRequestor);
        Assert.Equal(expectedTokenRequestorDetails, deserialized.TokenRequestorDetails);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVerification, deserialized.Verification);
        Assert.Equal(expectedVisa, deserialized.Visa);
        Assert.Equal(expectedWallet, deserialized.Wallet);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequest
        {
            ID = "digital_wallet_token_request_dlsq0yabf7ev4xvke6ek",
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new("Ian Crease"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Network = DigitalWalletTokenRequests::Network.Visa,
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            TokenRequestorDetails = new() { Identifier = "40010030273", Name = "Apple Inc." },
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
            Verification = new(
                new DigitalWalletTokenRequests::CardholderAddress()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94132",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result = DigitalWalletTokenRequests::Result.Match,
                }
            ),
            Visa = new() { NetworkRiskScore = 26, ProvisioningRiskScore = 7 },
            Wallet = new()
            {
                AccountEmailAgeDays = 720,
                AccountIdentifier = "0E51EC2F85C4ABF0",
                AccountScore = 5,
                DeviceScore = 5,
                EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
            },
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
            Cardholder = new("Ian Crease"),
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Declined = new(DigitalWalletTokenRequests::Reason.CardNotActive),
            Device = new()
            {
                DeviceType = DigitalWalletTokenRequests::DeviceType.MobilePhone,
                Identifier = "04393EADF4149002225811273840459271E36516DA4875FF",
                IPAddress = "1.2.3.4",
                Name = "My Work Phone",
            },
            Network = DigitalWalletTokenRequests::Network.Visa,
            Outcome = DigitalWalletTokenRequests::Outcome.Provisioned,
            Provisioned = new("digital_wallet_token_izi62go3h51p369jrie0"),
            TokenReferenceIdentifier = "DNITHE000000000000000000000",
            TokenRequestor = DigitalWalletTokenRequests::TokenRequestor.ApplePay,
            TokenRequestorDetails = new() { Identifier = "40010030273", Name = "Apple Inc." },
            Type = DigitalWalletTokenRequests::Type.DigitalWalletTokenRequest,
            Verification = new(
                new DigitalWalletTokenRequests::CardholderAddress()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94132",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result = DigitalWalletTokenRequests::Result.Match,
                }
            ),
            Visa = new() { NetworkRiskScore = 26, ProvisioningRiskScore = 7 },
            Wallet = new()
            {
                AccountEmailAgeDays = 720,
                AccountIdentifier = "0E51EC2F85C4ABF0",
                AccountScore = 5,
                DeviceScore = 5,
                EmailHash = "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
            },
        };

        DigitalWalletTokenRequests::DigitalWalletTokenRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Cardholder { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Cardholder { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Cardholder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Cardholder { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Cardholder>(
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
        var model = new DigitalWalletTokenRequests::Cardholder { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Cardholder { Name = "name" };

        DigitalWalletTokenRequests::Cardholder copied = new(model);

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
    [InlineData(DigitalWalletTokenRequests::Reason.CardExpirationMismatch)]
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
    [InlineData(DigitalWalletTokenRequests::Reason.CardExpirationMismatch)]
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

public class NetworkTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::Network.Visa)]
    public void Validation_Works(DigitalWalletTokenRequests::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Network> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Network>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::Network.Visa)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Network> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Network>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Network>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Network>
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

public class TokenRequestorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::TokenRequestorDetails
        {
            Identifier = "identifier",
            Name = "name",
        };

        string expectedIdentifier = "identifier";
        string expectedName = "name";

        Assert.Equal(expectedIdentifier, model.Identifier);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::TokenRequestorDetails
        {
            Identifier = "identifier",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::TokenRequestorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::TokenRequestorDetails
        {
            Identifier = "identifier",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::TokenRequestorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "identifier";
        string expectedName = "name";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::TokenRequestorDetails
        {
            Identifier = "identifier",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::TokenRequestorDetails
        {
            Identifier = "identifier",
            Name = "name",
        };

        DigitalWalletTokenRequests::TokenRequestorDetails copied = new(model);

        Assert.Equal(model, copied);
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

public class VerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Verification
        {
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DigitalWalletTokenRequests::Result.NotChecked,
            },
        };

        DigitalWalletTokenRequests::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        Assert.Equal(expectedCardholderAddress, model.CardholderAddress);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Verification
        {
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DigitalWalletTokenRequests::Result.NotChecked,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Verification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Verification
        {
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DigitalWalletTokenRequests::Result.NotChecked,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Verification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DigitalWalletTokenRequests::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        Assert.Equal(expectedCardholderAddress, deserialized.CardholderAddress);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::Verification
        {
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DigitalWalletTokenRequests::Result.NotChecked,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Verification
        {
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = DigitalWalletTokenRequests::Result.NotChecked,
            },
        };

        DigitalWalletTokenRequests::Verification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, DigitalWalletTokenRequests::Result> expectedResult =
            DigitalWalletTokenRequests::Result.NotChecked;

        Assert.Equal(expectedActualLine1, model.ActualLine1);
        Assert.Equal(expectedActualPostalCode, model.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, model.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, model.ProvidedPostalCode);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::CardholderAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::CardholderAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, DigitalWalletTokenRequests::Result> expectedResult =
            DigitalWalletTokenRequests::Result.NotChecked;

        Assert.Equal(expectedActualLine1, deserialized.ActualLine1);
        Assert.Equal(expectedActualPostalCode, deserialized.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, deserialized.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, deserialized.ProvidedPostalCode);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = DigitalWalletTokenRequests::Result.NotChecked,
        };

        DigitalWalletTokenRequests::CardholderAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Theory]
    [InlineData(DigitalWalletTokenRequests::Result.NotChecked)]
    [InlineData(DigitalWalletTokenRequests::Result.PostalCodeMatchAddressNoMatch)]
    [InlineData(DigitalWalletTokenRequests::Result.PostalCodeNoMatchAddressMatch)]
    [InlineData(DigitalWalletTokenRequests::Result.Match)]
    [InlineData(DigitalWalletTokenRequests::Result.NoMatch)]
    [InlineData(DigitalWalletTokenRequests::Result.PostalCodeMatchAddressNotChecked)]
    public void Validation_Works(DigitalWalletTokenRequests::Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokenRequests::Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalWalletTokenRequests::Result.NotChecked)]
    [InlineData(DigitalWalletTokenRequests::Result.PostalCodeMatchAddressNoMatch)]
    [InlineData(DigitalWalletTokenRequests::Result.PostalCodeNoMatchAddressMatch)]
    [InlineData(DigitalWalletTokenRequests::Result.Match)]
    [InlineData(DigitalWalletTokenRequests::Result.NoMatch)]
    [InlineData(DigitalWalletTokenRequests::Result.PostalCodeMatchAddressNotChecked)]
    public void SerializationRoundtrip_Works(DigitalWalletTokenRequests::Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalWalletTokenRequests::Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalWalletTokenRequests::Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalWalletTokenRequests::Result>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Visa
        {
            NetworkRiskScore = 0,
            ProvisioningRiskScore = 0,
        };

        long expectedNetworkRiskScore = 0;
        long expectedProvisioningRiskScore = 0;

        Assert.Equal(expectedNetworkRiskScore, model.NetworkRiskScore);
        Assert.Equal(expectedProvisioningRiskScore, model.ProvisioningRiskScore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Visa
        {
            NetworkRiskScore = 0,
            ProvisioningRiskScore = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Visa>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Visa
        {
            NetworkRiskScore = 0,
            ProvisioningRiskScore = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Visa>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedNetworkRiskScore = 0;
        long expectedProvisioningRiskScore = 0;

        Assert.Equal(expectedNetworkRiskScore, deserialized.NetworkRiskScore);
        Assert.Equal(expectedProvisioningRiskScore, deserialized.ProvisioningRiskScore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::Visa
        {
            NetworkRiskScore = 0,
            ProvisioningRiskScore = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Visa
        {
            NetworkRiskScore = 0,
            ProvisioningRiskScore = 0,
        };

        DigitalWalletTokenRequests::Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WalletTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Wallet
        {
            AccountEmailAgeDays = 0,
            AccountIdentifier = "account_identifier",
            AccountScore = 0,
            DeviceScore = 0,
            EmailHash = "email_hash",
        };

        long expectedAccountEmailAgeDays = 0;
        string expectedAccountIdentifier = "account_identifier";
        long expectedAccountScore = 0;
        long expectedDeviceScore = 0;
        string expectedEmailHash = "email_hash";

        Assert.Equal(expectedAccountEmailAgeDays, model.AccountEmailAgeDays);
        Assert.Equal(expectedAccountIdentifier, model.AccountIdentifier);
        Assert.Equal(expectedAccountScore, model.AccountScore);
        Assert.Equal(expectedDeviceScore, model.DeviceScore);
        Assert.Equal(expectedEmailHash, model.EmailHash);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::Wallet
        {
            AccountEmailAgeDays = 0,
            AccountIdentifier = "account_identifier",
            AccountScore = 0,
            DeviceScore = 0,
            EmailHash = "email_hash",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Wallet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::Wallet
        {
            AccountEmailAgeDays = 0,
            AccountIdentifier = "account_identifier",
            AccountScore = 0,
            DeviceScore = 0,
            EmailHash = "email_hash",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequests::Wallet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAccountEmailAgeDays = 0;
        string expectedAccountIdentifier = "account_identifier";
        long expectedAccountScore = 0;
        long expectedDeviceScore = 0;
        string expectedEmailHash = "email_hash";

        Assert.Equal(expectedAccountEmailAgeDays, deserialized.AccountEmailAgeDays);
        Assert.Equal(expectedAccountIdentifier, deserialized.AccountIdentifier);
        Assert.Equal(expectedAccountScore, deserialized.AccountScore);
        Assert.Equal(expectedDeviceScore, deserialized.DeviceScore);
        Assert.Equal(expectedEmailHash, deserialized.EmailHash);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequests::Wallet
        {
            AccountEmailAgeDays = 0,
            AccountIdentifier = "account_identifier",
            AccountScore = 0,
            DeviceScore = 0,
            EmailHash = "email_hash",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::Wallet
        {
            AccountEmailAgeDays = 0,
            AccountIdentifier = "account_identifier",
            AccountScore = 0,
            DeviceScore = 0,
            EmailHash = "email_hash",
        };

        DigitalWalletTokenRequests::Wallet copied = new(model);

        Assert.Equal(model, copied);
    }
}
