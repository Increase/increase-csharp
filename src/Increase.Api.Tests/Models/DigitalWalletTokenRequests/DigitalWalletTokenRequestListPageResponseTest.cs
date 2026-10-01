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
                },
            ],
            NextCursor = "v57w5d",
        };

        DigitalWalletTokenRequests::DigitalWalletTokenRequestListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
