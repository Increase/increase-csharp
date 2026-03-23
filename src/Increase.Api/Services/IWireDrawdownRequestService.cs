using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWireDrawdownRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWireDrawdownRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireDrawdownRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Wire Drawdown Request
    /// </summary>
    Task<WireDrawdownRequest> Create(
        WireDrawdownRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Wire Drawdown Request
    /// </summary>
    Task<WireDrawdownRequest> Retrieve(
        WireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WireDrawdownRequestRetrieveParams, CancellationToken)"/>
    Task<WireDrawdownRequest> Retrieve(
        string wireDrawdownRequestID,
        WireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Wire Drawdown Requests
    /// </summary>
    Task<WireDrawdownRequestListPage> List(
        WireDrawdownRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWireDrawdownRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWireDrawdownRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireDrawdownRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /wire_drawdown_requests</c>, but is otherwise the
    /// same as <see cref="IWireDrawdownRequestService.Create(WireDrawdownRequestCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireDrawdownRequest>> Create(
        WireDrawdownRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /wire_drawdown_requests/{wire_drawdown_request_id}</c>, but is otherwise the
    /// same as <see cref="IWireDrawdownRequestService.Retrieve(WireDrawdownRequestRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireDrawdownRequest>> Retrieve(
        WireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WireDrawdownRequestRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WireDrawdownRequest>> Retrieve(
        string wireDrawdownRequestID,
        WireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /wire_drawdown_requests</c>, but is otherwise the
    /// same as <see cref="IWireDrawdownRequestService.List(WireDrawdownRequestListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireDrawdownRequestListPage>> List(
        WireDrawdownRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
