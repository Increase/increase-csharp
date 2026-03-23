using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardPushTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardPushTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardPushTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Card Push Transfer
    /// </summary>
    Task<CardPushTransfer> Create(
        CardPushTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Card Push Transfer
    /// </summary>
    Task<CardPushTransfer> Retrieve(
        CardPushTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardPushTransferRetrieveParams, CancellationToken)"/>
    Task<CardPushTransfer> Retrieve(
        string cardPushTransferID,
        CardPushTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Push Transfers
    /// </summary>
    Task<CardPushTransferListPage> List(
        CardPushTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approves a Card Push Transfer in a pending_approval state.
    /// </summary>
    Task<CardPushTransfer> Approve(
        CardPushTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(CardPushTransferApproveParams, CancellationToken)"/>
    Task<CardPushTransfer> Approve(
        string cardPushTransferID,
        CardPushTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a Card Push Transfer in a pending_approval state.
    /// </summary>
    Task<CardPushTransfer> Cancel(
        CardPushTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(CardPushTransferCancelParams, CancellationToken)"/>
    Task<CardPushTransfer> Cancel(
        string cardPushTransferID,
        CardPushTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardPushTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardPushTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardPushTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_push_transfers</c>, but is otherwise the
    /// same as <see cref="ICardPushTransferService.Create(CardPushTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPushTransfer>> Create(
        CardPushTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_push_transfers/{card_push_transfer_id}</c>, but is otherwise the
    /// same as <see cref="ICardPushTransferService.Retrieve(CardPushTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPushTransfer>> Retrieve(
        CardPushTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardPushTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CardPushTransfer>> Retrieve(
        string cardPushTransferID,
        CardPushTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_push_transfers</c>, but is otherwise the
    /// same as <see cref="ICardPushTransferService.List(CardPushTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPushTransferListPage>> List(
        CardPushTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_push_transfers/{card_push_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="ICardPushTransferService.Approve(CardPushTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPushTransfer>> Approve(
        CardPushTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(CardPushTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<CardPushTransfer>> Approve(
        string cardPushTransferID,
        CardPushTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_push_transfers/{card_push_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="ICardPushTransferService.Cancel(CardPushTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPushTransfer>> Cancel(
        CardPushTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(CardPushTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<CardPushTransfer>> Cancel(
        string cardPushTransferID,
        CardPushTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
