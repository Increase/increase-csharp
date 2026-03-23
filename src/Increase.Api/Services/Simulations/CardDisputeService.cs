using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardDisputes;
using Increase.Api.Models.Simulations.CardDisputes;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardDisputeService : ICardDisputeService
{
    readonly Lazy<ICardDisputeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardDisputeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardDisputeService(this._client.WithOptions(modifier));
    }

    public CardDisputeService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CardDisputeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CardDispute> Action(
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Action(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardDispute> Action(
        string cardDisputeID,
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Action(parameters with { CardDisputeID = cardDisputeID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CardDisputeServiceWithRawResponse : ICardDisputeServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardDisputeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardDisputeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardDisputeServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardDispute>> Action(
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardDisputeID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardDisputeID' cannot be null");
        }

        HttpRequest<CardDisputeActionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardDispute = await response
                    .Deserialize<CardDispute>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardDispute.Validate();
                }
                return cardDispute;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardDispute>> Action(
        string cardDisputeID,
        CardDisputeActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Action(parameters with { CardDisputeID = cardDisputeID }, cancellationToken);
    }
}
