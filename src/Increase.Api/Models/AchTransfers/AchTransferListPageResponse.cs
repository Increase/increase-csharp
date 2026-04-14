using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.AchTransfers;

/// <summary>
/// A list of ACH Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AchTransferListPageResponse, AchTransferListPageResponseFromRaw>)
)]
public sealed record class AchTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<AchTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AchTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AchTransfer>>(
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

    public AchTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AchTransferListPageResponse(AchTransferListPageResponse achTransferListPageResponse)
        : base(achTransferListPageResponse) { }
#pragma warning restore CS8618

    public AchTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AchTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AchTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static AchTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AchTransferListPageResponseFromRaw : IFromRawJson<AchTransferListPageResponse>
{
    /// <inheritdoc/>
    public AchTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AchTransferListPageResponse.FromRawUnchecked(rawData);
}
