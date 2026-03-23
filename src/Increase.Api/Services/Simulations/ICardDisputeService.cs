using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardDisputes;
using Increase.Api.Models.Simulations.CardDisputes;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardDisputeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardDisputeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// After a [Card Dispute](#card-disputes) is created in production, the dispute
    /// will initially be in a `pending_user_submission_reviewing` state. Since no
    /// review or further action happens in sandbox, this endpoint simulates moving a
    /// Card Dispute through its various states.
    /// </summary>
    Task<CardDispute> Action(
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Action(CardDisputeActionParams, CancellationToken)"/>
    Task<CardDispute> Action(
        string cardDisputeID,
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardDisputeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardDisputeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardDisputeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_disputes/{card_dispute_id}/action</c>, but is otherwise the
    /// same as <see cref="ICardDisputeService.Action(CardDisputeActionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDispute>> Action(
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Action(CardDisputeActionParams, CancellationToken)"/>
    Task<HttpResponse<CardDispute>> Action(
        string cardDisputeID,
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    );
}
