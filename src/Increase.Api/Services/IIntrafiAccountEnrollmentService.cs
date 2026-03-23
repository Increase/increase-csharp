using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntrafiAccountEnrollmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntrafiAccountEnrollmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrafiAccountEnrollmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Enroll an account in the IntraFi deposit sweep network
    /// </summary>
    Task<IntrafiAccountEnrollment> Create(
        IntrafiAccountEnrollmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an IntraFi Account Enrollment
    /// </summary>
    Task<IntrafiAccountEnrollment> Retrieve(
        IntrafiAccountEnrollmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntrafiAccountEnrollmentRetrieveParams, CancellationToken)"/>
    Task<IntrafiAccountEnrollment> Retrieve(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List IntraFi Account Enrollments
    /// </summary>
    Task<IntrafiAccountEnrollmentListPage> List(
        IntrafiAccountEnrollmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unenroll an account from IntraFi
    /// </summary>
    Task<IntrafiAccountEnrollment> Unenroll(
        IntrafiAccountEnrollmentUnenrollParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unenroll(IntrafiAccountEnrollmentUnenrollParams, CancellationToken)"/>
    Task<IntrafiAccountEnrollment> Unenroll(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentUnenrollParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIntrafiAccountEnrollmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntrafiAccountEnrollmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrafiAccountEnrollmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /intrafi_account_enrollments</c>, but is otherwise the
    /// same as <see cref="IIntrafiAccountEnrollmentService.Create(IntrafiAccountEnrollmentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiAccountEnrollment>> Create(
        IntrafiAccountEnrollmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /intrafi_account_enrollments/{intrafi_account_enrollment_id}</c>, but is otherwise the
    /// same as <see cref="IIntrafiAccountEnrollmentService.Retrieve(IntrafiAccountEnrollmentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiAccountEnrollment>> Retrieve(
        IntrafiAccountEnrollmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntrafiAccountEnrollmentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<IntrafiAccountEnrollment>> Retrieve(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /intrafi_account_enrollments</c>, but is otherwise the
    /// same as <see cref="IIntrafiAccountEnrollmentService.List(IntrafiAccountEnrollmentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiAccountEnrollmentListPage>> List(
        IntrafiAccountEnrollmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /intrafi_account_enrollments/{intrafi_account_enrollment_id}/unenroll</c>, but is otherwise the
    /// same as <see cref="IIntrafiAccountEnrollmentService.Unenroll(IntrafiAccountEnrollmentUnenrollParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrafiAccountEnrollment>> Unenroll(
        IntrafiAccountEnrollmentUnenrollParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unenroll(IntrafiAccountEnrollmentUnenrollParams, CancellationToken)"/>
    Task<HttpResponse<IntrafiAccountEnrollment>> Unenroll(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentUnenrollParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
