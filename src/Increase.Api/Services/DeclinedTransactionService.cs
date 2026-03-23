using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DeclinedTransactions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class DeclinedTransactionService : IDeclinedTransactionService
{
    readonly Lazy<IDeclinedTransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDeclinedTransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IDeclinedTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DeclinedTransactionService(this._client.WithOptions(modifier));
    }

    public DeclinedTransactionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new DeclinedTransactionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<DeclinedTransaction> Retrieve(
        DeclinedTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeclinedTransaction> Retrieve(
        string declinedTransactionID,
        DeclinedTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DeclinedTransactionID = declinedTransactionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DeclinedTransactionListPage> List(
        DeclinedTransactionListParams? parameters = null,
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
public sealed class DeclinedTransactionServiceWithRawResponse
    : IDeclinedTransactionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDeclinedTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DeclinedTransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DeclinedTransactionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeclinedTransaction>> Retrieve(
        DeclinedTransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeclinedTransactionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.DeclinedTransactionID' cannot be null"
            );
        }

        HttpRequest<DeclinedTransactionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var declinedTransaction = await response
                    .Deserialize<DeclinedTransaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    declinedTransaction.Validate();
                }
                return declinedTransaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeclinedTransaction>> Retrieve(
        string declinedTransactionID,
        DeclinedTransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DeclinedTransactionID = declinedTransactionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeclinedTransactionListPage>> List(
        DeclinedTransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DeclinedTransactionListParams> request = new()
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
                    .Deserialize<DeclinedTransactionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DeclinedTransactionListPage(this, parameters, page);
            }
        );
    }
}
