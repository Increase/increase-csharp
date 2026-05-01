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
    /// Simulate updates to an [Entity's
    /// validation](/documentation/api/entities#entity-object.validation). In
    /// production, Know Your Customer validations [run
    /// automatically](/documentation/entity-validation#entity-validation) for eligible
    /// programs. While developing, use this API to simulate issues with information
    /// submissions.
    /// </summary>
    Task<Entity> UpdateValidation(
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateValidation(EntityUpdateValidationParams, CancellationToken)"/>
    Task<Entity> UpdateValidation(
        string entityID,
        EntityUpdateValidationParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/entities/{entity_id}/update_validation</c>, but is otherwise the
    /// same as <see cref="IEntityService.UpdateValidation(EntityUpdateValidationParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entity>> UpdateValidation(
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateValidation(EntityUpdateValidationParams, CancellationToken)"/>
    Task<HttpResponse<Entity>> UpdateValidation(
        string entityID,
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    );
}
