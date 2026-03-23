using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CardPushTransfers;

/// <summary>
/// A list of Card Push Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CardPushTransferListPageResponse,
        CardPushTransferListPageResponseFromRaw
    >)
)]
public sealed record class CardPushTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CardPushTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardPushTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardPushTransfer>>(
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

    public CardPushTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPushTransferListPageResponse(
        CardPushTransferListPageResponse cardPushTransferListPageResponse
    )
        : base(cardPushTransferListPageResponse) { }
#pragma warning restore CS8618

    public CardPushTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPushTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPushTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardPushTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPushTransferListPageResponseFromRaw : IFromRawJson<CardPushTransferListPageResponse>
{
    /// <inheritdoc/>
    public CardPushTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPushTransferListPageResponse.FromRawUnchecked(rawData);
}
