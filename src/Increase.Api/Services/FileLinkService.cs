using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.FileLinks;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class FileLinkService : IFileLinkService
{
    readonly Lazy<IFileLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFileLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IFileLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileLinkService(this._client.WithOptions(modifier));
    }

    public FileLinkService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FileLinkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileLink> Create(
        FileLinkCreateParams parameters,
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
public sealed class FileLinkServiceWithRawResponse : IFileLinkServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFileLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FileLinkServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileLink>> Create(
        FileLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FileLinkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fileLink = await response.Deserialize<FileLink>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fileLink.Validate();
                }
                return fileLink;
            }
        );
    }
}
