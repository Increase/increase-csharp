using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.AccountRevenuePayments;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountRevenuePaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountRevenuePaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountRevenuePaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates an account revenue payment to your account. In production, this
    /// happens automatically on the first of each month.
    /// </summary>
    Task<Transaction> Create(
        AccountRevenuePaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountRevenuePaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountRevenuePaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountRevenuePaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/account_revenue_payments</c>, but is otherwise the
    /// same as <see cref="IAccountRevenuePaymentService.Create(AccountRevenuePaymentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Transaction>> Create(
        AccountRevenuePaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
