using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardValidations;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CardValidationService : ICardValidationService
{
    readonly Lazy<ICardValidationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardValidationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardValidationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardValidationService(this._client.WithOptions(modifier));
    }

    public CardValidationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardValidationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardValidation> Create(
        CardValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardValidation> Retrieve(
        CardValidationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardValidation> Retrieve(
        string cardValidationID,
        CardValidationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CardValidationID = cardValidationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CardValidationListPage> List(
        CardValidationListParams? parameters = null,
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
public sealed class CardValidationServiceWithRawResponse : ICardValidationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardValidationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardValidationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardValidationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardValidation>> Create(
        CardValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardValidationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardValidation = await response
                    .Deserialize<CardValidation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardValidation.Validate();
                }
                return cardValidation;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardValidation>> Retrieve(
        CardValidationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardValidationID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardValidationID' cannot be null");
        }

        HttpRequest<CardValidationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardValidation = await response
                    .Deserialize<CardValidation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardValidation.Validate();
                }
                return cardValidation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardValidation>> Retrieve(
        string cardValidationID,
        CardValidationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CardValidationID = cardValidationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardValidationListPage>> List(
        CardValidationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardValidationListParams> request = new()
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
                    .Deserialize<CardValidationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardValidationListPage(this, parameters, page);
            }
        );
    }
}
