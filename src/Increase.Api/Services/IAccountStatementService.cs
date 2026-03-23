using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AccountStatements;

namespace Increase.Api.Services;

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
    /// Retrieve an Account Statement
    /// </summary>
    Task<AccountStatement> Retrieve(
        AccountStatementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountStatementRetrieveParams, CancellationToken)"/>
    Task<AccountStatement> Retrieve(
        string accountStatementID,
        AccountStatementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Account Statements
    /// </summary>
    Task<AccountStatementListPage> List(
        AccountStatementListParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /account_statements/{account_statement_id}</c>, but is otherwise the
    /// same as <see cref="IAccountStatementService.Retrieve(AccountStatementRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountStatement>> Retrieve(
        AccountStatementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountStatementRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountStatement>> Retrieve(
        string accountStatementID,
        AccountStatementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /account_statements</c>, but is otherwise the
    /// same as <see cref="IAccountStatementService.List(AccountStatementListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountStatementListPage>> List(
        AccountStatementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
