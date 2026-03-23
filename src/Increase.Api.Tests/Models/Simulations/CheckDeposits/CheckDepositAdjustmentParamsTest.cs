using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.CheckDeposits;

namespace Increase.Api.Tests.Models.Simulations.CheckDeposits;

public class CheckDepositAdjustmentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckDepositAdjustmentParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Amount = -1000000000,
            Reason = Reason.LateReturn,
        };

        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        long expectedAmount = -1000000000;
        ApiEnum<string, Reason> expectedReason = Reason.LateReturn;

        Assert.Equal(expectedCheckDepositID, parameters.CheckDepositID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckDepositAdjustmentParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckDepositAdjustmentParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",

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
        CheckDepositAdjustmentParams parameters = new()
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/check_deposits/check_deposit_f06n9gpg7sxn8t19lfc1/adjustment"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckDepositAdjustmentParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Amount = -1000000000,
            Reason = Reason.LateReturn,
        };

        CheckDepositAdjustmentParams copied = new(parameters);

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
