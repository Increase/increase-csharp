using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class AccountTransferService : IAccountTransferService
{
    readonly Lazy<IAccountTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountTransferService(this._client.WithOptions(modifier));
    }

    public AccountTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountTransfer> Create(
        AccountTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountTransfer> Retrieve(
        AccountTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountTransfer> Retrieve(
        string accountTransferID,
        AccountTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AccountTransferListPage> List(
        AccountTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountTransfer> Approve(
        AccountTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountTransfer> Approve(
        string accountTransferID,
        AccountTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AccountTransfer> Cancel(
        AccountTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountTransfer> Cancel(
        string accountTransferID,
        AccountTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class AccountTransferServiceWithRawResponse : IAccountTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransfer>> Create(
        AccountTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountTransfer = await response
                    .Deserialize<AccountTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountTransfer.Validate();
                }
                return accountTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransfer>> Retrieve(
        AccountTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountTransferID' cannot be null");
        }

        HttpRequest<AccountTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountTransfer = await response
                    .Deserialize<AccountTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountTransfer.Validate();
                }
                return accountTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountTransfer>> Retrieve(
        string accountTransferID,
        AccountTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransferListPage>> List(
        AccountTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountTransferListParams> request = new()
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
                    .Deserialize<AccountTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AccountTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransfer>> Approve(
        AccountTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountTransferID' cannot be null");
        }

        HttpRequest<AccountTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountTransfer = await response
                    .Deserialize<AccountTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountTransfer.Validate();
                }
                return accountTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountTransfer>> Approve(
        string accountTransferID,
        AccountTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransfer>> Cancel(
        AccountTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountTransferID' cannot be null");
        }

        HttpRequest<AccountTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountTransfer = await response
                    .Deserialize<AccountTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountTransfer.Validate();
                }
                return accountTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountTransfer>> Cancel(
        string accountTransferID,
        AccountTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }
}
