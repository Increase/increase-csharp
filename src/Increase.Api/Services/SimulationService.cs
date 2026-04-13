using System;
using Increase.Api.Core;
using Simulations = Increase.Api.Services.Simulations;

namespace Increase.Api.Services;

/// <inheritdoc/>
public sealed class SimulationService : ISimulationService
{
    readonly Lazy<ISimulationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISimulationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IIncreaseClient _client;

    /// <inheritdoc/>
    public ISimulationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SimulationService(this._client.WithOptions(modifier));
    }

    public SimulationService(IIncreaseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SimulationServiceWithRawResponse(client.WithRawResponse));
        _interestPayments = new(() => new Simulations::InterestPaymentService(client));
        _cardAuthorizations = new(() => new Simulations::CardAuthorizationService(client));
        _cardBalanceInquiries = new(() => new Simulations::CardBalanceInquiryService(client));
        _cardAuthorizationExpirations = new(() =>
            new Simulations::CardAuthorizationExpirationService(client)
        );
        _cardSettlements = new(() => new Simulations::CardSettlementService(client));
        _cardReversals = new(() => new Simulations::CardReversalService(client));
        _cardIncrements = new(() => new Simulations::CardIncrementService(client));
        _cardFuelConfirmations = new(() => new Simulations::CardFuelConfirmationService(client));
        _cardRefunds = new(() => new Simulations::CardRefundService(client));
        _cardAuthentications = new(() => new Simulations::CardAuthenticationService(client));
        _cardDisputes = new(() => new Simulations::CardDisputeService(client));
        _physicalCards = new(() => new Simulations::PhysicalCardService(client));
        _digitalWalletTokenRequests = new(() =>
            new Simulations::DigitalWalletTokenRequestService(client)
        );
        _pendingTransactions = new(() => new Simulations::PendingTransactionService(client));
        _achTransfers = new(() => new Simulations::AchTransferService(client));
        _inboundAchTransfers = new(() => new Simulations::InboundAchTransferService(client));
        _wireTransfers = new(() => new Simulations::WireTransferService(client));
        _inboundWireTransfers = new(() => new Simulations::InboundWireTransferService(client));
        _wireDrawdownRequests = new(() => new Simulations::WireDrawdownRequestService(client));
        _inboundWireDrawdownRequests = new(() =>
            new Simulations::InboundWireDrawdownRequestService(client)
        );
        _checkTransfers = new(() => new Simulations::CheckTransferService(client));
        _inboundCheckDeposits = new(() => new Simulations::InboundCheckDepositService(client));
        _realTimePaymentsTransfers = new(() =>
            new Simulations::RealTimePaymentsTransferService(client)
        );
        _inboundRealTimePaymentsTransfers = new(() =>
            new Simulations::InboundRealTimePaymentsTransferService(client)
        );
        _inboundFednowTransfers = new(() => new Simulations::InboundFednowTransferService(client));
        _checkDeposits = new(() => new Simulations::CheckDepositService(client));
        _inboundMailItems = new(() => new Simulations::InboundMailItemService(client));
        _entityOnboardingSessions = new(() =>
            new Simulations::EntityOnboardingSessionService(client)
        );
        _programs = new(() => new Simulations::ProgramService(client));
        _accountStatements = new(() => new Simulations::AccountStatementService(client));
        _exports = new(() => new Simulations::ExportService(client));
        _cardTokens = new(() => new Simulations::CardTokenService(client));
    }

    readonly Lazy<Simulations::IInterestPaymentService> _interestPayments;
    public Simulations::IInterestPaymentService InterestPayments
    {
        get { return _interestPayments.Value; }
    }

    readonly Lazy<Simulations::ICardAuthorizationService> _cardAuthorizations;
    public Simulations::ICardAuthorizationService CardAuthorizations
    {
        get { return _cardAuthorizations.Value; }
    }

    readonly Lazy<Simulations::ICardBalanceInquiryService> _cardBalanceInquiries;
    public Simulations::ICardBalanceInquiryService CardBalanceInquiries
    {
        get { return _cardBalanceInquiries.Value; }
    }

    readonly Lazy<Simulations::ICardAuthorizationExpirationService> _cardAuthorizationExpirations;
    public Simulations::ICardAuthorizationExpirationService CardAuthorizationExpirations
    {
        get { return _cardAuthorizationExpirations.Value; }
    }

    readonly Lazy<Simulations::ICardSettlementService> _cardSettlements;
    public Simulations::ICardSettlementService CardSettlements
    {
        get { return _cardSettlements.Value; }
    }

    readonly Lazy<Simulations::ICardReversalService> _cardReversals;
    public Simulations::ICardReversalService CardReversals
    {
        get { return _cardReversals.Value; }
    }

    readonly Lazy<Simulations::ICardIncrementService> _cardIncrements;
    public Simulations::ICardIncrementService CardIncrements
    {
        get { return _cardIncrements.Value; }
    }

    readonly Lazy<Simulations::ICardFuelConfirmationService> _cardFuelConfirmations;
    public Simulations::ICardFuelConfirmationService CardFuelConfirmations
    {
        get { return _cardFuelConfirmations.Value; }
    }

    readonly Lazy<Simulations::ICardRefundService> _cardRefunds;
    public Simulations::ICardRefundService CardRefunds
    {
        get { return _cardRefunds.Value; }
    }

    readonly Lazy<Simulations::ICardAuthenticationService> _cardAuthentications;
    public Simulations::ICardAuthenticationService CardAuthentications
    {
        get { return _cardAuthentications.Value; }
    }

    readonly Lazy<Simulations::ICardDisputeService> _cardDisputes;
    public Simulations::ICardDisputeService CardDisputes
    {
        get { return _cardDisputes.Value; }
    }

    readonly Lazy<Simulations::IPhysicalCardService> _physicalCards;
    public Simulations::IPhysicalCardService PhysicalCards
    {
        get { return _physicalCards.Value; }
    }

    readonly Lazy<Simulations::IDigitalWalletTokenRequestService> _digitalWalletTokenRequests;
    public Simulations::IDigitalWalletTokenRequestService DigitalWalletTokenRequests
    {
        get { return _digitalWalletTokenRequests.Value; }
    }

    readonly Lazy<Simulations::IPendingTransactionService> _pendingTransactions;
    public Simulations::IPendingTransactionService PendingTransactions
    {
        get { return _pendingTransactions.Value; }
    }

    readonly Lazy<Simulations::IAchTransferService> _achTransfers;
    public Simulations::IAchTransferService AchTransfers
    {
        get { return _achTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundAchTransferService> _inboundAchTransfers;
    public Simulations::IInboundAchTransferService InboundAchTransfers
    {
        get { return _inboundAchTransfers.Value; }
    }

    readonly Lazy<Simulations::IWireTransferService> _wireTransfers;
    public Simulations::IWireTransferService WireTransfers
    {
        get { return _wireTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundWireTransferService> _inboundWireTransfers;
    public Simulations::IInboundWireTransferService InboundWireTransfers
    {
        get { return _inboundWireTransfers.Value; }
    }

    readonly Lazy<Simulations::IWireDrawdownRequestService> _wireDrawdownRequests;
    public Simulations::IWireDrawdownRequestService WireDrawdownRequests
    {
        get { return _wireDrawdownRequests.Value; }
    }

    readonly Lazy<Simulations::IInboundWireDrawdownRequestService> _inboundWireDrawdownRequests;
    public Simulations::IInboundWireDrawdownRequestService InboundWireDrawdownRequests
    {
        get { return _inboundWireDrawdownRequests.Value; }
    }

    readonly Lazy<Simulations::ICheckTransferService> _checkTransfers;
    public Simulations::ICheckTransferService CheckTransfers
    {
        get { return _checkTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundCheckDepositService> _inboundCheckDeposits;
    public Simulations::IInboundCheckDepositService InboundCheckDeposits
    {
        get { return _inboundCheckDeposits.Value; }
    }

    readonly Lazy<Simulations::IRealTimePaymentsTransferService> _realTimePaymentsTransfers;
    public Simulations::IRealTimePaymentsTransferService RealTimePaymentsTransfers
    {
        get { return _realTimePaymentsTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundRealTimePaymentsTransferService> _inboundRealTimePaymentsTransfers;
    public Simulations::IInboundRealTimePaymentsTransferService InboundRealTimePaymentsTransfers
    {
        get { return _inboundRealTimePaymentsTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundFednowTransferService> _inboundFednowTransfers;
    public Simulations::IInboundFednowTransferService InboundFednowTransfers
    {
        get { return _inboundFednowTransfers.Value; }
    }

    readonly Lazy<Simulations::ICheckDepositService> _checkDeposits;
    public Simulations::ICheckDepositService CheckDeposits
    {
        get { return _checkDeposits.Value; }
    }

    readonly Lazy<Simulations::IInboundMailItemService> _inboundMailItems;
    public Simulations::IInboundMailItemService InboundMailItems
    {
        get { return _inboundMailItems.Value; }
    }

    readonly Lazy<Simulations::IEntityOnboardingSessionService> _entityOnboardingSessions;
    public Simulations::IEntityOnboardingSessionService EntityOnboardingSessions
    {
        get { return _entityOnboardingSessions.Value; }
    }

    readonly Lazy<Simulations::IProgramService> _programs;
    public Simulations::IProgramService Programs
    {
        get { return _programs.Value; }
    }

    readonly Lazy<Simulations::IAccountStatementService> _accountStatements;
    public Simulations::IAccountStatementService AccountStatements
    {
        get { return _accountStatements.Value; }
    }

    readonly Lazy<Simulations::IExportService> _exports;
    public Simulations::IExportService Exports
    {
        get { return _exports.Value; }
    }

    readonly Lazy<Simulations::ICardTokenService> _cardTokens;
    public Simulations::ICardTokenService CardTokens
    {
        get { return _cardTokens.Value; }
    }
}

/// <inheritdoc/>
public sealed class SimulationServiceWithRawResponse : ISimulationServiceWithRawResponse
{
    readonly IIncreaseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISimulationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimulationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SimulationServiceWithRawResponse(IIncreaseClientWithRawResponse client)
    {
        _client = client;

        _interestPayments = new(() =>
            new Simulations::InterestPaymentServiceWithRawResponse(client)
        );
        _cardAuthorizations = new(() =>
            new Simulations::CardAuthorizationServiceWithRawResponse(client)
        );
        _cardBalanceInquiries = new(() =>
            new Simulations::CardBalanceInquiryServiceWithRawResponse(client)
        );
        _cardAuthorizationExpirations = new(() =>
            new Simulations::CardAuthorizationExpirationServiceWithRawResponse(client)
        );
        _cardSettlements = new(() => new Simulations::CardSettlementServiceWithRawResponse(client));
        _cardReversals = new(() => new Simulations::CardReversalServiceWithRawResponse(client));
        _cardIncrements = new(() => new Simulations::CardIncrementServiceWithRawResponse(client));
        _cardFuelConfirmations = new(() =>
            new Simulations::CardFuelConfirmationServiceWithRawResponse(client)
        );
        _cardRefunds = new(() => new Simulations::CardRefundServiceWithRawResponse(client));
        _cardAuthentications = new(() =>
            new Simulations::CardAuthenticationServiceWithRawResponse(client)
        );
        _cardDisputes = new(() => new Simulations::CardDisputeServiceWithRawResponse(client));
        _physicalCards = new(() => new Simulations::PhysicalCardServiceWithRawResponse(client));
        _digitalWalletTokenRequests = new(() =>
            new Simulations::DigitalWalletTokenRequestServiceWithRawResponse(client)
        );
        _pendingTransactions = new(() =>
            new Simulations::PendingTransactionServiceWithRawResponse(client)
        );
        _achTransfers = new(() => new Simulations::AchTransferServiceWithRawResponse(client));
        _inboundAchTransfers = new(() =>
            new Simulations::InboundAchTransferServiceWithRawResponse(client)
        );
        _wireTransfers = new(() => new Simulations::WireTransferServiceWithRawResponse(client));
        _inboundWireTransfers = new(() =>
            new Simulations::InboundWireTransferServiceWithRawResponse(client)
        );
        _wireDrawdownRequests = new(() =>
            new Simulations::WireDrawdownRequestServiceWithRawResponse(client)
        );
        _inboundWireDrawdownRequests = new(() =>
            new Simulations::InboundWireDrawdownRequestServiceWithRawResponse(client)
        );
        _checkTransfers = new(() => new Simulations::CheckTransferServiceWithRawResponse(client));
        _inboundCheckDeposits = new(() =>
            new Simulations::InboundCheckDepositServiceWithRawResponse(client)
        );
        _realTimePaymentsTransfers = new(() =>
            new Simulations::RealTimePaymentsTransferServiceWithRawResponse(client)
        );
        _inboundRealTimePaymentsTransfers = new(() =>
            new Simulations::InboundRealTimePaymentsTransferServiceWithRawResponse(client)
        );
        _inboundFednowTransfers = new(() =>
            new Simulations::InboundFednowTransferServiceWithRawResponse(client)
        );
        _checkDeposits = new(() => new Simulations::CheckDepositServiceWithRawResponse(client));
        _inboundMailItems = new(() =>
            new Simulations::InboundMailItemServiceWithRawResponse(client)
        );
        _entityOnboardingSessions = new(() =>
            new Simulations::EntityOnboardingSessionServiceWithRawResponse(client)
        );
        _programs = new(() => new Simulations::ProgramServiceWithRawResponse(client));
        _accountStatements = new(() =>
            new Simulations::AccountStatementServiceWithRawResponse(client)
        );
        _exports = new(() => new Simulations::ExportServiceWithRawResponse(client));
        _cardTokens = new(() => new Simulations::CardTokenServiceWithRawResponse(client));
    }

    readonly Lazy<Simulations::IInterestPaymentServiceWithRawResponse> _interestPayments;
    public Simulations::IInterestPaymentServiceWithRawResponse InterestPayments
    {
        get { return _interestPayments.Value; }
    }

    readonly Lazy<Simulations::ICardAuthorizationServiceWithRawResponse> _cardAuthorizations;
    public Simulations::ICardAuthorizationServiceWithRawResponse CardAuthorizations
    {
        get { return _cardAuthorizations.Value; }
    }

    readonly Lazy<Simulations::ICardBalanceInquiryServiceWithRawResponse> _cardBalanceInquiries;
    public Simulations::ICardBalanceInquiryServiceWithRawResponse CardBalanceInquiries
    {
        get { return _cardBalanceInquiries.Value; }
    }

    readonly Lazy<Simulations::ICardAuthorizationExpirationServiceWithRawResponse> _cardAuthorizationExpirations;
    public Simulations::ICardAuthorizationExpirationServiceWithRawResponse CardAuthorizationExpirations
    {
        get { return _cardAuthorizationExpirations.Value; }
    }

    readonly Lazy<Simulations::ICardSettlementServiceWithRawResponse> _cardSettlements;
    public Simulations::ICardSettlementServiceWithRawResponse CardSettlements
    {
        get { return _cardSettlements.Value; }
    }

    readonly Lazy<Simulations::ICardReversalServiceWithRawResponse> _cardReversals;
    public Simulations::ICardReversalServiceWithRawResponse CardReversals
    {
        get { return _cardReversals.Value; }
    }

    readonly Lazy<Simulations::ICardIncrementServiceWithRawResponse> _cardIncrements;
    public Simulations::ICardIncrementServiceWithRawResponse CardIncrements
    {
        get { return _cardIncrements.Value; }
    }

    readonly Lazy<Simulations::ICardFuelConfirmationServiceWithRawResponse> _cardFuelConfirmations;
    public Simulations::ICardFuelConfirmationServiceWithRawResponse CardFuelConfirmations
    {
        get { return _cardFuelConfirmations.Value; }
    }

    readonly Lazy<Simulations::ICardRefundServiceWithRawResponse> _cardRefunds;
    public Simulations::ICardRefundServiceWithRawResponse CardRefunds
    {
        get { return _cardRefunds.Value; }
    }

    readonly Lazy<Simulations::ICardAuthenticationServiceWithRawResponse> _cardAuthentications;
    public Simulations::ICardAuthenticationServiceWithRawResponse CardAuthentications
    {
        get { return _cardAuthentications.Value; }
    }

    readonly Lazy<Simulations::ICardDisputeServiceWithRawResponse> _cardDisputes;
    public Simulations::ICardDisputeServiceWithRawResponse CardDisputes
    {
        get { return _cardDisputes.Value; }
    }

    readonly Lazy<Simulations::IPhysicalCardServiceWithRawResponse> _physicalCards;
    public Simulations::IPhysicalCardServiceWithRawResponse PhysicalCards
    {
        get { return _physicalCards.Value; }
    }

    readonly Lazy<Simulations::IDigitalWalletTokenRequestServiceWithRawResponse> _digitalWalletTokenRequests;
    public Simulations::IDigitalWalletTokenRequestServiceWithRawResponse DigitalWalletTokenRequests
    {
        get { return _digitalWalletTokenRequests.Value; }
    }

    readonly Lazy<Simulations::IPendingTransactionServiceWithRawResponse> _pendingTransactions;
    public Simulations::IPendingTransactionServiceWithRawResponse PendingTransactions
    {
        get { return _pendingTransactions.Value; }
    }

    readonly Lazy<Simulations::IAchTransferServiceWithRawResponse> _achTransfers;
    public Simulations::IAchTransferServiceWithRawResponse AchTransfers
    {
        get { return _achTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundAchTransferServiceWithRawResponse> _inboundAchTransfers;
    public Simulations::IInboundAchTransferServiceWithRawResponse InboundAchTransfers
    {
        get { return _inboundAchTransfers.Value; }
    }

    readonly Lazy<Simulations::IWireTransferServiceWithRawResponse> _wireTransfers;
    public Simulations::IWireTransferServiceWithRawResponse WireTransfers
    {
        get { return _wireTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundWireTransferServiceWithRawResponse> _inboundWireTransfers;
    public Simulations::IInboundWireTransferServiceWithRawResponse InboundWireTransfers
    {
        get { return _inboundWireTransfers.Value; }
    }

    readonly Lazy<Simulations::IWireDrawdownRequestServiceWithRawResponse> _wireDrawdownRequests;
    public Simulations::IWireDrawdownRequestServiceWithRawResponse WireDrawdownRequests
    {
        get { return _wireDrawdownRequests.Value; }
    }

    readonly Lazy<Simulations::IInboundWireDrawdownRequestServiceWithRawResponse> _inboundWireDrawdownRequests;
    public Simulations::IInboundWireDrawdownRequestServiceWithRawResponse InboundWireDrawdownRequests
    {
        get { return _inboundWireDrawdownRequests.Value; }
    }

    readonly Lazy<Simulations::ICheckTransferServiceWithRawResponse> _checkTransfers;
    public Simulations::ICheckTransferServiceWithRawResponse CheckTransfers
    {
        get { return _checkTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundCheckDepositServiceWithRawResponse> _inboundCheckDeposits;
    public Simulations::IInboundCheckDepositServiceWithRawResponse InboundCheckDeposits
    {
        get { return _inboundCheckDeposits.Value; }
    }

    readonly Lazy<Simulations::IRealTimePaymentsTransferServiceWithRawResponse> _realTimePaymentsTransfers;
    public Simulations::IRealTimePaymentsTransferServiceWithRawResponse RealTimePaymentsTransfers
    {
        get { return _realTimePaymentsTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundRealTimePaymentsTransferServiceWithRawResponse> _inboundRealTimePaymentsTransfers;
    public Simulations::IInboundRealTimePaymentsTransferServiceWithRawResponse InboundRealTimePaymentsTransfers
    {
        get { return _inboundRealTimePaymentsTransfers.Value; }
    }

    readonly Lazy<Simulations::IInboundFednowTransferServiceWithRawResponse> _inboundFednowTransfers;
    public Simulations::IInboundFednowTransferServiceWithRawResponse InboundFednowTransfers
    {
        get { return _inboundFednowTransfers.Value; }
    }

    readonly Lazy<Simulations::ICheckDepositServiceWithRawResponse> _checkDeposits;
    public Simulations::ICheckDepositServiceWithRawResponse CheckDeposits
    {
        get { return _checkDeposits.Value; }
    }

    readonly Lazy<Simulations::IInboundMailItemServiceWithRawResponse> _inboundMailItems;
    public Simulations::IInboundMailItemServiceWithRawResponse InboundMailItems
    {
        get { return _inboundMailItems.Value; }
    }

    readonly Lazy<Simulations::IEntityOnboardingSessionServiceWithRawResponse> _entityOnboardingSessions;
    public Simulations::IEntityOnboardingSessionServiceWithRawResponse EntityOnboardingSessions
    {
        get { return _entityOnboardingSessions.Value; }
    }

    readonly Lazy<Simulations::IProgramServiceWithRawResponse> _programs;
    public Simulations::IProgramServiceWithRawResponse Programs
    {
        get { return _programs.Value; }
    }

    readonly Lazy<Simulations::IAccountStatementServiceWithRawResponse> _accountStatements;
    public Simulations::IAccountStatementServiceWithRawResponse AccountStatements
    {
        get { return _accountStatements.Value; }
    }

    readonly Lazy<Simulations::IExportServiceWithRawResponse> _exports;
    public Simulations::IExportServiceWithRawResponse Exports
    {
        get { return _exports.Value; }
    }

    readonly Lazy<Simulations::ICardTokenServiceWithRawResponse> _cardTokens;
    public Simulations::ICardTokenServiceWithRawResponse CardTokens
    {
        get { return _cardTokens.Value; }
    }
}
