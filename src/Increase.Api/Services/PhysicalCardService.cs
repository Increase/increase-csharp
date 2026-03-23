using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class PhysicalCardService : IPhysicalCardService
{
    readonly Lazy<IPhysicalCardServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhysicalCardServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IPhysicalCardService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhysicalCardService(this._client.WithOptions(modifier));
    }

    public PhysicalCardService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PhysicalCardServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCard> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhysicalCard> Retrieve(
        PhysicalCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCard> Retrieve(
        string physicalCardID,
        PhysicalCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                PhysicalCardID = physicalCardID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCard> Update(
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCard> Update(
        string physicalCardID,
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { PhysicalCardID = physicalCardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhysicalCardListPage> List(
        PhysicalCardListParams? parameters = null,
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
public sealed class PhysicalCardServiceWithRawResponse : IPhysicalCardServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhysicalCardServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhysicalCardServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhysicalCardServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCard>> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhysicalCardCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCard = await response
                    .Deserialize<PhysicalCard>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCard.Validate();
                }
                return physicalCard;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCard>> Retrieve(
        PhysicalCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.PhysicalCardID' cannot be null");
        }

        HttpRequest<PhysicalCardRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCard = await response
                    .Deserialize<PhysicalCard>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCard.Validate();
                }
                return physicalCard;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCard>> Retrieve(
        string physicalCardID,
        PhysicalCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                PhysicalCardID = physicalCardID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCard>> Update(
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.PhysicalCardID' cannot be null");
        }

        HttpRequest<PhysicalCardUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCard = await response
                    .Deserialize<PhysicalCard>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCard.Validate();
                }
                return physicalCard;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCard>> Update(
        string physicalCardID,
        PhysicalCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { PhysicalCardID = physicalCardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCardListPage>> List(
        PhysicalCardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhysicalCardListParams> request = new()
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
                    .Deserialize<PhysicalCardListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PhysicalCardListPage(this, parameters, page);
            }
        );
    }
}
