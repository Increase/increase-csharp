using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using AccountStatements = Increase.Api.Models.AccountStatements;

namespace Increase.Api.Tests.Models.AccountStatements;

public class AccountStatementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountStatements::AccountStatement
        {
            ID = "account_statement_lkc03a4skm2k7f38vj15",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EndingBalance = 100,
            FileID = "file_makxrc67oh9l6sg7w9yc",
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            StartingBalance = 0,
            StatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            StatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = AccountStatements::Type.AccountStatement,
        };

        string expectedID = "account_statement_lkc03a4skm2k7f38vj15";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        long expectedEndingBalance = 100;
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        AccountStatements::Loan expectedLoan = new()
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };
        long expectedStartingBalance = 0;
        DateTimeOffset expectedStatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DateTimeOffset expectedStatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AccountStatements::Type> expectedType =
            AccountStatements::Type.AccountStatement;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEndingBalance, model.EndingBalance);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedLoan, model.Loan);
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
        Assert.Equal(expectedStatementPeriodEnd, model.StatementPeriodEnd);
        Assert.Equal(expectedStatementPeriodStart, model.StatementPeriodStart);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountStatements::AccountStatement
        {
            ID = "account_statement_lkc03a4skm2k7f38vj15",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EndingBalance = 100,
            FileID = "file_makxrc67oh9l6sg7w9yc",
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            StartingBalance = 0,
            StatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            StatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = AccountStatements::Type.AccountStatement,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatements::AccountStatement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountStatements::AccountStatement
        {
            ID = "account_statement_lkc03a4skm2k7f38vj15",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EndingBalance = 100,
            FileID = "file_makxrc67oh9l6sg7w9yc",
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            StartingBalance = 0,
            StatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            StatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = AccountStatements::Type.AccountStatement,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatements::AccountStatement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "account_statement_lkc03a4skm2k7f38vj15";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        long expectedEndingBalance = 100;
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        AccountStatements::Loan expectedLoan = new()
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };
        long expectedStartingBalance = 0;
        DateTimeOffset expectedStatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DateTimeOffset expectedStatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AccountStatements::Type> expectedType =
            AccountStatements::Type.AccountStatement;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEndingBalance, deserialized.EndingBalance);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedLoan, deserialized.Loan);
        Assert.Equal(expectedStartingBalance, deserialized.StartingBalance);
        Assert.Equal(expectedStatementPeriodEnd, deserialized.StatementPeriodEnd);
        Assert.Equal(expectedStatementPeriodStart, deserialized.StatementPeriodStart);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountStatements::AccountStatement
        {
            ID = "account_statement_lkc03a4skm2k7f38vj15",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EndingBalance = 100,
            FileID = "file_makxrc67oh9l6sg7w9yc",
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            StartingBalance = 0,
            StatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            StatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = AccountStatements::Type.AccountStatement,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountStatements::AccountStatement
        {
            ID = "account_statement_lkc03a4skm2k7f38vj15",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EndingBalance = 100,
            FileID = "file_makxrc67oh9l6sg7w9yc",
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            StartingBalance = 0,
            StatementPeriodEnd = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            StatementPeriodStart = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = AccountStatements::Type.AccountStatement,
        };

        AccountStatements::AccountStatement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LoanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountStatements::Loan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDueBalance = 0;
        long expectedPastDueBalance = 0;

        Assert.Equal(expectedDueAt, model.DueAt);
        Assert.Equal(expectedDueBalance, model.DueBalance);
        Assert.Equal(expectedPastDueBalance, model.PastDueBalance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountStatements::Loan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatements::Loan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountStatements::Loan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatements::Loan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDueBalance = 0;
        long expectedPastDueBalance = 0;

        Assert.Equal(expectedDueAt, deserialized.DueAt);
        Assert.Equal(expectedDueBalance, deserialized.DueBalance);
        Assert.Equal(expectedPastDueBalance, deserialized.PastDueBalance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountStatements::Loan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountStatements::Loan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        AccountStatements::Loan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(AccountStatements::Type.AccountStatement)]
    public void Validation_Works(AccountStatements::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountStatements::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountStatements::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountStatements::Type.AccountStatement)]
    public void SerializationRoundtrip_Works(AccountStatements::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountStatements::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountStatements::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountStatements::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountStatements::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
