using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILockboxRecipientService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILockboxRecipientServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILockboxRecipientService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Lockbox Recipient
    /// </summary>
    Task<LockboxRecipient> Create(
        LockboxRecipientCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Lockbox Recipient
    /// </summary>
    Task<LockboxRecipient> Retrieve(
        LockboxRecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LockboxRecipientRetrieveParams, CancellationToken)"/>
    Task<LockboxRecipient> Retrieve(
        string lockboxRecipientID,
        LockboxRecipientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Lockbox Recipient
    /// </summary>
    Task<LockboxRecipient> Update(
        LockboxRecipientUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LockboxRecipientUpdateParams, CancellationToken)"/>
    Task<LockboxRecipient> Update(
        string lockboxRecipientID,
        LockboxRecipientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Lockbox Recipients
    /// </summary>
    Task<LockboxRecipientListPage> List(
        LockboxRecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILockboxRecipientService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILockboxRecipientServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILockboxRecipientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /lockbox_recipients</c>, but is otherwise the
    /// same as <see cref="ILockboxRecipientService.Create(LockboxRecipientCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxRecipient>> Create(
        LockboxRecipientCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lockbox_recipients/{lockbox_recipient_id}</c>, but is otherwise the
    /// same as <see cref="ILockboxRecipientService.Retrieve(LockboxRecipientRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxRecipient>> Retrieve(
        LockboxRecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LockboxRecipientRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LockboxRecipient>> Retrieve(
        string lockboxRecipientID,
        LockboxRecipientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /lockbox_recipients/{lockbox_recipient_id}</c>, but is otherwise the
    /// same as <see cref="ILockboxRecipientService.Update(LockboxRecipientUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxRecipient>> Update(
        LockboxRecipientUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LockboxRecipientUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LockboxRecipient>> Update(
        string lockboxRecipientID,
        LockboxRecipientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lockbox_recipients</c>, but is otherwise the
    /// same as <see cref="ILockboxRecipientService.List(LockboxRecipientListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LockboxRecipientListPage>> List(
        LockboxRecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
