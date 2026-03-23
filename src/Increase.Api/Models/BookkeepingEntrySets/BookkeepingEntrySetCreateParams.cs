using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.BookkeepingEntrySets;

/// <summary>
/// Create a Bookkeeping Entry Set
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BookkeepingEntrySetCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The bookkeeping entries.
    /// </summary>
    public required IReadOnlyList<Entry> Entries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Entry>>("entries");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Entry>>(
                "entries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The date of the transaction. Optional if `transaction_id` is provided, in
    /// which case we use the `date` of that transaction. Required otherwise.
    /// </summary>
    public DateTimeOffset? Date
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("date", value);
        }
    }

    /// <summary>
    /// The identifier of the Transaction related to this entry set, if any.
    /// </summary>
    public string? TransactionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("transaction_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transaction_id", value);
        }
    }

    public BookkeepingEntrySetCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntrySetCreateParams(
        BookkeepingEntrySetCreateParams bookkeepingEntrySetCreateParams
    )
        : base(bookkeepingEntrySetCreateParams)
    {
        this._rawBodyData = new(bookkeepingEntrySetCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BookkeepingEntrySetCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntrySetCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BookkeepingEntrySetCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BookkeepingEntrySetCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/bookkeeping_entry_sets")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(typeof(JsonModelConverter<Entry, EntryFromRaw>))]
public sealed record class Entry : JsonModel
{
    /// <summary>
    /// The identifier for the Bookkeeping Account impacted by this entry.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The entry amount in the minor unit of the account currency. For dollars, for
    /// example, this is cents. Debit entries have positive amounts; credit entries
    /// have negative amounts.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.Amount;
    }

    public Entry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entry(Entry entry)
        : base(entry) { }
#pragma warning restore CS8618

    public Entry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntryFromRaw.FromRawUnchecked"/>
    public static Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntryFromRaw : IFromRawJson<Entry>
{
    /// <inheritdoc/>
    public Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entry.FromRawUnchecked(rawData);
}
