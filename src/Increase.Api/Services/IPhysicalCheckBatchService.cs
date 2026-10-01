using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.PhysicalCheckBatches;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhysicalCheckBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhysicalCheckBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhysicalCheckBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Physical Check Batch
    /// </summary>
    Task<PhysicalCheckBatch> Create(
        PhysicalCheckBatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a pending Physical Check Batch, which cancels all of its related checks.
    /// </summary>
    Task<PhysicalCheckBatch> Cancel(
        PhysicalCheckBatchCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PhysicalCheckBatchCancelParams, CancellationToken)"/>
    Task<PhysicalCheckBatch> Cancel(
        string physicalCheckBatchID,
        PhysicalCheckBatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Completing a Physical Check Batch closes it to new Physical Checks and begins
    /// the process of printing and mailing it.
    /// </summary>
    Task<PhysicalCheckBatch> Complete(
        PhysicalCheckBatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(PhysicalCheckBatchCompleteParams, CancellationToken)"/>
    Task<PhysicalCheckBatch> Complete(
        string physicalCheckBatchID,
        PhysicalCheckBatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPhysicalCheckBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhysicalCheckBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhysicalCheckBatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /physical_check_batches</c>, but is otherwise the
    /// same as <see cref="IPhysicalCheckBatchService.Create(PhysicalCheckBatchCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCheckBatch>> Create(
        PhysicalCheckBatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /physical_check_batches/{physical_check_batch_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IPhysicalCheckBatchService.Cancel(PhysicalCheckBatchCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCheckBatch>> Cancel(
        PhysicalCheckBatchCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PhysicalCheckBatchCancelParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCheckBatch>> Cancel(
        string physicalCheckBatchID,
        PhysicalCheckBatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /physical_check_batches/{physical_check_batch_id}/complete</c>, but is otherwise the
    /// same as <see cref="IPhysicalCheckBatchService.Complete(PhysicalCheckBatchCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhysicalCheckBatch>> Complete(
        PhysicalCheckBatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(PhysicalCheckBatchCompleteParams, CancellationToken)"/>
    Task<HttpResponse<PhysicalCheckBatch>> Complete(
        string physicalCheckBatchID,
        PhysicalCheckBatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
