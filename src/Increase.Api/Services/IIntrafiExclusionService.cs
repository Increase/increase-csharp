using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntrafiExclusionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntrafiExclusionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrafiExclusionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an IntraFi Exclusion
    /// </summary>
    Task<IntrafiExclusion> Create(
        IntrafiExclusionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an IntraFi Exclusion
    /// </summary>
    Task<IntrafiExclusion> Retrieve(
        IntrafiExclusionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntrafiExclusionRetrieveParams, CancellationToken)"/>
    Task<IntrafiExclusion> Retrieve(
        string intrafiExclusionID,
        IntrafiExclusionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List IntraFi Exclusions
    /// </summary>
    Task<IntrafiExclusionListPage> List(
        IntrafiExclusionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive an IntraFi Exclusion
    /// </summary>
    Task<IntrafiExclusion> Archive(
        IntrafiExclusionArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(IntrafiExclusionArchiveParams, CancellationToken)"/>
    Task<IntrafiExclusion> Archive(
        string intrafiExclusionID,
        IntrafiExclusionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIntrafiExclusionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntrafiExclusionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrafiExclusionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /intrafi_exclusions</c>, but is otherwise the
    /// same as <see cref="IIntrafiExclusionService.Create(IntrafiExclusionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiExclusion>> Create(
        IntrafiExclusionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /intrafi_exclusions/{intrafi_exclusion_id}</c>, but is otherwise the
    /// same as <see cref="IIntrafiExclusionService.Retrieve(IntrafiExclusionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiExclusion>> Retrieve(
        IntrafiExclusionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntrafiExclusionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<IntrafiExclusion>> Retrieve(
        string intrafiExclusionID,
        IntrafiExclusionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /intrafi_exclusions</c>, but is otherwise the
    /// same as <see cref="IIntrafiExclusionService.List(IntrafiExclusionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiExclusionListPage>> List(
        IntrafiExclusionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /intrafi_exclusions/{intrafi_exclusion_id}/archive</c>, but is otherwise the
    /// same as <see cref="IIntrafiExclusionService.Archive(IntrafiExclusionArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiExclusion>> Archive(
        IntrafiExclusionArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(IntrafiExclusionArchiveParams, CancellationToken)"/>
    Task<HttpResponse<IntrafiExclusion>> Archive(
        string intrafiExclusionID,
        IntrafiExclusionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
