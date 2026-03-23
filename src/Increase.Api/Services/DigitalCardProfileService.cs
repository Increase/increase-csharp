using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class DigitalCardProfileService : IDigitalCardProfileService
{
    readonly Lazy<IDigitalCardProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDigitalCardProfileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IDigitalCardProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DigitalCardProfileService(this._client.WithOptions(modifier));
    }

    public DigitalCardProfileService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new DigitalCardProfileServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalCardProfile> Create(
        DigitalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DigitalCardProfile> Retrieve(
        DigitalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DigitalCardProfile> Retrieve(
        string digitalCardProfileID,
        DigitalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DigitalCardProfileID = digitalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalCardProfileListPage> List(
        DigitalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DigitalCardProfile> Archive(
        DigitalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DigitalCardProfile> Archive(
        string digitalCardProfileID,
        DigitalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                DigitalCardProfileID = digitalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DigitalCardProfile> Clone(
        DigitalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Clone(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DigitalCardProfile> Clone(
        string digitalCardProfileID,
        DigitalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Clone(
            parameters with
            {
                DigitalCardProfileID = digitalCardProfileID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class DigitalCardProfileServiceWithRawResponse
    : IDigitalCardProfileServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDigitalCardProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DigitalCardProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DigitalCardProfileServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalCardProfile>> Create(
        DigitalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DigitalCardProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalCardProfile = await response
                    .Deserialize<DigitalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalCardProfile.Validate();
                }
                return digitalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalCardProfile>> Retrieve(
        DigitalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DigitalCardProfileID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.DigitalCardProfileID' cannot be null"
            );
        }

        HttpRequest<DigitalCardProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalCardProfile = await response
                    .Deserialize<DigitalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalCardProfile.Validate();
                }
                return digitalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DigitalCardProfile>> Retrieve(
        string digitalCardProfileID,
        DigitalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DigitalCardProfileID = digitalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalCardProfileListPage>> List(
        DigitalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DigitalCardProfileListParams> request = new()
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
                    .Deserialize<DigitalCardProfileListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DigitalCardProfileListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalCardProfile>> Archive(
        DigitalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DigitalCardProfileID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.DigitalCardProfileID' cannot be null"
            );
        }

        HttpRequest<DigitalCardProfileArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalCardProfile = await response
                    .Deserialize<DigitalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalCardProfile.Validate();
                }
                return digitalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DigitalCardProfile>> Archive(
        string digitalCardProfileID,
        DigitalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                DigitalCardProfileID = digitalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigitalCardProfile>> Clone(
        DigitalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DigitalCardProfileID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.DigitalCardProfileID' cannot be null"
            );
        }

        HttpRequest<DigitalCardProfileCloneParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digitalCardProfile = await response
                    .Deserialize<DigitalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digitalCardProfile.Validate();
                }
                return digitalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DigitalCardProfile>> Clone(
        string digitalCardProfileID,
        DigitalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Clone(
            parameters with
            {
                DigitalCardProfileID = digitalCardProfileID,
            },
            cancellationToken
        );
    }
}
