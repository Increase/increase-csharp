using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.CardAuthentications;

/// <summary>
/// Simulates starting a Card Authentication Challenge for an existing Card Authentication.
/// This updates the `card_authentications` object under the [Card Payment](#card_payments).
/// To attempt the challenge, use the `/simulations/card_authentications/:card_payment_id/challenge_attempts`
/// endpoint or navigate to https://dashboard.increase.com/card_authentication_simulation/:card_payment_id.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardAuthenticationChallengesParams : ParamsBase
{
    public string? CardPaymentID { get; init; }

    public CardAuthenticationChallengesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAuthenticationChallengesParams(
        CardAuthenticationChallengesParams cardAuthenticationChallengesParams
    )
        : base(cardAuthenticationChallengesParams)
    {
        this.CardPaymentID = cardAuthenticationChallengesParams.CardPaymentID;
    }
#pragma warning restore CS8618

    public CardAuthenticationChallengesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAuthenticationChallengesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string cardPaymentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CardPaymentID = cardPaymentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardAuthenticationChallengesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string cardPaymentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            cardPaymentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CardPaymentID"] = JsonSerializer.SerializeToElement(this.CardPaymentID),
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

    public virtual bool Equals(CardAuthenticationChallengesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CardPaymentID?.Equals(other.CardPaymentID) ?? other.CardPaymentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/card_authentications/{0}/challenges",
                    this.CardPaymentID
                )
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
