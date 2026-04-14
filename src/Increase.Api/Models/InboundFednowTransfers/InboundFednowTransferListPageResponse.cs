using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundFednowTransfers;

/// <summary>
/// A list of Inbound FedNow Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundFednowTransferListPageResponse,
        InboundFednowTransferListPageResponseFromRaw
    >)
)]
public sealed record class InboundFednowTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundFednowTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundFednowTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundFednowTransfer>>(
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

    public InboundFednowTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundFednowTransferListPageResponse(
        InboundFednowTransferListPageResponse inboundFednowTransferListPageResponse
    )
        : base(inboundFednowTransferListPageResponse) { }
#pragma warning restore CS8618

    public InboundFednowTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundFednowTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundFednowTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundFednowTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundFednowTransferListPageResponseFromRaw
    : IFromRawJson<InboundFednowTransferListPageResponse>
{
    /// <inheritdoc/>
    public InboundFednowTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundFednowTransferListPageResponse.FromRawUnchecked(rawData);
}
