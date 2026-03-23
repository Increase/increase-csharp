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
/// Cards are commercial credit cards. They'll immediately work for online purchases
/// after you create them. All cards maintain a credit limit of 100% of the Account’s
/// available balance at the time of transaction. Funds are deducted from the Account
/// upon transaction settlement.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Card, CardFromRaw>))]
public sealed record class Card : JsonModel
{
    /// <summary>
    /// The card identifier.
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
    /// The identifier for the account this card belongs to.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The Card's billing address.
    /// </summary>
    public required CardBillingAddress BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CardBillingAddress>("billing_address");
        }
        init { this._rawData.Set("billing_address", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Card was created.
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
    /// The card's description for display purposes.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The contact information used in the two-factor steps for digital wallet card
    /// creation. At least one field must be present to complete the digital wallet steps.
    /// </summary>
    public required CardDigitalWallet? DigitalWallet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardDigitalWallet>("digital_wallet");
        }
        init { this._rawData.Set("digital_wallet", value); }
    }

    /// <summary>
    /// The identifier for the entity associated with this card.
    /// </summary>
    public required string? EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
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
    /// The last 4 digits of the Card's Primary Account Number.
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
    /// This indicates if payments can be made with the card.
    /// </summary>
    public required ApiEnum<string, CardStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Cards.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Cards.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        this.BillingAddress.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        this.DigitalWallet?.Validate();
        _ = this.EntityID;
        _ = this.ExpirationMonth;
        _ = this.ExpirationYear;
        _ = this.IdempotencyKey;
        _ = this.Last4;
        this.Status.Validate();
        this.Type.Validate();
    }

    public Card() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Card(Card card)
        : base(card) { }
#pragma warning restore CS8618

    public Card(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Card(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFromRaw.FromRawUnchecked"/>
    public static Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFromRaw : IFromRawJson<Card>
{
    /// <inheritdoc/>
    public Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Card.FromRawUnchecked(rawData);
}

/// <summary>
/// The Card's billing address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardBillingAddress, CardBillingAddressFromRaw>))]
public sealed record class CardBillingAddress : JsonModel
{
    /// <summary>
    /// The city of the billing address.
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
    /// The first line of the billing address.
    /// </summary>
    public required string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the billing address.
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
    /// The postal code of the billing address.
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
    /// The US state of the billing address.
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
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public CardBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBillingAddress(CardBillingAddress cardBillingAddress)
        : base(cardBillingAddress) { }
#pragma warning restore CS8618

    public CardBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardBillingAddressFromRaw.FromRawUnchecked"/>
    public static CardBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardBillingAddressFromRaw : IFromRawJson<CardBillingAddress>
{
    /// <inheritdoc/>
    public CardBillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The contact information used in the two-factor steps for digital wallet card
/// creation. At least one field must be present to complete the digital wallet steps.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardDigitalWallet, CardDigitalWalletFromRaw>))]
public sealed record class CardDigitalWallet : JsonModel
{
    /// <summary>
    /// The digital card profile assigned to this digital card. Card profiles may
    /// also be assigned at the program level.
    /// </summary>
    public required string? DigitalCardProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("digital_card_profile_id");
        }
        init { this._rawData.Set("digital_card_profile_id", value); }
    }

    /// <summary>
    /// An email address that can be used to verify the cardholder via one-time passcode
    /// over email.
    /// </summary>
    public required string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// A phone number that can be used to verify the cardholder via one-time passcode
    /// over SMS.
    /// </summary>
    public required string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DigitalCardProfileID;
        _ = this.Email;
        _ = this.Phone;
    }

    public CardDigitalWallet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDigitalWallet(CardDigitalWallet cardDigitalWallet)
        : base(cardDigitalWallet) { }
#pragma warning restore CS8618

    public CardDigitalWallet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDigitalWallet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDigitalWalletFromRaw.FromRawUnchecked"/>
    public static CardDigitalWallet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDigitalWalletFromRaw : IFromRawJson<CardDigitalWallet>
{
    /// <inheritdoc/>
    public CardDigitalWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CardDigitalWallet.FromRawUnchecked(rawData);
}

/// <summary>
/// This indicates if payments can be made with the card.
/// </summary>
[JsonConverter(typeof(CardStatusConverter))]
public enum CardStatus
{
    /// <summary>
    /// The card is active.
    /// </summary>
    Active,

    /// <summary>
    /// The card is temporarily disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// The card is permanently canceled.
    /// </summary>
    Canceled,
}

sealed class CardStatusConverter : JsonConverter<CardStatus>
{
    public override CardStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => CardStatus.Active,
            "disabled" => CardStatus.Disabled,
            "canceled" => CardStatus.Canceled,
            _ => (CardStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardStatus.Active => "active",
                CardStatus.Disabled => "disabled",
                CardStatus.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Card,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Cards.Type>
{
    public override global::Increase.Api.Models.Cards.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card" => global::Increase.Api.Models.Cards.Type.Card,
            _ => (global::Increase.Api.Models.Cards.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Cards.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Cards.Type.Card => "card",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
