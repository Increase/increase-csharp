using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AccountTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an Account Transfer
    /// </summary>
    Task<AccountTransfer> Create(
        AccountTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Account Transfer
    /// </summary>
    Task<AccountTransfer> Retrieve(
        AccountTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountTransferRetrieveParams, CancellationToken)"/>
    Task<AccountTransfer> Retrieve(
        string accountTransferID,
        AccountTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Account Transfers
    /// </summary>
    Task<AccountTransferListPage> List(
        AccountTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approves an Account Transfer in status `pending_approval`.
    /// </summary>
    Task<AccountTransfer> Approve(
        AccountTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(AccountTransferApproveParams, CancellationToken)"/>
    Task<AccountTransfer> Approve(
        string accountTransferID,
        AccountTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an Account Transfer in status `pending_approval`.
    /// </summary>
    Task<AccountTransfer> Cancel(
        AccountTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(AccountTransferCancelParams, CancellationToken)"/>
    Task<AccountTransfer> Cancel(
        string accountTransferID,
        AccountTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /account_transfers</c>, but is otherwise the
    /// same as <see cref="IAccountTransferService.Create(AccountTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransfer>> Create(
        AccountTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /account_transfers/{account_transfer_id}</c>, but is otherwise the
    /// same as <see cref="IAccountTransferService.Retrieve(AccountTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransfer>> Retrieve(
        AccountTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountTransfer>> Retrieve(
        string accountTransferID,
        AccountTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /account_transfers</c>, but is otherwise the
    /// same as <see cref="IAccountTransferService.List(AccountTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransferListPage>> List(
        AccountTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /account_transfers/{account_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="IAccountTransferService.Approve(AccountTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransfer>> Approve(
        AccountTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(AccountTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<AccountTransfer>> Approve(
        string accountTransferID,
        AccountTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /account_transfers/{account_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IAccountTransferService.Cancel(AccountTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransfer>> Cancel(
        AccountTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(AccountTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<AccountTransfer>> Cancel(
        string accountTransferID,
        AccountTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
