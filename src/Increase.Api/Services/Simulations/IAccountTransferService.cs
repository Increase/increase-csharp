using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AccountTransfers;
using Increase.Api.Models.Simulations.AccountTransfers;

namespace Increase.Api.Services.Simulations;

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
    /// If your account is configured to require approval for each transfer, this
    /// endpoint simulates the approval of an [Account Transfer](#account-transfers).
    /// You can also approve sandbox Account Transfers in the dashboard. This transfer
    /// must first have a `status` of `pending_approval`.
    /// </summary>
    Task<AccountTransfer> Complete(
        AccountTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(AccountTransferCompleteParams, CancellationToken)"/>
    Task<AccountTransfer> Complete(
        string accountTransferID,
        AccountTransferCompleteParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/account_transfers/{account_transfer_id}/complete</c>, but is otherwise the
    /// same as <see cref="IAccountTransferService.Complete(AccountTransferCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransfer>> Complete(
        AccountTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(AccountTransferCompleteParams, CancellationToken)"/>
    Task<HttpResponse<AccountTransfer>> Complete(
        string accountTransferID,
        AccountTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
