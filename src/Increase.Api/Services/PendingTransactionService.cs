using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class PendingTransactionService : IPendingTransactionService
{
    readonly Lazy<IPendingTransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPendingTransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IPendingTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PendingTransactionService(this._client.WithOptions(modifier));
    }

    public PendingTransactionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PendingTransactionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PendingTransaction> Create(
        PendingTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PendingTransaction> Retrieve(
        PendingTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PendingTransaction> Retrieve(
        string pendingTransactionID,
        PendingTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                PendingTransactionID = pendingTransactionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<PendingTransactionListPage> List(
        PendingTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PendingTransaction> Release(
        PendingTransactionReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Release(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PendingTransaction> Release(
        string pendingTransactionID,
        PendingTransactionReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(
            parameters with
            {
                PendingTransactionID = pendingTransactionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class PendingTransactionServiceWithRawResponse
    : IPendingTransactionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPendingTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PendingTransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PendingTransactionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PendingTransaction>> Create(
        PendingTransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PendingTransactionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pendingTransaction = await response
                    .Deserialize<PendingTransaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pendingTransaction.Validate();
                }
                return pendingTransaction;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PendingTransaction>> Retrieve(
        PendingTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PendingTransactionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PendingTransactionID' cannot be null"
            );
        }

        HttpRequest<PendingTransactionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pendingTransaction = await response
                    .Deserialize<PendingTransaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pendingTransaction.Validate();
                }
                return pendingTransaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PendingTransaction>> Retrieve(
        string pendingTransactionID,
        PendingTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                PendingTransactionID = pendingTransactionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PendingTransactionListPage>> List(
        PendingTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PendingTransactionListParams> request = new()
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
                    .Deserialize<PendingTransactionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PendingTransactionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PendingTransaction>> Release(
        PendingTransactionReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PendingTransactionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PendingTransactionID' cannot be null"
            );
        }

        HttpRequest<PendingTransactionReleaseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pendingTransaction = await response
                    .Deserialize<PendingTransaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pendingTransaction.Validate();
                }
                return pendingTransaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PendingTransaction>> Release(
        string pendingTransactionID,
        PendingTransactionReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(
            parameters with
            {
                PendingTransactionID = pendingTransactionID,
            },
            cancellationToken
        );
    }
}
