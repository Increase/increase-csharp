using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundWireTransfers;
using Increase.Api.Models.Simulations.InboundWireTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundWireTransferService : IInboundWireTransferService
{
    readonly Lazy<IInboundWireTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundWireTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundWireTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundWireTransferService(this._client.WithOptions(modifier));
    }

    public InboundWireTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundWireTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundWireTransfer> Create(
        InboundWireTransferCreateParams parameters,
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
public sealed class InboundWireTransferServiceWithRawResponse
    : IInboundWireTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundWireTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundWireTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundWireTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundWireTransfer>> Create(
        InboundWireTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundWireTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundWireTransfer = await response
                    .Deserialize<InboundWireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundWireTransfer.Validate();
                }
                return inboundWireTransfer;
            }
        );
    }
}
