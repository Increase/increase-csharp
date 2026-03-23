using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class WireDrawdownRequestService : IWireDrawdownRequestService
{
    readonly Lazy<IWireDrawdownRequestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWireDrawdownRequestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IWireDrawdownRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WireDrawdownRequestService(this._client.WithOptions(modifier));
    }

    public WireDrawdownRequestService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WireDrawdownRequestServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<WireDrawdownRequest> Create(
        WireDrawdownRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireDrawdownRequest> Retrieve(
        WireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireDrawdownRequest> Retrieve(
        string wireDrawdownRequestID,
        WireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                WireDrawdownRequestID = wireDrawdownRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<WireDrawdownRequestListPage> List(
        WireDrawdownRequestListParams? parameters = null,
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
public sealed class WireDrawdownRequestServiceWithRawResponse
    : IWireDrawdownRequestServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWireDrawdownRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WireDrawdownRequestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WireDrawdownRequestServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireDrawdownRequest>> Create(
        WireDrawdownRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WireDrawdownRequestCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireDrawdownRequest = await response
                    .Deserialize<WireDrawdownRequest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireDrawdownRequest.Validate();
                }
                return wireDrawdownRequest;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireDrawdownRequest>> Retrieve(
        WireDrawdownRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireDrawdownRequestID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.WireDrawdownRequestID' cannot be null"
            );
        }

        HttpRequest<WireDrawdownRequestRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireDrawdownRequest = await response
                    .Deserialize<WireDrawdownRequest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireDrawdownRequest.Validate();
                }
                return wireDrawdownRequest;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WireDrawdownRequest>> Retrieve(
        string wireDrawdownRequestID,
        WireDrawdownRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                WireDrawdownRequestID = wireDrawdownRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireDrawdownRequestListPage>> List(
        WireDrawdownRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WireDrawdownRequestListParams> request = new()
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
                    .Deserialize<WireDrawdownRequestListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WireDrawdownRequestListPage(this, parameters, page);
            }
        );
    }
}
