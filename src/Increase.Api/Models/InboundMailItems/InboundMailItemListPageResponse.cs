using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundMailItems;

/// <summary>
/// A list of Inbound Mail Item objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundMailItemListPageResponse,
        InboundMailItemListPageResponseFromRaw
    >)
)]
public sealed record class InboundMailItemListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundMailItem> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundMailItem>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundMailItem>>(
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

    public InboundMailItemListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMailItemListPageResponse(
        InboundMailItemListPageResponse inboundMailItemListPageResponse
    )
        : base(inboundMailItemListPageResponse) { }
#pragma warning restore CS8618

    public InboundMailItemListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMailItemListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundMailItemListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundMailItemListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundMailItemListPageResponseFromRaw : IFromRawJson<InboundMailItemListPageResponse>
{
    /// <inheritdoc/>
    public InboundMailItemListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundMailItemListPageResponse.FromRawUnchecked(rawData);
}
