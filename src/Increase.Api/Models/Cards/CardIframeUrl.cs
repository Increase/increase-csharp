using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Cards;

/// <summary>
/// An object containing the iframe URL for a Card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardIframeUrl, CardIframeUrlFromRaw>))]
public sealed record class CardIframeUrl : JsonModel
{
    /// <summary>
    /// The time the iframe URL will expire.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The iframe URL for the Card. Treat this as an opaque URL.
    /// </summary>
    public required string IframeUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("iframe_url");
        }
        init { this._rawData.Set("iframe_url", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_iframe_url`.
    /// </summary>
    public required ApiEnum<string, CardIframeUrlType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardIframeUrlType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.IframeUrl;
        this.Type.Validate();
    }

    public CardIframeUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardIframeUrl(CardIframeUrl cardIframeUrl)
        : base(cardIframeUrl) { }
#pragma warning restore CS8618

    public CardIframeUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardIframeUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardIframeUrlFromRaw.FromRawUnchecked"/>
    public static CardIframeUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardIframeUrlFromRaw : IFromRawJson<CardIframeUrl>
{
    /// <inheritdoc/>
    public CardIframeUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardIframeUrl.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_iframe_url`.
/// </summary>
[JsonConverter(typeof(CardIframeUrlTypeConverter))]
public enum CardIframeUrlType
{
    CardIframeUrl,
}

sealed class CardIframeUrlTypeConverter : JsonConverter<CardIframeUrlType>
{
    public override CardIframeUrlType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_iframe_url" => CardIframeUrlType.CardIframeUrl,
            _ => (CardIframeUrlType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardIframeUrlType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardIframeUrlType.CardIframeUrl => "card_iframe_url",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
