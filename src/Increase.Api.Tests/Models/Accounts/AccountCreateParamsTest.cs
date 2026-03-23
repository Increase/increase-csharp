using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Accounts;

namespace Increase.Api.Tests.Models.Accounts;

public class AccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountCreateParams
        {
            Name = "New Account!",
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Funding.Loan,
            InformationalEntityID = "informational_entity_id",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                StatementDayOfMonth = 1,
                StatementPaymentType = StatementPaymentType.Balance,
                MaturityDate = "2019-12-27",
            },
            ProgramID = "program_i2v2os4mwza1oetokh9i",
        };

        string expectedName = "New Account!";
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        ApiEnum<string, Funding> expectedFunding = Funding.Loan;
        string expectedInformationalEntityID = "informational_entity_id";
        Loan expectedLoan = new()
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
            MaturityDate = "2019-12-27",
        };
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedFunding, parameters.Funding);
        Assert.Equal(expectedInformationalEntityID, parameters.InformationalEntityID);
        Assert.Equal(expectedLoan, parameters.Loan);
        Assert.Equal(expectedProgramID, parameters.ProgramID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountCreateParams { Name = "New Account!" };

        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
        Assert.Null(parameters.InformationalEntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("informational_entity_id"));
        Assert.Null(parameters.Loan);
        Assert.False(parameters.RawBodyData.ContainsKey("loan"));
        Assert.Null(parameters.ProgramID);
        Assert.False(parameters.RawBodyData.ContainsKey("program_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            Name = "New Account!",

            // Null should be interpreted as omitted for these properties
            EntityID = null,
            Funding = null,
            InformationalEntityID = null,
            Loan = null,
            ProgramID = null,
        };

        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
        Assert.Null(parameters.InformationalEntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("informational_entity_id"));
        Assert.Null(parameters.Loan);
        Assert.False(parameters.RawBodyData.ContainsKey("loan"));
        Assert.Null(parameters.ProgramID);
        Assert.False(parameters.RawBodyData.ContainsKey("program_id"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountCreateParams parameters = new() { Name = "New Account!" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/accounts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountCreateParams
        {
            Name = "New Account!",
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Funding.Loan,
            InformationalEntityID = "informational_entity_id",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                StatementDayOfMonth = 1,
                StatementPaymentType = StatementPaymentType.Balance,
                MaturityDate = "2019-12-27",
            },
            ProgramID = "program_i2v2os4mwza1oetokh9i",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FundingTest : TestBase
{
    [Theory]
    [InlineData(Funding.Loan)]
    [InlineData(Funding.Deposits)]
    public void Validation_Works(Funding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Funding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Funding.Loan)]
    [InlineData(Funding.Deposits)]
    public void SerializationRoundtrip_Works(Funding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Funding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LoanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
            MaturityDate = "2019-12-27",
        };

        long expectedCreditLimit = 0;
        long expectedGracePeriodDays = 0;
        long expectedStatementDayOfMonth = 1;
        ApiEnum<string, StatementPaymentType> expectedStatementPaymentType =
            StatementPaymentType.Balance;
        string expectedMaturityDate = "2019-12-27";

        Assert.Equal(expectedCreditLimit, model.CreditLimit);
        Assert.Equal(expectedGracePeriodDays, model.GracePeriodDays);
        Assert.Equal(expectedStatementDayOfMonth, model.StatementDayOfMonth);
        Assert.Equal(expectedStatementPaymentType, model.StatementPaymentType);
        Assert.Equal(expectedMaturityDate, model.MaturityDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
            MaturityDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Loan>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
            MaturityDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Loan>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedCreditLimit = 0;
        long expectedGracePeriodDays = 0;
        long expectedStatementDayOfMonth = 1;
        ApiEnum<string, StatementPaymentType> expectedStatementPaymentType =
            StatementPaymentType.Balance;
        string expectedMaturityDate = "2019-12-27";

        Assert.Equal(expectedCreditLimit, deserialized.CreditLimit);
        Assert.Equal(expectedGracePeriodDays, deserialized.GracePeriodDays);
        Assert.Equal(expectedStatementDayOfMonth, deserialized.StatementDayOfMonth);
        Assert.Equal(expectedStatementPaymentType, deserialized.StatementPaymentType);
        Assert.Equal(expectedMaturityDate, deserialized.MaturityDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
            MaturityDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
        };

        Assert.Null(model.MaturityDate);
        Assert.False(model.RawData.ContainsKey("maturity_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,

            // Null should be interpreted as omitted for these properties
            MaturityDate = null,
        };

        Assert.Null(model.MaturityDate);
        Assert.False(model.RawData.ContainsKey("maturity_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,

            // Null should be interpreted as omitted for these properties
            MaturityDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Loan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            StatementDayOfMonth = 1,
            StatementPaymentType = StatementPaymentType.Balance,
            MaturityDate = "2019-12-27",
        };

        Loan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatementPaymentTypeTest : TestBase
{
    [Theory]
    [InlineData(StatementPaymentType.Balance)]
    [InlineData(StatementPaymentType.InterestUntilMaturity)]
    public void Validation_Works(StatementPaymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatementPaymentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatementPaymentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StatementPaymentType.Balance)]
    [InlineData(StatementPaymentType.InterestUntilMaturity)]
    public void SerializationRoundtrip_Works(StatementPaymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatementPaymentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatementPaymentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatementPaymentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatementPaymentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
