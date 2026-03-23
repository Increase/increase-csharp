using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.Exports;
using Exports = Increase.Api.Models.Exports;

namespace Increase.Api.Services.Simulations;

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
    public async Task<Exports::Export> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
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
    public async Task<HttpResponse<Exports::Export>> Create(
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
                var export = await response
                    .Deserialize<Exports::Export>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    export.Validate();
                }
                return export;
            }
        );
    }
}
