using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class WireTransferService : IWireTransferService
{
    readonly Lazy<IWireTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWireTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IWireTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WireTransferService(this._client.WithOptions(modifier));
    }

    public WireTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WireTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<WireTransfer> Create(
        WireTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireTransfer> Retrieve(
        WireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireTransfer> Retrieve(
        string wireTransferID,
        WireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                WireTransferID = wireTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<WireTransferListPage> List(
        WireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireTransfer> Approve(
        WireTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireTransfer> Approve(
        string wireTransferID,
        WireTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WireTransfer> Cancel(
        WireTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WireTransfer> Cancel(
        string wireTransferID,
        WireTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WireTransferServiceWithRawResponse : IWireTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWireTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WireTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WireTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransfer>> Create(
        WireTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WireTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireTransfer = await response
                    .Deserialize<WireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireTransfer.Validate();
                }
                return wireTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransfer>> Retrieve(
        WireTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.WireTransferID' cannot be null");
        }

        HttpRequest<WireTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireTransfer = await response
                    .Deserialize<WireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireTransfer.Validate();
                }
                return wireTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WireTransfer>> Retrieve(
        string wireTransferID,
        WireTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                WireTransferID = wireTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransferListPage>> List(
        WireTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WireTransferListParams> request = new()
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
                    .Deserialize<WireTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WireTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransfer>> Approve(
        WireTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.WireTransferID' cannot be null");
        }

        HttpRequest<WireTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireTransfer = await response
                    .Deserialize<WireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireTransfer.Validate();
                }
                return wireTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WireTransfer>> Approve(
        string wireTransferID,
        WireTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireTransfer>> Cancel(
        WireTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WireTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.WireTransferID' cannot be null");
        }

        HttpRequest<WireTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var wireTransfer = await response
                    .Deserialize<WireTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    wireTransfer.Validate();
                }
                return wireTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WireTransfer>> Cancel(
        string wireTransferID,
        WireTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { WireTransferID = wireTransferID }, cancellationToken);
    }
}
