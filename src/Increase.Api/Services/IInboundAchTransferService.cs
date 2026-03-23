using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundAchTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundAchTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Inbound ACH Transfer
    /// </summary>
    Task<InboundAchTransfer> Retrieve(
        InboundAchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundAchTransferRetrieveParams, CancellationToken)"/>
    Task<InboundAchTransfer> Retrieve(
        string inboundAchTransferID,
        InboundAchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound ACH Transfers
    /// </summary>
    Task<InboundAchTransferListPage> List(
        InboundAchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a notification of change for an Inbound ACH Transfer
    /// </summary>
    Task<InboundAchTransfer> CreateNotificationOfChange(
        InboundAchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateNotificationOfChange(InboundAchTransferCreateNotificationOfChangeParams, CancellationToken)"/>
    Task<InboundAchTransfer> CreateNotificationOfChange(
        string inboundAchTransferID,
        InboundAchTransferCreateNotificationOfChangeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Decline an Inbound ACH Transfer
    /// </summary>
    Task<InboundAchTransfer> Decline(
        InboundAchTransferDeclineParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Decline(InboundAchTransferDeclineParams, CancellationToken)"/>
    Task<InboundAchTransfer> Decline(
        string inboundAchTransferID,
        InboundAchTransferDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return an Inbound ACH Transfer
    /// </summary>
    Task<InboundAchTransfer> TransferReturn(
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TransferReturn(InboundAchTransferTransferReturnParams, CancellationToken)"/>
    Task<InboundAchTransfer> TransferReturn(
        string inboundAchTransferID,
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundAchTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundAchTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundAchTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_ach_transfers/{inbound_ach_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IInboundAchTransferService.Retrieve(InboundAchTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundAchTransfer>> Retrieve(
        InboundAchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundAchTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundAchTransfer>> Retrieve(
        string inboundAchTransferID,
        InboundAchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_ach_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundAchTransferService.List(InboundAchTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundAchTransferListPage>> List(
        InboundAchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_ach_transfers/{inbound_ach_transfer_id}/create_notification_of_change</c>, but is otherwise the
    /// same as <see cref="IInboundAchTransferService.CreateNotificationOfChange(InboundAchTransferCreateNotificationOfChangeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundAchTransfer>> CreateNotificationOfChange(
        InboundAchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateNotificationOfChange(InboundAchTransferCreateNotificationOfChangeParams, CancellationToken)"/>
    Task<HttpResponse<InboundAchTransfer>> CreateNotificationOfChange(
        string inboundAchTransferID,
        InboundAchTransferCreateNotificationOfChangeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_ach_transfers/{inbound_ach_transfer_id}/decline</c>, but is otherwise the
    /// same as <see cref="IInboundAchTransferService.Decline(InboundAchTransferDeclineParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundAchTransfer>> Decline(
        InboundAchTransferDeclineParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Decline(InboundAchTransferDeclineParams, CancellationToken)"/>
    Task<HttpResponse<InboundAchTransfer>> Decline(
        string inboundAchTransferID,
        InboundAchTransferDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_ach_transfers/{inbound_ach_transfer_id}/transfer_return</c>, but is otherwise the
    /// same as <see cref="IInboundAchTransferService.TransferReturn(InboundAchTransferTransferReturnParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundAchTransfer>> TransferReturn(
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TransferReturn(InboundAchTransferTransferReturnParams, CancellationToken)"/>
    Task<HttpResponse<InboundAchTransfer>> TransferReturn(
        string inboundAchTransferID,
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    );
}
