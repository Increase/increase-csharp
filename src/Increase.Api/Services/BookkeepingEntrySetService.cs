using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class BookkeepingEntrySetService : IBookkeepingEntrySetService
{
    readonly Lazy<IBookkeepingEntrySetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBookkeepingEntrySetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IBookkeepingEntrySetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BookkeepingEntrySetService(this._client.WithOptions(modifier));
    }

    public BookkeepingEntrySetService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new BookkeepingEntrySetServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BookkeepingEntrySet> Create(
        BookkeepingEntrySetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BookkeepingEntrySet> Retrieve(
        BookkeepingEntrySetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BookkeepingEntrySet> Retrieve(
        string bookkeepingEntrySetID,
        BookkeepingEntrySetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                BookkeepingEntrySetID = bookkeepingEntrySetID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BookkeepingEntrySetListPage> List(
        BookkeepingEntrySetListParams? parameters = null,
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
public sealed class BookkeepingEntrySetServiceWithRawResponse
    : IBookkeepingEntrySetServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBookkeepingEntrySetServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BookkeepingEntrySetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BookkeepingEntrySetServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingEntrySet>> Create(
        BookkeepingEntrySetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BookkeepingEntrySetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bookkeepingEntrySet = await response
                    .Deserialize<BookkeepingEntrySet>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bookkeepingEntrySet.Validate();
                }
                return bookkeepingEntrySet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingEntrySet>> Retrieve(
        BookkeepingEntrySetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BookkeepingEntrySetID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.BookkeepingEntrySetID' cannot be null"
            );
        }

        HttpRequest<BookkeepingEntrySetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bookkeepingEntrySet = await response
                    .Deserialize<BookkeepingEntrySet>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bookkeepingEntrySet.Validate();
                }
                return bookkeepingEntrySet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BookkeepingEntrySet>> Retrieve(
        string bookkeepingEntrySetID,
        BookkeepingEntrySetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                BookkeepingEntrySetID = bookkeepingEntrySetID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingEntrySetListPage>> List(
        BookkeepingEntrySetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BookkeepingEntrySetListParams> request = new()
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
                    .Deserialize<BookkeepingEntrySetListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BookkeepingEntrySetListPage(this, parameters, page);
            }
        );
    }
}
