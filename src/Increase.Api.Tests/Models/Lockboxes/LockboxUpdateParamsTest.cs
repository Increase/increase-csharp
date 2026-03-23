using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Lockboxes;

namespace Increase.Api.Tests.Models.Lockboxes;

public class LockboxUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LockboxUpdateParams
        {
            LockboxID = "lockbox_3xt21ok13q19advds4t5",
            CheckDepositBehavior = CheckDepositBehavior.Disabled,
            Description = "x",
            RecipientName = "x",
        };

        string expectedLockboxID = "lockbox_3xt21ok13q19advds4t5";
        ApiEnum<string, CheckDepositBehavior> expectedCheckDepositBehavior =
            CheckDepositBehavior.Disabled;
        string expectedDescription = "x";
        string expectedRecipientName = "x";

        Assert.Equal(expectedLockboxID, parameters.LockboxID);
        Assert.Equal(expectedCheckDepositBehavior, parameters.CheckDepositBehavior);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedRecipientName, parameters.RecipientName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LockboxUpdateParams { LockboxID = "lockbox_3xt21ok13q19advds4t5" };

        Assert.Null(parameters.CheckDepositBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("check_deposit_behavior"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LockboxUpdateParams
        {
            LockboxID = "lockbox_3xt21ok13q19advds4t5",

            // Null should be interpreted as omitted for these properties
            CheckDepositBehavior = null,
            Description = null,
            RecipientName = null,
        };

        Assert.Null(parameters.CheckDepositBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("check_deposit_behavior"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.RecipientName);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void Url_Works()
    {
        LockboxUpdateParams parameters = new() { LockboxID = "lockbox_3xt21ok13q19advds4t5" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/lockboxes/lockbox_3xt21ok13q19advds4t5"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LockboxUpdateParams
        {
            LockboxID = "lockbox_3xt21ok13q19advds4t5",
            CheckDepositBehavior = CheckDepositBehavior.Disabled,
            Description = "x",
            RecipientName = "x",
        };

        LockboxUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CheckDepositBehaviorTest : TestBase
{
    [Theory]
    [InlineData(CheckDepositBehavior.Enabled)]
    [InlineData(CheckDepositBehavior.Disabled)]
    [InlineData(CheckDepositBehavior.PendForProcessing)]
    public void Validation_Works(CheckDepositBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDepositBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDepositBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDepositBehavior.Enabled)]
    [InlineData(CheckDepositBehavior.Disabled)]
    [InlineData(CheckDepositBehavior.PendForProcessing)]
    public void SerializationRoundtrip_Works(CheckDepositBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDepositBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDepositBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDepositBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDepositBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
