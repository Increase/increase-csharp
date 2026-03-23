using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.WireTransfers;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWireTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWireTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the reversal of a [Wire Transfer](#wire-transfers) by the Federal
    /// Reserve due to error conditions. This will also create a
    /// [Transaction](#transaction) to account for the returned funds. This Wire
    /// Transfer must first have a `status` of `complete`.
    /// </summary>
    Task<WireTransfer> Reverse(
        WireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reverse(WireTransferReverseParams, CancellationToken)"/>
    Task<WireTransfer> Reverse(
        string wireTransferID,
        WireTransferReverseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the submission of a [Wire Transfer](#wire-transfers) to the Federal
    /// Reserve. This transfer must first have a `status` of `pending_approval` or
    /// `pending_creating`.
    /// </summary>
    Task<WireTransfer> Submit(
        WireTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(WireTransferSubmitParams, CancellationToken)"/>
    Task<WireTransfer> Submit(
        string wireTransferID,
        WireTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWireTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWireTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/wire_transfers/{wire_transfer_id}/reverse</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.Reverse(WireTransferReverseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransfer>> Reverse(
        WireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reverse(WireTransferReverseParams, CancellationToken)"/>
    Task<HttpResponse<WireTransfer>> Reverse(
        string wireTransferID,
        WireTransferReverseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/wire_transfers/{wire_transfer_id}/submit</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.Submit(WireTransferSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransfer>> Submit(
        WireTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(WireTransferSubmitParams, CancellationToken)"/>
    Task<HttpResponse<WireTransfer>> Submit(
        string wireTransferID,
        WireTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
