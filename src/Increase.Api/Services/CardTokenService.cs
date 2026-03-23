using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardTokens;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CardTokenService : ICardTokenService
{
    readonly Lazy<ICardTokenServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICardTokenServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICardTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardTokenService(this._client.WithOptions(modifier));
    }

    public CardTokenService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CardTokenServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CardToken> Retrieve(
        CardTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardToken> Retrieve(
        string cardTokenID,
        CardTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardTokenID = cardTokenID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CardTokenListPage> List(
        CardTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CardTokenCapabilities> Capabilities(
        CardTokenCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Capabilities(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CardTokenCapabilities> Capabilities(
        string cardTokenID,
        CardTokenCapabilitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Capabilities(parameters with { CardTokenID = cardTokenID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CardTokenServiceWithRawResponse : ICardTokenServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICardTokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CardTokenServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CardTokenServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardToken>> Retrieve(
        CardTokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardTokenID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardTokenID' cannot be null");
        }

        HttpRequest<CardTokenRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardToken = await response.Deserialize<CardToken>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardToken.Validate();
                }
                return cardToken;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardToken>> Retrieve(
        string cardTokenID,
        CardTokenRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CardTokenID = cardTokenID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardTokenListPage>> List(
        CardTokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CardTokenListParams> request = new()
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
                    .Deserialize<CardTokenListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CardTokenListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CardTokenCapabilities>> Capabilities(
        CardTokenCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CardTokenID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CardTokenID' cannot be null");
        }

        HttpRequest<CardTokenCapabilitiesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cardTokenCapabilities = await response
                    .Deserialize<CardTokenCapabilities>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cardTokenCapabilities.Validate();
                }
                return cardTokenCapabilities;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CardTokenCapabilities>> Capabilities(
        string cardTokenID,
        CardTokenCapabilitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Capabilities(parameters with { CardTokenID = cardTokenID }, cancellationToken);
    }
}
