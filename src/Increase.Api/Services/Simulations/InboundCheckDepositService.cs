using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundCheckDeposits;
using Increase.Api.Models.Simulations.InboundCheckDeposits;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundCheckDepositService : IInboundCheckDepositService
{
    readonly Lazy<IInboundCheckDepositServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundCheckDepositServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundCheckDepositService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundCheckDepositService(this._client.WithOptions(modifier));
    }

    public InboundCheckDepositService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundCheckDepositServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundCheckDeposit> Create(
        InboundCheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InboundCheckDeposit> Adjustment(
        InboundCheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Adjustment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundCheckDeposit> Adjustment(
        string inboundCheckDepositID,
        InboundCheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Adjustment(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class InboundCheckDepositServiceWithRawResponse
    : IInboundCheckDepositServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundCheckDepositServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundCheckDepositServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundCheckDepositServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundCheckDeposit>> Create(
        InboundCheckDepositCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundCheckDepositCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundCheckDeposit = await response
                    .Deserialize<InboundCheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundCheckDeposit.Validate();
                }
                return inboundCheckDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundCheckDeposit>> Adjustment(
        InboundCheckDepositAdjustmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundCheckDepositID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundCheckDepositID' cannot be null"
            );
        }

        HttpRequest<InboundCheckDepositAdjustmentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundCheckDeposit = await response
                    .Deserialize<InboundCheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundCheckDeposit.Validate();
                }
                return inboundCheckDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundCheckDeposit>> Adjustment(
        string inboundCheckDepositID,
        InboundCheckDepositAdjustmentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Adjustment(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }
}
