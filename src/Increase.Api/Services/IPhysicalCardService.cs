using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Services;

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
    /// Create a Physical Card
    /// </summary>
    Task<PhysicalCard> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Physical Card
    /// </summary>
    Task<PhysicalCard> Retrieve(
        PhysicalCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PhysicalCardRetrieveParams, CancellationToken)"/>
    Task<PhysicalCard> Retrieve(
        string physicalCardID,
        PhysicalCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Physical Card
    /// </summary>
    Task<PhysicalCard> Update(
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PhysicalCardUpdateParams, CancellationToken)"/>
    Task<PhysicalCard> Update(
        string physicalCardID,
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Physical Cards
    /// </summary>
    Task<PhysicalCardListPage> List(
        PhysicalCardListParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /physical_cards</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardService.Create(PhysicalCardCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCard>> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /physical_cards/{physical_card_id}</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardService.Retrieve(PhysicalCardRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCard>> Retrieve(
        PhysicalCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PhysicalCardRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCard>> Retrieve(
        string physicalCardID,
        PhysicalCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /physical_cards/{physical_card_id}</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardService.Update(PhysicalCardUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCard>> Update(
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PhysicalCardUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCard>> Update(
        string physicalCardID,
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /physical_cards</c>, but is otherwise the
    /// same as <see cref="IPhysicalCardService.List(PhysicalCardListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCardListPage>> List(
        PhysicalCardListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
