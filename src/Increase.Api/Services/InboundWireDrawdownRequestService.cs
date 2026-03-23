using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundWireDrawdownRequests;

namespace Increase.Api.Services;

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
    public async Task<InboundWireDrawdownRequest> Retrieve(
        InboundWireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundWireDrawdownRequest> Retrieve(
        string inboundWireDrawdownRequestID,
        InboundWireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundWireDrawdownRequestID = inboundWireDrawdownRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundWireDrawdownRequestListPage> List(
        InboundWireDrawdownRequestListParams? parameters = null,
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
    public async Task<HttpResponse<InboundWireDrawdownRequest>> Retrieve(
        InboundWireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundWireDrawdownRequestID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundWireDrawdownRequestID' cannot be null"
            );
        }

        HttpRequest<InboundWireDrawdownRequestRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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

    /// <inheritdoc/>
    public Task<HttpResponse<InboundWireDrawdownRequest>> Retrieve(
        string inboundWireDrawdownRequestID,
        InboundWireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundWireDrawdownRequestID = inboundWireDrawdownRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundWireDrawdownRequestListPage>> List(
        InboundWireDrawdownRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundWireDrawdownRequestListParams> request = new()
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
                    .Deserialize<InboundWireDrawdownRequestListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundWireDrawdownRequestListPage(this, parameters, page);
            }
        );
    }
}
