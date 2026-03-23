using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.PhysicalCards;

/// <summary>
/// Create a Physical Card
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhysicalCardCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The underlying card representing this physical card.
    /// </summary>
    public required string CardID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("card_id");
        }
        init { this._rawBodyData.Set("card_id", value); }
    }

    /// <summary>
    /// Details about the cardholder, as it will appear on the physical card.
    /// </summary>
    public required Cardholder Cardholder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Cardholder>("cardholder");
        }
        init { this._rawBodyData.Set("cardholder", value); }
    }

    /// <summary>
    /// The details used to ship this physical card.
    /// </summary>
    public required Shipment Shipment
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Shipment>("shipment");
        }
        init { this._rawBodyData.Set("shipment", value); }
    }

    /// <summary>
    /// The physical card profile to use for this physical card. The latest default
    /// physical card profile will be used if not provided.
    /// </summary>
    public string? PhysicalCardProfileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("physical_card_profile_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("physical_card_profile_id", value);
        }
    }

    public PhysicalCardCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardCreateParams(PhysicalCardCreateParams physicalCardCreateParams)
        : base(physicalCardCreateParams)
    {
        this._rawBodyData = new(physicalCardCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PhysicalCardCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhysicalCardCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PhysicalCardCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/physical_cards")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Details about the cardholder, as it will appear on the physical card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cardholder, CardholderFromRaw>))]
public sealed record class Cardholder : JsonModel
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

    public Cardholder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cardholder(Cardholder cardholder)
        : base(cardholder) { }
#pragma warning restore CS8618

    public Cardholder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cardholder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardholderFromRaw.FromRawUnchecked"/>
    public static Cardholder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardholderFromRaw : IFromRawJson<Cardholder>
{
    /// <inheritdoc/>
    public Cardholder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cardholder.FromRawUnchecked(rawData);
}

/// <summary>
/// The details used to ship this physical card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Shipment, ShipmentFromRaw>))]
public sealed record class Shipment : JsonModel
{
    /// <summary>
    /// The address to where the card should be shipped.
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
    /// The shipping method to use.
    /// </summary>
    public required ApiEnum<string, Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Method>>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// When this physical card should be produced by the card printer. The default
    /// timeline is the day after the card printer receives the order, except for
    /// `FEDEX_PRIORITY_OVERNIGHT` cards, which default to `SAME_DAY`. To use faster
    /// production methods, please reach out to [support@increase.com](mailto:support@increase.com).
    /// </summary>
    public ApiEnum<string, Schedule>? Schedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Schedule>>("schedule");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("schedule", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        this.Method.Validate();
        this.Schedule?.Validate();
    }

    public Shipment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Shipment(Shipment shipment)
        : base(shipment) { }
#pragma warning restore CS8618

    public Shipment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Shipment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShipmentFromRaw.FromRawUnchecked"/>
    public static Shipment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShipmentFromRaw : IFromRawJson<Shipment>
{
    /// <inheritdoc/>
    public Shipment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Shipment.FromRawUnchecked(rawData);
}

/// <summary>
/// The address to where the card should be shipped.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
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

    /// <summary>
    /// The two-character ISO 3166-1 code of the country where the card should be
    /// shipped (e.g., `US`). Please reach out to [support@increase.com](mailto:support@increase.com)
    /// to ship cards internationally.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// The second line of the shipping address.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <summary>
    /// The third line of the shipping address.
    /// </summary>
    public string? Line3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line3", value);
        }
    }

    /// <summary>
    /// The phone number of the recipient.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Country;
        _ = this.Line2;
        _ = this.Line3;
        _ = this.PhoneNumber;
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
/// The shipping method to use.
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
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

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usps" => Method.Usps,
            "fedex_priority_overnight" => Method.FedexPriorityOvernight,
            "fedex_2_day" => Method.Fedex2Day,
            "dhl_worldwide_express" => Method.DhlWorldwideExpress,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.Usps => "usps",
                Method.FedexPriorityOvernight => "fedex_priority_overnight",
                Method.Fedex2Day => "fedex_2_day",
                Method.DhlWorldwideExpress => "dhl_worldwide_express",
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
[JsonConverter(typeof(ScheduleConverter))]
public enum Schedule
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

sealed class ScheduleConverter : JsonConverter<Schedule>
{
    public override Schedule Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "next_day" => Schedule.NextDay,
            "same_day" => Schedule.SameDay,
            _ => (Schedule)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Schedule value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Schedule.NextDay => "next_day",
                Schedule.SameDay => "same_day",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
