using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Services;

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
    /// Create a Wire Transfer
    /// </summary>
    Task<WireTransfer> Create(
        WireTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Wire Transfer
    /// </summary>
    Task<WireTransfer> Retrieve(
        WireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WireTransferRetrieveParams, CancellationToken)"/>
    Task<WireTransfer> Retrieve(
        string wireTransferID,
        WireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Wire Transfers
    /// </summary>
    Task<WireTransferListPage> List(
        WireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve a Wire Transfer
    /// </summary>
    Task<WireTransfer> Approve(
        WireTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(WireTransferApproveParams, CancellationToken)"/>
    Task<WireTransfer> Approve(
        string wireTransferID,
        WireTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a pending Wire Transfer
    /// </summary>
    Task<WireTransfer> Cancel(
        WireTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(WireTransferCancelParams, CancellationToken)"/>
    Task<WireTransfer> Cancel(
        string wireTransferID,
        WireTransferCancelParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /wire_transfers</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.Create(WireTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransfer>> Create(
        WireTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /wire_transfers/{wire_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.Retrieve(WireTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransfer>> Retrieve(
        WireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WireTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WireTransfer>> Retrieve(
        string wireTransferID,
        WireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /wire_transfers</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.List(WireTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransferListPage>> List(
        WireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /wire_transfers/{wire_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.Approve(WireTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransfer>> Approve(
        WireTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(WireTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<WireTransfer>> Approve(
        string wireTransferID,
        WireTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /wire_transfers/{wire_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IWireTransferService.Cancel(WireTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireTransfer>> Cancel(
        WireTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(WireTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<WireTransfer>> Cancel(
        string wireTransferID,
        WireTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
