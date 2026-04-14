using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.RoutingNumbers;

/// <summary>
/// A list of Routing Number objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RoutingNumberListPageResponse, RoutingNumberListPageResponseFromRaw>)
)]
public sealed record class RoutingNumberListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<RoutingNumberListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RoutingNumberListResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<RoutingNumberListResponse>>(
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

    public RoutingNumberListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingNumberListPageResponse(
        RoutingNumberListPageResponse routingNumberListPageResponse
    )
        : base(routingNumberListPageResponse) { }
#pragma warning restore CS8618

    public RoutingNumberListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingNumberListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingNumberListPageResponseFromRaw.FromRawUnchecked"/>
    public static RoutingNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingNumberListPageResponseFromRaw : IFromRawJson<RoutingNumberListPageResponse>
{
    /// <inheritdoc/>
    public RoutingNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingNumberListPageResponse.FromRawUnchecked(rawData);
}
