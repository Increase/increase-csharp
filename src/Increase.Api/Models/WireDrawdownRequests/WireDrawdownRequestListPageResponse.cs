using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.WireDrawdownRequests;

/// <summary>
/// A list of Wire Drawdown Request objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WireDrawdownRequestListPageResponse,
        WireDrawdownRequestListPageResponseFromRaw
    >)
)]
public sealed record class WireDrawdownRequestListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<WireDrawdownRequest> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WireDrawdownRequest>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WireDrawdownRequest>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A pointer to a place in the list.
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

    public WireDrawdownRequestListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequestListPageResponse(
        WireDrawdownRequestListPageResponse wireDrawdownRequestListPageResponse
    )
        : base(wireDrawdownRequestListPageResponse) { }
#pragma warning restore CS8618

    public WireDrawdownRequestListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireDrawdownRequestListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireDrawdownRequestListPageResponseFromRaw.FromRawUnchecked"/>
    public static WireDrawdownRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireDrawdownRequestListPageResponseFromRaw : IFromRawJson<WireDrawdownRequestListPageResponse>
{
    /// <inheritdoc/>
    public WireDrawdownRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireDrawdownRequestListPageResponse.FromRawUnchecked(rawData);
}
