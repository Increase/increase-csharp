using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundRealTimePaymentsTransfers;

/// <summary>
/// A list of Inbound Real-Time Payments Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundRealTimePaymentsTransferListPageResponse,
        InboundRealTimePaymentsTransferListPageResponseFromRaw
    >)
)]
public sealed record class InboundRealTimePaymentsTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundRealTimePaymentsTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundRealTimePaymentsTransfer>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundRealTimePaymentsTransfer>>(
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

    public InboundRealTimePaymentsTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsTransferListPageResponse(
        InboundRealTimePaymentsTransferListPageResponse inboundRealTimePaymentsTransferListPageResponse
    )
        : base(inboundRealTimePaymentsTransferListPageResponse) { }
#pragma warning restore CS8618

    public InboundRealTimePaymentsTransferListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundRealTimePaymentsTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundRealTimePaymentsTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundRealTimePaymentsTransferListPageResponseFromRaw
    : IFromRawJson<InboundRealTimePaymentsTransferListPageResponse>
{
    /// <inheritdoc/>
    public InboundRealTimePaymentsTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundRealTimePaymentsTransferListPageResponse.FromRawUnchecked(rawData);
}
