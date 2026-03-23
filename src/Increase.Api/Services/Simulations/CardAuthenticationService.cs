using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardAuthentications;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardAuthenticationService : ICardAuthenticationService
{
    readonly Lazy<ICardAuthenticationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardAuthenticationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardAuthenticationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardAuthenticationService(this._client.WithOptions(modifier));
    }

    public CardAuthenticationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardAuthenticationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Create(
        CardAuthenticationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardPayment> ChallengeAttempts(
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ChallengeAttempts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPayment> ChallengeAttempts(
        string cardPaymentID,
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ChallengeAttempts(
            parameters with
            {
                CardPaymentID = cardPaymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Challenges(
        CardAuthenticationChallengesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Challenges(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPayment> Challenges(
        string cardPaymentID,
        CardAuthenticationChallengesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Challenges(
            parameters with
            {
                CardPaymentID = cardPaymentID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class CardAuthenticationServiceWithRawResponse
    : ICardAuthenticationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardAuthenticationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardAuthenticationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardAuthenticationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Create(
        CardAuthenticationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardAuthenticationCreateParams> request = new()
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

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> ChallengeAttempts(
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPaymentID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardPaymentID' cannot be null");
        }

        HttpRequest<CardAuthenticationChallengeAttemptsParams> request = new()
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

    /// <inheritdoc/>
    public Task<HttpResponse<CardPayment>> ChallengeAttempts(
        string cardPaymentID,
        CardAuthenticationChallengeAttemptsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ChallengeAttempts(
            parameters with
            {
                CardPaymentID = cardPaymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Challenges(
        CardAuthenticationChallengesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPaymentID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardPaymentID' cannot be null");
        }

        HttpRequest<CardAuthenticationChallengesParams> request = new()
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

    /// <inheritdoc/>
    public Task<HttpResponse<CardPayment>> Challenges(
        string cardPaymentID,
        CardAuthenticationChallengesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Challenges(
            parameters with
            {
                CardPaymentID = cardPaymentID,
            },
            cancellationToken
        );
    }
}
