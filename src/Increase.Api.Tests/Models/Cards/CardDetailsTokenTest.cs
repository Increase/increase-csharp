using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardDetailsTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDetailsToken
        {
            Token = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8",
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = CardDetailsTokenType.CardDetailsToken,
        };

        string expectedToken = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, CardDetailsTokenType> expectedType = CardDetailsTokenType.CardDetailsToken;

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDetailsToken
        {
            Token = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8",
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = CardDetailsTokenType.CardDetailsToken,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDetailsToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDetailsToken
        {
            Token = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8",
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = CardDetailsTokenType.CardDetailsToken,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDetailsToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, CardDetailsTokenType> expectedType = CardDetailsTokenType.CardDetailsToken;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDetailsToken
        {
            Token = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8",
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = CardDetailsTokenType.CardDetailsToken,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDetailsToken
        {
            Token = "0f3d2a1b4c5e6f708192a3b4c5d6e7f8",
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = CardDetailsTokenType.CardDetailsToken,
        };

        CardDetailsToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardDetailsTokenTypeTest : TestBase
{
    [Theory]
    [InlineData(CardDetailsTokenType.CardDetailsToken)]
    public void Validation_Works(CardDetailsTokenType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDetailsTokenType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsTokenType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardDetailsTokenType.CardDetailsToken)]
    public void SerializationRoundtrip_Works(CardDetailsTokenType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDetailsTokenType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsTokenType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsTokenType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsTokenType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
