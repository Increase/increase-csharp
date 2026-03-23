using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISwiftTransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISwiftTransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISwiftTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Swift Transfer
    /// </summary>
    Task<SwiftTransfer> Create(
        SwiftTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Swift Transfer
    /// </summary>
    Task<SwiftTransfer> Retrieve(
        SwiftTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SwiftTransferRetrieveParams, CancellationToken)"/>
    Task<SwiftTransfer> Retrieve(
        string swiftTransferID,
        SwiftTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Swift Transfers
    /// </summary>
    Task<SwiftTransferListPage> List(
        SwiftTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve a Swift Transfer
    /// </summary>
    Task<SwiftTransfer> Approve(
        SwiftTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(SwiftTransferApproveParams, CancellationToken)"/>
    Task<SwiftTransfer> Approve(
        string swiftTransferID,
        SwiftTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a pending Swift Transfer
    /// </summary>
    Task<SwiftTransfer> Cancel(
        SwiftTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SwiftTransferCancelParams, CancellationToken)"/>
    Task<SwiftTransfer> Cancel(
        string swiftTransferID,
        SwiftTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISwiftTransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISwiftTransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISwiftTransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /swift_transfers</c>, but is otherwise the
    /// same as <see cref="ISwiftTransferService.Create(SwiftTransferCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwiftTransfer>> Create(
        SwiftTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /swift_transfers/{swift_transfer_id}</c>, but is otherwise the
    /// same as <see cref="ISwiftTransferService.Retrieve(SwiftTransferRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwiftTransfer>> Retrieve(
        SwiftTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SwiftTransferRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SwiftTransfer>> Retrieve(
        string swiftTransferID,
        SwiftTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /swift_transfers</c>, but is otherwise the
    /// same as <see cref="ISwiftTransferService.List(SwiftTransferListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwiftTransferListPage>> List(
        SwiftTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /swift_transfers/{swift_transfer_id}/approve</c>, but is otherwise the
    /// same as <see cref="ISwiftTransferService.Approve(SwiftTransferApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwiftTransfer>> Approve(
        SwiftTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(SwiftTransferApproveParams, CancellationToken)"/>
    Task<HttpResponse<SwiftTransfer>> Approve(
        string swiftTransferID,
        SwiftTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /swift_transfers/{swift_transfer_id}/cancel</c>, but is otherwise the
    /// same as <see cref="ISwiftTransferService.Cancel(SwiftTransferCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwiftTransfer>> Cancel(
        SwiftTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SwiftTransferCancelParams, CancellationToken)"/>
    Task<HttpResponse<SwiftTransfer>> Cancel(
        string swiftTransferID,
        SwiftTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
