using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardPurchaseSupplements;

namespace Increase.Api.Services;

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
    public async Task<CardPurchaseSupplement> Retrieve(
        CardPurchaseSupplementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPurchaseSupplement> Retrieve(
        string cardPurchaseSupplementID,
        CardPurchaseSupplementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CardPurchaseSupplementID = cardPurchaseSupplementID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CardPurchaseSupplementListPage> List(
        CardPurchaseSupplementListParams? parameters = null,
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
    public async Task<HttpResponse<CardPurchaseSupplement>> Retrieve(
        CardPurchaseSupplementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPurchaseSupplementID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.CardPurchaseSupplementID' cannot be null"
            );
        }

        HttpRequest<CardPurchaseSupplementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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

    /// <inheritdoc/>
    public Task<HttpResponse<CardPurchaseSupplement>> Retrieve(
        string cardPurchaseSupplementID,
        CardPurchaseSupplementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CardPurchaseSupplementID = cardPurchaseSupplementID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPurchaseSupplementListPage>> List(
        CardPurchaseSupplementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardPurchaseSupplementListParams> request = new()
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
                    .Deserialize<CardPurchaseSupplementListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardPurchaseSupplementListPage(this, parameters, page);
            }
        );
    }
}
