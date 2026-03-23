using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardRefunds;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardRefundService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardRefundServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardRefundService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates refunding a card transaction. The full value of the original sandbox
    /// transaction is refunded.
    /// </summary>
    Task<Transaction> Create(
        CardRefundCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardRefundService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardRefundServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardRefundServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_refunds</c>, but is otherwise the
    /// same as <see cref="ICardRefundService.Create(CardRefundCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Transaction>> Create(
        CardRefundCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
