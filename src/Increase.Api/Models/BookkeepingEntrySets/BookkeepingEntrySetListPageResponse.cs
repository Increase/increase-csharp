using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.BookkeepingEntrySets;

/// <summary>
/// A list of Bookkeeping Entry Set objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BookkeepingEntrySetListPageResponse,
        BookkeepingEntrySetListPageResponseFromRaw
    >)
)]
public sealed record class BookkeepingEntrySetListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<BookkeepingEntrySet> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BookkeepingEntrySet>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BookkeepingEntrySet>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A pointer to a place in the list.
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

    public BookkeepingEntrySetListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingEntrySetListPageResponse(
        BookkeepingEntrySetListPageResponse bookkeepingEntrySetListPageResponse
    )
        : base(bookkeepingEntrySetListPageResponse) { }
#pragma warning restore CS8618

    public BookkeepingEntrySetListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingEntrySetListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingEntrySetListPageResponseFromRaw.FromRawUnchecked"/>
    public static BookkeepingEntrySetListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingEntrySetListPageResponseFromRaw : IFromRawJson<BookkeepingEntrySetListPageResponse>
{
    /// <inheritdoc/>
    public BookkeepingEntrySetListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookkeepingEntrySetListPageResponse.FromRawUnchecked(rawData);
}
