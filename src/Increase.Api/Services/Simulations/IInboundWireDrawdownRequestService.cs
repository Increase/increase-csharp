using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundWireDrawdownRequests;
using Increase.Api.Models.Simulations.InboundWireDrawdownRequests;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates receiving an [Inbound Wire Drawdown
    /// Request](#inbound-wire-drawdown-requests).
    /// </summary>
    Task<InboundWireDrawdownRequest> Create(
        InboundWireDrawdownRequestCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/inbound_wire_drawdown_requests</c>, but is otherwise the
    /// same as <see cref="IInboundWireDrawdownRequestService.Create(InboundWireDrawdownRequestCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireDrawdownRequest>> Create(
        InboundWireDrawdownRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
