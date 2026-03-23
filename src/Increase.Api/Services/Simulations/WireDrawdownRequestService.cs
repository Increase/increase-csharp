using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.WireDrawdownRequests;
using Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Services.Simulations;

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
    public async Task<WireDrawdownRequest> Refuse(
        WireDrawdownRequestRefuseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Refuse(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireDrawdownRequest> Refuse(
        string wireDrawdownRequestID,
        WireDrawdownRequestRefuseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Refuse(
            parameters with
            {
                WireDrawdownRequestID = wireDrawdownRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<WireDrawdownRequest> Submit(
        WireDrawdownRequestSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireDrawdownRequest> Submit(
        string wireDrawdownRequestID,
        WireDrawdownRequestSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(
            parameters with
            {
                WireDrawdownRequestID = wireDrawdownRequestID,
            },
            cancellationToken
        );
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
    public async Task<HttpResponse<WireDrawdownRequest>> Refuse(
        WireDrawdownRequestRefuseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireDrawdownRequestID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.WireDrawdownRequestID' cannot be null"
            );
        }

        HttpRequest<WireDrawdownRequestRefuseParams> request = new()
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
    public Task<HttpResponse<WireDrawdownRequest>> Refuse(
        string wireDrawdownRequestID,
        WireDrawdownRequestRefuseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Refuse(
            parameters with
            {
                WireDrawdownRequestID = wireDrawdownRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireDrawdownRequest>> Submit(
        WireDrawdownRequestSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireDrawdownRequestID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.WireDrawdownRequestID' cannot be null"
            );
        }

        HttpRequest<WireDrawdownRequestSubmitParams> request = new()
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
    public Task<HttpResponse<WireDrawdownRequest>> Submit(
        string wireDrawdownRequestID,
        WireDrawdownRequestSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(
            parameters with
            {
                WireDrawdownRequestID = wireDrawdownRequestID,
            },
            cancellationToken
        );
    }
}
