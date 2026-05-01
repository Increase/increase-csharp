using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Entities;
using Increase.Api.Models.Simulations.Entities;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntityService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntityServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Set the status for an [Entity's
    /// validation](/documentation/api/entities#entity-object.validation). In
    /// production, Know Your Customer validations [run
    /// automatically](/documentation/entity-validation#entity-validation). While
    /// developing, it can be helpful to override the behavior in Sandbox.
    /// </summary>
    Task<Entity> Validation(
        EntityValidationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Validation(EntityValidationParams, CancellationToken)"/>
    Task<Entity> Validation(
        string entityID,
        EntityValidationParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntityService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntityServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/entities/{entity_id}/validation</c>, but is otherwise the
    /// same as <see cref="IEntityService.Validation(EntityValidationParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entity>> Validation(
        EntityValidationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Validation(EntityValidationParams, CancellationToken)"/>
    Task<HttpResponse<Entity>> Validation(
        string entityID,
        EntityValidationParams parameters,
        CancellationToken cancellationToken = default
    );
}
