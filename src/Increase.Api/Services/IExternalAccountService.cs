using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an External Account
    /// </summary>
    Task<ExternalAccount> Create(
        ExternalAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an External Account
    /// </summary>
    Task<ExternalAccount> Retrieve(
        ExternalAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalAccountRetrieveParams, CancellationToken)"/>
    Task<ExternalAccount> Retrieve(
        string externalAccountID,
        ExternalAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an External Account
    /// </summary>
    Task<ExternalAccount> Update(
        ExternalAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalAccountUpdateParams, CancellationToken)"/>
    Task<ExternalAccount> Update(
        string externalAccountID,
        ExternalAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List External Accounts
    /// </summary>
    Task<ExternalAccountListPage> List(
        ExternalAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /external_accounts</c>, but is otherwise the
    /// same as <see cref="IExternalAccountService.Create(ExternalAccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalAccount>> Create(
        ExternalAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /external_accounts/{external_account_id}</c>, but is otherwise the
    /// same as <see cref="IExternalAccountService.Retrieve(ExternalAccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalAccount>> Retrieve(
        ExternalAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ExternalAccount>> Retrieve(
        string externalAccountID,
        ExternalAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /external_accounts/{external_account_id}</c>, but is otherwise the
    /// same as <see cref="IExternalAccountService.Update(ExternalAccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalAccount>> Update(
        ExternalAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ExternalAccount>> Update(
        string externalAccountID,
        ExternalAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /external_accounts</c>, but is otherwise the
    /// same as <see cref="IExternalAccountService.List(ExternalAccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalAccountListPage>> List(
        ExternalAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
