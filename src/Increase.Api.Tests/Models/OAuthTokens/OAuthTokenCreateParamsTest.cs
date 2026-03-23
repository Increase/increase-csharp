using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.OAuthTokens;

namespace Increase.Api.Tests.Models.OAuthTokens;

public class OAuthTokenCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OAuthTokenCreateParams
        {
            GrantType = GrantType.AuthorizationCode,
            ClientID = "12345",
            ClientSecret = "supersecret",
            Code = "123",
            ProductionToken = "x",
        };

        ApiEnum<string, GrantType> expectedGrantType = GrantType.AuthorizationCode;
        string expectedClientID = "12345";
        string expectedClientSecret = "supersecret";
        string expectedCode = "123";
        string expectedProductionToken = "x";

        Assert.Equal(expectedGrantType, parameters.GrantType);
        Assert.Equal(expectedClientID, parameters.ClientID);
        Assert.Equal(expectedClientSecret, parameters.ClientSecret);
        Assert.Equal(expectedCode, parameters.Code);
        Assert.Equal(expectedProductionToken, parameters.ProductionToken);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new OAuthTokenCreateParams { GrantType = GrantType.AuthorizationCode };

        Assert.Null(parameters.ClientID);
        Assert.False(parameters.RawBodyData.ContainsKey("client_id"));
        Assert.Null(parameters.ClientSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("client_secret"));
        Assert.Null(parameters.Code);
        Assert.False(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.ProductionToken);
        Assert.False(parameters.RawBodyData.ContainsKey("production_token"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new OAuthTokenCreateParams
        {
            GrantType = GrantType.AuthorizationCode,

            // Null should be interpreted as omitted for these properties
            ClientID = null,
            ClientSecret = null,
            Code = null,
            ProductionToken = null,
        };

        Assert.Null(parameters.ClientID);
        Assert.False(parameters.RawBodyData.ContainsKey("client_id"));
        Assert.Null(parameters.ClientSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("client_secret"));
        Assert.Null(parameters.Code);
        Assert.False(parameters.RawBodyData.ContainsKey("code"));
        Assert.Null(parameters.ProductionToken);
        Assert.False(parameters.RawBodyData.ContainsKey("production_token"));
    }

    [Fact]
    public void Url_Works()
    {
        OAuthTokenCreateParams parameters = new() { GrantType = GrantType.AuthorizationCode };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/oauth/tokens"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OAuthTokenCreateParams
        {
            GrantType = GrantType.AuthorizationCode,
            ClientID = "12345",
            ClientSecret = "supersecret",
            Code = "123",
            ProductionToken = "x",
        };

        OAuthTokenCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GrantTypeTest : TestBase
{
    [Theory]
    [InlineData(GrantType.AuthorizationCode)]
    [InlineData(GrantType.ProductionToken)]
    public void Validation_Works(GrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantType.AuthorizationCode)]
    [InlineData(GrantType.ProductionToken)]
    public void SerializationRoundtrip_Works(GrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
