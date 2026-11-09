using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Checkbooks;
using Increase.Api.Models.Simulations.Checkbooks;

namespace Increase.Api.Services.Simulations;

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
    /// Simulates the mailing of a [Checkbook](#checkbooks), which happens periodically
    /// throughout the day in production but can be sped up in sandbox. This Checkbook
    /// must have a `status` of `pending_submission` or `pending_mailing`.
    /// </summary>
    Task<Checkbook> Mail(
        CheckbookMailParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Mail(CheckbookMailParams, CancellationToken)"/>
    Task<Checkbook> Mail(
        string checkbookID,
        CheckbookMailParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /simulations/checkbooks/{checkbook_id}/mail</c>, but is otherwise the
    /// same as <see cref="ICheckbookService.Mail(CheckbookMailParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Checkbook>> Mail(
        CheckbookMailParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Mail(CheckbookMailParams, CancellationToken)"/>
    Task<HttpResponse<Checkbook>> Mail(
        string checkbookID,
        CheckbookMailParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
