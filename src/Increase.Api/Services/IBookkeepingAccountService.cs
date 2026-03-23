using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBookkeepingAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBookkeepingAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookkeepingAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Bookkeeping Account
    /// </summary>
    Task<BookkeepingAccount> Create(
        BookkeepingAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Bookkeeping Account
    /// </summary>
    Task<BookkeepingAccount> Update(
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BookkeepingAccountUpdateParams, CancellationToken)"/>
    Task<BookkeepingAccount> Update(
        string bookkeepingAccountID,
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Bookkeeping Accounts
    /// </summary>
    Task<BookkeepingAccountListPage> List(
        BookkeepingAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Bookkeeping Account Balance
    /// </summary>
    Task<BookkeepingBalanceLookup> Balance(
        BookkeepingAccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Balance(BookkeepingAccountBalanceParams, CancellationToken)"/>
    Task<BookkeepingBalanceLookup> Balance(
        string bookkeepingAccountID,
        BookkeepingAccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBookkeepingAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBookkeepingAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookkeepingAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /bookkeeping_accounts</c>, but is otherwise the
    /// same as <see cref="IBookkeepingAccountService.Create(BookkeepingAccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingAccount>> Create(
        BookkeepingAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /bookkeeping_accounts/{bookkeeping_account_id}</c>, but is otherwise the
    /// same as <see cref="IBookkeepingAccountService.Update(BookkeepingAccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingAccount>> Update(
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BookkeepingAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BookkeepingAccount>> Update(
        string bookkeepingAccountID,
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bookkeeping_accounts</c>, but is otherwise the
    /// same as <see cref="IBookkeepingAccountService.List(BookkeepingAccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingAccountListPage>> List(
        BookkeepingAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bookkeeping_accounts/{bookkeeping_account_id}/balance</c>, but is otherwise the
    /// same as <see cref="IBookkeepingAccountService.Balance(BookkeepingAccountBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingBalanceLookup>> Balance(
        BookkeepingAccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Balance(BookkeepingAccountBalanceParams, CancellationToken)"/>
    Task<HttpResponse<BookkeepingBalanceLookup>> Balance(
        string bookkeepingAccountID,
        BookkeepingAccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
