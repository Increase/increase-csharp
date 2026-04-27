using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardTokens;

/// <summary>
/// The capabilities of a Card Token describe whether the card can be used for specific
/// operations, such as Card Push Transfers. The capabilities can change over time
/// based on the issuing bank's configuration of the card range.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardTokenCapabilities, CardTokenCapabilitiesFromRaw>))]
public sealed record class CardTokenCapabilities : JsonModel
{
    /// <summary>
    /// Each route represent a path e.g., a push transfer can take.
    /// </summary>
    public required IReadOnlyList<Route> Routes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Route>>("routes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Route>>(
                "routes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_token_capabilities`.
    /// </summary>
    public required ApiEnum<string, CardTokenCapabilitiesType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardTokenCapabilitiesType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Routes)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public CardTokenCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardTokenCapabilities(CardTokenCapabilities cardTokenCapabilities)
        : base(cardTokenCapabilities) { }
#pragma warning restore CS8618

    public CardTokenCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardTokenCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardTokenCapabilitiesFromRaw.FromRawUnchecked"/>
    public static CardTokenCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardTokenCapabilitiesFromRaw : IFromRawJson<CardTokenCapabilities>
{
    /// <inheritdoc/>
    public CardTokenCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardTokenCapabilities.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Route, RouteFromRaw>))]
public sealed record class Route : JsonModel
{
    /// <summary>
    /// Whether you can push funds to the card using cross-border Card Push Transfers.
    /// </summary>
    public required ApiEnum<string, CrossBorderPushTransfers> CrossBorderPushTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CrossBorderPushTransfers>>(
                "cross_border_push_transfers"
            );
        }
        init { this._rawData.Set("cross_border_push_transfers", value); }
    }

    /// <summary>
    /// Whether you can push funds to the card using domestic Card Push Transfers.
    /// </summary>
    public required ApiEnum<string, DomesticPushTransfers> DomesticPushTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DomesticPushTransfers>>(
                "domestic_push_transfers"
            );
        }
        init { this._rawData.Set("domestic_push_transfers", value); }
    }

    /// <summary>
    /// The ISO-3166-1 alpha-2 country code of the card's issuing bank.
    /// </summary>
    public required string IssuerCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("issuer_country");
        }
        init { this._rawData.Set("issuer_country", value); }
    }

    /// <summary>
    /// The card network route the capabilities apply to.
    /// </summary>
    public required ApiEnum<string, RouteRoute> RouteValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RouteRoute>>("route");
        }
        init { this._rawData.Set("route", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CrossBorderPushTransfers.Validate();
        this.DomesticPushTransfers.Validate();
        _ = this.IssuerCountry;
        this.RouteValue.Validate();
    }

    public Route() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Route(Route route)
        : base(route) { }
#pragma warning restore CS8618

    public Route(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Route(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteFromRaw.FromRawUnchecked"/>
    public static Route FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RouteFromRaw : IFromRawJson<Route>
{
    /// <inheritdoc/>
    public Route FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Route.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether you can push funds to the card using cross-border Card Push Transfers.
/// </summary>
[JsonConverter(typeof(CrossBorderPushTransfersConverter))]
public enum CrossBorderPushTransfers
{
    /// <summary>
    /// The capability is supported.
    /// </summary>
    Supported,

    /// <summary>
    /// The capability is not supported.
    /// </summary>
    NotSupported,
}

sealed class CrossBorderPushTransfersConverter : JsonConverter<CrossBorderPushTransfers>
{
    public override CrossBorderPushTransfers Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => CrossBorderPushTransfers.Supported,
            "not_supported" => CrossBorderPushTransfers.NotSupported,
            _ => (CrossBorderPushTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CrossBorderPushTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CrossBorderPushTransfers.Supported => "supported",
                CrossBorderPushTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether you can push funds to the card using domestic Card Push Transfers.
/// </summary>
[JsonConverter(typeof(DomesticPushTransfersConverter))]
public enum DomesticPushTransfers
{
    /// <summary>
    /// The capability is supported.
    /// </summary>
    Supported,

    /// <summary>
    /// The capability is not supported.
    /// </summary>
    NotSupported,
}

sealed class DomesticPushTransfersConverter : JsonConverter<DomesticPushTransfers>
{
    public override DomesticPushTransfers Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => DomesticPushTransfers.Supported,
            "not_supported" => DomesticPushTransfers.NotSupported,
            _ => (DomesticPushTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DomesticPushTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DomesticPushTransfers.Supported => "supported",
                DomesticPushTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card network route the capabilities apply to.
/// </summary>
[JsonConverter(typeof(RouteRouteConverter))]
public enum RouteRoute
{
    /// <summary>
    /// Visa and Interlink
    /// </summary>
    Visa,

    /// <summary>
    /// Mastercard and Maestro
    /// </summary>
    Mastercard,

    /// <summary>
    /// Pulse
    /// </summary>
    Pulse,
}

sealed class RouteRouteConverter : JsonConverter<RouteRoute>
{
    public override RouteRoute Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => RouteRoute.Visa,
            "mastercard" => RouteRoute.Mastercard,
            "pulse" => RouteRoute.Pulse,
            _ => (RouteRoute)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteRoute value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteRoute.Visa => "visa",
                RouteRoute.Mastercard => "mastercard",
                RouteRoute.Pulse => "pulse",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_token_capabilities`.
/// </summary>
[JsonConverter(typeof(CardTokenCapabilitiesTypeConverter))]
public enum CardTokenCapabilitiesType
{
    CardTokenCapabilities,
}

sealed class CardTokenCapabilitiesTypeConverter : JsonConverter<CardTokenCapabilitiesType>
{
    public override CardTokenCapabilitiesType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_token_capabilities" => CardTokenCapabilitiesType.CardTokenCapabilities,
            _ => (CardTokenCapabilitiesType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardTokenCapabilitiesType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardTokenCapabilitiesType.CardTokenCapabilities => "card_token_capabilities",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
