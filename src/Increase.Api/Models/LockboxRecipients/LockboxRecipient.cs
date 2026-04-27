using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.LockboxRecipients;

/// <summary>
/// Lockbox Recipients represent an inbox at a Lockbox Address. Checks received for
/// a Lockbox Recipient are deposited into its associated Account.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LockboxRecipient, LockboxRecipientFromRaw>))]
public sealed record class LockboxRecipient : JsonModel
{
    /// <summary>
    /// The Lockbox Recipient identifier.
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
    /// The identifier for the Account that checks sent to this Lockbox Recipient
    /// will be deposited into.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Lockbox
    /// Recipient was created.
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
    /// The description of the Lockbox Recipient.
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
    /// The identifier for the Lockbox Address where this Lockbox Recipient may receive
    /// physical mail.
    /// </summary>
    public required string LockboxAddressID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lockbox_address_id");
        }
        init { this._rawData.Set("lockbox_address_id", value); }
    }

    /// <summary>
    /// The mail stop code uniquely identifying this Lockbox Recipient at its Lockbox
    /// Address. It should be included in the mailing address intended for this Lockbox Recipient.
    /// </summary>
    public required string MailStopCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mail_stop_code");
        }
        init { this._rawData.Set("mail_stop_code", value); }
    }

    /// <summary>
    /// The name of the Lockbox Recipient.
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
    /// The status of the Lockbox Recipient.
    /// </summary>
    public required ApiEnum<string, LockboxRecipientStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LockboxRecipientStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `lockbox_recipient`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.LockboxRecipients.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.LockboxRecipients.Type>
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
        _ = this.Description;
        _ = this.IdempotencyKey;
        _ = this.LockboxAddressID;
        _ = this.MailStopCode;
        _ = this.RecipientName;
        this.Status?.Validate();
        this.Type.Validate();
    }

    public LockboxRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxRecipient(LockboxRecipient lockboxRecipient)
        : base(lockboxRecipient) { }
#pragma warning restore CS8618

    public LockboxRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LockboxRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LockboxRecipientFromRaw.FromRawUnchecked"/>
    public static LockboxRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LockboxRecipientFromRaw : IFromRawJson<LockboxRecipient>
{
    /// <inheritdoc/>
    public LockboxRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LockboxRecipient.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the Lockbox Recipient.
/// </summary>
[JsonConverter(typeof(LockboxRecipientStatusConverter))]
public enum LockboxRecipientStatus
{
    /// <summary>
    /// This Lockbox Recipient is active.
    /// </summary>
    Active,

    /// <summary>
    /// This Lockbox Recipient is disabled. Checks mailed to this Lockbox Recipient
    /// will be rejected.
    /// </summary>
    Disabled,

    /// <summary>
    /// This Lockbox Recipient is canceled and cannot be modified. Checks mailed to
    /// this Lockbox Recipient will be rejected.
    /// </summary>
    Canceled,
}

sealed class LockboxRecipientStatusConverter : JsonConverter<LockboxRecipientStatus>
{
    public override LockboxRecipientStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => LockboxRecipientStatus.Active,
            "disabled" => LockboxRecipientStatus.Disabled,
            "canceled" => LockboxRecipientStatus.Canceled,
            _ => (LockboxRecipientStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LockboxRecipientStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LockboxRecipientStatus.Active => "active",
                LockboxRecipientStatus.Disabled => "disabled",
                LockboxRecipientStatus.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `lockbox_recipient`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    LockboxRecipient,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.LockboxRecipients.Type>
{
    public override global::Increase.Api.Models.LockboxRecipients.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lockbox_recipient" => global::Increase
                .Api
                .Models
                .LockboxRecipients
                .Type
                .LockboxRecipient,
            _ => (global::Increase.Api.Models.LockboxRecipients.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.LockboxRecipients.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.LockboxRecipients.Type.LockboxRecipient =>
                    "lockbox_recipient",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
