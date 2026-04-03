using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    /// Controls that restrict how this card can be used.
    /// </summary>
    public required CardAuthorizationControls? AuthorizationControls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorizationControls>(
                "authorization_controls"
            );
        }
        init { this._rawData.Set("authorization_controls", value); }
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
        this.AuthorizationControls?.Validate();
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
/// Controls that restrict how this card can be used.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardAuthorizationControls, CardAuthorizationControlsFromRaw>)
)]
public sealed record class CardAuthorizationControls : JsonModel
{
    /// <summary>
    /// Limits the number of authorizations that can be approved on this card.
    /// </summary>
    public required CardAuthorizationControlsMaximumAuthorizationCount? MaximumAuthorizationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorizationControlsMaximumAuthorizationCount>(
                "maximum_authorization_count"
            );
        }
        init { this._rawData.Set("maximum_authorization_count", value); }
    }

    /// <summary>
    /// Restricts which Merchant Acceptor IDs are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public required CardAuthorizationControlsMerchantAcceptorIdentifier? MerchantAcceptorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorizationControlsMerchantAcceptorIdentifier>(
                "merchant_acceptor_identifier"
            );
        }
        init { this._rawData.Set("merchant_acceptor_identifier", value); }
    }

    /// <summary>
    /// Restricts which Merchant Category Codes are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public required CardAuthorizationControlsMerchantCategoryCode? MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorizationControlsMerchantCategoryCode>(
                "merchant_category_code"
            );
        }
        init { this._rawData.Set("merchant_category_code", value); }
    }

    /// <summary>
    /// Restricts which merchant countries are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public required CardAuthorizationControlsMerchantCountry? MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAuthorizationControlsMerchantCountry>(
                "merchant_country"
            );
        }
        init { this._rawData.Set("merchant_country", value); }
    }

    /// <summary>
    /// Spending limits for this card. The most restrictive limit is applied if multiple
    /// limits match.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsSpendingLimit>? SpendingLimits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsSpendingLimit>
            >("spending_limits");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsSpendingLimit>?>(
                "spending_limits",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MaximumAuthorizationCount?.Validate();
        this.MerchantAcceptorIdentifier?.Validate();
        this.MerchantCategoryCode?.Validate();
        this.MerchantCountry?.Validate();
        foreach (var item in this.SpendingLimits ?? [])
        {
            item.Validate();
        }
    }

    public CardAuthorizationControls() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControls(CardAuthorizationControls cardAuthorizationControls)
        : base(cardAuthorizationControls) { }
#pragma warning restore CS8618

    public CardAuthorizationControls(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControls(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationControlsFromRaw : IFromRawJson<CardAuthorizationControls>
{
    /// <inheritdoc/>
    public CardAuthorizationControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControls.FromRawUnchecked(rawData);
}

/// <summary>
/// Limits the number of authorizations that can be approved on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMaximumAuthorizationCount,
        CardAuthorizationControlsMaximumAuthorizationCountFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMaximumAuthorizationCount : JsonModel
{
    /// <summary>
    /// The maximum number of authorizations that can be approved on this card over
    /// its lifetime.
    /// </summary>
    public required long? AllTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("all_time");
        }
        init { this._rawData.Set("all_time", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllTime;
    }

    public CardAuthorizationControlsMaximumAuthorizationCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMaximumAuthorizationCount(
        CardAuthorizationControlsMaximumAuthorizationCount cardAuthorizationControlsMaximumAuthorizationCount
    )
        : base(cardAuthorizationControlsMaximumAuthorizationCount) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMaximumAuthorizationCount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMaximumAuthorizationCount(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMaximumAuthorizationCountFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMaximumAuthorizationCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMaximumAuthorizationCount(long? allTime)
        : this()
    {
        this.AllTime = allTime;
    }
}

class CardAuthorizationControlsMaximumAuthorizationCountFromRaw
    : IFromRawJson<CardAuthorizationControlsMaximumAuthorizationCount>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMaximumAuthorizationCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMaximumAuthorizationCount.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which Merchant Acceptor IDs are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantAcceptorIdentifier,
        CardAuthorizationControlsMerchantAcceptorIdentifierFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantAcceptorIdentifier : JsonModel
{
    /// <summary>
    /// The Merchant Acceptor IDs that are allowed for authorizations on this card.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsMerchantAcceptorIdentifierAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsMerchantAcceptorIdentifierAllowed>
            >("allowed");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsMerchantAcceptorIdentifierAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Merchant Acceptor IDs that are blocked for authorizations on this card.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsMerchantAcceptorIdentifierBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsMerchantAcceptorIdentifierBlocked>
            >("blocked");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsMerchantAcceptorIdentifierBlocked>?>(
                "blocked",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Allowed ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Blocked ?? [])
        {
            item.Validate();
        }
    }

    public CardAuthorizationControlsMerchantAcceptorIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantAcceptorIdentifier(
        CardAuthorizationControlsMerchantAcceptorIdentifier cardAuthorizationControlsMerchantAcceptorIdentifier
    )
        : base(cardAuthorizationControlsMerchantAcceptorIdentifier) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantAcceptorIdentifier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantAcceptorIdentifier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantAcceptorIdentifierFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantAcceptorIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationControlsMerchantAcceptorIdentifierFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantAcceptorIdentifier>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantAcceptorIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantAcceptorIdentifier.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantAcceptorIdentifierAllowed,
        CardAuthorizationControlsMerchantAcceptorIdentifierAllowedFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantAcceptorIdentifierAllowed : JsonModel
{
    /// <summary>
    /// The Merchant Acceptor ID.
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Identifier;
    }

    public CardAuthorizationControlsMerchantAcceptorIdentifierAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantAcceptorIdentifierAllowed(
        CardAuthorizationControlsMerchantAcceptorIdentifierAllowed cardAuthorizationControlsMerchantAcceptorIdentifierAllowed
    )
        : base(cardAuthorizationControlsMerchantAcceptorIdentifierAllowed) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantAcceptorIdentifierAllowed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantAcceptorIdentifierAllowed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantAcceptorIdentifierAllowedFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantAcceptorIdentifierAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantAcceptorIdentifierAllowed(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class CardAuthorizationControlsMerchantAcceptorIdentifierAllowedFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantAcceptorIdentifierAllowed>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantAcceptorIdentifierAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantAcceptorIdentifierAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantAcceptorIdentifierBlocked,
        CardAuthorizationControlsMerchantAcceptorIdentifierBlockedFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantAcceptorIdentifierBlocked : JsonModel
{
    /// <summary>
    /// The Merchant Acceptor ID.
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Identifier;
    }

    public CardAuthorizationControlsMerchantAcceptorIdentifierBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantAcceptorIdentifierBlocked(
        CardAuthorizationControlsMerchantAcceptorIdentifierBlocked cardAuthorizationControlsMerchantAcceptorIdentifierBlocked
    )
        : base(cardAuthorizationControlsMerchantAcceptorIdentifierBlocked) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantAcceptorIdentifierBlocked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantAcceptorIdentifierBlocked(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantAcceptorIdentifierBlockedFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantAcceptorIdentifierBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantAcceptorIdentifierBlocked(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class CardAuthorizationControlsMerchantAcceptorIdentifierBlockedFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantAcceptorIdentifierBlocked>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantAcceptorIdentifierBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantAcceptorIdentifierBlocked.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which Merchant Category Codes are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantCategoryCode,
        CardAuthorizationControlsMerchantCategoryCodeFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantCategoryCode : JsonModel
{
    /// <summary>
    /// The Merchant Category Codes that are allowed for authorizations on this card.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsMerchantCategoryCodeAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsMerchantCategoryCodeAllowed>
            >("allowed");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsMerchantCategoryCodeAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Merchant Category Codes that are blocked for authorizations on this card.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsMerchantCategoryCodeBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsMerchantCategoryCodeBlocked>
            >("blocked");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsMerchantCategoryCodeBlocked>?>(
                "blocked",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Allowed ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Blocked ?? [])
        {
            item.Validate();
        }
    }

    public CardAuthorizationControlsMerchantCategoryCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCategoryCode(
        CardAuthorizationControlsMerchantCategoryCode cardAuthorizationControlsMerchantCategoryCode
    )
        : base(cardAuthorizationControlsMerchantCategoryCode) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantCategoryCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantCategoryCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantCategoryCodeFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationControlsMerchantCategoryCodeFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantCategoryCode>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantCategoryCode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantCategoryCodeAllowed,
        CardAuthorizationControlsMerchantCategoryCodeAllowedFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantCategoryCodeAllowed : JsonModel
{
    /// <summary>
    /// The Merchant Category Code (MCC).
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
    }

    public CardAuthorizationControlsMerchantCategoryCodeAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCategoryCodeAllowed(
        CardAuthorizationControlsMerchantCategoryCodeAllowed cardAuthorizationControlsMerchantCategoryCodeAllowed
    )
        : base(cardAuthorizationControlsMerchantCategoryCodeAllowed) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantCategoryCodeAllowed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantCategoryCodeAllowed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantCategoryCodeAllowedFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantCategoryCodeAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCategoryCodeAllowed(string code)
        : this()
    {
        this.Code = code;
    }
}

class CardAuthorizationControlsMerchantCategoryCodeAllowedFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantCategoryCodeAllowed>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantCategoryCodeAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantCategoryCodeAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantCategoryCodeBlocked,
        CardAuthorizationControlsMerchantCategoryCodeBlockedFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantCategoryCodeBlocked : JsonModel
{
    /// <summary>
    /// The Merchant Category Code (MCC).
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
    }

    public CardAuthorizationControlsMerchantCategoryCodeBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCategoryCodeBlocked(
        CardAuthorizationControlsMerchantCategoryCodeBlocked cardAuthorizationControlsMerchantCategoryCodeBlocked
    )
        : base(cardAuthorizationControlsMerchantCategoryCodeBlocked) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantCategoryCodeBlocked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantCategoryCodeBlocked(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantCategoryCodeBlockedFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantCategoryCodeBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCategoryCodeBlocked(string code)
        : this()
    {
        this.Code = code;
    }
}

class CardAuthorizationControlsMerchantCategoryCodeBlockedFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantCategoryCodeBlocked>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantCategoryCodeBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantCategoryCodeBlocked.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which merchant countries are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantCountry,
        CardAuthorizationControlsMerchantCountryFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantCountry : JsonModel
{
    /// <summary>
    /// The merchant countries that are allowed for authorizations on this card.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsMerchantCountryAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsMerchantCountryAllowed>
            >("allowed");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsMerchantCountryAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The merchant countries that are blocked for authorizations on this card.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsMerchantCountryBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsMerchantCountryBlocked>
            >("blocked");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsMerchantCountryBlocked>?>(
                "blocked",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Allowed ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Blocked ?? [])
        {
            item.Validate();
        }
    }

    public CardAuthorizationControlsMerchantCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCountry(
        CardAuthorizationControlsMerchantCountry cardAuthorizationControlsMerchantCountry
    )
        : base(cardAuthorizationControlsMerchantCountry) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantCountry(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantCountry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantCountryFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationControlsMerchantCountryFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantCountry>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantCountry.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantCountryAllowed,
        CardAuthorizationControlsMerchantCountryAllowedFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantCountryAllowed : JsonModel
{
    /// <summary>
    /// The ISO 3166-1 alpha-2 country code.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
    }

    public CardAuthorizationControlsMerchantCountryAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCountryAllowed(
        CardAuthorizationControlsMerchantCountryAllowed cardAuthorizationControlsMerchantCountryAllowed
    )
        : base(cardAuthorizationControlsMerchantCountryAllowed) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantCountryAllowed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantCountryAllowed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantCountryAllowedFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantCountryAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCountryAllowed(string country)
        : this()
    {
        this.Country = country;
    }
}

class CardAuthorizationControlsMerchantCountryAllowedFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantCountryAllowed>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantCountryAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantCountryAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsMerchantCountryBlocked,
        CardAuthorizationControlsMerchantCountryBlockedFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsMerchantCountryBlocked : JsonModel
{
    /// <summary>
    /// The ISO 3166-1 alpha-2 country code.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
    }

    public CardAuthorizationControlsMerchantCountryBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCountryBlocked(
        CardAuthorizationControlsMerchantCountryBlocked cardAuthorizationControlsMerchantCountryBlocked
    )
        : base(cardAuthorizationControlsMerchantCountryBlocked) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsMerchantCountryBlocked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsMerchantCountryBlocked(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsMerchantCountryBlockedFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsMerchantCountryBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsMerchantCountryBlocked(string country)
        : this()
    {
        this.Country = country;
    }
}

class CardAuthorizationControlsMerchantCountryBlockedFromRaw
    : IFromRawJson<CardAuthorizationControlsMerchantCountryBlocked>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsMerchantCountryBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsMerchantCountryBlocked.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsSpendingLimit,
        CardAuthorizationControlsSpendingLimitFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsSpendingLimit : JsonModel
{
    /// <summary>
    /// The interval at which the spending limit is enforced.
    /// </summary>
    public required ApiEnum<string, CardAuthorizationControlsSpendingLimitInterval> Interval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardAuthorizationControlsSpendingLimitInterval>
            >("interval");
        }
        init { this._rawData.Set("interval", value); }
    }

    /// <summary>
    /// The Merchant Category Codes (MCCs) this spending limit applies to. If not
    /// set, the limit applies to all transactions.
    /// </summary>
    public required IReadOnlyList<CardAuthorizationControlsSpendingLimitMerchantCategoryCode>? MerchantCategoryCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardAuthorizationControlsSpendingLimitMerchantCategoryCode>
            >("merchant_category_codes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardAuthorizationControlsSpendingLimitMerchantCategoryCode>?>(
                "merchant_category_codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum settlement amount permitted in the given interval.
    /// </summary>
    public required long SettlementAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("settlement_amount");
        }
        init { this._rawData.Set("settlement_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Interval.Validate();
        foreach (var item in this.MerchantCategoryCodes ?? [])
        {
            item.Validate();
        }
        _ = this.SettlementAmount;
    }

    public CardAuthorizationControlsSpendingLimit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsSpendingLimit(
        CardAuthorizationControlsSpendingLimit cardAuthorizationControlsSpendingLimit
    )
        : base(cardAuthorizationControlsSpendingLimit) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsSpendingLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsSpendingLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsSpendingLimitFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsSpendingLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardAuthorizationControlsSpendingLimitFromRaw
    : IFromRawJson<CardAuthorizationControlsSpendingLimit>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsSpendingLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsSpendingLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// The interval at which the spending limit is enforced.
/// </summary>
[JsonConverter(typeof(CardAuthorizationControlsSpendingLimitIntervalConverter))]
public enum CardAuthorizationControlsSpendingLimitInterval
{
    /// <summary>
    /// The spending limit applies over the lifetime of the card.
    /// </summary>
    AllTime,

    /// <summary>
    /// The spending limit applies per transaction.
    /// </summary>
    PerTransaction,

    /// <summary>
    /// The spending limit applies per day. Resets nightly at midnight UTC.
    /// </summary>
    PerDay,

    /// <summary>
    /// The spending limit applies per week. Resets weekly on Mondays at midnight UTC.
    /// </summary>
    PerWeek,

    /// <summary>
    /// The spending limit applies per month. Resets on the first of the month, midnight UTC.
    /// </summary>
    PerMonth,
}

sealed class CardAuthorizationControlsSpendingLimitIntervalConverter
    : JsonConverter<CardAuthorizationControlsSpendingLimitInterval>
{
    public override CardAuthorizationControlsSpendingLimitInterval Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all_time" => CardAuthorizationControlsSpendingLimitInterval.AllTime,
            "per_transaction" => CardAuthorizationControlsSpendingLimitInterval.PerTransaction,
            "per_day" => CardAuthorizationControlsSpendingLimitInterval.PerDay,
            "per_week" => CardAuthorizationControlsSpendingLimitInterval.PerWeek,
            "per_month" => CardAuthorizationControlsSpendingLimitInterval.PerMonth,
            _ => (CardAuthorizationControlsSpendingLimitInterval)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardAuthorizationControlsSpendingLimitInterval value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardAuthorizationControlsSpendingLimitInterval.AllTime => "all_time",
                CardAuthorizationControlsSpendingLimitInterval.PerTransaction => "per_transaction",
                CardAuthorizationControlsSpendingLimitInterval.PerDay => "per_day",
                CardAuthorizationControlsSpendingLimitInterval.PerWeek => "per_week",
                CardAuthorizationControlsSpendingLimitInterval.PerMonth => "per_month",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardAuthorizationControlsSpendingLimitMerchantCategoryCode,
        CardAuthorizationControlsSpendingLimitMerchantCategoryCodeFromRaw
    >)
)]
public sealed record class CardAuthorizationControlsSpendingLimitMerchantCategoryCode : JsonModel
{
    /// <summary>
    /// The Merchant Category Code (MCC).
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
    }

    public CardAuthorizationControlsSpendingLimitMerchantCategoryCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthorizationControlsSpendingLimitMerchantCategoryCode(
        CardAuthorizationControlsSpendingLimitMerchantCategoryCode cardAuthorizationControlsSpendingLimitMerchantCategoryCode
    )
        : base(cardAuthorizationControlsSpendingLimitMerchantCategoryCode) { }
#pragma warning restore CS8618

    public CardAuthorizationControlsSpendingLimitMerchantCategoryCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthorizationControlsSpendingLimitMerchantCategoryCode(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardAuthorizationControlsSpendingLimitMerchantCategoryCodeFromRaw.FromRawUnchecked"/>
    public static CardAuthorizationControlsSpendingLimitMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardAuthorizationControlsSpendingLimitMerchantCategoryCode(string code)
        : this()
    {
        this.Code = code;
    }
}

class CardAuthorizationControlsSpendingLimitMerchantCategoryCodeFromRaw
    : IFromRawJson<CardAuthorizationControlsSpendingLimitMerchantCategoryCode>
{
    /// <inheritdoc/>
    public CardAuthorizationControlsSpendingLimitMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardAuthorizationControlsSpendingLimitMerchantCategoryCode.FromRawUnchecked(rawData);
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
