using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.CardPurchaseSupplements;

/// <summary>
/// Retrieve a Card Purchase Supplement
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardPurchaseSupplementRetrieveParams : ParamsBase
{
    public string? CardPurchaseSupplementID { get; init; }

    public CardPurchaseSupplementRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPurchaseSupplementRetrieveParams(
        CardPurchaseSupplementRetrieveParams cardPurchaseSupplementRetrieveParams
    )
        : base(cardPurchaseSupplementRetrieveParams)
    {
        this.CardPurchaseSupplementID =
            cardPurchaseSupplementRetrieveParams.CardPurchaseSupplementID;
    }
#pragma warning restore CS8618

    public CardPurchaseSupplementRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPurchaseSupplementRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string cardPurchaseSupplementID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CardPurchaseSupplementID = cardPurchaseSupplementID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardPurchaseSupplementRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string cardPurchaseSupplementID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            cardPurchaseSupplementID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CardPurchaseSupplementID"] = JsonSerializer.SerializeToElement(
                        this.CardPurchaseSupplementID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CardPurchaseSupplementRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.CardPurchaseSupplementID?.Equals(other.CardPurchaseSupplementID)
                ?? other.CardPurchaseSupplementID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/card_purchase_supplements/{0}", this.CardPurchaseSupplementID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
