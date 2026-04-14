using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.IntrafiExclusions;

/// <summary>
/// A list of IntraFi Exclusion objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntrafiExclusionListPageResponse,
        IntrafiExclusionListPageResponseFromRaw
    >)
)]
public sealed record class IntrafiExclusionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<IntrafiExclusion> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<IntrafiExclusion>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<IntrafiExclusion>>(
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

    public IntrafiExclusionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrafiExclusionListPageResponse(
        IntrafiExclusionListPageResponse intrafiExclusionListPageResponse
    )
        : base(intrafiExclusionListPageResponse) { }
#pragma warning restore CS8618

    public IntrafiExclusionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrafiExclusionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrafiExclusionListPageResponseFromRaw.FromRawUnchecked"/>
    public static IntrafiExclusionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrafiExclusionListPageResponseFromRaw : IFromRawJson<IntrafiExclusionListPageResponse>
{
    /// <inheritdoc/>
    public IntrafiExclusionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntrafiExclusionListPageResponse.FromRawUnchecked(rawData);
}
