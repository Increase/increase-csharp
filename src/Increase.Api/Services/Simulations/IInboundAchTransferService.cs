using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundAchTransfers;
using Increase.Api.Models.Simulations.InboundAchTransfers;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundAchTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundAchTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates an inbound ACH transfer to your account. This imitates initiating a
    /// transfer to an Increase account from a different financial institution. The
    /// transfer may be either a credit or a debit depending on if the `amount` is
    /// positive or negative. The result of calling this API will contain the created
    /// transfer. You can pass a `resolve_at` parameter to allow for a window to [action
    /// on the Inbound ACH
    /// Transfer](https://increase.com/documentation/receiving-ach-transfers).
    /// Alternatively, if you don't pass the `resolve_at` parameter the result will
    /// contain either a [Transaction](#transactions) or a [Declined
    /// Transaction](#declined-transactions) depending on whether or not the transfer is
    /// allowed.
    /// </summary>
    Task<InboundAchTransfer> Create(
        InboundAchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundAchTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundAchTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundAchTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/inbound_ach_transfers</c>, but is otherwise the
    /// same as <see cref="IInboundAchTransferService.Create(InboundAchTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundAchTransfer>> Create(
        InboundAchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
