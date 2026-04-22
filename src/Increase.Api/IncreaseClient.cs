using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Services;

namespace Increase.Api;

/// <inheritdoc/>
public sealed class IncreaseClient : IIncreaseClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    readonly Lazy<IIncreaseClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIncreaseClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IIncreaseClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IncreaseClient(modifier(this._options));
    }

    readonly Lazy<IAccountService> _accounts;
    public IAccountService Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IAccountNumberService> _accountNumbers;
    public IAccountNumberService AccountNumbers
    {
        get { return _accountNumbers.Value; }
    }

    readonly Lazy<IAccountTransferService> _accountTransfers;
    public IAccountTransferService AccountTransfers
    {
        get { return _accountTransfers.Value; }
    }

    readonly Lazy<ICardService> _cards;
    public ICardService Cards
    {
        get { return _cards.Value; }
    }

    readonly Lazy<ICardPaymentService> _cardPayments;
    public ICardPaymentService CardPayments
    {
        get { return _cardPayments.Value; }
    }

    readonly Lazy<ICardPurchaseSupplementService> _cardPurchaseSupplements;
    public ICardPurchaseSupplementService CardPurchaseSupplements
    {
        get { return _cardPurchaseSupplements.Value; }
    }

    readonly Lazy<ICardDisputeService> _cardDisputes;
    public ICardDisputeService CardDisputes
    {
        get { return _cardDisputes.Value; }
    }

    readonly Lazy<IPhysicalCardService> _physicalCards;
    public IPhysicalCardService PhysicalCards
    {
        get { return _physicalCards.Value; }
    }

    readonly Lazy<IDigitalCardProfileService> _digitalCardProfiles;
    public IDigitalCardProfileService DigitalCardProfiles
    {
        get { return _digitalCardProfiles.Value; }
    }

    readonly Lazy<IPhysicalCardProfileService> _physicalCardProfiles;
    public IPhysicalCardProfileService PhysicalCardProfiles
    {
        get { return _physicalCardProfiles.Value; }
    }

    readonly Lazy<IDigitalWalletTokenService> _digitalWalletTokens;
    public IDigitalWalletTokenService DigitalWalletTokens
    {
        get { return _digitalWalletTokens.Value; }
    }

    readonly Lazy<ITransactionService> _transactions;
    public ITransactionService Transactions
    {
        get { return _transactions.Value; }
    }

    readonly Lazy<IPendingTransactionService> _pendingTransactions;
    public IPendingTransactionService PendingTransactions
    {
        get { return _pendingTransactions.Value; }
    }

    readonly Lazy<IDeclinedTransactionService> _declinedTransactions;
    public IDeclinedTransactionService DeclinedTransactions
    {
        get { return _declinedTransactions.Value; }
    }

    readonly Lazy<IAchTransferService> _achTransfers;
    public IAchTransferService AchTransfers
    {
        get { return _achTransfers.Value; }
    }

    readonly Lazy<IAchPrenotificationService> _achPrenotifications;
    public IAchPrenotificationService AchPrenotifications
    {
        get { return _achPrenotifications.Value; }
    }

    readonly Lazy<IInboundAchTransferService> _inboundAchTransfers;
    public IInboundAchTransferService InboundAchTransfers
    {
        get { return _inboundAchTransfers.Value; }
    }

    readonly Lazy<IWireTransferService> _wireTransfers;
    public IWireTransferService WireTransfers
    {
        get { return _wireTransfers.Value; }
    }

    readonly Lazy<IInboundWireTransferService> _inboundWireTransfers;
    public IInboundWireTransferService InboundWireTransfers
    {
        get { return _inboundWireTransfers.Value; }
    }

    readonly Lazy<IWireDrawdownRequestService> _wireDrawdownRequests;
    public IWireDrawdownRequestService WireDrawdownRequests
    {
        get { return _wireDrawdownRequests.Value; }
    }

    readonly Lazy<IInboundWireDrawdownRequestService> _inboundWireDrawdownRequests;
    public IInboundWireDrawdownRequestService InboundWireDrawdownRequests
    {
        get { return _inboundWireDrawdownRequests.Value; }
    }

    readonly Lazy<ICheckTransferService> _checkTransfers;
    public ICheckTransferService CheckTransfers
    {
        get { return _checkTransfers.Value; }
    }

    readonly Lazy<IInboundCheckDepositService> _inboundCheckDeposits;
    public IInboundCheckDepositService InboundCheckDeposits
    {
        get { return _inboundCheckDeposits.Value; }
    }

    readonly Lazy<IRealTimePaymentsTransferService> _realTimePaymentsTransfers;
    public IRealTimePaymentsTransferService RealTimePaymentsTransfers
    {
        get { return _realTimePaymentsTransfers.Value; }
    }

    readonly Lazy<IInboundRealTimePaymentsTransferService> _inboundRealTimePaymentsTransfers;
    public IInboundRealTimePaymentsTransferService InboundRealTimePaymentsTransfers
    {
        get { return _inboundRealTimePaymentsTransfers.Value; }
    }

    readonly Lazy<IFednowTransferService> _fednowTransfers;
    public IFednowTransferService FednowTransfers
    {
        get { return _fednowTransfers.Value; }
    }

    readonly Lazy<IInboundFednowTransferService> _inboundFednowTransfers;
    public IInboundFednowTransferService InboundFednowTransfers
    {
        get { return _inboundFednowTransfers.Value; }
    }

    readonly Lazy<ISwiftTransferService> _swiftTransfers;
    public ISwiftTransferService SwiftTransfers
    {
        get { return _swiftTransfers.Value; }
    }

    readonly Lazy<ICheckDepositService> _checkDeposits;
    public ICheckDepositService CheckDeposits
    {
        get { return _checkDeposits.Value; }
    }

    readonly Lazy<ILockboxService> _lockboxes;
    public ILockboxService Lockboxes
    {
        get { return _lockboxes.Value; }
    }

    readonly Lazy<IInboundMailItemService> _inboundMailItems;
    public IInboundMailItemService InboundMailItems
    {
        get { return _inboundMailItems.Value; }
    }

    readonly Lazy<IRoutingNumberService> _routingNumbers;
    public IRoutingNumberService RoutingNumbers
    {
        get { return _routingNumbers.Value; }
    }

    readonly Lazy<IExternalAccountService> _externalAccounts;
    public IExternalAccountService ExternalAccounts
    {
        get { return _externalAccounts.Value; }
    }

    readonly Lazy<IEntityService> _entities;
    public IEntityService Entities
    {
        get { return _entities.Value; }
    }

    readonly Lazy<IBeneficialOwnerService> _beneficialOwners;
    public IBeneficialOwnerService BeneficialOwners
    {
        get { return _beneficialOwners.Value; }
    }

    readonly Lazy<ISupplementalDocumentService> _supplementalDocuments;
    public ISupplementalDocumentService SupplementalDocuments
    {
        get { return _supplementalDocuments.Value; }
    }

    readonly Lazy<IEntityOnboardingSessionService> _entityOnboardingSessions;
    public IEntityOnboardingSessionService EntityOnboardingSessions
    {
        get { return _entityOnboardingSessions.Value; }
    }

    readonly Lazy<IProgramService> _programs;
    public IProgramService Programs
    {
        get { return _programs.Value; }
    }

    readonly Lazy<IAccountStatementService> _accountStatements;
    public IAccountStatementService AccountStatements
    {
        get { return _accountStatements.Value; }
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<IFileLinkService> _fileLinks;
    public IFileLinkService FileLinks
    {
        get { return _fileLinks.Value; }
    }

    readonly Lazy<IExportService> _exports;
    public IExportService Exports
    {
        get { return _exports.Value; }
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IEventSubscriptionService> _eventSubscriptions;
    public IEventSubscriptionService EventSubscriptions
    {
        get { return _eventSubscriptions.Value; }
    }

    readonly Lazy<IRealTimeDecisionService> _realTimeDecisions;
    public IRealTimeDecisionService RealTimeDecisions
    {
        get { return _realTimeDecisions.Value; }
    }

    readonly Lazy<IGroupService> _groups;
    public IGroupService Groups
    {
        get { return _groups.Value; }
    }

    readonly Lazy<IOAuthApplicationService> _oauthApplications;
    public IOAuthApplicationService OAuthApplications
    {
        get { return _oauthApplications.Value; }
    }

    readonly Lazy<IOAuthConnectionService> _oauthConnections;
    public IOAuthConnectionService OAuthConnections
    {
        get { return _oauthConnections.Value; }
    }

    readonly Lazy<IOAuthTokenService> _oauthTokens;
    public IOAuthTokenService OAuthTokens
    {
        get { return _oauthTokens.Value; }
    }

    readonly Lazy<IIntrafiAccountEnrollmentService> _intrafiAccountEnrollments;
    public IIntrafiAccountEnrollmentService IntrafiAccountEnrollments
    {
        get { return _intrafiAccountEnrollments.Value; }
    }

    readonly Lazy<IIntrafiBalanceService> _intrafiBalances;
    public IIntrafiBalanceService IntrafiBalances
    {
        get { return _intrafiBalances.Value; }
    }

    readonly Lazy<IIntrafiExclusionService> _intrafiExclusions;
    public IIntrafiExclusionService IntrafiExclusions
    {
        get { return _intrafiExclusions.Value; }
    }

    readonly Lazy<ICardTokenService> _cardTokens;
    public ICardTokenService CardTokens
    {
        get { return _cardTokens.Value; }
    }

    readonly Lazy<ICardPushTransferService> _cardPushTransfers;
    public ICardPushTransferService CardPushTransfers
    {
        get { return _cardPushTransfers.Value; }
    }

    readonly Lazy<ICardValidationService> _cardValidations;
    public ICardValidationService CardValidations
    {
        get { return _cardValidations.Value; }
    }

    readonly Lazy<ISimulationService> _simulations;
    public ISimulationService Simulations
    {
        get { return _simulations.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public IncreaseClient()
    {
        _options = new();

        _withRawResponse = new(() => new IncreaseClientWithRawResponse(this._options));
        _accounts = new(() => new AccountService(this));
        _accountNumbers = new(() => new AccountNumberService(this));
        _accountTransfers = new(() => new AccountTransferService(this));
        _cards = new(() => new CardService(this));
        _cardPayments = new(() => new CardPaymentService(this));
        _cardPurchaseSupplements = new(() => new CardPurchaseSupplementService(this));
        _cardDisputes = new(() => new CardDisputeService(this));
        _physicalCards = new(() => new PhysicalCardService(this));
        _digitalCardProfiles = new(() => new DigitalCardProfileService(this));
        _physicalCardProfiles = new(() => new PhysicalCardProfileService(this));
        _digitalWalletTokens = new(() => new DigitalWalletTokenService(this));
        _transactions = new(() => new TransactionService(this));
        _pendingTransactions = new(() => new PendingTransactionService(this));
        _declinedTransactions = new(() => new DeclinedTransactionService(this));
        _achTransfers = new(() => new AchTransferService(this));
        _achPrenotifications = new(() => new AchPrenotificationService(this));
        _inboundAchTransfers = new(() => new InboundAchTransferService(this));
        _wireTransfers = new(() => new WireTransferService(this));
        _inboundWireTransfers = new(() => new InboundWireTransferService(this));
        _wireDrawdownRequests = new(() => new WireDrawdownRequestService(this));
        _inboundWireDrawdownRequests = new(() => new InboundWireDrawdownRequestService(this));
        _checkTransfers = new(() => new CheckTransferService(this));
        _inboundCheckDeposits = new(() => new InboundCheckDepositService(this));
        _realTimePaymentsTransfers = new(() => new RealTimePaymentsTransferService(this));
        _inboundRealTimePaymentsTransfers = new(() =>
            new InboundRealTimePaymentsTransferService(this)
        );
        _fednowTransfers = new(() => new FednowTransferService(this));
        _inboundFednowTransfers = new(() => new InboundFednowTransferService(this));
        _swiftTransfers = new(() => new SwiftTransferService(this));
        _checkDeposits = new(() => new CheckDepositService(this));
        _lockboxes = new(() => new LockboxService(this));
        _inboundMailItems = new(() => new InboundMailItemService(this));
        _routingNumbers = new(() => new RoutingNumberService(this));
        _externalAccounts = new(() => new ExternalAccountService(this));
        _entities = new(() => new EntityService(this));
        _beneficialOwners = new(() => new BeneficialOwnerService(this));
        _supplementalDocuments = new(() => new SupplementalDocumentService(this));
        _entityOnboardingSessions = new(() => new EntityOnboardingSessionService(this));
        _programs = new(() => new ProgramService(this));
        _accountStatements = new(() => new AccountStatementService(this));
        _files = new(() => new FileService(this));
        _fileLinks = new(() => new FileLinkService(this));
        _exports = new(() => new ExportService(this));
        _events = new(() => new EventService(this));
        _eventSubscriptions = new(() => new EventSubscriptionService(this));
        _realTimeDecisions = new(() => new RealTimeDecisionService(this));
        _groups = new(() => new GroupService(this));
        _oauthApplications = new(() => new OAuthApplicationService(this));
        _oauthConnections = new(() => new OAuthConnectionService(this));
        _oauthTokens = new(() => new OAuthTokenService(this));
        _intrafiAccountEnrollments = new(() => new IntrafiAccountEnrollmentService(this));
        _intrafiBalances = new(() => new IntrafiBalanceService(this));
        _intrafiExclusions = new(() => new IntrafiExclusionService(this));
        _cardTokens = new(() => new CardTokenService(this));
        _cardPushTransfers = new(() => new CardPushTransferService(this));
        _cardValidations = new(() => new CardValidationService(this));
        _simulations = new(() => new SimulationService(this));
    }

    public IncreaseClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class IncreaseClientWithRawResponse : IIncreaseClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    /// <inheritdoc/>
    public IIncreaseClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IncreaseClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IAccountServiceWithRawResponse> _accounts;
    public IAccountServiceWithRawResponse Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IAccountNumberServiceWithRawResponse> _accountNumbers;
    public IAccountNumberServiceWithRawResponse AccountNumbers
    {
        get { return _accountNumbers.Value; }
    }

    readonly Lazy<IAccountTransferServiceWithRawResponse> _accountTransfers;
    public IAccountTransferServiceWithRawResponse AccountTransfers
    {
        get { return _accountTransfers.Value; }
    }

    readonly Lazy<ICardServiceWithRawResponse> _cards;
    public ICardServiceWithRawResponse Cards
    {
        get { return _cards.Value; }
    }

    readonly Lazy<ICardPaymentServiceWithRawResponse> _cardPayments;
    public ICardPaymentServiceWithRawResponse CardPayments
    {
        get { return _cardPayments.Value; }
    }

    readonly Lazy<ICardPurchaseSupplementServiceWithRawResponse> _cardPurchaseSupplements;
    public ICardPurchaseSupplementServiceWithRawResponse CardPurchaseSupplements
    {
        get { return _cardPurchaseSupplements.Value; }
    }

    readonly Lazy<ICardDisputeServiceWithRawResponse> _cardDisputes;
    public ICardDisputeServiceWithRawResponse CardDisputes
    {
        get { return _cardDisputes.Value; }
    }

    readonly Lazy<IPhysicalCardServiceWithRawResponse> _physicalCards;
    public IPhysicalCardServiceWithRawResponse PhysicalCards
    {
        get { return _physicalCards.Value; }
    }

    readonly Lazy<IDigitalCardProfileServiceWithRawResponse> _digitalCardProfiles;
    public IDigitalCardProfileServiceWithRawResponse DigitalCardProfiles
    {
        get { return _digitalCardProfiles.Value; }
    }

    readonly Lazy<IPhysicalCardProfileServiceWithRawResponse> _physicalCardProfiles;
    public IPhysicalCardProfileServiceWithRawResponse PhysicalCardProfiles
    {
        get { return _physicalCardProfiles.Value; }
    }

    readonly Lazy<IDigitalWalletTokenServiceWithRawResponse> _digitalWalletTokens;
    public IDigitalWalletTokenServiceWithRawResponse DigitalWalletTokens
    {
        get { return _digitalWalletTokens.Value; }
    }

    readonly Lazy<ITransactionServiceWithRawResponse> _transactions;
    public ITransactionServiceWithRawResponse Transactions
    {
        get { return _transactions.Value; }
    }

    readonly Lazy<IPendingTransactionServiceWithRawResponse> _pendingTransactions;
    public IPendingTransactionServiceWithRawResponse PendingTransactions
    {
        get { return _pendingTransactions.Value; }
    }

    readonly Lazy<IDeclinedTransactionServiceWithRawResponse> _declinedTransactions;
    public IDeclinedTransactionServiceWithRawResponse DeclinedTransactions
    {
        get { return _declinedTransactions.Value; }
    }

    readonly Lazy<IAchTransferServiceWithRawResponse> _achTransfers;
    public IAchTransferServiceWithRawResponse AchTransfers
    {
        get { return _achTransfers.Value; }
    }

    readonly Lazy<IAchPrenotificationServiceWithRawResponse> _achPrenotifications;
    public IAchPrenotificationServiceWithRawResponse AchPrenotifications
    {
        get { return _achPrenotifications.Value; }
    }

    readonly Lazy<IInboundAchTransferServiceWithRawResponse> _inboundAchTransfers;
    public IInboundAchTransferServiceWithRawResponse InboundAchTransfers
    {
        get { return _inboundAchTransfers.Value; }
    }

    readonly Lazy<IWireTransferServiceWithRawResponse> _wireTransfers;
    public IWireTransferServiceWithRawResponse WireTransfers
    {
        get { return _wireTransfers.Value; }
    }

    readonly Lazy<IInboundWireTransferServiceWithRawResponse> _inboundWireTransfers;
    public IInboundWireTransferServiceWithRawResponse InboundWireTransfers
    {
        get { return _inboundWireTransfers.Value; }
    }

    readonly Lazy<IWireDrawdownRequestServiceWithRawResponse> _wireDrawdownRequests;
    public IWireDrawdownRequestServiceWithRawResponse WireDrawdownRequests
    {
        get { return _wireDrawdownRequests.Value; }
    }

    readonly Lazy<IInboundWireDrawdownRequestServiceWithRawResponse> _inboundWireDrawdownRequests;
    public IInboundWireDrawdownRequestServiceWithRawResponse InboundWireDrawdownRequests
    {
        get { return _inboundWireDrawdownRequests.Value; }
    }

    readonly Lazy<ICheckTransferServiceWithRawResponse> _checkTransfers;
    public ICheckTransferServiceWithRawResponse CheckTransfers
    {
        get { return _checkTransfers.Value; }
    }

    readonly Lazy<IInboundCheckDepositServiceWithRawResponse> _inboundCheckDeposits;
    public IInboundCheckDepositServiceWithRawResponse InboundCheckDeposits
    {
        get { return _inboundCheckDeposits.Value; }
    }

    readonly Lazy<IRealTimePaymentsTransferServiceWithRawResponse> _realTimePaymentsTransfers;
    public IRealTimePaymentsTransferServiceWithRawResponse RealTimePaymentsTransfers
    {
        get { return _realTimePaymentsTransfers.Value; }
    }

    readonly Lazy<IInboundRealTimePaymentsTransferServiceWithRawResponse> _inboundRealTimePaymentsTransfers;
    public IInboundRealTimePaymentsTransferServiceWithRawResponse InboundRealTimePaymentsTransfers
    {
        get { return _inboundRealTimePaymentsTransfers.Value; }
    }

    readonly Lazy<IFednowTransferServiceWithRawResponse> _fednowTransfers;
    public IFednowTransferServiceWithRawResponse FednowTransfers
    {
        get { return _fednowTransfers.Value; }
    }

    readonly Lazy<IInboundFednowTransferServiceWithRawResponse> _inboundFednowTransfers;
    public IInboundFednowTransferServiceWithRawResponse InboundFednowTransfers
    {
        get { return _inboundFednowTransfers.Value; }
    }

    readonly Lazy<ISwiftTransferServiceWithRawResponse> _swiftTransfers;
    public ISwiftTransferServiceWithRawResponse SwiftTransfers
    {
        get { return _swiftTransfers.Value; }
    }

    readonly Lazy<ICheckDepositServiceWithRawResponse> _checkDeposits;
    public ICheckDepositServiceWithRawResponse CheckDeposits
    {
        get { return _checkDeposits.Value; }
    }

    readonly Lazy<ILockboxServiceWithRawResponse> _lockboxes;
    public ILockboxServiceWithRawResponse Lockboxes
    {
        get { return _lockboxes.Value; }
    }

    readonly Lazy<IInboundMailItemServiceWithRawResponse> _inboundMailItems;
    public IInboundMailItemServiceWithRawResponse InboundMailItems
    {
        get { return _inboundMailItems.Value; }
    }

    readonly Lazy<IRoutingNumberServiceWithRawResponse> _routingNumbers;
    public IRoutingNumberServiceWithRawResponse RoutingNumbers
    {
        get { return _routingNumbers.Value; }
    }

    readonly Lazy<IExternalAccountServiceWithRawResponse> _externalAccounts;
    public IExternalAccountServiceWithRawResponse ExternalAccounts
    {
        get { return _externalAccounts.Value; }
    }

    readonly Lazy<IEntityServiceWithRawResponse> _entities;
    public IEntityServiceWithRawResponse Entities
    {
        get { return _entities.Value; }
    }

    readonly Lazy<IBeneficialOwnerServiceWithRawResponse> _beneficialOwners;
    public IBeneficialOwnerServiceWithRawResponse BeneficialOwners
    {
        get { return _beneficialOwners.Value; }
    }

    readonly Lazy<ISupplementalDocumentServiceWithRawResponse> _supplementalDocuments;
    public ISupplementalDocumentServiceWithRawResponse SupplementalDocuments
    {
        get { return _supplementalDocuments.Value; }
    }

    readonly Lazy<IEntityOnboardingSessionServiceWithRawResponse> _entityOnboardingSessions;
    public IEntityOnboardingSessionServiceWithRawResponse EntityOnboardingSessions
    {
        get { return _entityOnboardingSessions.Value; }
    }

    readonly Lazy<IProgramServiceWithRawResponse> _programs;
    public IProgramServiceWithRawResponse Programs
    {
        get { return _programs.Value; }
    }

    readonly Lazy<IAccountStatementServiceWithRawResponse> _accountStatements;
    public IAccountStatementServiceWithRawResponse AccountStatements
    {
        get { return _accountStatements.Value; }
    }

    readonly Lazy<IFileServiceWithRawResponse> _files;
    public IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<IFileLinkServiceWithRawResponse> _fileLinks;
    public IFileLinkServiceWithRawResponse FileLinks
    {
        get { return _fileLinks.Value; }
    }

    readonly Lazy<IExportServiceWithRawResponse> _exports;
    public IExportServiceWithRawResponse Exports
    {
        get { return _exports.Value; }
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IEventSubscriptionServiceWithRawResponse> _eventSubscriptions;
    public IEventSubscriptionServiceWithRawResponse EventSubscriptions
    {
        get { return _eventSubscriptions.Value; }
    }

    readonly Lazy<IRealTimeDecisionServiceWithRawResponse> _realTimeDecisions;
    public IRealTimeDecisionServiceWithRawResponse RealTimeDecisions
    {
        get { return _realTimeDecisions.Value; }
    }

    readonly Lazy<IGroupServiceWithRawResponse> _groups;
    public IGroupServiceWithRawResponse Groups
    {
        get { return _groups.Value; }
    }

    readonly Lazy<IOAuthApplicationServiceWithRawResponse> _oauthApplications;
    public IOAuthApplicationServiceWithRawResponse OAuthApplications
    {
        get { return _oauthApplications.Value; }
    }

    readonly Lazy<IOAuthConnectionServiceWithRawResponse> _oauthConnections;
    public IOAuthConnectionServiceWithRawResponse OAuthConnections
    {
        get { return _oauthConnections.Value; }
    }

    readonly Lazy<IOAuthTokenServiceWithRawResponse> _oauthTokens;
    public IOAuthTokenServiceWithRawResponse OAuthTokens
    {
        get { return _oauthTokens.Value; }
    }

    readonly Lazy<IIntrafiAccountEnrollmentServiceWithRawResponse> _intrafiAccountEnrollments;
    public IIntrafiAccountEnrollmentServiceWithRawResponse IntrafiAccountEnrollments
    {
        get { return _intrafiAccountEnrollments.Value; }
    }

    readonly Lazy<IIntrafiBalanceServiceWithRawResponse> _intrafiBalances;
    public IIntrafiBalanceServiceWithRawResponse IntrafiBalances
    {
        get { return _intrafiBalances.Value; }
    }

    readonly Lazy<IIntrafiExclusionServiceWithRawResponse> _intrafiExclusions;
    public IIntrafiExclusionServiceWithRawResponse IntrafiExclusions
    {
        get { return _intrafiExclusions.Value; }
    }

    readonly Lazy<ICardTokenServiceWithRawResponse> _cardTokens;
    public ICardTokenServiceWithRawResponse CardTokens
    {
        get { return _cardTokens.Value; }
    }

    readonly Lazy<ICardPushTransferServiceWithRawResponse> _cardPushTransfers;
    public ICardPushTransferServiceWithRawResponse CardPushTransfers
    {
        get { return _cardPushTransfers.Value; }
    }

    readonly Lazy<ICardValidationServiceWithRawResponse> _cardValidations;
    public ICardValidationServiceWithRawResponse CardValidations
    {
        get { return _cardValidations.Value; }
    }

    readonly Lazy<ISimulationServiceWithRawResponse> _simulations;
    public ISimulationServiceWithRawResponse Simulations
    {
        get { return _simulations.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var idempotencyHeaderValue = string.Format("stainless-csharp-retry-{0}", Guid.NewGuid());
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(
                        request,
                        retries,
                        idempotencyHeaderValue,
                        cancellationToken
                    )
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw IncreaseExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new IncreaseIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        string idempotencyHeaderValue,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        if (!requestMessage.Headers.Contains("Idempotency-Key"))
        {
            requestMessage.Headers.Add("Idempotency-Key", idempotencyHeaderValue);
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new IncreaseIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is IncreaseIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public IncreaseClientWithRawResponse()
    {
        _options = new();

        _accounts = new(() => new AccountServiceWithRawResponse(this));
        _accountNumbers = new(() => new AccountNumberServiceWithRawResponse(this));
        _accountTransfers = new(() => new AccountTransferServiceWithRawResponse(this));
        _cards = new(() => new CardServiceWithRawResponse(this));
        _cardPayments = new(() => new CardPaymentServiceWithRawResponse(this));
        _cardPurchaseSupplements = new(() =>
            new CardPurchaseSupplementServiceWithRawResponse(this)
        );
        _cardDisputes = new(() => new CardDisputeServiceWithRawResponse(this));
        _physicalCards = new(() => new PhysicalCardServiceWithRawResponse(this));
        _digitalCardProfiles = new(() => new DigitalCardProfileServiceWithRawResponse(this));
        _physicalCardProfiles = new(() => new PhysicalCardProfileServiceWithRawResponse(this));
        _digitalWalletTokens = new(() => new DigitalWalletTokenServiceWithRawResponse(this));
        _transactions = new(() => new TransactionServiceWithRawResponse(this));
        _pendingTransactions = new(() => new PendingTransactionServiceWithRawResponse(this));
        _declinedTransactions = new(() => new DeclinedTransactionServiceWithRawResponse(this));
        _achTransfers = new(() => new AchTransferServiceWithRawResponse(this));
        _achPrenotifications = new(() => new AchPrenotificationServiceWithRawResponse(this));
        _inboundAchTransfers = new(() => new InboundAchTransferServiceWithRawResponse(this));
        _wireTransfers = new(() => new WireTransferServiceWithRawResponse(this));
        _inboundWireTransfers = new(() => new InboundWireTransferServiceWithRawResponse(this));
        _wireDrawdownRequests = new(() => new WireDrawdownRequestServiceWithRawResponse(this));
        _inboundWireDrawdownRequests = new(() =>
            new InboundWireDrawdownRequestServiceWithRawResponse(this)
        );
        _checkTransfers = new(() => new CheckTransferServiceWithRawResponse(this));
        _inboundCheckDeposits = new(() => new InboundCheckDepositServiceWithRawResponse(this));
        _realTimePaymentsTransfers = new(() =>
            new RealTimePaymentsTransferServiceWithRawResponse(this)
        );
        _inboundRealTimePaymentsTransfers = new(() =>
            new InboundRealTimePaymentsTransferServiceWithRawResponse(this)
        );
        _fednowTransfers = new(() => new FednowTransferServiceWithRawResponse(this));
        _inboundFednowTransfers = new(() => new InboundFednowTransferServiceWithRawResponse(this));
        _swiftTransfers = new(() => new SwiftTransferServiceWithRawResponse(this));
        _checkDeposits = new(() => new CheckDepositServiceWithRawResponse(this));
        _lockboxes = new(() => new LockboxServiceWithRawResponse(this));
        _inboundMailItems = new(() => new InboundMailItemServiceWithRawResponse(this));
        _routingNumbers = new(() => new RoutingNumberServiceWithRawResponse(this));
        _externalAccounts = new(() => new ExternalAccountServiceWithRawResponse(this));
        _entities = new(() => new EntityServiceWithRawResponse(this));
        _beneficialOwners = new(() => new BeneficialOwnerServiceWithRawResponse(this));
        _supplementalDocuments = new(() => new SupplementalDocumentServiceWithRawResponse(this));
        _entityOnboardingSessions = new(() =>
            new EntityOnboardingSessionServiceWithRawResponse(this)
        );
        _programs = new(() => new ProgramServiceWithRawResponse(this));
        _accountStatements = new(() => new AccountStatementServiceWithRawResponse(this));
        _files = new(() => new FileServiceWithRawResponse(this));
        _fileLinks = new(() => new FileLinkServiceWithRawResponse(this));
        _exports = new(() => new ExportServiceWithRawResponse(this));
        _events = new(() => new EventServiceWithRawResponse(this));
        _eventSubscriptions = new(() => new EventSubscriptionServiceWithRawResponse(this));
        _realTimeDecisions = new(() => new RealTimeDecisionServiceWithRawResponse(this));
        _groups = new(() => new GroupServiceWithRawResponse(this));
        _oauthApplications = new(() => new OAuthApplicationServiceWithRawResponse(this));
        _oauthConnections = new(() => new OAuthConnectionServiceWithRawResponse(this));
        _oauthTokens = new(() => new OAuthTokenServiceWithRawResponse(this));
        _intrafiAccountEnrollments = new(() =>
            new IntrafiAccountEnrollmentServiceWithRawResponse(this)
        );
        _intrafiBalances = new(() => new IntrafiBalanceServiceWithRawResponse(this));
        _intrafiExclusions = new(() => new IntrafiExclusionServiceWithRawResponse(this));
        _cardTokens = new(() => new CardTokenServiceWithRawResponse(this));
        _cardPushTransfers = new(() => new CardPushTransferServiceWithRawResponse(this));
        _cardValidations = new(() => new CardValidationServiceWithRawResponse(this));
        _simulations = new(() => new SimulationServiceWithRawResponse(this));
    }

    public IncreaseClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
