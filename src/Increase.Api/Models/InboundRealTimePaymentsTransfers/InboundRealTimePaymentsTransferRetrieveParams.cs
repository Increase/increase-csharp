using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundRealTimePaymentsTransfers;

/// <summary>
/// Retrieve an Inbound Real-Time Payments Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundRealTimePaymentsTransferRetrieveParams : ParamsBase
{
    public string? InboundRealTimePaymentsTransferID { get; init; }

    public InboundRealTimePaymentsTransferRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsTransferRetrieveParams(
        InboundRealTimePaymentsTransferRetrieveParams inboundRealTimePaymentsTransferRetrieveParams
    )
        : base(inboundRealTimePaymentsTransferRetrieveParams)
    {
        this.InboundRealTimePaymentsTransferID =
            inboundRealTimePaymentsTransferRetrieveParams.InboundRealTimePaymentsTransferID;
    }
#pragma warning restore CS8618

    public InboundRealTimePaymentsTransferRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsTransferRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string inboundRealTimePaymentsTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.InboundRealTimePaymentsTransferID = inboundRealTimePaymentsTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboundRealTimePaymentsTransferRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string inboundRealTimePaymentsTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            inboundRealTimePaymentsTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InboundRealTimePaymentsTransferID"] = JsonSerializer.SerializeToElement(
                        this.InboundRealTimePaymentsTransferID
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

    public virtual bool Equals(InboundRealTimePaymentsTransferRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.InboundRealTimePaymentsTransferID?.Equals(
                    other.InboundRealTimePaymentsTransferID
                )
                ?? other.InboundRealTimePaymentsTransferID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/inbound_real_time_payments_transfers/{0}",
                    this.InboundRealTimePaymentsTransferID
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
