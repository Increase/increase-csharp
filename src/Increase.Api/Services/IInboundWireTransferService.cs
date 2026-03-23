using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundWireTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundWireTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundWireTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Inbound Wire Transfer
    /// </summary>
    Task<InboundWireTransfer> Retrieve(
        InboundWireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundWireTransferRetrieveParams, CancellationToken)"/>
    Task<InboundWireTransfer> Retrieve(
        string inboundWireTransferID,
        InboundWireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound Wire Transfers
    /// </summary>
    Task<InboundWireTransferListPage> List(
        InboundWireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reverse an Inbound Wire Transfer
    /// </summary>
    Task<InboundWireTransfer> Reverse(
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reverse(InboundWireTransferReverseParams, CancellationToken)"/>
    Task<InboundWireTransfer> Reverse(
        string inboundWireTransferID,
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundWireTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundWireTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundWireTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_wire_transfers/{inbound_wire_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IInboundWireTransferService.Retrieve(InboundWireTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireTransfer>> Retrieve(
        InboundWireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundWireTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundWireTransfer>> Retrieve(
        string inboundWireTransferID,
        InboundWireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_wire_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundWireTransferService.List(InboundWireTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireTransferListPage>> List(
        InboundWireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_wire_transfers/{inbound_wire_transfer_id}/reverse</c>, but is otherwise the
    /// same as <see cref="IInboundWireTransferService.Reverse(InboundWireTransferReverseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireTransfer>> Reverse(
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reverse(InboundWireTransferReverseParams, CancellationToken)"/>
    Task<HttpResponse<InboundWireTransfer>> Reverse(
        string inboundWireTransferID,
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    );
}
