using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.CardPayments;

/// <summary>
/// A list of Card Payment objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CardPaymentListPageResponse, CardPaymentListPageResponseFromRaw>)
)]
public sealed record class CardPaymentListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<CardPayment> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CardPayment>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CardPayment>>(
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

    public CardPaymentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPaymentListPageResponse(CardPaymentListPageResponse cardPaymentListPageResponse)
        : base(cardPaymentListPageResponse) { }
#pragma warning restore CS8618

    public CardPaymentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPaymentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPaymentListPageResponseFromRaw.FromRawUnchecked"/>
    public static CardPaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPaymentListPageResponseFromRaw : IFromRawJson<CardPaymentListPageResponse>
{
    /// <inheritdoc/>
    public CardPaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPaymentListPageResponse.FromRawUnchecked(rawData);
}
