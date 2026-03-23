using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class PhysicalCardProfileService : IPhysicalCardProfileService
{
    readonly Lazy<IPhysicalCardProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhysicalCardProfileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IPhysicalCardProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhysicalCardProfileService(this._client.WithOptions(modifier));
    }

    public PhysicalCardProfileService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PhysicalCardProfileServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCardProfile> Create(
        PhysicalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhysicalCardProfile> Retrieve(
        PhysicalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCardProfile> Retrieve(
        string physicalCardProfileID,
        PhysicalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                PhysicalCardProfileID = physicalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCardProfileListPage> List(
        PhysicalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhysicalCardProfile> Archive(
        PhysicalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCardProfile> Archive(
        string physicalCardProfileID,
        PhysicalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                PhysicalCardProfileID = physicalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCardProfile> Clone(
        PhysicalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Clone(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCardProfile> Clone(
        string physicalCardProfileID,
        PhysicalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Clone(
            parameters with
            {
                PhysicalCardProfileID = physicalCardProfileID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class PhysicalCardProfileServiceWithRawResponse
    : IPhysicalCardProfileServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhysicalCardProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhysicalCardProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhysicalCardProfileServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCardProfile>> Create(
        PhysicalCardProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhysicalCardProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCardProfile = await response
                    .Deserialize<PhysicalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCardProfile.Validate();
                }
                return physicalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCardProfile>> Retrieve(
        PhysicalCardProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardProfileID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PhysicalCardProfileID' cannot be null"
            );
        }

        HttpRequest<PhysicalCardProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCardProfile = await response
                    .Deserialize<PhysicalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCardProfile.Validate();
                }
                return physicalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCardProfile>> Retrieve(
        string physicalCardProfileID,
        PhysicalCardProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                PhysicalCardProfileID = physicalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCardProfileListPage>> List(
        PhysicalCardProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhysicalCardProfileListParams> request = new()
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
                    .Deserialize<PhysicalCardProfileListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PhysicalCardProfileListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCardProfile>> Archive(
        PhysicalCardProfileArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardProfileID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PhysicalCardProfileID' cannot be null"
            );
        }

        HttpRequest<PhysicalCardProfileArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCardProfile = await response
                    .Deserialize<PhysicalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCardProfile.Validate();
                }
                return physicalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCardProfile>> Archive(
        string physicalCardProfileID,
        PhysicalCardProfileArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                PhysicalCardProfileID = physicalCardProfileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCardProfile>> Clone(
        PhysicalCardProfileCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardProfileID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PhysicalCardProfileID' cannot be null"
            );
        }

        HttpRequest<PhysicalCardProfileCloneParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCardProfile = await response
                    .Deserialize<PhysicalCardProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCardProfile.Validate();
                }
                return physicalCardProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCardProfile>> Clone(
        string physicalCardProfileID,
        PhysicalCardProfileCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Clone(
            parameters with
            {
                PhysicalCardProfileID = physicalCardProfileID,
            },
            cancellationToken
        );
    }
}
