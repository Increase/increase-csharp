using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Lockboxes;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class LockboxService : ILockboxService
{
    readonly Lazy<ILockboxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILockboxServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ILockboxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LockboxService(this._client.WithOptions(modifier));
    }

    public LockboxService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LockboxServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Lockbox> Create(
        LockboxCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Lockbox> Retrieve(
        LockboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Lockbox> Retrieve(
        string lockboxID,
        LockboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LockboxID = lockboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Lockbox> Update(
        LockboxUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Lockbox> Update(
        string lockboxID,
        LockboxUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { LockboxID = lockboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LockboxListPage> List(
        LockboxListParams? parameters = null,
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
public sealed class LockboxServiceWithRawResponse : ILockboxServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILockboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LockboxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LockboxServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Lockbox>> Create(
        LockboxCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LockboxCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockbox = await response.Deserialize<Lockbox>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockbox.Validate();
                }
                return lockbox;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Lockbox>> Retrieve(
        LockboxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LockboxID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.LockboxID' cannot be null");
        }

        HttpRequest<LockboxRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockbox = await response.Deserialize<Lockbox>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockbox.Validate();
                }
                return lockbox;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Lockbox>> Retrieve(
        string lockboxID,
        LockboxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LockboxID = lockboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Lockbox>> Update(
        LockboxUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LockboxID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.LockboxID' cannot be null");
        }

        HttpRequest<LockboxUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockbox = await response.Deserialize<Lockbox>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockbox.Validate();
                }
                return lockbox;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Lockbox>> Update(
        string lockboxID,
        LockboxUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { LockboxID = lockboxID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxListPage>> List(
        LockboxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LockboxListParams> request = new()
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
                    .Deserialize<LockboxListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LockboxListPage(this, parameters, page);
            }
        );
    }
}
