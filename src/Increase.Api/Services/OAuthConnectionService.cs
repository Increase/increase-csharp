using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.OAuthConnections;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class OAuthConnectionService : IOAuthConnectionService
{
    readonly Lazy<IOAuthConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOAuthConnectionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IOAuthConnectionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OAuthConnectionService(this._client.WithOptions(modifier));
    }

    public OAuthConnectionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new OAuthConnectionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<OAuthConnection> Retrieve(
        OAuthConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OAuthConnection> Retrieve(
        string oauthConnectionID,
        OAuthConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                OAuthConnectionID = oauthConnectionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<OAuthConnectionListPage> List(
        OAuthConnectionListParams? parameters = null,
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
public sealed class OAuthConnectionServiceWithRawResponse : IOAuthConnectionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOAuthConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OAuthConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OAuthConnectionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthConnection>> Retrieve(
        OAuthConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OAuthConnectionID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.OAuthConnectionID' cannot be null");
        }

        HttpRequest<OAuthConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var oauthConnection = await response
                    .Deserialize<OAuthConnection>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    oauthConnection.Validate();
                }
                return oauthConnection;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OAuthConnection>> Retrieve(
        string oauthConnectionID,
        OAuthConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                OAuthConnectionID = oauthConnectionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthConnectionListPage>> List(
        OAuthConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OAuthConnectionListParams> request = new()
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
                    .Deserialize<OAuthConnectionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new OAuthConnectionListPage(this, parameters, page);
            }
        );
    }
}
