using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.DigitalWalletTokens;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDigitalWalletTokenService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDigitalWalletTokenServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigitalWalletTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Digital Wallet Token
    /// </summary>
    Task<DigitalWalletToken> Retrieve(
        DigitalWalletTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DigitalWalletTokenRetrieveParams, CancellationToken)"/>
    Task<DigitalWalletToken> Retrieve(
        string digitalWalletTokenID,
        DigitalWalletTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Digital Wallet Tokens
    /// </summary>
    Task<DigitalWalletTokenListPage> List(
        DigitalWalletTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDigitalWalletTokenService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDigitalWalletTokenServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigitalWalletTokenServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /digital_wallet_tokens/{digital_wallet_token_id}</c>, but is otherwise the
    /// same as <see cref="IDigitalWalletTokenService.Retrieve(DigitalWalletTokenRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalWalletToken>> Retrieve(
        DigitalWalletTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DigitalWalletTokenRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DigitalWalletToken>> Retrieve(
        string digitalWalletTokenID,
        DigitalWalletTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /digital_wallet_tokens</c>, but is otherwise the
    /// same as <see cref="IDigitalWalletTokenService.List(DigitalWalletTokenListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigitalWalletTokenListPage>> List(
        DigitalWalletTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
