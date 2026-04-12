using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Events;

/// <summary>
/// Events are records of things that happened to objects at Increase. Events are
/// accessible via the List Events endpoint and can be delivered to your application
/// via webhooks. For more information, see our [webhooks guide](https://increase.com/documentation/webhooks).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnwrapWebhookEvent, UnwrapWebhookEventFromRaw>))]
public sealed record class UnwrapWebhookEvent : JsonModel
{
    /// <summary>
    /// The Event identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The identifier of the object that generated this Event.
    /// </summary>
    public required string AssociatedObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("associated_object_id");
        }
        init { this._rawData.Set("associated_object_id", value); }
    }

    /// <summary>
    /// The type of the object that generated this Event.
    /// </summary>
    public required string AssociatedObjectType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("associated_object_type");
        }
        init { this._rawData.Set("associated_object_type", value); }
    }

    /// <summary>
    /// The category of the Event. We may add additional possible values for this
    /// enum over time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, UnwrapWebhookEventCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnwrapWebhookEventCategory>>(
                "category"
            );
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The time the Event was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `event`.
    /// </summary>
    public required ApiEnum<string, UnwrapWebhookEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnwrapWebhookEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AssociatedObjectID;
        _ = this.AssociatedObjectType;
        this.Category.Validate();
        _ = this.CreatedAt;
        this.Type.Validate();
    }

    public UnwrapWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnwrapWebhookEvent(UnwrapWebhookEvent unwrapWebhookEvent)
        : base(unwrapWebhookEvent) { }
#pragma warning restore CS8618

    public UnwrapWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnwrapWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnwrapWebhookEventFromRaw.FromRawUnchecked"/>
    public static UnwrapWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnwrapWebhookEventFromRaw : IFromRawJson<UnwrapWebhookEvent>
{
    /// <inheritdoc/>
    public UnwrapWebhookEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnwrapWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the Event. We may add additional possible values for this enum
/// over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(UnwrapWebhookEventCategoryConverter))]
public enum UnwrapWebhookEventCategory
{
    /// <summary>
    /// Occurs whenever an Account is created.
    /// </summary>
    AccountCreated,

    /// <summary>
    /// Occurs whenever an Account is updated.
    /// </summary>
    AccountUpdated,

    /// <summary>
    /// Occurs whenever an Account Number is created.
    /// </summary>
    AccountNumberCreated,

    /// <summary>
    /// Occurs whenever an Account Number is updated.
    /// </summary>
    AccountNumberUpdated,

    /// <summary>
    /// Occurs whenever an Account Statement is created.
    /// </summary>
    AccountStatementCreated,

    /// <summary>
    /// Occurs whenever an Account Transfer is created.
    /// </summary>
    AccountTransferCreated,

    /// <summary>
    /// Occurs whenever an Account Transfer is updated.
    /// </summary>
    AccountTransferUpdated,

    /// <summary>
    /// Occurs whenever an ACH Prenotification is created.
    /// </summary>
    AchPrenotificationCreated,

    /// <summary>
    /// Occurs whenever an ACH Prenotification is updated.
    /// </summary>
    AchPrenotificationUpdated,

    /// <summary>
    /// Occurs whenever an ACH Transfer is created.
    /// </summary>
    AchTransferCreated,

    /// <summary>
    /// Occurs whenever an ACH Transfer is updated.
    /// </summary>
    AchTransferUpdated,

    /// <summary>
    /// Occurs whenever a Blockchain Address is created.
    /// </summary>
    BlockchainAddressCreated,

    /// <summary>
    /// Occurs whenever a Blockchain Address is updated.
    /// </summary>
    BlockchainAddressUpdated,

    /// <summary>
    /// Occurs whenever a Blockchain Off-Ramp Transfer is created.
    /// </summary>
    BlockchainOfframpTransferCreated,

    /// <summary>
    /// Occurs whenever a Blockchain Off-Ramp Transfer is updated.
    /// </summary>
    BlockchainOfframpTransferUpdated,

    /// <summary>
    /// Occurs whenever a Blockchain On-Ramp Transfer is created.
    /// </summary>
    BlockchainOnrampTransferCreated,

    /// <summary>
    /// Occurs whenever a Blockchain On-Ramp Transfer is updated.
    /// </summary>
    BlockchainOnrampTransferUpdated,

    /// <summary>
    /// Occurs whenever a Bookkeeping Account is created.
    /// </summary>
    BookkeepingAccountCreated,

    /// <summary>
    /// Occurs whenever a Bookkeeping Account is updated.
    /// </summary>
    BookkeepingAccountUpdated,

    /// <summary>
    /// Occurs whenever a Bookkeeping Entry Set is created.
    /// </summary>
    BookkeepingEntrySetUpdated,

    /// <summary>
    /// Occurs whenever a Card is created.
    /// </summary>
    CardCreated,

    /// <summary>
    /// Occurs whenever a Card is updated.
    /// </summary>
    CardUpdated,

    /// <summary>
    /// Occurs whenever a Card Payment is created.
    /// </summary>
    CardPaymentCreated,

    /// <summary>
    /// Occurs whenever a Card Payment is updated.
    /// </summary>
    CardPaymentUpdated,

    /// <summary>
    /// Occurs whenever a Card Purchase Supplement is created.
    /// </summary>
    CardPurchaseSupplementCreated,

    /// <summary>
    /// Occurs whenever a Card Profile is created.
    /// </summary>
    CardProfileCreated,

    /// <summary>
    /// Occurs whenever a Card Profile is updated.
    /// </summary>
    CardProfileUpdated,

    /// <summary>
    /// Occurs whenever a Card Dispute is created.
    /// </summary>
    CardDisputeCreated,

    /// <summary>
    /// Occurs whenever a Card Dispute is updated.
    /// </summary>
    CardDisputeUpdated,

    /// <summary>
    /// Occurs whenever a Check Deposit is created.
    /// </summary>
    CheckDepositCreated,

    /// <summary>
    /// Occurs whenever a Check Deposit is updated.
    /// </summary>
    CheckDepositUpdated,

    /// <summary>
    /// Occurs whenever a Check Transfer is created.
    /// </summary>
    CheckTransferCreated,

    /// <summary>
    /// Occurs whenever a Check Transfer is updated.
    /// </summary>
    CheckTransferUpdated,

    /// <summary>
    /// Occurs whenever a Declined Transaction is created.
    /// </summary>
    DeclinedTransactionCreated,

    /// <summary>
    /// Occurs whenever a Digital Card Profile is created.
    /// </summary>
    DigitalCardProfileCreated,

    /// <summary>
    /// Occurs whenever a Digital Card Profile is updated.
    /// </summary>
    DigitalCardProfileUpdated,

    /// <summary>
    /// Occurs whenever a Digital Wallet Token is created.
    /// </summary>
    DigitalWalletTokenCreated,

    /// <summary>
    /// Occurs whenever a Digital Wallet Token is updated.
    /// </summary>
    DigitalWalletTokenUpdated,

    /// <summary>
    /// Occurs whenever a Document is created.
    /// </summary>
    DocumentCreated,

    /// <summary>
    /// Occurs whenever an Entity is created.
    /// </summary>
    EntityCreated,

    /// <summary>
    /// Occurs whenever an Entity is updated.
    /// </summary>
    EntityUpdated,

    /// <summary>
    /// Occurs whenever an Event Subscription is created.
    /// </summary>
    EventSubscriptionCreated,

    /// <summary>
    /// Occurs whenever an Event Subscription is updated.
    /// </summary>
    EventSubscriptionUpdated,

    /// <summary>
    /// Occurs whenever an Export is created.
    /// </summary>
    ExportCreated,

    /// <summary>
    /// Occurs whenever an Export is updated.
    /// </summary>
    ExportUpdated,

    /// <summary>
    /// Occurs whenever an External Account is created.
    /// </summary>
    ExternalAccountCreated,

    /// <summary>
    /// Occurs whenever an External Account is updated.
    /// </summary>
    ExternalAccountUpdated,

    /// <summary>
    /// Occurs whenever a FedNow Transfer is created.
    /// </summary>
    FednowTransferCreated,

    /// <summary>
    /// Occurs whenever a FedNow Transfer is updated.
    /// </summary>
    FednowTransferUpdated,

    /// <summary>
    /// Occurs whenever a File is created.
    /// </summary>
    FileCreated,

    /// <summary>
    /// Occurs whenever a Group is updated.
    /// </summary>
    GroupUpdated,

    /// <summary>
    /// Increase may send webhooks with this category to see if a webhook endpoint
    /// is working properly.
    /// </summary>
    GroupHeartbeat,

    /// <summary>
    /// Occurs whenever an Inbound ACH Transfer is created.
    /// </summary>
    InboundAchTransferCreated,

    /// <summary>
    /// Occurs whenever an Inbound ACH Transfer is updated.
    /// </summary>
    InboundAchTransferUpdated,

    /// <summary>
    /// Occurs whenever an Inbound ACH Transfer Return is created.
    /// </summary>
    InboundAchTransferReturnCreated,

    /// <summary>
    /// Occurs whenever an Inbound ACH Transfer Return is updated.
    /// </summary>
    InboundAchTransferReturnUpdated,

    /// <summary>
    /// Occurs whenever an Inbound Check Deposit is created.
    /// </summary>
    InboundCheckDepositCreated,

    /// <summary>
    /// Occurs whenever an Inbound Check Deposit is updated.
    /// </summary>
    InboundCheckDepositUpdated,

    /// <summary>
    /// Occurs whenever an Inbound FedNow Transfer is created.
    /// </summary>
    InboundFednowTransferCreated,

    /// <summary>
    /// Occurs whenever an Inbound FedNow Transfer is updated.
    /// </summary>
    InboundFednowTransferUpdated,

    /// <summary>
    /// Occurs whenever an Inbound Mail Item is created.
    /// </summary>
    InboundMailItemCreated,

    /// <summary>
    /// Occurs whenever an Inbound Mail Item is updated.
    /// </summary>
    InboundMailItemUpdated,

    /// <summary>
    /// Occurs whenever an Inbound Real-Time Payments Transfer is created.
    /// </summary>
    InboundRealTimePaymentsTransferCreated,

    /// <summary>
    /// Occurs whenever an Inbound Real-Time Payments Transfer is updated.
    /// </summary>
    InboundRealTimePaymentsTransferUpdated,

    /// <summary>
    /// Occurs whenever an Inbound Wire Drawdown Request is created.
    /// </summary>
    InboundWireDrawdownRequestCreated,

    /// <summary>
    /// Occurs whenever an Inbound Wire Transfer is created.
    /// </summary>
    InboundWireTransferCreated,

    /// <summary>
    /// Occurs whenever an Inbound Wire Transfer is updated.
    /// </summary>
    InboundWireTransferUpdated,

    /// <summary>
    /// Occurs whenever an IntraFi Account Enrollment is created.
    /// </summary>
    IntrafiAccountEnrollmentCreated,

    /// <summary>
    /// Occurs whenever an IntraFi Account Enrollment is updated.
    /// </summary>
    IntrafiAccountEnrollmentUpdated,

    /// <summary>
    /// Occurs whenever an IntraFi Exclusion is created.
    /// </summary>
    IntrafiExclusionCreated,

    /// <summary>
    /// Occurs whenever an IntraFi Exclusion is updated.
    /// </summary>
    IntrafiExclusionUpdated,

    /// <summary>
    /// Occurs whenever a Legacy Card Dispute is created.
    /// </summary>
    LegacyCardDisputeCreated,

    /// <summary>
    /// Occurs whenever a Legacy Card Dispute is updated.
    /// </summary>
    LegacyCardDisputeUpdated,

    /// <summary>
    /// Occurs whenever a Lockbox is created.
    /// </summary>
    LockboxCreated,

    /// <summary>
    /// Occurs whenever a Lockbox is updated.
    /// </summary>
    LockboxUpdated,

    /// <summary>
    /// Occurs whenever an OAuth Connection is created.
    /// </summary>
    OAuthConnectionCreated,

    /// <summary>
    /// Occurs whenever an OAuth Connection is deactivated.
    /// </summary>
    OAuthConnectionDeactivated,

    /// <summary>
    /// Occurs whenever a Card Push Transfer is created.
    /// </summary>
    CardPushTransferCreated,

    /// <summary>
    /// Occurs whenever a Card Push Transfer is updated.
    /// </summary>
    CardPushTransferUpdated,

    /// <summary>
    /// Occurs whenever a Card Validation is created.
    /// </summary>
    CardValidationCreated,

    /// <summary>
    /// Occurs whenever a Card Validation is updated.
    /// </summary>
    CardValidationUpdated,

    /// <summary>
    /// Occurs whenever a Pending Transaction is created.
    /// </summary>
    PendingTransactionCreated,

    /// <summary>
    /// Occurs whenever a Pending Transaction is updated.
    /// </summary>
    PendingTransactionUpdated,

    /// <summary>
    /// Occurs whenever a Physical Card is created.
    /// </summary>
    PhysicalCardCreated,

    /// <summary>
    /// Occurs whenever a Physical Card is updated.
    /// </summary>
    PhysicalCardUpdated,

    /// <summary>
    /// Occurs whenever a Physical Card Profile is created.
    /// </summary>
    PhysicalCardProfileCreated,

    /// <summary>
    /// Occurs whenever a Physical Card Profile is updated.
    /// </summary>
    PhysicalCardProfileUpdated,

    /// <summary>
    /// Occurs whenever a Physical Check is created.
    /// </summary>
    PhysicalCheckCreated,

    /// <summary>
    /// Occurs whenever a Physical Check is updated.
    /// </summary>
    PhysicalCheckUpdated,

    /// <summary>
    /// Occurs whenever a Program is created.
    /// </summary>
    ProgramCreated,

    /// <summary>
    /// Occurs whenever a Program is updated.
    /// </summary>
    ProgramUpdated,

    /// <summary>
    /// Occurs whenever a Proof of Authorization Request is created.
    /// </summary>
    ProofOfAuthorizationRequestCreated,

    /// <summary>
    /// Occurs whenever a Proof of Authorization Request is updated.
    /// </summary>
    ProofOfAuthorizationRequestUpdated,

    /// <summary>
    /// Occurs whenever a Real-Time Decision is created in response to a card authorization.
    /// </summary>
    RealTimeDecisionCardAuthorizationRequested,

    /// <summary>
    /// Occurs whenever a Real-Time Decision is created in response to a card balance inquiry.
    /// </summary>
    RealTimeDecisionCardBalanceInquiryRequested,

    /// <summary>
    /// Occurs whenever a Real-Time Decision is created in response to a digital
    /// wallet provisioning attempt.
    /// </summary>
    RealTimeDecisionDigitalWalletTokenRequested,

    /// <summary>
    /// Occurs whenever a Real-Time Decision is created in response to a digital
    /// wallet requiring two-factor authentication.
    /// </summary>
    RealTimeDecisionDigitalWalletAuthenticationRequested,

    /// <summary>
    /// Occurs whenever a Real-Time Decision is created in response to 3DS authentication.
    /// </summary>
    RealTimeDecisionCardAuthenticationRequested,

    /// <summary>
    /// Occurs whenever a Real-Time Decision is created in response to 3DS authentication challenges.
    /// </summary>
    RealTimeDecisionCardAuthenticationChallengeRequested,

    /// <summary>
    /// Occurs whenever a Real-Time Payments Transfer is created.
    /// </summary>
    RealTimePaymentsTransferCreated,

    /// <summary>
    /// Occurs whenever a Real-Time Payments Transfer is updated.
    /// </summary>
    RealTimePaymentsTransferUpdated,

    /// <summary>
    /// Occurs whenever a Real-Time Payments Request for Payment is created.
    /// </summary>
    RealTimePaymentsRequestForPaymentCreated,

    /// <summary>
    /// Occurs whenever a Real-Time Payments Request for Payment is updated.
    /// </summary>
    RealTimePaymentsRequestForPaymentUpdated,

    /// <summary>
    /// Occurs whenever a Swift Transfer is created.
    /// </summary>
    SwiftTransferCreated,

    /// <summary>
    /// Occurs whenever a Swift Transfer is updated.
    /// </summary>
    SwiftTransferUpdated,

    /// <summary>
    /// Occurs whenever a Transaction is created.
    /// </summary>
    TransactionCreated,

    /// <summary>
    /// Occurs whenever a Wire Drawdown Request is created.
    /// </summary>
    WireDrawdownRequestCreated,

    /// <summary>
    /// Occurs whenever a Wire Drawdown Request is updated.
    /// </summary>
    WireDrawdownRequestUpdated,

    /// <summary>
    /// Occurs whenever a Wire Transfer is created.
    /// </summary>
    WireTransferCreated,

    /// <summary>
    /// Occurs whenever a Wire Transfer is updated.
    /// </summary>
    WireTransferUpdated,
}

sealed class UnwrapWebhookEventCategoryConverter : JsonConverter<UnwrapWebhookEventCategory>
{
    public override UnwrapWebhookEventCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account.created" => UnwrapWebhookEventCategory.AccountCreated,
            "account.updated" => UnwrapWebhookEventCategory.AccountUpdated,
            "account_number.created" => UnwrapWebhookEventCategory.AccountNumberCreated,
            "account_number.updated" => UnwrapWebhookEventCategory.AccountNumberUpdated,
            "account_statement.created" => UnwrapWebhookEventCategory.AccountStatementCreated,
            "account_transfer.created" => UnwrapWebhookEventCategory.AccountTransferCreated,
            "account_transfer.updated" => UnwrapWebhookEventCategory.AccountTransferUpdated,
            "ach_prenotification.created" => UnwrapWebhookEventCategory.AchPrenotificationCreated,
            "ach_prenotification.updated" => UnwrapWebhookEventCategory.AchPrenotificationUpdated,
            "ach_transfer.created" => UnwrapWebhookEventCategory.AchTransferCreated,
            "ach_transfer.updated" => UnwrapWebhookEventCategory.AchTransferUpdated,
            "blockchain_address.created" => UnwrapWebhookEventCategory.BlockchainAddressCreated,
            "blockchain_address.updated" => UnwrapWebhookEventCategory.BlockchainAddressUpdated,
            "blockchain_offramp_transfer.created" =>
                UnwrapWebhookEventCategory.BlockchainOfframpTransferCreated,
            "blockchain_offramp_transfer.updated" =>
                UnwrapWebhookEventCategory.BlockchainOfframpTransferUpdated,
            "blockchain_onramp_transfer.created" =>
                UnwrapWebhookEventCategory.BlockchainOnrampTransferCreated,
            "blockchain_onramp_transfer.updated" =>
                UnwrapWebhookEventCategory.BlockchainOnrampTransferUpdated,
            "bookkeeping_account.created" => UnwrapWebhookEventCategory.BookkeepingAccountCreated,
            "bookkeeping_account.updated" => UnwrapWebhookEventCategory.BookkeepingAccountUpdated,
            "bookkeeping_entry_set.updated" =>
                UnwrapWebhookEventCategory.BookkeepingEntrySetUpdated,
            "card.created" => UnwrapWebhookEventCategory.CardCreated,
            "card.updated" => UnwrapWebhookEventCategory.CardUpdated,
            "card_payment.created" => UnwrapWebhookEventCategory.CardPaymentCreated,
            "card_payment.updated" => UnwrapWebhookEventCategory.CardPaymentUpdated,
            "card_purchase_supplement.created" =>
                UnwrapWebhookEventCategory.CardPurchaseSupplementCreated,
            "card_profile.created" => UnwrapWebhookEventCategory.CardProfileCreated,
            "card_profile.updated" => UnwrapWebhookEventCategory.CardProfileUpdated,
            "card_dispute.created" => UnwrapWebhookEventCategory.CardDisputeCreated,
            "card_dispute.updated" => UnwrapWebhookEventCategory.CardDisputeUpdated,
            "check_deposit.created" => UnwrapWebhookEventCategory.CheckDepositCreated,
            "check_deposit.updated" => UnwrapWebhookEventCategory.CheckDepositUpdated,
            "check_transfer.created" => UnwrapWebhookEventCategory.CheckTransferCreated,
            "check_transfer.updated" => UnwrapWebhookEventCategory.CheckTransferUpdated,
            "declined_transaction.created" => UnwrapWebhookEventCategory.DeclinedTransactionCreated,
            "digital_card_profile.created" => UnwrapWebhookEventCategory.DigitalCardProfileCreated,
            "digital_card_profile.updated" => UnwrapWebhookEventCategory.DigitalCardProfileUpdated,
            "digital_wallet_token.created" => UnwrapWebhookEventCategory.DigitalWalletTokenCreated,
            "digital_wallet_token.updated" => UnwrapWebhookEventCategory.DigitalWalletTokenUpdated,
            "document.created" => UnwrapWebhookEventCategory.DocumentCreated,
            "entity.created" => UnwrapWebhookEventCategory.EntityCreated,
            "entity.updated" => UnwrapWebhookEventCategory.EntityUpdated,
            "event_subscription.created" => UnwrapWebhookEventCategory.EventSubscriptionCreated,
            "event_subscription.updated" => UnwrapWebhookEventCategory.EventSubscriptionUpdated,
            "export.created" => UnwrapWebhookEventCategory.ExportCreated,
            "export.updated" => UnwrapWebhookEventCategory.ExportUpdated,
            "external_account.created" => UnwrapWebhookEventCategory.ExternalAccountCreated,
            "external_account.updated" => UnwrapWebhookEventCategory.ExternalAccountUpdated,
            "fednow_transfer.created" => UnwrapWebhookEventCategory.FednowTransferCreated,
            "fednow_transfer.updated" => UnwrapWebhookEventCategory.FednowTransferUpdated,
            "file.created" => UnwrapWebhookEventCategory.FileCreated,
            "group.updated" => UnwrapWebhookEventCategory.GroupUpdated,
            "group.heartbeat" => UnwrapWebhookEventCategory.GroupHeartbeat,
            "inbound_ach_transfer.created" => UnwrapWebhookEventCategory.InboundAchTransferCreated,
            "inbound_ach_transfer.updated" => UnwrapWebhookEventCategory.InboundAchTransferUpdated,
            "inbound_ach_transfer_return.created" =>
                UnwrapWebhookEventCategory.InboundAchTransferReturnCreated,
            "inbound_ach_transfer_return.updated" =>
                UnwrapWebhookEventCategory.InboundAchTransferReturnUpdated,
            "inbound_check_deposit.created" =>
                UnwrapWebhookEventCategory.InboundCheckDepositCreated,
            "inbound_check_deposit.updated" =>
                UnwrapWebhookEventCategory.InboundCheckDepositUpdated,
            "inbound_fednow_transfer.created" =>
                UnwrapWebhookEventCategory.InboundFednowTransferCreated,
            "inbound_fednow_transfer.updated" =>
                UnwrapWebhookEventCategory.InboundFednowTransferUpdated,
            "inbound_mail_item.created" => UnwrapWebhookEventCategory.InboundMailItemCreated,
            "inbound_mail_item.updated" => UnwrapWebhookEventCategory.InboundMailItemUpdated,
            "inbound_real_time_payments_transfer.created" =>
                UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferCreated,
            "inbound_real_time_payments_transfer.updated" =>
                UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferUpdated,
            "inbound_wire_drawdown_request.created" =>
                UnwrapWebhookEventCategory.InboundWireDrawdownRequestCreated,
            "inbound_wire_transfer.created" =>
                UnwrapWebhookEventCategory.InboundWireTransferCreated,
            "inbound_wire_transfer.updated" =>
                UnwrapWebhookEventCategory.InboundWireTransferUpdated,
            "intrafi_account_enrollment.created" =>
                UnwrapWebhookEventCategory.IntrafiAccountEnrollmentCreated,
            "intrafi_account_enrollment.updated" =>
                UnwrapWebhookEventCategory.IntrafiAccountEnrollmentUpdated,
            "intrafi_exclusion.created" => UnwrapWebhookEventCategory.IntrafiExclusionCreated,
            "intrafi_exclusion.updated" => UnwrapWebhookEventCategory.IntrafiExclusionUpdated,
            "legacy_card_dispute.created" => UnwrapWebhookEventCategory.LegacyCardDisputeCreated,
            "legacy_card_dispute.updated" => UnwrapWebhookEventCategory.LegacyCardDisputeUpdated,
            "lockbox.created" => UnwrapWebhookEventCategory.LockboxCreated,
            "lockbox.updated" => UnwrapWebhookEventCategory.LockboxUpdated,
            "oauth_connection.created" => UnwrapWebhookEventCategory.OAuthConnectionCreated,
            "oauth_connection.deactivated" => UnwrapWebhookEventCategory.OAuthConnectionDeactivated,
            "card_push_transfer.created" => UnwrapWebhookEventCategory.CardPushTransferCreated,
            "card_push_transfer.updated" => UnwrapWebhookEventCategory.CardPushTransferUpdated,
            "card_validation.created" => UnwrapWebhookEventCategory.CardValidationCreated,
            "card_validation.updated" => UnwrapWebhookEventCategory.CardValidationUpdated,
            "pending_transaction.created" => UnwrapWebhookEventCategory.PendingTransactionCreated,
            "pending_transaction.updated" => UnwrapWebhookEventCategory.PendingTransactionUpdated,
            "physical_card.created" => UnwrapWebhookEventCategory.PhysicalCardCreated,
            "physical_card.updated" => UnwrapWebhookEventCategory.PhysicalCardUpdated,
            "physical_card_profile.created" =>
                UnwrapWebhookEventCategory.PhysicalCardProfileCreated,
            "physical_card_profile.updated" =>
                UnwrapWebhookEventCategory.PhysicalCardProfileUpdated,
            "physical_check.created" => UnwrapWebhookEventCategory.PhysicalCheckCreated,
            "physical_check.updated" => UnwrapWebhookEventCategory.PhysicalCheckUpdated,
            "program.created" => UnwrapWebhookEventCategory.ProgramCreated,
            "program.updated" => UnwrapWebhookEventCategory.ProgramUpdated,
            "proof_of_authorization_request.created" =>
                UnwrapWebhookEventCategory.ProofOfAuthorizationRequestCreated,
            "proof_of_authorization_request.updated" =>
                UnwrapWebhookEventCategory.ProofOfAuthorizationRequestUpdated,
            "real_time_decision.card_authorization_requested" =>
                UnwrapWebhookEventCategory.RealTimeDecisionCardAuthorizationRequested,
            "real_time_decision.card_balance_inquiry_requested" =>
                UnwrapWebhookEventCategory.RealTimeDecisionCardBalanceInquiryRequested,
            "real_time_decision.digital_wallet_token_requested" =>
                UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletTokenRequested,
            "real_time_decision.digital_wallet_authentication_requested" =>
                UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested,
            "real_time_decision.card_authentication_requested" =>
                UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationRequested,
            "real_time_decision.card_authentication_challenge_requested" =>
                UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested,
            "real_time_payments_transfer.created" =>
                UnwrapWebhookEventCategory.RealTimePaymentsTransferCreated,
            "real_time_payments_transfer.updated" =>
                UnwrapWebhookEventCategory.RealTimePaymentsTransferUpdated,
            "real_time_payments_request_for_payment.created" =>
                UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentCreated,
            "real_time_payments_request_for_payment.updated" =>
                UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentUpdated,
            "swift_transfer.created" => UnwrapWebhookEventCategory.SwiftTransferCreated,
            "swift_transfer.updated" => UnwrapWebhookEventCategory.SwiftTransferUpdated,
            "transaction.created" => UnwrapWebhookEventCategory.TransactionCreated,
            "wire_drawdown_request.created" =>
                UnwrapWebhookEventCategory.WireDrawdownRequestCreated,
            "wire_drawdown_request.updated" =>
                UnwrapWebhookEventCategory.WireDrawdownRequestUpdated,
            "wire_transfer.created" => UnwrapWebhookEventCategory.WireTransferCreated,
            "wire_transfer.updated" => UnwrapWebhookEventCategory.WireTransferUpdated,
            _ => (UnwrapWebhookEventCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEventCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnwrapWebhookEventCategory.AccountCreated => "account.created",
                UnwrapWebhookEventCategory.AccountUpdated => "account.updated",
                UnwrapWebhookEventCategory.AccountNumberCreated => "account_number.created",
                UnwrapWebhookEventCategory.AccountNumberUpdated => "account_number.updated",
                UnwrapWebhookEventCategory.AccountStatementCreated => "account_statement.created",
                UnwrapWebhookEventCategory.AccountTransferCreated => "account_transfer.created",
                UnwrapWebhookEventCategory.AccountTransferUpdated => "account_transfer.updated",
                UnwrapWebhookEventCategory.AchPrenotificationCreated =>
                    "ach_prenotification.created",
                UnwrapWebhookEventCategory.AchPrenotificationUpdated =>
                    "ach_prenotification.updated",
                UnwrapWebhookEventCategory.AchTransferCreated => "ach_transfer.created",
                UnwrapWebhookEventCategory.AchTransferUpdated => "ach_transfer.updated",
                UnwrapWebhookEventCategory.BlockchainAddressCreated => "blockchain_address.created",
                UnwrapWebhookEventCategory.BlockchainAddressUpdated => "blockchain_address.updated",
                UnwrapWebhookEventCategory.BlockchainOfframpTransferCreated =>
                    "blockchain_offramp_transfer.created",
                UnwrapWebhookEventCategory.BlockchainOfframpTransferUpdated =>
                    "blockchain_offramp_transfer.updated",
                UnwrapWebhookEventCategory.BlockchainOnrampTransferCreated =>
                    "blockchain_onramp_transfer.created",
                UnwrapWebhookEventCategory.BlockchainOnrampTransferUpdated =>
                    "blockchain_onramp_transfer.updated",
                UnwrapWebhookEventCategory.BookkeepingAccountCreated =>
                    "bookkeeping_account.created",
                UnwrapWebhookEventCategory.BookkeepingAccountUpdated =>
                    "bookkeeping_account.updated",
                UnwrapWebhookEventCategory.BookkeepingEntrySetUpdated =>
                    "bookkeeping_entry_set.updated",
                UnwrapWebhookEventCategory.CardCreated => "card.created",
                UnwrapWebhookEventCategory.CardUpdated => "card.updated",
                UnwrapWebhookEventCategory.CardPaymentCreated => "card_payment.created",
                UnwrapWebhookEventCategory.CardPaymentUpdated => "card_payment.updated",
                UnwrapWebhookEventCategory.CardPurchaseSupplementCreated =>
                    "card_purchase_supplement.created",
                UnwrapWebhookEventCategory.CardProfileCreated => "card_profile.created",
                UnwrapWebhookEventCategory.CardProfileUpdated => "card_profile.updated",
                UnwrapWebhookEventCategory.CardDisputeCreated => "card_dispute.created",
                UnwrapWebhookEventCategory.CardDisputeUpdated => "card_dispute.updated",
                UnwrapWebhookEventCategory.CheckDepositCreated => "check_deposit.created",
                UnwrapWebhookEventCategory.CheckDepositUpdated => "check_deposit.updated",
                UnwrapWebhookEventCategory.CheckTransferCreated => "check_transfer.created",
                UnwrapWebhookEventCategory.CheckTransferUpdated => "check_transfer.updated",
                UnwrapWebhookEventCategory.DeclinedTransactionCreated =>
                    "declined_transaction.created",
                UnwrapWebhookEventCategory.DigitalCardProfileCreated =>
                    "digital_card_profile.created",
                UnwrapWebhookEventCategory.DigitalCardProfileUpdated =>
                    "digital_card_profile.updated",
                UnwrapWebhookEventCategory.DigitalWalletTokenCreated =>
                    "digital_wallet_token.created",
                UnwrapWebhookEventCategory.DigitalWalletTokenUpdated =>
                    "digital_wallet_token.updated",
                UnwrapWebhookEventCategory.DocumentCreated => "document.created",
                UnwrapWebhookEventCategory.EntityCreated => "entity.created",
                UnwrapWebhookEventCategory.EntityUpdated => "entity.updated",
                UnwrapWebhookEventCategory.EventSubscriptionCreated => "event_subscription.created",
                UnwrapWebhookEventCategory.EventSubscriptionUpdated => "event_subscription.updated",
                UnwrapWebhookEventCategory.ExportCreated => "export.created",
                UnwrapWebhookEventCategory.ExportUpdated => "export.updated",
                UnwrapWebhookEventCategory.ExternalAccountCreated => "external_account.created",
                UnwrapWebhookEventCategory.ExternalAccountUpdated => "external_account.updated",
                UnwrapWebhookEventCategory.FednowTransferCreated => "fednow_transfer.created",
                UnwrapWebhookEventCategory.FednowTransferUpdated => "fednow_transfer.updated",
                UnwrapWebhookEventCategory.FileCreated => "file.created",
                UnwrapWebhookEventCategory.GroupUpdated => "group.updated",
                UnwrapWebhookEventCategory.GroupHeartbeat => "group.heartbeat",
                UnwrapWebhookEventCategory.InboundAchTransferCreated =>
                    "inbound_ach_transfer.created",
                UnwrapWebhookEventCategory.InboundAchTransferUpdated =>
                    "inbound_ach_transfer.updated",
                UnwrapWebhookEventCategory.InboundAchTransferReturnCreated =>
                    "inbound_ach_transfer_return.created",
                UnwrapWebhookEventCategory.InboundAchTransferReturnUpdated =>
                    "inbound_ach_transfer_return.updated",
                UnwrapWebhookEventCategory.InboundCheckDepositCreated =>
                    "inbound_check_deposit.created",
                UnwrapWebhookEventCategory.InboundCheckDepositUpdated =>
                    "inbound_check_deposit.updated",
                UnwrapWebhookEventCategory.InboundFednowTransferCreated =>
                    "inbound_fednow_transfer.created",
                UnwrapWebhookEventCategory.InboundFednowTransferUpdated =>
                    "inbound_fednow_transfer.updated",
                UnwrapWebhookEventCategory.InboundMailItemCreated => "inbound_mail_item.created",
                UnwrapWebhookEventCategory.InboundMailItemUpdated => "inbound_mail_item.updated",
                UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferCreated =>
                    "inbound_real_time_payments_transfer.created",
                UnwrapWebhookEventCategory.InboundRealTimePaymentsTransferUpdated =>
                    "inbound_real_time_payments_transfer.updated",
                UnwrapWebhookEventCategory.InboundWireDrawdownRequestCreated =>
                    "inbound_wire_drawdown_request.created",
                UnwrapWebhookEventCategory.InboundWireTransferCreated =>
                    "inbound_wire_transfer.created",
                UnwrapWebhookEventCategory.InboundWireTransferUpdated =>
                    "inbound_wire_transfer.updated",
                UnwrapWebhookEventCategory.IntrafiAccountEnrollmentCreated =>
                    "intrafi_account_enrollment.created",
                UnwrapWebhookEventCategory.IntrafiAccountEnrollmentUpdated =>
                    "intrafi_account_enrollment.updated",
                UnwrapWebhookEventCategory.IntrafiExclusionCreated => "intrafi_exclusion.created",
                UnwrapWebhookEventCategory.IntrafiExclusionUpdated => "intrafi_exclusion.updated",
                UnwrapWebhookEventCategory.LegacyCardDisputeCreated =>
                    "legacy_card_dispute.created",
                UnwrapWebhookEventCategory.LegacyCardDisputeUpdated =>
                    "legacy_card_dispute.updated",
                UnwrapWebhookEventCategory.LockboxCreated => "lockbox.created",
                UnwrapWebhookEventCategory.LockboxUpdated => "lockbox.updated",
                UnwrapWebhookEventCategory.OAuthConnectionCreated => "oauth_connection.created",
                UnwrapWebhookEventCategory.OAuthConnectionDeactivated =>
                    "oauth_connection.deactivated",
                UnwrapWebhookEventCategory.CardPushTransferCreated => "card_push_transfer.created",
                UnwrapWebhookEventCategory.CardPushTransferUpdated => "card_push_transfer.updated",
                UnwrapWebhookEventCategory.CardValidationCreated => "card_validation.created",
                UnwrapWebhookEventCategory.CardValidationUpdated => "card_validation.updated",
                UnwrapWebhookEventCategory.PendingTransactionCreated =>
                    "pending_transaction.created",
                UnwrapWebhookEventCategory.PendingTransactionUpdated =>
                    "pending_transaction.updated",
                UnwrapWebhookEventCategory.PhysicalCardCreated => "physical_card.created",
                UnwrapWebhookEventCategory.PhysicalCardUpdated => "physical_card.updated",
                UnwrapWebhookEventCategory.PhysicalCardProfileCreated =>
                    "physical_card_profile.created",
                UnwrapWebhookEventCategory.PhysicalCardProfileUpdated =>
                    "physical_card_profile.updated",
                UnwrapWebhookEventCategory.PhysicalCheckCreated => "physical_check.created",
                UnwrapWebhookEventCategory.PhysicalCheckUpdated => "physical_check.updated",
                UnwrapWebhookEventCategory.ProgramCreated => "program.created",
                UnwrapWebhookEventCategory.ProgramUpdated => "program.updated",
                UnwrapWebhookEventCategory.ProofOfAuthorizationRequestCreated =>
                    "proof_of_authorization_request.created",
                UnwrapWebhookEventCategory.ProofOfAuthorizationRequestUpdated =>
                    "proof_of_authorization_request.updated",
                UnwrapWebhookEventCategory.RealTimeDecisionCardAuthorizationRequested =>
                    "real_time_decision.card_authorization_requested",
                UnwrapWebhookEventCategory.RealTimeDecisionCardBalanceInquiryRequested =>
                    "real_time_decision.card_balance_inquiry_requested",
                UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletTokenRequested =>
                    "real_time_decision.digital_wallet_token_requested",
                UnwrapWebhookEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested =>
                    "real_time_decision.digital_wallet_authentication_requested",
                UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationRequested =>
                    "real_time_decision.card_authentication_requested",
                UnwrapWebhookEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested =>
                    "real_time_decision.card_authentication_challenge_requested",
                UnwrapWebhookEventCategory.RealTimePaymentsTransferCreated =>
                    "real_time_payments_transfer.created",
                UnwrapWebhookEventCategory.RealTimePaymentsTransferUpdated =>
                    "real_time_payments_transfer.updated",
                UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentCreated =>
                    "real_time_payments_request_for_payment.created",
                UnwrapWebhookEventCategory.RealTimePaymentsRequestForPaymentUpdated =>
                    "real_time_payments_request_for_payment.updated",
                UnwrapWebhookEventCategory.SwiftTransferCreated => "swift_transfer.created",
                UnwrapWebhookEventCategory.SwiftTransferUpdated => "swift_transfer.updated",
                UnwrapWebhookEventCategory.TransactionCreated => "transaction.created",
                UnwrapWebhookEventCategory.WireDrawdownRequestCreated =>
                    "wire_drawdown_request.created",
                UnwrapWebhookEventCategory.WireDrawdownRequestUpdated =>
                    "wire_drawdown_request.updated",
                UnwrapWebhookEventCategory.WireTransferCreated => "wire_transfer.created",
                UnwrapWebhookEventCategory.WireTransferUpdated => "wire_transfer.updated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `event`.
/// </summary>
[JsonConverter(typeof(UnwrapWebhookEventTypeConverter))]
public enum UnwrapWebhookEventType
{
    Event,
}

sealed class UnwrapWebhookEventTypeConverter : JsonConverter<UnwrapWebhookEventType>
{
    public override UnwrapWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event" => UnwrapWebhookEventType.Event,
            _ => (UnwrapWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnwrapWebhookEventType.Event => "event",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
