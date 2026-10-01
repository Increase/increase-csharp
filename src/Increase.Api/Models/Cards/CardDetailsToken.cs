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
/// A short-lived token that authorizes Increase Card Elements to render the details
/// of a single Card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDetailsToken, CardDetailsTokenFromRaw>))]
public sealed record class CardDetailsToken : JsonModel
{
    /// <summary>
    /// The token. Pass this to the `@increasebank/card-elements` library in your
    /// frontend. Treat it as a credential: it authorizes anyone holding it to read
    /// the Card's details until it expires.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// The time the token will expire. Tokens are valid for one hour.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `card_details_token`.
    /// </summary>
    public required ApiEnum<string, CardDetailsTokenType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDetailsTokenType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.ExpiresAt;
        this.Type.Validate();
    }

    public CardDetailsToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDetailsToken(CardDetailsToken cardDetailsToken)
        : base(cardDetailsToken) { }
#pragma warning restore CS8618

    public CardDetailsToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDetailsToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDetailsTokenFromRaw.FromRawUnchecked"/>
    public static CardDetailsToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDetailsTokenFromRaw : IFromRawJson<CardDetailsToken>
{
    /// <inheritdoc/>
    public CardDetailsToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDetailsToken.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_details_token`.
/// </summary>
[JsonConverter(typeof(CardDetailsTokenTypeConverter))]
public enum CardDetailsTokenType
{
    CardDetailsToken,
}

sealed class CardDetailsTokenTypeConverter : JsonConverter<CardDetailsTokenType>
{
    public override CardDetailsTokenType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_details_token" => CardDetailsTokenType.CardDetailsToken,
            _ => (CardDetailsTokenType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDetailsTokenType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDetailsTokenType.CardDetailsToken => "card_details_token",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
