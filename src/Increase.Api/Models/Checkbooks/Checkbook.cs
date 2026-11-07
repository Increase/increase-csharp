using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Checkbooks;

/// <summary>
/// Checkbooks are sets of blank checks that Increase prints and mails on your behalf.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Checkbook, CheckbookFromRaw>))]
public sealed record class Checkbook : JsonModel
{
    /// <summary>
    /// The Checkbook's identifier.
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
    /// The identifier of the Account Number the Checkbook is attached to.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Checkbook was created.
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
    /// The destination address that the Checkbook will be mailed to.
    /// </summary>
    public required CheckbookMailingAddress MailingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CheckbookMailingAddress>("mailing_address");
        }
        init { this._rawData.Set("mailing_address", value); }
    }

    /// <summary>
    /// The payer information printed on the top-left corner of each check.
    /// </summary>
    public required IReadOnlyList<CheckbookPayer> Payer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CheckbookPayer>>("payer");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckbookPayer>>(
                "payer",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The address the Checkbook will return to if there is a delivery issue.
    /// </summary>
    public required ReturnAddress ReturnAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReturnAddress>("return_address");
        }
        init { this._rawData.Set("return_address", value); }
    }

    /// <summary>
    /// The lifecycle status of the Checkbook.
    /// </summary>
    public required ApiEnum<string, CheckbookStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CheckbookStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The physical format of the Checkbook.
    /// </summary>
    public required ApiEnum<string, Style> Style
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Style>>("style");
        }
        init { this._rawData.Set("style", value); }
    }

    /// <summary>
    /// Tracking updates relating to the Checkbook's delivery.
    /// </summary>
    public required IReadOnlyList<TrackingUpdate> TrackingUpdates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TrackingUpdate>>(
                "tracking_updates"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TrackingUpdate>>(
                "tracking_updates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `checkbook`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Checkbooks.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Checkbooks.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountNumberID;
        _ = this.CreatedAt;
        _ = this.IdempotencyKey;
        this.MailingAddress.Validate();
        foreach (var item in this.Payer)
        {
            item.Validate();
        }
        this.ReturnAddress.Validate();
        this.Status.Validate();
        this.Style.Validate();
        foreach (var item in this.TrackingUpdates)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public Checkbook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Checkbook(Checkbook checkbook)
        : base(checkbook) { }
#pragma warning restore CS8618

    public Checkbook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Checkbook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckbookFromRaw.FromRawUnchecked"/>
    public static Checkbook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckbookFromRaw : IFromRawJson<Checkbook>
{
    /// <inheritdoc/>
    public Checkbook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Checkbook.FromRawUnchecked(rawData);
}

/// <summary>
/// The destination address that the Checkbook will be mailed to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckbookMailingAddress, CheckbookMailingAddressFromRaw>))]
public sealed record class CheckbookMailingAddress : JsonModel
{
    /// <summary>
    /// The city of the destination address.
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
    /// The first line of the destination address.
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
    /// The second line of the destination address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The recipient at the destination address.
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
    /// The postal code of the destination address.
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
    /// The state of the destination address.
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
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
    }

    public CheckbookMailingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckbookMailingAddress(CheckbookMailingAddress checkbookMailingAddress)
        : base(checkbookMailingAddress) { }
#pragma warning restore CS8618

    public CheckbookMailingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckbookMailingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckbookMailingAddressFromRaw.FromRawUnchecked"/>
    public static CheckbookMailingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckbookMailingAddressFromRaw : IFromRawJson<CheckbookMailingAddress>
{
    /// <inheritdoc/>
    public CheckbookMailingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckbookMailingAddress.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CheckbookPayer, CheckbookPayerFromRaw>))]
public sealed record class CheckbookPayer : JsonModel
{
    /// <summary>
    /// The contents of the line.
    /// </summary>
    public required string Contents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contents");
        }
        init { this._rawData.Set("contents", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contents;
    }

    public CheckbookPayer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckbookPayer(CheckbookPayer checkbookPayer)
        : base(checkbookPayer) { }
#pragma warning restore CS8618

    public CheckbookPayer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckbookPayer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckbookPayerFromRaw.FromRawUnchecked"/>
    public static CheckbookPayer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckbookPayer(string contents)
        : this()
    {
        this.Contents = contents;
    }
}

class CheckbookPayerFromRaw : IFromRawJson<CheckbookPayer>
{
    /// <inheritdoc/>
    public CheckbookPayer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckbookPayer.FromRawUnchecked(rawData);
}

/// <summary>
/// The address the Checkbook will return to if there is a delivery issue.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReturnAddress, ReturnAddressFromRaw>))]
public sealed record class ReturnAddress : JsonModel
{
    /// <summary>
    /// The city of the return address.
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
    /// The first line of the return address.
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
    /// The second line of the return address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The recipient at the return address.
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
    /// The postal code of the return address.
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
    /// The state of the return address.
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
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
    }

    public ReturnAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReturnAddress(ReturnAddress returnAddress)
        : base(returnAddress) { }
#pragma warning restore CS8618

    public ReturnAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReturnAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReturnAddressFromRaw.FromRawUnchecked"/>
    public static ReturnAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReturnAddressFromRaw : IFromRawJson<ReturnAddress>
{
    /// <inheritdoc/>
    public ReturnAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReturnAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The lifecycle status of the Checkbook.
/// </summary>
[JsonConverter(typeof(CheckbookStatusConverter))]
public enum CheckbookStatus
{
    /// <summary>
    /// The Checkbook is pending submission to the printer.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The Checkbook has been submitted to the printer and is pending mailing.
    /// </summary>
    PendingMailing,

    /// <summary>
    /// The Checkbook has been mailed.
    /// </summary>
    Mailed,

    /// <summary>
    /// The Checkbook has been stopped and its checks can no longer be deposited.
    /// </summary>
    Stopped,
}

sealed class CheckbookStatusConverter : JsonConverter<CheckbookStatus>
{
    public override CheckbookStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_submission" => CheckbookStatus.PendingSubmission,
            "pending_mailing" => CheckbookStatus.PendingMailing,
            "mailed" => CheckbookStatus.Mailed,
            "stopped" => CheckbookStatus.Stopped,
            _ => (CheckbookStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckbookStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckbookStatus.PendingSubmission => "pending_submission",
                CheckbookStatus.PendingMailing => "pending_mailing",
                CheckbookStatus.Mailed => "mailed",
                CheckbookStatus.Stopped => "stopped",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The physical format of the Checkbook.
/// </summary>
[JsonConverter(typeof(StyleConverter))]
public enum Style
{
    /// <summary>
    /// A half-inch three-ring binder holding 75 pages of checks with 3 checks per page.
    /// </summary>
    ThreeRingBinder,

    /// <summary>
    /// A folder holding 15 pages of checks with 3 checks per page.
    /// </summary>
    Folder,
}

sealed class StyleConverter : JsonConverter<Style>
{
    public override Style Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "three_ring_binder" => Style.ThreeRingBinder,
            "folder" => Style.Folder,
            _ => (Style)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Style value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Style.ThreeRingBinder => "three_ring_binder",
                Style.Folder => "folder",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TrackingUpdate, TrackingUpdateFromRaw>))]
public sealed record class TrackingUpdate : JsonModel
{
    /// <summary>
    /// The type of tracking event.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code for the country where the event took place.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the tracking event took place.
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
    /// The postal code where the event took place.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        _ = this.Country;
        _ = this.CreatedAt;
        _ = this.PostalCode;
    }

    public TrackingUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrackingUpdate(TrackingUpdate trackingUpdate)
        : base(trackingUpdate) { }
#pragma warning restore CS8618

    public TrackingUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackingUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackingUpdateFromRaw.FromRawUnchecked"/>
    public static TrackingUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackingUpdateFromRaw : IFromRawJson<TrackingUpdate>
{
    /// <inheritdoc/>
    public TrackingUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackingUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of tracking event.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The checkbook is in transit.
    /// </summary>
    InTransit,

    /// <summary>
    /// The checkbook has been processed for delivery.
    /// </summary>
    ProcessedForDelivery,

    /// <summary>
    /// The checkbook has been delivered. Note that some couriers track delivery status
    /// based on driver location data rather than an explicit scan. While uncommon,
    /// a single checkbook may have more than one delivered event.
    /// </summary>
    Delivered,

    /// <summary>
    /// There is an issue preventing delivery. The delivery will be attempted again
    /// if possible. If the issue cannot be resolved, the checkbook will be rerouted
    /// to the return address.
    /// </summary>
    DeliveryIssue,

    /// <summary>
    /// The checkbook has been rerouted to the return address.
    /// </summary>
    ReturningToSender,

    /// <summary>
    /// The checkbook has been delivered to the return address.
    /// </summary>
    ReturnedToSender,
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
            "in_transit" => Category.InTransit,
            "processed_for_delivery" => Category.ProcessedForDelivery,
            "delivered" => Category.Delivered,
            "delivery_issue" => Category.DeliveryIssue,
            "returning_to_sender" => Category.ReturningToSender,
            "returned_to_sender" => Category.ReturnedToSender,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.InTransit => "in_transit",
                Category.ProcessedForDelivery => "processed_for_delivery",
                Category.Delivered => "delivered",
                Category.DeliveryIssue => "delivery_issue",
                Category.ReturningToSender => "returning_to_sender",
                Category.ReturnedToSender => "returned_to_sender",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `checkbook`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Checkbook,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Checkbooks.Type>
{
    public override global::Increase.Api.Models.Checkbooks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checkbook" => global::Increase.Api.Models.Checkbooks.Type.Checkbook,
            _ => (global::Increase.Api.Models.Checkbooks.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Checkbooks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Checkbooks.Type.Checkbook => "checkbook",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
