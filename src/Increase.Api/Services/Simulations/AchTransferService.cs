using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AchTransfers;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class AchTransferService : IAchTransferService
{
    readonly Lazy<IAchTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAchTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IAchTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AchTransferService(this._client.WithOptions(modifier));
    }

    public AchTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AchTransferServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Acknowledge(
        AchTransferAcknowledgeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Acknowledge(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Acknowledge(
        string achTransferID,
        AchTransferAcknowledgeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Acknowledge(
            parameters with
            {
                AchTransferID = achTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> CreateNotificationOfChange(
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateNotificationOfChange(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> CreateNotificationOfChange(
        string achTransferID,
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateNotificationOfChange(
            parameters with
            {
                AchTransferID = achTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Return(
        AchTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Return(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Return(
        string achTransferID,
        AchTransferReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Return(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Settle(
        AchTransferSettleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Settle(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Settle(
        string achTransferID,
        AchTransferSettleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Settle(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AchTransfer> Submit(
        AchTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AchTransfer> Submit(
        string achTransferID,
        AchTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AchTransferServiceWithRawResponse : IAchTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAchTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AchTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AchTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Acknowledge(
        AchTransferAcknowledgeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferAcknowledgeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Acknowledge(
        string achTransferID,
        AchTransferAcknowledgeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Acknowledge(
            parameters with
            {
                AchTransferID = achTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> CreateNotificationOfChange(
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferCreateNotificationOfChangeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> CreateNotificationOfChange(
        string achTransferID,
        AchTransferCreateNotificationOfChangeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateNotificationOfChange(
            parameters with
            {
                AchTransferID = achTransferID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Return(
        AchTransferReturnParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferReturnParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Return(
        string achTransferID,
        AchTransferReturnParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Return(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Settle(
        AchTransferSettleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferSettleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Settle(
        string achTransferID,
        AchTransferSettleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Settle(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AchTransfer>> Submit(
        AchTransferSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AchTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.AchTransferID' cannot be null");
        }

        HttpRequest<AchTransferSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var achTransfer = await response
                    .Deserialize<AchTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    achTransfer.Validate();
                }
                return achTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AchTransfer>> Submit(
        string achTransferID,
        AchTransferSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { AchTransferID = achTransferID }, cancellationToken);
    }
}
