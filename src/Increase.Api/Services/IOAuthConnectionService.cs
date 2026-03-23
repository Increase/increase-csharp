using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.OAuthConnections;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOAuthConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOAuthConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthConnectionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an OAuth Connection
    /// </summary>
    Task<OAuthConnection> Retrieve(
        OAuthConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OAuthConnectionRetrieveParams, CancellationToken)"/>
    Task<OAuthConnection> Retrieve(
        string oauthConnectionID,
        OAuthConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List OAuth Connections
    /// </summary>
    Task<OAuthConnectionListPage> List(
        OAuthConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOAuthConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOAuthConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthConnectionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /oauth_connections/{oauth_connection_id}</c>, but is otherwise the
    /// same as <see cref="IOAuthConnectionService.Retrieve(OAuthConnectionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OAuthConnection>> Retrieve(
        OAuthConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OAuthConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OAuthConnection>> Retrieve(
        string oauthConnectionID,
        OAuthConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /oauth_connections</c>, but is otherwise the
    /// same as <see cref="IOAuthConnectionService.List(OAuthConnectionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OAuthConnectionListPage>> List(
        OAuthConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
