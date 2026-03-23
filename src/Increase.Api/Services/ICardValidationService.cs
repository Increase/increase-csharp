using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.CardValidations;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICardValidationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICardValidationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardValidationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Card Validation
    /// </summary>
    Task<CardValidation> Create(
        CardValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Card Validation
    /// </summary>
    Task<CardValidation> Retrieve(
        CardValidationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardValidationRetrieveParams, CancellationToken)"/>
    Task<CardValidation> Retrieve(
        string cardValidationID,
        CardValidationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Card Validations
    /// </summary>
    Task<CardValidationListPage> List(
        CardValidationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICardValidationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICardValidationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICardValidationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /card_validations</c>, but is otherwise the
    /// same as <see cref="ICardValidationService.Create(CardValidationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardValidation>> Create(
        CardValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_validations/{card_validation_id}</c>, but is otherwise the
    /// same as <see cref="ICardValidationService.Retrieve(CardValidationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardValidation>> Retrieve(
        CardValidationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CardValidationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CardValidation>> Retrieve(
        string cardValidationID,
        CardValidationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /card_validations</c>, but is otherwise the
    /// same as <see cref="ICardValidationService.List(CardValidationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CardValidationListPage>> List(
        CardValidationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
