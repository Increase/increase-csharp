using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.OAuthTokens;

namespace Increase.Api.Tests.Models.OAuthTokens;

public class OAuthTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OAuthToken
        {
            AccessToken = "12345",
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            TokenType = TokenType.Bearer,
            Type = Type.OAuthToken,
        };

        string expectedAccessToken = "12345";
        string expectedGroupID = "group_1g4mhziu6kvrs3vz35um";
        ApiEnum<string, TokenType> expectedTokenType = TokenType.Bearer;
        ApiEnum<string, Type> expectedType = Type.OAuthToken;

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedGroupID, model.GroupID);
        Assert.Equal(expectedTokenType, model.TokenType);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OAuthToken
        {
            AccessToken = "12345",
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            TokenType = TokenType.Bearer,
            Type = Type.OAuthToken,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OAuthToken
        {
            AccessToken = "12345",
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            TokenType = TokenType.Bearer,
            Type = Type.OAuthToken,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessToken = "12345";
        string expectedGroupID = "group_1g4mhziu6kvrs3vz35um";
        ApiEnum<string, TokenType> expectedTokenType = TokenType.Bearer;
        ApiEnum<string, Type> expectedType = Type.OAuthToken;

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedGroupID, deserialized.GroupID);
        Assert.Equal(expectedTokenType, deserialized.TokenType);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OAuthToken
        {
            AccessToken = "12345",
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            TokenType = TokenType.Bearer,
            Type = Type.OAuthToken,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OAuthToken
        {
            AccessToken = "12345",
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            TokenType = TokenType.Bearer,
            Type = Type.OAuthToken,
        };

        OAuthToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenTypeTest : TestBase
{
    [Theory]
    [InlineData(TokenType.Bearer)]
    public void Validation_Works(TokenType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TokenType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TokenType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TokenType.Bearer)]
    public void SerializationRoundtrip_Works(TokenType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TokenType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TokenType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TokenType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TokenType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.OAuthToken)]
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
    [InlineData(Type.OAuthToken)]
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
