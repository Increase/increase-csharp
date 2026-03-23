using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardIframeUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardIframeUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IframeUrl = "https://increase.com/card_details_iframe/index.html?token=0",
            Type = CardIframeUrlType.CardIframeUrl,
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedIframeUrl = "https://increase.com/card_details_iframe/index.html?token=0";
        ApiEnum<string, CardIframeUrlType> expectedType = CardIframeUrlType.CardIframeUrl;

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedIframeUrl, model.IframeUrl);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardIframeUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IframeUrl = "https://increase.com/card_details_iframe/index.html?token=0",
            Type = CardIframeUrlType.CardIframeUrl,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardIframeUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardIframeUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IframeUrl = "https://increase.com/card_details_iframe/index.html?token=0",
            Type = CardIframeUrlType.CardIframeUrl,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardIframeUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedIframeUrl = "https://increase.com/card_details_iframe/index.html?token=0";
        ApiEnum<string, CardIframeUrlType> expectedType = CardIframeUrlType.CardIframeUrl;

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedIframeUrl, deserialized.IframeUrl);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardIframeUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IframeUrl = "https://increase.com/card_details_iframe/index.html?token=0",
            Type = CardIframeUrlType.CardIframeUrl,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardIframeUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IframeUrl = "https://increase.com/card_details_iframe/index.html?token=0",
            Type = CardIframeUrlType.CardIframeUrl,
        };

        CardIframeUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardIframeUrlTypeTest : TestBase
{
    [Theory]
    [InlineData(CardIframeUrlType.CardIframeUrl)]
    public void Validation_Works(CardIframeUrlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardIframeUrlType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardIframeUrlType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardIframeUrlType.CardIframeUrl)]
    public void SerializationRoundtrip_Works(CardIframeUrlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardIframeUrlType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardIframeUrlType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardIframeUrlType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardIframeUrlType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
