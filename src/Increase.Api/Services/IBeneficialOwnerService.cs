using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBeneficialOwnerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBeneficialOwnerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBeneficialOwnerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Beneficial Owner
    /// </summary>
    Task<EntityBeneficialOwner> Create(
        BeneficialOwnerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Beneficial Owner
    /// </summary>
    Task<EntityBeneficialOwner> Retrieve(
        BeneficialOwnerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BeneficialOwnerRetrieveParams, CancellationToken)"/>
    Task<EntityBeneficialOwner> Retrieve(
        string entityBeneficialOwnerID,
        BeneficialOwnerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Beneficial Owner
    /// </summary>
    Task<EntityBeneficialOwner> Update(
        BeneficialOwnerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BeneficialOwnerUpdateParams, CancellationToken)"/>
    Task<EntityBeneficialOwner> Update(
        string entityBeneficialOwnerID,
        BeneficialOwnerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Beneficial Owners
    /// </summary>
    Task<BeneficialOwnerListPage> List(
        BeneficialOwnerListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a Beneficial Owner
    /// </summary>
    Task<EntityBeneficialOwner> Archive(
        BeneficialOwnerArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(BeneficialOwnerArchiveParams, CancellationToken)"/>
    Task<EntityBeneficialOwner> Archive(
        string entityBeneficialOwnerID,
        BeneficialOwnerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBeneficialOwnerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBeneficialOwnerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBeneficialOwnerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entity_beneficial_owners</c>, but is otherwise the
    /// same as <see cref="IBeneficialOwnerService.Create(BeneficialOwnerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityBeneficialOwner>> Create(
        BeneficialOwnerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entity_beneficial_owners/{entity_beneficial_owner_id}</c>, but is otherwise the
    /// same as <see cref="IBeneficialOwnerService.Retrieve(BeneficialOwnerRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityBeneficialOwner>> Retrieve(
        BeneficialOwnerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BeneficialOwnerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EntityBeneficialOwner>> Retrieve(
        string entityBeneficialOwnerID,
        BeneficialOwnerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /entity_beneficial_owners/{entity_beneficial_owner_id}</c>, but is otherwise the
    /// same as <see cref="IBeneficialOwnerService.Update(BeneficialOwnerUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityBeneficialOwner>> Update(
        BeneficialOwnerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BeneficialOwnerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EntityBeneficialOwner>> Update(
        string entityBeneficialOwnerID,
        BeneficialOwnerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entity_beneficial_owners</c>, but is otherwise the
    /// same as <see cref="IBeneficialOwnerService.List(BeneficialOwnerListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BeneficialOwnerListPage>> List(
        BeneficialOwnerListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entity_beneficial_owners/{entity_beneficial_owner_id}/archive</c>, but is otherwise the
    /// same as <see cref="IBeneficialOwnerService.Archive(BeneficialOwnerArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityBeneficialOwner>> Archive(
        BeneficialOwnerArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(BeneficialOwnerArchiveParams, CancellationToken)"/>
    Task<HttpResponse<EntityBeneficialOwner>> Archive(
        string entityBeneficialOwnerID,
        BeneficialOwnerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
