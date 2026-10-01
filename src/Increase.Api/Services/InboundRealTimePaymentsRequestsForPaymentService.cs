using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class InboundRealTimePaymentsRequestsForPaymentService
    : IInboundRealTimePaymentsRequestsForPaymentService
{
    readonly Lazy<IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundRealTimePaymentsRequestsForPaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundRealTimePaymentsRequestsForPaymentService(
            this._client.WithOptions(modifier)
        );
    }

    public InboundRealTimePaymentsRequestsForPaymentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse(
                client.WithRawResponse
            )
        );
    }

    /// <inheritdoc/>
    public async Task<InboundRealTimePaymentsRequestForPayment> Retrieve(
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundRealTimePaymentsRequestForPayment> Retrieve(
        string inboundRealTimePaymentsRequestForPaymentID,
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundRealTimePaymentsRequestForPaymentID =
                    inboundRealTimePaymentsRequestForPaymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundRealTimePaymentsRequestsForPaymentListPage> List(
        InboundRealTimePaymentsRequestsForPaymentListParams? parameters = null,
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
public sealed class InboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse
    : IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public InboundRealTimePaymentsRequestsForPaymentServiceWithRawResponse(
        IIncreaseClientWithRawResponse client
    )
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundRealTimePaymentsRequestForPayment>> Retrieve(
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundRealTimePaymentsRequestForPaymentID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundRealTimePaymentsRequestForPaymentID' cannot be null"
            );
        }

        HttpRequest<InboundRealTimePaymentsRequestsForPaymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundRealTimePaymentsRequestForPayment = await response
                    .Deserialize<InboundRealTimePaymentsRequestForPayment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundRealTimePaymentsRequestForPayment.Validate();
                }
                return inboundRealTimePaymentsRequestForPayment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundRealTimePaymentsRequestForPayment>> Retrieve(
        string inboundRealTimePaymentsRequestForPaymentID,
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundRealTimePaymentsRequestForPaymentID =
                    inboundRealTimePaymentsRequestForPaymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundRealTimePaymentsRequestsForPaymentListPage>> List(
        InboundRealTimePaymentsRequestsForPaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundRealTimePaymentsRequestsForPaymentListParams> request = new()
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
                    .Deserialize<InboundRealTimePaymentsRequestsForPaymentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundRealTimePaymentsRequestsForPaymentListPage(
                    this,
                    parameters,
                    page
                );
            }
        );
    }
}
