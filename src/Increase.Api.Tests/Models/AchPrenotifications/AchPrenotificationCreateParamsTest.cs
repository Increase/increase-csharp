using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AchPrenotifications;

namespace Increase.Api.Tests.Models.AchPrenotifications;

public class AchPrenotificationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchPrenotificationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            RoutingNumber = "101050001",
            Addendum = "x",
            CompanyDescriptiveDate = "x",
            CompanyDiscretionaryData = "x",
            CompanyEntryDescription = "x",
            CompanyName = "x",
            CreditDebitIndicator = CreditDebitIndicator.Credit,
            EffectiveDate = "2019-12-27",
            IndividualID = "x",
            IndividualName = "x",
            StandardEntryClassCode = StandardEntryClassCode.CorporateCreditOrDebit,
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        string expectedRoutingNumber = "101050001";
        string expectedAddendum = "x";
        string expectedCompanyDescriptiveDate = "x";
        string expectedCompanyDiscretionaryData = "x";
        string expectedCompanyEntryDescription = "x";
        string expectedCompanyName = "x";
        ApiEnum<string, CreditDebitIndicator> expectedCreditDebitIndicator =
            CreditDebitIndicator.Credit;
        string expectedEffectiveDate = "2019-12-27";
        string expectedIndividualID = "x";
        string expectedIndividualName = "x";
        ApiEnum<string, StandardEntryClassCode> expectedStandardEntryClassCode =
            StandardEntryClassCode.CorporateCreditOrDebit;

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
        Assert.Equal(expectedAddendum, parameters.Addendum);
        Assert.Equal(expectedCompanyDescriptiveDate, parameters.CompanyDescriptiveDate);
        Assert.Equal(expectedCompanyDiscretionaryData, parameters.CompanyDiscretionaryData);
        Assert.Equal(expectedCompanyEntryDescription, parameters.CompanyEntryDescription);
        Assert.Equal(expectedCompanyName, parameters.CompanyName);
        Assert.Equal(expectedCreditDebitIndicator, parameters.CreditDebitIndicator);
        Assert.Equal(expectedEffectiveDate, parameters.EffectiveDate);
        Assert.Equal(expectedIndividualID, parameters.IndividualID);
        Assert.Equal(expectedIndividualName, parameters.IndividualName);
        Assert.Equal(expectedStandardEntryClassCode, parameters.StandardEntryClassCode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AchPrenotificationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            RoutingNumber = "101050001",
        };

        Assert.Null(parameters.Addendum);
        Assert.False(parameters.RawBodyData.ContainsKey("addendum"));
        Assert.Null(parameters.CompanyDescriptiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("company_descriptive_date"));
        Assert.Null(parameters.CompanyDiscretionaryData);
        Assert.False(parameters.RawBodyData.ContainsKey("company_discretionary_data"));
        Assert.Null(parameters.CompanyEntryDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("company_entry_description"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("company_name"));
        Assert.Null(parameters.CreditDebitIndicator);
        Assert.False(parameters.RawBodyData.ContainsKey("credit_debit_indicator"));
        Assert.Null(parameters.EffectiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_date"));
        Assert.Null(parameters.IndividualID);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_id"));
        Assert.Null(parameters.IndividualName);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_name"));
        Assert.Null(parameters.StandardEntryClassCode);
        Assert.False(parameters.RawBodyData.ContainsKey("standard_entry_class_code"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AchPrenotificationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            RoutingNumber = "101050001",

            // Null should be interpreted as omitted for these properties
            Addendum = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            CreditDebitIndicator = null,
            EffectiveDate = null,
            IndividualID = null,
            IndividualName = null,
            StandardEntryClassCode = null,
        };

        Assert.Null(parameters.Addendum);
        Assert.False(parameters.RawBodyData.ContainsKey("addendum"));
        Assert.Null(parameters.CompanyDescriptiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("company_descriptive_date"));
        Assert.Null(parameters.CompanyDiscretionaryData);
        Assert.False(parameters.RawBodyData.ContainsKey("company_discretionary_data"));
        Assert.Null(parameters.CompanyEntryDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("company_entry_description"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("company_name"));
        Assert.Null(parameters.CreditDebitIndicator);
        Assert.False(parameters.RawBodyData.ContainsKey("credit_debit_indicator"));
        Assert.Null(parameters.EffectiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_date"));
        Assert.Null(parameters.IndividualID);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_id"));
        Assert.Null(parameters.IndividualName);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_name"));
        Assert.Null(parameters.StandardEntryClassCode);
        Assert.False(parameters.RawBodyData.ContainsKey("standard_entry_class_code"));
    }

    [Fact]
    public void Url_Works()
    {
        AchPrenotificationCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            RoutingNumber = "101050001",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/ach_prenotifications"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchPrenotificationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            RoutingNumber = "101050001",
            Addendum = "x",
            CompanyDescriptiveDate = "x",
            CompanyDiscretionaryData = "x",
            CompanyEntryDescription = "x",
            CompanyName = "x",
            CreditDebitIndicator = CreditDebitIndicator.Credit,
            EffectiveDate = "2019-12-27",
            IndividualID = "x",
            IndividualName = "x",
            StandardEntryClassCode = StandardEntryClassCode.CorporateCreditOrDebit,
        };

        AchPrenotificationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreditDebitIndicatorTest : TestBase
{
    [Theory]
    [InlineData(CreditDebitIndicator.Credit)]
    [InlineData(CreditDebitIndicator.Debit)]
    public void Validation_Works(CreditDebitIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditDebitIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditDebitIndicator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditDebitIndicator.Credit)]
    [InlineData(CreditDebitIndicator.Debit)]
    public void SerializationRoundtrip_Works(CreditDebitIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditDebitIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditDebitIndicator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditDebitIndicator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditDebitIndicator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StandardEntryClassCodeTest : TestBase
{
    [Theory]
    [InlineData(StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(StandardEntryClassCode.InternetInitiated)]
    public void Validation_Works(StandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StandardEntryClassCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(StandardEntryClassCode.InternetInitiated)]
    public void SerializationRoundtrip_Works(StandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StandardEntryClassCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
