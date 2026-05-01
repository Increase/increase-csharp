using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Entities;
using Increase.Api.Models.Simulations.Entities;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class EntityService : IEntityService
{
    readonly Lazy<IEntityServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntityServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IEntityService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityService(this._client.WithOptions(modifier));
    }

    public EntityService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntityServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Entity> UpdateValidation(
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateValidation(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Entity> UpdateValidation(
        string entityID,
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateValidation(parameters with { EntityID = entityID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EntityServiceWithRawResponse : IEntityServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntityServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Entity>> UpdateValidation(
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.EntityID' cannot be null");
        }

        HttpRequest<EntityUpdateValidationParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entity = await response.Deserialize<Entity>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entity.Validate();
                }
                return entity;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Entity>> UpdateValidation(
        string entityID,
        EntityUpdateValidationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateValidation(parameters with { EntityID = entityID }, cancellationToken);
    }
}
