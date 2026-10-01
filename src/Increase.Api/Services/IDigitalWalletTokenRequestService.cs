using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.DigitalWalletTokenRequests;

namespace Increase.Api.Services;

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
    /// Retrieve a Digital Wallet Token Request
    /// </summary>
    Task<DigitalWalletTokenRequest> Retrieve(
        DigitalWalletTokenRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DigitalWalletTokenRequestRetrieveParams, CancellationToken)"/>
    Task<DigitalWalletTokenRequest> Retrieve(
        string digitalWalletTokenRequestID,
        DigitalWalletTokenRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Digital Wallet Token Requests
    /// </summary>
    Task<DigitalWalletTokenRequestListPage> List(
        DigitalWalletTokenRequestListParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /digital_wallet_token_requests/{digital_wallet_token_request_id}</c>, but is otherwise the
    /// same as <see cref="IDigitalWalletTokenRequestService.Retrieve(DigitalWalletTokenRequestRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalWalletTokenRequest>> Retrieve(
        DigitalWalletTokenRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DigitalWalletTokenRequestRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DigitalWalletTokenRequest>> Retrieve(
        string digitalWalletTokenRequestID,
        DigitalWalletTokenRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /digital_wallet_token_requests</c>, but is otherwise the
    /// same as <see cref="IDigitalWalletTokenRequestService.List(DigitalWalletTokenRequestListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalWalletTokenRequestListPage>> List(
        DigitalWalletTokenRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
