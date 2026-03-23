using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.DigitalWalletTokenRequests;

namespace Increase.Api.Services.Simulations;

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
    public async Task<DigitalWalletTokenRequestCreateResponse> Create(
        DigitalWalletTokenRequestCreateParams parameters,
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
    public async Task<HttpResponse<DigitalWalletTokenRequestCreateResponse>> Create(
        DigitalWalletTokenRequestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DigitalWalletTokenRequestCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalWalletTokenRequest = await response
                    .Deserialize<DigitalWalletTokenRequestCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalWalletTokenRequest.Validate();
                }
                return digitalWalletTokenRequest;
            }
        );
    }
}
