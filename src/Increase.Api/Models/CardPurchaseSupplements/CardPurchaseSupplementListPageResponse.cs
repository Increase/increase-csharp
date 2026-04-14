using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CardPurchaseSupplements;

/// <summary>
/// A list of Card Purchase Supplement objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardPurchaseSupplementListPageResponse,
        CardPurchaseSupplementListPageResponseFromRaw
    >)
)]
public sealed record class CardPurchaseSupplementListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CardPurchaseSupplement> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardPurchaseSupplement>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardPurchaseSupplement>>(
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

    public CardPurchaseSupplementListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPurchaseSupplementListPageResponse(
        CardPurchaseSupplementListPageResponse cardPurchaseSupplementListPageResponse
    )
        : base(cardPurchaseSupplementListPageResponse) { }
#pragma warning restore CS8618

    public CardPurchaseSupplementListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPurchaseSupplementListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPurchaseSupplementListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardPurchaseSupplementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPurchaseSupplementListPageResponseFromRaw
    : IFromRawJson<CardPurchaseSupplementListPageResponse>
{
    /// <inheritdoc/>
    public CardPurchaseSupplementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPurchaseSupplementListPageResponse.FromRawUnchecked(rawData);
}
