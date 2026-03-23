using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundWireDrawdownRequests;

/// <summary>
/// Retrieve an Inbound Wire Drawdown Request
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundWireDrawdownRequestRetrieveParams : ParamsBase
{
    public string? InboundWireDrawdownRequestID { get; init; }

    public InboundWireDrawdownRequestRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireDrawdownRequestRetrieveParams(
        InboundWireDrawdownRequestRetrieveParams inboundWireDrawdownRequestRetrieveParams
    )
        : base(inboundWireDrawdownRequestRetrieveParams)
    {
        this.InboundWireDrawdownRequestID =
            inboundWireDrawdownRequestRetrieveParams.InboundWireDrawdownRequestID;
    }
#pragma warning restore CS8618

    public InboundWireDrawdownRequestRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireDrawdownRequestRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string inboundWireDrawdownRequestID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.InboundWireDrawdownRequestID = inboundWireDrawdownRequestID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboundWireDrawdownRequestRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string inboundWireDrawdownRequestID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            inboundWireDrawdownRequestID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InboundWireDrawdownRequestID"] = JsonSerializer.SerializeToElement(
                        this.InboundWireDrawdownRequestID
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

    public virtual bool Equals(InboundWireDrawdownRequestRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.InboundWireDrawdownRequestID?.Equals(other.InboundWireDrawdownRequestID)
                ?? other.InboundWireDrawdownRequestID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/inbound_wire_drawdown_requests/{0}",
                    this.InboundWireDrawdownRequestID
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
