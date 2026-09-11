using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Accounts;

/// <summary>
/// Represents a request to look up the balance of an Account at a given point in time.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BalanceLookup, BalanceLookupFromRaw>))]
public sealed record class BalanceLookup : JsonModel
{
    /// <summary>
    /// The identifier for the account for which the balance was queried.
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
    /// The Account's available balance, representing the current balance less any
    /// open Pending Transactions on the Account.
    /// </summary>
    public required long AvailableBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("available_balance");
        }
        init { this._rawData.Set("available_balance", value); }
    }

    /// <summary>
    /// The Account's current balance, representing the sum of all posted Transactions
    /// on the Account.
    /// </summary>
    public required long CurrentBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("current_balance");
        }
        init { this._rawData.Set("current_balance", value); }
    }

    /// <summary>
    /// The loan balances for the Account.
    /// </summary>
    public required BalanceLookupLoan? Loan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BalanceLookupLoan>("loan");
        }
        init { this._rawData.Set("loan", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `balance_lookup`.
    /// </summary>
    public required ApiEnum<string, BalanceLookupType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BalanceLookupType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.AvailableBalance;
        _ = this.CurrentBalance;
        this.Loan?.Validate();
        this.Type.Validate();
    }

    public BalanceLookup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceLookup(BalanceLookup balanceLookup)
        : base(balanceLookup) { }
#pragma warning restore CS8618

    public BalanceLookup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceLookup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceLookupFromRaw.FromRawUnchecked"/>
    public static BalanceLookup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceLookupFromRaw : IFromRawJson<BalanceLookup>
{
    /// <inheritdoc/>
    public BalanceLookup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceLookup.FromRawUnchecked(rawData);
}

/// <summary>
/// The loan balances for the Account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BalanceLookupLoan, BalanceLookupLoanFromRaw>))]
public sealed record class BalanceLookupLoan : JsonModel
{
    /// <summary>
    /// The fees on the loan that are due and unpaid.
    /// </summary>
    public required long? DueFees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("due_fees");
        }
        init { this._rawData.Set("due_fees", value); }
    }

    /// <summary>
    /// The interest on the loan that is due and unpaid.
    /// </summary>
    public required long? DueInterest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("due_interest");
        }
        init { this._rawData.Set("due_interest", value); }
    }

    /// <summary>
    /// The principal on the loan that is due and unpaid.
    /// </summary>
    public required long? DuePrincipal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("due_principal");
        }
        init { this._rawData.Set("due_principal", value); }
    }

    /// <summary>
    /// The fees on the loan that are not yet due.
    /// </summary>
    public required long? NotDueFees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("not_due_fees");
        }
        init { this._rawData.Set("not_due_fees", value); }
    }

    /// <summary>
    /// The interest on the loan that is not yet due.
    /// </summary>
    public required long? NotDueInterest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("not_due_interest");
        }
        init { this._rawData.Set("not_due_interest", value); }
    }

    /// <summary>
    /// The principal on the loan that is not yet due.
    /// </summary>
    public required long? NotDuePrincipal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("not_due_principal");
        }
        init { this._rawData.Set("not_due_principal", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DueFees;
        _ = this.DueInterest;
        _ = this.DuePrincipal;
        _ = this.NotDueFees;
        _ = this.NotDueInterest;
        _ = this.NotDuePrincipal;
    }

    public BalanceLookupLoan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceLookupLoan(BalanceLookupLoan balanceLookupLoan)
        : base(balanceLookupLoan) { }
#pragma warning restore CS8618

    public BalanceLookupLoan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceLookupLoan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceLookupLoanFromRaw.FromRawUnchecked"/>
    public static BalanceLookupLoan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceLookupLoanFromRaw : IFromRawJson<BalanceLookupLoan>
{
    /// <inheritdoc/>
    public BalanceLookupLoan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceLookupLoan.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `balance_lookup`.
/// </summary>
[JsonConverter(typeof(BalanceLookupTypeConverter))]
public enum BalanceLookupType
{
    BalanceLookup,
}

sealed class BalanceLookupTypeConverter : JsonConverter<BalanceLookupType>
{
    public override BalanceLookupType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "balance_lookup" => BalanceLookupType.BalanceLookup,
            _ => (BalanceLookupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceLookupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceLookupType.BalanceLookup => "balance_lookup",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
