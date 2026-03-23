using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Programs;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class ProgramService : IProgramService
{
    readonly Lazy<IProgramServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProgramServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IProgramService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProgramService(this._client.WithOptions(modifier));
    }

    public ProgramService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProgramServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Program> Retrieve(
        ProgramRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Program> Retrieve(
        string programID,
        ProgramRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ProgramID = programID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProgramListPage> List(
        ProgramListParams? parameters = null,
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
public sealed class ProgramServiceWithRawResponse : IProgramServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProgramServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProgramServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProgramServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Program>> Retrieve(
        ProgramRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProgramID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.ProgramID' cannot be null");
        }

        HttpRequest<ProgramRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var program = await response.Deserialize<Program>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    program.Validate();
                }
                return program;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Program>> Retrieve(
        string programID,
        ProgramRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ProgramID = programID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProgramListPage>> List(
        ProgramListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProgramListParams> request = new()
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
                    .Deserialize<ProgramListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ProgramListPage(this, parameters, page);
            }
        );
    }
}
