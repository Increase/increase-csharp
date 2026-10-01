using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

/// <summary>
/// A list of Inbound Real-Time Payments Request for Payment objects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundRealTimePaymentsRequestsForPaymentListPageResponse,
        InboundRealTimePaymentsRequestsForPaymentListPageResponseFromRaw
    >)
)]
public sealed record class InboundRealTimePaymentsRequestsForPaymentListPageResponse : JsonModel
{
    /// <summary>
    /// The contents of the list.
    /// </summary>
    public required IReadOnlyList<InboundRealTimePaymentsRequestForPayment> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<InboundRealTimePaymentsRequestForPayment>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InboundRealTimePaymentsRequestForPayment>>(
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

    public InboundRealTimePaymentsRequestsForPaymentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsRequestsForPaymentListPageResponse(
        InboundRealTimePaymentsRequestsForPaymentListPageResponse inboundRealTimePaymentsRequestsForPaymentListPageResponse
    )
        : base(inboundRealTimePaymentsRequestsForPaymentListPageResponse) { }
#pragma warning restore CS8618

    public InboundRealTimePaymentsRequestsForPaymentListPageResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsRequestsForPaymentListPageResponse(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundRealTimePaymentsRequestsForPaymentListPageResponseFromRaw.FromRawUnchecked"/>
    public static InboundRealTimePaymentsRequestsForPaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundRealTimePaymentsRequestsForPaymentListPageResponseFromRaw
    : IFromRawJson<InboundRealTimePaymentsRequestsForPaymentListPageResponse>
{
    /// <inheritdoc/>
    public InboundRealTimePaymentsRequestsForPaymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundRealTimePaymentsRequestsForPaymentListPageResponse.FromRawUnchecked(rawData);
}
