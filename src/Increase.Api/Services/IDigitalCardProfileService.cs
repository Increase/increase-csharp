using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDigitalCardProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDigitalCardProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigitalCardProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Digital Card Profile
    /// </summary>
    Task<DigitalCardProfile> Create(
        DigitalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Digital Card Profile
    /// </summary>
    Task<DigitalCardProfile> Retrieve(
        DigitalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DigitalCardProfileRetrieveParams, CancellationToken)"/>
    Task<DigitalCardProfile> Retrieve(
        string digitalCardProfileID,
        DigitalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Profiles
    /// </summary>
    Task<DigitalCardProfileListPage> List(
        DigitalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a Digital Card Profile
    /// </summary>
    Task<DigitalCardProfile> Archive(
        DigitalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(DigitalCardProfileArchiveParams, CancellationToken)"/>
    Task<DigitalCardProfile> Archive(
        string digitalCardProfileID,
        DigitalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Clones a Digital Card Profile
    /// </summary>
    Task<DigitalCardProfile> Clone(
        DigitalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Clone(DigitalCardProfileCloneParams, CancellationToken)"/>
    Task<DigitalCardProfile> Clone(
        string digitalCardProfileID,
        DigitalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDigitalCardProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDigitalCardProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigitalCardProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /digital_card_profiles</c>, but is otherwise the
    /// same as <see cref="IDigitalCardProfileService.Create(DigitalCardProfileCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalCardProfile>> Create(
        DigitalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /digital_card_profiles/{digital_card_profile_id}</c>, but is otherwise the
    /// same as <see cref="IDigitalCardProfileService.Retrieve(DigitalCardProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalCardProfile>> Retrieve(
        DigitalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DigitalCardProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DigitalCardProfile>> Retrieve(
        string digitalCardProfileID,
        DigitalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /digital_card_profiles</c>, but is otherwise the
    /// same as <see cref="IDigitalCardProfileService.List(DigitalCardProfileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalCardProfileListPage>> List(
        DigitalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /digital_card_profiles/{digital_card_profile_id}/archive</c>, but is otherwise the
    /// same as <see cref="IDigitalCardProfileService.Archive(DigitalCardProfileArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalCardProfile>> Archive(
        DigitalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(DigitalCardProfileArchiveParams, CancellationToken)"/>
    Task<HttpResponse<DigitalCardProfile>> Archive(
        string digitalCardProfileID,
        DigitalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /digital_card_profiles/{digital_card_profile_id}/clone</c>, but is otherwise the
    /// same as <see cref="IDigitalCardProfileService.Clone(DigitalCardProfileCloneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalCardProfile>> Clone(
        DigitalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Clone(DigitalCardProfileCloneParams, CancellationToken)"/>
    Task<HttpResponse<DigitalCardProfile>> Clone(
        string digitalCardProfileID,
        DigitalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
