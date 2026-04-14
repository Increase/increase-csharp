using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.WireTransfers;

/// <summary>
/// A list of Wire Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WireTransferListPageResponse, WireTransferListPageResponseFromRaw>)
)]
public sealed record class WireTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<WireTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WireTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WireTransfer>>(
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

    public WireTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireTransferListPageResponse(WireTransferListPageResponse wireTransferListPageResponse)
        : base(wireTransferListPageResponse) { }
#pragma warning restore CS8618

    public WireTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static WireTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireTransferListPageResponseFromRaw : IFromRawJson<WireTransferListPageResponse>
{
    /// <inheritdoc/>
    public WireTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireTransferListPageResponse.FromRawUnchecked(rawData);
}
