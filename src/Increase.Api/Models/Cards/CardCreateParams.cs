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
/// Create a Card
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The Account the card should belong to.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_id");
        }
        init { this._rawBodyData.Set("account_id", value); }
    }

    /// <summary>
    /// Controls that restrict how this card can be used.
    /// </summary>
    public AuthorizationControls? AuthorizationControls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AuthorizationControls>(
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
    /// The card's billing address.
    /// </summary>
    public BillingAddress? BillingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingAddress>("billing_address");
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
    /// creation. To add the card to a digital wallet, you may supply an email or
    /// phone number with this request. Otherwise, subscribe and then action a Real
    /// Time Decision with the category `digital_wallet_token_requested` or `digital_wallet_authentication_requested`.
    /// </summary>
    public DigitalWallet? DigitalWallet
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DigitalWallet>("digital_wallet");
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

    public CardCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardCreateParams(CardCreateParams cardCreateParams)
        : base(cardCreateParams)
    {
        this._rawBodyData = new(cardCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardCreateParams(
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
    CardCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(CardCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/cards")
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
[JsonConverter(typeof(JsonModelConverter<AuthorizationControls, AuthorizationControlsFromRaw>))]
public sealed record class AuthorizationControls : JsonModel
{
    /// <summary>
    /// Restricts which Merchant Acceptor IDs are allowed or blocked for authorizations
    /// on this card.
    /// </summary>
    public MerchantAcceptorIdentifier? MerchantAcceptorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantAcceptorIdentifier>(
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
    public MerchantCategoryCode? MerchantCategoryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantCategoryCode>("merchant_category_code");
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
    public MerchantCountry? MerchantCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MerchantCountry>("merchant_country");
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
    /// Controls how many times this card can be used.
    /// </summary>
    public Usage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Usage>("usage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MerchantAcceptorIdentifier?.Validate();
        this.MerchantCategoryCode?.Validate();
        this.MerchantCountry?.Validate();
        this.Usage?.Validate();
    }

    public AuthorizationControls() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthorizationControls(AuthorizationControls authorizationControls)
        : base(authorizationControls) { }
#pragma warning restore CS8618

    public AuthorizationControls(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthorizationControls(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthorizationControlsFromRaw.FromRawUnchecked"/>
    public static AuthorizationControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuthorizationControlsFromRaw : IFromRawJson<AuthorizationControls>
{
    /// <inheritdoc/>
    public AuthorizationControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuthorizationControls.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which Merchant Acceptor IDs are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MerchantAcceptorIdentifier, MerchantAcceptorIdentifierFromRaw>)
)]
public sealed record class MerchantAcceptorIdentifier : JsonModel
{
    /// <summary>
    /// The Merchant Acceptor IDs that are allowed for authorizations on this card.
    /// Authorizations with Merchant Acceptor IDs not in this list will be declined.
    /// </summary>
    public IReadOnlyList<Allowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Allowed>>("allowed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Allowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Merchant Acceptor IDs that are blocked for authorizations on this card.
    /// Authorizations with Merchant Acceptor IDs in this list will be declined.
    /// </summary>
    public IReadOnlyList<Blocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Blocked>>("blocked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Blocked>?>(
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

    public MerchantAcceptorIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantAcceptorIdentifier(MerchantAcceptorIdentifier merchantAcceptorIdentifier)
        : base(merchantAcceptorIdentifier) { }
#pragma warning restore CS8618

    public MerchantAcceptorIdentifier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantAcceptorIdentifier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantAcceptorIdentifierFromRaw.FromRawUnchecked"/>
    public static MerchantAcceptorIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantAcceptorIdentifierFromRaw : IFromRawJson<MerchantAcceptorIdentifier>
{
    /// <inheritdoc/>
    public MerchantAcceptorIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantAcceptorIdentifier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Allowed, AllowedFromRaw>))]
public sealed record class Allowed : JsonModel
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

    public Allowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Allowed(Allowed allowed)
        : base(allowed) { }
#pragma warning restore CS8618

    public Allowed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Allowed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AllowedFromRaw.FromRawUnchecked"/>
    public static Allowed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Allowed(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class AllowedFromRaw : IFromRawJson<Allowed>
{
    /// <inheritdoc/>
    public Allowed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Allowed.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Blocked, BlockedFromRaw>))]
public sealed record class Blocked : JsonModel
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

    public Blocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Blocked(Blocked blocked)
        : base(blocked) { }
#pragma warning restore CS8618

    public Blocked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Blocked(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockedFromRaw.FromRawUnchecked"/>
    public static Blocked FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Blocked(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class BlockedFromRaw : IFromRawJson<Blocked>
{
    /// <inheritdoc/>
    public Blocked FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Blocked.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which Merchant Category Codes are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MerchantCategoryCode, MerchantCategoryCodeFromRaw>))]
public sealed record class MerchantCategoryCode : JsonModel
{
    /// <summary>
    /// The Merchant Category Codes that are allowed for authorizations on this card.
    /// Authorizations with Merchant Category Codes not in this list will be declined.
    /// </summary>
    public IReadOnlyList<MerchantCategoryCodeAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MerchantCategoryCodeAllowed>>(
                "allowed"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MerchantCategoryCodeAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Merchant Category Codes that are blocked for authorizations on this card.
    /// Authorizations with Merchant Category Codes in this list will be declined.
    /// </summary>
    public IReadOnlyList<MerchantCategoryCodeBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MerchantCategoryCodeBlocked>>(
                "blocked"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MerchantCategoryCodeBlocked>?>(
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

    public MerchantCategoryCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCategoryCode(MerchantCategoryCode merchantCategoryCode)
        : base(merchantCategoryCode) { }
#pragma warning restore CS8618

    public MerchantCategoryCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCategoryCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCategoryCodeFromRaw.FromRawUnchecked"/>
    public static MerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantCategoryCodeFromRaw : IFromRawJson<MerchantCategoryCode>
{
    /// <inheritdoc/>
    public MerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantCategoryCode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<MerchantCategoryCodeAllowed, MerchantCategoryCodeAllowedFromRaw>)
)]
public sealed record class MerchantCategoryCodeAllowed : JsonModel
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

    public MerchantCategoryCodeAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCategoryCodeAllowed(MerchantCategoryCodeAllowed merchantCategoryCodeAllowed)
        : base(merchantCategoryCodeAllowed) { }
#pragma warning restore CS8618

    public MerchantCategoryCodeAllowed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCategoryCodeAllowed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCategoryCodeAllowedFromRaw.FromRawUnchecked"/>
    public static MerchantCategoryCodeAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantCategoryCodeAllowed(string code)
        : this()
    {
        this.Code = code;
    }
}

class MerchantCategoryCodeAllowedFromRaw : IFromRawJson<MerchantCategoryCodeAllowed>
{
    /// <inheritdoc/>
    public MerchantCategoryCodeAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantCategoryCodeAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<MerchantCategoryCodeBlocked, MerchantCategoryCodeBlockedFromRaw>)
)]
public sealed record class MerchantCategoryCodeBlocked : JsonModel
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

    public MerchantCategoryCodeBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCategoryCodeBlocked(MerchantCategoryCodeBlocked merchantCategoryCodeBlocked)
        : base(merchantCategoryCodeBlocked) { }
#pragma warning restore CS8618

    public MerchantCategoryCodeBlocked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCategoryCodeBlocked(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCategoryCodeBlockedFromRaw.FromRawUnchecked"/>
    public static MerchantCategoryCodeBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantCategoryCodeBlocked(string code)
        : this()
    {
        this.Code = code;
    }
}

class MerchantCategoryCodeBlockedFromRaw : IFromRawJson<MerchantCategoryCodeBlocked>
{
    /// <inheritdoc/>
    public MerchantCategoryCodeBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantCategoryCodeBlocked.FromRawUnchecked(rawData);
}

/// <summary>
/// Restricts which merchant countries are allowed or blocked for authorizations
/// on this card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MerchantCountry, MerchantCountryFromRaw>))]
public sealed record class MerchantCountry : JsonModel
{
    /// <summary>
    /// The merchant countries that are allowed for authorizations on this card. Authorizations
    /// with merchant countries not in this list will be declined.
    /// </summary>
    public IReadOnlyList<MerchantCountryAllowed>? Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MerchantCountryAllowed>>(
                "allowed"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MerchantCountryAllowed>?>(
                "allowed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The merchant countries that are blocked for authorizations on this card. Authorizations
    /// with merchant countries in this list will be declined.
    /// </summary>
    public IReadOnlyList<MerchantCountryBlocked>? Blocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MerchantCountryBlocked>>(
                "blocked"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MerchantCountryBlocked>?>(
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

    public MerchantCountry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCountry(MerchantCountry merchantCountry)
        : base(merchantCountry) { }
#pragma warning restore CS8618

    public MerchantCountry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCountry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCountryFromRaw.FromRawUnchecked"/>
    public static MerchantCountry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MerchantCountryFromRaw : IFromRawJson<MerchantCountry>
{
    /// <inheritdoc/>
    public MerchantCountry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MerchantCountry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MerchantCountryAllowed, MerchantCountryAllowedFromRaw>))]
public sealed record class MerchantCountryAllowed : JsonModel
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

    public MerchantCountryAllowed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCountryAllowed(MerchantCountryAllowed merchantCountryAllowed)
        : base(merchantCountryAllowed) { }
#pragma warning restore CS8618

    public MerchantCountryAllowed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCountryAllowed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCountryAllowedFromRaw.FromRawUnchecked"/>
    public static MerchantCountryAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantCountryAllowed(string country)
        : this()
    {
        this.Country = country;
    }
}

class MerchantCountryAllowedFromRaw : IFromRawJson<MerchantCountryAllowed>
{
    /// <inheritdoc/>
    public MerchantCountryAllowed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantCountryAllowed.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MerchantCountryBlocked, MerchantCountryBlockedFromRaw>))]
public sealed record class MerchantCountryBlocked : JsonModel
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

    public MerchantCountryBlocked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MerchantCountryBlocked(MerchantCountryBlocked merchantCountryBlocked)
        : base(merchantCountryBlocked) { }
#pragma warning restore CS8618

    public MerchantCountryBlocked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MerchantCountryBlocked(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MerchantCountryBlockedFromRaw.FromRawUnchecked"/>
    public static MerchantCountryBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MerchantCountryBlocked(string country)
        : this()
    {
        this.Country = country;
    }
}

class MerchantCountryBlockedFromRaw : IFromRawJson<MerchantCountryBlocked>
{
    /// <inheritdoc/>
    public MerchantCountryBlocked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MerchantCountryBlocked.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls how many times this card can be used.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    /// <summary>
    /// Whether the card is for a single use or multiple uses.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Controls for multi-use cards. Required if and only if `category` is `multi_use`.
    /// </summary>
    public MultiUse? MultiUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MultiUse>("multi_use");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("multi_use", value);
        }
    }

    /// <summary>
    /// Controls for single-use cards. Required if and only if `category` is `single_use`.
    /// </summary>
    public SingleUse? SingleUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SingleUse>("single_use");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("single_use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.MultiUse?.Validate();
        this.SingleUse?.Validate();
    }

    public Usage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage(Usage usage)
        : base(usage) { }
#pragma warning restore CS8618

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Usage(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the card is for a single use or multiple uses.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The card can only be used for a single authorization.
    /// </summary>
    SingleUse,

    /// <summary>
    /// The card can be used for multiple authorizations.
    /// </summary>
    MultiUse,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single_use" => Category.SingleUse,
            "multi_use" => Category.MultiUse,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.SingleUse => "single_use",
                Category.MultiUse => "multi_use",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Controls for multi-use cards. Required if and only if `category` is `multi_use`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MultiUse, MultiUseFromRaw>))]
public sealed record class MultiUse : JsonModel
{
    /// <summary>
    /// Spending limits for this card. The most restrictive limit applies if multiple
    /// limits match.
    /// </summary>
    public IReadOnlyList<SpendingLimit>? SpendingLimits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SpendingLimit>>(
                "spending_limits"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SpendingLimit>?>(
                "spending_limits",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.SpendingLimits ?? [])
        {
            item.Validate();
        }
    }

    public MultiUse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultiUse(MultiUse multiUse)
        : base(multiUse) { }
#pragma warning restore CS8618

    public MultiUse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultiUse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultiUseFromRaw.FromRawUnchecked"/>
    public static MultiUse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultiUseFromRaw : IFromRawJson<MultiUse>
{
    /// <inheritdoc/>
    public MultiUse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MultiUse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SpendingLimit, SpendingLimitFromRaw>))]
public sealed record class SpendingLimit : JsonModel
{
    /// <summary>
    /// The interval at which the spending limit is enforced.
    /// </summary>
    public required ApiEnum<string, Interval> Interval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Interval>>("interval");
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
    public IReadOnlyList<SpendingLimitMerchantCategoryCode>? MerchantCategoryCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SpendingLimitMerchantCategoryCode>
            >("merchant_category_codes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SpendingLimitMerchantCategoryCode>?>(
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

    public SpendingLimit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendingLimit(SpendingLimit spendingLimit)
        : base(spendingLimit) { }
#pragma warning restore CS8618

    public SpendingLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendingLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendingLimitFromRaw.FromRawUnchecked"/>
    public static SpendingLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendingLimitFromRaw : IFromRawJson<SpendingLimit>
{
    /// <inheritdoc/>
    public SpendingLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpendingLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// The interval at which the spending limit is enforced.
/// </summary>
[JsonConverter(typeof(IntervalConverter))]
public enum Interval
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

sealed class IntervalConverter : JsonConverter<Interval>
{
    public override Interval Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all_time" => Interval.AllTime,
            "per_transaction" => Interval.PerTransaction,
            "per_day" => Interval.PerDay,
            "per_week" => Interval.PerWeek,
            "per_month" => Interval.PerMonth,
            _ => (Interval)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Interval value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Interval.AllTime => "all_time",
                Interval.PerTransaction => "per_transaction",
                Interval.PerDay => "per_day",
                Interval.PerWeek => "per_week",
                Interval.PerMonth => "per_month",
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
        SpendingLimitMerchantCategoryCode,
        SpendingLimitMerchantCategoryCodeFromRaw
    >)
)]
public sealed record class SpendingLimitMerchantCategoryCode : JsonModel
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

    public SpendingLimitMerchantCategoryCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendingLimitMerchantCategoryCode(
        SpendingLimitMerchantCategoryCode spendingLimitMerchantCategoryCode
    )
        : base(spendingLimitMerchantCategoryCode) { }
#pragma warning restore CS8618

    public SpendingLimitMerchantCategoryCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendingLimitMerchantCategoryCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendingLimitMerchantCategoryCodeFromRaw.FromRawUnchecked"/>
    public static SpendingLimitMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendingLimitMerchantCategoryCode(string code)
        : this()
    {
        this.Code = code;
    }
}

class SpendingLimitMerchantCategoryCodeFromRaw : IFromRawJson<SpendingLimitMerchantCategoryCode>
{
    /// <inheritdoc/>
    public SpendingLimitMerchantCategoryCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendingLimitMerchantCategoryCode.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls for single-use cards. Required if and only if `category` is `single_use`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SingleUse, SingleUseFromRaw>))]
public sealed record class SingleUse : JsonModel
{
    /// <summary>
    /// The settlement amount constraint for this single-use card.
    /// </summary>
    public required SettlementAmount SettlementAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SettlementAmount>("settlement_amount");
        }
        init { this._rawData.Set("settlement_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SettlementAmount.Validate();
    }

    public SingleUse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SingleUse(SingleUse singleUse)
        : base(singleUse) { }
#pragma warning restore CS8618

    public SingleUse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SingleUse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SingleUseFromRaw.FromRawUnchecked"/>
    public static SingleUse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SingleUse(SettlementAmount settlementAmount)
        : this()
    {
        this.SettlementAmount = settlementAmount;
    }
}

class SingleUseFromRaw : IFromRawJson<SingleUse>
{
    /// <inheritdoc/>
    public SingleUse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SingleUse.FromRawUnchecked(rawData);
}

/// <summary>
/// The settlement amount constraint for this single-use card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SettlementAmount, SettlementAmountFromRaw>))]
public sealed record class SettlementAmount : JsonModel
{
    /// <summary>
    /// The operator used to compare the settlement amount.
    /// </summary>
    public required ApiEnum<string, Comparison> Comparison
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Comparison>>("comparison");
        }
        init { this._rawData.Set("comparison", value); }
    }

    /// <summary>
    /// The settlement amount value.
    /// </summary>
    public required long Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Comparison.Validate();
        _ = this.Value;
    }

    public SettlementAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SettlementAmount(SettlementAmount settlementAmount)
        : base(settlementAmount) { }
#pragma warning restore CS8618

    public SettlementAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SettlementAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SettlementAmountFromRaw.FromRawUnchecked"/>
    public static SettlementAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SettlementAmountFromRaw : IFromRawJson<SettlementAmount>
{
    /// <inheritdoc/>
    public SettlementAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SettlementAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// The operator used to compare the settlement amount.
/// </summary>
[JsonConverter(typeof(ComparisonConverter))]
public enum Comparison
{
    /// <summary>
    /// The settlement amount must be exactly the specified value.
    /// </summary>
    Equals,

    /// <summary>
    /// The settlement amount must be less than or equal to the specified value.
    /// </summary>
    LessThanOrEquals,
}

sealed class ComparisonConverter : JsonConverter<Comparison>
{
    public override Comparison Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equals" => Comparison.Equals,
            "less_than_or_equals" => Comparison.LessThanOrEquals,
            _ => (Comparison)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Comparison value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Comparison.Equals => "equals",
                Comparison.LessThanOrEquals => "less_than_or_equals",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The card's billing address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : JsonModel
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

    public BillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }
#pragma warning restore CS8618

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingAddressFromRaw.FromRawUnchecked"/>
    public static BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingAddressFromRaw : IFromRawJson<BillingAddress>
{
    /// <inheritdoc/>
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The contact information used in the two-factor steps for digital wallet card
/// creation. To add the card to a digital wallet, you may supply an email or phone
/// number with this request. Otherwise, subscribe and then action a Real Time Decision
/// with the category `digital_wallet_token_requested` or `digital_wallet_authentication_requested`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalWallet, DigitalWalletFromRaw>))]
public sealed record class DigitalWallet : JsonModel
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
    /// An email address that can be used to contact and verify the cardholder via
    /// one-time passcode over email.
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
    /// A phone number that can be used to contact and verify the cardholder via
    /// one-time passcode over SMS.
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

    public DigitalWallet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWallet(DigitalWallet digitalWallet)
        : base(digitalWallet) { }
#pragma warning restore CS8618

    public DigitalWallet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalWallet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalWalletFromRaw.FromRawUnchecked"/>
    public static DigitalWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalWalletFromRaw : IFromRawJson<DigitalWallet>
{
    /// <inheritdoc/>
    public DigitalWallet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalWallet.FromRawUnchecked(rawData);
}
