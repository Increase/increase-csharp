using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRealTimePaymentsRequestsForPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRealTimePaymentsRequestsForPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Create a Real-Time Payments Request for Payment
    /// </summary>
    Task<RealTimePaymentsRequestForPayment> Create(
        RealTimePaymentsRequestsForPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Real-Time Payments Request for Payment
    /// </summary>
    Task<RealTimePaymentsRequestForPayment> Retrieve(
        RealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RealTimePaymentsRequestsForPaymentRetrieveParams, CancellationToken)"/>
    Task<RealTimePaymentsRequestForPayment> Retrieve(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Real-Time Payments Requests for Payment
    /// </summary>
    Task<RealTimePaymentsRequestsForPaymentListPage> List(
        RealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a Real-Time Payments Request for Payment that is still awaiting payment.
    /// </summary>
    Task<RealTimePaymentsRequestForPayment> Cancel(
        RealTimePaymentsRequestsForPaymentCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(RealTimePaymentsRequestsForPaymentCancelParams, CancellationToken)"/>
    Task<RealTimePaymentsRequestForPayment> Cancel(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRealTimePaymentsRequestsForPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRealTimePaymentsRequestsForPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /real_time_payments_requests_for_payment</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsRequestsForPaymentService.Create(RealTimePaymentsRequestsForPaymentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsRequestForPayment>> Create(
        RealTimePaymentsRequestsForPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /real_time_payments_requests_for_payment/{real_time_payments_request_for_payment_id}</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsRequestsForPaymentService.Retrieve(RealTimePaymentsRequestsForPaymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsRequestForPayment>> Retrieve(
        RealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RealTimePaymentsRequestsForPaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RealTimePaymentsRequestForPayment>> Retrieve(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /real_time_payments_requests_for_payment</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsRequestsForPaymentService.List(RealTimePaymentsRequestsForPaymentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsRequestsForPaymentListPage>> List(
        RealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /real_time_payments_requests_for_payment/{real_time_payments_request_for_payment_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsRequestsForPaymentService.Cancel(RealTimePaymentsRequestsForPaymentCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsRequestForPayment>> Cancel(
        RealTimePaymentsRequestsForPaymentCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(RealTimePaymentsRequestsForPaymentCancelParams, CancellationToken)"/>
    Task<HttpResponse<RealTimePaymentsRequestForPayment>> Cancel(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
