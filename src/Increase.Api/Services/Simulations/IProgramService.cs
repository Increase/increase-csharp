using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Programs;
using Increase.Api.Models.Simulations.Programs;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates a [Program](#programs) being created in your group. By default, your
    /// group has one program called Commercial Banking. Note that when your group
    /// operates more than one program, `program_id` is a required field when creating
    /// accounts.
    /// </summary>
    Task<Program> Create(
        ProgramCreateParams parameters,
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
    /// Returns a raw HTTP response for <c>post /simulations/programs</c>, but is otherwise the
    /// same as <see cref="IProgramService.Create(ProgramCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Program>> Create(
        ProgramCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
