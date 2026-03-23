using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardPayments;
using Increase.Api.Models.Simulations.CardBalanceInquiries;

namespace Increase.Api.Services.Simulations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardBalanceInquiryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardBalanceInquiryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardBalanceInquiryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Simulates a balance inquiry on a [Card](#cards).
    /// </summary>
    Task<CardPayment> Create(
        CardBalanceInquiryCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardBalanceInquiryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardBalanceInquiryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardBalanceInquiryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /simulations/card_balance_inquiries</c>, but is otherwise the
    /// same as <see cref="ICardBalanceInquiryService.Create(CardBalanceInquiryCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardPayment>> Create(
        CardBalanceInquiryCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
