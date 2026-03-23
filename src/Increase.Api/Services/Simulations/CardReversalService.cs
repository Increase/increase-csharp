using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardReversals;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardReversalService : ICardReversalService
{
    readonly Lazy<ICardReversalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardReversalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardReversalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardReversalService(this._client.WithOptions(modifier));
    }

    public CardReversalService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardReversalServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Create(
        CardReversalCreateParams parameters,
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
public sealed class CardReversalServiceWithRawResponse : ICardReversalServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardReversalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardReversalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardReversalServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Create(
        CardReversalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardReversalCreateParams> request = new()
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
