using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.DigitalCardProfiles;

/// <summary>
/// A list of Digital Card Profile objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalCardProfileListPageResponse,
        DigitalCardProfileListPageResponseFromRaw
    >)
)]
public sealed record class DigitalCardProfileListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<DigitalCardProfile> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DigitalCardProfile>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DigitalCardProfile>>(
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

    public DigitalCardProfileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileListPageResponse(
        DigitalCardProfileListPageResponse digitalCardProfileListPageResponse
    )
        : base(digitalCardProfileListPageResponse) { }
#pragma warning restore CS8618

    public DigitalCardProfileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalCardProfileListPageResponseFromRaw : IFromRawJson<DigitalCardProfileListPageResponse>
{
    /// <inheritdoc/>
    public DigitalCardProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalCardProfileListPageResponse.FromRawUnchecked(rawData);
}
