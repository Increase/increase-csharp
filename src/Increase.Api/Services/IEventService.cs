using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Events;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Event
    /// </summary>
    Task<Event> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<Event> Retrieve(
        string eventID,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Events
    /// </summary>
    Task<EventListPage> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /events/{event_id}</c>, but is otherwise the
    /// same as <see cref="IEventService.Retrieve(EventRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Event>> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Event>> Retrieve(
        string eventID,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /events</c>, but is otherwise the
    /// same as <see cref="IEventService.List(EventListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventListPage>> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
