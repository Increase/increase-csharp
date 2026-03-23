using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Events;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class EventService : IEventService
{
    readonly Lazy<IEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventService(this._client.WithOptions(modifier));
    }

    public EventService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Event> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Event> Retrieve(
        string eventID,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventListPage> List(
        EventListParams? parameters = null,
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
public sealed class EventServiceWithRawResponse : IEventServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Event>> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.EventID' cannot be null");
        }

        HttpRequest<EventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<Event>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Event>> Retrieve(
        string eventID,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EventID = eventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventListPage>> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EventListParams> request = new()
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
                    .Deserialize<EventListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EventListPage(this, parameters, page);
            }
        );
    }
}
