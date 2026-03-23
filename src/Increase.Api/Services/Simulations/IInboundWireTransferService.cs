using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundWireTransfers;
using Increase.Api.Models.Simulations.InboundWireTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates an [Inbound Wire Transfer](#inbound-wire-transfers) to your account.
    /// </summary>
    Task<InboundWireTransfer> Create(
        InboundWireTransferCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/inbound_wire_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundWireTransferService.Create(InboundWireTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundWireTransfer>> Create(
        InboundWireTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
