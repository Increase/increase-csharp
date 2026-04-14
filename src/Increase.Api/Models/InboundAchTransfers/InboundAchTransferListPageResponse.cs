using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundAchTransfers;

/// <summary>
/// A list of Inbound ACH Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundAchTransferListPageResponse,
        InboundAchTransferListPageResponseFromRaw
    >)
)]
public sealed record class InboundAchTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundAchTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundAchTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundAchTransfer>>(
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

    public InboundAchTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransferListPageResponse(
        InboundAchTransferListPageResponse inboundAchTransferListPageResponse
    )
        : base(inboundAchTransferListPageResponse) { }
#pragma warning restore CS8618

    public InboundAchTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundAchTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundAchTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundAchTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundAchTransferListPageResponseFromRaw : IFromRawJson<InboundAchTransferListPageResponse>
{
    /// <inheritdoc/>
    public InboundAchTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundAchTransferListPageResponse.FromRawUnchecked(rawData);
}
