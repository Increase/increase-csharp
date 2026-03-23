using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Entities;

namespace Increase.Api.Services;

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
    public async Task<Entity> Create(
        EntityCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Entity> Retrieve(
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Entity> Retrieve(
        string entityID,
        EntityRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EntityID = entityID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Entity> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Entity> Update(
        string entityID,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { EntityID = entityID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntityListPage> List(
        EntityListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Entity> Archive(
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Entity> Archive(
        string entityID,
        EntityArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { EntityID = entityID }, cancellationToken);
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
    public async Task<HttpResponse<Entity>> Create(
        EntityCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityCreateParams> request = new()
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
    public async Task<HttpResponse<Entity>> Retrieve(
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.EntityID' cannot be null");
        }

        HttpRequest<EntityRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<Entity>> Retrieve(
        string entityID,
        EntityRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EntityID = entityID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Entity>> Update(
        EntityUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.EntityID' cannot be null");
        }

        HttpRequest<EntityUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
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
    public Task<HttpResponse<Entity>> Update(
        string entityID,
        EntityUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { EntityID = entityID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityListPage>> List(
        EntityListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EntityListParams> request = new()
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
                    .Deserialize<EntityListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EntityListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Entity>> Archive(
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.EntityID' cannot be null");
        }

        HttpRequest<EntityArchiveParams> request = new()
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
    public Task<HttpResponse<Entity>> Archive(
        string entityID,
        EntityArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { EntityID = entityID }, cancellationToken);
    }
}
