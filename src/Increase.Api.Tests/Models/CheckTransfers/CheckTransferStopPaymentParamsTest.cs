using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Tests.Models.CheckTransfers;

public class CheckTransferStopPaymentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckTransferStopPaymentParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Reason = Reason.MailDeliveryFailed,
        };

        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        ApiEnum<string, Reason> expectedReason = Reason.MailDeliveryFailed;

        Assert.Equal(expectedCheckTransferID, parameters.CheckTransferID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckTransferStopPaymentParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckTransferStopPaymentParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        CheckTransferStopPaymentParams parameters = new()
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/check_transfers/check_transfer_30b43acfu9vw8fyc4f5/stop_payment"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckTransferStopPaymentParams
        {
            CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Reason = Reason.MailDeliveryFailed,
        };

        CheckTransferStopPaymentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.MailDeliveryFailed)]
    [InlineData(Reason.NotAuthorized)]
    [InlineData(Reason.ValidUntilDatePassed)]
    [InlineData(Reason.Unknown)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.MailDeliveryFailed)]
    [InlineData(Reason.NotAuthorized)]
    [InlineData(Reason.ValidUntilDatePassed)]
    [InlineData(Reason.Unknown)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
