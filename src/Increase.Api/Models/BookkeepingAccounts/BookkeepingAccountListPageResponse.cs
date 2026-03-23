using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.BookkeepingAccounts;

/// <summary>
/// A list of Bookkeeping Account objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BookkeepingAccountListPageResponse,
        BookkeepingAccountListPageResponseFromRaw
    >)
)]
public sealed record class BookkeepingAccountListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<BookkeepingAccount> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BookkeepingAccount>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BookkeepingAccount>>(
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

    public BookkeepingAccountListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookkeepingAccountListPageResponse(
        BookkeepingAccountListPageResponse bookkeepingAccountListPageResponse
    )
        : base(bookkeepingAccountListPageResponse) { }
#pragma warning restore CS8618

    public BookkeepingAccountListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookkeepingAccountListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookkeepingAccountListPageResponseFromRaw.FromRawUnchecked"/>
    public static BookkeepingAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookkeepingAccountListPageResponseFromRaw : IFromRawJson<BookkeepingAccountListPageResponse>
{
    /// <inheritdoc/>
    public BookkeepingAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookkeepingAccountListPageResponse.FromRawUnchecked(rawData);
}
