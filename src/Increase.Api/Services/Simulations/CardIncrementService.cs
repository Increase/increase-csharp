using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardIncrements;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardIncrementService : ICardIncrementService
{
    readonly Lazy<ICardIncrementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardIncrementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardIncrementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardIncrementService(this._client.WithOptions(modifier));
    }

    public CardIncrementService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardIncrementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Create(
        CardIncrementCreateParams parameters,
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
public sealed class CardIncrementServiceWithRawResponse : ICardIncrementServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardIncrementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardIncrementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardIncrementServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Create(
        CardIncrementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardIncrementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardPayment = await response
                    .Deserialize<CardPayment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardPayment.Validate();
                }
                return cardPayment;
            }
        );
    }
}
