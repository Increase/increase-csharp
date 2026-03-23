using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.InterestPayments;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInterestPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInterestPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInterestPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates an interest payment to your account. In production, this happens
    /// automatically on the first of each month.
    /// </summary>
    Task<Transaction> Create(
        InterestPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInterestPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInterestPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInterestPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/interest_payments</c>, but is otherwise the
    /// same as <see cref="IInterestPaymentService.Create(InterestPaymentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Transaction>> Create(
        InterestPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
