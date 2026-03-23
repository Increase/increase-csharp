using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBookkeepingEntrySetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBookkeepingEntrySetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookkeepingEntrySetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Bookkeeping Entry Set
    /// </summary>
    Task<BookkeepingEntrySet> Create(
        BookkeepingEntrySetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Bookkeeping Entry Set
    /// </summary>
    Task<BookkeepingEntrySet> Retrieve(
        BookkeepingEntrySetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BookkeepingEntrySetRetrieveParams, CancellationToken)"/>
    Task<BookkeepingEntrySet> Retrieve(
        string bookkeepingEntrySetID,
        BookkeepingEntrySetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Bookkeeping Entry Sets
    /// </summary>
    Task<BookkeepingEntrySetListPage> List(
        BookkeepingEntrySetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBookkeepingEntrySetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBookkeepingEntrySetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookkeepingEntrySetServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /bookkeeping_entry_sets</c>, but is otherwise the
    /// same as <see cref="IBookkeepingEntrySetService.Create(BookkeepingEntrySetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingEntrySet>> Create(
        BookkeepingEntrySetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bookkeeping_entry_sets/{bookkeeping_entry_set_id}</c>, but is otherwise the
    /// same as <see cref="IBookkeepingEntrySetService.Retrieve(BookkeepingEntrySetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingEntrySet>> Retrieve(
        BookkeepingEntrySetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BookkeepingEntrySetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BookkeepingEntrySet>> Retrieve(
        string bookkeepingEntrySetID,
        BookkeepingEntrySetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bookkeeping_entry_sets</c>, but is otherwise the
    /// same as <see cref="IBookkeepingEntrySetService.List(BookkeepingEntrySetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingEntrySetListPage>> List(
        BookkeepingEntrySetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
