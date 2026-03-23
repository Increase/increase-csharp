using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.AchPrenotifications;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAchPrenotificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAchPrenotificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAchPrenotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an ACH Prenotification
    /// </summary>
    Task<AchPrenotification> Create(
        AchPrenotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an ACH Prenotification
    /// </summary>
    Task<AchPrenotification> Retrieve(
        AchPrenotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AchPrenotificationRetrieveParams, CancellationToken)"/>
    Task<AchPrenotification> Retrieve(
        string achPrenotificationID,
        AchPrenotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List ACH Prenotifications
    /// </summary>
    Task<AchPrenotificationListPage> List(
        AchPrenotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAchPrenotificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAchPrenotificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAchPrenotificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /ach_prenotifications</c>, but is otherwise the
    /// same as <see cref="IAchPrenotificationService.Create(AchPrenotificationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchPrenotification>> Create(
        AchPrenotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ach_prenotifications/{ach_prenotification_id}</c>, but is otherwise the
    /// same as <see cref="IAchPrenotificationService.Retrieve(AchPrenotificationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchPrenotification>> Retrieve(
        AchPrenotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AchPrenotificationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AchPrenotification>> Retrieve(
        string achPrenotificationID,
        AchPrenotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ach_prenotifications</c>, but is otherwise the
    /// same as <see cref="IAchPrenotificationService.List(AchPrenotificationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AchPrenotificationListPage>> List(
        AchPrenotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
