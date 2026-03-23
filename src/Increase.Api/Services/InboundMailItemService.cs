using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class InboundMailItemService : IInboundMailItemService
{
    readonly Lazy<IInboundMailItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundMailItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundMailItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundMailItemService(this._client.WithOptions(modifier));
    }

    public InboundMailItemService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundMailItemServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundMailItem> Retrieve(
        InboundMailItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundMailItem> Retrieve(
        string inboundMailItemID,
        InboundMailItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundMailItemID = inboundMailItemID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundMailItemListPage> List(
        InboundMailItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InboundMailItem> Action(
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Action(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundMailItem> Action(
        string inboundMailItemID,
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Action(
            parameters with
            {
                InboundMailItemID = inboundMailItemID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class InboundMailItemServiceWithRawResponse : IInboundMailItemServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundMailItemServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundMailItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundMailItemServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundMailItem>> Retrieve(
        InboundMailItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundMailItemID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.InboundMailItemID' cannot be null");
        }

        HttpRequest<InboundMailItemRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundMailItem = await response
                    .Deserialize<InboundMailItem>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundMailItem.Validate();
                }
                return inboundMailItem;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundMailItem>> Retrieve(
        string inboundMailItemID,
        InboundMailItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundMailItemID = inboundMailItemID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundMailItemListPage>> List(
        InboundMailItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundMailItemListParams> request = new()
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
                    .Deserialize<InboundMailItemListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundMailItemListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundMailItem>> Action(
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundMailItemID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.InboundMailItemID' cannot be null");
        }

        HttpRequest<InboundMailItemActionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundMailItem = await response
                    .Deserialize<InboundMailItem>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundMailItem.Validate();
                }
                return inboundMailItem;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundMailItem>> Action(
        string inboundMailItemID,
        InboundMailItemActionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Action(
            parameters with
            {
                InboundMailItemID = inboundMailItemID,
            },
            cancellationToken
        );
    }
}
