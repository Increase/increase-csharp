using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.Simulations.InboundCheckDeposits;

public class InboundCheckDepositAdjustmentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundCheckDepositAdjustmentParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Amount = 1000,
            Reason = Reason.LateReturn,
        };

        string expectedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        long expectedAmount = 1000;
        ApiEnum<string, Reason> expectedReason = Reason.LateReturn;

        Assert.Equal(expectedInboundCheckDepositID, parameters.InboundCheckDepositID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundCheckDepositAdjustmentParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundCheckDepositAdjustmentParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            Reason = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundCheckDepositAdjustmentParams parameters = new()
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/inbound_check_deposits/inbound_check_deposit_zoshvqybq0cjjm31mra/adjustment"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundCheckDepositAdjustmentParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Amount = 1000,
            Reason = Reason.LateReturn,
        };

        InboundCheckDepositAdjustmentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.LateReturn)]
    [InlineData(Reason.WrongPayeeCredit)]
    [InlineData(Reason.AdjustedAmount)]
    [InlineData(Reason.NonConformingItem)]
    [InlineData(Reason.Paid)]
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
    [InlineData(Reason.LateReturn)]
    [InlineData(Reason.WrongPayeeCredit)]
    [InlineData(Reason.AdjustedAmount)]
    [InlineData(Reason.NonConformingItem)]
    [InlineData(Reason.Paid)]
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
