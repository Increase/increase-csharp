using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.DeclinedTransactions;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDeclinedTransactionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDeclinedTransactionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeclinedTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Declined Transaction
    /// </summary>
    Task<DeclinedTransaction> Retrieve(
        DeclinedTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeclinedTransactionRetrieveParams, CancellationToken)"/>
    Task<DeclinedTransaction> Retrieve(
        string declinedTransactionID,
        DeclinedTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Declined Transactions
    /// </summary>
    Task<DeclinedTransactionListPage> List(
        DeclinedTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDeclinedTransactionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDeclinedTransactionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeclinedTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /declined_transactions/{declined_transaction_id}</c>, but is otherwise the
    /// same as <see cref="IDeclinedTransactionService.Retrieve(DeclinedTransactionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeclinedTransaction>> Retrieve(
        DeclinedTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeclinedTransactionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DeclinedTransaction>> Retrieve(
        string declinedTransactionID,
        DeclinedTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /declined_transactions</c>, but is otherwise the
    /// same as <see cref="IDeclinedTransactionService.List(DeclinedTransactionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeclinedTransactionListPage>> List(
        DeclinedTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
