using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class InboundCheckDepositService : IInboundCheckDepositService
{
    readonly Lazy<IInboundCheckDepositServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundCheckDepositServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IInboundCheckDepositService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundCheckDepositService(this._client.WithOptions(modifier));
    }

    public InboundCheckDepositService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InboundCheckDepositServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InboundCheckDeposit> Retrieve(
        InboundCheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundCheckDeposit> Retrieve(
        string inboundCheckDepositID,
        InboundCheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundCheckDepositListPage> List(
        InboundCheckDepositListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InboundCheckDeposit> Decline(
        InboundCheckDepositDeclineParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Decline(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundCheckDeposit> Decline(
        string inboundCheckDepositID,
        InboundCheckDepositDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Decline(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<InboundCheckDeposit> Return(
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Return(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InboundCheckDeposit> Return(
        string inboundCheckDepositID,
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Return(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class InboundCheckDepositServiceWithRawResponse
    : IInboundCheckDepositServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundCheckDepositServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InboundCheckDepositServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundCheckDepositServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundCheckDeposit>> Retrieve(
        InboundCheckDepositRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundCheckDepositID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundCheckDepositID' cannot be null"
            );
        }

        HttpRequest<InboundCheckDepositRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundCheckDeposit = await response
                    .Deserialize<InboundCheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundCheckDeposit.Validate();
                }
                return inboundCheckDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundCheckDeposit>> Retrieve(
        string inboundCheckDepositID,
        InboundCheckDepositRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundCheckDepositListPage>> List(
        InboundCheckDepositListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InboundCheckDepositListParams> request = new()
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
                    .Deserialize<InboundCheckDepositListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InboundCheckDepositListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundCheckDeposit>> Decline(
        InboundCheckDepositDeclineParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundCheckDepositID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundCheckDepositID' cannot be null"
            );
        }

        HttpRequest<InboundCheckDepositDeclineParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundCheckDeposit = await response
                    .Deserialize<InboundCheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundCheckDeposit.Validate();
                }
                return inboundCheckDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundCheckDeposit>> Decline(
        string inboundCheckDepositID,
        InboundCheckDepositDeclineParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Decline(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundCheckDeposit>> Return(
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboundCheckDepositID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.InboundCheckDepositID' cannot be null"
            );
        }

        HttpRequest<InboundCheckDepositReturnParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var inboundCheckDeposit = await response
                    .Deserialize<InboundCheckDeposit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    inboundCheckDeposit.Validate();
                }
                return inboundCheckDeposit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InboundCheckDeposit>> Return(
        string inboundCheckDepositID,
        InboundCheckDepositReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Return(
            parameters with
            {
                InboundCheckDepositID = inboundCheckDepositID,
            },
            cancellationToken
        );
    }
}
