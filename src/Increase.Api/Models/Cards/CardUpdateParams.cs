using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Cards;

/// <summary>
/// Update a Card
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CardID { get; init; }

    /// <summary>
    /// Controls that restrict how this card can be used.
    /// </summary>
    public CardUpdateParamsAuthorizationControls? AuthorizationControls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardUpdateParamsAuthorizationControls>(
                "authorization_controls"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("authorization_controls", value);
        }
    }

    /// <summary>
    /// The card's updated billing address.
    /// </summary>
    public CardUpdateParamsBillingAddress? BillingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardUpdateParamsBillingAddress>(
                "billing_address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billing_address", value);
        }
    }

    /// <summary>
    /// The description you choose to give the card.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// The contact information used in the two-factor steps for digital wallet card
    /// creation. At least one field must be present to complete the digital wallet steps.
    /// </summary>
    public CardUpdateParamsDigitalWallet? DigitalWallet
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CardUpdateParamsDigitalWallet>(
                "digital_wallet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("digital_wallet", value);
        }
    }

    /// <summary>
    /// The Entity the card belongs to. You only need to supply this in rare situations
    /// when the card is not for the Account holder.
    /// </summary>
    public string? EntityID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("entity_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entity_id", value);
        }
    }

    /// <summary>
    /// The status to update the Card with.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    public CardUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParams(CardUpdateParams cardUpdateParams)
        : base(cardUpdateParams)
    {
        this.CardID = cardUpdateParams.CardID;

        this._rawBodyData = new(cardUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardUpdateParams(
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
    CardUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string cardID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CardID = cardID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string cardID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            cardID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CardID"] = JsonSerializer.SerializeToElement(this.CardID),
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

    public virtual bool Equals(CardUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CardID?.Equals(other.CardID) ?? other.CardID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/cards/{0}", this.CardID)
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
/// Controls that restrict how this card can be used.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControls,
        CardUpdateParamsAuthorizationControlsFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControls : JsonModel
{
    /// <summary>
    /// Limits the number of authorizations that can be approved on this card.
    /// </summary>
    public CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount? MaximumAuthorizationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount>(
                "maximum_authorization_count"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maximum_authorization_count", value);
        }
    }

    /// <summary>
    /// Restricts which Merchant Acceptor IDs are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier? MerchantAcceptorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier>(
                "merchant_acceptor_identifier"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_acceptor_identifier", value);
        }
    }

    /// <summary>
    /// Restricts which Merchant Category Codes are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCode? MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardUpdateParamsAuthorizationControlsMerchantCategoryCode>(
                "merchant_category_code"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_category_code", value);
        }
    }

    /// <summary>
    /// Restricts which merchant countries are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public CardUpdateParamsAuthorizationControlsMerchantCountry? MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardUpdateParamsAuthorizationControlsMerchantCountry>(
                "merchant_country"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("merchant_country", value);
        }
    }

    /// <summary>
    /// Spending limits for this card. The most restrictive limit is applied if multiple
    /// limits match.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsSpendingLimit>? SpendingLimits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsSpendingLimit>
            >("spending_limits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsSpendingLimit>?>(
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

    public CardUpdateParamsAuthorizationControls() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControls(
        CardUpdateParamsAuthorizationControls cardUpdateParamsAuthorizationControls
    )
        : base(cardUpdateParamsAuthorizationControls) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControls(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControls(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsAuthorizationControlsFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControls>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControls.FromRawUnchecked(rawData);
}

/// <summary>
/// Limits the number of authorizations that can be approved on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount,
        CardUpdateParamsAuthorizationControlsMaximumAuthorizationCountFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
    : JsonModel
{
    /// <summary>
    /// The maximum number of authorizations that can be approved on this card over
    /// its lifetime.
    /// </summary>
    public required long AllTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("all_time");
        }
        init { this._rawData.Set("all_time", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllTime;
    }

    public CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount(
        CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount cardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
    )
        : base(cardUpdateParamsAuthorizationControlsMaximumAuthorizationCount) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMaximumAuthorizationCountFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount(long allTime)
        : this()
    {
        this.AllTime = allTime;
    }
}

class CardUpdateParamsAuthorizationControlsMaximumAuthorizationCountFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which Merchant Acceptor IDs are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier,
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
    : JsonModel
{
    /// <summary>
    /// The Merchant Acceptor IDs that are allowed for authorizations on this card.
    /// Authorizations with Merchant Acceptor IDs not in this list will be declined.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed>
            >("allowed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Merchant Acceptor IDs that are blocked for authorizations on this card.
    /// Authorizations with Merchant Acceptor IDs in this list will be declined.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked>
            >("blocked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked>?>(
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

    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier(
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier cardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed,
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowedFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
    : JsonModel
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

    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed(
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed cardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowedFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowedFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked,
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlockedFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
    : JsonModel
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

    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked(
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked cardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlockedFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlockedFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Restricts which Merchant Category Codes are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantCategoryCode,
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantCategoryCode : JsonModel
{
    /// <summary>
    /// The Merchant Category Codes that are allowed for authorizations on this card.
    /// Authorizations with Merchant Category Codes not in this list will be declined.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed>
            >("allowed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Merchant Category Codes that are blocked for authorizations on this card.
    /// Authorizations with Merchant Category Codes in this list will be declined.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked>
            >("blocked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked>?>(
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

    public CardUpdateParamsAuthorizationControlsMerchantCategoryCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCode(
        CardUpdateParamsAuthorizationControlsMerchantCategoryCode cardUpdateParamsAuthorizationControlsMerchantCategoryCode
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantCategoryCode) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantCategoryCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantCategoryCode(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantCategoryCodeFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantCategoryCode>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantCategoryCode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed,
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowedFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
    : JsonModel
{
    /// <summary>
    /// The Merchant Category Code.
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

    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed(
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed cardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowedFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed(string code)
        : this()
    {
        this.Code = code;
    }
}

class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowedFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked,
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlockedFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
    : JsonModel
{
    /// <summary>
    /// The Merchant Category Code.
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

    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked(
        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked cardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlockedFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked(string code)
        : this()
    {
        this.Code = code;
    }
}

class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlockedFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which merchant countries are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantCountry,
        CardUpdateParamsAuthorizationControlsMerchantCountryFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantCountry : JsonModel
{
    /// <summary>
    /// The merchant countries that are allowed for authorizations on this card. Authorizations
    /// with merchant countries not in this list will be declined.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed>
            >("allowed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The merchant countries that are blocked for authorizations on this card. Authorizations
    /// with merchant countries in this list will be declined.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked>
            >("blocked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked>?>(
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

    public CardUpdateParamsAuthorizationControlsMerchantCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCountry(
        CardUpdateParamsAuthorizationControlsMerchantCountry cardUpdateParamsAuthorizationControlsMerchantCountry
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantCountry) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantCountry(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantCountry(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantCountryFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsAuthorizationControlsMerchantCountryFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantCountry>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantCountry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantCountry.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantCountryAllowed,
        CardUpdateParamsAuthorizationControlsMerchantCountryAllowedFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantCountryAllowed : JsonModel
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

    public CardUpdateParamsAuthorizationControlsMerchantCountryAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCountryAllowed(
        CardUpdateParamsAuthorizationControlsMerchantCountryAllowed cardUpdateParamsAuthorizationControlsMerchantCountryAllowed
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantCountryAllowed) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantCountryAllowed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantCountryAllowed(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantCountryAllowedFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantCountryAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCountryAllowed(string country)
        : this()
    {
        this.Country = country;
    }
}

class CardUpdateParamsAuthorizationControlsMerchantCountryAllowedFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantCountryAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantCountryAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsMerchantCountryBlocked,
        CardUpdateParamsAuthorizationControlsMerchantCountryBlockedFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsMerchantCountryBlocked : JsonModel
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

    public CardUpdateParamsAuthorizationControlsMerchantCountryBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCountryBlocked(
        CardUpdateParamsAuthorizationControlsMerchantCountryBlocked cardUpdateParamsAuthorizationControlsMerchantCountryBlocked
    )
        : base(cardUpdateParamsAuthorizationControlsMerchantCountryBlocked) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsMerchantCountryBlocked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsMerchantCountryBlocked(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsMerchantCountryBlockedFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsMerchantCountryBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsMerchantCountryBlocked(string country)
        : this()
    {
        this.Country = country;
    }
}

class CardUpdateParamsAuthorizationControlsMerchantCountryBlockedFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsMerchantCountryBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsMerchantCountryBlocked.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsAuthorizationControlsSpendingLimit,
        CardUpdateParamsAuthorizationControlsSpendingLimitFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsSpendingLimit : JsonModel
{
    /// <summary>
    /// The interval at which the spending limit is enforced.
    /// </summary>
    public required ApiEnum<
        string,
        CardUpdateParamsAuthorizationControlsSpendingLimitInterval
    > Interval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval>
            >("interval");
        }
        init { this._rawData.Set("interval", value); }
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

    /// <summary>
    /// The Merchant Category Codes this spending limit applies to. If not set, the
    /// limit applies to all transactions.
    /// </summary>
    public IReadOnlyList<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode>? MerchantCategoryCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode>
            >("merchant_category_codes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode>?>(
                "merchant_category_codes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Interval.Validate();
        _ = this.SettlementAmount;
        foreach (var item in this.MerchantCategoryCodes ?? [])
        {
            item.Validate();
        }
    }

    public CardUpdateParamsAuthorizationControlsSpendingLimit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsSpendingLimit(
        CardUpdateParamsAuthorizationControlsSpendingLimit cardUpdateParamsAuthorizationControlsSpendingLimit
    )
        : base(cardUpdateParamsAuthorizationControlsSpendingLimit) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsSpendingLimit(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsSpendingLimit(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsSpendingLimitFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsSpendingLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsAuthorizationControlsSpendingLimitFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsSpendingLimit>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsSpendingLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsAuthorizationControlsSpendingLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// The interval at which the spending limit is enforced.
/// </summary>
[JsonConverter(typeof(CardUpdateParamsAuthorizationControlsSpendingLimitIntervalConverter))]
public enum CardUpdateParamsAuthorizationControlsSpendingLimitInterval
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

sealed class CardUpdateParamsAuthorizationControlsSpendingLimitIntervalConverter
    : JsonConverter<CardUpdateParamsAuthorizationControlsSpendingLimitInterval>
{
    public override CardUpdateParamsAuthorizationControlsSpendingLimitInterval Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all_time" => CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            "per_transaction" =>
                CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerTransaction,
            "per_day" => CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerDay,
            "per_week" => CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerWeek,
            "per_month" => CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerMonth,
            _ => (CardUpdateParamsAuthorizationControlsSpendingLimitInterval)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardUpdateParamsAuthorizationControlsSpendingLimitInterval value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime => "all_time",
                CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerTransaction =>
                    "per_transaction",
                CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerDay => "per_day",
                CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerWeek => "per_week",
                CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerMonth => "per_month",
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
        CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode,
        CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCodeFromRaw
    >)
)]
public sealed record class CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
    : JsonModel
{
    /// <summary>
    /// The Merchant Category Code.
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

    public CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode(
        CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode cardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
    )
        : base(cardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode) { }
#pragma warning restore CS8618

    public CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCodeFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode(string code)
        : this()
    {
        this.Code = code;
    }
}

class CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCodeFromRaw
    : IFromRawJson<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode>
{
    /// <inheritdoc/>
    public CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The card's updated billing address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardUpdateParamsBillingAddress,
        CardUpdateParamsBillingAddressFromRaw
    >)
)]
public sealed record class CardUpdateParamsBillingAddress : JsonModel
{
    /// <summary>
    /// The city of the billing address.
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
    /// The first line of the billing address.
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
    /// The postal code of the billing address.
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
    /// The US state of the billing address.
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
    /// The second line of the billing address.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line2;
    }

    public CardUpdateParamsBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsBillingAddress(
        CardUpdateParamsBillingAddress cardUpdateParamsBillingAddress
    )
        : base(cardUpdateParamsBillingAddress) { }
#pragma warning restore CS8618

    public CardUpdateParamsBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsBillingAddressFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsBillingAddressFromRaw : IFromRawJson<CardUpdateParamsBillingAddress>
{
    /// <inheritdoc/>
    public CardUpdateParamsBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The contact information used in the two-factor steps for digital wallet card
/// creation. At least one field must be present to complete the digital wallet steps.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardUpdateParamsDigitalWallet, CardUpdateParamsDigitalWalletFromRaw>)
)]
public sealed record class CardUpdateParamsDigitalWallet : JsonModel
{
    /// <summary>
    /// The digital card profile assigned to this digital card.
    /// </summary>
    public string? DigitalCardProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("digital_card_profile_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("digital_card_profile_id", value);
        }
    }

    /// <summary>
    /// An email address that can be used to verify the cardholder via one-time passcode
    /// over email.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// A phone number that can be used to verify the cardholder via one-time passcode
    /// over SMS.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DigitalCardProfileID;
        _ = this.Email;
        _ = this.Phone;
    }

    public CardUpdateParamsDigitalWallet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUpdateParamsDigitalWallet(
        CardUpdateParamsDigitalWallet cardUpdateParamsDigitalWallet
    )
        : base(cardUpdateParamsDigitalWallet) { }
#pragma warning restore CS8618

    public CardUpdateParamsDigitalWallet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUpdateParamsDigitalWallet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUpdateParamsDigitalWalletFromRaw.FromRawUnchecked"/>
    public static CardUpdateParamsDigitalWallet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUpdateParamsDigitalWalletFromRaw : IFromRawJson<CardUpdateParamsDigitalWallet>
{
    /// <inheritdoc/>
    public CardUpdateParamsDigitalWallet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUpdateParamsDigitalWallet.FromRawUnchecked(rawData);
}

/// <summary>
/// The status to update the Card with.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
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

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "disabled" => Status.Disabled,
            "canceled" => Status.Canceled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Disabled => "disabled",
                Status.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
