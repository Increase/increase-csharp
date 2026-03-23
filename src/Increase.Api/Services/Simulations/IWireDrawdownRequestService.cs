using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.WireDrawdownRequests;
using Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates a Wire Drawdown Request being refused by the debtor.
    /// </summary>
    Task<WireDrawdownRequest> Refuse(
        WireDrawdownRequestRefuseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Refuse(WireDrawdownRequestRefuseParams, CancellationToken)"/>
    Task<WireDrawdownRequest> Refuse(
        string wireDrawdownRequestID,
        WireDrawdownRequestRefuseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates a Wire Drawdown Request being submitted to Fedwire.
    /// </summary>
    Task<WireDrawdownRequest> Submit(
        WireDrawdownRequestSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(WireDrawdownRequestSubmitParams, CancellationToken)"/>
    Task<WireDrawdownRequest> Submit(
        string wireDrawdownRequestID,
        WireDrawdownRequestSubmitParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/wire_drawdown_requests/{wire_drawdown_request_id}/refuse</c>, but is otherwise the
    /// same as <see cref="IWireDrawdownRequestService.Refuse(WireDrawdownRequestRefuseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireDrawdownRequest>> Refuse(
        WireDrawdownRequestRefuseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Refuse(WireDrawdownRequestRefuseParams, CancellationToken)"/>
    Task<HttpResponse<WireDrawdownRequest>> Refuse(
        string wireDrawdownRequestID,
        WireDrawdownRequestRefuseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/wire_drawdown_requests/{wire_drawdown_request_id}/submit</c>, but is otherwise the
    /// same as <see cref="IWireDrawdownRequestService.Submit(WireDrawdownRequestSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WireDrawdownRequest>> Submit(
        WireDrawdownRequestSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(WireDrawdownRequestSubmitParams, CancellationToken)"/>
    Task<HttpResponse<WireDrawdownRequest>> Submit(
        string wireDrawdownRequestID,
        WireDrawdownRequestSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
