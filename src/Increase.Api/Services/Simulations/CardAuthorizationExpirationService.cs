using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardAuthorizationExpirations;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardAuthorizationExpirationService : ICardAuthorizationExpirationService
{
    readonly Lazy<ICardAuthorizationExpirationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardAuthorizationExpirationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardAuthorizationExpirationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardAuthorizationExpirationService(this._client.WithOptions(modifier));
    }

    public CardAuthorizationExpirationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardAuthorizationExpirationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Create(
        CardAuthorizationExpirationCreateParams parameters,
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
public sealed class CardAuthorizationExpirationServiceWithRawResponse
    : ICardAuthorizationExpirationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardAuthorizationExpirationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardAuthorizationExpirationServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public CardAuthorizationExpirationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Create(
        CardAuthorizationExpirationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardAuthorizationExpirationCreateParams> request = new()
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
