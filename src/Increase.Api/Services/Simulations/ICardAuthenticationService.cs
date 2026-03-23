using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardAuthentications;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardAuthenticationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardAuthenticationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardAuthenticationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates a Card Authentication attempt on a [Card](#cards). The attempt always
    /// results in a [Card Payment](#card_payments) being created, either with a status
    /// that allows further action or a terminal failed status.
    /// </summary>
    Task<CardPayment> Create(
        CardAuthenticationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates an attempt at a Card Authentication Challenge. This updates the
    /// `card_authentications` object under the [Card Payment](#card_payments). You can
    /// also attempt the challenge by navigating to
    /// https://dashboard.increase.com/card_authentication_simulation/:card_payment_id.
    /// </summary>
    Task<CardPayment> ChallengeAttempts(
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChallengeAttempts(CardAuthenticationChallengeAttemptsParams, CancellationToken)"/>
    Task<CardPayment> ChallengeAttempts(
        string cardPaymentID,
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates starting a Card Authentication Challenge for an existing Card
    /// Authentication. This updates the `card_authentications` object under the [Card
    /// Payment](#card_payments). To attempt the challenge, use the
    /// `/simulations/card_authentications/:card_payment_id/challenge_attempts` endpoint
    /// or navigate to
    /// https://dashboard.increase.com/card_authentication_simulation/:card_payment_id.
    /// </summary>
    Task<CardPayment> Challenges(
        CardAuthenticationChallengesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Challenges(CardAuthenticationChallengesParams, CancellationToken)"/>
    Task<CardPayment> Challenges(
        string cardPaymentID,
        CardAuthenticationChallengesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardAuthenticationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardAuthenticationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardAuthenticationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_authentications</c>, but is otherwise the
    /// same as <see cref="ICardAuthenticationService.Create(CardAuthenticationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> Create(
        CardAuthenticationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_authentications/{card_payment_id}/challenge_attempts</c>, but is otherwise the
    /// same as <see cref="ICardAuthenticationService.ChallengeAttempts(CardAuthenticationChallengeAttemptsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> ChallengeAttempts(
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChallengeAttempts(CardAuthenticationChallengeAttemptsParams, CancellationToken)"/>
    Task<HttpResponse<CardPayment>> ChallengeAttempts(
        string cardPaymentID,
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_authentications/{card_payment_id}/challenges</c>, but is otherwise the
    /// same as <see cref="ICardAuthenticationService.Challenges(CardAuthenticationChallengesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> Challenges(
        CardAuthenticationChallengesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Challenges(CardAuthenticationChallengesParams, CancellationToken)"/>
    Task<HttpResponse<CardPayment>> Challenges(
        string cardPaymentID,
        CardAuthenticationChallengesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
