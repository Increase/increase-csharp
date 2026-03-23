using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.WireTransfers;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class WireTransferService : IWireTransferService
{
    readonly Lazy<IWireTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWireTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IWireTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WireTransferService(this._client.WithOptions(modifier));
    }

    public WireTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WireTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<WireTransfer> Reverse(
        WireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reverse(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireTransfer> Reverse(
        string wireTransferID,
        WireTransferReverseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reverse(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WireTransfer> Submit(
        WireTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireTransfer> Submit(
        string wireTransferID,
        WireTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WireTransferServiceWithRawResponse : IWireTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWireTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WireTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WireTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransfer>> Reverse(
        WireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.WireTransferID' cannot be null");
        }

        HttpRequest<WireTransferReverseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireTransfer = await response
                    .Deserialize<WireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireTransfer.Validate();
                }
                return wireTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WireTransfer>> Reverse(
        string wireTransferID,
        WireTransferReverseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Reverse(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransfer>> Submit(
        WireTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.WireTransferID' cannot be null");
        }

        HttpRequest<WireTransferSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireTransfer = await response
                    .Deserialize<WireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireTransfer.Validate();
                }
                return wireTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WireTransfer>> Submit(
        string wireTransferID,
        WireTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }
}
