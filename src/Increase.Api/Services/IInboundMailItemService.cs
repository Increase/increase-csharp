using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundMailItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundMailItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundMailItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an Inbound Mail Item
    /// </summary>
    Task<InboundMailItem> Retrieve(
        InboundMailItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundMailItemRetrieveParams, CancellationToken)"/>
    Task<InboundMailItem> Retrieve(
        string inboundMailItemID,
        InboundMailItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Inbound Mail Items
    /// </summary>
    Task<InboundMailItemListPage> List(
        InboundMailItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Action an Inbound Mail Item
    /// </summary>
    Task<InboundMailItem> Action(
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Action(InboundMailItemActionParams, CancellationToken)"/>
    Task<InboundMailItem> Action(
        string inboundMailItemID,
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundMailItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundMailItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundMailItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_mail_items/{inbound_mail_item_id}</c>, but is otherwise the
    /// same as <see cref="IInboundMailItemService.Retrieve(InboundMailItemRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundMailItem>> Retrieve(
        InboundMailItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InboundMailItemRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InboundMailItem>> Retrieve(
        string inboundMailItemID,
        InboundMailItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /inbound_mail_items</c>, but is otherwise the
    /// same as <see cref="IInboundMailItemService.List(InboundMailItemListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundMailItemListPage>> List(
        InboundMailItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /inbound_mail_items/{inbound_mail_item_id}/action</c>, but is otherwise the
    /// same as <see cref="IInboundMailItemService.Action(InboundMailItemActionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundMailItem>> Action(
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Action(InboundMailItemActionParams, CancellationToken)"/>
    Task<HttpResponse<InboundMailItem>> Action(
        string inboundMailItemID,
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    );
}
