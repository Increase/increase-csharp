using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardAuthorizations;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardAuthorizationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardAuthorizationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardAuthorizationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates a purchase authorization on a [Card](#cards). Depending on the balance
    /// available to the card and the `amount` submitted, the authorization activity
    /// will result in a [Pending Transaction](#pending-transactions) of type
    /// `card_authorization` or a [Declined Transaction](#declined-transactions) of type
    /// `card_decline`. You can pass either a Card id or a [Digital Wallet
    /// Token](#digital-wallet-tokens) id to simulate the two different ways purchases
    /// can be made.
    /// </summary>
    Task<CardAuthorizationCreateResponse> Create(
        CardAuthorizationCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardAuthorizationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardAuthorizationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardAuthorizationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_authorizations</c>, but is otherwise the
    /// same as <see cref="ICardAuthorizationService.Create(CardAuthorizationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardAuthorizationCreateResponse>> Create(
        CardAuthorizationCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
