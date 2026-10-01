using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.RealTimePaymentsRequestsForPayment;

/// <summary>
/// A list of Real-Time Payments Request for Payment objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsRequestsForPaymentListPageResponse,
        RealTimePaymentsRequestsForPaymentListPageResponseFromRaw
    >)
)]
public sealed record class RealTimePaymentsRequestsForPaymentListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<RealTimePaymentsRequestForPayment> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<RealTimePaymentsRequestForPayment>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RealTimePaymentsRequestForPayment>>(
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

    public RealTimePaymentsRequestsForPaymentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestsForPaymentListPageResponse(
        RealTimePaymentsRequestsForPaymentListPageResponse realTimePaymentsRequestsForPaymentListPageResponse
    )
        : base(realTimePaymentsRequestsForPaymentListPageResponse) { }
#pragma warning restore CS8618

    public RealTimePaymentsRequestsForPaymentListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsRequestsForPaymentListPageResponse(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsRequestsForPaymentListPageResponseFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsRequestsForPaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsRequestsForPaymentListPageResponseFromRaw
    : IFromRawJson<RealTimePaymentsRequestsForPaymentListPageResponse>
{
    /// <inheritdoc/>
    public RealTimePaymentsRequestsForPaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsRequestsForPaymentListPageResponse.FromRawUnchecked(rawData);
}
