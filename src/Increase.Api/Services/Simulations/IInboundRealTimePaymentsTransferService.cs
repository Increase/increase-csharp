using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;
using Increase.Api.Models.Simulations.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates an [Inbound Real-Time Payments
    /// Transfer](#inbound-real-time-payments-transfers) to your account. Real-Time
    /// Payments are a beta feature.
    /// </summary>
    Task<InboundRealTimePaymentsTransfer> Create(
        InboundRealTimePaymentsTransferCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/inbound_real_time_payments_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundRealTimePaymentsTransferService.Create(InboundRealTimePaymentsTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundRealTimePaymentsTransfer>> Create(
        InboundRealTimePaymentsTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
