using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class RealTimePaymentsTransferService : IRealTimePaymentsTransferService
{
    readonly Lazy<IRealTimePaymentsTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRealTimePaymentsTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IRealTimePaymentsTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RealTimePaymentsTransferService(this._client.WithOptions(modifier));
    }

    public RealTimePaymentsTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RealTimePaymentsTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsTransfer> Create(
        RealTimePaymentsTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsTransfer> Retrieve(
        RealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimePaymentsTransfer> Retrieve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsTransferListPage> List(
        RealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsTransfer> Approve(
        RealTimePaymentsTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimePaymentsTransfer> Approve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsTransfer> Cancel(
        RealTimePaymentsTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimePaymentsTransfer> Cancel(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class RealTimePaymentsTransferServiceWithRawResponse
    : IRealTimePaymentsTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRealTimePaymentsTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RealTimePaymentsTransferServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public RealTimePaymentsTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsTransfer>> Create(
        RealTimePaymentsTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RealTimePaymentsTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsTransfer = await response
                    .Deserialize<RealTimePaymentsTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsTransfer.Validate();
                }
                return realTimePaymentsTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsTransfer>> Retrieve(
        RealTimePaymentsTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimePaymentsTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimePaymentsTransferID' cannot be null"
            );
        }

        HttpRequest<RealTimePaymentsTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsTransfer = await response
                    .Deserialize<RealTimePaymentsTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsTransfer.Validate();
                }
                return realTimePaymentsTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimePaymentsTransfer>> Retrieve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsTransferListPage>> List(
        RealTimePaymentsTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RealTimePaymentsTransferListParams> request = new()
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
                    .Deserialize<RealTimePaymentsTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RealTimePaymentsTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsTransfer>> Approve(
        RealTimePaymentsTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimePaymentsTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimePaymentsTransferID' cannot be null"
            );
        }

        HttpRequest<RealTimePaymentsTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsTransfer = await response
                    .Deserialize<RealTimePaymentsTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsTransfer.Validate();
                }
                return realTimePaymentsTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimePaymentsTransfer>> Approve(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsTransfer>> Cancel(
        RealTimePaymentsTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimePaymentsTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimePaymentsTransferID' cannot be null"
            );
        }

        HttpRequest<RealTimePaymentsTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsTransfer = await response
                    .Deserialize<RealTimePaymentsTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsTransfer.Validate();
                }
                return realTimePaymentsTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimePaymentsTransfer>> Cancel(
        string realTimePaymentsTransferID,
        RealTimePaymentsTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                RealTimePaymentsTransferID = realTimePaymentsTransferID,
            },
            cancellationToken
        );
    }
}
