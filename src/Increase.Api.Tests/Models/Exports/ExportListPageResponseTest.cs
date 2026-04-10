using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Exports = Increase.Api.Models.Exports;

namespace Increase.Api.Tests.Models.Exports;

public class ExportListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Exports::ExportListPageResponse
        {
            Data =
            [
                new()
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
                        OnOrAfterDate = "2019-12-27",
                        OnOrBeforeDate = "2019-12-27",
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
                    VoidedCheck = new()
                    {
                        AccountNumberID = "account_number_id",
                        Payer = [new("line")],
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Exports::Export> expectedData =
        [
            new()
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
                    OnOrAfterDate = "2019-12-27",
                    OnOrBeforeDate = "2019-12-27",
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
                VoidedCheck = new()
                {
                    AccountNumberID = "account_number_id",
                    Payer = [new("line")],
                },
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
        var model = new Exports::ExportListPageResponse
        {
            Data =
            [
                new()
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
                        OnOrAfterDate = "2019-12-27",
                        OnOrBeforeDate = "2019-12-27",
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
                    VoidedCheck = new()
                    {
                        AccountNumberID = "account_number_id",
                        Payer = [new("line")],
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Exports::ExportListPageResponse
        {
            Data =
            [
                new()
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
                        OnOrAfterDate = "2019-12-27",
                        OnOrBeforeDate = "2019-12-27",
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
                    VoidedCheck = new()
                    {
                        AccountNumberID = "account_number_id",
                        Payer = [new("line")],
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exports::ExportListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Exports::Export> expectedData =
        [
            new()
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
                    OnOrAfterDate = "2019-12-27",
                    OnOrBeforeDate = "2019-12-27",
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
                VoidedCheck = new()
                {
                    AccountNumberID = "account_number_id",
                    Payer = [new("line")],
                },
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
        var model = new Exports::ExportListPageResponse
        {
            Data =
            [
                new()
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
                        OnOrAfterDate = "2019-12-27",
                        OnOrBeforeDate = "2019-12-27",
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
                    VoidedCheck = new()
                    {
                        AccountNumberID = "account_number_id",
                        Payer = [new("line")],
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Exports::ExportListPageResponse
        {
            Data =
            [
                new()
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
                        OnOrAfterDate = "2019-12-27",
                        OnOrBeforeDate = "2019-12-27",
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
                    VoidedCheck = new()
                    {
                        AccountNumberID = "account_number_id",
                        Payer = [new("line")],
                    },
                },
            ],
            NextCursor = "v57w5d",
        };

        Exports::ExportListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
