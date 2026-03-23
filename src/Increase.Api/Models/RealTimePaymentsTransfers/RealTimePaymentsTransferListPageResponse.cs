using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.RealTimePaymentsTransfers;

/// <summary>
/// A list of Real-Time Payments Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsTransferListPageResponse,
        RealTimePaymentsTransferListPageResponseFromRaw
    >)
)]
public sealed record class RealTimePaymentsTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<RealTimePaymentsTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RealTimePaymentsTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RealTimePaymentsTransfer>>(
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

    public RealTimePaymentsTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsTransferListPageResponse(
        RealTimePaymentsTransferListPageResponse realTimePaymentsTransferListPageResponse
    )
        : base(realTimePaymentsTransferListPageResponse) { }
#pragma warning restore CS8618

    public RealTimePaymentsTransferListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsTransferListPageResponseFromRaw
    : IFromRawJson<RealTimePaymentsTransferListPageResponse>
{
    /// <inheritdoc/>
    public RealTimePaymentsTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsTransferListPageResponse.FromRawUnchecked(rawData);
}
