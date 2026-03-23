using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardDisputeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardDisputeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardDisputeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Card Dispute
    /// </summary>
    Task<CardDispute> Create(
        CardDisputeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Card Dispute
    /// </summary>
    Task<CardDispute> Retrieve(
        CardDisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardDisputeRetrieveParams, CancellationToken)"/>
    Task<CardDispute> Retrieve(
        string cardDisputeID,
        CardDisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Disputes
    /// </summary>
    Task<CardDisputeListPage> List(
        CardDisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit a User Submission for a Card Dispute
    /// </summary>
    Task<CardDispute> SubmitUserSubmission(
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SubmitUserSubmission(CardDisputeSubmitUserSubmissionParams, CancellationToken)"/>
    Task<CardDispute> SubmitUserSubmission(
        string cardDisputeID,
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Withdraw a Card Dispute
    /// </summary>
    Task<CardDispute> Withdraw(
        CardDisputeWithdrawParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Withdraw(CardDisputeWithdrawParams, CancellationToken)"/>
    Task<CardDispute> Withdraw(
        string cardDisputeID,
        CardDisputeWithdrawParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardDisputeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardDisputeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardDisputeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_disputes</c>, but is otherwise the
    /// same as <see cref="ICardDisputeService.Create(CardDisputeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDispute>> Create(
        CardDisputeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_disputes/{card_dispute_id}</c>, but is otherwise the
    /// same as <see cref="ICardDisputeService.Retrieve(CardDisputeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDispute>> Retrieve(
        CardDisputeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardDisputeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CardDispute>> Retrieve(
        string cardDisputeID,
        CardDisputeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_disputes</c>, but is otherwise the
    /// same as <see cref="ICardDisputeService.List(CardDisputeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDisputeListPage>> List(
        CardDisputeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_disputes/{card_dispute_id}/submit_user_submission</c>, but is otherwise the
    /// same as <see cref="ICardDisputeService.SubmitUserSubmission(CardDisputeSubmitUserSubmissionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDispute>> SubmitUserSubmission(
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SubmitUserSubmission(CardDisputeSubmitUserSubmissionParams, CancellationToken)"/>
    Task<HttpResponse<CardDispute>> SubmitUserSubmission(
        string cardDisputeID,
        CardDisputeSubmitUserSubmissionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_disputes/{card_dispute_id}/withdraw</c>, but is otherwise the
    /// same as <see cref="ICardDisputeService.Withdraw(CardDisputeWithdrawParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardDispute>> Withdraw(
        CardDisputeWithdrawParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Withdraw(CardDisputeWithdrawParams, CancellationToken)"/>
    Task<HttpResponse<CardDispute>> Withdraw(
        string cardDisputeID,
        CardDisputeWithdrawParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
