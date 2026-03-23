using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CardDisputes;

/// <summary>
/// A list of Card Dispute objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardDisputeListPageResponse, CardDisputeListPageResponseFromRaw>)
)]
public sealed record class CardDisputeListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CardDispute> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardDispute>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardDispute>>(
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

    public CardDisputeListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeListPageResponse(CardDisputeListPageResponse cardDisputeListPageResponse)
        : base(cardDisputeListPageResponse) { }
#pragma warning restore CS8618

    public CardDisputeListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardDisputeListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardDisputeListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardDisputeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardDisputeListPageResponseFromRaw : IFromRawJson<CardDisputeListPageResponse>
{
    /// <inheritdoc/>
    public CardDisputeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardDisputeListPageResponse.FromRawUnchecked(rawData);
}
