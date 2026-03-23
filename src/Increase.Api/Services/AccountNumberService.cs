using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class AccountNumberService : IAccountNumberService
{
    readonly Lazy<IAccountNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountNumberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountNumberService(this._client.WithOptions(modifier));
    }

    public AccountNumberService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountNumberServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountNumber> Create(
        AccountNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountNumber> Retrieve(
        AccountNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountNumber> Retrieve(
        string accountNumberID,
        AccountNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AccountNumberID = accountNumberID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AccountNumber> Update(
        AccountNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountNumber> Update(
        string accountNumberID,
        AccountNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                AccountNumberID = accountNumberID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AccountNumberListPage> List(
        AccountNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AccountNumberServiceWithRawResponse : IAccountNumberServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountNumberServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountNumber>> Create(
        AccountNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountNumberCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountNumber = await response
                    .Deserialize<AccountNumber>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountNumber.Validate();
                }
                return accountNumber;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountNumber>> Retrieve(
        AccountNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountNumberID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountNumberID' cannot be null");
        }

        HttpRequest<AccountNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountNumber = await response
                    .Deserialize<AccountNumber>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountNumber.Validate();
                }
                return accountNumber;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountNumber>> Retrieve(
        string accountNumberID,
        AccountNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AccountNumberID = accountNumberID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountNumber>> Update(
        AccountNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountNumberID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountNumberID' cannot be null");
        }

        HttpRequest<AccountNumberUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountNumber = await response
                    .Deserialize<AccountNumber>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountNumber.Validate();
                }
                return accountNumber;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountNumber>> Update(
        string accountNumberID,
        AccountNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                AccountNumberID = accountNumberID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountNumberListPage>> List(
        AccountNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<AccountNumberListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AccountNumberListPage(this, parameters, page);
            }
        );
    }
}
