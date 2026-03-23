using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundCheckDeposits;
using Increase.Api.Models.Simulations.InboundCheckDeposits;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates an Inbound Check Deposit against your account. This imitates someone
    /// depositing a check at their bank that was issued from your account. It may or
    /// may not be associated with a Check Transfer. Increase will evaluate the Inbound
    /// Check Deposit as we would in production and either create a Transaction or a
    /// Declined Transaction as a result. You can inspect the resulting Inbound Check
    /// Deposit object to see the result.
    /// </summary>
    Task<InboundCheckDeposit> Create(
        InboundCheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates an adjustment on an Inbound Check Deposit. The Inbound Check Deposit
    /// must have a `status` of `accepted`.
    /// </summary>
    Task<InboundCheckDeposit> Adjustment(
        InboundCheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Adjustment(InboundCheckDepositAdjustmentParams, CancellationToken)"/>
    Task<InboundCheckDeposit> Adjustment(
        string inboundCheckDepositID,
        InboundCheckDepositAdjustmentParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/inbound_check_deposits</c>, but is otherwise the
    /// same as <see cref="IInboundCheckDepositService.Create(InboundCheckDepositCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundCheckDeposit>> Create(
        InboundCheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/inbound_check_deposits/{inbound_check_deposit_id}/adjustment</c>, but is otherwise the
    /// same as <see cref="IInboundCheckDepositService.Adjustment(InboundCheckDepositAdjustmentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundCheckDeposit>> Adjustment(
        InboundCheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Adjustment(InboundCheckDepositAdjustmentParams, CancellationToken)"/>
    Task<HttpResponse<InboundCheckDeposit>> Adjustment(
        string inboundCheckDepositID,
        InboundCheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
