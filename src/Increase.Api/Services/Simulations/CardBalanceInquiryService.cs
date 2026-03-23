using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardBalanceInquiries;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CardBalanceInquiryService : ICardBalanceInquiryService
{
    readonly Lazy<ICardBalanceInquiryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardBalanceInquiryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardBalanceInquiryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardBalanceInquiryService(this._client.WithOptions(modifier));
    }

    public CardBalanceInquiryService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CardBalanceInquiryServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CardPayment> Create(
        CardBalanceInquiryCreateParams? parameters = null,
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
public sealed class CardBalanceInquiryServiceWithRawResponse
    : ICardBalanceInquiryServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardBalanceInquiryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CardBalanceInquiryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardBalanceInquiryServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardPayment>> Create(
        CardBalanceInquiryCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardBalanceInquiryCreateParams> request = new()
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
