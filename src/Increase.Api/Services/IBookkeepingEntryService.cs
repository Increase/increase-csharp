using System;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.BookkeepingEntries;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBookkeepingEntryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBookkeepingEntryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookkeepingEntryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a Bookkeeping Entry
    /// </summary>
    Task<BookkeepingEntry> Retrieve(
        BookkeepingEntryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BookkeepingEntryRetrieveParams, CancellationToken)"/>
    Task<BookkeepingEntry> Retrieve(
        string bookkeepingEntryID,
        BookkeepingEntryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Bookkeeping Entries
    /// </summary>
    Task<BookkeepingEntryListPage> List(
        BookkeepingEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBookkeepingEntryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBookkeepingEntryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookkeepingEntryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bookkeeping_entries/{bookkeeping_entry_id}</c>, but is otherwise the
    /// same as <see cref="IBookkeepingEntryService.Retrieve(BookkeepingEntryRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingEntry>> Retrieve(
        BookkeepingEntryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BookkeepingEntryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BookkeepingEntry>> Retrieve(
        string bookkeepingEntryID,
        BookkeepingEntryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bookkeeping_entries</c>, but is otherwise the
    /// same as <see cref="IBookkeepingEntryService.List(BookkeepingEntryListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookkeepingEntryListPage>> List(
        BookkeepingEntryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
