using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDetails
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            ExpirationMonth = 7,
            ExpirationYear = 2025,
            Pin = "1234",
            PrimaryAccountNumber = "4242424242424242",
            Type = CardDetailsType.CardDetails,
            VerificationCode = "123",
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        long expectedExpirationMonth = 7;
        long expectedExpirationYear = 2025;
        string expectedPin = "1234";
        string expectedPrimaryAccountNumber = "4242424242424242";
        ApiEnum<string, CardDetailsType> expectedType = CardDetailsType.CardDetails;
        string expectedVerificationCode = "123";

        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedExpirationMonth, model.ExpirationMonth);
        Assert.Equal(expectedExpirationYear, model.ExpirationYear);
        Assert.Equal(expectedPin, model.Pin);
        Assert.Equal(expectedPrimaryAccountNumber, model.PrimaryAccountNumber);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVerificationCode, model.VerificationCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDetails
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            ExpirationMonth = 7,
            ExpirationYear = 2025,
            Pin = "1234",
            PrimaryAccountNumber = "4242424242424242",
            Type = CardDetailsType.CardDetails,
            VerificationCode = "123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDetails
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            ExpirationMonth = 7,
            ExpirationYear = 2025,
            Pin = "1234",
            PrimaryAccountNumber = "4242424242424242",
            Type = CardDetailsType.CardDetails,
            VerificationCode = "123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        long expectedExpirationMonth = 7;
        long expectedExpirationYear = 2025;
        string expectedPin = "1234";
        string expectedPrimaryAccountNumber = "4242424242424242";
        ApiEnum<string, CardDetailsType> expectedType = CardDetailsType.CardDetails;
        string expectedVerificationCode = "123";

        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedExpirationMonth, deserialized.ExpirationMonth);
        Assert.Equal(expectedExpirationYear, deserialized.ExpirationYear);
        Assert.Equal(expectedPin, deserialized.Pin);
        Assert.Equal(expectedPrimaryAccountNumber, deserialized.PrimaryAccountNumber);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVerificationCode, deserialized.VerificationCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDetails
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            ExpirationMonth = 7,
            ExpirationYear = 2025,
            Pin = "1234",
            PrimaryAccountNumber = "4242424242424242",
            Type = CardDetailsType.CardDetails,
            VerificationCode = "123",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDetails
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            ExpirationMonth = 7,
            ExpirationYear = 2025,
            Pin = "1234",
            PrimaryAccountNumber = "4242424242424242",
            Type = CardDetailsType.CardDetails,
            VerificationCode = "123",
        };

        CardDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardDetailsTypeTest : TestBase
{
    [Theory]
    [InlineData(CardDetailsType.CardDetails)]
    public void Validation_Works(CardDetailsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDetailsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardDetailsType.CardDetails)]
    public void SerializationRoundtrip_Works(CardDetailsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDetailsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDetailsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
