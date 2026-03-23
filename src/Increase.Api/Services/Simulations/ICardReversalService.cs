using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardReversals;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardReversalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardReversalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardReversalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the reversal of an authorization by a card acquirer. An authorization
    /// can be partially reversed multiple times, up until the total authorized amount.
    /// Marks the pending transaction as complete if the authorization is fully
    /// reversed.
    /// </summary>
    Task<CardPayment> Create(
        CardReversalCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardReversalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardReversalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardReversalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_reversals</c>, but is otherwise the
    /// same as <see cref="ICardReversalService.Create(CardReversalCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> Create(
        CardReversalCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
