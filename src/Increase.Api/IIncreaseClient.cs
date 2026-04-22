using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Services;

namespace Increase.Api;

/// <summary>
/// A client for interacting with the Increase REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IIncreaseClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    string? WebhookSecret { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIncreaseClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIncreaseClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAccountService Accounts { get; }

    IAccountNumberService AccountNumbers { get; }

    IAccountTransferService AccountTransfers { get; }

    ICardService Cards { get; }

    ICardPaymentService CardPayments { get; }

    ICardPurchaseSupplementService CardPurchaseSupplements { get; }

    ICardDisputeService CardDisputes { get; }

    IPhysicalCardService PhysicalCards { get; }

    IDigitalCardProfileService DigitalCardProfiles { get; }

    IPhysicalCardProfileService PhysicalCardProfiles { get; }

    IDigitalWalletTokenService DigitalWalletTokens { get; }

    ITransactionService Transactions { get; }

    IPendingTransactionService PendingTransactions { get; }

    IDeclinedTransactionService DeclinedTransactions { get; }

    IAchTransferService AchTransfers { get; }

    IAchPrenotificationService AchPrenotifications { get; }

    IInboundAchTransferService InboundAchTransfers { get; }

    IWireTransferService WireTransfers { get; }

    IInboundWireTransferService InboundWireTransfers { get; }

    IWireDrawdownRequestService WireDrawdownRequests { get; }

    IInboundWireDrawdownRequestService InboundWireDrawdownRequests { get; }

    ICheckTransferService CheckTransfers { get; }

    IInboundCheckDepositService InboundCheckDeposits { get; }

    IRealTimePaymentsTransferService RealTimePaymentsTransfers { get; }

    IInboundRealTimePaymentsTransferService InboundRealTimePaymentsTransfers { get; }

    IFednowTransferService FednowTransfers { get; }

    IInboundFednowTransferService InboundFednowTransfers { get; }

    ISwiftTransferService SwiftTransfers { get; }

    ICheckDepositService CheckDeposits { get; }

    ILockboxService Lockboxes { get; }

    IInboundMailItemService InboundMailItems { get; }

    IRoutingNumberService RoutingNumbers { get; }

    IExternalAccountService ExternalAccounts { get; }

    IEntityService Entities { get; }

    IBeneficialOwnerService BeneficialOwners { get; }

    ISupplementalDocumentService SupplementalDocuments { get; }

    IEntityOnboardingSessionService EntityOnboardingSessions { get; }

    IProgramService Programs { get; }

    IAccountStatementService AccountStatements { get; }

    IFileService Files { get; }

    IFileLinkService FileLinks { get; }

    IExportService Exports { get; }

    IEventService Events { get; }

    IEventSubscriptionService EventSubscriptions { get; }

    IRealTimeDecisionService RealTimeDecisions { get; }

    IGroupService Groups { get; }

    IOAuthApplicationService OAuthApplications { get; }

    IOAuthConnectionService OAuthConnections { get; }

    IOAuthTokenService OAuthTokens { get; }

    IIntrafiAccountEnrollmentService IntrafiAccountEnrollments { get; }

    IIntrafiBalanceService IntrafiBalances { get; }

    IIntrafiExclusionService IntrafiExclusions { get; }

    ICardTokenService CardTokens { get; }

    ICardPushTransferService CardPushTransfers { get; }

    ICardValidationService CardValidations { get; }

    ISimulationService Simulations { get; }
}

/// <summary>
/// A view of <see cref="IIncreaseClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IIncreaseClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    string? WebhookSecret { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIncreaseClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAccountServiceWithRawResponse Accounts { get; }

    IAccountNumberServiceWithRawResponse AccountNumbers { get; }

    IAccountTransferServiceWithRawResponse AccountTransfers { get; }

    ICardServiceWithRawResponse Cards { get; }

    ICardPaymentServiceWithRawResponse CardPayments { get; }

    ICardPurchaseSupplementServiceWithRawResponse CardPurchaseSupplements { get; }

    ICardDisputeServiceWithRawResponse CardDisputes { get; }

    IPhysicalCardServiceWithRawResponse PhysicalCards { get; }

    IDigitalCardProfileServiceWithRawResponse DigitalCardProfiles { get; }

    IPhysicalCardProfileServiceWithRawResponse PhysicalCardProfiles { get; }

    IDigitalWalletTokenServiceWithRawResponse DigitalWalletTokens { get; }

    ITransactionServiceWithRawResponse Transactions { get; }

    IPendingTransactionServiceWithRawResponse PendingTransactions { get; }

    IDeclinedTransactionServiceWithRawResponse DeclinedTransactions { get; }

    IAchTransferServiceWithRawResponse AchTransfers { get; }

    IAchPrenotificationServiceWithRawResponse AchPrenotifications { get; }

    IInboundAchTransferServiceWithRawResponse InboundAchTransfers { get; }

    IWireTransferServiceWithRawResponse WireTransfers { get; }

    IInboundWireTransferServiceWithRawResponse InboundWireTransfers { get; }

    IWireDrawdownRequestServiceWithRawResponse WireDrawdownRequests { get; }

    IInboundWireDrawdownRequestServiceWithRawResponse InboundWireDrawdownRequests { get; }

    ICheckTransferServiceWithRawResponse CheckTransfers { get; }

    IInboundCheckDepositServiceWithRawResponse InboundCheckDeposits { get; }

    IRealTimePaymentsTransferServiceWithRawResponse RealTimePaymentsTransfers { get; }

    IInboundRealTimePaymentsTransferServiceWithRawResponse InboundRealTimePaymentsTransfers { get; }

    IFednowTransferServiceWithRawResponse FednowTransfers { get; }

    IInboundFednowTransferServiceWithRawResponse InboundFednowTransfers { get; }

    ISwiftTransferServiceWithRawResponse SwiftTransfers { get; }

    ICheckDepositServiceWithRawResponse CheckDeposits { get; }

    ILockboxServiceWithRawResponse Lockboxes { get; }

    IInboundMailItemServiceWithRawResponse InboundMailItems { get; }

    IRoutingNumberServiceWithRawResponse RoutingNumbers { get; }

    IExternalAccountServiceWithRawResponse ExternalAccounts { get; }

    IEntityServiceWithRawResponse Entities { get; }

    IBeneficialOwnerServiceWithRawResponse BeneficialOwners { get; }

    ISupplementalDocumentServiceWithRawResponse SupplementalDocuments { get; }

    IEntityOnboardingSessionServiceWithRawResponse EntityOnboardingSessions { get; }

    IProgramServiceWithRawResponse Programs { get; }

    IAccountStatementServiceWithRawResponse AccountStatements { get; }

    IFileServiceWithRawResponse Files { get; }

    IFileLinkServiceWithRawResponse FileLinks { get; }

    IExportServiceWithRawResponse Exports { get; }

    IEventServiceWithRawResponse Events { get; }

    IEventSubscriptionServiceWithRawResponse EventSubscriptions { get; }

    IRealTimeDecisionServiceWithRawResponse RealTimeDecisions { get; }

    IGroupServiceWithRawResponse Groups { get; }

    IOAuthApplicationServiceWithRawResponse OAuthApplications { get; }

    IOAuthConnectionServiceWithRawResponse OAuthConnections { get; }

    IOAuthTokenServiceWithRawResponse OAuthTokens { get; }

    IIntrafiAccountEnrollmentServiceWithRawResponse IntrafiAccountEnrollments { get; }

    IIntrafiBalanceServiceWithRawResponse IntrafiBalances { get; }

    IIntrafiExclusionServiceWithRawResponse IntrafiExclusions { get; }

    ICardTokenServiceWithRawResponse CardTokens { get; }

    ICardPushTransferServiceWithRawResponse CardPushTransfers { get; }

    ICardValidationServiceWithRawResponse CardValidations { get; }

    ISimulationServiceWithRawResponse Simulations { get; }

    /// <summary>
    /// Sends a request to the Increase REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
