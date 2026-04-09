using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Services;

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
    /// Create an Entity Onboarding Session
    /// </summary>
    Task<EntityOnboardingSession> Create(
        EntityOnboardingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Entity Onboarding Session
    /// </summary>
    Task<EntityOnboardingSession> Retrieve(
        EntityOnboardingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityOnboardingSessionRetrieveParams, CancellationToken)"/>
    Task<EntityOnboardingSession> Retrieve(
        string entityOnboardingSessionID,
        EntityOnboardingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Entity Onboarding Session
    /// </summary>
    Task<EntityOnboardingSessionListPage> List(
        EntityOnboardingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Expire an Entity Onboarding Session
    /// </summary>
    Task<EntityOnboardingSession> Expire(
        EntityOnboardingSessionExpireParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Expire(EntityOnboardingSessionExpireParams, CancellationToken)"/>
    Task<EntityOnboardingSession> Expire(
        string entityOnboardingSessionID,
        EntityOnboardingSessionExpireParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /entity_onboarding_sessions</c>, but is otherwise the
    /// same as <see cref="IEntityOnboardingSessionService.Create(EntityOnboardingSessionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityOnboardingSession>> Create(
        EntityOnboardingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entity_onboarding_sessions/{entity_onboarding_session_id}</c>, but is otherwise the
    /// same as <see cref="IEntityOnboardingSessionService.Retrieve(EntityOnboardingSessionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityOnboardingSession>> Retrieve(
        EntityOnboardingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityOnboardingSessionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EntityOnboardingSession>> Retrieve(
        string entityOnboardingSessionID,
        EntityOnboardingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entity_onboarding_sessions</c>, but is otherwise the
    /// same as <see cref="IEntityOnboardingSessionService.List(EntityOnboardingSessionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityOnboardingSessionListPage>> List(
        EntityOnboardingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entity_onboarding_sessions/{entity_onboarding_session_id}/expire</c>, but is otherwise the
    /// same as <see cref="IEntityOnboardingSessionService.Expire(EntityOnboardingSessionExpireParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityOnboardingSession>> Expire(
        EntityOnboardingSessionExpireParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Expire(EntityOnboardingSessionExpireParams, CancellationToken)"/>
    Task<HttpResponse<EntityOnboardingSession>> Expire(
        string entityOnboardingSessionID,
        EntityOnboardingSessionExpireParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
