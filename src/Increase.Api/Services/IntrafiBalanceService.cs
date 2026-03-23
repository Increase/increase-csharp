using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.IntrafiBalances;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class IntrafiBalanceService : IIntrafiBalanceService
{
    readonly Lazy<IIntrafiBalanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntrafiBalanceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IIntrafiBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntrafiBalanceService(this._client.WithOptions(modifier));
    }

    public IntrafiBalanceService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new IntrafiBalanceServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<IntrafiBalance> IntrafiBalance(
        IntrafiBalanceIntrafiBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.IntrafiBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntrafiBalance> IntrafiBalance(
        string accountID,
        IntrafiBalanceIntrafiBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.IntrafiBalance(parameters with { AccountID = accountID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class IntrafiBalanceServiceWithRawResponse : IIntrafiBalanceServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntrafiBalanceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntrafiBalanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntrafiBalanceServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiBalance>> IntrafiBalance(
        IntrafiBalanceIntrafiBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<IntrafiBalanceIntrafiBalanceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiBalance = await response
                    .Deserialize<IntrafiBalance>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiBalance.Validate();
                }
                return intrafiBalance;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntrafiBalance>> IntrafiBalance(
        string accountID,
        IntrafiBalanceIntrafiBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.IntrafiBalance(parameters with { AccountID = accountID }, cancellationToken);
    }
}
