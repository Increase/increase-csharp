using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardRefunds;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardRefundService : ICardRefundService
{
    readonly Lazy<ICardRefundServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardRefundServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardRefundService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardRefundService(this._client.WithOptions(modifier));
    }

    public CardRefundService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CardRefundServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Transaction> Create(
        CardRefundCreateParams? parameters = null,
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
public sealed class CardRefundServiceWithRawResponse : ICardRefundServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardRefundServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardRefundServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardRefundServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Transaction>> Create(
        CardRefundCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardRefundCreateParams> request = new()
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
