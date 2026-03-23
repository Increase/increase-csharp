using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AchTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAchTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAchTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an ACH Transfer
    /// </summary>
    Task<AchTransfer> Create(
        AchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an ACH Transfer
    /// </summary>
    Task<AchTransfer> Retrieve(
        AchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AchTransferRetrieveParams, CancellationToken)"/>
    Task<AchTransfer> Retrieve(
        string achTransferID,
        AchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List ACH Transfers
    /// </summary>
    Task<AchTransferListPage> List(
        AchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approves an ACH Transfer in a pending_approval state.
    /// </summary>
    Task<AchTransfer> Approve(
        AchTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(AchTransferApproveParams, CancellationToken)"/>
    Task<AchTransfer> Approve(
        string achTransferID,
        AchTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an ACH Transfer in a pending_approval state.
    /// </summary>
    Task<AchTransfer> Cancel(
        AchTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(AchTransferCancelParams, CancellationToken)"/>
    Task<AchTransfer> Cancel(
        string achTransferID,
        AchTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAchTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAchTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAchTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /ach_transfers</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Create(AchTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Create(
        AchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ach_transfers/{ach_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Retrieve(AchTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Retrieve(
        AchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AchTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Retrieve(
        string achTransferID,
        AchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ach_transfers</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.List(AchTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransferListPage>> List(
        AchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /ach_transfers/{ach_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Approve(AchTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Approve(
        AchTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(AchTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Approve(
        string achTransferID,
        AchTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /ach_transfers/{ach_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Cancel(AchTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Cancel(
        AchTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(AchTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Cancel(
        string achTransferID,
        AchTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
