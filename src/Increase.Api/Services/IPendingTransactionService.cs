using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Services;

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
    /// Creates a pending transaction on an account. This can be useful to hold funds
    /// for an external payment or known future transaction outside of Increase (only
    /// negative amounts are supported). The resulting Pending Transaction will have a
    /// `category` of `user_initiated_hold` and can be released via the API to unlock
    /// the held funds.
    /// </summary>
    Task<PendingTransaction> Create(
        PendingTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Pending Transaction
    /// </summary>
    Task<PendingTransaction> Retrieve(
        PendingTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PendingTransactionRetrieveParams, CancellationToken)"/>
    Task<PendingTransaction> Retrieve(
        string pendingTransactionID,
        PendingTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Pending Transactions
    /// </summary>
    Task<PendingTransactionListPage> List(
        PendingTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Release a Pending Transaction you had previously created. The Pending
    /// Transaction must have a `category` of `user_initiated_hold` and a `status` of
    /// `pending`. This will unlock the held funds and mark the Pending Transaction as
    /// complete.
    /// </summary>
    Task<PendingTransaction> Release(
        PendingTransactionReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(PendingTransactionReleaseParams, CancellationToken)"/>
    Task<PendingTransaction> Release(
        string pendingTransactionID,
        PendingTransactionReleaseParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /pending_transactions</c>, but is otherwise the
    /// same as <see cref="IPendingTransactionService.Create(PendingTransactionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PendingTransaction>> Create(
        PendingTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /pending_transactions/{pending_transaction_id}</c>, but is otherwise the
    /// same as <see cref="IPendingTransactionService.Retrieve(PendingTransactionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PendingTransaction>> Retrieve(
        PendingTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PendingTransactionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PendingTransaction>> Retrieve(
        string pendingTransactionID,
        PendingTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /pending_transactions</c>, but is otherwise the
    /// same as <see cref="IPendingTransactionService.List(PendingTransactionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PendingTransactionListPage>> List(
        PendingTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /pending_transactions/{pending_transaction_id}/release</c>, but is otherwise the
    /// same as <see cref="IPendingTransactionService.Release(PendingTransactionReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PendingTransaction>> Release(
        PendingTransactionReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(PendingTransactionReleaseParams, CancellationToken)"/>
    Task<HttpResponse<PendingTransaction>> Release(
        string pendingTransactionID,
        PendingTransactionReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
