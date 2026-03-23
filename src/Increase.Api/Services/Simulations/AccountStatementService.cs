using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AccountStatements;
using Increase.Api.Models.Simulations.AccountStatements;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class AccountStatementService : IAccountStatementService
{
    readonly Lazy<IAccountStatementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountStatementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAccountStatementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountStatementService(this._client.WithOptions(modifier));
    }

    public AccountStatementService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountStatementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountStatement> Create(
        AccountStatementCreateParams parameters,
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
public sealed class AccountStatementServiceWithRawResponse : IAccountStatementServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountStatementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountStatementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountStatementServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountStatement>> Create(
        AccountStatementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountStatementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountStatement = await response
                    .Deserialize<AccountStatement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountStatement.Validate();
                }
                return accountStatement;
            }
        );
    }
}
