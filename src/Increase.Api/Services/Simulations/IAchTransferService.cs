using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AchTransfers;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates the acknowledgement of an [ACH Transfer](#ach-transfers) by the
    /// Federal Reserve. This transfer must first have a `status` of `submitted`. In
    /// production, the Federal Reserve generally acknowledges submitted ACH files
    /// within 30 minutes. Since sandbox ACH Transfers are not submitted to the Federal
    /// Reserve, this endpoint allows you to skip that delay and add the acknowledgement
    /// subresource to the ACH Transfer.
    /// </summary>
    Task<AchTransfer> Acknowledge(
        AchTransferAcknowledgeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Acknowledge(AchTransferAcknowledgeParams, CancellationToken)"/>
    Task<AchTransfer> Acknowledge(
        string achTransferID,
        AchTransferAcknowledgeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates receiving a Notification of Change for an [ACH
    /// Transfer](#ach-transfers).
    /// </summary>
    Task<AchTransfer> CreateNotificationOfChange(
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateNotificationOfChange(AchTransferCreateNotificationOfChangeParams, CancellationToken)"/>
    Task<AchTransfer> CreateNotificationOfChange(
        string achTransferID,
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the return of an [ACH Transfer](#ach-transfers) by the Federal Reserve
    /// due to an error condition. This will also create a Transaction to account for
    /// the returned funds. This transfer must first have a `status` of `submitted`.
    /// </summary>
    Task<AchTransfer> Return(
        AchTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Return(AchTransferReturnParams, CancellationToken)"/>
    Task<AchTransfer> Return(
        string achTransferID,
        AchTransferReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the settlement of an [ACH Transfer](#ach-transfers) by the Federal
    /// Reserve. This transfer must first have a `status` of `pending_submission` or
    /// `submitted`. For convenience, if the transfer is in `status`:
    /// `pending_submission`, the simulation will also submit the transfer. Without this
    /// simulation the transfer will eventually settle on its own following the same
    /// Federal Reserve timeline as in production. Additionally, you can specify the
    /// behavior of the inbound funds hold that is created when the ACH Transfer is
    /// settled. If no behavior is specified, the inbound funds hold will be released
    /// immediately in order for the funds to be available for use.
    /// </summary>
    Task<AchTransfer> Settle(
        AchTransferSettleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Settle(AchTransferSettleParams, CancellationToken)"/>
    Task<AchTransfer> Settle(
        string achTransferID,
        AchTransferSettleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the submission of an [ACH Transfer](#ach-transfers) to the Federal
    /// Reserve. This transfer must first have a `status` of `pending_approval` or
    /// `pending_submission`. In production, Increase submits ACH Transfers to the
    /// Federal Reserve three times per day on weekdays. Since sandbox ACH Transfers are
    /// not submitted to the Federal Reserve, this endpoint allows you to skip that
    /// delay and transition the ACH Transfer to a status of `submitted`.
    /// </summary>
    Task<AchTransfer> Submit(
        AchTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(AchTransferSubmitParams, CancellationToken)"/>
    Task<AchTransfer> Submit(
        string achTransferID,
        AchTransferSubmitParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/ach_transfers/{ach_transfer_id}/acknowledge</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Acknowledge(AchTransferAcknowledgeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Acknowledge(
        AchTransferAcknowledgeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Acknowledge(AchTransferAcknowledgeParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Acknowledge(
        string achTransferID,
        AchTransferAcknowledgeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/ach_transfers/{ach_transfer_id}/create_notification_of_change</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.CreateNotificationOfChange(AchTransferCreateNotificationOfChangeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> CreateNotificationOfChange(
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateNotificationOfChange(AchTransferCreateNotificationOfChangeParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> CreateNotificationOfChange(
        string achTransferID,
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/ach_transfers/{ach_transfer_id}/return</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Return(AchTransferReturnParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Return(
        AchTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Return(AchTransferReturnParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Return(
        string achTransferID,
        AchTransferReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/ach_transfers/{ach_transfer_id}/settle</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Settle(AchTransferSettleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Settle(
        AchTransferSettleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Settle(AchTransferSettleParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Settle(
        string achTransferID,
        AchTransferSettleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/ach_transfers/{ach_transfer_id}/submit</c>, but is otherwise the
    /// same as <see cref="IAchTransferService.Submit(AchTransferSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchTransfer>> Submit(
        AchTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(AchTransferSubmitParams, CancellationToken)"/>
    Task<HttpResponse<AchTransfer>> Submit(
        string achTransferID,
        AchTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
