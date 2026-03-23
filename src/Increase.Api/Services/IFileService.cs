using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Files;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// To upload a file to Increase, you'll need to send a request of Content-Type
    /// `multipart/form-data`. The request should contain the file you would like to
    /// upload, as well as the parameters for creating a file.
    /// </summary>
    Task<File> Create(FileCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve a File
    /// </summary>
    Task<File> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FileRetrieveParams, CancellationToken)"/>
    Task<File> Retrieve(
        string fileID,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Files
    /// </summary>
    Task<FileListPage> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /files</c>, but is otherwise the
    /// same as <see cref="IFileService.Create(FileCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<File>> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /files/{file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Retrieve(FileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<File>> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<File>> Retrieve(
        string fileID,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /files</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileListPage>> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
