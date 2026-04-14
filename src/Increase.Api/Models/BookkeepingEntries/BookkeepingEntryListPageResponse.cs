using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.BookkeepingEntries;

/// <summary>
/// A list of Bookkeeping Entry objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BookkeepingEntryListPageResponse,
        BookkeepingEntryListPageResponseFromRaw
    >)
)]
public sealed record class BookkeepingEntryListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<BookkeepingEntry> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BookkeepingEntry>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BookkeepingEntry>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A pointer to a place in the list. Pass this as the `cursor` parameter to retrieve
    /// the next page of results. If there are no more results, the value will be `null`.
    /// </summary>
    public required string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public BookkeepingEntryListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntryListPageResponse(
        BookkeepingEntryListPageResponse bookkeepingEntryListPageResponse
    )
        : base(bookkeepingEntryListPageResponse) { }
#pragma warning restore CS8618

    public BookkeepingEntryListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntryListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingEntryListPageResponseFromRaw.FromRawUnchecked"/>
    public static BookkeepingEntryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingEntryListPageResponseFromRaw : IFromRawJson<BookkeepingEntryListPageResponse>
{
    /// <inheritdoc/>
    public BookkeepingEntryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookkeepingEntryListPageResponse.FromRawUnchecked(rawData);
}
