using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Exports;

namespace Increase.Api.Tests.Models.Exports;

public class ExportCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportCreateParams
        {
            Category = Category.TransactionCsv,
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
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            EntityCsv = new(),
            FundingInstructions = new("account_number_id"),
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("x")] },
        };

        ApiEnum<string, Category> expectedCategory = Category.TransactionCsv;
        AccountStatementBai2 expectedAccountStatementBai2 = new()
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };
        AccountStatementOfx expectedAccountStatementOfx = new()
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        AccountVerificationLetter expectedAccountVerificationLetter = new()
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };
        BalanceCsv expectedBalanceCsv = new()
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        BookkeepingAccountBalanceCsv expectedBookkeepingAccountBalanceCsv = new()
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        DailyAccountBalanceCsv expectedDailyAccountBalanceCsv = new()
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };
        EntityCsv expectedEntityCsv = new();
        FundingInstructions expectedFundingInstructions = new("account_number_id");
        TransactionCsv expectedTransactionCsv = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };
        VendorCsv expectedVendorCsv = new();
        VoidedCheck expectedVoidedCheck = new()
        {
            AccountNumberID = "account_number_id",
            Payer = [new("x")],
        };

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedAccountStatementBai2, parameters.AccountStatementBai2);
        Assert.Equal(expectedAccountStatementOfx, parameters.AccountStatementOfx);
        Assert.Equal(expectedAccountVerificationLetter, parameters.AccountVerificationLetter);
        Assert.Equal(expectedBalanceCsv, parameters.BalanceCsv);
        Assert.Equal(expectedBookkeepingAccountBalanceCsv, parameters.BookkeepingAccountBalanceCsv);
        Assert.Equal(expectedDailyAccountBalanceCsv, parameters.DailyAccountBalanceCsv);
        Assert.Equal(expectedEntityCsv, parameters.EntityCsv);
        Assert.Equal(expectedFundingInstructions, parameters.FundingInstructions);
        Assert.Equal(expectedTransactionCsv, parameters.TransactionCsv);
        Assert.Equal(expectedVendorCsv, parameters.VendorCsv);
        Assert.Equal(expectedVoidedCheck, parameters.VoidedCheck);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExportCreateParams { Category = Category.TransactionCsv };

        Assert.Null(parameters.AccountStatementBai2);
        Assert.False(parameters.RawBodyData.ContainsKey("account_statement_bai2"));
        Assert.Null(parameters.AccountStatementOfx);
        Assert.False(parameters.RawBodyData.ContainsKey("account_statement_ofx"));
        Assert.Null(parameters.AccountVerificationLetter);
        Assert.False(parameters.RawBodyData.ContainsKey("account_verification_letter"));
        Assert.Null(parameters.BalanceCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("balance_csv"));
        Assert.Null(parameters.BookkeepingAccountBalanceCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("bookkeeping_account_balance_csv"));
        Assert.Null(parameters.DailyAccountBalanceCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("daily_account_balance_csv"));
        Assert.Null(parameters.EntityCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_csv"));
        Assert.Null(parameters.FundingInstructions);
        Assert.False(parameters.RawBodyData.ContainsKey("funding_instructions"));
        Assert.Null(parameters.TransactionCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_csv"));
        Assert.Null(parameters.VendorCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("vendor_csv"));
        Assert.Null(parameters.VoidedCheck);
        Assert.False(parameters.RawBodyData.ContainsKey("voided_check"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExportCreateParams
        {
            Category = Category.TransactionCsv,

            // Null should be interpreted as omitted for these properties
            AccountStatementBai2 = null,
            AccountStatementOfx = null,
            AccountVerificationLetter = null,
            BalanceCsv = null,
            BookkeepingAccountBalanceCsv = null,
            DailyAccountBalanceCsv = null,
            EntityCsv = null,
            FundingInstructions = null,
            TransactionCsv = null,
            VendorCsv = null,
            VoidedCheck = null,
        };

        Assert.Null(parameters.AccountStatementBai2);
        Assert.False(parameters.RawBodyData.ContainsKey("account_statement_bai2"));
        Assert.Null(parameters.AccountStatementOfx);
        Assert.False(parameters.RawBodyData.ContainsKey("account_statement_ofx"));
        Assert.Null(parameters.AccountVerificationLetter);
        Assert.False(parameters.RawBodyData.ContainsKey("account_verification_letter"));
        Assert.Null(parameters.BalanceCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("balance_csv"));
        Assert.Null(parameters.BookkeepingAccountBalanceCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("bookkeeping_account_balance_csv"));
        Assert.Null(parameters.DailyAccountBalanceCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("daily_account_balance_csv"));
        Assert.Null(parameters.EntityCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_csv"));
        Assert.Null(parameters.FundingInstructions);
        Assert.False(parameters.RawBodyData.ContainsKey("funding_instructions"));
        Assert.Null(parameters.TransactionCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_csv"));
        Assert.Null(parameters.VendorCsv);
        Assert.False(parameters.RawBodyData.ContainsKey("vendor_csv"));
        Assert.Null(parameters.VoidedCheck);
        Assert.False(parameters.RawBodyData.ContainsKey("voided_check"));
    }

    [Fact]
    public void Url_Works()
    {
        ExportCreateParams parameters = new() { Category = Category.TransactionCsv };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/exports"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExportCreateParams
        {
            Category = Category.TransactionCsv,
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
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            BookkeepingAccountBalanceCsv = new()
            {
                BookkeepingAccountID = "bookkeeping_account_id",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            DailyAccountBalanceCsv = new()
            {
                AccountID = "account_id",
                OnOrAfterDate = "2019-12-27",
                OnOrBeforeDate = "2019-12-27",
            },
            EntityCsv = new(),
            FundingInstructions = new("account_number_id"),
            TransactionCsv = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = new()
                {
                    After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
            VendorCsv = new(),
            VoidedCheck = new() { AccountNumberID = "account_number_id", Payer = [new("x")] },
        };

        ExportCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.AccountStatementOfx)]
    [InlineData(Category.AccountStatementBai2)]
    [InlineData(Category.TransactionCsv)]
    [InlineData(Category.BalanceCsv)]
    [InlineData(Category.BookkeepingAccountBalanceCsv)]
    [InlineData(Category.EntityCsv)]
    [InlineData(Category.VendorCsv)]
    [InlineData(Category.AccountVerificationLetter)]
    [InlineData(Category.FundingInstructions)]
    [InlineData(Category.VoidedCheck)]
    [InlineData(Category.DailyAccountBalanceCsv)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.AccountStatementOfx)]
    [InlineData(Category.AccountStatementBai2)]
    [InlineData(Category.TransactionCsv)]
    [InlineData(Category.BalanceCsv)]
    [InlineData(Category.BookkeepingAccountBalanceCsv)]
    [InlineData(Category.EntityCsv)]
    [InlineData(Category.VendorCsv)]
    [InlineData(Category.AccountVerificationLetter)]
    [InlineData(Category.FundingInstructions)]
    [InlineData(Category.VoidedCheck)]
    [InlineData(Category.DailyAccountBalanceCsv)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccountStatementBai2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountStatementBai2
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
        var model = new AccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatementBai2>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatementBai2>(
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
        var model = new AccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountStatementBai2 { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.EffectiveDate);
        Assert.False(model.RawData.ContainsKey("effective_date"));
        Assert.Null(model.ProgramID);
        Assert.False(model.RawData.ContainsKey("program_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountStatementBai2 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountStatementBai2
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            EffectiveDate = null,
            ProgramID = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.EffectiveDate);
        Assert.False(model.RawData.ContainsKey("effective_date"));
        Assert.Null(model.ProgramID);
        Assert.False(model.RawData.ContainsKey("program_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountStatementBai2
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            EffectiveDate = null,
            ProgramID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountStatementBai2
        {
            AccountID = "account_id",
            EffectiveDate = "2019-12-27",
            ProgramID = "program_id",
        };

        AccountStatementBai2 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountStatementOfxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedAccountID = "account_id";
        CreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatementOfx>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountStatementOfx>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        CreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountStatementOfx { AccountID = "account_id" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountStatementOfx { AccountID = "account_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountStatementOfx
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        AccountStatementOfx copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountVerificationLetterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountVerificationLetter
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
        var model = new AccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountVerificationLetter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountVerificationLetter>(
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
        var model = new AccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountVerificationLetter { AccountNumberID = "account_number_id" };

        Assert.Null(model.BalanceDate);
        Assert.False(model.RawData.ContainsKey("balance_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountVerificationLetter { AccountNumberID = "account_number_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountVerificationLetter
        {
            AccountNumberID = "account_number_id",

            // Null should be interpreted as omitted for these properties
            BalanceDate = null,
        };

        Assert.Null(model.BalanceDate);
        Assert.False(model.RawData.ContainsKey("balance_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountVerificationLetter
        {
            AccountNumberID = "account_number_id",

            // Null should be interpreted as omitted for these properties
            BalanceDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountVerificationLetter
        {
            AccountNumberID = "account_number_id",
            BalanceDate = "2019-12-27",
        };

        AccountVerificationLetter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedAccountID = "account_id";
        BalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        BalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BalanceCsv { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BalanceCsv { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BalanceCsv
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            CreatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BalanceCsv
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            CreatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        BalanceCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceCsvCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceCsvCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BalanceCsvCreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BalanceCsvCreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BalanceCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BookkeepingAccountBalanceCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedBookkeepingAccountID = "bookkeeping_account_id";
        BookkeepingAccountBalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedBookkeepingAccountID, model.BookkeepingAccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccountBalanceCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccountBalanceCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBookkeepingAccountID = "bookkeeping_account_id";
        BookkeepingAccountBalanceCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedBookkeepingAccountID, deserialized.BookkeepingAccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BookkeepingAccountBalanceCsv { };

        Assert.Null(model.BookkeepingAccountID);
        Assert.False(model.RawData.ContainsKey("bookkeeping_account_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BookkeepingAccountBalanceCsv { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            // Null should be interpreted as omitted for these properties
            BookkeepingAccountID = null,
            CreatedAt = null,
        };

        Assert.Null(model.BookkeepingAccountID);
        Assert.False(model.RawData.ContainsKey("bookkeeping_account_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            // Null should be interpreted as omitted for these properties
            BookkeepingAccountID = null,
            CreatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingAccountBalanceCsv
        {
            BookkeepingAccountID = "bookkeeping_account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        BookkeepingAccountBalanceCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BookkeepingAccountBalanceCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccountBalanceCsvCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccountBalanceCsvCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingAccountBalanceCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BookkeepingAccountBalanceCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DailyAccountBalanceCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DailyAccountBalanceCsv
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
        var model = new DailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DailyAccountBalanceCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DailyAccountBalanceCsv>(
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
        var model = new DailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DailyAccountBalanceCsv { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.OnOrAfterDate);
        Assert.False(model.RawData.ContainsKey("on_or_after_date"));
        Assert.Null(model.OnOrBeforeDate);
        Assert.False(model.RawData.ContainsKey("on_or_before_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DailyAccountBalanceCsv { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DailyAccountBalanceCsv
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            OnOrAfterDate = null,
            OnOrBeforeDate = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.OnOrAfterDate);
        Assert.False(model.RawData.ContainsKey("on_or_after_date"));
        Assert.Null(model.OnOrBeforeDate);
        Assert.False(model.RawData.ContainsKey("on_or_before_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DailyAccountBalanceCsv
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            OnOrAfterDate = null,
            OnOrBeforeDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DailyAccountBalanceCsv
        {
            AccountID = "account_id",
            OnOrAfterDate = "2019-12-27",
            OnOrBeforeDate = "2019-12-27",
        };

        DailyAccountBalanceCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityCsv { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityCsv { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityCsv>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityCsv { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityCsv { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityCsv { };

        EntityCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FundingInstructionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FundingInstructions { AccountNumberID = "account_number_id" };

        string expectedAccountNumberID = "account_number_id";

        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FundingInstructions { AccountNumberID = "account_number_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FundingInstructions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FundingInstructions { AccountNumberID = "account_number_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FundingInstructions>(
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
        var model = new FundingInstructions { AccountNumberID = "account_number_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FundingInstructions { AccountNumberID = "account_number_id" };

        FundingInstructions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedAccountID = "account_id";
        TransactionCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionCsv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        TransactionCsvCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TransactionCsv { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TransactionCsv { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TransactionCsv
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            CreatedAt = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TransactionCsv
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            CreatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionCsv
        {
            AccountID = "account_id",
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        TransactionCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionCsvCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionCsvCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionCsvCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TransactionCsvCreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TransactionCsvCreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionCsvCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        TransactionCsvCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VendorCsvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VendorCsv { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VendorCsv { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VendorCsv>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VendorCsv { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VendorCsv>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VendorCsv { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VendorCsv { };

        VendorCsv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VoidedCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id", Payer = [new("x")] };

        string expectedAccountNumberID = "account_number_id";
        List<Payer> expectedPayer = [new("x")];

        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.NotNull(model.Payer);
        Assert.Equal(expectedPayer.Count, model.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], model.Payer[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id", Payer = [new("x")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoidedCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id", Payer = [new("x")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoidedCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountNumberID = "account_number_id";
        List<Payer> expectedPayer = [new("x")];

        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.NotNull(deserialized.Payer);
        Assert.Equal(expectedPayer.Count, deserialized.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], deserialized.Payer[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id", Payer = [new("x")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id" };

        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoidedCheck
        {
            AccountNumberID = "account_number_id",

            // Null should be interpreted as omitted for these properties
            Payer = null,
        };

        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoidedCheck
        {
            AccountNumberID = "account_number_id",

            // Null should be interpreted as omitted for these properties
            Payer = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoidedCheck { AccountNumberID = "account_number_id", Payer = [new("x")] };

        VoidedCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Payer { Line = "x" };

        string expectedLine = "x";

        Assert.Equal(expectedLine, model.Line);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payer { Line = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Payer { Line = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payer>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedLine = "x";

        Assert.Equal(expectedLine, deserialized.Line);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payer { Line = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payer { Line = "x" };

        Payer copied = new(model);

        Assert.Equal(model, copied);
    }
}
