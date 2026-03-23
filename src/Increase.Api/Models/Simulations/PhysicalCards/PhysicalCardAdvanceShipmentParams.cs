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
/// This endpoint allows you to simulate advancing the shipment status of a Physical
/// Card, to simulate e.g., that a physical card was attempted shipped but then failed delivery.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhysicalCardAdvanceShipmentParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PhysicalCardID { get; init; }

    /// <summary>
    /// The shipment status to move the Physical Card to.
    /// </summary>
    public required ApiEnum<string, ShipmentStatus> ShipmentStatus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ShipmentStatus>>(
                "shipment_status"
            );
        }
        init { this._rawBodyData.Set("shipment_status", value); }
    }

    public PhysicalCardAdvanceShipmentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardAdvanceShipmentParams(
        PhysicalCardAdvanceShipmentParams physicalCardAdvanceShipmentParams
    )
        : base(physicalCardAdvanceShipmentParams)
    {
        this.PhysicalCardID = physicalCardAdvanceShipmentParams.PhysicalCardID;

        this._rawBodyData = new(physicalCardAdvanceShipmentParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PhysicalCardAdvanceShipmentParams(
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
    PhysicalCardAdvanceShipmentParams(
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
    public static PhysicalCardAdvanceShipmentParams FromRawUnchecked(
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

    public virtual bool Equals(PhysicalCardAdvanceShipmentParams? other)
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
                    "/simulations/physical_cards/{0}/advance_shipment",
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
/// The shipment status to move the Physical Card to.
/// </summary>
[JsonConverter(typeof(ShipmentStatusConverter))]
public enum ShipmentStatus
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

sealed class ShipmentStatusConverter : JsonConverter<ShipmentStatus>
{
    public override ShipmentStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ShipmentStatus.Pending,
            "canceled" => ShipmentStatus.Canceled,
            "submitted" => ShipmentStatus.Submitted,
            "acknowledged" => ShipmentStatus.Acknowledged,
            "rejected" => ShipmentStatus.Rejected,
            "shipped" => ShipmentStatus.Shipped,
            "returned" => ShipmentStatus.Returned,
            "requires_attention" => ShipmentStatus.RequiresAttention,
            _ => (ShipmentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShipmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShipmentStatus.Pending => "pending",
                ShipmentStatus.Canceled => "canceled",
                ShipmentStatus.Submitted => "submitted",
                ShipmentStatus.Acknowledged => "acknowledged",
                ShipmentStatus.Rejected => "rejected",
                ShipmentStatus.Shipped => "shipped",
                ShipmentStatus.Returned => "returned",
                ShipmentStatus.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
