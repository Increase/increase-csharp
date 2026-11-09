using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Checkbooks;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckbookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckbookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckbookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Checkbook
    /// </summary>
    Task<Checkbook> Create(
        CheckbookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Checkbook
    /// </summary>
    Task<Checkbook> Retrieve(
        CheckbookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckbookRetrieveParams, CancellationToken)"/>
    Task<Checkbook> Retrieve(
        string checkbookID,
        CheckbookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Checkbooks
    /// </summary>
    Task<CheckbookListPage> List(
        CheckbookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop a Checkbook. Stopping a Checkbook stops all of its checks that have not yet
    /// been deposited.
    /// </summary>
    Task<Checkbook> Stop(
        CheckbookStopParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stop(CheckbookStopParams, CancellationToken)"/>
    Task<Checkbook> Stop(
        string checkbookID,
        CheckbookStopParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckbookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckbookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckbookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /checkbooks</c>, but is otherwise the
    /// same as <see cref="ICheckbookService.Create(CheckbookCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Checkbook>> Create(
        CheckbookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /checkbooks/{checkbook_id}</c>, but is otherwise the
    /// same as <see cref="ICheckbookService.Retrieve(CheckbookRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Checkbook>> Retrieve(
        CheckbookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckbookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Checkbook>> Retrieve(
        string checkbookID,
        CheckbookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /checkbooks</c>, but is otherwise the
    /// same as <see cref="ICheckbookService.List(CheckbookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckbookListPage>> List(
        CheckbookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /checkbooks/{checkbook_id}/stop</c>, but is otherwise the
    /// same as <see cref="ICheckbookService.Stop(CheckbookStopParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Checkbook>> Stop(
        CheckbookStopParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stop(CheckbookStopParams, CancellationToken)"/>
    Task<HttpResponse<Checkbook>> Stop(
        string checkbookID,
        CheckbookStopParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
