using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Check Transfer
    /// </summary>
    Task<CheckTransfer> Create(
        CheckTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Check Transfer
    /// </summary>
    Task<CheckTransfer> Retrieve(
        CheckTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckTransferRetrieveParams, CancellationToken)"/>
    Task<CheckTransfer> Retrieve(
        string checkTransferID,
        CheckTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Check Transfers
    /// </summary>
    Task<CheckTransferListPage> List(
        CheckTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve a Check Transfer
    /// </summary>
    Task<CheckTransfer> Approve(
        CheckTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(CheckTransferApproveParams, CancellationToken)"/>
    Task<CheckTransfer> Approve(
        string checkTransferID,
        CheckTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a Check Transfer with the `pending_approval` status. See [Transfer
    /// Approvals](/documentation/transfer-approvals) for more information.
    /// </summary>
    Task<CheckTransfer> Cancel(
        CheckTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(CheckTransferCancelParams, CancellationToken)"/>
    Task<CheckTransfer> Cancel(
        string checkTransferID,
        CheckTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop payment on a Check Transfer
    /// </summary>
    Task<CheckTransfer> StopPayment(
        CheckTransferStopPaymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StopPayment(CheckTransferStopPaymentParams, CancellationToken)"/>
    Task<CheckTransfer> StopPayment(
        string checkTransferID,
        CheckTransferStopPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /check_transfers</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.Create(CheckTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransfer>> Create(
        CheckTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /check_transfers/{check_transfer_id}</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.Retrieve(CheckTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransfer>> Retrieve(
        CheckTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CheckTransfer>> Retrieve(
        string checkTransferID,
        CheckTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /check_transfers</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.List(CheckTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransferListPage>> List(
        CheckTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /check_transfers/{check_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.Approve(CheckTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransfer>> Approve(
        CheckTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(CheckTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<CheckTransfer>> Approve(
        string checkTransferID,
        CheckTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /check_transfers/{check_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.Cancel(CheckTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransfer>> Cancel(
        CheckTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(CheckTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<CheckTransfer>> Cancel(
        string checkTransferID,
        CheckTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /check_transfers/{check_transfer_id}/stop_payment</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.StopPayment(CheckTransferStopPaymentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransfer>> StopPayment(
        CheckTransferStopPaymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StopPayment(CheckTransferStopPaymentParams, CancellationToken)"/>
    Task<HttpResponse<CheckTransfer>> StopPayment(
        string checkTransferID,
        CheckTransferStopPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
