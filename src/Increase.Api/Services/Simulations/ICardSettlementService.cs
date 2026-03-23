using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardSettlements;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardSettlementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardSettlementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardSettlementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the settlement of an authorization by a card acquirer. After a card
    /// authorization is created, the merchant will eventually send a settlement. This
    /// simulates that event, which may occur many days after the purchase in
    /// production. The amount settled can be different from the amount originally
    /// authorized, for example, when adding a tip to a restaurant bill.
    /// </summary>
    Task<Transaction> Create(
        CardSettlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardSettlementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardSettlementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardSettlementServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_settlements</c>, but is otherwise the
    /// same as <see cref="ICardSettlementService.Create(CardSettlementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Transaction>> Create(
        CardSettlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
