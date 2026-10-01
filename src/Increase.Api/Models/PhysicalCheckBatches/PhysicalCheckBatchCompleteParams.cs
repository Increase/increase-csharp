using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.PhysicalCheckBatches;

/// <summary>
/// Completing a Physical Check Batch closes it to new Physical Checks and begins
/// the process of printing and mailing it.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhysicalCheckBatchCompleteParams : ParamsBase
{
    public string? PhysicalCheckBatchID { get; init; }

    public PhysicalCheckBatchCompleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCheckBatchCompleteParams(
        PhysicalCheckBatchCompleteParams physicalCheckBatchCompleteParams
    )
        : base(physicalCheckBatchCompleteParams)
    {
        this.PhysicalCheckBatchID = physicalCheckBatchCompleteParams.PhysicalCheckBatchID;
    }
#pragma warning restore CS8618

    public PhysicalCheckBatchCompleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCheckBatchCompleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string physicalCheckBatchID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PhysicalCheckBatchID = physicalCheckBatchID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhysicalCheckBatchCompleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string physicalCheckBatchID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            physicalCheckBatchID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PhysicalCheckBatchID"] = JsonSerializer.SerializeToElement(
                        this.PhysicalCheckBatchID
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

    public virtual bool Equals(PhysicalCheckBatchCompleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.PhysicalCheckBatchID?.Equals(other.PhysicalCheckBatchID)
                ?? other.PhysicalCheckBatchID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/physical_check_batches/{0}/complete", this.PhysicalCheckBatchID)
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
