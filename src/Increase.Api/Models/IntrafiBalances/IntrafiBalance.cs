using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.IntrafiBalances;

/// <summary>
/// When using IntraFi, each account's balance over the standard FDIC insurance amount
/// is swept to various other institutions. Funds are rebalanced across banks as
/// needed once per business day.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IntrafiBalance, IntrafiBalanceFromRaw>))]
public sealed record class IntrafiBalance : JsonModel
{
    /// <summary>
    /// Each entry represents a balance held at a different bank. IntraFi separates
    /// the total balance across many participating banks in the network.
    /// </summary>
    public required IReadOnlyList<Balance> Balances
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Balance>>("balances");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Balance>>(
                "balances",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the account currency.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The date this balance reflects.
    /// </summary>
    public required string EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    /// <summary>
    /// The total balance, in minor units of `currency`. Increase reports this balance
    /// to IntraFi daily.
    /// </summary>
    public required long TotalBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_balance");
        }
        init { this._rawData.Set("total_balance", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `intrafi_balance`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.IntrafiBalances.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.IntrafiBalances.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Balances)
        {
            item.Validate();
        }
        this.Currency.Validate();
        _ = this.EffectiveDate;
        _ = this.TotalBalance;
        this.Type.Validate();
    }

    public IntrafiBalance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrafiBalance(IntrafiBalance intrafiBalance)
        : base(intrafiBalance) { }
#pragma warning restore CS8618

    public IntrafiBalance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrafiBalance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrafiBalanceFromRaw.FromRawUnchecked"/>
    public static IntrafiBalance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrafiBalanceFromRaw : IFromRawJson<IntrafiBalance>
{
    /// <inheritdoc/>
    public IntrafiBalance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntrafiBalance.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Balance, BalanceFromRaw>))]
public sealed record class Balance : JsonModel
{
    /// <summary>
    /// The balance, in minor units of `currency`, held with this bank.
    /// </summary>
    public required long BalanceValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    /// <summary>
    /// The name of the bank holding these funds.
    /// </summary>
    public required string Bank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bank");
        }
        init { this._rawData.Set("bank", value); }
    }

    /// <summary>
    /// The primary location of the bank.
    /// </summary>
    public required BankLocation? BankLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BankLocation>("bank_location");
        }
        init { this._rawData.Set("bank_location", value); }
    }

    /// <summary>
    /// The Federal Deposit Insurance Corporation (FDIC) certificate number of the
    /// bank. Because many banks have the same or similar names, this can be used
    /// to uniquely identify the institution.
    /// </summary>
    public required string FdicCertificateNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fdic_certificate_number");
        }
        init { this._rawData.Set("fdic_certificate_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BalanceValue;
        _ = this.Bank;
        this.BankLocation?.Validate();
        _ = this.FdicCertificateNumber;
    }

    public Balance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Balance(Balance balance)
        : base(balance) { }
#pragma warning restore CS8618

    public Balance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Balance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceFromRaw.FromRawUnchecked"/>
    public static Balance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceFromRaw : IFromRawJson<Balance>
{
    /// <inheritdoc/>
    public Balance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Balance.FromRawUnchecked(rawData);
}

/// <summary>
/// The primary location of the bank.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BankLocation, BankLocationFromRaw>))]
public sealed record class BankLocation : JsonModel
{
    /// <summary>
    /// The bank's city.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The bank's state.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.State;
    }

    public BankLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BankLocation(BankLocation bankLocation)
        : base(bankLocation) { }
#pragma warning restore CS8618

    public BankLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BankLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BankLocationFromRaw.FromRawUnchecked"/>
    public static BankLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BankLocationFromRaw : IFromRawJson<BankLocation>
{
    /// <inheritdoc/>
    public BankLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BankLocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the account currency.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.Usd,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `intrafi_balance`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    IntrafiBalance,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.IntrafiBalances.Type>
{
    public override global::Increase.Api.Models.IntrafiBalances.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "intrafi_balance" => global::Increase.Api.Models.IntrafiBalances.Type.IntrafiBalance,
            _ => (global::Increase.Api.Models.IntrafiBalances.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.IntrafiBalances.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.IntrafiBalances.Type.IntrafiBalance =>
                    "intrafi_balance",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
