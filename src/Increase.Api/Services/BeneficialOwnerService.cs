using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class BeneficialOwnerService : IBeneficialOwnerService
{
    readonly Lazy<IBeneficialOwnerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBeneficialOwnerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IBeneficialOwnerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BeneficialOwnerService(this._client.WithOptions(modifier));
    }

    public BeneficialOwnerService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new BeneficialOwnerServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<EntityBeneficialOwner> Create(
        BeneficialOwnerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityBeneficialOwner> Retrieve(
        BeneficialOwnerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityBeneficialOwner> Retrieve(
        string entityBeneficialOwnerID,
        BeneficialOwnerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                EntityBeneficialOwnerID = entityBeneficialOwnerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<EntityBeneficialOwner> Update(
        BeneficialOwnerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityBeneficialOwner> Update(
        string entityBeneficialOwnerID,
        BeneficialOwnerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                EntityBeneficialOwnerID = entityBeneficialOwnerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BeneficialOwnerListPage> List(
        BeneficialOwnerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityBeneficialOwner> Archive(
        BeneficialOwnerArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityBeneficialOwner> Archive(
        string entityBeneficialOwnerID,
        BeneficialOwnerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                EntityBeneficialOwnerID = entityBeneficialOwnerID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class BeneficialOwnerServiceWithRawResponse : IBeneficialOwnerServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBeneficialOwnerServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BeneficialOwnerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BeneficialOwnerServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityBeneficialOwner>> Create(
        BeneficialOwnerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BeneficialOwnerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityBeneficialOwner = await response
                    .Deserialize<EntityBeneficialOwner>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityBeneficialOwner.Validate();
                }
                return entityBeneficialOwner;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityBeneficialOwner>> Retrieve(
        BeneficialOwnerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityBeneficialOwnerID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EntityBeneficialOwnerID' cannot be null"
            );
        }

        HttpRequest<BeneficialOwnerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityBeneficialOwner = await response
                    .Deserialize<EntityBeneficialOwner>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityBeneficialOwner.Validate();
                }
                return entityBeneficialOwner;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityBeneficialOwner>> Retrieve(
        string entityBeneficialOwnerID,
        BeneficialOwnerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                EntityBeneficialOwnerID = entityBeneficialOwnerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityBeneficialOwner>> Update(
        BeneficialOwnerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityBeneficialOwnerID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EntityBeneficialOwnerID' cannot be null"
            );
        }

        HttpRequest<BeneficialOwnerUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityBeneficialOwner = await response
                    .Deserialize<EntityBeneficialOwner>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityBeneficialOwner.Validate();
                }
                return entityBeneficialOwner;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityBeneficialOwner>> Update(
        string entityBeneficialOwnerID,
        BeneficialOwnerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                EntityBeneficialOwnerID = entityBeneficialOwnerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BeneficialOwnerListPage>> List(
        BeneficialOwnerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BeneficialOwnerListParams> request = new()
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
                    .Deserialize<BeneficialOwnerListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BeneficialOwnerListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityBeneficialOwner>> Archive(
        BeneficialOwnerArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntityBeneficialOwnerID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.EntityBeneficialOwnerID' cannot be null"
            );
        }

        HttpRequest<BeneficialOwnerArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entityBeneficialOwner = await response
                    .Deserialize<EntityBeneficialOwner>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entityBeneficialOwner.Validate();
                }
                return entityBeneficialOwner;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntityBeneficialOwner>> Archive(
        string entityBeneficialOwnerID,
        BeneficialOwnerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                EntityBeneficialOwnerID = entityBeneficialOwnerID,
            },
            cancellationToken
        );
    }
}
