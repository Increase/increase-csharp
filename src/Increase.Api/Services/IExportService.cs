using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Exports;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an Export
    /// </summary>
    Task<Export> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an Export
    /// </summary>
    Task<Export> Retrieve(
        ExportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExportRetrieveParams, CancellationToken)"/>
    Task<Export> Retrieve(
        string exportID,
        ExportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Exports
    /// </summary>
    Task<ExportListPage> List(
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /exports</c>, but is otherwise the
    /// same as <see cref="IExportService.Create(ExportCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Export>> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /exports/{export_id}</c>, but is otherwise the
    /// same as <see cref="IExportService.Retrieve(ExportRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Export>> Retrieve(
        ExportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Export>> Retrieve(
        string exportID,
        ExportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /exports</c>, but is otherwise the
    /// same as <see cref="IExportService.List(ExportListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExportListPage>> List(
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
