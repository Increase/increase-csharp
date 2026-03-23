using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Tests.Models.Simulations.AchTransfers;

public class AchTransferSettleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferSettleParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            InboundFundsHoldBehavior = InboundFundsHoldBehavior.ReleaseImmediately,
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";
        ApiEnum<string, InboundFundsHoldBehavior> expectedInboundFundsHoldBehavior =
            InboundFundsHoldBehavior.ReleaseImmediately;

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
        Assert.Equal(expectedInboundFundsHoldBehavior, parameters.InboundFundsHoldBehavior);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AchTransferSettleParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        Assert.Null(parameters.InboundFundsHoldBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_funds_hold_behavior"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AchTransferSettleParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",

            // Null should be interpreted as omitted for these properties
            InboundFundsHoldBehavior = null,
        };

        Assert.Null(parameters.InboundFundsHoldBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_funds_hold_behavior"));
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferSettleParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q/settle"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferSettleParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            InboundFundsHoldBehavior = InboundFundsHoldBehavior.ReleaseImmediately,
        };

        AchTransferSettleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InboundFundsHoldBehaviorTest : TestBase
{
    [Theory]
    [InlineData(InboundFundsHoldBehavior.ReleaseImmediately)]
    [InlineData(InboundFundsHoldBehavior.ReleaseOnDefaultSchedule)]
    public void Validation_Works(InboundFundsHoldBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFundsHoldBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFundsHoldBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundFundsHoldBehavior.ReleaseImmediately)]
    [InlineData(InboundFundsHoldBehavior.ReleaseOnDefaultSchedule)]
    public void SerializationRoundtrip_Works(InboundFundsHoldBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFundsHoldBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundFundsHoldBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFundsHoldBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundFundsHoldBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
