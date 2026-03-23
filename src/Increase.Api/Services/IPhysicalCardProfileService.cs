using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhysicalCardProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhysicalCardProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhysicalCardProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Physical Card Profile
    /// </summary>
    Task<PhysicalCardProfile> Create(
        PhysicalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Card Profile
    /// </summary>
    Task<PhysicalCardProfile> Retrieve(
        PhysicalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PhysicalCardProfileRetrieveParams, CancellationToken)"/>
    Task<PhysicalCardProfile> Retrieve(
        string physicalCardProfileID,
        PhysicalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Physical Card Profiles
    /// </summary>
    Task<PhysicalCardProfileListPage> List(
        PhysicalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a Physical Card Profile
    /// </summary>
    Task<PhysicalCardProfile> Archive(
        PhysicalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(PhysicalCardProfileArchiveParams, CancellationToken)"/>
    Task<PhysicalCardProfile> Archive(
        string physicalCardProfileID,
        PhysicalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Clone a Physical Card Profile
    /// </summary>
    Task<PhysicalCardProfile> Clone(
        PhysicalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Clone(PhysicalCardProfileCloneParams, CancellationToken)"/>
    Task<PhysicalCardProfile> Clone(
        string physicalCardProfileID,
        PhysicalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPhysicalCardProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhysicalCardProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhysicalCardProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /physical_card_profiles</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardProfileService.Create(PhysicalCardProfileCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCardProfile>> Create(
        PhysicalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /physical_card_profiles/{physical_card_profile_id}</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardProfileService.Retrieve(PhysicalCardProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCardProfile>> Retrieve(
        PhysicalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PhysicalCardProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCardProfile>> Retrieve(
        string physicalCardProfileID,
        PhysicalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /physical_card_profiles</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardProfileService.List(PhysicalCardProfileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCardProfileListPage>> List(
        PhysicalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /physical_card_profiles/{physical_card_profile_id}/archive</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardProfileService.Archive(PhysicalCardProfileArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCardProfile>> Archive(
        PhysicalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(PhysicalCardProfileArchiveParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCardProfile>> Archive(
        string physicalCardProfileID,
        PhysicalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /physical_card_profiles/{physical_card_profile_id}/clone</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardProfileService.Clone(PhysicalCardProfileCloneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCardProfile>> Clone(
        PhysicalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Clone(PhysicalCardProfileCloneParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCardProfile>> Clone(
        string physicalCardProfileID,
        PhysicalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
