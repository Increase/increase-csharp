using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.RealTimePaymentsTransfers;

/// <summary>
/// Retrieve a Real-Time Payments Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RealTimePaymentsTransferRetrieveParams : ParamsBase
{
    public string? RealTimePaymentsTransferID { get; init; }

    public RealTimePaymentsTransferRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsTransferRetrieveParams(
        RealTimePaymentsTransferRetrieveParams realTimePaymentsTransferRetrieveParams
    )
        : base(realTimePaymentsTransferRetrieveParams)
    {
        this.RealTimePaymentsTransferID =
            realTimePaymentsTransferRetrieveParams.RealTimePaymentsTransferID;
    }
#pragma warning restore CS8618

    public RealTimePaymentsTransferRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsTransferRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string realTimePaymentsTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RealTimePaymentsTransferID = realTimePaymentsTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RealTimePaymentsTransferRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string realTimePaymentsTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            realTimePaymentsTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RealTimePaymentsTransferID"] = JsonSerializer.SerializeToElement(
                        this.RealTimePaymentsTransferID
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

    public virtual bool Equals(RealTimePaymentsTransferRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.RealTimePaymentsTransferID?.Equals(other.RealTimePaymentsTransferID)
                ?? other.RealTimePaymentsTransferID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/real_time_payments_transfers/{0}",
                    this.RealTimePaymentsTransferID
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
