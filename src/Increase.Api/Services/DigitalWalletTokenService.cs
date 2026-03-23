using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DigitalWalletTokens;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class DigitalWalletTokenService : IDigitalWalletTokenService
{
    readonly Lazy<IDigitalWalletTokenServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDigitalWalletTokenServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IDigitalWalletTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DigitalWalletTokenService(this._client.WithOptions(modifier));
    }

    public DigitalWalletTokenService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new DigitalWalletTokenServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalWalletToken> Retrieve(
        DigitalWalletTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DigitalWalletToken> Retrieve(
        string digitalWalletTokenID,
        DigitalWalletTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DigitalWalletTokenID = digitalWalletTokenID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalWalletTokenListPage> List(
        DigitalWalletTokenListParams? parameters = null,
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
public sealed class DigitalWalletTokenServiceWithRawResponse
    : IDigitalWalletTokenServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDigitalWalletTokenServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DigitalWalletTokenServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DigitalWalletTokenServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalWalletToken>> Retrieve(
        DigitalWalletTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DigitalWalletTokenID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.DigitalWalletTokenID' cannot be null"
            );
        }

        HttpRequest<DigitalWalletTokenRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalWalletToken = await response
                    .Deserialize<DigitalWalletToken>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalWalletToken.Validate();
                }
                return digitalWalletToken;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DigitalWalletToken>> Retrieve(
        string digitalWalletTokenID,
        DigitalWalletTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DigitalWalletTokenID = digitalWalletTokenID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalWalletTokenListPage>> List(
        DigitalWalletTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DigitalWalletTokenListParams> request = new()
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
                    .Deserialize<DigitalWalletTokenListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DigitalWalletTokenListPage(this, parameters, page);
            }
        );
    }
}
