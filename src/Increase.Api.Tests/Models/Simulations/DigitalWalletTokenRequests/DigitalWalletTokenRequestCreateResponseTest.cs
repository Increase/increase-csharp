using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.DigitalWalletTokenRequests;

namespace Increase.Api.Tests.Models.Simulations.DigitalWalletTokenRequests;

public class DigitalWalletTokenRequestCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequestCreateResponse
        {
            DeclineReason = null,
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Type = Type.InboundDigitalWalletTokenRequestSimulationResult,
        };

        string expectedDigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0";
        ApiEnum<string, Type> expectedType = Type.InboundDigitalWalletTokenRequestSimulationResult;

        Assert.Null(model.DeclineReason);
        Assert.Equal(expectedDigitalWalletTokenID, model.DigitalWalletTokenID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalWalletTokenRequestCreateResponse
        {
            DeclineReason = null,
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Type = Type.InboundDigitalWalletTokenRequestSimulationResult,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequestCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWalletTokenRequestCreateResponse
        {
            DeclineReason = null,
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Type = Type.InboundDigitalWalletTokenRequestSimulationResult,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWalletTokenRequestCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0";
        ApiEnum<string, Type> expectedType = Type.InboundDigitalWalletTokenRequestSimulationResult;

        Assert.Null(deserialized.DeclineReason);
        Assert.Equal(expectedDigitalWalletTokenID, deserialized.DigitalWalletTokenID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalWalletTokenRequestCreateResponse
        {
            DeclineReason = null,
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Type = Type.InboundDigitalWalletTokenRequestSimulationResult,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalWalletTokenRequestCreateResponse
        {
            DeclineReason = null,
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Type = Type.InboundDigitalWalletTokenRequestSimulationResult,
        };

        DigitalWalletTokenRequestCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(DeclineReason.CardNotActive)]
    [InlineData(DeclineReason.NoVerificationMethod)]
    [InlineData(DeclineReason.WebhookTimedOut)]
    [InlineData(DeclineReason.WebhookDeclined)]
    public void Validation_Works(DeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeclineReason.CardNotActive)]
    [InlineData(DeclineReason.NoVerificationMethod)]
    [InlineData(DeclineReason.WebhookTimedOut)]
    [InlineData(DeclineReason.WebhookDeclined)]
    public void SerializationRoundtrip_Works(DeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeclineReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.InboundDigitalWalletTokenRequestSimulationResult)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.InboundDigitalWalletTokenRequestSimulationResult)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
