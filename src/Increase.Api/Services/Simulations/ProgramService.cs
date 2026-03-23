using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Models.Programs;
using Increase.Api.Models.Simulations.Programs;

namespace Increase.Api.Services.Simulations;

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
    public async Task<Program> Create(
        ProgramCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
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
    public async Task<HttpResponse<Program>> Create(
        ProgramCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProgramCreateParams> request = new()
        {
            Method = HttpMethod.Post,
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
}
