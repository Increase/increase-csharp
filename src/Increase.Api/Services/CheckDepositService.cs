using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckDeposits;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CheckDepositService : ICheckDepositService
{
    readonly Lazy<ICheckDepositServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckDepositServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICheckDepositService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckDepositService(this._client.WithOptions(modifier));
    }

    public CheckDepositService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CheckDepositServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CheckDeposit> Create(
        CheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CheckDeposit> Retrieve(
        CheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckDeposit> Retrieve(
        string checkDepositID,
        CheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CheckDepositID = checkDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckDepositListPage> List(
        CheckDepositListParams? parameters = null,
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
public sealed class CheckDepositServiceWithRawResponse : ICheckDepositServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckDepositServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CheckDepositServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckDepositServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckDeposit>> Create(
        CheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CheckDepositCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkDeposit = await response
                    .Deserialize<CheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkDeposit.Validate();
                }
                return checkDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckDeposit>> Retrieve(
        CheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckDepositID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckDepositID' cannot be null");
        }

        HttpRequest<CheckDepositRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkDeposit = await response
                    .Deserialize<CheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkDeposit.Validate();
                }
                return checkDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckDeposit>> Retrieve(
        string checkDepositID,
        CheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CheckDepositID = checkDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckDepositListPage>> List(
        CheckDepositListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CheckDepositListParams> request = new()
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
                    .Deserialize<CheckDepositListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CheckDepositListPage(this, parameters, page);
            }
        );
    }
}
