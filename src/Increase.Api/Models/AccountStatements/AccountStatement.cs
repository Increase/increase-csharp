using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.AccountStatements;

/// <summary>
/// Account Statements are generated monthly for every active Account. You can access
/// the statement's data via the API or retrieve a PDF with its details via its associated File.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountStatement, AccountStatementFromRaw>))]
public sealed record class AccountStatement : JsonModel
{
    /// <summary>
    /// The Account Statement identifier.
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
    /// The identifier for the Account this Account Statement belongs to.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Account
    /// Statement was created.
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
    /// The Account's balance at the end of its statement period.
    /// </summary>
    public required long EndingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("ending_balance");
        }
        init { this._rawData.Set("ending_balance", value); }
    }

    /// <summary>
    /// The identifier of the File containing a PDF of the statement.
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

    /// <summary>
    /// The loan balances.
    /// </summary>
    public required Loan? Loan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Loan>("loan");
        }
        init { this._rawData.Set("loan", value); }
    }

    /// <summary>
    /// The Account's balance at the start of its statement period.
    /// </summary>
    public required long StartingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("starting_balance");
        }
        init { this._rawData.Set("starting_balance", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time representing the
    /// end of the period the Account Statement covers.
    /// </summary>
    public required System::DateTimeOffset StatementPeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("statement_period_end");
        }
        init { this._rawData.Set("statement_period_end", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time representing the
    /// start of the period the Account Statement covers.
    /// </summary>
    public required System::DateTimeOffset StatementPeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("statement_period_start");
        }
        init { this._rawData.Set("statement_period_start", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `account_statement`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.AccountStatements.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.AccountStatements.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.CreatedAt;
        _ = this.EndingBalance;
        _ = this.FileID;
        this.Loan?.Validate();
        _ = this.StartingBalance;
        _ = this.StatementPeriodEnd;
        _ = this.StatementPeriodStart;
        this.Type.Validate();
    }

    public AccountStatement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountStatement(AccountStatement accountStatement)
        : base(accountStatement) { }
#pragma warning restore CS8618

    public AccountStatement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountStatement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountStatementFromRaw.FromRawUnchecked"/>
    public static AccountStatement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountStatementFromRaw : IFromRawJson<AccountStatement>
{
    /// <inheritdoc/>
    public AccountStatement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountStatement.FromRawUnchecked(rawData);
}

/// <summary>
/// The loan balances.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Loan, LoanFromRaw>))]
public sealed record class Loan : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the loan
    /// payment is due.
    /// </summary>
    public required System::DateTimeOffset? DueAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("due_at");
        }
        init { this._rawData.Set("due_at", value); }
    }

    /// <summary>
    /// The total amount due on the loan.
    /// </summary>
    public required long DueBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("due_balance");
        }
        init { this._rawData.Set("due_balance", value); }
    }

    /// <summary>
    /// The amount past due on the loan.
    /// </summary>
    public required long PastDueBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("past_due_balance");
        }
        init { this._rawData.Set("past_due_balance", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DueAt;
        _ = this.DueBalance;
        _ = this.PastDueBalance;
    }

    public Loan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Loan(Loan loan)
        : base(loan) { }
#pragma warning restore CS8618

    public Loan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Loan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LoanFromRaw.FromRawUnchecked"/>
    public static Loan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LoanFromRaw : IFromRawJson<Loan>
{
    /// <inheritdoc/>
    public Loan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Loan.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `account_statement`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AccountStatement,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.AccountStatements.Type>
{
    public override global::Increase.Api.Models.AccountStatements.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_statement" => global::Increase
                .Api
                .Models
                .AccountStatements
                .Type
                .AccountStatement,
            _ => (global::Increase.Api.Models.AccountStatements.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.AccountStatements.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.AccountStatements.Type.AccountStatement =>
                    "account_statement",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
