using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardTokens;
using Increase.Api.Models.Simulations.CardTokens;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardTokenService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardTokenServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates tokenizing a card in the sandbox environment.
    /// </summary>
    Task<CardToken> Create(
        CardTokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardTokenService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardTokenServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardTokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_tokens</c>, but is otherwise the
    /// same as <see cref="ICardTokenService.Create(CardTokenCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardToken>> Create(
        CardTokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
