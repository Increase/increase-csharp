using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.PhysicalCards;

/// <summary>
/// Custom physical Visa cards that are shipped to your customers. The artwork is
/// configurable by a connected [Card Profile](/documentation/api#card-profiles).
/// The same Card can be used for multiple Physical Cards. Printing cards incurs
/// a fee. Please contact [support@increase.com](mailto:support@increase.com) for pricing!
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhysicalCard, PhysicalCardFromRaw>))]
public sealed record class PhysicalCard : JsonModel
{
    /// <summary>
    /// The physical card identifier.
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
    /// The identifier for the Card this Physical Card represents.
    /// </summary>
    public required string CardID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_id");
        }
        init { this._rawData.Set("card_id", value); }
    }

    /// <summary>
    /// Details about the cardholder, as it appears on the printed card.
    /// </summary>
    public required PhysicalCardCardholder Cardholder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhysicalCardCardholder>("cardholder");
        }
        init { this._rawData.Set("cardholder", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Physical Card was created.
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
    /// The Physical Card Profile used for this Physical Card.
    /// </summary>
    public required string? PhysicalCardProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("physical_card_profile_id");
        }
        init { this._rawData.Set("physical_card_profile_id", value); }
    }

    /// <summary>
    /// The details used to ship this physical card.
    /// </summary>
    public required PhysicalCardShipment Shipment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhysicalCardShipment>("shipment");
        }
        init { this._rawData.Set("shipment", value); }
    }

    /// <summary>
    /// The status of the Physical Card.
    /// </summary>
    public required ApiEnum<string, PhysicalCardStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhysicalCardStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `physical_card`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.PhysicalCards.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.PhysicalCards.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardID;
        this.Cardholder.Validate();
        _ = this.CreatedAt;
        _ = this.IdempotencyKey;
        _ = this.PhysicalCardProfileID;
        this.Shipment.Validate();
        this.Status.Validate();
        this.Type.Validate();
    }

    public PhysicalCard() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCard(PhysicalCard physicalCard)
        : base(physicalCard) { }
#pragma warning restore CS8618

    public PhysicalCard(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCard(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardFromRaw.FromRawUnchecked"/>
    public static PhysicalCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardFromRaw : IFromRawJson<PhysicalCard>
{
    /// <inheritdoc/>
    public PhysicalCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhysicalCard.FromRawUnchecked(rawData);
}

/// <summary>
/// Details about the cardholder, as it appears on the printed card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhysicalCardCardholder, PhysicalCardCardholderFromRaw>))]
public sealed record class PhysicalCardCardholder : JsonModel
{
    /// <summary>
    /// The cardholder's first name.
    /// </summary>
    public required string FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_name");
        }
        init { this._rawData.Set("first_name", value); }
    }

    /// <summary>
    /// The cardholder's last name.
    /// </summary>
    public required string LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_name");
        }
        init { this._rawData.Set("last_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstName;
        _ = this.LastName;
    }

    public PhysicalCardCardholder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardCardholder(PhysicalCardCardholder physicalCardCardholder)
        : base(physicalCardCardholder) { }
#pragma warning restore CS8618

    public PhysicalCardCardholder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardCardholder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardCardholderFromRaw.FromRawUnchecked"/>
    public static PhysicalCardCardholder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardCardholderFromRaw : IFromRawJson<PhysicalCardCardholder>
{
    /// <inheritdoc/>
    public PhysicalCardCardholder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCardCardholder.FromRawUnchecked(rawData);
}

/// <summary>
/// The details used to ship this physical card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhysicalCardShipment, PhysicalCardShipmentFromRaw>))]
public sealed record class PhysicalCardShipment : JsonModel
{
    /// <summary>
    /// The location to where the card's packing label is addressed.
    /// </summary>
    public required PhysicalCardShipmentAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhysicalCardShipmentAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The shipping method.
    /// </summary>
    public required ApiEnum<string, PhysicalCardShipmentMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhysicalCardShipmentMethod>>(
                "method"
            );
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// When this physical card should be produced by the card printer. The default
    /// timeline is the day after the card printer receives the order, except for
    /// `FEDEX_PRIORITY_OVERNIGHT` cards, which default to `SAME_DAY`. To use faster
    /// production methods, please reach out to [support@increase.com](mailto:support@increase.com).
    /// </summary>
    public required ApiEnum<string, PhysicalCardShipmentSchedule> Schedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhysicalCardShipmentSchedule>>(
                "schedule"
            );
        }
        init { this._rawData.Set("schedule", value); }
    }

    /// <summary>
    /// The status of this shipment.
    /// </summary>
    public required ApiEnum<string, PhysicalCardShipmentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhysicalCardShipmentStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Tracking details for the shipment.
    /// </summary>
    public required Tracking? Tracking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Tracking>("tracking");
        }
        init { this._rawData.Set("tracking", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        this.Method.Validate();
        this.Schedule.Validate();
        this.Status.Validate();
        this.Tracking?.Validate();
    }

    public PhysicalCardShipment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardShipment(PhysicalCardShipment physicalCardShipment)
        : base(physicalCardShipment) { }
#pragma warning restore CS8618

    public PhysicalCardShipment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardShipment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardShipmentFromRaw.FromRawUnchecked"/>
    public static PhysicalCardShipment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardShipmentFromRaw : IFromRawJson<PhysicalCardShipment>
{
    /// <inheritdoc/>
    public PhysicalCardShipment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCardShipment.FromRawUnchecked(rawData);
}

/// <summary>
/// The location to where the card's packing label is addressed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PhysicalCardShipmentAddress, PhysicalCardShipmentAddressFromRaw>)
)]
public sealed record class PhysicalCardShipmentAddress : JsonModel
{
    /// <summary>
    /// The city of the shipping address.
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
    /// The country of the shipping address.
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
    /// The first line of the shipping address.
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
    /// The second line of the shipping address.
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
    /// The third line of the shipping address.
    /// </summary>
    public required string? Line3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line3");
        }
        init { this._rawData.Set("line3", value); }
    }

    /// <summary>
    /// The name of the recipient.
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
    /// The postal code of the shipping address.
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
    /// The state of the shipping address.
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
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Line3;
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
    }

    public PhysicalCardShipmentAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardShipmentAddress(PhysicalCardShipmentAddress physicalCardShipmentAddress)
        : base(physicalCardShipmentAddress) { }
#pragma warning restore CS8618

    public PhysicalCardShipmentAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardShipmentAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardShipmentAddressFromRaw.FromRawUnchecked"/>
    public static PhysicalCardShipmentAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardShipmentAddressFromRaw : IFromRawJson<PhysicalCardShipmentAddress>
{
    /// <inheritdoc/>
    public PhysicalCardShipmentAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCardShipmentAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The shipping method.
/// </summary>
[JsonConverter(typeof(PhysicalCardShipmentMethodConverter))]
public enum PhysicalCardShipmentMethod
{
    /// <summary>
    /// USPS Post.
    /// </summary>
    Usps,

    /// <summary>
    /// FedEx Priority Overnight, no signature.
    /// </summary>
    FedexPriorityOvernight,

    /// <summary>
    /// FedEx 2-day.
    /// </summary>
    Fedex2Day,

    /// <summary>
    /// DHL Worldwide Express, international shipping only.
    /// </summary>
    DhlWorldwideExpress,
}

sealed class PhysicalCardShipmentMethodConverter : JsonConverter<PhysicalCardShipmentMethod>
{
    public override PhysicalCardShipmentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usps" => PhysicalCardShipmentMethod.Usps,
            "fedex_priority_overnight" => PhysicalCardShipmentMethod.FedexPriorityOvernight,
            "fedex_2_day" => PhysicalCardShipmentMethod.Fedex2Day,
            "dhl_worldwide_express" => PhysicalCardShipmentMethod.DhlWorldwideExpress,
            _ => (PhysicalCardShipmentMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhysicalCardShipmentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhysicalCardShipmentMethod.Usps => "usps",
                PhysicalCardShipmentMethod.FedexPriorityOvernight => "fedex_priority_overnight",
                PhysicalCardShipmentMethod.Fedex2Day => "fedex_2_day",
                PhysicalCardShipmentMethod.DhlWorldwideExpress => "dhl_worldwide_express",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When this physical card should be produced by the card printer. The default timeline
/// is the day after the card printer receives the order, except for `FEDEX_PRIORITY_OVERNIGHT`
/// cards, which default to `SAME_DAY`. To use faster production methods, please
/// reach out to [support@increase.com](mailto:support@increase.com).
/// </summary>
[JsonConverter(typeof(PhysicalCardShipmentScheduleConverter))]
public enum PhysicalCardShipmentSchedule
{
    /// <summary>
    /// The physical card will be shipped one business day after the order is received
    /// by the card printer. A card that is submitted to Increase on a Monday evening
    /// (Pacific Time) will ship out on Wednesday.
    /// </summary>
    NextDay,

    /// <summary>
    /// The physical card will be shipped on the same business day that the order
    /// is received by the card printer. A card that is submitted to Increase on
    /// a Monday evening (Pacific Time) will ship out on Tuesday.
    /// </summary>
    SameDay,
}

sealed class PhysicalCardShipmentScheduleConverter : JsonConverter<PhysicalCardShipmentSchedule>
{
    public override PhysicalCardShipmentSchedule Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "next_day" => PhysicalCardShipmentSchedule.NextDay,
            "same_day" => PhysicalCardShipmentSchedule.SameDay,
            _ => (PhysicalCardShipmentSchedule)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhysicalCardShipmentSchedule value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhysicalCardShipmentSchedule.NextDay => "next_day",
                PhysicalCardShipmentSchedule.SameDay => "same_day",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of this shipment.
/// </summary>
[JsonConverter(typeof(PhysicalCardShipmentStatusConverter))]
public enum PhysicalCardShipmentStatus
{
    /// <summary>
    /// The physical card has not yet been shipped.
    /// </summary>
    Pending,

    /// <summary>
    /// The physical card shipment was canceled prior to submission.
    /// </summary>
    Canceled,

    /// <summary>
    /// The physical card shipment has been submitted to the card fulfillment provider.
    /// </summary>
    Submitted,

    /// <summary>
    /// The physical card shipment has been acknowledged by the card fulfillment provider
    /// and will be processed in their next batch.
    /// </summary>
    Acknowledged,

    /// <summary>
    /// The physical card shipment was rejected by the card printer due to an error.
    /// </summary>
    Rejected,

    /// <summary>
    /// The physical card has been shipped.
    /// </summary>
    Shipped,

    /// <summary>
    /// The physical card shipment was returned to the sender and destroyed by the
    /// production facility.
    /// </summary>
    Returned,

    /// <summary>
    /// The physical card shipment requires attention from Increase before progressing.
    /// </summary>
    RequiresAttention,
}

sealed class PhysicalCardShipmentStatusConverter : JsonConverter<PhysicalCardShipmentStatus>
{
    public override PhysicalCardShipmentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => PhysicalCardShipmentStatus.Pending,
            "canceled" => PhysicalCardShipmentStatus.Canceled,
            "submitted" => PhysicalCardShipmentStatus.Submitted,
            "acknowledged" => PhysicalCardShipmentStatus.Acknowledged,
            "rejected" => PhysicalCardShipmentStatus.Rejected,
            "shipped" => PhysicalCardShipmentStatus.Shipped,
            "returned" => PhysicalCardShipmentStatus.Returned,
            "requires_attention" => PhysicalCardShipmentStatus.RequiresAttention,
            _ => (PhysicalCardShipmentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhysicalCardShipmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhysicalCardShipmentStatus.Pending => "pending",
                PhysicalCardShipmentStatus.Canceled => "canceled",
                PhysicalCardShipmentStatus.Submitted => "submitted",
                PhysicalCardShipmentStatus.Acknowledged => "acknowledged",
                PhysicalCardShipmentStatus.Rejected => "rejected",
                PhysicalCardShipmentStatus.Shipped => "shipped",
                PhysicalCardShipmentStatus.Returned => "returned",
                PhysicalCardShipmentStatus.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tracking details for the shipment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tracking, TrackingFromRaw>))]
public sealed record class Tracking : JsonModel
{
    /// <summary>
    /// The tracking number. Not available for USPS shipments.
    /// </summary>
    public required string? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// For returned shipments, the tracking number of the return shipment.
    /// </summary>
    public required string? ReturnNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_number");
        }
        init { this._rawData.Set("return_number", value); }
    }

    /// <summary>
    /// For returned shipments, this describes why the package was returned.
    /// </summary>
    public required string? ReturnReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("return_reason");
        }
        init { this._rawData.Set("return_reason", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the fulfillment provider marked the card as ready for pick-up by the shipment carrier.
    /// </summary>
    public required System::DateTimeOffset ShippedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("shipped_at");
        }
        init { this._rawData.Set("shipped_at", value); }
    }

    /// <summary>
    /// Tracking updates relating to the physical card's delivery.
    /// </summary>
    public required IReadOnlyList<Update> Updates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Update>>("updates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Update>>(
                "updates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Number;
        _ = this.ReturnNumber;
        _ = this.ReturnReason;
        _ = this.ShippedAt;
        foreach (var item in this.Updates)
        {
            item.Validate();
        }
    }

    public Tracking() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tracking(Tracking tracking)
        : base(tracking) { }
#pragma warning restore CS8618

    public Tracking(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tracking(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackingFromRaw.FromRawUnchecked"/>
    public static Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackingFromRaw : IFromRawJson<Tracking>
{
    /// <inheritdoc/>
    public Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tracking.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Update, UpdateFromRaw>))]
public sealed record class Update : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time when
    /// the carrier expects the card to be delivered.
    /// </summary>
    public required System::DateTimeOffset? CarrierEstimatedDeliveryAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "carrier_estimated_delivery_at"
            );
        }
        init { this._rawData.Set("carrier_estimated_delivery_at", value); }
    }

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
    /// The city where the event took place.
    /// </summary>
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
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
    public required string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The state where the event took place.
    /// </summary>
    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierEstimatedDeliveryAt;
        this.Category.Validate();
        _ = this.City;
        _ = this.CreatedAt;
        _ = this.PostalCode;
        _ = this.State;
    }

    public Update() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Update(Update update)
        : base(update) { }
#pragma warning restore CS8618

    public Update(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Update(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFromRaw.FromRawUnchecked"/>
    public static Update FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFromRaw : IFromRawJson<Update>
{
    /// <inheritdoc/>
    public Update FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Update.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of tracking event.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The physical card is in transit.
    /// </summary>
    InTransit,

    /// <summary>
    /// The physical card has been processed for delivery.
    /// </summary>
    ProcessedForDelivery,

    /// <summary>
    /// The physical card has been delivered.
    /// </summary>
    Delivered,

    /// <summary>
    /// There is an issue preventing delivery. The delivery will be attempted again
    /// if possible. If the issue cannot be resolved, the physical card will be returned
    /// to sender.
    /// </summary>
    DeliveryIssue,

    /// <summary>
    /// Delivery failed and the physical card was returned to sender.
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
/// The status of the Physical Card.
/// </summary>
[JsonConverter(typeof(PhysicalCardStatusConverter))]
public enum PhysicalCardStatus
{
    /// <summary>
    /// The physical card is active.
    /// </summary>
    Active,

    /// <summary>
    /// The physical card is temporarily disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// The physical card is permanently canceled.
    /// </summary>
    Canceled,
}

sealed class PhysicalCardStatusConverter : JsonConverter<PhysicalCardStatus>
{
    public override PhysicalCardStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => PhysicalCardStatus.Active,
            "disabled" => PhysicalCardStatus.Disabled,
            "canceled" => PhysicalCardStatus.Canceled,
            _ => (PhysicalCardStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhysicalCardStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhysicalCardStatus.Active => "active",
                PhysicalCardStatus.Disabled => "disabled",
                PhysicalCardStatus.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `physical_card`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    PhysicalCard,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.PhysicalCards.Type>
{
    public override global::Increase.Api.Models.PhysicalCards.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical_card" => global::Increase.Api.Models.PhysicalCards.Type.PhysicalCard,
            _ => (global::Increase.Api.Models.PhysicalCards.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.PhysicalCards.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.PhysicalCards.Type.PhysicalCard => "physical_card",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
