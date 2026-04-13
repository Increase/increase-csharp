using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPurchaseSupplements;
using Increase.Api.Models.Simulations.CardPurchaseSupplements;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates the creation of a Card Purchase Supplement (Level 3 data) for a card
    /// settlement. This happens asynchronously in production when Visa sends enhanced
    /// transaction data about a purchase.
    /// </summary>
    Task<CardPurchaseSupplement> Create(
        CardPurchaseSupplementCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/card_purchase_supplements</c>, but is otherwise the
    /// same as <see cref="ICardPurchaseSupplementService.Create(CardPurchaseSupplementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPurchaseSupplement>> Create(
        CardPurchaseSupplementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
