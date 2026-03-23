using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.PendingTransactions;

/// <summary>
/// This endpoint simulates immediately releasing an Inbound Funds Hold, which might
/// be created as a result of, for example, an ACH debit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PendingTransactionReleaseInboundFundsHoldParams : ParamsBase
{
    public string? PendingTransactionID { get; init; }

    public PendingTransactionReleaseInboundFundsHoldParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PendingTransactionReleaseInboundFundsHoldParams(
        PendingTransactionReleaseInboundFundsHoldParams pendingTransactionReleaseInboundFundsHoldParams
    )
        : base(pendingTransactionReleaseInboundFundsHoldParams)
    {
        this.PendingTransactionID =
            pendingTransactionReleaseInboundFundsHoldParams.PendingTransactionID;
    }
#pragma warning restore CS8618

    public PendingTransactionReleaseInboundFundsHoldParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PendingTransactionReleaseInboundFundsHoldParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string pendingTransactionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PendingTransactionID = pendingTransactionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PendingTransactionReleaseInboundFundsHoldParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string pendingTransactionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            pendingTransactionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PendingTransactionID"] = JsonSerializer.SerializeToElement(
                        this.PendingTransactionID
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

    public virtual bool Equals(PendingTransactionReleaseInboundFundsHoldParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.PendingTransactionID?.Equals(other.PendingTransactionID)
                ?? other.PendingTransactionID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/pending_transactions/{0}/release_inbound_funds_hold",
                    this.PendingTransactionID
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
