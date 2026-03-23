using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundFednowTransfers;
using Increase.Api.Models.Simulations.InboundFednowTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundFednowTransferService : IInboundFednowTransferService
{
    readonly Lazy<IInboundFednowTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundFednowTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundFednowTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundFednowTransferService(this._client.WithOptions(modifier));
    }

    public InboundFednowTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundFednowTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundFednowTransfer> Create(
        InboundFednowTransferCreateParams parameters,
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
public sealed class InboundFednowTransferServiceWithRawResponse
    : IInboundFednowTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundFednowTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundFednowTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundFednowTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundFednowTransfer>> Create(
        InboundFednowTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundFednowTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundFednowTransfer = await response
                    .Deserialize<InboundFednowTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundFednowTransfer.Validate();
                }
                return inboundFednowTransfer;
            }
        );
    }
}
