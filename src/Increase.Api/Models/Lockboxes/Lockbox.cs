using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Lockboxes;

/// <summary>
/// Lockboxes are physical locations that can receive mail containing paper checks.
/// Increase will automatically create a Check Deposit for checks received this way.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Lockbox, LockboxFromRaw>))]
public sealed record class Lockbox : JsonModel
{
    /// <summary>
    /// The Lockbox identifier.
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
    /// The identifier for the Account checks sent to this lockbox will be deposited into.
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
    /// The mailing address for the Lockbox.
    /// </summary>
    public required Address Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Indicates if checks mailed to this lockbox will be deposited.
    /// </summary>
    public required ApiEnum<string, LockboxCheckDepositBehavior> CheckDepositBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LockboxCheckDepositBehavior>>(
                "check_deposit_behavior"
            );
        }
        init { this._rawData.Set("check_deposit_behavior", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Lockbox
    /// was created.
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
    /// The description you choose for the Lockbox.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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
    /// The recipient name you choose for the Lockbox.
    /// </summary>
    public required string? RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient_name");
        }
        init { this._rawData.Set("recipient_name", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `lockbox`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Lockboxes.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Lockboxes.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.Address.Validate();
        this.CheckDepositBehavior.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.IdempotencyKey;
        _ = this.RecipientName;
        this.Type.Validate();
    }

    public Lockbox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Lockbox(Lockbox lockbox)
        : base(lockbox) { }
#pragma warning restore CS8618

    public Lockbox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Lockbox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LockboxFromRaw.FromRawUnchecked"/>
    public static Lockbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LockboxFromRaw : IFromRawJson<Lockbox>
{
    /// <inheritdoc/>
    public Lockbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Lockbox.FromRawUnchecked(rawData);
}

/// <summary>
/// The mailing address for the Lockbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// The city of the address.
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
    /// The first line of the address.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address.
    /// </summary>
    public required string Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The postal code of the address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The recipient line of the address. This will include the recipient name you
    /// provide when creating the address, as well as an ATTN suffix to help route
    /// the mail to your lockbox. Mail senders must include this ATTN line to receive
    /// mail at this Lockbox.
    /// </summary>
    public required string? Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient");
        }
        init { this._rawData.Set("recipient", value); }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
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
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.Recipient;
        _ = this.State;
    }

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates if checks mailed to this lockbox will be deposited.
/// </summary>
[JsonConverter(typeof(LockboxCheckDepositBehaviorConverter))]
public enum LockboxCheckDepositBehavior
{
    /// <summary>
    /// Checks mailed to this Lockbox will be deposited.
    /// </summary>
    Enabled,

    /// <summary>
    /// Checks mailed to this Lockbox will not be deposited.
    /// </summary>
    Disabled,

    /// <summary>
    /// Checks mailed to this Lockbox will be pending until actioned.
    /// </summary>
    PendForProcessing,
}

sealed class LockboxCheckDepositBehaviorConverter : JsonConverter<LockboxCheckDepositBehavior>
{
    public override LockboxCheckDepositBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled" => LockboxCheckDepositBehavior.Enabled,
            "disabled" => LockboxCheckDepositBehavior.Disabled,
            "pend_for_processing" => LockboxCheckDepositBehavior.PendForProcessing,
            _ => (LockboxCheckDepositBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LockboxCheckDepositBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LockboxCheckDepositBehavior.Enabled => "enabled",
                LockboxCheckDepositBehavior.Disabled => "disabled",
                LockboxCheckDepositBehavior.PendForProcessing => "pend_for_processing",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `lockbox`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Lockbox,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Lockboxes.Type>
{
    public override global::Increase.Api.Models.Lockboxes.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lockbox" => global::Increase.Api.Models.Lockboxes.Type.Lockbox,
            _ => (global::Increase.Api.Models.Lockboxes.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Lockboxes.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Lockboxes.Type.Lockbox => "lockbox",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
