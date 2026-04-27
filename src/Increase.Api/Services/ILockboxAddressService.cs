using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.LockboxAddresses;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILockboxAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILockboxAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILockboxAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Lockbox Address
    /// </summary>
    Task<LockboxAddress> Create(
        LockboxAddressCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Lockbox Address
    /// </summary>
    Task<LockboxAddress> Retrieve(
        LockboxAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LockboxAddressRetrieveParams, CancellationToken)"/>
    Task<LockboxAddress> Retrieve(
        string lockboxAddressID,
        LockboxAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Lockbox Address
    /// </summary>
    Task<LockboxAddress> Update(
        LockboxAddressUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LockboxAddressUpdateParams, CancellationToken)"/>
    Task<LockboxAddress> Update(
        string lockboxAddressID,
        LockboxAddressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Lockbox Addresses
    /// </summary>
    Task<LockboxAddressListPage> List(
        LockboxAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILockboxAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILockboxAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILockboxAddressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /lockbox_addresses</c>, but is otherwise the
    /// same as <see cref="ILockboxAddressService.Create(LockboxAddressCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxAddress>> Create(
        LockboxAddressCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lockbox_addresses/{lockbox_address_id}</c>, but is otherwise the
    /// same as <see cref="ILockboxAddressService.Retrieve(LockboxAddressRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxAddress>> Retrieve(
        LockboxAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LockboxAddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LockboxAddress>> Retrieve(
        string lockboxAddressID,
        LockboxAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /lockbox_addresses/{lockbox_address_id}</c>, but is otherwise the
    /// same as <see cref="ILockboxAddressService.Update(LockboxAddressUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxAddress>> Update(
        LockboxAddressUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LockboxAddressUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LockboxAddress>> Update(
        string lockboxAddressID,
        LockboxAddressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lockbox_addresses</c>, but is otherwise the
    /// same as <see cref="ILockboxAddressService.List(LockboxAddressListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxAddressListPage>> List(
        LockboxAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
