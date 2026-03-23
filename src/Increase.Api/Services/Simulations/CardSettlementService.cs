using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardSettlements;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardSettlementService : ICardSettlementService
{
    readonly Lazy<ICardSettlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardSettlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardSettlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardSettlementService(this._client.WithOptions(modifier));
    }

    public CardSettlementService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardSettlementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Transaction> Create(
        CardSettlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CardSettlementServiceWithRawResponse : ICardSettlementServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardSettlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardSettlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardSettlementServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Transaction>> Create(
        CardSettlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardSettlementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
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
}
