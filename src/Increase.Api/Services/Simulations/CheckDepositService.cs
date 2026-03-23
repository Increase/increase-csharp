using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckDeposits;
using Increase.Api.Models.Simulations.CheckDeposits;

namespace Increase.Api.Services.Simulations;

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
    public async Task<CheckDeposit> Adjustment(
        CheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Adjustment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckDeposit> Adjustment(
        string checkDepositID,
        CheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Adjustment(
            parameters with
            {
                CheckDepositID = checkDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckDeposit> Reject(
        CheckDepositRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reject(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckDeposit> Reject(
        string checkDepositID,
        CheckDepositRejectParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reject(parameters with { CheckDepositID = checkDepositID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CheckDeposit> Return(
        CheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Return(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckDeposit> Return(
        string checkDepositID,
        CheckDepositReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Return(parameters with { CheckDepositID = checkDepositID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CheckDeposit> Submit(
        CheckDepositSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckDeposit> Submit(
        string checkDepositID,
        CheckDepositSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { CheckDepositID = checkDepositID }, cancellationToken);
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
    public async Task<HttpResponse<CheckDeposit>> Adjustment(
        CheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckDepositID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckDepositID' cannot be null");
        }

        HttpRequest<CheckDepositAdjustmentParams> request = new()
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
    public Task<HttpResponse<CheckDeposit>> Adjustment(
        string checkDepositID,
        CheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Adjustment(
            parameters with
            {
                CheckDepositID = checkDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckDeposit>> Reject(
        CheckDepositRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckDepositID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckDepositID' cannot be null");
        }

        HttpRequest<CheckDepositRejectParams> request = new()
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
    public Task<HttpResponse<CheckDeposit>> Reject(
        string checkDepositID,
        CheckDepositRejectParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reject(parameters with { CheckDepositID = checkDepositID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckDeposit>> Return(
        CheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckDepositID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckDepositID' cannot be null");
        }

        HttpRequest<CheckDepositReturnParams> request = new()
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
    public Task<HttpResponse<CheckDeposit>> Return(
        string checkDepositID,
        CheckDepositReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Return(parameters with { CheckDepositID = checkDepositID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckDeposit>> Submit(
        CheckDepositSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckDepositID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckDepositID' cannot be null");
        }

        HttpRequest<CheckDepositSubmitParams> request = new()
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
    public Task<HttpResponse<CheckDeposit>> Submit(
        string checkDepositID,
        CheckDepositSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { CheckDepositID = checkDepositID }, cancellationToken);
    }
}
