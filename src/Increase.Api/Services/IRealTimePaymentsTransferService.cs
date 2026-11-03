using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRealTimePaymentsTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRealTimePaymentsTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRealTimePaymentsTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Real-Time Payments Transfer
    /// </summary>
    Task<RealTimePaymentsTransfer> Create(
        RealTimePaymentsTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Real-Time Payments Transfer
    /// </summary>
    Task<RealTimePaymentsTransfer> Retrieve(
        RealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RealTimePaymentsTransferRetrieveParams, CancellationToken)"/>
    Task<RealTimePaymentsTransfer> Retrieve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Real-Time Payments Transfers
    /// </summary>
    Task<RealTimePaymentsTransferListPage> List(
        RealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approves a Real-Time Payments Transfer in a pending_approval state.
    /// </summary>
    Task<RealTimePaymentsTransfer> Approve(
        RealTimePaymentsTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(RealTimePaymentsTransferApproveParams, CancellationToken)"/>
    Task<RealTimePaymentsTransfer> Approve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a Real-Time Payments Transfer in a pending_approval state.
    /// </summary>
    Task<RealTimePaymentsTransfer> Cancel(
        RealTimePaymentsTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(RealTimePaymentsTransferCancelParams, CancellationToken)"/>
    Task<RealTimePaymentsTransfer> Cancel(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRealTimePaymentsTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRealTimePaymentsTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRealTimePaymentsTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /real_time_payments_transfers</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsTransferService.Create(RealTimePaymentsTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsTransfer>> Create(
        RealTimePaymentsTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /real_time_payments_transfers/{real_time_payments_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsTransferService.Retrieve(RealTimePaymentsTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsTransfer>> Retrieve(
        RealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RealTimePaymentsTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RealTimePaymentsTransfer>> Retrieve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /real_time_payments_transfers</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsTransferService.List(RealTimePaymentsTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsTransferListPage>> List(
        RealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /real_time_payments_transfers/{real_time_payments_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsTransferService.Approve(RealTimePaymentsTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsTransfer>> Approve(
        RealTimePaymentsTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(RealTimePaymentsTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<RealTimePaymentsTransfer>> Approve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /real_time_payments_transfers/{real_time_payments_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsTransferService.Cancel(RealTimePaymentsTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsTransfer>> Cancel(
        RealTimePaymentsTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(RealTimePaymentsTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<RealTimePaymentsTransfer>> Cancel(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
