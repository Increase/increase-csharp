using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an Account Number
    /// </summary>
    Task<AccountNumber> Create(
        AccountNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Account Number
    /// </summary>
    Task<AccountNumber> Retrieve(
        AccountNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountNumberRetrieveParams, CancellationToken)"/>
    Task<AccountNumber> Retrieve(
        string accountNumberID,
        AccountNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an Account Number
    /// </summary>
    Task<AccountNumber> Update(
        AccountNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountNumberUpdateParams, CancellationToken)"/>
    Task<AccountNumber> Update(
        string accountNumberID,
        AccountNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Account Numbers
    /// </summary>
    Task<AccountNumberListPage> List(
        AccountNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountNumberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /account_numbers</c>, but is otherwise the
    /// same as <see cref="IAccountNumberService.Create(AccountNumberCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountNumber>> Create(
        AccountNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /account_numbers/{account_number_id}</c>, but is otherwise the
    /// same as <see cref="IAccountNumberService.Retrieve(AccountNumberRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountNumber>> Retrieve(
        AccountNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountNumber>> Retrieve(
        string accountNumberID,
        AccountNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /account_numbers/{account_number_id}</c>, but is otherwise the
    /// same as <see cref="IAccountNumberService.Update(AccountNumberUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountNumber>> Update(
        AccountNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountNumberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AccountNumber>> Update(
        string accountNumberID,
        AccountNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /account_numbers</c>, but is otherwise the
    /// same as <see cref="IAccountNumberService.List(AccountNumberListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountNumberListPage>> List(
        AccountNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
