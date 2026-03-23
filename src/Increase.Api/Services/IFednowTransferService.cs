using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFednowTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFednowTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFednowTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a FedNow Transfer
    /// </summary>
    Task<FednowTransfer> Create(
        FednowTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a FedNow Transfer
    /// </summary>
    Task<FednowTransfer> Retrieve(
        FednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FednowTransferRetrieveParams, CancellationToken)"/>
    Task<FednowTransfer> Retrieve(
        string fednowTransferID,
        FednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List FedNow Transfers
    /// </summary>
    Task<FednowTransferListPage> List(
        FednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve a FedNow Transfer
    /// </summary>
    Task<FednowTransfer> Approve(
        FednowTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(FednowTransferApproveParams, CancellationToken)"/>
    Task<FednowTransfer> Approve(
        string fednowTransferID,
        FednowTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a pending FedNow Transfer
    /// </summary>
    Task<FednowTransfer> Cancel(
        FednowTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(FednowTransferCancelParams, CancellationToken)"/>
    Task<FednowTransfer> Cancel(
        string fednowTransferID,
        FednowTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFednowTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFednowTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFednowTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /fednow_transfers</c>, but is otherwise the
    /// same as <see cref="IFednowTransferService.Create(FednowTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FednowTransfer>> Create(
        FednowTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /fednow_transfers/{fednow_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IFednowTransferService.Retrieve(FednowTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FednowTransfer>> Retrieve(
        FednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FednowTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FednowTransfer>> Retrieve(
        string fednowTransferID,
        FednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /fednow_transfers</c>, but is otherwise the
    /// same as <see cref="IFednowTransferService.List(FednowTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FednowTransferListPage>> List(
        FednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /fednow_transfers/{fednow_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="IFednowTransferService.Approve(FednowTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FednowTransfer>> Approve(
        FednowTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(FednowTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<FednowTransfer>> Approve(
        string fednowTransferID,
        FednowTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /fednow_transfers/{fednow_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IFednowTransferService.Cancel(FednowTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FednowTransfer>> Cancel(
        FednowTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(FednowTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<FednowTransfer>> Cancel(
        string fednowTransferID,
        FednowTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
