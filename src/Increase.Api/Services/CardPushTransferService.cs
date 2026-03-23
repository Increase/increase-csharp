using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CardPushTransferService : ICardPushTransferService
{
    readonly Lazy<ICardPushTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardPushTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardPushTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardPushTransferService(this._client.WithOptions(modifier));
    }

    public CardPushTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardPushTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPushTransfer> Create(
        CardPushTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardPushTransfer> Retrieve(
        CardPushTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPushTransfer> Retrieve(
        string cardPushTransferID,
        CardPushTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CardPushTransferID = cardPushTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CardPushTransferListPage> List(
        CardPushTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardPushTransfer> Approve(
        CardPushTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPushTransfer> Approve(
        string cardPushTransferID,
        CardPushTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                CardPushTransferID = cardPushTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CardPushTransfer> Cancel(
        CardPushTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPushTransfer> Cancel(
        string cardPushTransferID,
        CardPushTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                CardPushTransferID = cardPushTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class CardPushTransferServiceWithRawResponse : ICardPushTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardPushTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardPushTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardPushTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPushTransfer>> Create(
        CardPushTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardPushTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardPushTransfer = await response
                    .Deserialize<CardPushTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardPushTransfer.Validate();
                }
                return cardPushTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPushTransfer>> Retrieve(
        CardPushTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPushTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.CardPushTransferID' cannot be null"
            );
        }

        HttpRequest<CardPushTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardPushTransfer = await response
                    .Deserialize<CardPushTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardPushTransfer.Validate();
                }
                return cardPushTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardPushTransfer>> Retrieve(
        string cardPushTransferID,
        CardPushTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CardPushTransferID = cardPushTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPushTransferListPage>> List(
        CardPushTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardPushTransferListParams> request = new()
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
                    .Deserialize<CardPushTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardPushTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPushTransfer>> Approve(
        CardPushTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPushTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.CardPushTransferID' cannot be null"
            );
        }

        HttpRequest<CardPushTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardPushTransfer = await response
                    .Deserialize<CardPushTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardPushTransfer.Validate();
                }
                return cardPushTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardPushTransfer>> Approve(
        string cardPushTransferID,
        CardPushTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                CardPushTransferID = cardPushTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPushTransfer>> Cancel(
        CardPushTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPushTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.CardPushTransferID' cannot be null"
            );
        }

        HttpRequest<CardPushTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardPushTransfer = await response
                    .Deserialize<CardPushTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardPushTransfer.Validate();
                }
                return cardPushTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardPushTransfer>> Cancel(
        string cardPushTransferID,
        CardPushTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                CardPushTransferID = cardPushTransferID,
            },
            cancellationToken
        );
    }
}
