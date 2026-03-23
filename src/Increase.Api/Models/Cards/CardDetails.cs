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
/// An object containing the sensitive details (card number, CVC, PIN, etc) for a
/// Card. These details are not included in the Card object. If you'd prefer to never
/// access these details directly, you can use the [embedded iframe](/documentation/embedded-card-component)
/// to display the information to your users.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDetails, CardDetailsFromRaw>))]
public sealed record class CardDetails : JsonModel
{
    /// <summary>
    /// The identifier for the Card for which sensitive details have been returned.
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
    /// The month the card expires in M format (e.g., August is 8).
    /// </summary>
    public required long ExpirationMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expiration_month");
        }
        init { this._rawData.Set("expiration_month", value); }
    }

    /// <summary>
    /// The year the card expires in YYYY format (e.g., 2025).
    /// </summary>
    public required long ExpirationYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expiration_year");
        }
        init { this._rawData.Set("expiration_year", value); }
    }

    /// <summary>
    /// The 4-digit PIN for the card, for use with ATMs.
    /// </summary>
    public required string Pin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pin");
        }
        init { this._rawData.Set("pin", value); }
    }

    /// <summary>
    /// The card number.
    /// </summary>
    public required string PrimaryAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("primary_account_number");
        }
        init { this._rawData.Set("primary_account_number", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_details`.
    /// </summary>
    public required ApiEnum<string, CardDetailsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardDetailsType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The three-digit verification code for the card. It's also known as the Card
    /// Verification Code (CVC), the Card Verification Value (CVV), or the Card Identification (CID).
    /// </summary>
    public required string VerificationCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("verification_code");
        }
        init { this._rawData.Set("verification_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CardID;
        _ = this.ExpirationMonth;
        _ = this.ExpirationYear;
        _ = this.Pin;
        _ = this.PrimaryAccountNumber;
        this.Type.Validate();
        _ = this.VerificationCode;
    }

    public CardDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDetails(CardDetails cardDetails)
        : base(cardDetails) { }
#pragma warning restore CS8618

    public CardDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDetailsFromRaw.FromRawUnchecked"/>
    public static CardDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDetailsFromRaw : IFromRawJson<CardDetails>
{
    /// <inheritdoc/>
    public CardDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_details`.
/// </summary>
[JsonConverter(typeof(CardDetailsTypeConverter))]
public enum CardDetailsType
{
    CardDetails,
}

sealed class CardDetailsTypeConverter : JsonConverter<CardDetailsType>
{
    public override CardDetailsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_details" => CardDetailsType.CardDetails,
            _ => (CardDetailsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardDetailsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardDetailsType.CardDetails => "card_details",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
