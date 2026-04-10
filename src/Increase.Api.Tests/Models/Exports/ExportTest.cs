using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Exports = Increase.Api.Models.Exports;

namespace Increase.Api.Tests.Models.Exports;

public class ExportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::Export
        {
            ID = "export_8s4m48qz3bclzje0zwh9",
            AccountStatementBai2 = new()
            {
                AccountID = "account_id",
                EffectiveDate = "2019-12-27",
                ProgramID = "program_id",
            },
            AccountStatementOfx = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            AccountVerificationLetter = new()
            {
                AccountNumberID = "account_number_id",
                BalanceDate = "2019-12-27",
            },
            BalanceCsv = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Category = Exports::ExportCategory.TransactionCsv,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            DashboardTableCsv = new(),
            EntityCsv = new(),
            FeeCsv = new(
                new Exports::FeeCsvCreatedAt()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                }
            ),
            Form1099Int = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Description = "description",
                Year = 0,
            },
            Form1099Misc = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Year = 0,
            },
            FundingInstructions = new("account_number_id"),
            IdempotencyKey = null,
            Result = new("file_makxrc67oh9l6sg7w9yc"),
            Status = Exports::ExportStatus.Complete,
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Type = Exports::Type.Export,
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("line")] },
        };

        string expectedID = "export_8s4m48qz3bclzje0zwh9";
        Exports::ExportAccountStatementBai2 expectedAccountStatementBai2 = new()
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };
        Exports::ExportAccountStatementOfx expectedAccountStatementOfx = new()
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        Exports::ExportAccountVerificationLetter expectedAccountVerificationLetter = new()
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };
        Exports::ExportBalanceCsv expectedBalanceCsv = new()
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        Exports::ExportBookkeepingAccountBalanceCsv expectedBookkeepingAccountBalanceCsv = new()
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        ApiEnum<string, Exports::ExportCategory> expectedCategory =
            Exports::ExportCategory.TransactionCsv;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        Exports::ExportDailyAccountBalanceCsv expectedDailyAccountBalanceCsv = new()
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };
        Exports::DashboardTableCsv expectedDashboardTableCsv = new();
        Exports::ExportEntityCsv expectedEntityCsv = new();
        Exports::FeeCsv expectedFeeCsv = new(
            new Exports::FeeCsvCreatedAt()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        Exports::ExportForm1099Int expectedForm1099Int = new()
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };
        Exports::ExportForm1099Misc expectedForm1099Misc = new()
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };
        Exports::ExportFundingInstructions expectedFundingInstructions = new("account_number_id");
        Exports::Result expectedResult = new("file_makxrc67oh9l6sg7w9yc");
        ApiEnum<string, Exports::ExportStatus> expectedStatus = Exports::ExportStatus.Complete;
        Exports::ExportTransactionCsv expectedTransactionCsv = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        ApiEnum<string, Exports::Type> expectedType = Exports::Type.Export;
        Exports::ExportVendorCsv expectedVendorCsv = new();
        Exports::ExportVoidedCheck expectedVoidedCheck = new()
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountStatementBai2, model.AccountStatementBai2);
        Assert.Equal(expectedAccountStatementOfx, model.AccountStatementOfx);
        Assert.Equal(expectedAccountVerificationLetter, model.AccountVerificationLetter);
        Assert.Equal(expectedBalanceCsv, model.BalanceCsv);
        Assert.Equal(expectedBookkeepingAccountBalanceCsv, model.BookkeepingAccountBalanceCsv);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDailyAccountBalanceCsv, model.DailyAccountBalanceCsv);
        Assert.Equal(expectedDashboardTableCsv, model.DashboardTableCsv);
        Assert.Equal(expectedEntityCsv, model.EntityCsv);
        Assert.Equal(expectedFeeCsv, model.FeeCsv);
        Assert.Equal(expectedForm1099Int, model.Form1099Int);
        Assert.Equal(expectedForm1099Misc, model.Form1099Misc);
        Assert.Equal(expectedFundingInstructions, model.FundingInstructions);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionCsv, model.TransactionCsv);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVendorCsv, model.VendorCsv);
        Assert.Equal(expectedVoidedCheck, model.VoidedCheck);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::Export
        {
            ID = "export_8s4m48qz3bclzje0zwh9",
            AccountStatementBai2 = new()
            {
                AccountID = "account_id",
                EffectiveDate = "2019-12-27",
                ProgramID = "program_id",
            },
            AccountStatementOfx = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            AccountVerificationLetter = new()
            {
                AccountNumberID = "account_number_id",
                BalanceDate = "2019-12-27",
            },
            BalanceCsv = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Category = Exports::ExportCategory.TransactionCsv,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            DashboardTableCsv = new(),
            EntityCsv = new(),
            FeeCsv = new(
                new Exports::FeeCsvCreatedAt()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                }
            ),
            Form1099Int = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Description = "description",
                Year = 0,
            },
            Form1099Misc = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Year = 0,
            },
            FundingInstructions = new("account_number_id"),
            IdempotencyKey = null,
            Result = new("file_makxrc67oh9l6sg7w9yc"),
            Status = Exports::ExportStatus.Complete,
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Type = Exports::Type.Export,
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("line")] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::Export>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::Export
        {
            ID = "export_8s4m48qz3bclzje0zwh9",
            AccountStatementBai2 = new()
            {
                AccountID = "account_id",
                EffectiveDate = "2019-12-27",
                ProgramID = "program_id",
            },
            AccountStatementOfx = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            AccountVerificationLetter = new()
            {
                AccountNumberID = "account_number_id",
                BalanceDate = "2019-12-27",
            },
            BalanceCsv = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Category = Exports::ExportCategory.TransactionCsv,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            DashboardTableCsv = new(),
            EntityCsv = new(),
            FeeCsv = new(
                new Exports::FeeCsvCreatedAt()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                }
            ),
            Form1099Int = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Description = "description",
                Year = 0,
            },
            Form1099Misc = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Year = 0,
            },
            FundingInstructions = new("account_number_id"),
            IdempotencyKey = null,
            Result = new("file_makxrc67oh9l6sg7w9yc"),
            Status = Exports::ExportStatus.Complete,
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Type = Exports::Type.Export,
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("line")] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::Export>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "export_8s4m48qz3bclzje0zwh9";
        Exports::ExportAccountStatementBai2 expectedAccountStatementBai2 = new()
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };
        Exports::ExportAccountStatementOfx expectedAccountStatementOfx = new()
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        Exports::ExportAccountVerificationLetter expectedAccountVerificationLetter = new()
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };
        Exports::ExportBalanceCsv expectedBalanceCsv = new()
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        Exports::ExportBookkeepingAccountBalanceCsv expectedBookkeepingAccountBalanceCsv = new()
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        ApiEnum<string, Exports::ExportCategory> expectedCategory =
            Exports::ExportCategory.TransactionCsv;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        Exports::ExportDailyAccountBalanceCsv expectedDailyAccountBalanceCsv = new()
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };
        Exports::DashboardTableCsv expectedDashboardTableCsv = new();
        Exports::ExportEntityCsv expectedEntityCsv = new();
        Exports::FeeCsv expectedFeeCsv = new(
            new Exports::FeeCsvCreatedAt()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        Exports::ExportForm1099Int expectedForm1099Int = new()
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };
        Exports::ExportForm1099Misc expectedForm1099Misc = new()
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };
        Exports::ExportFundingInstructions expectedFundingInstructions = new("account_number_id");
        Exports::Result expectedResult = new("file_makxrc67oh9l6sg7w9yc");
        ApiEnum<string, Exports::ExportStatus> expectedStatus = Exports::ExportStatus.Complete;
        Exports::ExportTransactionCsv expectedTransactionCsv = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        ApiEnum<string, Exports::Type> expectedType = Exports::Type.Export;
        Exports::ExportVendorCsv expectedVendorCsv = new();
        Exports::ExportVoidedCheck expectedVoidedCheck = new()
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountStatementBai2, deserialized.AccountStatementBai2);
        Assert.Equal(expectedAccountStatementOfx, deserialized.AccountStatementOfx);
        Assert.Equal(expectedAccountVerificationLetter, deserialized.AccountVerificationLetter);
        Assert.Equal(expectedBalanceCsv, deserialized.BalanceCsv);
        Assert.Equal(
            expectedBookkeepingAccountBalanceCsv,
            deserialized.BookkeepingAccountBalanceCsv
        );
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDailyAccountBalanceCsv, deserialized.DailyAccountBalanceCsv);
        Assert.Equal(expectedDashboardTableCsv, deserialized.DashboardTableCsv);
        Assert.Equal(expectedEntityCsv, deserialized.EntityCsv);
        Assert.Equal(expectedFeeCsv, deserialized.FeeCsv);
        Assert.Equal(expectedForm1099Int, deserialized.Form1099Int);
        Assert.Equal(expectedForm1099Misc, deserialized.Form1099Misc);
        Assert.Equal(expectedFundingInstructions, deserialized.FundingInstructions);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionCsv, deserialized.TransactionCsv);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVendorCsv, deserialized.VendorCsv);
        Assert.Equal(expectedVoidedCheck, deserialized.VoidedCheck);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::Export
        {
            ID = "export_8s4m48qz3bclzje0zwh9",
            AccountStatementBai2 = new()
            {
                AccountID = "account_id",
                EffectiveDate = "2019-12-27",
                ProgramID = "program_id",
            },
            AccountStatementOfx = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            AccountVerificationLetter = new()
            {
                AccountNumberID = "account_number_id",
                BalanceDate = "2019-12-27",
            },
            BalanceCsv = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Category = Exports::ExportCategory.TransactionCsv,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            DashboardTableCsv = new(),
            EntityCsv = new(),
            FeeCsv = new(
                new Exports::FeeCsvCreatedAt()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                }
            ),
            Form1099Int = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Description = "description",
                Year = 0,
            },
            Form1099Misc = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Year = 0,
            },
            FundingInstructions = new("account_number_id"),
            IdempotencyKey = null,
            Result = new("file_makxrc67oh9l6sg7w9yc"),
            Status = Exports::ExportStatus.Complete,
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Type = Exports::Type.Export,
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("line")] },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::Export
        {
            ID = "export_8s4m48qz3bclzje0zwh9",
            AccountStatementBai2 = new()
            {
                AccountID = "account_id",
                EffectiveDate = "2019-12-27",
                ProgramID = "program_id",
            },
            AccountStatementOfx = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            AccountVerificationLetter = new()
            {
                AccountNumberID = "account_number_id",
                BalanceDate = "2019-12-27",
            },
            BalanceCsv = new()
            {
                AccountID = "account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Category = Exports::ExportCategory.TransactionCsv,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            DashboardTableCsv = new(),
            EntityCsv = new(),
            FeeCsv = new(
                new Exports::FeeCsvCreatedAt()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                }
            ),
            Form1099Int = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Description = "description",
                Year = 0,
            },
            Form1099Misc = new()
            {
                AccountID = "account_id",
                Corrected = true,
                Year = 0,
            },
            FundingInstructions = new("account_number_id"),
            IdempotencyKey = null,
            Result = new("file_makxrc67oh9l6sg7w9yc"),
            Status = Exports::ExportStatus.Complete,
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            Type = Exports::Type.Export,
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("line")] },
        };

        Exports::Export copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportAccountStatementBai2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportAccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        string expectedAccountID = "account_id";
        string expectedEffectiveDate = "2019-12-27";
        string expectedProgramID = "program_id";

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedProgramID, model.ProgramID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportAccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountStatementBai2>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportAccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountStatementBai2>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        string expectedEffectiveDate = "2019-12-27";
        string expectedProgramID = "program_id";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedProgramID, deserialized.ProgramID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportAccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportAccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        Exports::ExportAccountStatementBai2 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportAccountStatementOfxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportAccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedAccountID = "account_id";
        Exports::ExportAccountStatementOfxCreatedAt expectedCreatedAt = new()
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportAccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountStatementOfx>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportAccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountStatementOfx>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        Exports::ExportAccountStatementOfxCreatedAt expectedCreatedAt = new()
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportAccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportAccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Exports::ExportAccountStatementOfx copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportAccountStatementOfxCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportAccountStatementOfxCreatedAt
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportAccountStatementOfxCreatedAt
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountStatementOfxCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportAccountStatementOfxCreatedAt
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountStatementOfxCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportAccountStatementOfxCreatedAt
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportAccountStatementOfxCreatedAt
        {
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Exports::ExportAccountStatementOfxCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportAccountVerificationLetterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportAccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        string expectedAccountNumberID = "account_number_id";
        string expectedBalanceDate = "2019-12-27";

        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedBalanceDate, model.BalanceDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportAccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountVerificationLetter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportAccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportAccountVerificationLetter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountNumberID = "account_number_id";
        string expectedBalanceDate = "2019-12-27";

        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedBalanceDate, deserialized.BalanceDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportAccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportAccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        Exports::ExportAccountVerificationLetter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportBalanceCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportBalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedAccountID = "account_id";
        Exports::ExportBalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportBalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportBalanceCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportBalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportBalanceCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        Exports::ExportBalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportBalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportBalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Exports::ExportBalanceCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportBalanceCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportBalanceCsvCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportBalanceCsvCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Exports::ExportBalanceCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportBookkeepingAccountBalanceCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedBookkeepingAccountID = "bookkeeping_account_id";
        Exports::ExportBookkeepingAccountBalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedBookkeepingAccountID, model.BookkeepingAccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportBookkeepingAccountBalanceCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportBookkeepingAccountBalanceCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBookkeepingAccountID = "bookkeeping_account_id";
        Exports::ExportBookkeepingAccountBalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedBookkeepingAccountID, deserialized.BookkeepingAccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Exports::ExportBookkeepingAccountBalanceCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportBookkeepingAccountBalanceCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Exports::ExportBookkeepingAccountBalanceCsvCreatedAt>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Exports::ExportBookkeepingAccountBalanceCsvCreatedAt>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportBookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Exports::ExportBookkeepingAccountBalanceCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportCategoryTest : TestBase
{
    [Theory]
    [InlineData(Exports::ExportCategory.AccountStatementOfx)]
    [InlineData(Exports::ExportCategory.AccountStatementBai2)]
    [InlineData(Exports::ExportCategory.TransactionCsv)]
    [InlineData(Exports::ExportCategory.BalanceCsv)]
    [InlineData(Exports::ExportCategory.BookkeepingAccountBalanceCsv)]
    [InlineData(Exports::ExportCategory.EntityCsv)]
    [InlineData(Exports::ExportCategory.VendorCsv)]
    [InlineData(Exports::ExportCategory.DashboardTableCsv)]
    [InlineData(Exports::ExportCategory.AccountVerificationLetter)]
    [InlineData(Exports::ExportCategory.FundingInstructions)]
    [InlineData(Exports::ExportCategory.Form1099Int)]
    [InlineData(Exports::ExportCategory.Form1099Misc)]
    [InlineData(Exports::ExportCategory.FeeCsv)]
    [InlineData(Exports::ExportCategory.VoidedCheck)]
    [InlineData(Exports::ExportCategory.DailyAccountBalanceCsv)]
    public void Validation_Works(Exports::ExportCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Exports::ExportCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Exports::ExportCategory.AccountStatementOfx)]
    [InlineData(Exports::ExportCategory.AccountStatementBai2)]
    [InlineData(Exports::ExportCategory.TransactionCsv)]
    [InlineData(Exports::ExportCategory.BalanceCsv)]
    [InlineData(Exports::ExportCategory.BookkeepingAccountBalanceCsv)]
    [InlineData(Exports::ExportCategory.EntityCsv)]
    [InlineData(Exports::ExportCategory.VendorCsv)]
    [InlineData(Exports::ExportCategory.DashboardTableCsv)]
    [InlineData(Exports::ExportCategory.AccountVerificationLetter)]
    [InlineData(Exports::ExportCategory.FundingInstructions)]
    [InlineData(Exports::ExportCategory.Form1099Int)]
    [InlineData(Exports::ExportCategory.Form1099Misc)]
    [InlineData(Exports::ExportCategory.FeeCsv)]
    [InlineData(Exports::ExportCategory.VoidedCheck)]
    [InlineData(Exports::ExportCategory.DailyAccountBalanceCsv)]
    public void SerializationRoundtrip_Works(Exports::ExportCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Exports::ExportCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExportDailyAccountBalanceCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportDailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        string expectedAccountID = "account_id";
        string expectedOnOrAfterDate = "2019-12-27";
        string expectedOnOrBeforeDate = "2019-12-27";

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedOnOrAfterDate, model.OnOrAfterDate);
        Assert.Equal(expectedOnOrBeforeDate, model.OnOrBeforeDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportDailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportDailyAccountBalanceCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportDailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportDailyAccountBalanceCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        string expectedOnOrAfterDate = "2019-12-27";
        string expectedOnOrBeforeDate = "2019-12-27";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedOnOrAfterDate, deserialized.OnOrAfterDate);
        Assert.Equal(expectedOnOrBeforeDate, deserialized.OnOrBeforeDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportDailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportDailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        Exports::ExportDailyAccountBalanceCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DashboardTableCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::DashboardTableCsv { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::DashboardTableCsv { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::DashboardTableCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::DashboardTableCsv { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::DashboardTableCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::DashboardTableCsv { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::DashboardTableCsv { };

        Exports::DashboardTableCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportEntityCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportEntityCsv { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportEntityCsv { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportEntityCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportEntityCsv { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportEntityCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportEntityCsv { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportEntityCsv { };

        Exports::ExportEntityCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeeCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::FeeCsv
        {
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Exports::FeeCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::FeeCsv
        {
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::FeeCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::FeeCsv
        {
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::FeeCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Exports::FeeCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::FeeCsv
        {
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::FeeCsv
        {
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Exports::FeeCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeeCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::FeeCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::FeeCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::FeeCsvCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::FeeCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::FeeCsvCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::FeeCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::FeeCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Exports::FeeCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportForm1099IntTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportForm1099Int
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };

        string expectedAccountID = "account_id";
        bool expectedCorrected = true;
        string expectedDescription = "description";
        long expectedYear = 0;

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCorrected, model.Corrected);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedYear, model.Year);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportForm1099Int
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportForm1099Int>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportForm1099Int
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportForm1099Int>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        bool expectedCorrected = true;
        string expectedDescription = "description";
        long expectedYear = 0;

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCorrected, deserialized.Corrected);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedYear, deserialized.Year);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportForm1099Int
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportForm1099Int
        {
            AccountID = "account_id",
            Corrected = true,
            Description = "description",
            Year = 0,
        };

        Exports::ExportForm1099Int copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportForm1099MiscTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportForm1099Misc
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };

        string expectedAccountID = "account_id";
        bool expectedCorrected = true;
        long expectedYear = 0;

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCorrected, model.Corrected);
        Assert.Equal(expectedYear, model.Year);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportForm1099Misc
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportForm1099Misc>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportForm1099Misc
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportForm1099Misc>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        bool expectedCorrected = true;
        long expectedYear = 0;

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCorrected, deserialized.Corrected);
        Assert.Equal(expectedYear, deserialized.Year);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportForm1099Misc
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportForm1099Misc
        {
            AccountID = "account_id",
            Corrected = true,
            Year = 0,
        };

        Exports::ExportForm1099Misc copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportFundingInstructionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportFundingInstructions
        {
            AccountNumberID = "account_number_id",
        };

        string expectedAccountNumberID = "account_number_id";

        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportFundingInstructions
        {
            AccountNumberID = "account_number_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportFundingInstructions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportFundingInstructions
        {
            AccountNumberID = "account_number_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportFundingInstructions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountNumberID = "account_number_id";

        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportFundingInstructions
        {
            AccountNumberID = "account_number_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportFundingInstructions
        {
            AccountNumberID = "account_number_id",
        };

        Exports::ExportFundingInstructions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::Result { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, model.FileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::Result { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::Result>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::Result { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::Result>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, deserialized.FileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::Result { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::Result { FileID = "file_id" };

        Exports::Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportStatusTest : TestBase
{
    [Theory]
    [InlineData(Exports::ExportStatus.Pending)]
    [InlineData(Exports::ExportStatus.Complete)]
    [InlineData(Exports::ExportStatus.Failed)]
    public void Validation_Works(Exports::ExportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Exports::ExportStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Exports::ExportStatus.Pending)]
    [InlineData(Exports::ExportStatus.Complete)]
    [InlineData(Exports::ExportStatus.Failed)]
    public void SerializationRoundtrip_Works(Exports::ExportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Exports::ExportStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Exports::ExportStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExportTransactionCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportTransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedAccountID = "account_id";
        Exports::ExportTransactionCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportTransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportTransactionCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportTransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportTransactionCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        Exports::ExportTransactionCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportTransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportTransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Exports::ExportTransactionCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportTransactionCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportTransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportTransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportTransactionCsvCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportTransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportTransactionCsvCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportTransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportTransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Exports::ExportTransactionCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Exports::Type.Export)]
    public void Validation_Works(Exports::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Exports::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Exports::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Exports::Type.Export)]
    public void SerializationRoundtrip_Works(Exports::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Exports::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Exports::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Exports::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Exports::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExportVendorCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportVendorCsv { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportVendorCsv { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportVendorCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportVendorCsv { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportVendorCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportVendorCsv { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportVendorCsv { };

        Exports::ExportVendorCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportVoidedCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportVoidedCheck
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        string expectedAccountNumberID = "account_number_id";
        List<Exports::ExportVoidedCheckPayer> expectedPayer = [new("line")];

        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedPayer.Count, model.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], model.Payer[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportVoidedCheck
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportVoidedCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportVoidedCheck
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportVoidedCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountNumberID = "account_number_id";
        List<Exports::ExportVoidedCheckPayer> expectedPayer = [new("line")];

        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedPayer.Count, deserialized.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], deserialized.Payer[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportVoidedCheck
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportVoidedCheck
        {
            AccountNumberID = "account_number_id",
            Payer = [new("line")],
        };

        Exports::ExportVoidedCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExportVoidedCheckPayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportVoidedCheckPayer { Line = "line" };

        string expectedLine = "line";

        Assert.Equal(expectedLine, model.Line);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Exports::ExportVoidedCheckPayer { Line = "line" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportVoidedCheckPayer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportVoidedCheckPayer { Line = "line" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportVoidedCheckPayer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLine = "line";

        Assert.Equal(expectedLine, deserialized.Line);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Exports::ExportVoidedCheckPayer { Line = "line" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportVoidedCheckPayer { Line = "line" };

        Exports::ExportVoidedCheckPayer copied = new(model);

        Assert.Equal(model, copied);
    }
}
