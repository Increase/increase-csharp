using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AchTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class AchTransferService : IAchTransferService
{
    readonly Lazy<IAchTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAchTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AchTransferService(this._client.WithOptions(modifier));
    }

    public AchTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AchTransferServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Create(
        AchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Retrieve(
        AchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Retrieve(
        string achTransferID,
        AchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AchTransferListPage> List(
        AchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Approve(
        AchTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Approve(
        string achTransferID,
        AchTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Cancel(
        AchTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Cancel(
        string achTransferID,
        AchTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AchTransferServiceWithRawResponse : IAchTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAchTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AchTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AchTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Create(
        AchTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AchTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Retrieve(
        AchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Retrieve(
        string achTransferID,
        AchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransferListPage>> List(
        AchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AchTransferListParams> request = new()
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
                    .Deserialize<AchTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AchTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Approve(
        AchTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Approve(
        string achTransferID,
        AchTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Cancel(
        AchTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Cancel(
        string achTransferID,
        AchTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }
}
