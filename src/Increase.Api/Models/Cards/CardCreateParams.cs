using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/cards")
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
