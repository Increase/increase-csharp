using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardAuthorizations;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardAuthorizationService : ICardAuthorizationService
{
    readonly Lazy<ICardAuthorizationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardAuthorizationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardAuthorizationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardAuthorizationService(this._client.WithOptions(modifier));
    }

    public CardAuthorizationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardAuthorizationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardAuthorizationCreateResponse> Create(
        CardAuthorizationCreateParams parameters,
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
public sealed class CardAuthorizationServiceWithRawResponse
    : ICardAuthorizationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardAuthorizationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardAuthorizationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardAuthorizationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardAuthorizationCreateResponse>> Create(
        CardAuthorizationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardAuthorizationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardAuthorization = await response
                    .Deserialize<CardAuthorizationCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardAuthorization.Validate();
                }
                return cardAuthorization;
            }
        );
    }
}
