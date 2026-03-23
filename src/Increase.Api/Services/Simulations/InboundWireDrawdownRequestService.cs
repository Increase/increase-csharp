using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundWireDrawdownRequests;
using Increase.Api.Models.Simulations.InboundWireDrawdownRequests;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundWireDrawdownRequestService : IInboundWireDrawdownRequestService
{
    readonly Lazy<IInboundWireDrawdownRequestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundWireDrawdownRequestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundWireDrawdownRequestService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundWireDrawdownRequestService(this._client.WithOptions(modifier));
    }

    public InboundWireDrawdownRequestService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundWireDrawdownRequestServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundWireDrawdownRequest> Create(
        InboundWireDrawdownRequestCreateParams parameters,
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
public sealed class InboundWireDrawdownRequestServiceWithRawResponse
    : IInboundWireDrawdownRequestServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundWireDrawdownRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundWireDrawdownRequestServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public InboundWireDrawdownRequestServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundWireDrawdownRequest>> Create(
        InboundWireDrawdownRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundWireDrawdownRequestCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundWireDrawdownRequest = await response
                    .Deserialize<InboundWireDrawdownRequest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundWireDrawdownRequest.Validate();
                }
                return inboundWireDrawdownRequest;
            }
        );
    }
}
