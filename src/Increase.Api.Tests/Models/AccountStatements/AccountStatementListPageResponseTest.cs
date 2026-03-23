using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using AccountStatements = Increase.Api.Models.AccountStatements;

namespace Increase.Api.Tests.Models.AccountStatements;

public class AccountStatementListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountStatements::AccountStatementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<AccountStatements::AccountStatement> expectedData =
        [
            new()
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
        var model = new AccountStatements::AccountStatementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountStatements::AccountStatementListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountStatements::AccountStatementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountStatements::AccountStatementListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AccountStatements::AccountStatement> expectedData =
        [
            new()
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
        var model = new AccountStatements::AccountStatementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountStatements::AccountStatementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        AccountStatements::AccountStatementListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
