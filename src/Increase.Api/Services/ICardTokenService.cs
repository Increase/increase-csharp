using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardTokens;

namespace Increase.Api.Services;

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
    /// Retrieve a Card Token
    /// </summary>
    Task<CardToken> Retrieve(
        CardTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardTokenRetrieveParams, CancellationToken)"/>
    Task<CardToken> Retrieve(
        string cardTokenID,
        CardTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Tokens
    /// </summary>
    Task<CardTokenListPage> List(
        CardTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The capabilities of a Card Token describe whether the card can be used for
    /// specific operations, such as Card Push Transfers. The capabilities can change
    /// over time based on the issuing bank's configuration of the card range.
    /// </summary>
    Task<CardTokenCapabilities> Capabilities(
        CardTokenCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Capabilities(CardTokenCapabilitiesParams, CancellationToken)"/>
    Task<CardTokenCapabilities> Capabilities(
        string cardTokenID,
        CardTokenCapabilitiesParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /card_tokens/{card_token_id}</c>, but is otherwise the
    /// same as <see cref="ICardTokenService.Retrieve(CardTokenRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardToken>> Retrieve(
        CardTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardTokenRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CardToken>> Retrieve(
        string cardTokenID,
        CardTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_tokens</c>, but is otherwise the
    /// same as <see cref="ICardTokenService.List(CardTokenListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardTokenListPage>> List(
        CardTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_tokens/{card_token_id}/capabilities</c>, but is otherwise the
    /// same as <see cref="ICardTokenService.Capabilities(CardTokenCapabilitiesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardTokenCapabilities>> Capabilities(
        CardTokenCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Capabilities(CardTokenCapabilitiesParams, CancellationToken)"/>
    Task<HttpResponse<CardTokenCapabilities>> Capabilities(
        string cardTokenID,
        CardTokenCapabilitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
