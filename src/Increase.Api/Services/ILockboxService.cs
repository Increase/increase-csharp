using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Lockboxes;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILockboxService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILockboxServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILockboxService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Lockbox
    /// </summary>
    Task<Lockbox> Create(
        LockboxCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Lockbox
    /// </summary>
    Task<Lockbox> Retrieve(
        LockboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LockboxRetrieveParams, CancellationToken)"/>
    Task<Lockbox> Retrieve(
        string lockboxID,
        LockboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Lockbox
    /// </summary>
    Task<Lockbox> Update(
        LockboxUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LockboxUpdateParams, CancellationToken)"/>
    Task<Lockbox> Update(
        string lockboxID,
        LockboxUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Lockboxes
    /// </summary>
    Task<LockboxListPage> List(
        LockboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILockboxService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILockboxServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILockboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /lockboxes</c>, but is otherwise the
    /// same as <see cref="ILockboxService.Create(LockboxCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Lockbox>> Create(
        LockboxCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lockboxes/{lockbox_id}</c>, but is otherwise the
    /// same as <see cref="ILockboxService.Retrieve(LockboxRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Lockbox>> Retrieve(
        LockboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LockboxRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Lockbox>> Retrieve(
        string lockboxID,
        LockboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /lockboxes/{lockbox_id}</c>, but is otherwise the
    /// same as <see cref="ILockboxService.Update(LockboxUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Lockbox>> Update(
        LockboxUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LockboxUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Lockbox>> Update(
        string lockboxID,
        LockboxUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lockboxes</c>, but is otherwise the
    /// same as <see cref="ILockboxService.List(LockboxListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxListPage>> List(
        LockboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
