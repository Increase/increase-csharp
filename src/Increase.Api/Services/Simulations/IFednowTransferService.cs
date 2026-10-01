using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.FednowTransfers;
using Increase.Api.Models.Simulations.FednowTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates submission of a [FedNow Transfer](#fednow-transfers) and handling the
    /// response from the destination financial institution. This transfer must first
    /// have a `status` of `pending_submitting`.
    /// </summary>
    Task<FednowTransfer> Complete(
        FednowTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(FednowTransferCompleteParams, CancellationToken)"/>
    Task<FednowTransfer> Complete(
        string fednowTransferID,
        FednowTransferCompleteParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/fednow_transfers/{fednow_transfer_id}/complete</c>, but is otherwise the
    /// same as <see cref="IFednowTransferService.Complete(FednowTransferCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FednowTransfer>> Complete(
        FednowTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(FednowTransferCompleteParams, CancellationToken)"/>
    Task<HttpResponse<FednowTransfer>> Complete(
        string fednowTransferID,
        FednowTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
