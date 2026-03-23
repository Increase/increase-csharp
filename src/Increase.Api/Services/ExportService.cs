using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Exports;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class ExportService : IExportService
{
    readonly Lazy<IExportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IExportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExportService(this._client.WithOptions(modifier));
    }

    public ExportService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExportServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Export> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Export> Retrieve(
        ExportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Export> Retrieve(
        string exportID,
        ExportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ExportID = exportID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExportListPage> List(
        ExportListParams? parameters = null,
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
public sealed class ExportServiceWithRawResponse : IExportServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExportServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Export>> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var export = await response.Deserialize<Export>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    export.Validate();
                }
                return export;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Export>> Retrieve(
        ExportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExportID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.ExportID' cannot be null");
        }

        HttpRequest<ExportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var export = await response.Deserialize<Export>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    export.Validate();
                }
                return export;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Export>> Retrieve(
        string exportID,
        ExportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ExportID = exportID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExportListPage>> List(
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportListParams> request = new()
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
                    .Deserialize<ExportListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExportListPage(this, parameters, page);
            }
        );
    }
}
