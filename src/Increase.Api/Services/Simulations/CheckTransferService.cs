using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckTransfers;
using Increase.Api.Models.Simulations.CheckTransfers;

namespace Increase.Api.Services.Simulations;

/// <inheritdoc/>
public sealed class CheckTransferService : ICheckTransferService
{
    readonly Lazy<ICheckTransferServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckTransferServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ICheckTransferService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckTransferService(this._client.WithOptions(modifier));
    }

    public CheckTransferService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CheckTransferServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CheckTransfer> Mail(
        CheckTransferMailParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Mail(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckTransfer> Mail(
        string checkTransferID,
        CheckTransferMailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Mail(parameters with { CheckTransferID = checkTransferID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CheckTransferServiceWithRawResponse : ICheckTransferServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckTransferServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CheckTransferServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckTransferServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckTransfer>> Mail(
        CheckTransferMailParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckTransferID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckTransferID' cannot be null");
        }

        HttpRequest<CheckTransferMailParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checkTransfer = await response
                    .Deserialize<CheckTransfer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checkTransfer.Validate();
                }
                return checkTransfer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckTransfer>> Mail(
        string checkTransferID,
        CheckTransferMailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Mail(parameters with { CheckTransferID = checkTransferID }, cancellationToken);
    }
}
