using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class EntityOnboardingSessionService : IEntityOnboardingSessionService
{
    readonly Lazy<IEntityOnboardingSessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntityOnboardingSessionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IEntityOnboardingSessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityOnboardingSessionService(this._client.WithOptions(modifier));
    }

    public EntityOnboardingSessionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new EntityOnboardingSessionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<EntityOnboardingSession> Create(
        EntityOnboardingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityOnboardingSession> Retrieve(
        EntityOnboardingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityOnboardingSession> Retrieve(
        string entityOnboardingSessionID,
        EntityOnboardingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                EntityOnboardingSessionID = entityOnboardingSessionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<EntityOnboardingSessionListPage> List(
        EntityOnboardingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityOnboardingSession> Expire(
        EntityOnboardingSessionExpireParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Expire(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityOnboardingSession> Expire(
        string entityOnboardingSessionID,
        EntityOnboardingSessionExpireParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Expire(
            parameters with
            {
                EntityOnboardingSessionID = entityOnboardingSessionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class EntityOnboardingSessionServiceWithRawResponse
    : IEntityOnboardingSessionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntityOnboardingSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EntityOnboardingSessionServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public EntityOnboardingSessionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityOnboardingSession>> Create(
        EntityOnboardingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityOnboardingSessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityOnboardingSession = await response
                    .Deserialize<EntityOnboardingSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityOnboardingSession.Validate();
                }
                return entityOnboardingSession;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityOnboardingSession>> Retrieve(
        EntityOnboardingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityOnboardingSessionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EntityOnboardingSessionID' cannot be null"
            );
        }

        HttpRequest<EntityOnboardingSessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityOnboardingSession = await response
                    .Deserialize<EntityOnboardingSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityOnboardingSession.Validate();
                }
                return entityOnboardingSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityOnboardingSession>> Retrieve(
        string entityOnboardingSessionID,
        EntityOnboardingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                EntityOnboardingSessionID = entityOnboardingSessionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityOnboardingSessionListPage>> List(
        EntityOnboardingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EntityOnboardingSessionListParams> request = new()
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
                    .Deserialize<EntityOnboardingSessionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EntityOnboardingSessionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityOnboardingSession>> Expire(
        EntityOnboardingSessionExpireParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityOnboardingSessionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EntityOnboardingSessionID' cannot be null"
            );
        }

        HttpRequest<EntityOnboardingSessionExpireParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityOnboardingSession = await response
                    .Deserialize<EntityOnboardingSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityOnboardingSession.Validate();
                }
                return entityOnboardingSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityOnboardingSession>> Expire(
        string entityOnboardingSessionID,
        EntityOnboardingSessionExpireParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Expire(
            parameters with
            {
                EntityOnboardingSessionID = entityOnboardingSessionID,
            },
            cancellationToken
        );
    }
}
