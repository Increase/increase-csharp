using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Checkbooks;

/// <summary>
/// A list of Checkbook objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CheckbookListPageResponse, CheckbookListPageResponseFromRaw>)
)]
public sealed record class CheckbookListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Checkbook> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Checkbook>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Checkbook>>(
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

    public CheckbookListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckbookListPageResponse(CheckbookListPageResponse checkbookListPageResponse)
        : base(checkbookListPageResponse) { }
#pragma warning restore CS8618

    public CheckbookListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckbookListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckbookListPageResponseFromRaw.FromRawUnchecked"/>
    public static CheckbookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckbookListPageResponseFromRaw : IFromRawJson<CheckbookListPageResponse>
{
    /// <inheritdoc/>
    public CheckbookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CheckbookListPageResponse.FromRawUnchecked(rawData);
}
