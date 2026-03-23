using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundWireDrawdownRequests;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundWireDrawdownRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundWireDrawdownRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundWireDrawdownRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Inbound Wire Drawdown Request
    /// </summary>
    Task<InboundWireDrawdownRequest> Retrieve(
        InboundWireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundWireDrawdownRequestRetrieveParams, CancellationToken)"/>
    Task<InboundWireDrawdownRequest> Retrieve(
        string inboundWireDrawdownRequestID,
        InboundWireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound Wire Drawdown Requests
    /// </summary>
    Task<InboundWireDrawdownRequestListPage> List(
        InboundWireDrawdownRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundWireDrawdownRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundWireDrawdownRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundWireDrawdownRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_wire_drawdown_requests/{inbound_wire_drawdown_request_id}</c>, but is otherwise the
    /// same as <see cref="IInboundWireDrawdownRequestService.Retrieve(InboundWireDrawdownRequestRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireDrawdownRequest>> Retrieve(
        InboundWireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundWireDrawdownRequestRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundWireDrawdownRequest>> Retrieve(
        string inboundWireDrawdownRequestID,
        InboundWireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_wire_drawdown_requests</c>, but is otherwise the
    /// same as <see cref="IInboundWireDrawdownRequestService.List(InboundWireDrawdownRequestListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireDrawdownRequestListPage>> List(
        InboundWireDrawdownRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
