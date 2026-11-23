using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using DigitalWalletTokenRequests = Increase.Api.Models.DigitalWalletTokenRequests;

namespace Increase.Api.Tests.Models.DigitalWalletTokenRequests;

public class DigitalWalletTokenRequestListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse
        {
            Data =
            [
                new()
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
                    TokenRequestorDetails = new()
                    {
                        Identifier = "40010030273",
                        Name = "Apple Inc.",
                    },
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
                        EmailHash =
                            "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        List<DigitalWalletTokenRequests::DigitalWalletTokenRequest> expectedData =
        [
            new()
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
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse
        {
            Data =
            [
                new()
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
                    TokenRequestorDetails = new()
                    {
                        Identifier = "40010030273",
                        Name = "Apple Inc.",
                    },
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
                        EmailHash =
                            "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse
        {
            Data =
            [
                new()
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
                    TokenRequestorDetails = new()
                    {
                        Identifier = "40010030273",
                        Name = "Apple Inc.",
                    },
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
                        EmailHash =
                            "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<DigitalWalletTokenRequests::DigitalWalletTokenRequest> expectedData =
        [
            new()
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
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse
        {
            Data =
            [
                new()
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
                    TokenRequestorDetails = new()
                    {
                        Identifier = "40010030273",
                        Name = "Apple Inc.",
                    },
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
                        EmailHash =
                            "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse
        {
            Data =
            [
                new()
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
                    TokenRequestorDetails = new()
                    {
                        Identifier = "40010030273",
                        Name = "Apple Inc.",
                    },
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
                        EmailHash =
                            "0E51EC2F85C4ABF067DFE4B0D30A5F60899C6ACEFD700D3171E7330D542E0834",
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
