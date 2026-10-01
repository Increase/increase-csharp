using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DigitalWalletTokenRequests;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class DigitalWalletTokenRequestService : IDigitalWalletTokenRequestService
{
    readonly Lazy<IDigitalWalletTokenRequestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDigitalWalletTokenRequestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IDigitalWalletTokenRequestService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DigitalWalletTokenRequestService(this._client.WithOptions(modifier));
    }

    public DigitalWalletTokenRequestService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new DigitalWalletTokenRequestServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalWalletTokenRequest> Retrieve(
        DigitalWalletTokenRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DigitalWalletTokenRequest> Retrieve(
        string digitalWalletTokenRequestID,
        DigitalWalletTokenRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DigitalWalletTokenRequestID = digitalWalletTokenRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalWalletTokenRequestListPage> List(
        DigitalWalletTokenRequestListParams? parameters = null,
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
public sealed class DigitalWalletTokenRequestServiceWithRawResponse
    : IDigitalWalletTokenRequestServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDigitalWalletTokenRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DigitalWalletTokenRequestServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public DigitalWalletTokenRequestServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalWalletTokenRequest>> Retrieve(
        DigitalWalletTokenRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DigitalWalletTokenRequestID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.DigitalWalletTokenRequestID' cannot be null"
            );
        }

        HttpRequest<DigitalWalletTokenRequestRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalWalletTokenRequest = await response
                    .Deserialize<DigitalWalletTokenRequest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalWalletTokenRequest.Validate();
                }
                return digitalWalletTokenRequest;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DigitalWalletTokenRequest>> Retrieve(
        string digitalWalletTokenRequestID,
        DigitalWalletTokenRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DigitalWalletTokenRequestID = digitalWalletTokenRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalWalletTokenRequestListPage>> List(
        DigitalWalletTokenRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DigitalWalletTokenRequestListParams> request = new()
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
                    .Deserialize<DigitalWalletTokenRequestListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DigitalWalletTokenRequestListPage(this, parameters, page);
            }
        );
    }
}
