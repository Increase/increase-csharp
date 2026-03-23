using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.SwiftTransfers;

/// <summary>
/// A list of Swift Transfer objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SwiftTransferListPageResponse, SwiftTransferListPageResponseFromRaw>)
)]
public sealed record class SwiftTransferListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<SwiftTransfer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SwiftTransfer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SwiftTransfer>>(
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

    public SwiftTransferListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwiftTransferListPageResponse(
        SwiftTransferListPageResponse swiftTransferListPageResponse
    )
        : base(swiftTransferListPageResponse) { }
#pragma warning restore CS8618

    public SwiftTransferListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwiftTransferListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwiftTransferListPageResponseFromRaw.FromRawUnchecked"/>
    public static SwiftTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwiftTransferListPageResponseFromRaw : IFromRawJson<SwiftTransferListPageResponse>
{
    /// <inheritdoc/>
    public SwiftTransferListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwiftTransferListPageResponse.FromRawUnchecked(rawData);
}
