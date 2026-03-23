using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.BookkeepingEntrySets;

/// <summary>
/// Retrieve a Bookkeeping Entry Set
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BookkeepingEntrySetRetrieveParams : ParamsBase
{
    public string? BookkeepingEntrySetID { get; init; }

    public BookkeepingEntrySetRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntrySetRetrieveParams(
        BookkeepingEntrySetRetrieveParams bookkeepingEntrySetRetrieveParams
    )
        : base(bookkeepingEntrySetRetrieveParams)
    {
        this.BookkeepingEntrySetID = bookkeepingEntrySetRetrieveParams.BookkeepingEntrySetID;
    }
#pragma warning restore CS8618

    public BookkeepingEntrySetRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntrySetRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string bookkeepingEntrySetID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BookkeepingEntrySetID = bookkeepingEntrySetID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BookkeepingEntrySetRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string bookkeepingEntrySetID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            bookkeepingEntrySetID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BookkeepingEntrySetID"] = JsonSerializer.SerializeToElement(
                        this.BookkeepingEntrySetID
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

    public virtual bool Equals(BookkeepingEntrySetRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.BookkeepingEntrySetID?.Equals(other.BookkeepingEntrySetID)
                ?? other.BookkeepingEntrySetID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/bookkeeping_entry_sets/{0}", this.BookkeepingEntrySetID)
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
