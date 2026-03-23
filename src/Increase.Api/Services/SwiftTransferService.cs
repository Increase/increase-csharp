using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class SwiftTransferService : ISwiftTransferService
{
    readonly Lazy<ISwiftTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISwiftTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ISwiftTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SwiftTransferService(this._client.WithOptions(modifier));
    }

    public SwiftTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SwiftTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<SwiftTransfer> Create(
        SwiftTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SwiftTransfer> Retrieve(
        SwiftTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SwiftTransfer> Retrieve(
        string swiftTransferID,
        SwiftTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SwiftTransferID = swiftTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SwiftTransferListPage> List(
        SwiftTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SwiftTransfer> Approve(
        SwiftTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SwiftTransfer> Approve(
        string swiftTransferID,
        SwiftTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                SwiftTransferID = swiftTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SwiftTransfer> Cancel(
        SwiftTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SwiftTransfer> Cancel(
        string swiftTransferID,
        SwiftTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                SwiftTransferID = swiftTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class SwiftTransferServiceWithRawResponse : ISwiftTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISwiftTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SwiftTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SwiftTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwiftTransfer>> Create(
        SwiftTransferCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SwiftTransferCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var swiftTransfer = await response
                    .Deserialize<SwiftTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    swiftTransfer.Validate();
                }
                return swiftTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwiftTransfer>> Retrieve(
        SwiftTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SwiftTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.SwiftTransferID' cannot be null");
        }

        HttpRequest<SwiftTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var swiftTransfer = await response
                    .Deserialize<SwiftTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    swiftTransfer.Validate();
                }
                return swiftTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SwiftTransfer>> Retrieve(
        string swiftTransferID,
        SwiftTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SwiftTransferID = swiftTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwiftTransferListPage>> List(
        SwiftTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SwiftTransferListParams> request = new()
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
                    .Deserialize<SwiftTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SwiftTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwiftTransfer>> Approve(
        SwiftTransferApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SwiftTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.SwiftTransferID' cannot be null");
        }

        HttpRequest<SwiftTransferApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var swiftTransfer = await response
                    .Deserialize<SwiftTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    swiftTransfer.Validate();
                }
                return swiftTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SwiftTransfer>> Approve(
        string swiftTransferID,
        SwiftTransferApproveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Approve(
            parameters with
            {
                SwiftTransferID = swiftTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwiftTransfer>> Cancel(
        SwiftTransferCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SwiftTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.SwiftTransferID' cannot be null");
        }

        HttpRequest<SwiftTransferCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var swiftTransfer = await response
                    .Deserialize<SwiftTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    swiftTransfer.Validate();
                }
                return swiftTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SwiftTransfer>> Cancel(
        string swiftTransferID,
        SwiftTransferCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                SwiftTransferID = swiftTransferID,
            },
            cancellationToken
        );
    }
}
