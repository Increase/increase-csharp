using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.Transactions;

/// <summary>
/// A list of Transaction objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TransactionListPageResponse, TransactionListPageResponseFromRaw>)
)]
public sealed record class TransactionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<Transaction> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Transaction>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Transaction>>(
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

    public TransactionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionListPageResponse(TransactionListPageResponse transactionListPageResponse)
        : base(transactionListPageResponse) { }
#pragma warning restore CS8618

    public TransactionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionListPageResponseFromRaw.FromRawUnchecked"/>
    public static TransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionListPageResponseFromRaw : IFromRawJson<TransactionListPageResponse>
{
    /// <inheritdoc/>
    public TransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionListPageResponse.FromRawUnchecked(rawData);
}
