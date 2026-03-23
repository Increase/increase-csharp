using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundFednowTransfers;
using Increase.Api.Models.Simulations.InboundFednowTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates an [Inbound FedNow Transfer](#inbound-fednow-transfers) to your
    /// account.
    /// </summary>
    Task<InboundFednowTransfer> Create(
        InboundFednowTransferCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/inbound_fednow_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundFednowTransferService.Create(InboundFednowTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundFednowTransfer>> Create(
        InboundFednowTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
