using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CardTokens = Increase.Api.Models.CardTokens;

namespace Increase.Api.Tests.Models.CardTokens;

public class CardTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardTokens::CardToken
        {
            ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpirationDate = "2020-01-31",
            Last4 = "1234",
            Length = 16,
            Prefix = "46637100",
            Type = CardTokens::Type.CardToken,
        };

        string expectedID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedExpirationDate = "2020-01-31";
        string expectedLast4 = "1234";
        long expectedLength = 16;
        string expectedPrefix = "46637100";
        ApiEnum<string, CardTokens::Type> expectedType = CardTokens::Type.CardToken;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpirationDate, model.ExpirationDate);
        Assert.Equal(expectedLast4, model.Last4);
        Assert.Equal(expectedLength, model.Length);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardTokens::CardToken
        {
            ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpirationDate = "2020-01-31",
            Last4 = "1234",
            Length = 16,
            Prefix = "46637100",
            Type = CardTokens::Type.CardToken,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardTokens::CardToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardTokens::CardToken
        {
            ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpirationDate = "2020-01-31",
            Last4 = "1234",
            Length = 16,
            Prefix = "46637100",
            Type = CardTokens::Type.CardToken,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardTokens::CardToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedExpirationDate = "2020-01-31";
        string expectedLast4 = "1234";
        long expectedLength = 16;
        string expectedPrefix = "46637100";
        ApiEnum<string, CardTokens::Type> expectedType = CardTokens::Type.CardToken;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpirationDate, deserialized.ExpirationDate);
        Assert.Equal(expectedLast4, deserialized.Last4);
        Assert.Equal(expectedLength, deserialized.Length);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardTokens::CardToken
        {
            ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpirationDate = "2020-01-31",
            Last4 = "1234",
            Length = 16,
            Prefix = "46637100",
            Type = CardTokens::Type.CardToken,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardTokens::CardToken
        {
            ID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpirationDate = "2020-01-31",
            Last4 = "1234",
            Length = 16,
            Prefix = "46637100",
            Type = CardTokens::Type.CardToken,
        };

        CardTokens::CardToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CardTokens::Type.CardToken)]
    public void Validation_Works(CardTokens::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardTokens::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardTokens::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardTokens::Type.CardToken)]
    public void SerializationRoundtrip_Works(CardTokens::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardTokens::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardTokens::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardTokens::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardTokens::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
