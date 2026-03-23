using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class BookkeepingAccountService : IBookkeepingAccountService
{
    readonly Lazy<IBookkeepingAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBookkeepingAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IBookkeepingAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BookkeepingAccountService(this._client.WithOptions(modifier));
    }

    public BookkeepingAccountService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new BookkeepingAccountServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BookkeepingAccount> Create(
        BookkeepingAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BookkeepingAccount> Update(
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BookkeepingAccount> Update(
        string bookkeepingAccountID,
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                BookkeepingAccountID = bookkeepingAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BookkeepingAccountListPage> List(
        BookkeepingAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BookkeepingBalanceLookup> Balance(
        BookkeepingAccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Balance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BookkeepingBalanceLookup> Balance(
        string bookkeepingAccountID,
        BookkeepingAccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Balance(
            parameters with
            {
                BookkeepingAccountID = bookkeepingAccountID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class BookkeepingAccountServiceWithRawResponse
    : IBookkeepingAccountServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBookkeepingAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BookkeepingAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BookkeepingAccountServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingAccount>> Create(
        BookkeepingAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BookkeepingAccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bookkeepingAccount = await response
                    .Deserialize<BookkeepingAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bookkeepingAccount.Validate();
                }
                return bookkeepingAccount;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingAccount>> Update(
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BookkeepingAccountID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.BookkeepingAccountID' cannot be null"
            );
        }

        HttpRequest<BookkeepingAccountUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bookkeepingAccount = await response
                    .Deserialize<BookkeepingAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bookkeepingAccount.Validate();
                }
                return bookkeepingAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BookkeepingAccount>> Update(
        string bookkeepingAccountID,
        BookkeepingAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                BookkeepingAccountID = bookkeepingAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingAccountListPage>> List(
        BookkeepingAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BookkeepingAccountListParams> request = new()
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
                    .Deserialize<BookkeepingAccountListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BookkeepingAccountListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingBalanceLookup>> Balance(
        BookkeepingAccountBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BookkeepingAccountID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.BookkeepingAccountID' cannot be null"
            );
        }

        HttpRequest<BookkeepingAccountBalanceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bookkeepingBalanceLookup = await response
                    .Deserialize<BookkeepingBalanceLookup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bookkeepingBalanceLookup.Validate();
                }
                return bookkeepingBalanceLookup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BookkeepingBalanceLookup>> Balance(
        string bookkeepingAccountID,
        BookkeepingAccountBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Balance(
            parameters with
            {
                BookkeepingAccountID = bookkeepingAccountID,
            },
            cancellationToken
        );
    }
}
