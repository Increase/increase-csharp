using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.EntityOnboardingSessions;
using Increase.Api.Models.Simulations.EntityOnboardingSessions;

namespace Increase.Api.Services.Simulations;

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
    public async Task<EntityOnboardingSession> Submit(
        EntityOnboardingSessionSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityOnboardingSession> Submit(
        string entityOnboardingSessionID,
        EntityOnboardingSessionSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(
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
    public async Task<HttpResponse<EntityOnboardingSession>> Submit(
        EntityOnboardingSessionSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityOnboardingSessionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EntityOnboardingSessionID' cannot be null"
            );
        }

        HttpRequest<EntityOnboardingSessionSubmitParams> request = new()
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
    public Task<HttpResponse<EntityOnboardingSession>> Submit(
        string entityOnboardingSessionID,
        EntityOnboardingSessionSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(
            parameters with
            {
                EntityOnboardingSessionID = entityOnboardingSessionID,
            },
            cancellationToken
        );
    }
}
