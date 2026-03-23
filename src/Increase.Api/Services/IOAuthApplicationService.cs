using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.OAuthApplications;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOAuthApplicationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOAuthApplicationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthApplicationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an OAuth Application
    /// </summary>
    Task<OAuthApplication> Retrieve(
        OAuthApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OAuthApplicationRetrieveParams, CancellationToken)"/>
    Task<OAuthApplication> Retrieve(
        string oauthApplicationID,
        OAuthApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List OAuth Applications
    /// </summary>
    Task<OAuthApplicationListPage> List(
        OAuthApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOAuthApplicationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOAuthApplicationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /oauth_applications/{oauth_application_id}</c>, but is otherwise the
    /// same as <see cref="IOAuthApplicationService.Retrieve(OAuthApplicationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OAuthApplication>> Retrieve(
        OAuthApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OAuthApplicationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OAuthApplication>> Retrieve(
        string oauthApplicationID,
        OAuthApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /oauth_applications</c>, but is otherwise the
    /// same as <see cref="IOAuthApplicationService.List(OAuthApplicationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OAuthApplicationListPage>> List(
        OAuthApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
