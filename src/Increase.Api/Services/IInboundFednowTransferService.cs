using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundFednowTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundFednowTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundFednowTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundFednowTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Inbound FedNow Transfer
    /// </summary>
    Task<InboundFednowTransfer> Retrieve(
        InboundFednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundFednowTransferRetrieveParams, CancellationToken)"/>
    Task<InboundFednowTransfer> Retrieve(
        string inboundFednowTransferID,
        InboundFednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound FedNow Transfers
    /// </summary>
    Task<InboundFednowTransferListPage> List(
        InboundFednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundFednowTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundFednowTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundFednowTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_fednow_transfers/{inbound_fednow_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IInboundFednowTransferService.Retrieve(InboundFednowTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundFednowTransfer>> Retrieve(
        InboundFednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundFednowTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundFednowTransfer>> Retrieve(
        string inboundFednowTransferID,
        InboundFednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_fednow_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundFednowTransferService.List(InboundFednowTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundFednowTransferListPage>> List(
        InboundFednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
