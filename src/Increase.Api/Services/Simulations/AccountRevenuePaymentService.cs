using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.AccountRevenuePayments;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class AccountRevenuePaymentService : IAccountRevenuePaymentService
{
    readonly Lazy<IAccountRevenuePaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountRevenuePaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountRevenuePaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountRevenuePaymentService(this._client.WithOptions(modifier));
    }

    public AccountRevenuePaymentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountRevenuePaymentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Transaction> Create(
        AccountRevenuePaymentCreateParams parameters,
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
public sealed class AccountRevenuePaymentServiceWithRawResponse
    : IAccountRevenuePaymentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountRevenuePaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountRevenuePaymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountRevenuePaymentServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Transaction>> Create(
        AccountRevenuePaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountRevenuePaymentCreateParams> request = new()
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
