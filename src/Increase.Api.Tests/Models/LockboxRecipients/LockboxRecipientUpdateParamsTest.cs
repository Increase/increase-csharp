using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Tests.Models.LockboxRecipients;

public class LockboxRecipientUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxRecipientUpdateParams
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            Description = "x",
            RecipientName = "x",
            Status = Status.Active,
        };

        string expectedLockboxRecipientID = "lockbox_3xt21ok13q19advds4t5";
        string expectedDescription = "x";
        string expectedRecipientName = "x";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedLockboxRecipientID, parameters.LockboxRecipientID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedRecipientName, parameters.RecipientName);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LockboxRecipientUpdateParams
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LockboxRecipientUpdateParams
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",

            // Null should be interpreted as omitted for these properties
            Description = null,
            RecipientName = null,
            Status = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        LockboxRecipientUpdateParams parameters = new()
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/lockbox_recipients/lockbox_3xt21ok13q19advds4t5"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxRecipientUpdateParams
        {
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            Description = "x",
            RecipientName = "x",
            Status = Status.Active,
        };

        LockboxRecipientUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    [InlineData(Status.Canceled)]
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
    [InlineData(Status.Disabled)]
    [InlineData(Status.Canceled)]
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
