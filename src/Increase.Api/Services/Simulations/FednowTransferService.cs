using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.FednowTransfers;
using Increase.Api.Models.Simulations.FednowTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class FednowTransferService : IFednowTransferService
{
    readonly Lazy<IFednowTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFednowTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IFednowTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FednowTransferService(this._client.WithOptions(modifier));
    }

    public FednowTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new FednowTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<FednowTransfer> Complete(
        FednowTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FednowTransfer> Complete(
        string fednowTransferID,
        FednowTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class FednowTransferServiceWithRawResponse : IFednowTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFednowTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FednowTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FednowTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FednowTransfer>> Complete(
        FednowTransferCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FednowTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.FednowTransferID' cannot be null");
        }

        HttpRequest<FednowTransferCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fednowTransfer = await response
                    .Deserialize<FednowTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fednowTransfer.Validate();
                }
                return fednowTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FednowTransfer>> Complete(
        string fednowTransferID,
        FednowTransferCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }
}
