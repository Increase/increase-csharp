using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CheckTransferService : ICheckTransferService
{
    readonly Lazy<ICheckTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICheckTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckTransferService(this._client.WithOptions(modifier));
    }

    public CheckTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CheckTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CheckTransfer> Create(
        CheckTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CheckTransfer> Retrieve(
        CheckTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckTransfer> Retrieve(
        string checkTransferID,
        CheckTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckTransferListPage> List(
        CheckTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CheckTransfer> Approve(
        CheckTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckTransfer> Approve(
        string checkTransferID,
        CheckTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckTransfer> Cancel(
        CheckTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckTransfer> Cancel(
        string checkTransferID,
        CheckTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckTransfer> StopPayment(
        CheckTransferStopPaymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.StopPayment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckTransfer> StopPayment(
        string checkTransferID,
        CheckTransferStopPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopPayment(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class CheckTransferServiceWithRawResponse : ICheckTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CheckTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransfer>> Create(
        CheckTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CheckTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkTransfer = await response
                    .Deserialize<CheckTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkTransfer.Validate();
                }
                return checkTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransfer>> Retrieve(
        CheckTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckTransferID' cannot be null");
        }

        HttpRequest<CheckTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkTransfer = await response
                    .Deserialize<CheckTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkTransfer.Validate();
                }
                return checkTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckTransfer>> Retrieve(
        string checkTransferID,
        CheckTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransferListPage>> List(
        CheckTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CheckTransferListParams> request = new()
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
                    .Deserialize<CheckTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CheckTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransfer>> Approve(
        CheckTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckTransferID' cannot be null");
        }

        HttpRequest<CheckTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkTransfer = await response
                    .Deserialize<CheckTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkTransfer.Validate();
                }
                return checkTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckTransfer>> Approve(
        string checkTransferID,
        CheckTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransfer>> Cancel(
        CheckTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckTransferID' cannot be null");
        }

        HttpRequest<CheckTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkTransfer = await response
                    .Deserialize<CheckTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkTransfer.Validate();
                }
                return checkTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckTransfer>> Cancel(
        string checkTransferID,
        CheckTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransfer>> StopPayment(
        CheckTransferStopPaymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckTransferID' cannot be null");
        }

        HttpRequest<CheckTransferStopPaymentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkTransfer = await response
                    .Deserialize<CheckTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkTransfer.Validate();
                }
                return checkTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckTransfer>> StopPayment(
        string checkTransferID,
        CheckTransferStopPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StopPayment(
            parameters with
            {
                CheckTransferID = checkTransferID,
            },
            cancellationToken
        );
    }
}
