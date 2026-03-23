using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardPayments;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CardPaymentService : ICardPaymentService
{
    readonly Lazy<ICardPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardPaymentService(this._client.WithOptions(modifier));
    }

    public CardPaymentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CardPaymentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Retrieve(
        CardPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardPayment> Retrieve(
        string cardPaymentID,
        CardPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardPaymentID = cardPaymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CardPaymentListPage> List(
        CardPaymentListParams? parameters = null,
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
public sealed class CardPaymentServiceWithRawResponse : ICardPaymentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardPaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardPaymentServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Retrieve(
        CardPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardPaymentID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardPaymentID' cannot be null");
        }

        HttpRequest<CardPaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<CardPayment>> Retrieve(
        string cardPaymentID,
        CardPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardPaymentID = cardPaymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPaymentListPage>> List(
        CardPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardPaymentListParams> request = new()
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
                    .Deserialize<CardPaymentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardPaymentListPage(this, parameters, page);
            }
        );
    }
}
