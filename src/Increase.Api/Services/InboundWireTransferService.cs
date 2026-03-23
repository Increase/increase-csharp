using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Services;

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
    public async Task<InboundWireTransfer> Retrieve(
        InboundWireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundWireTransfer> Retrieve(
        string inboundWireTransferID,
        InboundWireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundWireTransferID = inboundWireTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundWireTransferListPage> List(
        InboundWireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InboundWireTransfer> Reverse(
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reverse(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundWireTransfer> Reverse(
        string inboundWireTransferID,
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reverse(
            parameters with
            {
                InboundWireTransferID = inboundWireTransferID,
            },
            cancellationToken
        );
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
    public async Task<HttpResponse<InboundWireTransfer>> Retrieve(
        InboundWireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundWireTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundWireTransferID' cannot be null"
            );
        }

        HttpRequest<InboundWireTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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

    /// <inheritdoc/>
    public Task<HttpResponse<InboundWireTransfer>> Retrieve(
        string inboundWireTransferID,
        InboundWireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundWireTransferID = inboundWireTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundWireTransferListPage>> List(
        InboundWireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundWireTransferListParams> request = new()
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
                    .Deserialize<InboundWireTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundWireTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundWireTransfer>> Reverse(
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundWireTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundWireTransferID' cannot be null"
            );
        }

        HttpRequest<InboundWireTransferReverseParams> request = new()
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

    /// <inheritdoc/>
    public Task<HttpResponse<InboundWireTransfer>> Reverse(
        string inboundWireTransferID,
        InboundWireTransferReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reverse(
            parameters with
            {
                InboundWireTransferID = inboundWireTransferID,
            },
            cancellationToken
        );
    }
}
