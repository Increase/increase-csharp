using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CheckDeposits;

namespace Increase.Api.Services;

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
    /// Create a Check Deposit
    /// </summary>
    Task<CheckDeposit> Create(
        CheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Check Deposit
    /// </summary>
    Task<CheckDeposit> Retrieve(
        CheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckDepositRetrieveParams, CancellationToken)"/>
    Task<CheckDeposit> Retrieve(
        string checkDepositID,
        CheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Check Deposits
    /// </summary>
    Task<CheckDepositListPage> List(
        CheckDepositListParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /check_deposits</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.Create(CheckDepositCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDeposit>> Create(
        CheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /check_deposits/{check_deposit_id}</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.Retrieve(CheckDepositRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDeposit>> Retrieve(
        CheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckDepositRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CheckDeposit>> Retrieve(
        string checkDepositID,
        CheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /check_deposits</c>, but is otherwise the
    /// same as <see cref="ICheckDepositService.List(CheckDepositListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckDepositListPage>> List(
        CheckDepositListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
