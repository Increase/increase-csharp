using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CheckTransfers;

/// <summary>
/// A list of Check Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CheckTransferListPageResponse, CheckTransferListPageResponseFromRaw>)
)]
public sealed record class CheckTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CheckTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CheckTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckTransfer>>(
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

    public CheckTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferListPageResponse(
        CheckTransferListPageResponse checkTransferListPageResponse
    )
        : base(checkTransferListPageResponse) { }
#pragma warning restore CS8618

    public CheckTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static CheckTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckTransferListPageResponseFromRaw : IFromRawJson<CheckTransferListPageResponse>
{
    /// <inheritdoc/>
    public CheckTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckTransferListPageResponse.FromRawUnchecked(rawData);
}
