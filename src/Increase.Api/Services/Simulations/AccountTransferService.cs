using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountTransfers;
using Increase.Api.Models.Simulations.AccountTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class AccountTransferService : IAccountTransferService
{
    readonly Lazy<IAccountTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountTransferService(this._client.WithOptions(modifier));
    }

    public AccountTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountTransfer> Complete(
        AccountTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountTransfer> Complete(
        string accountTransferID,
        AccountTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class AccountTransferServiceWithRawResponse : IAccountTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransfer>> Complete(
        AccountTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AccountTransferID' cannot be null");
        }

        HttpRequest<AccountTransferCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountTransfer = await response
                    .Deserialize<AccountTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountTransfer.Validate();
                }
                return accountTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountTransfer>> Complete(
        string accountTransferID,
        AccountTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                AccountTransferID = accountTransferID,
            },
            cancellationToken
        );
    }
}
