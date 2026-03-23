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
    /// Properties related to how this Account Number handles inbound ACH transfers.
    /// </summary>
    public required AccountNumberInboundAch InboundAch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountNumberInboundAch>("inbound_ach");
        }
        init { this._rawData.Set("inbound_ach", value); }
    }

    /// <summary>
    /// Properties related to how this Account Number should handle inbound check withdrawals.
    /// </summary>
    public required AccountNumberInboundChecks InboundChecks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountNumberInboundChecks>("inbound_checks");
        }
        init { this._rawData.Set("inbound_checks", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumberValue;
        _ = this.CreatedAt;
        _ = this.IdempotencyKey;
        this.InboundAch.Validate();
        this.InboundChecks.Validate();
        _ = this.Name;
        _ = this.RoutingNumber;
        this.Status.Validate();
        this.Type.Validate();
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
/// Properties related to how this Account Number handles inbound ACH transfers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountNumberInboundAch, AccountNumberInboundAchFromRaw>))]
public sealed record class AccountNumberInboundAch : JsonModel
{
    /// <summary>
    /// Whether ACH debits are allowed against this Account Number. Note that they
    /// will still be declined if this is `allowed` if the Account Number is not active.
    /// </summary>
    public required ApiEnum<string, AccountNumberInboundAchDebitStatus> DebitStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountNumberInboundAchDebitStatus>
            >("debit_status");
        }
        init { this._rawData.Set("debit_status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DebitStatus.Validate();
    }

    public AccountNumberInboundAch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberInboundAch(AccountNumberInboundAch accountNumberInboundAch)
        : base(accountNumberInboundAch) { }
#pragma warning restore CS8618

    public AccountNumberInboundAch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNumberInboundAch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNumberInboundAchFromRaw.FromRawUnchecked"/>
    public static AccountNumberInboundAch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountNumberInboundAch(ApiEnum<string, AccountNumberInboundAchDebitStatus> debitStatus)
        : this()
    {
        this.DebitStatus = debitStatus;
    }
}

class AccountNumberInboundAchFromRaw : IFromRawJson<AccountNumberInboundAch>
{
    /// <inheritdoc/>
    public AccountNumberInboundAch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountNumberInboundAch.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether ACH debits are allowed against this Account Number. Note that they will
/// still be declined if this is `allowed` if the Account Number is not active.
/// </summary>
[JsonConverter(typeof(AccountNumberInboundAchDebitStatusConverter))]
public enum AccountNumberInboundAchDebitStatus
{
    /// <summary>
    /// ACH Debits are allowed.
    /// </summary>
    Allowed,

    /// <summary>
    /// ACH Debits are blocked.
    /// </summary>
    Blocked,
}

sealed class AccountNumberInboundAchDebitStatusConverter
    : JsonConverter<AccountNumberInboundAchDebitStatus>
{
    public override AccountNumberInboundAchDebitStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberInboundAchDebitStatus.Allowed,
            "blocked" => AccountNumberInboundAchDebitStatus.Blocked,
            _ => (AccountNumberInboundAchDebitStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberInboundAchDebitStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberInboundAchDebitStatus.Allowed => "allowed",
                AccountNumberInboundAchDebitStatus.Blocked => "blocked",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Properties related to how this Account Number should handle inbound check withdrawals.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AccountNumberInboundChecks, AccountNumberInboundChecksFromRaw>)
)]
public sealed record class AccountNumberInboundChecks : JsonModel
{
    /// <summary>
    /// How Increase should process checks with this account number printed on them.
    /// </summary>
    public required ApiEnum<string, AccountNumberInboundChecksStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountNumberInboundChecksStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public AccountNumberInboundChecks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountNumberInboundChecks(AccountNumberInboundChecks accountNumberInboundChecks)
        : base(accountNumberInboundChecks) { }
#pragma warning restore CS8618

    public AccountNumberInboundChecks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountNumberInboundChecks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountNumberInboundChecksFromRaw.FromRawUnchecked"/>
    public static AccountNumberInboundChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountNumberInboundChecks(ApiEnum<string, AccountNumberInboundChecksStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class AccountNumberInboundChecksFromRaw : IFromRawJson<AccountNumberInboundChecks>
{
    /// <inheritdoc/>
    public AccountNumberInboundChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountNumberInboundChecks.FromRawUnchecked(rawData);
}

/// <summary>
/// How Increase should process checks with this account number printed on them.
/// </summary>
[JsonConverter(typeof(AccountNumberInboundChecksStatusConverter))]
public enum AccountNumberInboundChecksStatus
{
    /// <summary>
    /// Checks with this Account Number will be processed even if they are not associated
    /// with a Check Transfer.
    /// </summary>
    Allowed,

    /// <summary>
    /// Checks with this Account Number will be processed only if they can be matched
    /// to an existing Check Transfer.
    /// </summary>
    CheckTransfersOnly,
}

sealed class AccountNumberInboundChecksStatusConverter
    : JsonConverter<AccountNumberInboundChecksStatus>
{
    public override AccountNumberInboundChecksStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowed" => AccountNumberInboundChecksStatus.Allowed,
            "check_transfers_only" => AccountNumberInboundChecksStatus.CheckTransfersOnly,
            _ => (AccountNumberInboundChecksStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountNumberInboundChecksStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountNumberInboundChecksStatus.Allowed => "allowed",
                AccountNumberInboundChecksStatus.CheckTransfersOnly => "check_transfers_only",
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
