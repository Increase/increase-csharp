using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundAchTransfers;
using Increase.Api.Models.Simulations.InboundAchTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundAchTransferService : IInboundAchTransferService
{
    readonly Lazy<IInboundAchTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundAchTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundAchTransferService(this._client.WithOptions(modifier));
    }

    public InboundAchTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundAchTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundAchTransfer> Create(
        InboundAchTransferCreateParams parameters,
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
public sealed class InboundAchTransferServiceWithRawResponse
    : IInboundAchTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundAchTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundAchTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundAchTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundAchTransfer>> Create(
        InboundAchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundAchTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundAchTransfer = await response
                    .Deserialize<InboundAchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundAchTransfer.Validate();
                }
                return inboundAchTransfer;
            }
        );
    }
}
