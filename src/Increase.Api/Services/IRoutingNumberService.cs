using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.RoutingNumbers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRoutingNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoutingNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoutingNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// You can use this API to confirm if a routing number is valid, such as when a
    /// user is providing you with bank account details. Since routing numbers uniquely
    /// identify a bank, this will always return 0 or 1 entry. In Sandbox, only a few
    /// [routing numbers are
    /// valid](/documentation/sandbox-routing-numbers#sandbox-routing-numbers).
    /// `110000000` is an example of a Sandbox routing number.
    /// </summary>
    Task<RoutingNumberListPage> List(
        RoutingNumberListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRoutingNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoutingNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoutingNumberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /routing_numbers</c>, but is otherwise the
    /// same as <see cref="IRoutingNumberService.List(RoutingNumberListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RoutingNumberListPage>> List(
        RoutingNumberListParams parameters,
        CancellationToken cancellationToken = default
    );
}
