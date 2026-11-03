using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RealTimePaymentsTransfers;
using Increase.Api.Models.Simulations.RealTimePaymentsTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class RealTimePaymentsTransferService : IRealTimePaymentsTransferService
{
    readonly Lazy<IRealTimePaymentsTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRealTimePaymentsTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IRealTimePaymentsTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RealTimePaymentsTransferService(this._client.WithOptions(modifier));
    }

    public RealTimePaymentsTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RealTimePaymentsTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsTransfer> Complete(
        RealTimePaymentsTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimePaymentsTransfer> Complete(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class RealTimePaymentsTransferServiceWithRawResponse
    : IRealTimePaymentsTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRealTimePaymentsTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RealTimePaymentsTransferServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public RealTimePaymentsTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsTransfer>> Complete(
        RealTimePaymentsTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimePaymentsTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimePaymentsTransferID' cannot be null"
            );
        }

        HttpRequest<RealTimePaymentsTransferCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsTransfer = await response
                    .Deserialize<RealTimePaymentsTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsTransfer.Validate();
                }
                return realTimePaymentsTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimePaymentsTransfer>> Complete(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }
}
