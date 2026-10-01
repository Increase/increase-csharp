using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundRealTimePaymentsRequestsForPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundRealTimePaymentsRequestsForPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Retrieve an Inbound Real-Time Payments Request for Payment
    /// </summary>
    Task<InboundRealTimePaymentsRequestForPayment> Retrieve(
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundRealTimePaymentsRequestsForPaymentRetrieveParams, CancellationToken)"/>
    Task<InboundRealTimePaymentsRequestForPayment> Retrieve(
        string inboundRealTimePaymentsRequestForPaymentID,
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound Real-Time Payments Requests for Payment
    /// </summary>
    Task<InboundRealTimePaymentsRequestsForPaymentListPage> List(
        InboundRealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundRealTimePaymentsRequestsForPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_real_time_payments_requests_for_payment/{inbound_real_time_payments_request_for_payment_id}</c>, but is otherwise the
    /// same as <see cref="IInboundRealTimePaymentsRequestsForPaymentService.Retrieve(InboundRealTimePaymentsRequestsForPaymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundRealTimePaymentsRequestForPayment>> Retrieve(
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundRealTimePaymentsRequestsForPaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundRealTimePaymentsRequestForPayment>> Retrieve(
        string inboundRealTimePaymentsRequestForPaymentID,
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_real_time_payments_requests_for_payment</c>, but is otherwise the
    /// same as <see cref="IInboundRealTimePaymentsRequestsForPaymentService.List(InboundRealTimePaymentsRequestsForPaymentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundRealTimePaymentsRequestsForPaymentListPage>> List(
        InboundRealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
