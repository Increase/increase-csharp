using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundFednowTransfers;

namespace Increase.Api.Services;

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
    public async Task<InboundFednowTransfer> Retrieve(
        InboundFednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundFednowTransfer> Retrieve(
        string inboundFednowTransferID,
        InboundFednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundFednowTransferID = inboundFednowTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundFednowTransferListPage> List(
        InboundFednowTransferListParams? parameters = null,
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
    public async Task<HttpResponse<InboundFednowTransfer>> Retrieve(
        InboundFednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundFednowTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundFednowTransferID' cannot be null"
            );
        }

        HttpRequest<InboundFednowTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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

    /// <inheritdoc/>
    public Task<HttpResponse<InboundFednowTransfer>> Retrieve(
        string inboundFednowTransferID,
        InboundFednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundFednowTransferID = inboundFednowTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundFednowTransferListPage>> List(
        InboundFednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundFednowTransferListParams> request = new()
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
                    .Deserialize<InboundFednowTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundFednowTransferListPage(this, parameters, page);
            }
        );
    }
}
