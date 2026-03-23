using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Accounts = Increase.Api.Models.Accounts;

namespace Increase.Api.Tests.Models.Accounts;

public class AccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Accounts::Account
        {
            ID = "account_in71c4amph0vgo2qllky",
            AccountRevenueRate = null,
            Bank = Accounts::Bank.FirstInternetBank,
            ClosedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = Accounts::Currency.Usd,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Accounts::AccountFunding.Deposits,
            IdempotencyKey = null,
            InformationalEntityID = null,
            InterestAccrued = "0.01",
            InterestAccruedAt = "2020-01-31",
            InterestRate = "0.055",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                MaturityDate = "2019-12-27",
                StatementDayOfMonth = 0,
                StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
            },
            Name = "My first account!",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            Status = Accounts::AccountStatus.Open,
            Type = Accounts::Type.Account,
        };

        string expectedID = "account_in71c4amph0vgo2qllky";
        ApiEnum<string, Accounts::Bank> expectedBank = Accounts::Bank.FirstInternetBank;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, Accounts::Currency> expectedCurrency = Accounts::Currency.Usd;
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        ApiEnum<string, Accounts::AccountFunding> expectedFunding =
            Accounts::AccountFunding.Deposits;
        string expectedInterestAccrued = "0.01";
        string expectedInterestAccruedAt = "2020-01-31";
        string expectedInterestRate = "0.055";
        Accounts::AccountLoan expectedLoan = new()
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };
        string expectedName = "My first account!";
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        ApiEnum<string, Accounts::AccountStatus> expectedStatus = Accounts::AccountStatus.Open;
        ApiEnum<string, Accounts::Type> expectedType = Accounts::Type.Account;

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.AccountRevenueRate);
        Assert.Equal(expectedBank, model.Bank);
        Assert.Null(model.ClosedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedFunding, model.Funding);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.InformationalEntityID);
        Assert.Equal(expectedInterestAccrued, model.InterestAccrued);
        Assert.Equal(expectedInterestAccruedAt, model.InterestAccruedAt);
        Assert.Equal(expectedInterestRate, model.InterestRate);
        Assert.Equal(expectedLoan, model.Loan);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProgramID, model.ProgramID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Accounts::Account
        {
            ID = "account_in71c4amph0vgo2qllky",
            AccountRevenueRate = null,
            Bank = Accounts::Bank.FirstInternetBank,
            ClosedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = Accounts::Currency.Usd,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Accounts::AccountFunding.Deposits,
            IdempotencyKey = null,
            InformationalEntityID = null,
            InterestAccrued = "0.01",
            InterestAccruedAt = "2020-01-31",
            InterestRate = "0.055",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                MaturityDate = "2019-12-27",
                StatementDayOfMonth = 0,
                StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
            },
            Name = "My first account!",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            Status = Accounts::AccountStatus.Open,
            Type = Accounts::Type.Account,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accounts::Account>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Accounts::Account
        {
            ID = "account_in71c4amph0vgo2qllky",
            AccountRevenueRate = null,
            Bank = Accounts::Bank.FirstInternetBank,
            ClosedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = Accounts::Currency.Usd,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Accounts::AccountFunding.Deposits,
            IdempotencyKey = null,
            InformationalEntityID = null,
            InterestAccrued = "0.01",
            InterestAccruedAt = "2020-01-31",
            InterestRate = "0.055",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                MaturityDate = "2019-12-27",
                StatementDayOfMonth = 0,
                StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
            },
            Name = "My first account!",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            Status = Accounts::AccountStatus.Open,
            Type = Accounts::Type.Account,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accounts::Account>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "account_in71c4amph0vgo2qllky";
        ApiEnum<string, Accounts::Bank> expectedBank = Accounts::Bank.FirstInternetBank;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, Accounts::Currency> expectedCurrency = Accounts::Currency.Usd;
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        ApiEnum<string, Accounts::AccountFunding> expectedFunding =
            Accounts::AccountFunding.Deposits;
        string expectedInterestAccrued = "0.01";
        string expectedInterestAccruedAt = "2020-01-31";
        string expectedInterestRate = "0.055";
        Accounts::AccountLoan expectedLoan = new()
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };
        string expectedName = "My first account!";
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        ApiEnum<string, Accounts::AccountStatus> expectedStatus = Accounts::AccountStatus.Open;
        ApiEnum<string, Accounts::Type> expectedType = Accounts::Type.Account;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.AccountRevenueRate);
        Assert.Equal(expectedBank, deserialized.Bank);
        Assert.Null(deserialized.ClosedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedFunding, deserialized.Funding);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.InformationalEntityID);
        Assert.Equal(expectedInterestAccrued, deserialized.InterestAccrued);
        Assert.Equal(expectedInterestAccruedAt, deserialized.InterestAccruedAt);
        Assert.Equal(expectedInterestRate, deserialized.InterestRate);
        Assert.Equal(expectedLoan, deserialized.Loan);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProgramID, deserialized.ProgramID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Accounts::Account
        {
            ID = "account_in71c4amph0vgo2qllky",
            AccountRevenueRate = null,
            Bank = Accounts::Bank.FirstInternetBank,
            ClosedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = Accounts::Currency.Usd,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Accounts::AccountFunding.Deposits,
            IdempotencyKey = null,
            InformationalEntityID = null,
            InterestAccrued = "0.01",
            InterestAccruedAt = "2020-01-31",
            InterestRate = "0.055",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                MaturityDate = "2019-12-27",
                StatementDayOfMonth = 0,
                StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
            },
            Name = "My first account!",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            Status = Accounts::AccountStatus.Open,
            Type = Accounts::Type.Account,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Accounts::Account
        {
            ID = "account_in71c4amph0vgo2qllky",
            AccountRevenueRate = null,
            Bank = Accounts::Bank.FirstInternetBank,
            ClosedAt = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Currency = Accounts::Currency.Usd,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Funding = Accounts::AccountFunding.Deposits,
            IdempotencyKey = null,
            InformationalEntityID = null,
            InterestAccrued = "0.01",
            InterestAccruedAt = "2020-01-31",
            InterestRate = "0.055",
            Loan = new()
            {
                CreditLimit = 0,
                GracePeriodDays = 0,
                MaturityDate = "2019-12-27",
                StatementDayOfMonth = 0,
                StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
            },
            Name = "My first account!",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            Status = Accounts::AccountStatus.Open,
            Type = Accounts::Type.Account,
        };

        Accounts::Account copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BankTest : TestBase
{
    [Theory]
    [InlineData(Accounts::Bank.CoreBank)]
    [InlineData(Accounts::Bank.FirstInternetBank)]
    [InlineData(Accounts::Bank.GrasshopperBank)]
    public void Validation_Works(Accounts::Bank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Bank> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Bank>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::Bank.CoreBank)]
    [InlineData(Accounts::Bank.FirstInternetBank)]
    [InlineData(Accounts::Bank.GrasshopperBank)]
    public void SerializationRoundtrip_Works(Accounts::Bank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Bank> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Bank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Bank>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Bank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Accounts::Currency.Usd)]
    public void Validation_Works(Accounts::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::Currency.Usd)]
    public void SerializationRoundtrip_Works(Accounts::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccountFundingTest : TestBase
{
    [Theory]
    [InlineData(Accounts::AccountFunding.Loan)]
    [InlineData(Accounts::AccountFunding.Deposits)]
    public void Validation_Works(Accounts::AccountFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::AccountFunding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::AccountFunding.Loan)]
    [InlineData(Accounts::AccountFunding.Deposits)]
    public void SerializationRoundtrip_Works(Accounts::AccountFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::AccountFunding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountFunding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountFunding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccountLoanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Accounts::AccountLoan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };

        long expectedCreditLimit = 0;
        long expectedGracePeriodDays = 0;
        string expectedMaturityDate = "2019-12-27";
        long expectedStatementDayOfMonth = 0;
        ApiEnum<string, Accounts::AccountLoanStatementPaymentType> expectedStatementPaymentType =
            Accounts::AccountLoanStatementPaymentType.Balance;

        Assert.Equal(expectedCreditLimit, model.CreditLimit);
        Assert.Equal(expectedGracePeriodDays, model.GracePeriodDays);
        Assert.Equal(expectedMaturityDate, model.MaturityDate);
        Assert.Equal(expectedStatementDayOfMonth, model.StatementDayOfMonth);
        Assert.Equal(expectedStatementPaymentType, model.StatementPaymentType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Accounts::AccountLoan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accounts::AccountLoan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Accounts::AccountLoan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accounts::AccountLoan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCreditLimit = 0;
        long expectedGracePeriodDays = 0;
        string expectedMaturityDate = "2019-12-27";
        long expectedStatementDayOfMonth = 0;
        ApiEnum<string, Accounts::AccountLoanStatementPaymentType> expectedStatementPaymentType =
            Accounts::AccountLoanStatementPaymentType.Balance;

        Assert.Equal(expectedCreditLimit, deserialized.CreditLimit);
        Assert.Equal(expectedGracePeriodDays, deserialized.GracePeriodDays);
        Assert.Equal(expectedMaturityDate, deserialized.MaturityDate);
        Assert.Equal(expectedStatementDayOfMonth, deserialized.StatementDayOfMonth);
        Assert.Equal(expectedStatementPaymentType, deserialized.StatementPaymentType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Accounts::AccountLoan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Accounts::AccountLoan
        {
            CreditLimit = 0,
            GracePeriodDays = 0,
            MaturityDate = "2019-12-27",
            StatementDayOfMonth = 0,
            StatementPaymentType = Accounts::AccountLoanStatementPaymentType.Balance,
        };

        Accounts::AccountLoan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountLoanStatementPaymentTypeTest : TestBase
{
    [Theory]
    [InlineData(Accounts::AccountLoanStatementPaymentType.Balance)]
    [InlineData(Accounts::AccountLoanStatementPaymentType.InterestUntilMaturity)]
    public void Validation_Works(Accounts::AccountLoanStatementPaymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::AccountLoanStatementPaymentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Accounts::AccountLoanStatementPaymentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::AccountLoanStatementPaymentType.Balance)]
    [InlineData(Accounts::AccountLoanStatementPaymentType.InterestUntilMaturity)]
    public void SerializationRoundtrip_Works(Accounts::AccountLoanStatementPaymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::AccountLoanStatementPaymentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Accounts::AccountLoanStatementPaymentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Accounts::AccountLoanStatementPaymentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Accounts::AccountLoanStatementPaymentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountStatusTest : TestBase
{
    [Theory]
    [InlineData(Accounts::AccountStatus.Closed)]
    [InlineData(Accounts::AccountStatus.Open)]
    public void Validation_Works(Accounts::AccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::AccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::AccountStatus.Closed)]
    [InlineData(Accounts::AccountStatus.Open)]
    public void SerializationRoundtrip_Works(Accounts::AccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::AccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::AccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Accounts::Type.Account)]
    public void Validation_Works(Accounts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::Type.Account)]
    public void SerializationRoundtrip_Works(Accounts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
