using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.Exports;
using Exports = Increase.Api.Models.Exports;

namespace Increase.Api.Services.Simulations;

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
    /// Many exports are created by you via POST /exports or in the Dashboard. Some
    /// exports are created automatically by Increase. For example, tax documents are
    /// published once a year. In sandbox, you can trigger the arrival of an export that
    /// would normally only be created automatically via this simulation.
    /// </summary>
    Task<Exports::Export> Create(
        ExportCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/exports</c>, but is otherwise the
    /// same as <see cref="IExportService.Create(ExportCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Exports::Export>> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
