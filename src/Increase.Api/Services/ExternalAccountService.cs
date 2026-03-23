using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class ExternalAccountService : IExternalAccountService
{
    readonly Lazy<IExternalAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public IExternalAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalAccountService(this._client.WithOptions(modifier));
    }

    public ExternalAccountService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExternalAccountServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ExternalAccount> Create(
        ExternalAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExternalAccount> Retrieve(
        ExternalAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExternalAccount> Retrieve(
        string externalAccountID,
        ExternalAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalAccountID = externalAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ExternalAccount> Update(
        ExternalAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExternalAccount> Update(
        string externalAccountID,
        ExternalAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExternalAccountID = externalAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ExternalAccountListPage> List(
        ExternalAccountListParams? parameters = null,
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
public sealed class ExternalAccountServiceWithRawResponse : IExternalAccountServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalAccountServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalAccount>> Create(
        ExternalAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalAccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var externalAccount = await response
                    .Deserialize<ExternalAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    externalAccount.Validate();
                }
                return externalAccount;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalAccount>> Retrieve(
        ExternalAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalAccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.ExternalAccountID' cannot be null");
        }

        HttpRequest<ExternalAccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var externalAccount = await response
                    .Deserialize<ExternalAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    externalAccount.Validate();
                }
                return externalAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExternalAccount>> Retrieve(
        string externalAccountID,
        ExternalAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalAccountID = externalAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalAccount>> Update(
        ExternalAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalAccountID == null)
        {
            throw new IncreaseInvalidDataException("'parameters.ExternalAccountID' cannot be null");
        }

        HttpRequest<ExternalAccountUpdateParams> request = new()
        {
            Method = IncreaseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var externalAccount = await response
                    .Deserialize<ExternalAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    externalAccount.Validate();
                }
                return externalAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExternalAccount>> Update(
        string externalAccountID,
        ExternalAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExternalAccountID = externalAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalAccountListPage>> List(
        ExternalAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExternalAccountListParams> request = new()
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
                    .Deserialize<ExternalAccountListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExternalAccountListPage(this, parameters, page);
            }
        );
    }
}
