using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class InboundAchTransferService : IInboundAchTransferService
{
    readonly Lazy<IInboundAchTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundAchTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundAchTransferService(this._client.WithOptions(modifier));
    }

    public InboundAchTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundAchTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundAchTransfer> Retrieve(
        InboundAchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundAchTransfer> Retrieve(
        string inboundAchTransferID,
        InboundAchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundAchTransferListPage> List(
        InboundAchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InboundAchTransfer> CreateNotificationOfChange(
        InboundAchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateNotificationOfChange(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundAchTransfer> CreateNotificationOfChange(
        string inboundAchTransferID,
        InboundAchTransferCreateNotificationOfChangeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateNotificationOfChange(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundAchTransfer> Decline(
        InboundAchTransferDeclineParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Decline(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundAchTransfer> Decline(
        string inboundAchTransferID,
        InboundAchTransferDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Decline(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundAchTransfer> TransferReturn(
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TransferReturn(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundAchTransfer> TransferReturn(
        string inboundAchTransferID,
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TransferReturn(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class InboundAchTransferServiceWithRawResponse
    : IInboundAchTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundAchTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundAchTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundAchTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundAchTransfer>> Retrieve(
        InboundAchTransferRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundAchTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundAchTransferID' cannot be null"
            );
        }

        HttpRequest<InboundAchTransferRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundAchTransfer = await response
                    .Deserialize<InboundAchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundAchTransfer.Validate();
                }
                return inboundAchTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundAchTransfer>> Retrieve(
        string inboundAchTransferID,
        InboundAchTransferRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundAchTransferListPage>> List(
        InboundAchTransferListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundAchTransferListParams> request = new()
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
                    .Deserialize<InboundAchTransferListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundAchTransferListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundAchTransfer>> CreateNotificationOfChange(
        InboundAchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundAchTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundAchTransferID' cannot be null"
            );
        }

        HttpRequest<InboundAchTransferCreateNotificationOfChangeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundAchTransfer = await response
                    .Deserialize<InboundAchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundAchTransfer.Validate();
                }
                return inboundAchTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundAchTransfer>> CreateNotificationOfChange(
        string inboundAchTransferID,
        InboundAchTransferCreateNotificationOfChangeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateNotificationOfChange(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundAchTransfer>> Decline(
        InboundAchTransferDeclineParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundAchTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundAchTransferID' cannot be null"
            );
        }

        HttpRequest<InboundAchTransferDeclineParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundAchTransfer = await response
                    .Deserialize<InboundAchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundAchTransfer.Validate();
                }
                return inboundAchTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundAchTransfer>> Decline(
        string inboundAchTransferID,
        InboundAchTransferDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Decline(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundAchTransfer>> TransferReturn(
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundAchTransferID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundAchTransferID' cannot be null"
            );
        }

        HttpRequest<InboundAchTransferTransferReturnParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundAchTransfer = await response
                    .Deserialize<InboundAchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundAchTransfer.Validate();
                }
                return inboundAchTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundAchTransfer>> TransferReturn(
        string inboundAchTransferID,
        InboundAchTransferTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TransferReturn(
            parameters with
            {
                InboundAchTransferID = inboundAchTransferID,
            },
            cancellationToken
        );
    }
}
