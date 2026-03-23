using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.IntrafiBalances;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntrafiBalanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntrafiBalanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrafiBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the IntraFi balance for the given account. IntraFi may sweep funds to
    /// multiple banks. This endpoint will include both the total balance and the amount
    /// swept to each institution.
    /// </summary>
    Task<IntrafiBalance> IntrafiBalance(
        IntrafiBalanceIntrafiBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="IntrafiBalance(IntrafiBalanceIntrafiBalanceParams, CancellationToken)"/>
    Task<IntrafiBalance> IntrafiBalance(
        string accountID,
        IntrafiBalanceIntrafiBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIntrafiBalanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntrafiBalanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrafiBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /accounts/{account_id}/intrafi_balance</c>, but is otherwise the
    /// same as <see cref="IIntrafiBalanceService.IntrafiBalance(IntrafiBalanceIntrafiBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiBalance>> IntrafiBalance(
        IntrafiBalanceIntrafiBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="IntrafiBalance(IntrafiBalanceIntrafiBalanceParams, CancellationToken)"/>
    Task<HttpResponse<IntrafiBalance>> IntrafiBalance(
        string accountID,
        IntrafiBalanceIntrafiBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
