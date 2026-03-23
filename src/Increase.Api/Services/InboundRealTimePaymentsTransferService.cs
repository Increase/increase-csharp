using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Services;

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
    public async Task<InboundRealTimePaymentsTransfer> Retrieve(
        InboundRealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundRealTimePaymentsTransfer> Retrieve(
        string inboundRealTimePaymentsTransferID,
        InboundRealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundRealTimePaymentsTransferID = inboundRealTimePaymentsTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundRealTimePaymentsTransferListPage> List(
        InboundRealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
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
    public async Task<HttpResponse<InboundRealTimePaymentsTransfer>> Retrieve(
        InboundRealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundRealTimePaymentsTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundRealTimePaymentsTransferID' cannot be null"
            );
        }

        HttpRequest<InboundRealTimePaymentsTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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

    /// <inheritdoc/>
    public Task<HttpResponse<InboundRealTimePaymentsTransfer>> Retrieve(
        string inboundRealTimePaymentsTransferID,
        InboundRealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundRealTimePaymentsTransferID = inboundRealTimePaymentsTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundRealTimePaymentsTransferListPage>> List(
        InboundRealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundRealTimePaymentsTransferListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<InboundRealTimePaymentsTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundRealTimePaymentsTransferListPage(this, parameters, page);
            }
        );
    }
}
