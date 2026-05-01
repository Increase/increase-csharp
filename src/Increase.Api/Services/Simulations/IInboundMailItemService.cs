using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundMailItems;
using Increase.Api.Models.Simulations.InboundMailItems;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundMailItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundMailItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundMailItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates an Inbound Mail Item to one of your Lockbox Addresses or Lockbox
    /// Recipients, as if someone had mailed a physical check.
    /// </summary>
    Task<InboundMailItem> Create(
        InboundMailItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundMailItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundMailItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundMailItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/inbound_mail_items</c>, but is otherwise the
    /// same as <see cref="IInboundMailItemService.Create(InboundMailItemCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundMailItem>> Create(
        InboundMailItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
