using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.EventSubscriptions;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEventSubscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventSubscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventSubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an Event Subscription
    /// </summary>
    Task<EventSubscription> Create(
        EventSubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Event Subscription
    /// </summary>
    Task<EventSubscription> Retrieve(
        EventSubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventSubscriptionRetrieveParams, CancellationToken)"/>
    Task<EventSubscription> Retrieve(
        string eventSubscriptionID,
        EventSubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an Event Subscription
    /// </summary>
    Task<EventSubscription> Update(
        EventSubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EventSubscriptionUpdateParams, CancellationToken)"/>
    Task<EventSubscription> Update(
        string eventSubscriptionID,
        EventSubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Event Subscriptions
    /// </summary>
    Task<EventSubscriptionListPage> List(
        EventSubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventSubscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventSubscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventSubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /event_subscriptions</c>, but is otherwise the
    /// same as <see cref="IEventSubscriptionService.Create(EventSubscriptionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventSubscription>> Create(
        EventSubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /event_subscriptions/{event_subscription_id}</c>, but is otherwise the
    /// same as <see cref="IEventSubscriptionService.Retrieve(EventSubscriptionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventSubscription>> Retrieve(
        EventSubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventSubscriptionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EventSubscription>> Retrieve(
        string eventSubscriptionID,
        EventSubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /event_subscriptions/{event_subscription_id}</c>, but is otherwise the
    /// same as <see cref="IEventSubscriptionService.Update(EventSubscriptionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventSubscription>> Update(
        EventSubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EventSubscriptionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EventSubscription>> Update(
        string eventSubscriptionID,
        EventSubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /event_subscriptions</c>, but is otherwise the
    /// same as <see cref="IEventSubscriptionService.List(EventSubscriptionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventSubscriptionListPage>> List(
        EventSubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
