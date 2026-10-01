using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PhysicalCheckBatches;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class PhysicalCheckBatchService : IPhysicalCheckBatchService
{
    readonly Lazy<IPhysicalCheckBatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhysicalCheckBatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IPhysicalCheckBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhysicalCheckBatchService(this._client.WithOptions(modifier));
    }

    public PhysicalCheckBatchService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PhysicalCheckBatchServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCheckBatch> Create(
        PhysicalCheckBatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhysicalCheckBatch> Cancel(
        PhysicalCheckBatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCheckBatch> Cancel(
        string physicalCheckBatchID,
        PhysicalCheckBatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                PhysicalCheckBatchID = physicalCheckBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<PhysicalCheckBatch> Complete(
        PhysicalCheckBatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhysicalCheckBatch> Complete(
        string physicalCheckBatchID,
        PhysicalCheckBatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                PhysicalCheckBatchID = physicalCheckBatchID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class PhysicalCheckBatchServiceWithRawResponse
    : IPhysicalCheckBatchServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhysicalCheckBatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhysicalCheckBatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhysicalCheckBatchServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCheckBatch>> Create(
        PhysicalCheckBatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhysicalCheckBatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCheckBatch = await response
                    .Deserialize<PhysicalCheckBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCheckBatch.Validate();
                }
                return physicalCheckBatch;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCheckBatch>> Cancel(
        PhysicalCheckBatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCheckBatchID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PhysicalCheckBatchID' cannot be null"
            );
        }

        HttpRequest<PhysicalCheckBatchCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCheckBatch = await response
                    .Deserialize<PhysicalCheckBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCheckBatch.Validate();
                }
                return physicalCheckBatch;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCheckBatch>> Cancel(
        string physicalCheckBatchID,
        PhysicalCheckBatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                PhysicalCheckBatchID = physicalCheckBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhysicalCheckBatch>> Complete(
        PhysicalCheckBatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhysicalCheckBatchID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.PhysicalCheckBatchID' cannot be null"
            );
        }

        HttpRequest<PhysicalCheckBatchCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var physicalCheckBatch = await response
                    .Deserialize<PhysicalCheckBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    physicalCheckBatch.Validate();
                }
                return physicalCheckBatch;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhysicalCheckBatch>> Complete(
        string physicalCheckBatchID,
        PhysicalCheckBatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(
            parameters with
            {
                PhysicalCheckBatchID = physicalCheckBatchID,
            },
            cancellationToken
        );
    }
}
