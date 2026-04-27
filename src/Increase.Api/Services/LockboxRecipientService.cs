using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.LockboxRecipients;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class LockboxRecipientService : ILockboxRecipientService
{
    readonly Lazy<ILockboxRecipientServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILockboxRecipientServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ILockboxRecipientService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LockboxRecipientService(this._client.WithOptions(modifier));
    }

    public LockboxRecipientService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new LockboxRecipientServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<LockboxRecipient> Create(
        LockboxRecipientCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LockboxRecipient> Retrieve(
        LockboxRecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LockboxRecipient> Retrieve(
        string lockboxRecipientID,
        LockboxRecipientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                LockboxRecipientID = lockboxRecipientID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LockboxRecipient> Update(
        LockboxRecipientUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LockboxRecipient> Update(
        string lockboxRecipientID,
        LockboxRecipientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                LockboxRecipientID = lockboxRecipientID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LockboxRecipientListPage> List(
        LockboxRecipientListParams? parameters = null,
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
public sealed class LockboxRecipientServiceWithRawResponse : ILockboxRecipientServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILockboxRecipientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LockboxRecipientServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LockboxRecipientServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxRecipient>> Create(
        LockboxRecipientCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LockboxRecipientCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockboxRecipient = await response
                    .Deserialize<LockboxRecipient>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockboxRecipient.Validate();
                }
                return lockboxRecipient;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxRecipient>> Retrieve(
        LockboxRecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LockboxRecipientID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.LockboxRecipientID' cannot be null"
            );
        }

        HttpRequest<LockboxRecipientRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockboxRecipient = await response
                    .Deserialize<LockboxRecipient>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockboxRecipient.Validate();
                }
                return lockboxRecipient;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LockboxRecipient>> Retrieve(
        string lockboxRecipientID,
        LockboxRecipientRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                LockboxRecipientID = lockboxRecipientID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxRecipient>> Update(
        LockboxRecipientUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LockboxRecipientID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.LockboxRecipientID' cannot be null"
            );
        }

        HttpRequest<LockboxRecipientUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var lockboxRecipient = await response
                    .Deserialize<LockboxRecipient>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    lockboxRecipient.Validate();
                }
                return lockboxRecipient;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LockboxRecipient>> Update(
        string lockboxRecipientID,
        LockboxRecipientUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                LockboxRecipientID = lockboxRecipientID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LockboxRecipientListPage>> List(
        LockboxRecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LockboxRecipientListParams> request = new()
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
                    .Deserialize<LockboxRecipientListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LockboxRecipientListPage(this, parameters, page);
            }
        );
    }
}
