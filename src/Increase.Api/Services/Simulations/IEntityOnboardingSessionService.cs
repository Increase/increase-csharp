using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.EntityOnboardingSessions;
using Increase.Api.Models.Simulations.EntityOnboardingSessions;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntityOnboardingSessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntityOnboardingSessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityOnboardingSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the submission of an [Entity Onboarding
    /// Session](#entity-onboarding-sessions). This session must have a `status` of
    /// `active`. After submission, the session will transition to `expired` and a new
    /// Entity will be created.
    /// </summary>
    Task<EntityOnboardingSession> Submit(
        EntityOnboardingSessionSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(EntityOnboardingSessionSubmitParams, CancellationToken)"/>
    Task<EntityOnboardingSession> Submit(
        string entityOnboardingSessionID,
        EntityOnboardingSessionSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntityOnboardingSessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntityOnboardingSessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityOnboardingSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/entity_onboarding_sessions/{entity_onboarding_session_id}/submit</c>, but is otherwise the
    /// same as <see cref="IEntityOnboardingSessionService.Submit(EntityOnboardingSessionSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityOnboardingSession>> Submit(
        EntityOnboardingSessionSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(EntityOnboardingSessionSubmitParams, CancellationToken)"/>
    Task<HttpResponse<EntityOnboardingSession>> Submit(
        string entityOnboardingSessionID,
        EntityOnboardingSessionSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
