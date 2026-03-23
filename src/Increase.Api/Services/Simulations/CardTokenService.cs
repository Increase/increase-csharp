using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardTokens;
using Increase.Api.Models.Simulations.CardTokens;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardTokenService : ICardTokenService
{
    readonly Lazy<ICardTokenServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardTokenServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardTokenService(this._client.WithOptions(modifier));
    }

    public CardTokenService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CardTokenServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CardToken> Create(
        CardTokenCreateParams? parameters = null,
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
public sealed class CardTokenServiceWithRawResponse : ICardTokenServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardTokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardTokenServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardTokenServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardToken>> Create(
        CardTokenCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardTokenCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardToken = await response.Deserialize<CardToken>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardToken.Validate();
                }
                return cardToken;
            }
        );
    }
}
