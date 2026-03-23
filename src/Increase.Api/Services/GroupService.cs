using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Groups;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class GroupService : IGroupService
{
    readonly Lazy<IGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GroupService(this._client.WithOptions(modifier));
    }

    public GroupService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GroupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Group> Retrieve(
        GroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GroupServiceWithRawResponse : IGroupServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GroupServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Group>> Retrieve(
        GroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var group = await response.Deserialize<Group>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    group.Validate();
                }
                return group;
            }
        );
    }
}
