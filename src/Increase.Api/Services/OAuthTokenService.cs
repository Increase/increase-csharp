using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.OAuthTokens;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class OAuthTokenService : IOAuthTokenService
{
    readonly Lazy<IOAuthTokenServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOAuthTokenServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IOAuthTokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OAuthTokenService(this._client.WithOptions(modifier));
    }

    public OAuthTokenService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OAuthTokenServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OAuthToken> Create(
        OAuthTokenCreateParams parameters,
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
public sealed class OAuthTokenServiceWithRawResponse : IOAuthTokenServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOAuthTokenServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OAuthTokenServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OAuthTokenServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthToken>> Create(
        OAuthTokenCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OAuthTokenCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var oauthToken = await response
                    .Deserialize<OAuthToken>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    oauthToken.Validate();
                }
                return oauthToken;
            }
        );
    }
}
