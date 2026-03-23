using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Simulations.AchTransfers;

/// <summary>
/// Simulates the submission of an [ACH Transfer](#ach-transfers) to the Federal
/// Reserve. This transfer must first have a `status` of `pending_approval` or `pending_submission`.
/// In production, Increase submits ACH Transfers to the Federal Reserve three times
/// per day on weekdays. Since sandbox ACH Transfers are not submitted to the Federal
/// Reserve, this endpoint allows you to skip that delay and transition the ACH Transfer
/// to a status of `submitted`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AchTransferSubmitParams : ParamsBase
{
    public string? AchTransferID { get; init; }

    public AchTransferSubmitParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferSubmitParams(AchTransferSubmitParams achTransferSubmitParams)
        : base(achTransferSubmitParams)
    {
        this.AchTransferID = achTransferSubmitParams.AchTransferID;
    }
#pragma warning restore CS8618

    public AchTransferSubmitParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferSubmitParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string achTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AchTransferID = achTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AchTransferSubmitParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string achTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            achTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AchTransferID"] = JsonSerializer.SerializeToElement(this.AchTransferID),
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

    public virtual bool Equals(AchTransferSubmitParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AchTransferID?.Equals(other.AchTransferID) ?? other.AchTransferID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/simulations/ach_transfers/{0}/submit", this.AchTransferID)
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
