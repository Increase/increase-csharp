using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.AccountNumbers;

/// <summary>
/// Each account can have multiple account and routing numbers. We recommend that
/// you use a set per vendor. This is similar to how you use different passwords for
/// different websites. Account numbers can also be used to seamlessly reconcile inbound
/// payments. Generating a unique account number per vendor ensures you always know
/// the originator of an incoming payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountNumber, AccountNumberFromRaw>))]
public sealed record class AccountNumber : JsonModel
{
    /// <summary>
    /// The Account Number identifier.
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
    /// The identifier for the account this Account Number belongs to.
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
    /// The account number.
    /// </summary>
    public required string AccountNumberValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Account
    /// Number was created.
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
    /// Whether inbound ACH debits are allowed against this Account Number. Note that
    /// they will still be declined if this is `allowed` but the Account Number is
    /// not active.
    /// </summary>
    public required ApiEnum<string, AccountNumberInboundAchDebits> InboundAchDebits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountNumberInboundAchDebits>>(
                "inbound_ach_debits"
            );
        }
        init { this._rawData.Set("inbound_ach_debits", value); }
    }

    /// <summary>
    /// The name you choose for the Account Number.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The American Bankers' Association (ABA) Routing Transit Number (RTN).
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <summary>
    /// This indicates if payments can be made to the Account Number.
    /// </summary>
    public required ApiEnum<string, AccountNumberStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountNumberStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `account_number`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.AccountNumbers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.AccountNumbers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether unregistered inbound checks for this Account Number can be deposited.
    /// </summary>
    public required ApiEnum<
        string,
        AccountNumberUnregisteredInboundChecks
    > UnregisteredInboundChecks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountNumberUnregisteredInboundChecks>
            >("unregistered_inbound_checks");
        }
        init { this._rawData.Set("unregistered_inbound_checks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumberValue;
        _ = this.CreatedAt;
        _ = this.IdempotencyKey;
        this.InboundAchDebits.Validate();
        _ = this.Name;
        _ = this.RoutingNumber;
        this.Status.Validate();
        this.Type.Validate();
        this.UnregisteredInboundChecks.Validate();
    }

    public AccountNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumber(AccountNumber accountNumber)
        : base(accountNumber) { }
#pragma warning restore CS8618

    public AccountNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNumberFromRaw.FromRawUnchecked"/>
    public static AccountNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountNumberFromRaw : IFromRawJson<AccountNumber>
{
    /// <inheritdoc/>
    public AccountNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether inbound ACH debits are allowed against this Account Number. Note that
/// they will still be declined if this is `allowed` but the Account Number is not active.
/// </summary>
[JsonConverter(typeof(AccountNumberInboundAchDebitsConverter))]
public enum AccountNumberInboundAchDebits
{
    /// <summary>
    /// ACH Debits are allowed.
    /// </summary>
    Allowed,

    /// <summary>
    /// ACH Debits are blocked. Received debits will be declined and returned with
    /// code `R20` (non-transaction account).
    /// </summary>
    Blocked,
}

sealed class AccountNumberInboundAchDebitsConverter : JsonConverter<AccountNumberInboundAchDebits>
{
    public override AccountNumberInboundAchDebits Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberInboundAchDebits.Allowed,
            "blocked" => AccountNumberInboundAchDebits.Blocked,
            _ => (AccountNumberInboundAchDebits)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberInboundAchDebits value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberInboundAchDebits.Allowed => "allowed",
                AccountNumberInboundAchDebits.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This indicates if payments can be made to the Account Number.
/// </summary>
[JsonConverter(typeof(AccountNumberStatusConverter))]
public enum AccountNumberStatus
{
    /// <summary>
    /// The account number is active.
    /// </summary>
    Active,

    /// <summary>
    /// The account number is temporarily disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// The account number is permanently disabled.
    /// </summary>
    Canceled,
}

sealed class AccountNumberStatusConverter : JsonConverter<AccountNumberStatus>
{
    public override AccountNumberStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountNumberStatus.Active,
            "disabled" => AccountNumberStatus.Disabled,
            "canceled" => AccountNumberStatus.Canceled,
            _ => (AccountNumberStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberStatus.Active => "active",
                AccountNumberStatus.Disabled => "disabled",
                AccountNumberStatus.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `account_number`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AccountNumber,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.AccountNumbers.Type>
{
    public override global::Increase.Api.Models.AccountNumbers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_number" => global::Increase.Api.Models.AccountNumbers.Type.AccountNumber,
            _ => (global::Increase.Api.Models.AccountNumbers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.AccountNumbers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.AccountNumbers.Type.AccountNumber => "account_number",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether unregistered inbound checks for this Account Number can be deposited.
/// </summary>
[JsonConverter(typeof(AccountNumberUnregisteredInboundChecksConverter))]
public enum AccountNumberUnregisteredInboundChecks
{
    /// <summary>
    /// Accept all Inbound Check Deposits, even if they are not associated with a
    /// Check Transfer or Checkbook Check.
    /// </summary>
    Allowed,

    /// <summary>
    /// Only accept Inbound Check Deposits if they can be matched to a Check Transfer
    /// or Checkbook Check.
    /// </summary>
    Blocked,
}

sealed class AccountNumberUnregisteredInboundChecksConverter
    : JsonConverter<AccountNumberUnregisteredInboundChecks>
{
    public override AccountNumberUnregisteredInboundChecks Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberUnregisteredInboundChecks.Allowed,
            "blocked" => AccountNumberUnregisteredInboundChecks.Blocked,
            _ => (AccountNumberUnregisteredInboundChecks)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberUnregisteredInboundChecks value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberUnregisteredInboundChecks.Allowed => "allowed",
                AccountNumberUnregisteredInboundChecks.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
