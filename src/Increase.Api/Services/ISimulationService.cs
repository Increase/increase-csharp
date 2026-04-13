using System;
using Increase.Api.Core;
using Simulations = Increase.Api.Services.Simulations;

namespace Increase.Api.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISimulationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISimulationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimulationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Simulations::IInterestPaymentService InterestPayments { get; }

    Simulations::ICardAuthorizationService CardAuthorizations { get; }

    Simulations::ICardBalanceInquiryService CardBalanceInquiries { get; }

    Simulations::ICardAuthorizationExpirationService CardAuthorizationExpirations { get; }

    Simulations::ICardSettlementService CardSettlements { get; }

    Simulations::ICardReversalService CardReversals { get; }

    Simulations::ICardIncrementService CardIncrements { get; }

    Simulations::ICardFuelConfirmationService CardFuelConfirmations { get; }

    Simulations::ICardRefundService CardRefunds { get; }

    Simulations::ICardAuthenticationService CardAuthentications { get; }

    Simulations::ICardDisputeService CardDisputes { get; }

    Simulations::IPhysicalCardService PhysicalCards { get; }

    Simulations::IDigitalWalletTokenRequestService DigitalWalletTokenRequests { get; }

    Simulations::IPendingTransactionService PendingTransactions { get; }

    Simulations::IAchTransferService AchTransfers { get; }

    Simulations::IInboundAchTransferService InboundAchTransfers { get; }

    Simulations::IWireTransferService WireTransfers { get; }

    Simulations::IInboundWireTransferService InboundWireTransfers { get; }

    Simulations::IWireDrawdownRequestService WireDrawdownRequests { get; }

    Simulations::IInboundWireDrawdownRequestService InboundWireDrawdownRequests { get; }

    Simulations::ICheckTransferService CheckTransfers { get; }

    Simulations::IInboundCheckDepositService InboundCheckDeposits { get; }

    Simulations::IRealTimePaymentsTransferService RealTimePaymentsTransfers { get; }

    Simulations::IInboundRealTimePaymentsTransferService InboundRealTimePaymentsTransfers { get; }

    Simulations::IInboundFednowTransferService InboundFednowTransfers { get; }

    Simulations::ICheckDepositService CheckDeposits { get; }

    Simulations::IInboundMailItemService InboundMailItems { get; }

    Simulations::IEntityOnboardingSessionService EntityOnboardingSessions { get; }

    Simulations::IProgramService Programs { get; }

    Simulations::IAccountStatementService AccountStatements { get; }

    Simulations::IExportService Exports { get; }

    Simulations::ICardTokenService CardTokens { get; }
}

/// <summary>
/// A view of <see cref="ISimulationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISimulationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimulationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Simulations::IInterestPaymentServiceWithRawResponse InterestPayments { get; }

    Simulations::ICardAuthorizationServiceWithRawResponse CardAuthorizations { get; }

    Simulations::ICardBalanceInquiryServiceWithRawResponse CardBalanceInquiries { get; }

    Simulations::ICardAuthorizationExpirationServiceWithRawResponse CardAuthorizationExpirations { get; }

    Simulations::ICardSettlementServiceWithRawResponse CardSettlements { get; }

    Simulations::ICardReversalServiceWithRawResponse CardReversals { get; }

    Simulations::ICardIncrementServiceWithRawResponse CardIncrements { get; }

    Simulations::ICardFuelConfirmationServiceWithRawResponse CardFuelConfirmations { get; }

    Simulations::ICardRefundServiceWithRawResponse CardRefunds { get; }

    Simulations::ICardAuthenticationServiceWithRawResponse CardAuthentications { get; }

    Simulations::ICardDisputeServiceWithRawResponse CardDisputes { get; }

    Simulations::IPhysicalCardServiceWithRawResponse PhysicalCards { get; }

    Simulations::IDigitalWalletTokenRequestServiceWithRawResponse DigitalWalletTokenRequests { get; }

    Simulations::IPendingTransactionServiceWithRawResponse PendingTransactions { get; }

    Simulations::IAchTransferServiceWithRawResponse AchTransfers { get; }

    Simulations::IInboundAchTransferServiceWithRawResponse InboundAchTransfers { get; }

    Simulations::IWireTransferServiceWithRawResponse WireTransfers { get; }

    Simulations::IInboundWireTransferServiceWithRawResponse InboundWireTransfers { get; }

    Simulations::IWireDrawdownRequestServiceWithRawResponse WireDrawdownRequests { get; }

    Simulations::IInboundWireDrawdownRequestServiceWithRawResponse InboundWireDrawdownRequests { get; }

    Simulations::ICheckTransferServiceWithRawResponse CheckTransfers { get; }

    Simulations::IInboundCheckDepositServiceWithRawResponse InboundCheckDeposits { get; }

    Simulations::IRealTimePaymentsTransferServiceWithRawResponse RealTimePaymentsTransfers { get; }

    Simulations::IInboundRealTimePaymentsTransferServiceWithRawResponse InboundRealTimePaymentsTransfers { get; }

    Simulations::IInboundFednowTransferServiceWithRawResponse InboundFednowTransfers { get; }

    Simulations::ICheckDepositServiceWithRawResponse CheckDeposits { get; }

    Simulations::IInboundMailItemServiceWithRawResponse InboundMailItems { get; }

    Simulations::IEntityOnboardingSessionServiceWithRawResponse EntityOnboardingSessions { get; }

    Simulations::IProgramServiceWithRawResponse Programs { get; }

    Simulations::IAccountStatementServiceWithRawResponse AccountStatements { get; }

    Simulations::IExportServiceWithRawResponse Exports { get; }

    Simulations::ICardTokenServiceWithRawResponse CardTokens { get; }
}
