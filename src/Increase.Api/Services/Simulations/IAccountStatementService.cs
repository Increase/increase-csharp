using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AccountStatements;
using Increase.Api.Models.Simulations.AccountStatements;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountStatementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountStatementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountStatementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates an [Account Statement](#account-statements) being created for an
    /// account. In production, Account Statements are generated once per month.
    /// </summary>
    Task<AccountStatement> Create(
        AccountStatementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountStatementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountStatementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountStatementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/account_statements</c>, but is otherwise the
    /// same as <see cref="IAccountStatementService.Create(AccountStatementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountStatement>> Create(
        AccountStatementCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
