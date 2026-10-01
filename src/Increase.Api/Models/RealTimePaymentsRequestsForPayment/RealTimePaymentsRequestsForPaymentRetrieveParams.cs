using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.RealTimePaymentsRequestsForPayment;

/// <summary>
/// Retrieve a Real-Time Payments Request for Payment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RealTimePaymentsRequestsForPaymentRetrieveParams : ParamsBase
{
    public string? RealTimePaymentsRequestForPaymentID { get; init; }

    public RealTimePaymentsRequestsForPaymentRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestsForPaymentRetrieveParams(
        RealTimePaymentsRequestsForPaymentRetrieveParams realTimePaymentsRequestsForPaymentRetrieveParams
    )
        : base(realTimePaymentsRequestsForPaymentRetrieveParams)
    {
        this.RealTimePaymentsRequestForPaymentID =
            realTimePaymentsRequestsForPaymentRetrieveParams.RealTimePaymentsRequestForPaymentID;
    }
#pragma warning restore CS8618

    public RealTimePaymentsRequestsForPaymentRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsRequestsForPaymentRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string realTimePaymentsRequestForPaymentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RealTimePaymentsRequestForPaymentID = realTimePaymentsRequestForPaymentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RealTimePaymentsRequestsForPaymentRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string realTimePaymentsRequestForPaymentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            realTimePaymentsRequestForPaymentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RealTimePaymentsRequestForPaymentID"] = JsonSerializer.SerializeToElement(
                        this.RealTimePaymentsRequestForPaymentID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(RealTimePaymentsRequestsForPaymentRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.RealTimePaymentsRequestForPaymentID?.Equals(
                    other.RealTimePaymentsRequestForPaymentID
                )
                ?? other.RealTimePaymentsRequestForPaymentID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/real_time_payments_requests_for_payment/{0}",
                    this.RealTimePaymentsRequestForPaymentID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
