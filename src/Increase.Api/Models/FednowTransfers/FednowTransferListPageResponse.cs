using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.FednowTransfers;

/// <summary>
/// A list of FedNow Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FednowTransferListPageResponse,
        FednowTransferListPageResponseFromRaw
    >)
)]
public sealed record class FednowTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<FednowTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FednowTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FednowTransfer>>(
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

    public FednowTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FednowTransferListPageResponse(
        FednowTransferListPageResponse fednowTransferListPageResponse
    )
        : base(fednowTransferListPageResponse) { }
#pragma warning restore CS8618

    public FednowTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FednowTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FednowTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static FednowTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FednowTransferListPageResponseFromRaw : IFromRawJson<FednowTransferListPageResponse>
{
    /// <inheritdoc/>
    public FednowTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FednowTransferListPageResponse.FromRawUnchecked(rawData);
}
