using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using DigitalWalletTokens = Increase.Api.Models.DigitalWalletTokens;

namespace Increase.Api.Tests.Models.DigitalWalletTokens;

public class DigitalWalletTokenListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletTokenListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<DigitalWalletTokens::DigitalWalletToken> expectedData =
        [
            new()
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
        var model = new DigitalWalletTokens::DigitalWalletTokenListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokens::DigitalWalletTokenListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletTokenListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalWalletTokens::DigitalWalletTokenListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<DigitalWalletTokens::DigitalWalletToken> expectedData =
        [
            new()
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
        var model = new DigitalWalletTokens::DigitalWalletTokenListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokens::DigitalWalletTokenListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        DigitalWalletTokens::DigitalWalletTokenListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
