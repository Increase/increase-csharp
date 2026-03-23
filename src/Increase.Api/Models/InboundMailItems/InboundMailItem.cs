using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundMailItems;

/// <summary>
/// Inbound Mail Items represent pieces of physical mail delivered to a Lockbox.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundMailItem, InboundMailItemFromRaw>))]
public sealed record class InboundMailItem : JsonModel
{
    /// <summary>
    /// The Inbound Mail Item identifier.
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
    /// The checks in the mail item.
    /// </summary>
    public required IReadOnlyList<InboundMailItemCheck> Checks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundMailItemCheck>>("checks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundMailItemCheck>>(
                "checks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Inbound
    /// Mail Item was created.
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
    /// The identifier for the File containing the scanned contents of the mail item.
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
    /// The identifier for the Lockbox that received this mail item. For mail items
    /// that could not be processed due to an invalid address, this will be null.
    /// </summary>
    public required string? LockboxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lockbox_id");
        }
        init { this._rawData.Set("lockbox_id", value); }
    }

    /// <summary>
    /// The recipient name as written on the mail item.
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
    /// If the mail item has been rejected, why it was rejected.
    /// </summary>
    public required ApiEnum<string, RejectionReason>? RejectionReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RejectionReason>>(
                "rejection_reason"
            );
        }
        init { this._rawData.Set("rejection_reason", value); }
    }

    /// <summary>
    /// If the mail item has been processed.
    /// </summary>
    public required ApiEnum<string, InboundMailItemStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InboundMailItemStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_mail_item`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.InboundMailItems.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.InboundMailItems.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Checks)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.FileID;
        _ = this.LockboxID;
        _ = this.RecipientName;
        this.RejectionReason?.Validate();
        this.Status.Validate();
        this.Type.Validate();
    }

    public InboundMailItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMailItem(InboundMailItem inboundMailItem)
        : base(inboundMailItem) { }
#pragma warning restore CS8618

    public InboundMailItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMailItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundMailItemFromRaw.FromRawUnchecked"/>
    public static InboundMailItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundMailItemFromRaw : IFromRawJson<InboundMailItem>
{
    /// <inheritdoc/>
    public InboundMailItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundMailItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Inbound Mail Item Checks represent the checks in an Inbound Mail Item.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundMailItemCheck, InboundMailItemCheckFromRaw>))]
public sealed record class InboundMailItemCheck : JsonModel
{
    /// <summary>
    /// The amount of the check.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The identifier for the File containing the back of the check.
    /// </summary>
    public required string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init { this._rawData.Set("back_file_id", value); }
    }

    /// <summary>
    /// The identifier of the Check Deposit if this check was deposited.
    /// </summary>
    public required string? CheckDepositID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_deposit_id");
        }
        init { this._rawData.Set("check_deposit_id", value); }
    }

    /// <summary>
    /// The identifier for the File containing the front of the check.
    /// </summary>
    public required string? FrontFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("front_file_id");
        }
        init { this._rawData.Set("front_file_id", value); }
    }

    /// <summary>
    /// The status of the Inbound Mail Item Check.
    /// </summary>
    public required ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BackFileID;
        _ = this.CheckDepositID;
        _ = this.FrontFileID;
        this.Status?.Validate();
    }

    public InboundMailItemCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMailItemCheck(InboundMailItemCheck inboundMailItemCheck)
        : base(inboundMailItemCheck) { }
#pragma warning restore CS8618

    public InboundMailItemCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMailItemCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundMailItemCheckFromRaw.FromRawUnchecked"/>
    public static InboundMailItemCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundMailItemCheckFromRaw : IFromRawJson<InboundMailItemCheck>
{
    /// <inheritdoc/>
    public InboundMailItemCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundMailItemCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the Inbound Mail Item Check.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The check is pending processing.
    /// </summary>
    Pending,

    /// <summary>
    /// The check has been deposited.
    /// </summary>
    Deposited,

    /// <summary>
    /// The check has been ignored.
    /// </summary>
    Ignored,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "deposited" => Status.Deposited,
            "ignored" => Status.Ignored,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Deposited => "deposited",
                Status.Ignored => "ignored",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the mail item has been rejected, why it was rejected.
/// </summary>
[JsonConverter(typeof(RejectionReasonConverter))]
public enum RejectionReason
{
    /// <summary>
    /// The mail item does not match any lockbox.
    /// </summary>
    NoMatchingLockbox,

    /// <summary>
    /// The mail item does not contain a check.
    /// </summary>
    NoCheck,

    /// <summary>
    /// The Lockbox or its associated Account is not active.
    /// </summary>
    LockboxNotActive,
}

sealed class RejectionReasonConverter : JsonConverter<RejectionReason>
{
    public override RejectionReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_matching_lockbox" => RejectionReason.NoMatchingLockbox,
            "no_check" => RejectionReason.NoCheck,
            "lockbox_not_active" => RejectionReason.LockboxNotActive,
            _ => (RejectionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RejectionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RejectionReason.NoMatchingLockbox => "no_matching_lockbox",
                RejectionReason.NoCheck => "no_check",
                RejectionReason.LockboxNotActive => "lockbox_not_active",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the mail item has been processed.
/// </summary>
[JsonConverter(typeof(InboundMailItemStatusConverter))]
public enum InboundMailItemStatus
{
    /// <summary>
    /// The mail item is pending processing.
    /// </summary>
    Pending,

    /// <summary>
    /// The mail item has been processed.
    /// </summary>
    Processed,

    /// <summary>
    /// The mail item has been rejected.
    /// </summary>
    Rejected,
}

sealed class InboundMailItemStatusConverter : JsonConverter<InboundMailItemStatus>
{
    public override InboundMailItemStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => InboundMailItemStatus.Pending,
            "processed" => InboundMailItemStatus.Processed,
            "rejected" => InboundMailItemStatus.Rejected,
            _ => (InboundMailItemStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundMailItemStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundMailItemStatus.Pending => "pending",
                InboundMailItemStatus.Processed => "processed",
                InboundMailItemStatus.Rejected => "rejected",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `inbound_mail_item`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundMailItem,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.InboundMailItems.Type>
{
    public override global::Increase.Api.Models.InboundMailItems.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_mail_item" => global::Increase
                .Api
                .Models
                .InboundMailItems
                .Type
                .InboundMailItem,
            _ => (global::Increase.Api.Models.InboundMailItems.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundMailItems.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.InboundMailItems.Type.InboundMailItem =>
                    "inbound_mail_item",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
