using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.PhysicalCards;
using PhysicalCards = Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Services.Simulations;

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
    public async Task<PhysicalCards::PhysicalCard> Create(
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
    public Task<PhysicalCards::PhysicalCard> Create(
        string physicalCardID,
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PhysicalCardID = physicalCardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhysicalCards::PhysicalCard> AdvanceShipment(
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AdvanceShipment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCards::PhysicalCard> AdvanceShipment(
        string physicalCardID,
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AdvanceShipment(
            parameters with
            {
                PhysicalCardID = physicalCardID,
            },
            cancellationToken
        );
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
    public async Task<HttpResponse<PhysicalCards::PhysicalCard>> Create(
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.PhysicalCardID' cannot be null");
        }

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
                    .Deserialize<PhysicalCards::PhysicalCard>(token)
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
    public Task<HttpResponse<PhysicalCards::PhysicalCard>> Create(
        string physicalCardID,
        PhysicalCardCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PhysicalCardID = physicalCardID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCards::PhysicalCard>> AdvanceShipment(
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCardID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.PhysicalCardID' cannot be null");
        }

        HttpRequest<PhysicalCardAdvanceShipmentParams> request = new()
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
                    .Deserialize<PhysicalCards::PhysicalCard>(token)
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
    public Task<HttpResponse<PhysicalCards::PhysicalCard>> AdvanceShipment(
        string physicalCardID,
        PhysicalCardAdvanceShipmentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AdvanceShipment(
            parameters with
            {
                PhysicalCardID = physicalCardID,
            },
            cancellationToken
        );
    }
}
