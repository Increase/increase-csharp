using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.RoutingNumbers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class RoutingNumberService : IRoutingNumberService
{
    readonly Lazy<IRoutingNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoutingNumberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IRoutingNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RoutingNumberService(this._client.WithOptions(modifier));
    }

    public RoutingNumberService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RoutingNumberServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RoutingNumberListPage> List(
        RoutingNumberListParams parameters,
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
public sealed class RoutingNumberServiceWithRawResponse : IRoutingNumberServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoutingNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RoutingNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoutingNumberServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoutingNumberListPage>> List(
        RoutingNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RoutingNumberListParams> request = new()
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
                    .Deserialize<RoutingNumberListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RoutingNumberListPage(this, parameters, page);
            }
        );
    }
}
