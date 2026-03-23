using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Groups;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns details for the currently authenticated Group.
    /// </summary>
    Task<Group> Retrieve(
        GroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /groups/current</c>, but is otherwise the
    /// same as <see cref="IGroupService.Retrieve(GroupRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Group>> Retrieve(
        GroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
