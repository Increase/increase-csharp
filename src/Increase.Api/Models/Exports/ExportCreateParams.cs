using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Exports;

/// <summary>
/// Create an Export
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExportCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The type of Export to create.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawBodyData.Set("category", value); }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `account_statement_bai2`.
    /// </summary>
    public AccountStatementBai2? AccountStatementBai2
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AccountStatementBai2>(
                "account_statement_bai2"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("account_statement_bai2", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `account_statement_ofx`.
    /// </summary>
    public AccountStatementOfx? AccountStatementOfx
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AccountStatementOfx>("account_statement_ofx");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("account_statement_ofx", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `account_verification_letter`.
    /// </summary>
    public AccountVerificationLetter? AccountVerificationLetter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AccountVerificationLetter>(
                "account_verification_letter"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("account_verification_letter", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `balance_csv`.
    /// </summary>
    public BalanceCsv? BalanceCsv
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BalanceCsv>("balance_csv");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("balance_csv", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `bookkeeping_account_balance_csv`.
    /// </summary>
    public BookkeepingAccountBalanceCsv? BookkeepingAccountBalanceCsv
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BookkeepingAccountBalanceCsv>(
                "bookkeeping_account_balance_csv"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("bookkeeping_account_balance_csv", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `daily_account_balance_csv`.
    /// </summary>
    public DailyAccountBalanceCsv? DailyAccountBalanceCsv
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DailyAccountBalanceCsv>(
                "daily_account_balance_csv"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("daily_account_balance_csv", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `entity_csv`.
    /// </summary>
    public EntityCsv? EntityCsv
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityCsv>("entity_csv");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entity_csv", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `funding_instructions`.
    /// </summary>
    public FundingInstructions? FundingInstructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FundingInstructions>("funding_instructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("funding_instructions", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `transaction_csv`.
    /// </summary>
    public TransactionCsv? TransactionCsv
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TransactionCsv>("transaction_csv");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transaction_csv", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `vendor_csv`.
    /// </summary>
    public VendorCsv? VendorCsv
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VendorCsv>("vendor_csv");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("vendor_csv", value);
        }
    }

    /// <summary>
    /// Options for the created export. Required if `category` is equal to `voided_check`.
    /// </summary>
    public VoidedCheck? VoidedCheck
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VoidedCheck>("voided_check");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("voided_check", value);
        }
    }

    public ExportCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportCreateParams(ExportCreateParams exportCreateParams)
        : base(exportCreateParams)
    {
        this._rawBodyData = new(exportCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExportCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExportCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExportCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/exports")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The type of Export to create.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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
    /// A PDF of an account verification letter.
    /// </summary>
    AccountVerificationLetter,

    /// <summary>
    /// A PDF of funding instructions.
    /// </summary>
    FundingInstructions,

    /// <summary>
    /// A PDF of a voided check.
    /// </summary>
    VoidedCheck,

    /// <summary>
    /// Export a CSV of daily account balances with starting and ending balances
    /// for a given date range.
    /// </summary>
    DailyAccountBalanceCsv,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_statement_ofx" => Category.AccountStatementOfx,
            "account_statement_bai2" => Category.AccountStatementBai2,
            "transaction_csv" => Category.TransactionCsv,
            "balance_csv" => Category.BalanceCsv,
            "bookkeeping_account_balance_csv" => Category.BookkeepingAccountBalanceCsv,
            "entity_csv" => Category.EntityCsv,
            "vendor_csv" => Category.VendorCsv,
            "account_verification_letter" => Category.AccountVerificationLetter,
            "funding_instructions" => Category.FundingInstructions,
            "voided_check" => Category.VoidedCheck,
            "daily_account_balance_csv" => Category.DailyAccountBalanceCsv,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.AccountStatementOfx => "account_statement_ofx",
                Category.AccountStatementBai2 => "account_statement_bai2",
                Category.TransactionCsv => "transaction_csv",
                Category.BalanceCsv => "balance_csv",
                Category.BookkeepingAccountBalanceCsv => "bookkeeping_account_balance_csv",
                Category.EntityCsv => "entity_csv",
                Category.VendorCsv => "vendor_csv",
                Category.AccountVerificationLetter => "account_verification_letter",
                Category.FundingInstructions => "funding_instructions",
                Category.VoidedCheck => "voided_check",
                Category.DailyAccountBalanceCsv => "daily_account_balance_csv",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `account_statement_bai2`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountStatementBai2, AccountStatementBai2FromRaw>))]
public sealed record class AccountStatementBai2 : JsonModel
{
    /// <summary>
    /// The Account to create a BAI2 report for. If not provided, all open accounts
    /// will be included.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// The date to create a BAI2 report for. If not provided, the current date will
    /// be used. The timezone is UTC. If the current date is used, the report will
    /// include intraday balances, otherwise it will include end-of-day balances for
    /// the provided date.
    /// </summary>
    public string? EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("effective_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effective_date", value);
        }
    }

    /// <summary>
    /// The Program to create a BAI2 report for. If not provided, all open accounts
    /// will be included.
    /// </summary>
    public string? ProgramID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("program_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("program_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.EffectiveDate;
        _ = this.ProgramID;
    }

    public AccountStatementBai2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountStatementBai2(AccountStatementBai2 accountStatementBai2)
        : base(accountStatementBai2) { }
#pragma warning restore CS8618

    public AccountStatementBai2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountStatementBai2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountStatementBai2FromRaw.FromRawUnchecked"/>
    public static AccountStatementBai2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountStatementBai2FromRaw : IFromRawJson<AccountStatementBai2>
{
    /// <inheritdoc/>
    public AccountStatementBai2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountStatementBai2.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `account_statement_ofx`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountStatementOfx, AccountStatementOfxFromRaw>))]
public sealed record class AccountStatementOfx : JsonModel
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
    public CreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.CreatedAt?.Validate();
    }

    public AccountStatementOfx() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountStatementOfx(AccountStatementOfx accountStatementOfx)
        : base(accountStatementOfx) { }
#pragma warning restore CS8618

    public AccountStatementOfx(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountStatementOfx(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountStatementOfxFromRaw.FromRawUnchecked"/>
    public static AccountStatementOfx FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountStatementOfx(string accountID)
        : this()
    {
        this.AccountID = accountID;
    }
}

class AccountStatementOfxFromRaw : IFromRawJson<AccountStatementOfx>
{
    /// <inheritdoc/>
    public AccountStatementOfx FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountStatementOfx.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter transactions by their created date.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Filter results to transactions created before this time.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Filter results to transactions created on or after this time.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Before;
        _ = this.OnOrAfter;
    }

    public CreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt(CreatedAt createdAt)
        : base(createdAt) { }
#pragma warning restore CS8618

    public CreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `account_verification_letter`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AccountVerificationLetter, AccountVerificationLetterFromRaw>)
)]
public sealed record class AccountVerificationLetter : JsonModel
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
    /// The date of the balance to include in the letter. Defaults to the current date.
    /// </summary>
    public string? BalanceDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("balance_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("balance_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumberID;
        _ = this.BalanceDate;
    }

    public AccountVerificationLetter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountVerificationLetter(AccountVerificationLetter accountVerificationLetter)
        : base(accountVerificationLetter) { }
#pragma warning restore CS8618

    public AccountVerificationLetter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountVerificationLetter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountVerificationLetterFromRaw.FromRawUnchecked"/>
    public static AccountVerificationLetter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountVerificationLetter(string accountNumberID)
        : this()
    {
        this.AccountNumberID = accountNumberID;
    }
}

class AccountVerificationLetterFromRaw : IFromRawJson<AccountVerificationLetter>
{
    /// <inheritdoc/>
    public AccountVerificationLetter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountVerificationLetter.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `balance_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BalanceCsv, BalanceCsvFromRaw>))]
public sealed record class BalanceCsv : JsonModel
{
    /// <summary>
    /// Filter exported Balances to the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// Filter results by time range on the `created_at` attribute.
    /// </summary>
    public BalanceCsvCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BalanceCsvCreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.CreatedAt?.Validate();
    }

    public BalanceCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceCsv(BalanceCsv balanceCsv)
        : base(balanceCsv) { }
#pragma warning restore CS8618

    public BalanceCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceCsvFromRaw.FromRawUnchecked"/>
    public static BalanceCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceCsvFromRaw : IFromRawJson<BalanceCsv>
{
    /// <inheritdoc/>
    public BalanceCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter results by time range on the `created_at` attribute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BalanceCsvCreatedAt, BalanceCsvCreatedAtFromRaw>))]
public sealed record class BalanceCsvCreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public BalanceCsvCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceCsvCreatedAt(BalanceCsvCreatedAt balanceCsvCreatedAt)
        : base(balanceCsvCreatedAt) { }
#pragma warning restore CS8618

    public BalanceCsvCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceCsvCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceCsvCreatedAtFromRaw.FromRawUnchecked"/>
    public static BalanceCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceCsvCreatedAtFromRaw : IFromRawJson<BalanceCsvCreatedAt>
{
    /// <inheritdoc/>
    public BalanceCsvCreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceCsvCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `bookkeeping_account_balance_csv`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BookkeepingAccountBalanceCsv, BookkeepingAccountBalanceCsvFromRaw>)
)]
public sealed record class BookkeepingAccountBalanceCsv : JsonModel
{
    /// <summary>
    /// Filter exported Bookkeeping Account Balances to the specified Bookkeeping Account.
    /// </summary>
    public string? BookkeepingAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bookkeeping_account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bookkeeping_account_id", value);
        }
    }

    /// <summary>
    /// Filter exported Balances to those on or after this date.
    /// </summary>
    public string? OnOrAfterDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("on_or_after_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after_date", value);
        }
    }

    /// <summary>
    /// Filter exported Balances to those on or before this date.
    /// </summary>
    public string? OnOrBeforeDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("on_or_before_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BookkeepingAccountID;
        _ = this.OnOrAfterDate;
        _ = this.OnOrBeforeDate;
    }

    public BookkeepingAccountBalanceCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingAccountBalanceCsv(BookkeepingAccountBalanceCsv bookkeepingAccountBalanceCsv)
        : base(bookkeepingAccountBalanceCsv) { }
#pragma warning restore CS8618

    public BookkeepingAccountBalanceCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingAccountBalanceCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingAccountBalanceCsvFromRaw.FromRawUnchecked"/>
    public static BookkeepingAccountBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingAccountBalanceCsvFromRaw : IFromRawJson<BookkeepingAccountBalanceCsv>
{
    /// <inheritdoc/>
    public BookkeepingAccountBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookkeepingAccountBalanceCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `daily_account_balance_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DailyAccountBalanceCsv, DailyAccountBalanceCsvFromRaw>))]
public sealed record class DailyAccountBalanceCsv : JsonModel
{
    /// <summary>
    /// Filter exported Balances to the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// Filter exported Balances to those on or after this date.
    /// </summary>
    public string? OnOrAfterDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("on_or_after_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after_date", value);
        }
    }

    /// <summary>
    /// Filter exported Balances to those on or before this date.
    /// </summary>
    public string? OnOrBeforeDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("on_or_before_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.OnOrAfterDate;
        _ = this.OnOrBeforeDate;
    }

    public DailyAccountBalanceCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DailyAccountBalanceCsv(DailyAccountBalanceCsv dailyAccountBalanceCsv)
        : base(dailyAccountBalanceCsv) { }
#pragma warning restore CS8618

    public DailyAccountBalanceCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DailyAccountBalanceCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DailyAccountBalanceCsvFromRaw.FromRawUnchecked"/>
    public static DailyAccountBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DailyAccountBalanceCsvFromRaw : IFromRawJson<DailyAccountBalanceCsv>
{
    /// <inheritdoc/>
    public DailyAccountBalanceCsv FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DailyAccountBalanceCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `entity_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityCsv, EntityCsvFromRaw>))]
public sealed record class EntityCsv : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public EntityCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCsv(EntityCsv entityCsv)
        : base(entityCsv) { }
#pragma warning restore CS8618

    public EntityCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCsvFromRaw.FromRawUnchecked"/>
    public static EntityCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCsvFromRaw : IFromRawJson<EntityCsv>
{
    /// <inheritdoc/>
    public EntityCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `funding_instructions`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FundingInstructions, FundingInstructionsFromRaw>))]
public sealed record class FundingInstructions : JsonModel
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

    public FundingInstructions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FundingInstructions(FundingInstructions fundingInstructions)
        : base(fundingInstructions) { }
#pragma warning restore CS8618

    public FundingInstructions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FundingInstructions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FundingInstructionsFromRaw.FromRawUnchecked"/>
    public static FundingInstructions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FundingInstructions(string accountNumberID)
        : this()
    {
        this.AccountNumberID = accountNumberID;
    }
}

class FundingInstructionsFromRaw : IFromRawJson<FundingInstructions>
{
    /// <inheritdoc/>
    public FundingInstructions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FundingInstructions.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `transaction_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TransactionCsv, TransactionCsvFromRaw>))]
public sealed record class TransactionCsv : JsonModel
{
    /// <summary>
    /// Filter exported Transactions to the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <summary>
    /// Filter results by time range on the `created_at` attribute.
    /// </summary>
    public TransactionCsvCreatedAt? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransactionCsvCreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        this.CreatedAt?.Validate();
    }

    public TransactionCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionCsv(TransactionCsv transactionCsv)
        : base(transactionCsv) { }
#pragma warning restore CS8618

    public TransactionCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionCsvFromRaw.FromRawUnchecked"/>
    public static TransactionCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionCsvFromRaw : IFromRawJson<TransactionCsv>
{
    /// <inheritdoc/>
    public TransactionCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TransactionCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter results by time range on the `created_at` attribute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TransactionCsvCreatedAt, TransactionCsvCreatedAtFromRaw>))]
public sealed record class TransactionCsvCreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public TransactionCsvCreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionCsvCreatedAt(TransactionCsvCreatedAt transactionCsvCreatedAt)
        : base(transactionCsvCreatedAt) { }
#pragma warning restore CS8618

    public TransactionCsvCreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionCsvCreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionCsvCreatedAtFromRaw.FromRawUnchecked"/>
    public static TransactionCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionCsvCreatedAtFromRaw : IFromRawJson<TransactionCsvCreatedAt>
{
    /// <inheritdoc/>
    public TransactionCsvCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionCsvCreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `vendor_csv`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VendorCsv, VendorCsvFromRaw>))]
public sealed record class VendorCsv : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public VendorCsv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VendorCsv(VendorCsv vendorCsv)
        : base(vendorCsv) { }
#pragma warning restore CS8618

    public VendorCsv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VendorCsv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VendorCsvFromRaw.FromRawUnchecked"/>
    public static VendorCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VendorCsvFromRaw : IFromRawJson<VendorCsv>
{
    /// <inheritdoc/>
    public VendorCsv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VendorCsv.FromRawUnchecked(rawData);
}

/// <summary>
/// Options for the created export. Required if `category` is equal to `voided_check`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoidedCheck, VoidedCheckFromRaw>))]
public sealed record class VoidedCheck : JsonModel
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
    /// The payer information to be printed on the check.
    /// </summary>
    public IReadOnlyList<Payer>? Payer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Payer>>("payer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Payer>?>(
                "payer",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumberID;
        foreach (var item in this.Payer ?? [])
        {
            item.Validate();
        }
    }

    public VoidedCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoidedCheck(VoidedCheck voidedCheck)
        : base(voidedCheck) { }
#pragma warning restore CS8618

    public VoidedCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoidedCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoidedCheckFromRaw.FromRawUnchecked"/>
    public static VoidedCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VoidedCheck(string accountNumberID)
        : this()
    {
        this.AccountNumberID = accountNumberID;
    }
}

class VoidedCheckFromRaw : IFromRawJson<VoidedCheck>
{
    /// <inheritdoc/>
    public VoidedCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoidedCheck.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Payer, PayerFromRaw>))]
public sealed record class Payer : JsonModel
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

    public Payer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payer(Payer payer)
        : base(payer) { }
#pragma warning restore CS8618

    public Payer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayerFromRaw.FromRawUnchecked"/>
    public static Payer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Payer(string line)
        : this()
    {
        this.Line = line;
    }
}

class PayerFromRaw : IFromRawJson<Payer>
{
    /// <inheritdoc/>
    public Payer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payer.FromRawUnchecked(rawData);
}
