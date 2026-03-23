using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Accounts;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an Account
    /// </summary>
    Task<Account> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Account
    /// </summary>
    Task<Account> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<Account> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an Account
    /// </summary>
    Task<Account> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<Account> Update(
        string accountID,
        AccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Accounts
    /// </summary>
    Task<AccountListPage> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the current and available balances for an account in minor units of the
    /// account's currency. Learn more about [account balances](/documentation/balance).
    /// </summary>
    Task<BalanceLookup> Balance(
        AccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Balance(AccountBalanceParams, CancellationToken)"/>
    Task<BalanceLookup> Balance(
        string accountID,
        AccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Close an Account
    /// </summary>
    Task<Account> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Close(AccountCloseParams, CancellationToken)"/>
    Task<Account> Close(
        string accountID,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.Create(AccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Account>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /accounts/{account_id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Account>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Account>> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /accounts/{account_id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Update(AccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Account>> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Account>> Update(
        string accountID,
        AccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.List(AccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountListPage>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /accounts/{account_id}/balance</c>, but is otherwise the
    /// same as <see cref="IAccountService.Balance(AccountBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BalanceLookup>> Balance(
        AccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Balance(AccountBalanceParams, CancellationToken)"/>
    Task<HttpResponse<BalanceLookup>> Balance(
        string accountID,
        AccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /accounts/{account_id}/close</c>, but is otherwise the
    /// same as <see cref="IAccountService.Close(AccountCloseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Account>> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Close(AccountCloseParams, CancellationToken)"/>
    Task<HttpResponse<Account>> Close(
        string accountID,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
