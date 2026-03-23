using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Exports;

/// <summary>
/// Exports are generated files. Some exports can contain a lot of data, like a CSV
/// of your transactions. Others can be a single document, like a tax form. Since
/// they can take a while, they are generated asynchronously. We send a webhook when
/// they are ready. For more information, please read our [Exports documentation](https://increase.com/documentation/exports).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Export, ExportFromRaw>))]
public sealed record class Export : JsonModel
{
    /// <summary>
    /// The Export identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Details of the account statement BAI2 export. This field will be present
    /// when the `category` is equal to `account_statement_bai2`.
    /// </summary>
    public required ExportAccountStatementBai2? AccountStatementBai2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportAccountStatementBai2>(
                "account_statement_bai2"
            );
        }
        init { this._rawData.Set("account_statement_bai2", value); }
    }

    /// <summary>
    /// Details of the account statement OFX export. This field will be present when
    /// the `category` is equal to `account_statement_ofx`.
    /// </summary>
    public required ExportAccountStatementOfx? AccountStatementOfx
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportAccountStatementOfx>(
                "account_statement_ofx"
            );
        }
        init { this._rawData.Set("account_statement_ofx", value); }
    }

    /// <summary>
    /// Details of the account verification letter export. This field will be present
    /// when the `category` is equal to `account_verification_letter`.
    /// </summary>
    public required ExportAccountVerificationLetter? AccountVerificationLetter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportAccountVerificationLetter>(
                "account_verification_letter"
            );
        }
        init { this._rawData.Set("account_verification_letter", value); }
    }

    /// <summary>
    /// Details of the balance CSV export. This field will be present when the `category`
    /// is equal to `balance_csv`.
    /// </summary>
    public required ExportBalanceCsv? BalanceCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportBalanceCsv>("balance_csv");
        }
        init { this._rawData.Set("balance_csv", value); }
    }

    /// <summary>
    /// Details of the bookkeeping account balance CSV export. This field will be
    /// present when the `category` is equal to `bookkeeping_account_balance_csv`.
    /// </summary>
    public required ExportBookkeepingAccountBalanceCsv? BookkeepingAccountBalanceCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportBookkeepingAccountBalanceCsv>(
                "bookkeeping_account_balance_csv"
            );
        }
        init { this._rawData.Set("bookkeeping_account_balance_csv", value); }
    }

    /// <summary>
    /// The category of the Export. We may add additional possible values for this
    /// enum over time; your application should be able to handle that gracefully.
    /// </summary>
    public required ApiEnum<string, ExportCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExportCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The time the Export was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Details of the dashboard table CSV export. This field will be present when
    /// the `category` is equal to `dashboard_table_csv`.
    /// </summary>
    public required DashboardTableCsv? DashboardTableCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DashboardTableCsv>("dashboard_table_csv");
        }
        init { this._rawData.Set("dashboard_table_csv", value); }
    }

    /// <summary>
    /// Details of the entity CSV export. This field will be present when the `category`
    /// is equal to `entity_csv`.
    /// </summary>
    public required ExportEntityCsv? EntityCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportEntityCsv>("entity_csv");
        }
        init { this._rawData.Set("entity_csv", value); }
    }

    /// <summary>
    /// Details of the fee CSV export. This field will be present when the `category`
    /// is equal to `fee_csv`.
    /// </summary>
    public required FeeCsv? FeeCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeeCsv>("fee_csv");
        }
        init { this._rawData.Set("fee_csv", value); }
    }

    /// <summary>
    /// Details of the Form 1099-INT export. This field will be present when the `category`
    /// is equal to `form_1099_int`.
    /// </summary>
    public required ExportForm1099Int? Form1099Int
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportForm1099Int>("form_1099_int");
        }
        init { this._rawData.Set("form_1099_int", value); }
    }

    /// <summary>
    /// Details of the Form 1099-MISC export. This field will be present when the
    /// `category` is equal to `form_1099_misc`.
    /// </summary>
    public required ExportForm1099Misc? Form1099Misc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportForm1099Misc>("form_1099_misc");
        }
        init { this._rawData.Set("form_1099_misc", value); }
    }

    /// <summary>
    /// Details of the funding instructions export. This field will be present when
    /// the `category` is equal to `funding_instructions`.
    /// </summary>
    public required ExportFundingInstructions? FundingInstructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportFundingInstructions>(
                "funding_instructions"
            );
        }
        init { this._rawData.Set("funding_instructions", value); }
    }

    /// <summary>
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// The result of the Export. This will be present when the Export's status transitions
    /// to `complete`.
    /// </summary>
    public required Result? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Result>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// The status of the Export.
    /// </summary>
    public required ApiEnum<string, ExportStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExportStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Details of the transaction CSV export. This field will be present when the
    /// `category` is equal to `transaction_csv`.
    /// </summary>
    public required ExportTransactionCsv? TransactionCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportTransactionCsv>("transaction_csv");
        }
        init { this._rawData.Set("transaction_csv", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `export`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Exports.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Exports.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Details of the vendor CSV export. This field will be present when the `category`
    /// is equal to `vendor_csv`.
    /// </summary>
    public required ExportVendorCsv? VendorCsv
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportVendorCsv>("vendor_csv");
        }
        init { this._rawData.Set("vendor_csv", value); }
    }

    /// <summary>
    /// Details of the voided check export. This field will be present when the `category`
    /// is equal to `voided_check`.
    /// </summary>
    public required ExportVoidedCheck? VoidedCheck
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportVoidedCheck>("voided_check");
        }
        init { this._rawData.Set("voided_check", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AccountStatementBai2?.Validate();
        this.AccountStatementOfx?.Validate();
        this.AccountVerificationLetter?.Validate();
        this.BalanceCsv?.Validate();
        this.BookkeepingAccountBalanceCsv?.Validate();
        this.Category.Validate();
        _ = this.CreatedAt;
        this.DashboardTableCsv?.Validate();
        this.EntityCsv?.Validate();
        this.FeeCsv?.Validate();
        this.Form1099Int?.Validate();
        this.Form1099Misc?.Validate();
        this.FundingInstructions?.Validate();
        _ = this.IdempotencyKey;
        this.Result?.Validate();
        this.Status.Validate();
        this.TransactionCsv?.Validate();
        this.Type.Validate();
        this.VendorCsv?.Validate();
        this.VoidedCheck?.Validate();
    }

    public Export() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Export(Export export)
        : base(export) { }
#pragma warning restore CS8618

    public Export(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Export(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportFromRaw.FromRawUnchecked"/>
    public static Export FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportFromRaw : IFromRawJson<Export>
{
    /// <inheritdoc/>
    public Export FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Export.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the account statement BAI2 export. This field will be present when
/// the `category` is equal to `account_statement_bai2`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExportAccountStatementBai2, ExportAccountStatementBai2FromRaw>)
)]
public sealed record class ExportAccountStatementBai2 : JsonModel
{
    /// <summary>
    /// Filter results by Account.
    /// </summary>
    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The date for which to retrieve the balance.
    /// </summary>
    public required string? EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    /// <summary>
    /// Filter results by Program.
    /// </summary>
    public required string? ProgramID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("program_id");
        }
        init { this._rawData.Set("program_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.EffectiveDate;
        _ = this.ProgramID;
    }

    public ExportAccountStatementBai2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportAccountStatementBai2(ExportAccountStatementBai2 exportAccountStatementBai2)
        : base(exportAccountStatementBai2) { }
#pragma warning restore CS8618

    public ExportAccountStatementBai2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportAccountStatementBai2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportAccountStatementBai2FromRaw.FromRawUnchecked"/>
    public static ExportAccountStatementBai2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportAccountStatementBai2FromRaw : IFromRawJson<ExportAccountStatementBai2>
{
    /// <inheritdoc/>
    public ExportAccountStatementBai2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportAccountStatementBai2.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the account statement OFX export. This field will be present when the
/// `category` is equal to `account_statement_ofx`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExportAccountStatementOfx, ExportAccountStatementOfxFromRaw>)
)]
public sealed record class ExportAccountStatementOfx : JsonModel
{
    /// <summary>
    /// The Account to create a statement for.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Filter transactions by their created date.
    /// </summary>
    public required ExportAccountStatementOfxCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportAccountStatementOfxCreatedAt>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.CreatedAt?.Validate();
    }

    public ExportAccountStatementOfx() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportAccountStatementOfx(ExportAccountStatementOfx exportAccountStatementOfx)
        : base(exportAccountStatementOfx) { }
#pragma warning restore CS8618

    public ExportAccountStatementOfx(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportAccountStatementOfx(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportAccountStatementOfxFromRaw.FromRawUnchecked"/>
    public static ExportAccountStatementOfx FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportAccountStatementOfxFromRaw : IFromRawJson<ExportAccountStatementOfx>
{
    /// <inheritdoc/>
    public ExportAccountStatementOfx FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportAccountStatementOfx.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter transactions by their created date.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExportAccountStatementOfxCreatedAt,
        ExportAccountStatementOfxCreatedAtFromRaw
    >)
)]
public sealed record class ExportAccountStatementOfxCreatedAt : JsonModel
{
    /// <summary>
    /// Filter results to transactions created after this time.
    /// </summary>
    public required System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Filter results to transactions created before this time.
    /// </summary>
    public required System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public ExportAccountStatementOfxCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportAccountStatementOfxCreatedAt(
        ExportAccountStatementOfxCreatedAt exportAccountStatementOfxCreatedAt
    )
        : base(exportAccountStatementOfxCreatedAt) { }
#pragma warning restore CS8618

    public ExportAccountStatementOfxCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportAccountStatementOfxCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportAccountStatementOfxCreatedAtFromRaw.FromRawUnchecked"/>
    public static ExportAccountStatementOfxCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportAccountStatementOfxCreatedAtFromRaw : IFromRawJson<ExportAccountStatementOfxCreatedAt>
{
    /// <inheritdoc/>
    public ExportAccountStatementOfxCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportAccountStatementOfxCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the account verification letter export. This field will be present
/// when the `category` is equal to `account_verification_letter`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExportAccountVerificationLetter,
        ExportAccountVerificationLetterFromRaw
    >)
)]
public sealed record class ExportAccountVerificationLetter : JsonModel
{
    /// <summary>
    /// The Account Number to create a letter for.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <summary>
    /// The date of the balance to include in the letter.
    /// </summary>
    public required string? BalanceDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("balance_date");
        }
        init { this._rawData.Set("balance_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumberID;
        _ = this.BalanceDate;
    }

    public ExportAccountVerificationLetter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportAccountVerificationLetter(
        ExportAccountVerificationLetter exportAccountVerificationLetter
    )
        : base(exportAccountVerificationLetter) { }
#pragma warning restore CS8618

    public ExportAccountVerificationLetter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportAccountVerificationLetter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportAccountVerificationLetterFromRaw.FromRawUnchecked"/>
    public static ExportAccountVerificationLetter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportAccountVerificationLetterFromRaw : IFromRawJson<ExportAccountVerificationLetter>
{
    /// <inheritdoc/>
    public ExportAccountVerificationLetter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportAccountVerificationLetter.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the balance CSV export. This field will be present when the `category`
/// is equal to `balance_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportBalanceCsv, ExportBalanceCsvFromRaw>))]
public sealed record class ExportBalanceCsv : JsonModel
{
    /// <summary>
    /// Filter results by Account.
    /// </summary>
    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Filter balances by their created date.
    /// </summary>
    public required ExportBalanceCsvCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportBalanceCsvCreatedAt>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.CreatedAt?.Validate();
    }

    public ExportBalanceCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportBalanceCsv(ExportBalanceCsv exportBalanceCsv)
        : base(exportBalanceCsv) { }
#pragma warning restore CS8618

    public ExportBalanceCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportBalanceCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportBalanceCsvFromRaw.FromRawUnchecked"/>
    public static ExportBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportBalanceCsvFromRaw : IFromRawJson<ExportBalanceCsv>
{
    /// <inheritdoc/>
    public ExportBalanceCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExportBalanceCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter balances by their created date.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExportBalanceCsvCreatedAt, ExportBalanceCsvCreatedAtFromRaw>)
)]
public sealed record class ExportBalanceCsvCreatedAt : JsonModel
{
    /// <summary>
    /// Filter balances created after this time.
    /// </summary>
    public required System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Filter balances created before this time.
    /// </summary>
    public required System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public ExportBalanceCsvCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportBalanceCsvCreatedAt(ExportBalanceCsvCreatedAt exportBalanceCsvCreatedAt)
        : base(exportBalanceCsvCreatedAt) { }
#pragma warning restore CS8618

    public ExportBalanceCsvCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportBalanceCsvCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportBalanceCsvCreatedAtFromRaw.FromRawUnchecked"/>
    public static ExportBalanceCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportBalanceCsvCreatedAtFromRaw : IFromRawJson<ExportBalanceCsvCreatedAt>
{
    /// <inheritdoc/>
    public ExportBalanceCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportBalanceCsvCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the bookkeeping account balance CSV export. This field will be present
/// when the `category` is equal to `bookkeeping_account_balance_csv`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExportBookkeepingAccountBalanceCsv,
        ExportBookkeepingAccountBalanceCsvFromRaw
    >)
)]
public sealed record class ExportBookkeepingAccountBalanceCsv : JsonModel
{
    /// <summary>
    /// Filter results by Bookkeeping Account.
    /// </summary>
    public required string? BookkeepingAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bookkeeping_account_id");
        }
        init { this._rawData.Set("bookkeeping_account_id", value); }
    }

    /// <summary>
    /// Filter balances by their created date.
    /// </summary>
    public required ExportBookkeepingAccountBalanceCsvCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportBookkeepingAccountBalanceCsvCreatedAt>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BookkeepingAccountID;
        this.CreatedAt?.Validate();
    }

    public ExportBookkeepingAccountBalanceCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportBookkeepingAccountBalanceCsv(
        ExportBookkeepingAccountBalanceCsv exportBookkeepingAccountBalanceCsv
    )
        : base(exportBookkeepingAccountBalanceCsv) { }
#pragma warning restore CS8618

    public ExportBookkeepingAccountBalanceCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportBookkeepingAccountBalanceCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportBookkeepingAccountBalanceCsvFromRaw.FromRawUnchecked"/>
    public static ExportBookkeepingAccountBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportBookkeepingAccountBalanceCsvFromRaw : IFromRawJson<ExportBookkeepingAccountBalanceCsv>
{
    /// <inheritdoc/>
    public ExportBookkeepingAccountBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportBookkeepingAccountBalanceCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter balances by their created date.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExportBookkeepingAccountBalanceCsvCreatedAt,
        ExportBookkeepingAccountBalanceCsvCreatedAtFromRaw
    >)
)]
public sealed record class ExportBookkeepingAccountBalanceCsvCreatedAt : JsonModel
{
    /// <summary>
    /// Filter balances created after this time.
    /// </summary>
    public required System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Filter balances created before this time.
    /// </summary>
    public required System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public ExportBookkeepingAccountBalanceCsvCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportBookkeepingAccountBalanceCsvCreatedAt(
        ExportBookkeepingAccountBalanceCsvCreatedAt exportBookkeepingAccountBalanceCsvCreatedAt
    )
        : base(exportBookkeepingAccountBalanceCsvCreatedAt) { }
#pragma warning restore CS8618

    public ExportBookkeepingAccountBalanceCsvCreatedAt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportBookkeepingAccountBalanceCsvCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportBookkeepingAccountBalanceCsvCreatedAtFromRaw.FromRawUnchecked"/>
    public static ExportBookkeepingAccountBalanceCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportBookkeepingAccountBalanceCsvCreatedAtFromRaw
    : IFromRawJson<ExportBookkeepingAccountBalanceCsvCreatedAt>
{
    /// <inheritdoc/>
    public ExportBookkeepingAccountBalanceCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportBookkeepingAccountBalanceCsvCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the Export. We may add additional possible values for this enum
/// over time; your application should be able to handle that gracefully.
/// </summary>
[JsonConverter(typeof(ExportCategoryConverter))]
public enum ExportCategory
{
    /// <summary>
    /// Export an Open Financial Exchange (OFX) file of transactions and balances
    /// for a given time range and Account.
    /// </summary>
    AccountStatementOfx,

    /// <summary>
    /// Export a BAI2 file of transactions and balances for a given date and optional Account.
    /// </summary>
    AccountStatementBai2,

    /// <summary>
    /// Export a CSV of all transactions for a given time range.
    /// </summary>
    TransactionCsv,

    /// <summary>
    /// Export a CSV of account balances for the dates in a given range.
    /// </summary>
    BalanceCsv,

    /// <summary>
    /// Export a CSV of bookkeeping account balances for the dates in a given range.
    /// </summary>
    BookkeepingAccountBalanceCsv,

    /// <summary>
    /// Export a CSV of entities with a given status.
    /// </summary>
    EntityCsv,

    /// <summary>
    /// Export a CSV of vendors added to the third-party risk management dashboard.
    /// </summary>
    VendorCsv,

    /// <summary>
    /// Certain dashboard tables are available as CSV exports. This export cannot
    /// be created via the API.
    /// </summary>
    DashboardTableCsv,

    /// <summary>
    /// A PDF of an account verification letter.
    /// </summary>
    AccountVerificationLetter,

    /// <summary>
    /// A PDF of funding instructions.
    /// </summary>
    FundingInstructions,

    /// <summary>
    /// A PDF of an Internal Revenue Service Form 1099-INT.
    /// </summary>
    Form1099Int,

    /// <summary>
    /// A PDF of an Internal Revenue Service Form 1099-MISC.
    /// </summary>
    Form1099Misc,

    /// <summary>
    /// Export a CSV of fees. The time range must not include any fees that are part
    /// of an open fee statement.
    /// </summary>
    FeeCsv,

    /// <summary>
    /// A PDF of a voided check.
    /// </summary>
    VoidedCheck,
}

sealed class ExportCategoryConverter : JsonConverter<ExportCategory>
{
    public override ExportCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_statement_ofx" => ExportCategory.AccountStatementOfx,
            "account_statement_bai2" => ExportCategory.AccountStatementBai2,
            "transaction_csv" => ExportCategory.TransactionCsv,
            "balance_csv" => ExportCategory.BalanceCsv,
            "bookkeeping_account_balance_csv" => ExportCategory.BookkeepingAccountBalanceCsv,
            "entity_csv" => ExportCategory.EntityCsv,
            "vendor_csv" => ExportCategory.VendorCsv,
            "dashboard_table_csv" => ExportCategory.DashboardTableCsv,
            "account_verification_letter" => ExportCategory.AccountVerificationLetter,
            "funding_instructions" => ExportCategory.FundingInstructions,
            "form_1099_int" => ExportCategory.Form1099Int,
            "form_1099_misc" => ExportCategory.Form1099Misc,
            "fee_csv" => ExportCategory.FeeCsv,
            "voided_check" => ExportCategory.VoidedCheck,
            _ => (ExportCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExportCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExportCategory.AccountStatementOfx => "account_statement_ofx",
                ExportCategory.AccountStatementBai2 => "account_statement_bai2",
                ExportCategory.TransactionCsv => "transaction_csv",
                ExportCategory.BalanceCsv => "balance_csv",
                ExportCategory.BookkeepingAccountBalanceCsv => "bookkeeping_account_balance_csv",
                ExportCategory.EntityCsv => "entity_csv",
                ExportCategory.VendorCsv => "vendor_csv",
                ExportCategory.DashboardTableCsv => "dashboard_table_csv",
                ExportCategory.AccountVerificationLetter => "account_verification_letter",
                ExportCategory.FundingInstructions => "funding_instructions",
                ExportCategory.Form1099Int => "form_1099_int",
                ExportCategory.Form1099Misc => "form_1099_misc",
                ExportCategory.FeeCsv => "fee_csv",
                ExportCategory.VoidedCheck => "voided_check",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the dashboard table CSV export. This field will be present when the
/// `category` is equal to `dashboard_table_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DashboardTableCsv, DashboardTableCsvFromRaw>))]
public sealed record class DashboardTableCsv : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public DashboardTableCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DashboardTableCsv(DashboardTableCsv dashboardTableCsv)
        : base(dashboardTableCsv) { }
#pragma warning restore CS8618

    public DashboardTableCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DashboardTableCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DashboardTableCsvFromRaw.FromRawUnchecked"/>
    public static DashboardTableCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DashboardTableCsvFromRaw : IFromRawJson<DashboardTableCsv>
{
    /// <inheritdoc/>
    public DashboardTableCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DashboardTableCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the entity CSV export. This field will be present when the `category`
/// is equal to `entity_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportEntityCsv, ExportEntityCsvFromRaw>))]
public sealed record class ExportEntityCsv : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ExportEntityCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportEntityCsv(ExportEntityCsv exportEntityCsv)
        : base(exportEntityCsv) { }
#pragma warning restore CS8618

    public ExportEntityCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportEntityCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportEntityCsvFromRaw.FromRawUnchecked"/>
    public static ExportEntityCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportEntityCsvFromRaw : IFromRawJson<ExportEntityCsv>
{
    /// <inheritdoc/>
    public ExportEntityCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExportEntityCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the fee CSV export. This field will be present when the `category`
/// is equal to `fee_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FeeCsv, FeeCsvFromRaw>))]
public sealed record class FeeCsv : JsonModel
{
    /// <summary>
    /// Filter fees by their created date. The time range must not include any fees
    /// that are part of an open fee statement.
    /// </summary>
    public required FeeCsvCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeeCsvCreatedAt>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CreatedAt?.Validate();
    }

    public FeeCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeeCsv(FeeCsv feeCsv)
        : base(feeCsv) { }
#pragma warning restore CS8618

    public FeeCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeeCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeeCsvFromRaw.FromRawUnchecked"/>
    public static FeeCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeeCsv(FeeCsvCreatedAt? createdAt)
        : this()
    {
        this.CreatedAt = createdAt;
    }
}

class FeeCsvFromRaw : IFromRawJson<FeeCsv>
{
    /// <inheritdoc/>
    public FeeCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeeCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter fees by their created date. The time range must not include any fees that
/// are part of an open fee statement.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FeeCsvCreatedAt, FeeCsvCreatedAtFromRaw>))]
public sealed record class FeeCsvCreatedAt : JsonModel
{
    /// <summary>
    /// Filter fees created after this time.
    /// </summary>
    public required System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Filter fees created before this time.
    /// </summary>
    public required System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public FeeCsvCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeeCsvCreatedAt(FeeCsvCreatedAt feeCsvCreatedAt)
        : base(feeCsvCreatedAt) { }
#pragma warning restore CS8618

    public FeeCsvCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeeCsvCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeeCsvCreatedAtFromRaw.FromRawUnchecked"/>
    public static FeeCsvCreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeeCsvCreatedAtFromRaw : IFromRawJson<FeeCsvCreatedAt>
{
    /// <inheritdoc/>
    public FeeCsvCreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeeCsvCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the Form 1099-INT export. This field will be present when the `category`
/// is equal to `form_1099_int`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportForm1099Int, ExportForm1099IntFromRaw>))]
public sealed record class ExportForm1099Int : JsonModel
{
    /// <summary>
    /// The Account the tax form is for.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Whether the tax form is a corrected form.
    /// </summary>
    public required bool Corrected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("corrected");
        }
        init { this._rawData.Set("corrected", value); }
    }

    /// <summary>
    /// A description of the tax form.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The tax year for the tax form.
    /// </summary>
    public required long Year
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("year");
        }
        init { this._rawData.Set("year", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.Corrected;
        _ = this.Description;
        _ = this.Year;
    }

    public ExportForm1099Int() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportForm1099Int(ExportForm1099Int exportForm1099Int)
        : base(exportForm1099Int) { }
#pragma warning restore CS8618

    public ExportForm1099Int(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportForm1099Int(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportForm1099IntFromRaw.FromRawUnchecked"/>
    public static ExportForm1099Int FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportForm1099IntFromRaw : IFromRawJson<ExportForm1099Int>
{
    /// <inheritdoc/>
    public ExportForm1099Int FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExportForm1099Int.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the Form 1099-MISC export. This field will be present when the `category`
/// is equal to `form_1099_misc`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportForm1099Misc, ExportForm1099MiscFromRaw>))]
public sealed record class ExportForm1099Misc : JsonModel
{
    /// <summary>
    /// The Account the tax form is for.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Whether the tax form is a corrected form.
    /// </summary>
    public required bool Corrected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("corrected");
        }
        init { this._rawData.Set("corrected", value); }
    }

    /// <summary>
    /// The tax year for the tax form.
    /// </summary>
    public required long Year
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("year");
        }
        init { this._rawData.Set("year", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.Corrected;
        _ = this.Year;
    }

    public ExportForm1099Misc() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportForm1099Misc(ExportForm1099Misc exportForm1099Misc)
        : base(exportForm1099Misc) { }
#pragma warning restore CS8618

    public ExportForm1099Misc(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportForm1099Misc(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportForm1099MiscFromRaw.FromRawUnchecked"/>
    public static ExportForm1099Misc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportForm1099MiscFromRaw : IFromRawJson<ExportForm1099Misc>
{
    /// <inheritdoc/>
    public ExportForm1099Misc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExportForm1099Misc.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the funding instructions export. This field will be present when the
/// `category` is equal to `funding_instructions`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExportFundingInstructions, ExportFundingInstructionsFromRaw>)
)]
public sealed record class ExportFundingInstructions : JsonModel
{
    /// <summary>
    /// The Account Number to create funding instructions for.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumberID;
    }

    public ExportFundingInstructions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportFundingInstructions(ExportFundingInstructions exportFundingInstructions)
        : base(exportFundingInstructions) { }
#pragma warning restore CS8618

    public ExportFundingInstructions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportFundingInstructions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportFundingInstructionsFromRaw.FromRawUnchecked"/>
    public static ExportFundingInstructions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExportFundingInstructions(string accountNumberID)
        : this()
    {
        this.AccountNumberID = accountNumberID;
    }
}

class ExportFundingInstructionsFromRaw : IFromRawJson<ExportFundingInstructions>
{
    /// <inheritdoc/>
    public ExportFundingInstructions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportFundingInstructions.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of the Export. This will be present when the Export's status transitions
/// to `complete`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// The File containing the contents of the Export.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Result(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the Export.
/// </summary>
[JsonConverter(typeof(ExportStatusConverter))]
public enum ExportStatus
{
    /// <summary>
    /// Increase is generating the export.
    /// </summary>
    Pending,

    /// <summary>
    /// The export has been successfully generated.
    /// </summary>
    Complete,

    /// <summary>
    /// The export failed to generate. Increase will reach out to you to resolve the issue.
    /// </summary>
    Failed,
}

sealed class ExportStatusConverter : JsonConverter<ExportStatus>
{
    public override ExportStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ExportStatus.Pending,
            "complete" => ExportStatus.Complete,
            "failed" => ExportStatus.Failed,
            _ => (ExportStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExportStatus.Pending => "pending",
                ExportStatus.Complete => "complete",
                ExportStatus.Failed => "failed",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the transaction CSV export. This field will be present when the `category`
/// is equal to `transaction_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportTransactionCsv, ExportTransactionCsvFromRaw>))]
public sealed record class ExportTransactionCsv : JsonModel
{
    /// <summary>
    /// Filter results by Account.
    /// </summary>
    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Filter transactions by their created date.
    /// </summary>
    public required ExportTransactionCsvCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportTransactionCsvCreatedAt>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.CreatedAt?.Validate();
    }

    public ExportTransactionCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportTransactionCsv(ExportTransactionCsv exportTransactionCsv)
        : base(exportTransactionCsv) { }
#pragma warning restore CS8618

    public ExportTransactionCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportTransactionCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportTransactionCsvFromRaw.FromRawUnchecked"/>
    public static ExportTransactionCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportTransactionCsvFromRaw : IFromRawJson<ExportTransactionCsv>
{
    /// <inheritdoc/>
    public ExportTransactionCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportTransactionCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter transactions by their created date.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExportTransactionCsvCreatedAt, ExportTransactionCsvCreatedAtFromRaw>)
)]
public sealed record class ExportTransactionCsvCreatedAt : JsonModel
{
    /// <summary>
    /// Filter transactions created after this time.
    /// </summary>
    public required System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init { this._rawData.Set("after", value); }
    }

    /// <summary>
    /// Filter transactions created before this time.
    /// </summary>
    public required System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init { this._rawData.Set("before", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public ExportTransactionCsvCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportTransactionCsvCreatedAt(
        ExportTransactionCsvCreatedAt exportTransactionCsvCreatedAt
    )
        : base(exportTransactionCsvCreatedAt) { }
#pragma warning restore CS8618

    public ExportTransactionCsvCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportTransactionCsvCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportTransactionCsvCreatedAtFromRaw.FromRawUnchecked"/>
    public static ExportTransactionCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportTransactionCsvCreatedAtFromRaw : IFromRawJson<ExportTransactionCsvCreatedAt>
{
    /// <inheritdoc/>
    public ExportTransactionCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportTransactionCsvCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `export`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Export,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Exports.Type>
{
    public override global::Increase.Api.Models.Exports.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "export" => global::Increase.Api.Models.Exports.Type.Export,
            _ => (global::Increase.Api.Models.Exports.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Exports.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Exports.Type.Export => "export",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the vendor CSV export. This field will be present when the `category`
/// is equal to `vendor_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportVendorCsv, ExportVendorCsvFromRaw>))]
public sealed record class ExportVendorCsv : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ExportVendorCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportVendorCsv(ExportVendorCsv exportVendorCsv)
        : base(exportVendorCsv) { }
#pragma warning restore CS8618

    public ExportVendorCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportVendorCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportVendorCsvFromRaw.FromRawUnchecked"/>
    public static ExportVendorCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportVendorCsvFromRaw : IFromRawJson<ExportVendorCsv>
{
    /// <inheritdoc/>
    public ExportVendorCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExportVendorCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the voided check export. This field will be present when the `category`
/// is equal to `voided_check`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportVoidedCheck, ExportVoidedCheckFromRaw>))]
public sealed record class ExportVoidedCheck : JsonModel
{
    /// <summary>
    /// The Account Number for the voided check.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <summary>
    /// The payer information printed on the check.
    /// </summary>
    public required IReadOnlyList<ExportVoidedCheckPayer> Payer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExportVoidedCheckPayer>>("payer");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExportVoidedCheckPayer>>(
                "payer",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumberID;
        foreach (var item in this.Payer)
        {
            item.Validate();
        }
    }

    public ExportVoidedCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportVoidedCheck(ExportVoidedCheck exportVoidedCheck)
        : base(exportVoidedCheck) { }
#pragma warning restore CS8618

    public ExportVoidedCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportVoidedCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportVoidedCheckFromRaw.FromRawUnchecked"/>
    public static ExportVoidedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExportVoidedCheckFromRaw : IFromRawJson<ExportVoidedCheck>
{
    /// <inheritdoc/>
    public ExportVoidedCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExportVoidedCheck.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ExportVoidedCheckPayer, ExportVoidedCheckPayerFromRaw>))]
public sealed record class ExportVoidedCheckPayer : JsonModel
{
    /// <summary>
    /// The contents of the line.
    /// </summary>
    public required string Line
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line");
        }
        init { this._rawData.Set("line", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Line;
    }

    public ExportVoidedCheckPayer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportVoidedCheckPayer(ExportVoidedCheckPayer exportVoidedCheckPayer)
        : base(exportVoidedCheckPayer) { }
#pragma warning restore CS8618

    public ExportVoidedCheckPayer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportVoidedCheckPayer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExportVoidedCheckPayerFromRaw.FromRawUnchecked"/>
    public static ExportVoidedCheckPayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExportVoidedCheckPayer(string line)
        : this()
    {
        this.Line = line;
    }
}

class ExportVoidedCheckPayerFromRaw : IFromRawJson<ExportVoidedCheckPayer>
{
    /// <inheritdoc/>
    public ExportVoidedCheckPayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExportVoidedCheckPayer.FromRawUnchecked(rawData);
}
