using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISupplementalDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISupplementalDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISupplementalDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a supplemental document for an Entity
    /// </summary>
    Task<EntitySupplementalDocument> Create(
        SupplementalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Entity Supplemental Document Submissions
    /// </summary>
    Task<SupplementalDocumentListPage> List(
        SupplementalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISupplementalDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISupplementalDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISupplementalDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /entity_supplemental_documents</c>, but is otherwise the
    /// same as <see cref="ISupplementalDocumentService.Create(SupplementalDocumentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitySupplementalDocument>> Create(
        SupplementalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /entity_supplemental_documents</c>, but is otherwise the
    /// same as <see cref="ISupplementalDocumentService.List(SupplementalDocumentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SupplementalDocumentListPage>> List(
        SupplementalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    );
}
