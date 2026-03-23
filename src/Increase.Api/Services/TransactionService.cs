using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class TransactionService : ITransactionService
{
    readonly Lazy<ITransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ITransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransactionService(this._client.WithOptions(modifier));
    }

    public TransactionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TransactionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Transaction> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Transaction> Retrieve(
        string transactionID,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TransactionID = transactionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionListPage> List(
        TransactionListParams? parameters = null,
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
public sealed class TransactionServiceWithRawResponse : ITransactionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransactionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Transaction>> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TransactionID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.TransactionID' cannot be null");
        }

        HttpRequest<TransactionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transaction = await response
                    .Deserialize<Transaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transaction.Validate();
                }
                return transaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Transaction>> Retrieve(
        string transactionID,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TransactionID = transactionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionListPage>> List(
        TransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TransactionListParams> request = new()
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
                    .Deserialize<TransactionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TransactionListPage(this, parameters, page);
            }
        );
    }
}
