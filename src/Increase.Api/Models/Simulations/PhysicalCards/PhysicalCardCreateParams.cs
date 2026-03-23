using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.PhysicalCards;

/// <summary>
/// This endpoint allows you to simulate receiving a tracking update for a Physical
/// Card, to simulate the progress of a shipment.
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

    public string? PhysicalCardID { get; init; }

    /// <summary>
    /// The type of tracking event.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawBodyData.Set("category", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time when
    /// the carrier expects the card to be delivered.
    /// </summary>
    public DateTimeOffset? CarrierEstimatedDeliveryAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>(
                "carrier_estimated_delivery_at"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("carrier_estimated_delivery_at", value);
        }
    }

    /// <summary>
    /// The city where the event took place.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("city", value);
        }
    }

    /// <summary>
    /// The postal code where the event took place.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// The state where the event took place.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("state", value);
        }
    }

    public PhysicalCardCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardCreateParams(PhysicalCardCreateParams physicalCardCreateParams)
        : base(physicalCardCreateParams)
    {
        this.PhysicalCardID = physicalCardCreateParams.PhysicalCardID;

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
        FrozenDictionary<string, JsonElement> rawBodyData,
        string physicalCardID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PhysicalCardID = physicalCardID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhysicalCardCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string physicalCardID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            physicalCardID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PhysicalCardID"] = JsonSerializer.SerializeToElement(this.PhysicalCardID),
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
        return (this.PhysicalCardID?.Equals(other.PhysicalCardID) ?? other.PhysicalCardID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/physical_cards/{0}/tracking_updates",
                    this.PhysicalCardID
                )
        )
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
        Type typeToConvert,
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
