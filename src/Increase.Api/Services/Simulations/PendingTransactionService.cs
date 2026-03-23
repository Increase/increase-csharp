using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PendingTransactions;
using Increase.Api.Models.Simulations.PendingTransactions;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class PendingTransactionService : IPendingTransactionService
{
    readonly Lazy<IPendingTransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPendingTransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IPendingTransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PendingTransactionService(this._client.WithOptions(modifier));
    }

    public PendingTransactionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PendingTransactionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PendingTransaction> ReleaseInboundFundsHold(
        PendingTransactionReleaseInboundFundsHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ReleaseInboundFundsHold(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PendingTransaction> ReleaseInboundFundsHold(
        string pendingTransactionID,
        PendingTransactionReleaseInboundFundsHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ReleaseInboundFundsHold(
            parameters with
            {
                PendingTransactionID = pendingTransactionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class PendingTransactionServiceWithRawResponse
    : IPendingTransactionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPendingTransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PendingTransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PendingTransactionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PendingTransaction>> ReleaseInboundFundsHold(
        PendingTransactionReleaseInboundFundsHoldParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PendingTransactionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PendingTransactionID' cannot be null"
            );
        }

        HttpRequest<PendingTransactionReleaseInboundFundsHoldParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pendingTransaction = await response
                    .Deserialize<PendingTransaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pendingTransaction.Validate();
                }
                return pendingTransaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PendingTransaction>> ReleaseInboundFundsHold(
        string pendingTransactionID,
        PendingTransactionReleaseInboundFundsHoldParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ReleaseInboundFundsHold(
            parameters with
            {
                PendingTransactionID = pendingTransactionID,
            },
            cancellationToken
        );
    }
}
