using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.OAuthApplications;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class OAuthApplicationService : IOAuthApplicationService
{
    readonly Lazy<IOAuthApplicationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOAuthApplicationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IOAuthApplicationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OAuthApplicationService(this._client.WithOptions(modifier));
    }

    public OAuthApplicationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new OAuthApplicationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<OAuthApplication> Retrieve(
        OAuthApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OAuthApplication> Retrieve(
        string oauthApplicationID,
        OAuthApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                OAuthApplicationID = oauthApplicationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<OAuthApplicationListPage> List(
        OAuthApplicationListParams? parameters = null,
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
public sealed class OAuthApplicationServiceWithRawResponse : IOAuthApplicationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOAuthApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OAuthApplicationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OAuthApplicationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthApplication>> Retrieve(
        OAuthApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OAuthApplicationID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.OAuthApplicationID' cannot be null"
            );
        }

        HttpRequest<OAuthApplicationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var oauthApplication = await response
                    .Deserialize<OAuthApplication>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    oauthApplication.Validate();
                }
                return oauthApplication;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OAuthApplication>> Retrieve(
        string oauthApplicationID,
        OAuthApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                OAuthApplicationID = oauthApplicationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OAuthApplicationListPage>> List(
        OAuthApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OAuthApplicationListParams> request = new()
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
                    .Deserialize<OAuthApplicationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new OAuthApplicationListPage(this, parameters, page);
            }
        );
    }
}
