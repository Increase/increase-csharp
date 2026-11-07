using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CheckbookChecks;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckbookCheckService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckbookCheckServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckbookCheckService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Checkbook Check
    /// </summary>
    Task<CheckbookCheck> Retrieve(
        CheckbookCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckbookCheckRetrieveParams, CancellationToken)"/>
    Task<CheckbookCheck> Retrieve(
        string checkbookCheckID,
        CheckbookCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Checkbook Checks
    /// </summary>
    Task<CheckbookCheckListPage> List(
        CheckbookCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop a Checkbook Check. A stopped check cannot be deposited.
    /// </summary>
    Task<CheckbookCheck> Stop(
        CheckbookCheckStopParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stop(CheckbookCheckStopParams, CancellationToken)"/>
    Task<CheckbookCheck> Stop(
        string checkbookCheckID,
        CheckbookCheckStopParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckbookCheckService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckbookCheckServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckbookCheckServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /checkbook_checks/{checkbook_check_id}</c>, but is otherwise the
    /// same as <see cref="ICheckbookCheckService.Retrieve(CheckbookCheckRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckbookCheck>> Retrieve(
        CheckbookCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CheckbookCheckRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CheckbookCheck>> Retrieve(
        string checkbookCheckID,
        CheckbookCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /checkbook_checks</c>, but is otherwise the
    /// same as <see cref="ICheckbookCheckService.List(CheckbookCheckListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckbookCheckListPage>> List(
        CheckbookCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /checkbook_checks/{checkbook_check_id}/stop</c>, but is otherwise the
    /// same as <see cref="ICheckbookCheckService.Stop(CheckbookCheckStopParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckbookCheck>> Stop(
        CheckbookCheckStopParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stop(CheckbookCheckStopParams, CancellationToken)"/>
    Task<HttpResponse<CheckbookCheck>> Stop(
        string checkbookCheckID,
        CheckbookCheckStopParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
