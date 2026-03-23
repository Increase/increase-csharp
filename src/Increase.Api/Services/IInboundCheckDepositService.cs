using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundCheckDepositService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundCheckDepositServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundCheckDepositService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Inbound Check Deposit
    /// </summary>
    Task<InboundCheckDeposit> Retrieve(
        InboundCheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundCheckDepositRetrieveParams, CancellationToken)"/>
    Task<InboundCheckDeposit> Retrieve(
        string inboundCheckDepositID,
        InboundCheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound Check Deposits
    /// </summary>
    Task<InboundCheckDepositListPage> List(
        InboundCheckDepositListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Decline an Inbound Check Deposit
    /// </summary>
    Task<InboundCheckDeposit> Decline(
        InboundCheckDepositDeclineParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Decline(InboundCheckDepositDeclineParams, CancellationToken)"/>
    Task<InboundCheckDeposit> Decline(
        string inboundCheckDepositID,
        InboundCheckDepositDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return an Inbound Check Deposit
    /// </summary>
    Task<InboundCheckDeposit> Return(
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Return(InboundCheckDepositReturnParams, CancellationToken)"/>
    Task<InboundCheckDeposit> Return(
        string inboundCheckDepositID,
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundCheckDepositService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundCheckDepositServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundCheckDepositServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_check_deposits/{inbound_check_deposit_id}</c>, but is otherwise the
    /// same as <see cref="IInboundCheckDepositService.Retrieve(InboundCheckDepositRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundCheckDeposit>> Retrieve(
        InboundCheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundCheckDepositRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundCheckDeposit>> Retrieve(
        string inboundCheckDepositID,
        InboundCheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_check_deposits</c>, but is otherwise the
    /// same as <see cref="IInboundCheckDepositService.List(InboundCheckDepositListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundCheckDepositListPage>> List(
        InboundCheckDepositListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_check_deposits/{inbound_check_deposit_id}/decline</c>, but is otherwise the
    /// same as <see cref="IInboundCheckDepositService.Decline(InboundCheckDepositDeclineParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundCheckDeposit>> Decline(
        InboundCheckDepositDeclineParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Decline(InboundCheckDepositDeclineParams, CancellationToken)"/>
    Task<HttpResponse<InboundCheckDeposit>> Decline(
        string inboundCheckDepositID,
        InboundCheckDepositDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_check_deposits/{inbound_check_deposit_id}/return</c>, but is otherwise the
    /// same as <see cref="IInboundCheckDepositService.Return(InboundCheckDepositReturnParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundCheckDeposit>> Return(
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Return(InboundCheckDepositReturnParams, CancellationToken)"/>
    Task<HttpResponse<InboundCheckDeposit>> Return(
        string inboundCheckDepositID,
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    );
}
