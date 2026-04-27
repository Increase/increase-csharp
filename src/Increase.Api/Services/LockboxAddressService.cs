using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.LockboxAddresses;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class LockboxAddressService : ILockboxAddressService
{
    readonly Lazy<ILockboxAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILockboxAddressServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ILockboxAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LockboxAddressService(this._client.WithOptions(modifier));
    }

    public LockboxAddressService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new LockboxAddressServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<LockboxAddress> Create(
        LockboxAddressCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LockboxAddress> Retrieve(
        LockboxAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LockboxAddress> Retrieve(
        string lockboxAddressID,
        LockboxAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                LockboxAddressID = lockboxAddressID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LockboxAddress> Update(
        LockboxAddressUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LockboxAddress> Update(
        string lockboxAddressID,
        LockboxAddressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                LockboxAddressID = lockboxAddressID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LockboxAddressListPage> List(
        LockboxAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class LockboxAddressServiceWithRawResponse : ILockboxAddressServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILockboxAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LockboxAddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LockboxAddressServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxAddress>> Create(
        LockboxAddressCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LockboxAddressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockboxAddress = await response
                    .Deserialize<LockboxAddress>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockboxAddress.Validate();
                }
                return lockboxAddress;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxAddress>> Retrieve(
        LockboxAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LockboxAddressID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.LockboxAddressID' cannot be null");
        }

        HttpRequest<LockboxAddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockboxAddress = await response
                    .Deserialize<LockboxAddress>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockboxAddress.Validate();
                }
                return lockboxAddress;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LockboxAddress>> Retrieve(
        string lockboxAddressID,
        LockboxAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                LockboxAddressID = lockboxAddressID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxAddress>> Update(
        LockboxAddressUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LockboxAddressID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.LockboxAddressID' cannot be null");
        }

        HttpRequest<LockboxAddressUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockboxAddress = await response
                    .Deserialize<LockboxAddress>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockboxAddress.Validate();
                }
                return lockboxAddress;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LockboxAddress>> Update(
        string lockboxAddressID,
        LockboxAddressUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                LockboxAddressID = lockboxAddressID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxAddressListPage>> List(
        LockboxAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LockboxAddressListParams> request = new()
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
                    .Deserialize<LockboxAddressListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LockboxAddressListPage(this, parameters, page);
            }
        );
    }
}
