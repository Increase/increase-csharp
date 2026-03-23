using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class FednowTransferService : IFednowTransferService
{
    readonly Lazy<IFednowTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFednowTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IFednowTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FednowTransferService(this._client.WithOptions(modifier));
    }

    public FednowTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new FednowTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<FednowTransfer> Create(
        FednowTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FednowTransfer> Retrieve(
        FednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FednowTransfer> Retrieve(
        string fednowTransferID,
        FednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<FednowTransferListPage> List(
        FednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FednowTransfer> Approve(
        FednowTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FednowTransfer> Approve(
        string fednowTransferID,
        FednowTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<FednowTransfer> Cancel(
        FednowTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FednowTransfer> Cancel(
        string fednowTransferID,
        FednowTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class FednowTransferServiceWithRawResponse : IFednowTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFednowTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FednowTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FednowTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FednowTransfer>> Create(
        FednowTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FednowTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fednowTransfer = await response
                    .Deserialize<FednowTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fednowTransfer.Validate();
                }
                return fednowTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FednowTransfer>> Retrieve(
        FednowTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FednowTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.FednowTransferID' cannot be null");
        }

        HttpRequest<FednowTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fednowTransfer = await response
                    .Deserialize<FednowTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fednowTransfer.Validate();
                }
                return fednowTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FednowTransfer>> Retrieve(
        string fednowTransferID,
        FednowTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FednowTransferListPage>> List(
        FednowTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FednowTransferListParams> request = new()
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
                    .Deserialize<FednowTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new FednowTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FednowTransfer>> Approve(
        FednowTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FednowTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.FednowTransferID' cannot be null");
        }

        HttpRequest<FednowTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fednowTransfer = await response
                    .Deserialize<FednowTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fednowTransfer.Validate();
                }
                return fednowTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FednowTransfer>> Approve(
        string fednowTransferID,
        FednowTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FednowTransfer>> Cancel(
        FednowTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FednowTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.FednowTransferID' cannot be null");
        }

        HttpRequest<FednowTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fednowTransfer = await response
                    .Deserialize<FednowTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fednowTransfer.Validate();
                }
                return fednowTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FednowTransfer>> Cancel(
        string fednowTransferID,
        FednowTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                FednowTransferID = fednowTransferID,
            },
            cancellationToken
        );
    }
}
