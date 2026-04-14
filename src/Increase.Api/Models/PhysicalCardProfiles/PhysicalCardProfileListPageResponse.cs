using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.PhysicalCardProfiles;

/// <summary>
/// A list of Physical Card Profile objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PhysicalCardProfileListPageResponse,
        PhysicalCardProfileListPageResponseFromRaw
    >)
)]
public sealed record class PhysicalCardProfileListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<PhysicalCardProfile> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PhysicalCardProfile>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PhysicalCardProfile>>(
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

    public PhysicalCardProfileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardProfileListPageResponse(
        PhysicalCardProfileListPageResponse physicalCardProfileListPageResponse
    )
        : base(physicalCardProfileListPageResponse) { }
#pragma warning restore CS8618

    public PhysicalCardProfileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardProfileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhysicalCardProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardProfileListPageResponseFromRaw : IFromRawJson<PhysicalCardProfileListPageResponse>
{
    /// <inheritdoc/>
    public PhysicalCardProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCardProfileListPageResponse.FromRawUnchecked(rawData);
}
