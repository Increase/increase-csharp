using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundWireTransfers;

/// <summary>
/// A list of Inbound Wire Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundWireTransferListPageResponse,
        InboundWireTransferListPageResponseFromRaw
    >)
)]
public sealed record class InboundWireTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundWireTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundWireTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundWireTransfer>>(
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

    public InboundWireTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireTransferListPageResponse(
        InboundWireTransferListPageResponse inboundWireTransferListPageResponse
    )
        : base(inboundWireTransferListPageResponse) { }
#pragma warning restore CS8618

    public InboundWireTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundWireTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundWireTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundWireTransferListPageResponseFromRaw : IFromRawJson<InboundWireTransferListPageResponse>
{
    /// <inheritdoc/>
    public InboundWireTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundWireTransferListPageResponse.FromRawUnchecked(rawData);
}
