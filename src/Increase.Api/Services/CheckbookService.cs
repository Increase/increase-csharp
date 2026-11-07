using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Checkbooks;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CheckbookService : ICheckbookService
{
    readonly Lazy<ICheckbookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckbookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICheckbookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckbookService(this._client.WithOptions(modifier));
    }

    public CheckbookService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CheckbookServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Checkbook> Create(
        CheckbookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Checkbook> Retrieve(
        CheckbookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Checkbook> Retrieve(
        string checkbookID,
        CheckbookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CheckbookID = checkbookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CheckbookListPage> List(
        CheckbookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Checkbook> Stop(
        CheckbookStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stop(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Checkbook> Stop(
        string checkbookID,
        CheckbookStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stop(parameters with { CheckbookID = checkbookID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CheckbookServiceWithRawResponse : ICheckbookServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckbookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckbookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckbookServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Checkbook>> Create(
        CheckbookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CheckbookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkbook = await response.Deserialize<Checkbook>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkbook.Validate();
                }
                return checkbook;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Checkbook>> Retrieve(
        CheckbookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckbookID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckbookID' cannot be null");
        }

        HttpRequest<CheckbookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkbook = await response.Deserialize<Checkbook>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkbook.Validate();
                }
                return checkbook;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Checkbook>> Retrieve(
        string checkbookID,
        CheckbookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CheckbookID = checkbookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckbookListPage>> List(
        CheckbookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CheckbookListParams> request = new()
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
                    .Deserialize<CheckbookListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CheckbookListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Checkbook>> Stop(
        CheckbookStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckbookID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckbookID' cannot be null");
        }

        HttpRequest<CheckbookStopParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkbook = await response.Deserialize<Checkbook>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkbook.Validate();
                }
                return checkbook;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Checkbook>> Stop(
        string checkbookID,
        CheckbookStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stop(parameters with { CheckbookID = checkbookID }, cancellationToken);
    }
}
