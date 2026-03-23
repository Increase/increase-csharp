using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BookkeepingEntries;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class BookkeepingEntryService : IBookkeepingEntryService
{
    readonly Lazy<IBookkeepingEntryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBookkeepingEntryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IBookkeepingEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BookkeepingEntryService(this._client.WithOptions(modifier));
    }

    public BookkeepingEntryService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new BookkeepingEntryServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BookkeepingEntry> Retrieve(
        BookkeepingEntryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BookkeepingEntry> Retrieve(
        string bookkeepingEntryID,
        BookkeepingEntryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                BookkeepingEntryID = bookkeepingEntryID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BookkeepingEntryListPage> List(
        BookkeepingEntryListParams? parameters = null,
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
public sealed class BookkeepingEntryServiceWithRawResponse : IBookkeepingEntryServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBookkeepingEntryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BookkeepingEntryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BookkeepingEntryServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingEntry>> Retrieve(
        BookkeepingEntryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BookkeepingEntryID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.BookkeepingEntryID' cannot be null"
            );
        }

        HttpRequest<BookkeepingEntryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var bookkeepingEntry = await response
                    .Deserialize<BookkeepingEntry>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    bookkeepingEntry.Validate();
                }
                return bookkeepingEntry;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BookkeepingEntry>> Retrieve(
        string bookkeepingEntryID,
        BookkeepingEntryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                BookkeepingEntryID = bookkeepingEntryID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BookkeepingEntryListPage>> List(
        BookkeepingEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BookkeepingEntryListParams> request = new()
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
                    .Deserialize<BookkeepingEntryListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BookkeepingEntryListPage(this, parameters, page);
            }
        );
    }
}
