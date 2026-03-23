using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AchPrenotifications;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class AchPrenotificationService : IAchPrenotificationService
{
    readonly Lazy<IAchPrenotificationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAchPrenotificationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAchPrenotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AchPrenotificationService(this._client.WithOptions(modifier));
    }

    public AchPrenotificationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AchPrenotificationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AchPrenotification> Create(
        AchPrenotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AchPrenotification> Retrieve(
        AchPrenotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchPrenotification> Retrieve(
        string achPrenotificationID,
        AchPrenotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AchPrenotificationID = achPrenotificationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AchPrenotificationListPage> List(
        AchPrenotificationListParams? parameters = null,
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
public sealed class AchPrenotificationServiceWithRawResponse
    : IAchPrenotificationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAchPrenotificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AchPrenotificationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AchPrenotificationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchPrenotification>> Create(
        AchPrenotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AchPrenotificationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achPrenotification = await response
                    .Deserialize<AchPrenotification>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achPrenotification.Validate();
                }
                return achPrenotification;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchPrenotification>> Retrieve(
        AchPrenotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchPrenotificationID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.AchPrenotificationID' cannot be null"
            );
        }

        HttpRequest<AchPrenotificationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achPrenotification = await response
                    .Deserialize<AchPrenotification>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achPrenotification.Validate();
                }
                return achPrenotification;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchPrenotification>> Retrieve(
        string achPrenotificationID,
        AchPrenotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                AchPrenotificationID = achPrenotificationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchPrenotificationListPage>> List(
        AchPrenotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AchPrenotificationListParams> request = new()
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
                    .Deserialize<AchPrenotificationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AchPrenotificationListPage(this, parameters, page);
            }
        );
    }
}
