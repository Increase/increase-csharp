using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundRealTimePaymentsTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundRealTimePaymentsTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundRealTimePaymentsTransferService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Retrieve an Inbound Real-Time Payments Transfer
    /// </summary>
    Task<InboundRealTimePaymentsTransfer> Retrieve(
        InboundRealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundRealTimePaymentsTransferRetrieveParams, CancellationToken)"/>
    Task<InboundRealTimePaymentsTransfer> Retrieve(
        string inboundRealTimePaymentsTransferID,
        InboundRealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound Real-Time Payments Transfers
    /// </summary>
    Task<InboundRealTimePaymentsTransferListPage> List(
        InboundRealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundRealTimePaymentsTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundRealTimePaymentsTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundRealTimePaymentsTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_real_time_payments_transfers/{inbound_real_time_payments_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IInboundRealTimePaymentsTransferService.Retrieve(InboundRealTimePaymentsTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundRealTimePaymentsTransfer>> Retrieve(
        InboundRealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundRealTimePaymentsTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundRealTimePaymentsTransfer>> Retrieve(
        string inboundRealTimePaymentsTransferID,
        InboundRealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_real_time_payments_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundRealTimePaymentsTransferService.List(InboundRealTimePaymentsTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundRealTimePaymentsTransferListPage>> List(
        InboundRealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
