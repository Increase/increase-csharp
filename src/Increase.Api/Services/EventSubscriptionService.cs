using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class EventSubscriptionService : IEventSubscriptionService
{
    readonly Lazy<IEventSubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventSubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IEventSubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventSubscriptionService(this._client.WithOptions(modifier));
    }

    public EventSubscriptionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new EventSubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<EventSubscription> Create(
        EventSubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EventSubscription> Retrieve(
        EventSubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventSubscription> Retrieve(
        string eventSubscriptionID,
        EventSubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                EventSubscriptionID = eventSubscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<EventSubscription> Update(
        EventSubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventSubscription> Update(
        string eventSubscriptionID,
        EventSubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                EventSubscriptionID = eventSubscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<EventSubscriptionListPage> List(
        EventSubscriptionListParams? parameters = null,
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
public sealed class EventSubscriptionServiceWithRawResponse
    : IEventSubscriptionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventSubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EventSubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventSubscriptionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventSubscription>> Create(
        EventSubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventSubscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventSubscription = await response
                    .Deserialize<EventSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventSubscription.Validate();
                }
                return eventSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventSubscription>> Retrieve(
        EventSubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventSubscriptionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EventSubscriptionID' cannot be null"
            );
        }

        HttpRequest<EventSubscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventSubscription = await response
                    .Deserialize<EventSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventSubscription.Validate();
                }
                return eventSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventSubscription>> Retrieve(
        string eventSubscriptionID,
        EventSubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                EventSubscriptionID = eventSubscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventSubscription>> Update(
        EventSubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventSubscriptionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EventSubscriptionID' cannot be null"
            );
        }

        HttpRequest<EventSubscriptionUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventSubscription = await response
                    .Deserialize<EventSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventSubscription.Validate();
                }
                return eventSubscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventSubscription>> Update(
        string eventSubscriptionID,
        EventSubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                EventSubscriptionID = eventSubscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventSubscriptionListPage>> List(
        EventSubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EventSubscriptionListParams> request = new()
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
                    .Deserialize<EventSubscriptionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EventSubscriptionListPage(this, parameters, page);
            }
        );
    }
}
