using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Cards;

/// <summary>
/// A list of Card objects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardListPageResponse, CardListPageResponseFromRaw>))]
public sealed record class CardListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Card> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Card>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Card>>("data", ImmutableArray.ToImmutableArray(value));
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

    public CardListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardListPageResponse(CardListPageResponse cardListPageResponse)
        : base(cardListPageResponse) { }
#pragma warning restore CS8618

    public CardListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardListPageResponseFromRaw : IFromRawJson<CardListPageResponse>
{
    /// <inheritdoc/>
    public CardListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardListPageResponse.FromRawUnchecked(rawData);
}
