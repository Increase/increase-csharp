using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Cards;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CardService : ICardService
{
    readonly Lazy<ICardServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardService(this._client.WithOptions(modifier));
    }

    public CardService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CardServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Card> Create(
        CardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Card> Retrieve(
        CardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Card> Retrieve(
        string cardID,
        CardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Card> Update(
        CardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Card> Update(
        string cardID,
        CardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CardListPage> List(
        CardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardIframeUrl> CreateDetailsIframe(
        CardCreateDetailsIframeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateDetailsIframe(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardIframeUrl> CreateDetailsIframe(
        string cardID,
        CardCreateDetailsIframeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDetailsIframe(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CardDetails> Details(
        CardDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Details(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardDetails> Details(
        string cardID,
        CardDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Details(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CardDetails> UpdatePin(
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdatePin(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardDetails> UpdatePin(
        string cardID,
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdatePin(parameters with { CardID = cardID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CardServiceWithRawResponse : ICardServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Card>> Create(
        CardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var card = await response.Deserialize<Card>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    card.Validate();
                }
                return card;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Card>> Retrieve(
        CardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardID' cannot be null");
        }

        HttpRequest<CardRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var card = await response.Deserialize<Card>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    card.Validate();
                }
                return card;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Card>> Retrieve(
        string cardID,
        CardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Card>> Update(
        CardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardID' cannot be null");
        }

        HttpRequest<CardUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var card = await response.Deserialize<Card>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    card.Validate();
                }
                return card;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Card>> Update(
        string cardID,
        CardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardListPage>> List(
        CardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardListParams> request = new()
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
                    .Deserialize<CardListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardIframeUrl>> CreateDetailsIframe(
        CardCreateDetailsIframeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardID' cannot be null");
        }

        HttpRequest<CardCreateDetailsIframeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardIframeUrl = await response
                    .Deserialize<CardIframeUrl>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardIframeUrl.Validate();
                }
                return cardIframeUrl;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardIframeUrl>> CreateDetailsIframe(
        string cardID,
        CardCreateDetailsIframeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDetailsIframe(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardDetails>> Details(
        CardDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardID' cannot be null");
        }

        HttpRequest<CardDetailsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardDetails = await response
                    .Deserialize<CardDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardDetails.Validate();
                }
                return cardDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardDetails>> Details(
        string cardID,
        CardDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Details(parameters with { CardID = cardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardDetails>> UpdatePin(
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardID' cannot be null");
        }

        HttpRequest<CardUpdatePinParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardDetails = await response
                    .Deserialize<CardDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardDetails.Validate();
                }
                return cardDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardDetails>> UpdatePin(
        string cardID,
        CardUpdatePinParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdatePin(parameters with { CardID = cardID }, cancellationToken);
    }
}
