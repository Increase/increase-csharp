using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.PendingTransactions;
using Increase.Api.Models.Simulations.PendingTransactions;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPendingTransactionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPendingTransactionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPendingTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint simulates immediately releasing an Inbound Funds Hold, which might
    /// be created as a result of, for example, an ACH debit.
    /// </summary>
    Task<PendingTransaction> ReleaseInboundFundsHold(
        PendingTransactionReleaseInboundFundsHoldParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ReleaseInboundFundsHold(PendingTransactionReleaseInboundFundsHoldParams, CancellationToken)"/>
    Task<PendingTransaction> ReleaseInboundFundsHold(
        string pendingTransactionID,
        PendingTransactionReleaseInboundFundsHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPendingTransactionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPendingTransactionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPendingTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/pending_transactions/{pending_transaction_id}/release_inbound_funds_hold</c>, but is otherwise the
    /// same as <see cref="IPendingTransactionService.ReleaseInboundFundsHold(PendingTransactionReleaseInboundFundsHoldParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PendingTransaction>> ReleaseInboundFundsHold(
        PendingTransactionReleaseInboundFundsHoldParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ReleaseInboundFundsHold(PendingTransactionReleaseInboundFundsHoldParams, CancellationToken)"/>
    Task<HttpResponse<PendingTransaction>> ReleaseInboundFundsHold(
        string pendingTransactionID,
        PendingTransactionReleaseInboundFundsHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
