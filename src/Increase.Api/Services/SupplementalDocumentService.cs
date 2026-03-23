using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class SupplementalDocumentService : ISupplementalDocumentService
{
    readonly Lazy<ISupplementalDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISupplementalDocumentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ISupplementalDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SupplementalDocumentService(this._client.WithOptions(modifier));
    }

    public SupplementalDocumentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SupplementalDocumentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<EntitySupplementalDocument> Create(
        SupplementalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SupplementalDocumentListPage> List(
        SupplementalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SupplementalDocumentServiceWithRawResponse
    : ISupplementalDocumentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISupplementalDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SupplementalDocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SupplementalDocumentServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitySupplementalDocument>> Create(
        SupplementalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SupplementalDocumentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitySupplementalDocument = await response
                    .Deserialize<EntitySupplementalDocument>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitySupplementalDocument.Validate();
                }
                return entitySupplementalDocument;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SupplementalDocumentListPage>> List(
        SupplementalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SupplementalDocumentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SupplementalDocumentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SupplementalDocumentListPage(this, parameters, page);
            }
        );
    }
}
