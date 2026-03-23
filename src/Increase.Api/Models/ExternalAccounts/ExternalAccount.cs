using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.ExternalAccounts;

/// <summary>
/// External Accounts represent accounts at financial institutions other than Increase.
/// You can use this API to store their details for reuse.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExternalAccount, ExternalAccountFromRaw>))]
public sealed record class ExternalAccount : JsonModel
{
    /// <summary>
    /// The External Account's identifier.
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
    /// The type of entity that owns the External Account.
    /// </summary>
    public required ApiEnum<string, ExternalAccountAccountHolder> AccountHolder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExternalAccountAccountHolder>>(
                "account_holder"
            );
        }
        init { this._rawData.Set("account_holder", value); }
    }

    /// <summary>
    /// The destination account number.
    /// </summary>
    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the External Account was created.
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
    /// The External Account's description for display purposes.
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
    /// The type of the account to which the transfer will be sent.
    /// </summary>
    public required ApiEnum<string, ExternalAccountFunding> Funding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExternalAccountFunding>>(
                "funding"
            );
        }
        init { this._rawData.Set("funding", value); }
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
    /// The External Account's status.
    /// </summary>
    public required ApiEnum<string, ExternalAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExternalAccountStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `external_account`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.ExternalAccounts.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.ExternalAccounts.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AccountHolder.Validate();
        _ = this.AccountNumber;
        _ = this.CreatedAt;
        _ = this.Description;
        this.Funding.Validate();
        _ = this.IdempotencyKey;
        _ = this.RoutingNumber;
        this.Status.Validate();
        this.Type.Validate();
    }

    public ExternalAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalAccount(ExternalAccount externalAccount)
        : base(externalAccount) { }
#pragma warning restore CS8618

    public ExternalAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalAccountFromRaw.FromRawUnchecked"/>
    public static ExternalAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalAccountFromRaw : IFromRawJson<ExternalAccount>
{
    /// <inheritdoc/>
    public ExternalAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExternalAccount.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of entity that owns the External Account.
/// </summary>
[JsonConverter(typeof(ExternalAccountAccountHolderConverter))]
public enum ExternalAccountAccountHolder
{
    /// <summary>
    /// The External Account is owned by a business.
    /// </summary>
    Business,

    /// <summary>
    /// The External Account is owned by an individual.
    /// </summary>
    Individual,

    /// <summary>
    /// It's unknown what kind of entity owns the External Account.
    /// </summary>
    Unknown,
}

sealed class ExternalAccountAccountHolderConverter : JsonConverter<ExternalAccountAccountHolder>
{
    public override ExternalAccountAccountHolder Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business" => ExternalAccountAccountHolder.Business,
            "individual" => ExternalAccountAccountHolder.Individual,
            "unknown" => ExternalAccountAccountHolder.Unknown,
            _ => (ExternalAccountAccountHolder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalAccountAccountHolder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalAccountAccountHolder.Business => "business",
                ExternalAccountAccountHolder.Individual => "individual",
                ExternalAccountAccountHolder.Unknown => "unknown",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of the account to which the transfer will be sent.
/// </summary>
[JsonConverter(typeof(ExternalAccountFundingConverter))]
public enum ExternalAccountFunding
{
    /// <summary>
    /// A checking account.
    /// </summary>
    Checking,

    /// <summary>
    /// A savings account.
    /// </summary>
    Savings,

    /// <summary>
    /// A general ledger account.
    /// </summary>
    GeneralLedger,

    /// <summary>
    /// A different type of account.
    /// </summary>
    Other,
}

sealed class ExternalAccountFundingConverter : JsonConverter<ExternalAccountFunding>
{
    public override ExternalAccountFunding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => ExternalAccountFunding.Checking,
            "savings" => ExternalAccountFunding.Savings,
            "general_ledger" => ExternalAccountFunding.GeneralLedger,
            "other" => ExternalAccountFunding.Other,
            _ => (ExternalAccountFunding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalAccountFunding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalAccountFunding.Checking => "checking",
                ExternalAccountFunding.Savings => "savings",
                ExternalAccountFunding.GeneralLedger => "general_ledger",
                ExternalAccountFunding.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The External Account's status.
/// </summary>
[JsonConverter(typeof(ExternalAccountStatusConverter))]
public enum ExternalAccountStatus
{
    /// <summary>
    /// The External Account is active.
    /// </summary>
    Active,

    /// <summary>
    /// The External Account is archived and won't appear in the dashboard.
    /// </summary>
    Archived,
}

sealed class ExternalAccountStatusConverter : JsonConverter<ExternalAccountStatus>
{
    public override ExternalAccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ExternalAccountStatus.Active,
            "archived" => ExternalAccountStatus.Archived,
            _ => (ExternalAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalAccountStatus.Active => "active",
                ExternalAccountStatus.Archived => "archived",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `external_account`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ExternalAccount,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.ExternalAccounts.Type>
{
    public override global::Increase.Api.Models.ExternalAccounts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "external_account" => global::Increase.Api.Models.ExternalAccounts.Type.ExternalAccount,
            _ => (global::Increase.Api.Models.ExternalAccounts.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.ExternalAccounts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.ExternalAccounts.Type.ExternalAccount =>
                    "external_account",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
