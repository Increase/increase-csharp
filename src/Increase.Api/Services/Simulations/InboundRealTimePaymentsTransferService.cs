using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;
using Increase.Api.Models.Simulations.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class InboundRealTimePaymentsTransferService : IInboundRealTimePaymentsTransferService
{
    readonly Lazy<IInboundRealTimePaymentsTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundRealTimePaymentsTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundRealTimePaymentsTransferService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundRealTimePaymentsTransferService(this._client.WithOptions(modifier));
    }

    public InboundRealTimePaymentsTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundRealTimePaymentsTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundRealTimePaymentsTransfer> Create(
        InboundRealTimePaymentsTransferCreateParams parameters,
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
public sealed class InboundRealTimePaymentsTransferServiceWithRawResponse
    : IInboundRealTimePaymentsTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundRealTimePaymentsTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundRealTimePaymentsTransferServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public InboundRealTimePaymentsTransferServiceWithRawResponse(
        IIncreaseClientWithRawResponse client
    )
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundRealTimePaymentsTransfer>> Create(
        InboundRealTimePaymentsTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundRealTimePaymentsTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundRealTimePaymentsTransfer = await response
                    .Deserialize<InboundRealTimePaymentsTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundRealTimePaymentsTransfer.Validate();
                }
                return inboundRealTimePaymentsTransfer;
            }
        );
    }
}
