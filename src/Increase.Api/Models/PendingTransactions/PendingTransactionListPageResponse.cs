using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.PendingTransactions;

/// <summary>
/// A list of Pending Transaction objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PendingTransactionListPageResponse,
        PendingTransactionListPageResponseFromRaw
    >)
)]
public sealed record class PendingTransactionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<PendingTransaction> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PendingTransaction>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PendingTransaction>>(
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

    public PendingTransactionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PendingTransactionListPageResponse(
        PendingTransactionListPageResponse pendingTransactionListPageResponse
    )
        : base(pendingTransactionListPageResponse) { }
#pragma warning restore CS8618

    public PendingTransactionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PendingTransactionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PendingTransactionListPageResponseFromRaw.FromRawUnchecked"/>
    public static PendingTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PendingTransactionListPageResponseFromRaw : IFromRawJson<PendingTransactionListPageResponse>
{
    /// <inheritdoc/>
    public PendingTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PendingTransactionListPageResponse.FromRawUnchecked(rawData);
}
