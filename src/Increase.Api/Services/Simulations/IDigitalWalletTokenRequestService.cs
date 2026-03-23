using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.DigitalWalletTokenRequests;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDigitalWalletTokenRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDigitalWalletTokenRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigitalWalletTokenRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates a user attempting to add a [Card](#cards) to a digital wallet such as
    /// Apple Pay.
    /// </summary>
    Task<DigitalWalletTokenRequestCreateResponse> Create(
        DigitalWalletTokenRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDigitalWalletTokenRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDigitalWalletTokenRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigitalWalletTokenRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/digital_wallet_token_requests</c>, but is otherwise the
    /// same as <see cref="IDigitalWalletTokenRequestService.Create(DigitalWalletTokenRequestCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalWalletTokenRequestCreateResponse>> Create(
        DigitalWalletTokenRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
