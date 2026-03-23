using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CheckTransfers;
using Increase.Api.Models.Simulations.CheckTransfers;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the mailing of a [Check Transfer](#check-transfers), which happens
    /// periodically throughout the day in production but can be sped up in sandbox.
    /// This transfer must first have a `status` of `pending_approval` or
    /// `pending_submission`.
    /// </summary>
    Task<CheckTransfer> Mail(
        CheckTransferMailParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Mail(CheckTransferMailParams, CancellationToken)"/>
    Task<CheckTransfer> Mail(
        string checkTransferID,
        CheckTransferMailParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/check_transfers/{check_transfer_id}/mail</c>, but is otherwise the
    /// same as <see cref="ICheckTransferService.Mail(CheckTransferMailParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckTransfer>> Mail(
        CheckTransferMailParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Mail(CheckTransferMailParams, CancellationToken)"/>
    Task<HttpResponse<CheckTransfer>> Mail(
        string checkTransferID,
        CheckTransferMailParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
