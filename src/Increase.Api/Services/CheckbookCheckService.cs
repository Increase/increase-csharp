using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckbookChecks;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class CheckbookCheckService : ICheckbookCheckService
{
    readonly Lazy<ICheckbookCheckServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckbookCheckServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICheckbookCheckService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckbookCheckService(this._client.WithOptions(modifier));
    }

    public CheckbookCheckService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CheckbookCheckServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CheckbookCheck> Retrieve(
        CheckbookCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckbookCheck> Retrieve(
        string checkbookCheckID,
        CheckbookCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CheckbookCheckID = checkbookCheckID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckbookCheckListPage> List(
        CheckbookCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CheckbookCheck> Stop(
        CheckbookCheckStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stop(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckbookCheck> Stop(
        string checkbookCheckID,
        CheckbookCheckStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stop(
            parameters with
            {
                CheckbookCheckID = checkbookCheckID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class CheckbookCheckServiceWithRawResponse : ICheckbookCheckServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckbookCheckServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CheckbookCheckServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckbookCheckServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckbookCheck>> Retrieve(
        CheckbookCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckbookCheckID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckbookCheckID' cannot be null");
        }

        HttpRequest<CheckbookCheckRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkbookCheck = await response
                    .Deserialize<CheckbookCheck>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkbookCheck.Validate();
                }
                return checkbookCheck;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckbookCheck>> Retrieve(
        string checkbookCheckID,
        CheckbookCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                CheckbookCheckID = checkbookCheckID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckbookCheckListPage>> List(
        CheckbookCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CheckbookCheckListParams> request = new()
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
                    .Deserialize<CheckbookCheckListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CheckbookCheckListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckbookCheck>> Stop(
        CheckbookCheckStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckbookCheckID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckbookCheckID' cannot be null");
        }

        HttpRequest<CheckbookCheckStopParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkbookCheck = await response
                    .Deserialize<CheckbookCheck>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkbookCheck.Validate();
                }
                return checkbookCheck;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckbookCheck>> Stop(
        string checkbookCheckID,
        CheckbookCheckStopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stop(
            parameters with
            {
                CheckbookCheckID = checkbookCheckID,
            },
            cancellationToken
        );
    }
}
