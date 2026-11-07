using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.CheckbookChecks;

/// <summary>
/// Retrieve a Checkbook Check
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CheckbookCheckRetrieveParams : ParamsBase
{
    public string? CheckbookCheckID { get; init; }

    public CheckbookCheckRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckbookCheckRetrieveParams(CheckbookCheckRetrieveParams checkbookCheckRetrieveParams)
        : base(checkbookCheckRetrieveParams)
    {
        this.CheckbookCheckID = checkbookCheckRetrieveParams.CheckbookCheckID;
    }
#pragma warning restore CS8618

    public CheckbookCheckRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckbookCheckRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string checkbookCheckID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CheckbookCheckID = checkbookCheckID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CheckbookCheckRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string checkbookCheckID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            checkbookCheckID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CheckbookCheckID"] = JsonSerializer.SerializeToElement(this.CheckbookCheckID),
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

    public virtual bool Equals(CheckbookCheckRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.CheckbookCheckID?.Equals(other.CheckbookCheckID)
                ?? other.CheckbookCheckID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/checkbook_checks/{0}", this.CheckbookCheckID)
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
