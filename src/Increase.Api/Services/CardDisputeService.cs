using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Services;

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
    public async Task<CardDispute> Create(
        CardDisputeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardDispute> Retrieve(
        CardDisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardDispute> Retrieve(
        string cardDisputeID,
        CardDisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardDisputeID = cardDisputeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CardDisputeListPage> List(
        CardDisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardDispute> SubmitUserSubmission(
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SubmitUserSubmission(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardDispute> SubmitUserSubmission(
        string cardDisputeID,
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitUserSubmission(
            parameters with
            {
                CardDisputeID = cardDisputeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CardDispute> Withdraw(
        CardDisputeWithdrawParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Withdraw(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardDispute> Withdraw(
        string cardDisputeID,
        CardDisputeWithdrawParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Withdraw(parameters with { CardDisputeID = cardDisputeID }, cancellationToken);
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
    public async Task<HttpResponse<CardDispute>> Create(
        CardDisputeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CardDisputeCreateParams> request = new()
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
    public async Task<HttpResponse<CardDispute>> Retrieve(
        CardDisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardDisputeID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardDisputeID' cannot be null");
        }

        HttpRequest<CardDisputeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<CardDispute>> Retrieve(
        string cardDisputeID,
        CardDisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardDisputeID = cardDisputeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardDisputeListPage>> List(
        CardDisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardDisputeListParams> request = new()
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
                    .Deserialize<CardDisputeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardDisputeListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardDispute>> SubmitUserSubmission(
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardDisputeID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardDisputeID' cannot be null");
        }

        HttpRequest<CardDisputeSubmitUserSubmissionParams> request = new()
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
    public Task<HttpResponse<CardDispute>> SubmitUserSubmission(
        string cardDisputeID,
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitUserSubmission(
            parameters with
            {
                CardDisputeID = cardDisputeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardDispute>> Withdraw(
        CardDisputeWithdrawParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardDisputeID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardDisputeID' cannot be null");
        }

        HttpRequest<CardDisputeWithdrawParams> request = new()
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
    public Task<HttpResponse<CardDispute>> Withdraw(
        string cardDisputeID,
        CardDisputeWithdrawParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Withdraw(parameters with { CardDisputeID = cardDisputeID }, cancellationToken);
    }
}
