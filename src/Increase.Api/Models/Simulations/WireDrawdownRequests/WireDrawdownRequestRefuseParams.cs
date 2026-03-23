using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.WireDrawdownRequests;

/// <summary>
/// Simulates a Wire Drawdown Request being refused by the debtor.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WireDrawdownRequestRefuseParams : ParamsBase
{
    public string? WireDrawdownRequestID { get; init; }

    public WireDrawdownRequestRefuseParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequestRefuseParams(
        WireDrawdownRequestRefuseParams wireDrawdownRequestRefuseParams
    )
        : base(wireDrawdownRequestRefuseParams)
    {
        this.WireDrawdownRequestID = wireDrawdownRequestRefuseParams.WireDrawdownRequestID;
    }
#pragma warning restore CS8618

    public WireDrawdownRequestRefuseParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireDrawdownRequestRefuseParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string wireDrawdownRequestID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.WireDrawdownRequestID = wireDrawdownRequestID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WireDrawdownRequestRefuseParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string wireDrawdownRequestID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            wireDrawdownRequestID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WireDrawdownRequestID"] = JsonSerializer.SerializeToElement(
                        this.WireDrawdownRequestID
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

    public virtual bool Equals(WireDrawdownRequestRefuseParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.WireDrawdownRequestID?.Equals(other.WireDrawdownRequestID)
                ?? other.WireDrawdownRequestID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/simulations/wire_drawdown_requests/{0}/refuse",
                    this.WireDrawdownRequestID
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
