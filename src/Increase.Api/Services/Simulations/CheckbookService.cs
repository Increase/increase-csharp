using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Checkbooks;
using Increase.Api.Models.Simulations.Checkbooks;

namespace Increase.Api.Services.Simulations;

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
    public async Task<Checkbook> Mail(
        CheckbookMailParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Mail(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Checkbook> Mail(
        string checkbookID,
        CheckbookMailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Mail(parameters with { CheckbookID = checkbookID }, cancellationToken);
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
    public async Task<HttpResponse<Checkbook>> Mail(
        CheckbookMailParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CheckbookID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.CheckbookID' cannot be null");
        }

        HttpRequest<CheckbookMailParams> request = new()
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
    public Task<HttpResponse<Checkbook>> Mail(
        string checkbookID,
        CheckbookMailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Mail(parameters with { CheckbookID = checkbookID }, cancellationToken);
    }
}
