using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RealTimeDecisions;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class RealTimeDecisionService : IRealTimeDecisionService
{
    readonly Lazy<IRealTimeDecisionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRealTimeDecisionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IRealTimeDecisionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RealTimeDecisionService(this._client.WithOptions(modifier));
    }

    public RealTimeDecisionService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RealTimeDecisionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimeDecision> Retrieve(
        RealTimeDecisionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimeDecision> Retrieve(
        string realTimeDecisionID,
        RealTimeDecisionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RealTimeDecisionID = realTimeDecisionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimeDecision> Action(
        RealTimeDecisionActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Action(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimeDecision> Action(
        string realTimeDecisionID,
        RealTimeDecisionActionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Action(
            parameters with
            {
                RealTimeDecisionID = realTimeDecisionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class RealTimeDecisionServiceWithRawResponse : IRealTimeDecisionServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRealTimeDecisionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RealTimeDecisionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RealTimeDecisionServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimeDecision>> Retrieve(
        RealTimeDecisionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimeDecisionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimeDecisionID' cannot be null"
            );
        }

        HttpRequest<RealTimeDecisionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimeDecision = await response
                    .Deserialize<RealTimeDecision>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimeDecision.Validate();
                }
                return realTimeDecision;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimeDecision>> Retrieve(
        string realTimeDecisionID,
        RealTimeDecisionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RealTimeDecisionID = realTimeDecisionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimeDecision>> Action(
        RealTimeDecisionActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimeDecisionID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimeDecisionID' cannot be null"
            );
        }

        HttpRequest<RealTimeDecisionActionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimeDecision = await response
                    .Deserialize<RealTimeDecision>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimeDecision.Validate();
                }
                return realTimeDecision;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimeDecision>> Action(
        string realTimeDecisionID,
        RealTimeDecisionActionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Action(
            parameters with
            {
                RealTimeDecisionID = realTimeDecisionID,
            },
            cancellationToken
        );
    }
}
