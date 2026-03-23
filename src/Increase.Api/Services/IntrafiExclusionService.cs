using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class IntrafiExclusionService : IIntrafiExclusionService
{
    readonly Lazy<IIntrafiExclusionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntrafiExclusionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IIntrafiExclusionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntrafiExclusionService(this._client.WithOptions(modifier));
    }

    public IntrafiExclusionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new IntrafiExclusionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<IntrafiExclusion> Create(
        IntrafiExclusionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IntrafiExclusion> Retrieve(
        IntrafiExclusionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntrafiExclusion> Retrieve(
        string intrafiExclusionID,
        IntrafiExclusionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                IntrafiExclusionID = intrafiExclusionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<IntrafiExclusionListPage> List(
        IntrafiExclusionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IntrafiExclusion> Archive(
        IntrafiExclusionArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntrafiExclusion> Archive(
        string intrafiExclusionID,
        IntrafiExclusionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                IntrafiExclusionID = intrafiExclusionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class IntrafiExclusionServiceWithRawResponse : IIntrafiExclusionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntrafiExclusionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntrafiExclusionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntrafiExclusionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiExclusion>> Create(
        IntrafiExclusionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IntrafiExclusionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiExclusion = await response
                    .Deserialize<IntrafiExclusion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiExclusion.Validate();
                }
                return intrafiExclusion;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiExclusion>> Retrieve(
        IntrafiExclusionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntrafiExclusionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.IntrafiExclusionID' cannot be null"
            );
        }

        HttpRequest<IntrafiExclusionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiExclusion = await response
                    .Deserialize<IntrafiExclusion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiExclusion.Validate();
                }
                return intrafiExclusion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntrafiExclusion>> Retrieve(
        string intrafiExclusionID,
        IntrafiExclusionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                IntrafiExclusionID = intrafiExclusionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiExclusionListPage>> List(
        IntrafiExclusionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IntrafiExclusionListParams> request = new()
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
                    .Deserialize<IntrafiExclusionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new IntrafiExclusionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiExclusion>> Archive(
        IntrafiExclusionArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntrafiExclusionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.IntrafiExclusionID' cannot be null"
            );
        }

        HttpRequest<IntrafiExclusionArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiExclusion = await response
                    .Deserialize<IntrafiExclusion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiExclusion.Validate();
                }
                return intrafiExclusion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntrafiExclusion>> Archive(
        string intrafiExclusionID,
        IntrafiExclusionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                IntrafiExclusionID = intrafiExclusionID,
            },
            cancellationToken
        );
    }
}
