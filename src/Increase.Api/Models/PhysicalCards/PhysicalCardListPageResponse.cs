using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.PhysicalCards;

/// <summary>
/// A list of Physical Card objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PhysicalCardListPageResponse, PhysicalCardListPageResponseFromRaw>)
)]
public sealed record class PhysicalCardListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<PhysicalCard> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PhysicalCard>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PhysicalCard>>(
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

    public PhysicalCardListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardListPageResponse(PhysicalCardListPageResponse physicalCardListPageResponse)
        : base(physicalCardListPageResponse) { }
#pragma warning restore CS8618

    public PhysicalCardListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhysicalCardListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardListPageResponseFromRaw : IFromRawJson<PhysicalCardListPageResponse>
{
    /// <inheritdoc/>
    public PhysicalCardListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCardListPageResponse.FromRawUnchecked(rawData);
}
