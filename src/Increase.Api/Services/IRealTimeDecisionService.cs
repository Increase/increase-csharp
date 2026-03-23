using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.RealTimeDecisions;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRealTimeDecisionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRealTimeDecisionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRealTimeDecisionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Real-Time Decision
    /// </summary>
    Task<RealTimeDecision> Retrieve(
        RealTimeDecisionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RealTimeDecisionRetrieveParams, CancellationToken)"/>
    Task<RealTimeDecision> Retrieve(
        string realTimeDecisionID,
        RealTimeDecisionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Action a Real-Time Decision
    /// </summary>
    Task<RealTimeDecision> Action(
        RealTimeDecisionActionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Action(RealTimeDecisionActionParams, CancellationToken)"/>
    Task<RealTimeDecision> Action(
        string realTimeDecisionID,
        RealTimeDecisionActionParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRealTimeDecisionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRealTimeDecisionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRealTimeDecisionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /real_time_decisions/{real_time_decision_id}</c>, but is otherwise the
    /// same as <see cref="IRealTimeDecisionService.Retrieve(RealTimeDecisionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimeDecision>> Retrieve(
        RealTimeDecisionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RealTimeDecisionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RealTimeDecision>> Retrieve(
        string realTimeDecisionID,
        RealTimeDecisionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /real_time_decisions/{real_time_decision_id}/action</c>, but is otherwise the
    /// same as <see cref="IRealTimeDecisionService.Action(RealTimeDecisionActionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RealTimeDecision>> Action(
        RealTimeDecisionActionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Action(RealTimeDecisionActionParams, CancellationToken)"/>
    Task<HttpResponse<RealTimeDecision>> Action(
        string realTimeDecisionID,
        RealTimeDecisionActionParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
