using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CheckDeposits;
using Increase.Api.Models.Simulations.CheckDeposits;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckDepositService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckDepositServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckDepositService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates the creation of a [Check Deposit
    /// Adjustment](#check-deposit-adjustments) on a [Check Deposit](#check-deposits).
    /// This Check Deposit must first have a `status` of `submitted`.
    /// </summary>
    Task<CheckDeposit> Adjustment(
        CheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Adjustment(CheckDepositAdjustmentParams, CancellationToken)"/>
    Task<CheckDeposit> Adjustment(
        string checkDepositID,
        CheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the rejection of a [Check Deposit](#check-deposits) by Increase due to
    /// factors like poor image quality. This Check Deposit must first have a `status`
    /// of `pending`.
    /// </summary>
    Task<CheckDeposit> Reject(
        CheckDepositRejectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reject(CheckDepositRejectParams, CancellationToken)"/>
    Task<CheckDeposit> Reject(
        string checkDepositID,
        CheckDepositRejectParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the return of a [Check Deposit](#check-deposits). This Check Deposit
    /// must first have a `status` of `submitted`.
    /// </summary>
    Task<CheckDeposit> Return(
        CheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Return(CheckDepositReturnParams, CancellationToken)"/>
    Task<CheckDeposit> Return(
        string checkDepositID,
        CheckDepositReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Simulates the submission of a [Check Deposit](#check-deposits) to the Federal
    /// Reserve. This Check Deposit must first have a `status` of `pending`.
    /// </summary>
    Task<CheckDeposit> Submit(
        CheckDepositSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(CheckDepositSubmitParams, CancellationToken)"/>
    Task<CheckDeposit> Submit(
        string checkDepositID,
        CheckDepositSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckDepositService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckDepositServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckDepositServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/check_deposits/{check_deposit_id}/adjustment</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.Adjustment(CheckDepositAdjustmentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDeposit>> Adjustment(
        CheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Adjustment(CheckDepositAdjustmentParams, CancellationToken)"/>
    Task<HttpResponse<CheckDeposit>> Adjustment(
        string checkDepositID,
        CheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/check_deposits/{check_deposit_id}/reject</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.Reject(CheckDepositRejectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDeposit>> Reject(
        CheckDepositRejectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reject(CheckDepositRejectParams, CancellationToken)"/>
    Task<HttpResponse<CheckDeposit>> Reject(
        string checkDepositID,
        CheckDepositRejectParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/check_deposits/{check_deposit_id}/return</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.Return(CheckDepositReturnParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDeposit>> Return(
        CheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Return(CheckDepositReturnParams, CancellationToken)"/>
    Task<HttpResponse<CheckDeposit>> Return(
        string checkDepositID,
        CheckDepositReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/check_deposits/{check_deposit_id}/submit</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.Submit(CheckDepositSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDeposit>> Submit(
        CheckDepositSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(CheckDepositSubmitParams, CancellationToken)"/>
    Task<HttpResponse<CheckDeposit>> Submit(
        string checkDepositID,
        CheckDepositSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
