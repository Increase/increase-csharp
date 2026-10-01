using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DigitalWalletTokens;

namespace Increase.Api.Tests.Models.DigitalWalletTokens;

public class DigitalWalletTokenTransitionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalWalletTokenTransitionParams
        {
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Status = Status.Suspended,
        };

        string expectedDigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0";
        ApiEnum<string, Status> expectedStatus = Status.Suspended;

        Assert.Equal(expectedDigitalWalletTokenID, parameters.DigitalWalletTokenID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void Url_Works()
    {
        DigitalWalletTokenTransitionParams parameters = new()
        {
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Status = Status.Suspended,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/digital_wallet_tokens/digital_wallet_token_izi62go3h51p369jrie0/transition"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalWalletTokenTransitionParams
        {
            DigitalWalletTokenID = "digital_wallet_token_izi62go3h51p369jrie0",
            Status = Status.Suspended,
        };

        DigitalWalletTokenTransitionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Suspended)]
    [InlineData(Status.Deactivated)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Suspended)]
    [InlineData(Status.Deactivated)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
