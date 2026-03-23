using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.PhysicalCards;
using PhysicalCards = Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhysicalCardService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhysicalCardServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhysicalCardService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to simulate receiving a tracking update for a Physical
    /// Card, to simulate the progress of a shipment.
    /// </summary>
    Task<PhysicalCards::PhysicalCard> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PhysicalCardCreateParams, CancellationToken)"/>
    Task<PhysicalCards::PhysicalCard> Create(
        string physicalCardID,
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to simulate advancing the shipment status of a Physical
    /// Card, to simulate e.g., that a physical card was attempted shipped but then
    /// failed delivery.
    /// </summary>
    Task<PhysicalCards::PhysicalCard> AdvanceShipment(
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AdvanceShipment(PhysicalCardAdvanceShipmentParams, CancellationToken)"/>
    Task<PhysicalCards::PhysicalCard> AdvanceShipment(
        string physicalCardID,
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPhysicalCardService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhysicalCardServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhysicalCardServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/physical_cards/{physical_card_id}/tracking_updates</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardService.Create(PhysicalCardCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCards::PhysicalCard>> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PhysicalCardCreateParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCards::PhysicalCard>> Create(
        string physicalCardID,
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/physical_cards/{physical_card_id}/advance_shipment</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardService.AdvanceShipment(PhysicalCardAdvanceShipmentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCards::PhysicalCard>> AdvanceShipment(
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AdvanceShipment(PhysicalCardAdvanceShipmentParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCards::PhysicalCard>> AdvanceShipment(
        string physicalCardID,
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    );
}
