using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class IntrafiAccountEnrollmentService : IIntrafiAccountEnrollmentService
{
    readonly Lazy<IIntrafiAccountEnrollmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntrafiAccountEnrollmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IIntrafiAccountEnrollmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntrafiAccountEnrollmentService(this._client.WithOptions(modifier));
    }

    public IntrafiAccountEnrollmentService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new IntrafiAccountEnrollmentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<IntrafiAccountEnrollment> Create(
        IntrafiAccountEnrollmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IntrafiAccountEnrollment> Retrieve(
        IntrafiAccountEnrollmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntrafiAccountEnrollment> Retrieve(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                IntrafiAccountEnrollmentID = intrafiAccountEnrollmentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<IntrafiAccountEnrollmentListPage> List(
        IntrafiAccountEnrollmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IntrafiAccountEnrollment> Unenroll(
        IntrafiAccountEnrollmentUnenrollParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unenroll(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntrafiAccountEnrollment> Unenroll(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentUnenrollParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unenroll(
            parameters with
            {
                IntrafiAccountEnrollmentID = intrafiAccountEnrollmentID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class IntrafiAccountEnrollmentServiceWithRawResponse
    : IIntrafiAccountEnrollmentServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntrafiAccountEnrollmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntrafiAccountEnrollmentServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public IntrafiAccountEnrollmentServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiAccountEnrollment>> Create(
        IntrafiAccountEnrollmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IntrafiAccountEnrollmentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiAccountEnrollment = await response
                    .Deserialize<IntrafiAccountEnrollment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiAccountEnrollment.Validate();
                }
                return intrafiAccountEnrollment;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiAccountEnrollment>> Retrieve(
        IntrafiAccountEnrollmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntrafiAccountEnrollmentID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.IntrafiAccountEnrollmentID' cannot be null"
            );
        }

        HttpRequest<IntrafiAccountEnrollmentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiAccountEnrollment = await response
                    .Deserialize<IntrafiAccountEnrollment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiAccountEnrollment.Validate();
                }
                return intrafiAccountEnrollment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntrafiAccountEnrollment>> Retrieve(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                IntrafiAccountEnrollmentID = intrafiAccountEnrollmentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiAccountEnrollmentListPage>> List(
        IntrafiAccountEnrollmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IntrafiAccountEnrollmentListParams> request = new()
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
                    .Deserialize<IntrafiAccountEnrollmentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new IntrafiAccountEnrollmentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrafiAccountEnrollment>> Unenroll(
        IntrafiAccountEnrollmentUnenrollParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntrafiAccountEnrollmentID == null)
        {
            throw new IncreaseInvalidDataException(
                "'parameters.IntrafiAccountEnrollmentID' cannot be null"
            );
        }

        HttpRequest<IntrafiAccountEnrollmentUnenrollParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var intrafiAccountEnrollment = await response
                    .Deserialize<IntrafiAccountEnrollment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    intrafiAccountEnrollment.Validate();
                }
                return intrafiAccountEnrollment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntrafiAccountEnrollment>> Unenroll(
        string intrafiAccountEnrollmentID,
        IntrafiAccountEnrollmentUnenrollParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unenroll(
            parameters with
            {
                IntrafiAccountEnrollmentID = intrafiAccountEnrollmentID,
            },
            cancellationToken
        );
    }
}
