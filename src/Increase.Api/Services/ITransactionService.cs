using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransactionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Transaction
    /// </summary>
    Task<Transaction> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionRetrieveParams, CancellationToken)"/>
    Task<Transaction> Retrieve(
        string transactionID,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Transactions
    /// </summary>
    Task<TransactionListPage> List(
        TransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransactionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransactionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /transactions/{transaction_id}</c>, but is otherwise the
    /// same as <see cref="ITransactionService.Retrieve(TransactionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Transaction>> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Transaction>> Retrieve(
        string transactionID,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /transactions</c>, but is otherwise the
    /// same as <see cref="ITransactionService.List(TransactionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionListPage>> List(
        TransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
