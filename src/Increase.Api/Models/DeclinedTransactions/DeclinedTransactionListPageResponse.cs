using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.DeclinedTransactions;

/// <summary>
/// A list of Declined Transaction objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DeclinedTransactionListPageResponse,
        DeclinedTransactionListPageResponseFromRaw
    >)
)]
public sealed record class DeclinedTransactionListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<DeclinedTransaction> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DeclinedTransaction>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeclinedTransaction>>(
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

    public DeclinedTransactionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeclinedTransactionListPageResponse(
        DeclinedTransactionListPageResponse declinedTransactionListPageResponse
    )
        : base(declinedTransactionListPageResponse) { }
#pragma warning restore CS8618

    public DeclinedTransactionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeclinedTransactionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeclinedTransactionListPageResponseFromRaw.FromRawUnchecked"/>
    public static DeclinedTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeclinedTransactionListPageResponseFromRaw : IFromRawJson<DeclinedTransactionListPageResponse>
{
    /// <inheritdoc/>
    public DeclinedTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeclinedTransactionListPageResponse.FromRawUnchecked(rawData);
}
