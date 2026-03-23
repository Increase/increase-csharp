using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.RealTimePaymentsTransfers;
using Increase.Api.Models.Simulations.RealTimePaymentsTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates submission of a [Real-Time Payments
    /// Transfer](#real-time-payments-transfers) and handling the response from the
    /// destination financial institution. This transfer must first have a `status` of
    /// `pending_submission`.
    /// </summary>
    Task<RealTimePaymentsTransfer> Complete(
        RealTimePaymentsTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(RealTimePaymentsTransferCompleteParams, CancellationToken)"/>
    Task<RealTimePaymentsTransfer> Complete(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCompleteParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/real_time_payments_transfers/{real_time_payments_transfer_id}/complete</c>, but is otherwise the
    /// same as <see cref="IRealTimePaymentsTransferService.Complete(RealTimePaymentsTransferCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimePaymentsTransfer>> Complete(
        RealTimePaymentsTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(RealTimePaymentsTransferCompleteParams, CancellationToken)"/>
    Task<HttpResponse<RealTimePaymentsTransfer>> Complete(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
