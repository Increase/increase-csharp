using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class RealTimePaymentsRequestsForPaymentService
    : IRealTimePaymentsRequestsForPaymentService
{
    readonly Lazy<IRealTimePaymentsRequestsForPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IRealTimePaymentsRequestsForPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RealTimePaymentsRequestsForPaymentService(this._client.WithOptions(modifier));
    }

    public RealTimePaymentsRequestsForPaymentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RealTimePaymentsRequestsForPaymentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsRequestForPayment> Create(
        RealTimePaymentsRequestsForPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsRequestForPayment> Retrieve(
        RealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimePaymentsRequestForPayment> Retrieve(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RealTimePaymentsRequestForPaymentID = realTimePaymentsRequestForPaymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsRequestsForPaymentListPage> List(
        RealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RealTimePaymentsRequestForPayment> Cancel(
        RealTimePaymentsRequestsForPaymentCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RealTimePaymentsRequestForPayment> Cancel(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                RealTimePaymentsRequestForPaymentID = realTimePaymentsRequestForPaymentID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class RealTimePaymentsRequestsForPaymentServiceWithRawResponse
    : IRealTimePaymentsRequestsForPaymentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RealTimePaymentsRequestsForPaymentServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public RealTimePaymentsRequestsForPaymentServiceWithRawResponse(
        IIncreaseClientWithRawResponse client
    )
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsRequestForPayment>> Create(
        RealTimePaymentsRequestsForPaymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RealTimePaymentsRequestsForPaymentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsRequestForPayment = await response
                    .Deserialize<RealTimePaymentsRequestForPayment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsRequestForPayment.Validate();
                }
                return realTimePaymentsRequestForPayment;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsRequestForPayment>> Retrieve(
        RealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimePaymentsRequestForPaymentID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimePaymentsRequestForPaymentID' cannot be null"
            );
        }

        HttpRequest<RealTimePaymentsRequestsForPaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsRequestForPayment = await response
                    .Deserialize<RealTimePaymentsRequestForPayment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsRequestForPayment.Validate();
                }
                return realTimePaymentsRequestForPayment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimePaymentsRequestForPayment>> Retrieve(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                RealTimePaymentsRequestForPaymentID = realTimePaymentsRequestForPaymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsRequestsForPaymentListPage>> List(
        RealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RealTimePaymentsRequestsForPaymentListParams> request = new()
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
                    .Deserialize<RealTimePaymentsRequestsForPaymentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RealTimePaymentsRequestsForPaymentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RealTimePaymentsRequestForPayment>> Cancel(
        RealTimePaymentsRequestsForPaymentCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RealTimePaymentsRequestForPaymentID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.RealTimePaymentsRequestForPaymentID' cannot be null"
            );
        }

        HttpRequest<RealTimePaymentsRequestsForPaymentCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var realTimePaymentsRequestForPayment = await response
                    .Deserialize<RealTimePaymentsRequestForPayment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    realTimePaymentsRequestForPayment.Validate();
                }
                return realTimePaymentsRequestForPayment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RealTimePaymentsRequestForPayment>> Cancel(
        string realTimePaymentsRequestForPaymentID,
        RealTimePaymentsRequestsForPaymentCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                RealTimePaymentsRequestForPaymentID = realTimePaymentsRequestForPaymentID,
            },
            cancellationToken
        );
    }
}
