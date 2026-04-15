using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.Programs;

namespace Increase.Api.Tests.Models.Simulations.Programs;

public class ProgramCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProgramCreateParams
        {
            Name = "For Benefit Of",
            Bank = Bank.CoreBank,
            LendingMaximumExtendableCredit = 0,
            ReserveAccountID = "reserve_account_id",
        };

        string expectedName = "For Benefit Of";
        ApiEnum<string, Bank> expectedBank = Bank.CoreBank;
        long expectedLendingMaximumExtendableCredit = 0;
        string expectedReserveAccountID = "reserve_account_id";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBank, parameters.Bank);
        Assert.Equal(
            expectedLendingMaximumExtendableCredit,
            parameters.LendingMaximumExtendableCredit
        );
        Assert.Equal(expectedReserveAccountID, parameters.ReserveAccountID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProgramCreateParams { Name = "For Benefit Of" };

        Assert.Null(parameters.Bank);
        Assert.False(parameters.RawBodyData.ContainsKey("bank"));
        Assert.Null(parameters.LendingMaximumExtendableCredit);
        Assert.False(parameters.RawBodyData.ContainsKey("lending_maximum_extendable_credit"));
        Assert.Null(parameters.ReserveAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("reserve_account_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProgramCreateParams
        {
            Name = "For Benefit Of",

            // Null should be interpreted as omitted for these properties
            Bank = null,
            LendingMaximumExtendableCredit = null,
            ReserveAccountID = null,
        };

        Assert.Null(parameters.Bank);
        Assert.False(parameters.RawBodyData.ContainsKey("bank"));
        Assert.Null(parameters.LendingMaximumExtendableCredit);
        Assert.False(parameters.RawBodyData.ContainsKey("lending_maximum_extendable_credit"));
        Assert.Null(parameters.ReserveAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("reserve_account_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ProgramCreateParams parameters = new() { Name = "For Benefit Of" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/simulations/programs"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProgramCreateParams
        {
            Name = "For Benefit Of",
            Bank = Bank.CoreBank,
            LendingMaximumExtendableCredit = 0,
            ReserveAccountID = "reserve_account_id",
        };

        ProgramCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BankTest : TestBase
{
    [Theory]
    [InlineData(Bank.CoreBank)]
    [InlineData(Bank.FirstInternetBank)]
    [InlineData(Bank.GrasshopperBank)]
    [InlineData(Bank.TwinCityBank)]
    public void Validation_Works(Bank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Bank> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Bank>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Bank.CoreBank)]
    [InlineData(Bank.FirstInternetBank)]
    [InlineData(Bank.GrasshopperBank)]
    [InlineData(Bank.TwinCityBank)]
    public void SerializationRoundtrip_Works(Bank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Bank> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Bank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Bank>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Bank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
