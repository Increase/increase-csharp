using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Entities;

namespace Increase.Api.Services;

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
    /// Create an Entity
    /// </summary>
    Task<Entity> Create(
        EntityCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Entity
    /// </summary>
    Task<Entity> Retrieve(
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityRetrieveParams, CancellationToken)"/>
    Task<Entity> Retrieve(
        string entityID,
        EntityRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an Entity
    /// </summary>
    Task<Entity> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntityUpdateParams, CancellationToken)"/>
    Task<Entity> Update(
        string entityID,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Entities
    /// </summary>
    Task<EntityListPage> List(
        EntityListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive an Entity
    /// </summary>
    Task<Entity> Archive(
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(EntityArchiveParams, CancellationToken)"/>
    Task<Entity> Archive(
        string entityID,
        EntityArchiveParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /entities</c>, but is otherwise the
    /// same as <see cref="IEntityService.Create(EntityCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entity>> Create(
        EntityCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entities/{entity_id}</c>, but is otherwise the
    /// same as <see cref="IEntityService.Retrieve(EntityRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entity>> Retrieve(
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Entity>> Retrieve(
        string entityID,
        EntityRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /entities/{entity_id}</c>, but is otherwise the
    /// same as <see cref="IEntityService.Update(EntityUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entity>> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntityUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Entity>> Update(
        string entityID,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entities</c>, but is otherwise the
    /// same as <see cref="IEntityService.List(EntityListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityListPage>> List(
        EntityListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entities/{entity_id}/archive</c>, but is otherwise the
    /// same as <see cref="IEntityService.Archive(EntityArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Entity>> Archive(
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(EntityArchiveParams, CancellationToken)"/>
    Task<HttpResponse<Entity>> Archive(
        string entityID,
        EntityArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
