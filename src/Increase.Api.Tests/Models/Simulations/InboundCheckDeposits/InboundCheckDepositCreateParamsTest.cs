using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.Simulations.InboundCheckDeposits;

public class InboundCheckDepositCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundCheckDepositCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CheckNumber = "1234567890",
            PayeeNameAnalysis = PayeeNameAnalysis.NameMatches,
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 1000;
        string expectedCheckNumber = "1234567890";
        ApiEnum<string, PayeeNameAnalysis> expectedPayeeNameAnalysis =
            PayeeNameAnalysis.NameMatches;

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCheckNumber, parameters.CheckNumber);
        Assert.Equal(expectedPayeeNameAnalysis, parameters.PayeeNameAnalysis);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundCheckDepositCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CheckNumber = "1234567890",
        };

        Assert.Null(parameters.PayeeNameAnalysis);
        Assert.False(parameters.RawBodyData.ContainsKey("payee_name_analysis"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundCheckDepositCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CheckNumber = "1234567890",

            // Null should be interpreted as omitted for these properties
            PayeeNameAnalysis = null,
        };

        Assert.Null(parameters.PayeeNameAnalysis);
        Assert.False(parameters.RawBodyData.ContainsKey("payee_name_analysis"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundCheckDepositCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CheckNumber = "1234567890",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/inbound_check_deposits"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundCheckDepositCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CheckNumber = "1234567890",
            PayeeNameAnalysis = PayeeNameAnalysis.NameMatches,
        };

        InboundCheckDepositCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PayeeNameAnalysisTest : TestBase
{
    [Theory]
    [InlineData(PayeeNameAnalysis.NameMatches)]
    [InlineData(PayeeNameAnalysis.DoesNotMatch)]
    [InlineData(PayeeNameAnalysis.NotEvaluated)]
    public void Validation_Works(PayeeNameAnalysis rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PayeeNameAnalysis> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PayeeNameAnalysis>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PayeeNameAnalysis.NameMatches)]
    [InlineData(PayeeNameAnalysis.DoesNotMatch)]
    [InlineData(PayeeNameAnalysis.NotEvaluated)]
    public void SerializationRoundtrip_Works(PayeeNameAnalysis rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PayeeNameAnalysis> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PayeeNameAnalysis>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PayeeNameAnalysis>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PayeeNameAnalysis>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
