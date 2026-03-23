using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundWireDrawdownRequests;

/// <summary>
/// A list of Inbound Wire Drawdown Request objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundWireDrawdownRequestListPageResponse,
        InboundWireDrawdownRequestListPageResponseFromRaw
    >)
)]
public sealed record class InboundWireDrawdownRequestListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundWireDrawdownRequest> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundWireDrawdownRequest>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundWireDrawdownRequest>>(
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

    public InboundWireDrawdownRequestListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundWireDrawdownRequestListPageResponse(
        InboundWireDrawdownRequestListPageResponse inboundWireDrawdownRequestListPageResponse
    )
        : base(inboundWireDrawdownRequestListPageResponse) { }
#pragma warning restore CS8618

    public InboundWireDrawdownRequestListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundWireDrawdownRequestListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundWireDrawdownRequestListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundWireDrawdownRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundWireDrawdownRequestListPageResponseFromRaw
    : IFromRawJson<InboundWireDrawdownRequestListPageResponse>
{
    /// <inheritdoc/>
    public InboundWireDrawdownRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundWireDrawdownRequestListPageResponse.FromRawUnchecked(rawData);
}
