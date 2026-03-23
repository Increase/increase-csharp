using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CardTokens = Increase.Api.Models.CardTokens;

namespace Increase.Api.Tests.Models.CardTokens;

public class CardTokenListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardTokens::CardTokenListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ExpirationDate = "2020-01-31",
                    Last4 = "1234",
                    Length = 16,
                    Prefix = "46637100",
                    Type = CardTokens::Type.CardToken,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CardTokens::CardToken> expectedData =
        [
            new()
            {
                ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ExpirationDate = "2020-01-31",
                Last4 = "1234",
                Length = 16,
                Prefix = "46637100",
                Type = CardTokens::Type.CardToken,
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
        var model = new CardTokens::CardTokenListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ExpirationDate = "2020-01-31",
                    Last4 = "1234",
                    Length = 16,
                    Prefix = "46637100",
                    Type = CardTokens::Type.CardToken,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardTokens::CardTokenListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardTokens::CardTokenListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ExpirationDate = "2020-01-31",
                    Last4 = "1234",
                    Length = 16,
                    Prefix = "46637100",
                    Type = CardTokens::Type.CardToken,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardTokens::CardTokenListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CardTokens::CardToken> expectedData =
        [
            new()
            {
                ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ExpirationDate = "2020-01-31",
                Last4 = "1234",
                Length = 16,
                Prefix = "46637100",
                Type = CardTokens::Type.CardToken,
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
        var model = new CardTokens::CardTokenListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ExpirationDate = "2020-01-31",
                    Last4 = "1234",
                    Length = 16,
                    Prefix = "46637100",
                    Type = CardTokens::Type.CardToken,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardTokens::CardTokenListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ExpirationDate = "2020-01-31",
                    Last4 = "1234",
                    Length = 16,
                    Prefix = "46637100",
                    Type = CardTokens::Type.CardToken,
                },
            ],
            NextCursor = "v57w5d",
        };

        CardTokens::CardTokenListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
