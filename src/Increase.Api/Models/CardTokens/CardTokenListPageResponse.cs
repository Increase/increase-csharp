using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CardTokens;

/// <summary>
/// A list of Card Token objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardTokenListPageResponse, CardTokenListPageResponseFromRaw>)
)]
public sealed record class CardTokenListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CardToken> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardToken>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardToken>>(
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

    public CardTokenListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardTokenListPageResponse(CardTokenListPageResponse cardTokenListPageResponse)
        : base(cardTokenListPageResponse) { }
#pragma warning restore CS8618

    public CardTokenListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardTokenListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardTokenListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardTokenListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardTokenListPageResponseFromRaw : IFromRawJson<CardTokenListPageResponse>
{
    /// <inheritdoc/>
    public CardTokenListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardTokenListPageResponse.FromRawUnchecked(rawData);
}
