using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountStatements;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class AccountStatementService : IAccountStatementService
{
    readonly Lazy<IAccountStatementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountStatementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountStatementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountStatementService(this._client.WithOptions(modifier));
    }

    public AccountStatementService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountStatementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountStatement> Retrieve(
        AccountStatementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountStatement> Retrieve(
        string accountStatementID,
        AccountStatementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AccountStatementID = accountStatementID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AccountStatementListPage> List(
        AccountStatementListParams? parameters = null,
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
public sealed class AccountStatementServiceWithRawResponse : IAccountStatementServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountStatementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountStatementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountStatementServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountStatement>> Retrieve(
        AccountStatementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountStatementID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.AccountStatementID' cannot be null"
            );
        }

        HttpRequest<AccountStatementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountStatement = await response
                    .Deserialize<AccountStatement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountStatement.Validate();
                }
                return accountStatement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountStatement>> Retrieve(
        string accountStatementID,
        AccountStatementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AccountStatementID = accountStatementID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountStatementListPage>> List(
        AccountStatementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountStatementListParams> request = new()
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
                    .Deserialize<AccountStatementListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AccountStatementListPage(this, parameters, page);
            }
        );
    }
}
