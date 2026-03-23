using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.FileLinks;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFileLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a File Link
    /// </summary>
    Task<FileLink> Create(
        FileLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /file_links</c>, but is otherwise the
    /// same as <see cref="IFileLinkService.Create(FileLinkCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileLink>> Create(
        FileLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
