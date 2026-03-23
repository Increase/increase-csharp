using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Accounts = Increase.Api.Models.Accounts;

namespace Increase.Api.Tests.Models.Accounts;

public class AccountListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Accounts::AccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Accounts::Account> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Accounts::AccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accounts::AccountListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Accounts::AccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Accounts::AccountListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Accounts::Account> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Accounts::AccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Accounts::AccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        Accounts::AccountListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
