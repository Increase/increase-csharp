using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardTokens;

/// <summary>
/// Card Tokens represent a tokenized card number that can be used for Card Push
/// Transfers and Card Validations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardToken, CardTokenFromRaw>))]
public sealed record class CardToken : JsonModel
{
    /// <summary>
    /// The Card Token's identifier.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the card token was created.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date when the card expires.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The last 4 digits of the card number.
    /// </summary>
    public required string Last4
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last4");
        }
        init { this._rawData.Set("last4", value); }
    }

    /// <summary>
    /// The length of the card number.
    /// </summary>
    public required long Length
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("length");
        }
        init { this._rawData.Set("length", value); }
    }

    /// <summary>
    /// The prefix of the card number, usually 8 digits.
    /// </summary>
    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_token`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CardTokens.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CardTokens.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ExpirationDate;
        _ = this.Last4;
        _ = this.Length;
        _ = this.Prefix;
        this.Type.Validate();
    }

    public CardToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardToken(CardToken cardToken)
        : base(cardToken) { }
#pragma warning restore CS8618

    public CardToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardTokenFromRaw.FromRawUnchecked"/>
    public static CardToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardTokenFromRaw : IFromRawJson<CardToken>
{
    /// <inheritdoc/>
    public CardToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardToken.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_token`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardToken,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CardTokens.Type>
{
    public override global::Increase.Api.Models.CardTokens.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_token" => global::Increase.Api.Models.CardTokens.Type.CardToken,
            _ => (global::Increase.Api.Models.CardTokens.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CardTokens.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CardTokens.Type.CardToken => "card_token",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
