using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.OAuthTokens;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOAuthTokenService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOAuthTokenServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an OAuth Token
    /// </summary>
    Task<OAuthToken> Create(
        OAuthTokenCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOAuthTokenService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOAuthTokenServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOAuthTokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /oauth/tokens</c>, but is otherwise the
    /// same as <see cref="IOAuthTokenService.Create(OAuthTokenCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OAuthToken>> Create(
        OAuthTokenCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
