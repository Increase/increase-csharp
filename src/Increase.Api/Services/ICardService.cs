using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Cards;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Card
    /// </summary>
    Task<Card> Create(CardCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve a Card
    /// </summary>
    Task<Card> Retrieve(
        CardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardRetrieveParams, CancellationToken)"/>
    Task<Card> Retrieve(
        string cardID,
        CardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Card
    /// </summary>
    Task<Card> Update(CardUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(CardUpdateParams, CancellationToken)"/>
    Task<Card> Update(
        string cardID,
        CardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Cards
    /// </summary>
    Task<CardListPage> List(
        CardListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an iframe URL for a Card to display the card details. More details about
    /// styling and usage can be found in the
    /// [documentation](/documentation/embedded-card-component).
    /// </summary>
    Task<CardIframeUrl> CreateDetailsIframe(
        CardCreateDetailsIframeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDetailsIframe(CardCreateDetailsIframeParams, CancellationToken)"/>
    Task<CardIframeUrl> CreateDetailsIframe(
        string cardID,
        CardCreateDetailsIframeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sensitive details for a Card include the primary account number, expiry, card
    /// verification code, and PIN.
    /// </summary>
    Task<CardDetails> Details(
        CardDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Details(CardDetailsParams, CancellationToken)"/>
    Task<CardDetails> Details(
        string cardID,
        CardDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Card's PIN
    /// </summary>
    Task<CardDetails> UpdatePin(
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdatePin(CardUpdatePinParams, CancellationToken)"/>
    Task<CardDetails> UpdatePin(
        string cardID,
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /cards</c>, but is otherwise the
    /// same as <see cref="ICardService.Create(CardCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Card>> Create(
        CardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /cards/{card_id}</c>, but is otherwise the
    /// same as <see cref="ICardService.Retrieve(CardRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Card>> Retrieve(
        CardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Card>> Retrieve(
        string cardID,
        CardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /cards/{card_id}</c>, but is otherwise the
    /// same as <see cref="ICardService.Update(CardUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Card>> Update(
        CardUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CardUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Card>> Update(
        string cardID,
        CardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /cards</c>, but is otherwise the
    /// same as <see cref="ICardService.List(CardListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardListPage>> List(
        CardListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /cards/{card_id}/create_details_iframe</c>, but is otherwise the
    /// same as <see cref="ICardService.CreateDetailsIframe(CardCreateDetailsIframeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardIframeUrl>> CreateDetailsIframe(
        CardCreateDetailsIframeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDetailsIframe(CardCreateDetailsIframeParams, CancellationToken)"/>
    Task<HttpResponse<CardIframeUrl>> CreateDetailsIframe(
        string cardID,
        CardCreateDetailsIframeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /cards/{card_id}/details</c>, but is otherwise the
    /// same as <see cref="ICardService.Details(CardDetailsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDetails>> Details(
        CardDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Details(CardDetailsParams, CancellationToken)"/>
    Task<HttpResponse<CardDetails>> Details(
        string cardID,
        CardDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /cards/{card_id}/update_pin</c>, but is otherwise the
    /// same as <see cref="ICardService.UpdatePin(CardUpdatePinParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDetails>> UpdatePin(
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdatePin(CardUpdatePinParams, CancellationToken)"/>
    Task<HttpResponse<CardDetails>> UpdatePin(
        string cardID,
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    );
}
