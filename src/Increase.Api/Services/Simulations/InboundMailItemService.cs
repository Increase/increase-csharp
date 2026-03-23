using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundMailItems;
using Increase.Api.Models.Simulations.InboundMailItems;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundMailItemService : IInboundMailItemService
{
    readonly Lazy<IInboundMailItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundMailItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundMailItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundMailItemService(this._client.WithOptions(modifier));
    }

    public InboundMailItemService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundMailItemServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundMailItem> Create(
        InboundMailItemCreateParams parameters,
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
public sealed class InboundMailItemServiceWithRawResponse : IInboundMailItemServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundMailItemServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundMailItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundMailItemServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundMailItem>> Create(
        InboundMailItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundMailItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundMailItem = await response
                    .Deserialize<InboundMailItem>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundMailItem.Validate();
                }
                return inboundMailItem;
            }
        );
    }
}
