using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.LockboxRecipients;

/// <summary>
/// Retrieve a Lockbox Recipient
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LockboxRecipientRetrieveParams : ParamsBase
{
    public string? LockboxRecipientID { get; init; }

    public LockboxRecipientRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxRecipientRetrieveParams(
        LockboxRecipientRetrieveParams lockboxRecipientRetrieveParams
    )
        : base(lockboxRecipientRetrieveParams)
    {
        this.LockboxRecipientID = lockboxRecipientRetrieveParams.LockboxRecipientID;
    }
#pragma warning restore CS8618

    public LockboxRecipientRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LockboxRecipientRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string lockboxRecipientID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.LockboxRecipientID = lockboxRecipientID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LockboxRecipientRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string lockboxRecipientID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            lockboxRecipientID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["LockboxRecipientID"] = JsonSerializer.SerializeToElement(
                        this.LockboxRecipientID
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

    public virtual bool Equals(LockboxRecipientRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.LockboxRecipientID?.Equals(other.LockboxRecipientID)
                ?? other.LockboxRecipientID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/lockbox_recipients/{0}", this.LockboxRecipientID)
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
