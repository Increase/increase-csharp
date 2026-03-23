using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPurchaseSupplements;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardPurchaseSupplementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardPurchaseSupplementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardPurchaseSupplementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Card Purchase Supplement
    /// </summary>
    Task<CardPurchaseSupplement> Retrieve(
        CardPurchaseSupplementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardPurchaseSupplementRetrieveParams, CancellationToken)"/>
    Task<CardPurchaseSupplement> Retrieve(
        string cardPurchaseSupplementID,
        CardPurchaseSupplementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Purchase Supplements
    /// </summary>
    Task<CardPurchaseSupplementListPage> List(
        CardPurchaseSupplementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardPurchaseSupplementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardPurchaseSupplementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardPurchaseSupplementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_purchase_supplements/{card_purchase_supplement_id}</c>, but is otherwise the
    /// same as <see cref="ICardPurchaseSupplementService.Retrieve(CardPurchaseSupplementRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPurchaseSupplement>> Retrieve(
        CardPurchaseSupplementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardPurchaseSupplementRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CardPurchaseSupplement>> Retrieve(
        string cardPurchaseSupplementID,
        CardPurchaseSupplementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_purchase_supplements</c>, but is otherwise the
    /// same as <see cref="ICardPurchaseSupplementService.List(CardPurchaseSupplementListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPurchaseSupplementListPage>> List(
        CardPurchaseSupplementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
