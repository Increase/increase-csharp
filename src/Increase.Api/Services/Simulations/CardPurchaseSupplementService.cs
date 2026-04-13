using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPurchaseSupplements;
using Increase.Api.Models.Simulations.CardPurchaseSupplements;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardPurchaseSupplementService : ICardPurchaseSupplementService
{
    readonly Lazy<ICardPurchaseSupplementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardPurchaseSupplementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardPurchaseSupplementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardPurchaseSupplementService(this._client.WithOptions(modifier));
    }

    public CardPurchaseSupplementService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardPurchaseSupplementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPurchaseSupplement> Create(
        CardPurchaseSupplementCreateParams parameters,
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
public sealed class CardPurchaseSupplementServiceWithRawResponse
    : ICardPurchaseSupplementServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardPurchaseSupplementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardPurchaseSupplementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardPurchaseSupplementServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPurchaseSupplement>> Create(
        CardPurchaseSupplementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardPurchaseSupplementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardPurchaseSupplement = await response
                    .Deserialize<CardPurchaseSupplement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardPurchaseSupplement.Validate();
                }
                return cardPurchaseSupplement;
            }
        );
    }
}
