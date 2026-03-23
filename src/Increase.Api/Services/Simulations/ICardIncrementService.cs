using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardIncrements;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardIncrementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardIncrementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardIncrementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the increment of an authorization by a card acquirer. An authorization
    /// can be incremented multiple times.
    /// </summary>
    Task<CardPayment> Create(
        CardIncrementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardIncrementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardIncrementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardIncrementServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_increments</c>, but is otherwise the
    /// same as <see cref="ICardIncrementService.Create(CardIncrementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> Create(
        CardIncrementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
