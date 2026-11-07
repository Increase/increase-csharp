using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CheckbookChecks;

/// <summary>
/// A list of Checkbook Check objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CheckbookCheckListPageResponse,
        CheckbookCheckListPageResponseFromRaw
    >)
)]
public sealed record class CheckbookCheckListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CheckbookCheck> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CheckbookCheck>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CheckbookCheck>>(
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

    public CheckbookCheckListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckbookCheckListPageResponse(
        CheckbookCheckListPageResponse checkbookCheckListPageResponse
    )
        : base(checkbookCheckListPageResponse) { }
#pragma warning restore CS8618

    public CheckbookCheckListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckbookCheckListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckbookCheckListPageResponseFromRaw.FromRawUnchecked"/>
    public static CheckbookCheckListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckbookCheckListPageResponseFromRaw : IFromRawJson<CheckbookCheckListPageResponse>
{
    /// <inheritdoc/>
    public CheckbookCheckListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckbookCheckListPageResponse.FromRawUnchecked(rawData);
}
