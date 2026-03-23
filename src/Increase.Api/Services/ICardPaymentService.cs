using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Card Payment
    /// </summary>
    Task<CardPayment> Retrieve(
        CardPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardPaymentRetrieveParams, CancellationToken)"/>
    Task<CardPayment> Retrieve(
        string cardPaymentID,
        CardPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Payments
    /// </summary>
    Task<CardPaymentListPage> List(
        CardPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardPaymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_payments/{card_payment_id}</c>, but is otherwise the
    /// same as <see cref="ICardPaymentService.Retrieve(CardPaymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> Retrieve(
        CardPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardPaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CardPayment>> Retrieve(
        string cardPaymentID,
        CardPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_payments</c>, but is otherwise the
    /// same as <see cref="ICardPaymentService.List(CardPaymentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPaymentListPage>> List(
        CardPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
