using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.InterestPayments;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InterestPaymentService : IInterestPaymentService
{
    readonly Lazy<IInterestPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInterestPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInterestPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InterestPaymentService(this._client.WithOptions(modifier));
    }

    public InterestPaymentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InterestPaymentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Transaction> Create(
        InterestPaymentCreateParams parameters,
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
public sealed class InterestPaymentServiceWithRawResponse : IInterestPaymentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInterestPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InterestPaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InterestPaymentServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Transaction>> Create(
        InterestPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InterestPaymentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transaction = await response
                    .Deserialize<Transaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transaction.Validate();
                }
                return transaction;
            }
        );
    }
}
