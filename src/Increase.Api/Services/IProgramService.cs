using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Programs;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProgramService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProgramServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProgramService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Program
    /// </summary>
    Task<Program> Retrieve(
        ProgramRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProgramRetrieveParams, CancellationToken)"/>
    Task<Program> Retrieve(
        string programID,
        ProgramRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Programs
    /// </summary>
    Task<ProgramListPage> List(
        ProgramListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProgramService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProgramServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProgramServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /programs/{program_id}</c>, but is otherwise the
    /// same as <see cref="IProgramService.Retrieve(ProgramRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Program>> Retrieve(
        ProgramRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProgramRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Program>> Retrieve(
        string programID,
        ProgramRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /programs</c>, but is otherwise the
    /// same as <see cref="IProgramService.List(ProgramListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProgramListPage>> List(
        ProgramListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
