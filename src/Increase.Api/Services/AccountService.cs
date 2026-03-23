using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Accounts;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Account> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Account> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Account> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Account> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Account> Update(
        string accountID,
        AccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountListPage> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BalanceLookup> Balance(
        AccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Balance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BalanceLookup> Balance(
        string accountID,
        AccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Balance(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Account> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Close(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Account> Close(
        string accountID,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Close(parameters with { AccountID = accountID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Account>> Retrieve(
        string accountID,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Account>> Update(
        string accountID,
        AccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountListPage>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountListParams> request = new()
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
                    .Deserialize<AccountListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AccountListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BalanceLookup>> Balance(
        AccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountBalanceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var balanceLookup = await response
                    .Deserialize<BalanceLookup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    balanceLookup.Validate();
                }
                return balanceLookup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BalanceLookup>> Balance(
        string accountID,
        AccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Balance(parameters with { AccountID = accountID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<AccountCloseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Account>> Close(
        string accountID,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Close(parameters with { AccountID = accountID }, cancellationToken);
    }
}
