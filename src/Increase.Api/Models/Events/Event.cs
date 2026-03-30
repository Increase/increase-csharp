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
[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
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
    public required ApiEnum<string, EventCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventCategory>>("category");
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
    public required ApiEnum<string, global::Increase.Api.Models.Events.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Events.Type>
            >("type");
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

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the Event. We may add additional possible values for this enum
/// over time; your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(EventCategoryConverter))]
public enum EventCategory
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
    /// Occurs whenever a Lockbox Address is created.
    /// </summary>
    LockboxAddressCreated,

    /// <summary>
    /// Occurs whenever a Lockbox Address is updated.
    /// </summary>
    LockboxAddressUpdated,

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

sealed class EventCategoryConverter : JsonConverter<EventCategory>
{
    public override EventCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account.created" => EventCategory.AccountCreated,
            "account.updated" => EventCategory.AccountUpdated,
            "account_number.created" => EventCategory.AccountNumberCreated,
            "account_number.updated" => EventCategory.AccountNumberUpdated,
            "account_statement.created" => EventCategory.AccountStatementCreated,
            "account_transfer.created" => EventCategory.AccountTransferCreated,
            "account_transfer.updated" => EventCategory.AccountTransferUpdated,
            "ach_prenotification.created" => EventCategory.AchPrenotificationCreated,
            "ach_prenotification.updated" => EventCategory.AchPrenotificationUpdated,
            "ach_transfer.created" => EventCategory.AchTransferCreated,
            "ach_transfer.updated" => EventCategory.AchTransferUpdated,
            "blockchain_address.created" => EventCategory.BlockchainAddressCreated,
            "blockchain_address.updated" => EventCategory.BlockchainAddressUpdated,
            "blockchain_offramp_transfer.created" => EventCategory.BlockchainOfframpTransferCreated,
            "blockchain_offramp_transfer.updated" => EventCategory.BlockchainOfframpTransferUpdated,
            "blockchain_onramp_transfer.created" => EventCategory.BlockchainOnrampTransferCreated,
            "blockchain_onramp_transfer.updated" => EventCategory.BlockchainOnrampTransferUpdated,
            "bookkeeping_account.created" => EventCategory.BookkeepingAccountCreated,
            "bookkeeping_account.updated" => EventCategory.BookkeepingAccountUpdated,
            "bookkeeping_entry_set.updated" => EventCategory.BookkeepingEntrySetUpdated,
            "card.created" => EventCategory.CardCreated,
            "card.updated" => EventCategory.CardUpdated,
            "card_payment.created" => EventCategory.CardPaymentCreated,
            "card_payment.updated" => EventCategory.CardPaymentUpdated,
            "card_profile.created" => EventCategory.CardProfileCreated,
            "card_profile.updated" => EventCategory.CardProfileUpdated,
            "card_dispute.created" => EventCategory.CardDisputeCreated,
            "card_dispute.updated" => EventCategory.CardDisputeUpdated,
            "check_deposit.created" => EventCategory.CheckDepositCreated,
            "check_deposit.updated" => EventCategory.CheckDepositUpdated,
            "check_transfer.created" => EventCategory.CheckTransferCreated,
            "check_transfer.updated" => EventCategory.CheckTransferUpdated,
            "declined_transaction.created" => EventCategory.DeclinedTransactionCreated,
            "digital_card_profile.created" => EventCategory.DigitalCardProfileCreated,
            "digital_card_profile.updated" => EventCategory.DigitalCardProfileUpdated,
            "digital_wallet_token.created" => EventCategory.DigitalWalletTokenCreated,
            "digital_wallet_token.updated" => EventCategory.DigitalWalletTokenUpdated,
            "document.created" => EventCategory.DocumentCreated,
            "entity.created" => EventCategory.EntityCreated,
            "entity.updated" => EventCategory.EntityUpdated,
            "event_subscription.created" => EventCategory.EventSubscriptionCreated,
            "event_subscription.updated" => EventCategory.EventSubscriptionUpdated,
            "export.created" => EventCategory.ExportCreated,
            "export.updated" => EventCategory.ExportUpdated,
            "external_account.created" => EventCategory.ExternalAccountCreated,
            "external_account.updated" => EventCategory.ExternalAccountUpdated,
            "fednow_transfer.created" => EventCategory.FednowTransferCreated,
            "fednow_transfer.updated" => EventCategory.FednowTransferUpdated,
            "file.created" => EventCategory.FileCreated,
            "group.updated" => EventCategory.GroupUpdated,
            "group.heartbeat" => EventCategory.GroupHeartbeat,
            "inbound_ach_transfer.created" => EventCategory.InboundAchTransferCreated,
            "inbound_ach_transfer.updated" => EventCategory.InboundAchTransferUpdated,
            "inbound_ach_transfer_return.created" => EventCategory.InboundAchTransferReturnCreated,
            "inbound_ach_transfer_return.updated" => EventCategory.InboundAchTransferReturnUpdated,
            "inbound_check_deposit.created" => EventCategory.InboundCheckDepositCreated,
            "inbound_check_deposit.updated" => EventCategory.InboundCheckDepositUpdated,
            "inbound_fednow_transfer.created" => EventCategory.InboundFednowTransferCreated,
            "inbound_fednow_transfer.updated" => EventCategory.InboundFednowTransferUpdated,
            "inbound_mail_item.created" => EventCategory.InboundMailItemCreated,
            "inbound_mail_item.updated" => EventCategory.InboundMailItemUpdated,
            "inbound_real_time_payments_transfer.created" =>
                EventCategory.InboundRealTimePaymentsTransferCreated,
            "inbound_real_time_payments_transfer.updated" =>
                EventCategory.InboundRealTimePaymentsTransferUpdated,
            "inbound_wire_drawdown_request.created" =>
                EventCategory.InboundWireDrawdownRequestCreated,
            "inbound_wire_transfer.created" => EventCategory.InboundWireTransferCreated,
            "inbound_wire_transfer.updated" => EventCategory.InboundWireTransferUpdated,
            "intrafi_account_enrollment.created" => EventCategory.IntrafiAccountEnrollmentCreated,
            "intrafi_account_enrollment.updated" => EventCategory.IntrafiAccountEnrollmentUpdated,
            "intrafi_exclusion.created" => EventCategory.IntrafiExclusionCreated,
            "intrafi_exclusion.updated" => EventCategory.IntrafiExclusionUpdated,
            "legacy_card_dispute.created" => EventCategory.LegacyCardDisputeCreated,
            "legacy_card_dispute.updated" => EventCategory.LegacyCardDisputeUpdated,
            "lockbox_address.created" => EventCategory.LockboxAddressCreated,
            "lockbox_address.updated" => EventCategory.LockboxAddressUpdated,
            "lockbox.created" => EventCategory.LockboxCreated,
            "lockbox.updated" => EventCategory.LockboxUpdated,
            "oauth_connection.created" => EventCategory.OAuthConnectionCreated,
            "oauth_connection.deactivated" => EventCategory.OAuthConnectionDeactivated,
            "card_push_transfer.created" => EventCategory.CardPushTransferCreated,
            "card_push_transfer.updated" => EventCategory.CardPushTransferUpdated,
            "card_validation.created" => EventCategory.CardValidationCreated,
            "card_validation.updated" => EventCategory.CardValidationUpdated,
            "pending_transaction.created" => EventCategory.PendingTransactionCreated,
            "pending_transaction.updated" => EventCategory.PendingTransactionUpdated,
            "physical_card.created" => EventCategory.PhysicalCardCreated,
            "physical_card.updated" => EventCategory.PhysicalCardUpdated,
            "physical_card_profile.created" => EventCategory.PhysicalCardProfileCreated,
            "physical_card_profile.updated" => EventCategory.PhysicalCardProfileUpdated,
            "physical_check.created" => EventCategory.PhysicalCheckCreated,
            "physical_check.updated" => EventCategory.PhysicalCheckUpdated,
            "program.created" => EventCategory.ProgramCreated,
            "program.updated" => EventCategory.ProgramUpdated,
            "proof_of_authorization_request.created" =>
                EventCategory.ProofOfAuthorizationRequestCreated,
            "proof_of_authorization_request.updated" =>
                EventCategory.ProofOfAuthorizationRequestUpdated,
            "real_time_decision.card_authorization_requested" =>
                EventCategory.RealTimeDecisionCardAuthorizationRequested,
            "real_time_decision.card_balance_inquiry_requested" =>
                EventCategory.RealTimeDecisionCardBalanceInquiryRequested,
            "real_time_decision.digital_wallet_token_requested" =>
                EventCategory.RealTimeDecisionDigitalWalletTokenRequested,
            "real_time_decision.digital_wallet_authentication_requested" =>
                EventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested,
            "real_time_decision.card_authentication_requested" =>
                EventCategory.RealTimeDecisionCardAuthenticationRequested,
            "real_time_decision.card_authentication_challenge_requested" =>
                EventCategory.RealTimeDecisionCardAuthenticationChallengeRequested,
            "real_time_payments_transfer.created" => EventCategory.RealTimePaymentsTransferCreated,
            "real_time_payments_transfer.updated" => EventCategory.RealTimePaymentsTransferUpdated,
            "real_time_payments_request_for_payment.created" =>
                EventCategory.RealTimePaymentsRequestForPaymentCreated,
            "real_time_payments_request_for_payment.updated" =>
                EventCategory.RealTimePaymentsRequestForPaymentUpdated,
            "swift_transfer.created" => EventCategory.SwiftTransferCreated,
            "swift_transfer.updated" => EventCategory.SwiftTransferUpdated,
            "transaction.created" => EventCategory.TransactionCreated,
            "wire_drawdown_request.created" => EventCategory.WireDrawdownRequestCreated,
            "wire_drawdown_request.updated" => EventCategory.WireDrawdownRequestUpdated,
            "wire_transfer.created" => EventCategory.WireTransferCreated,
            "wire_transfer.updated" => EventCategory.WireTransferUpdated,
            _ => (EventCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventCategory.AccountCreated => "account.created",
                EventCategory.AccountUpdated => "account.updated",
                EventCategory.AccountNumberCreated => "account_number.created",
                EventCategory.AccountNumberUpdated => "account_number.updated",
                EventCategory.AccountStatementCreated => "account_statement.created",
                EventCategory.AccountTransferCreated => "account_transfer.created",
                EventCategory.AccountTransferUpdated => "account_transfer.updated",
                EventCategory.AchPrenotificationCreated => "ach_prenotification.created",
                EventCategory.AchPrenotificationUpdated => "ach_prenotification.updated",
                EventCategory.AchTransferCreated => "ach_transfer.created",
                EventCategory.AchTransferUpdated => "ach_transfer.updated",
                EventCategory.BlockchainAddressCreated => "blockchain_address.created",
                EventCategory.BlockchainAddressUpdated => "blockchain_address.updated",
                EventCategory.BlockchainOfframpTransferCreated =>
                    "blockchain_offramp_transfer.created",
                EventCategory.BlockchainOfframpTransferUpdated =>
                    "blockchain_offramp_transfer.updated",
                EventCategory.BlockchainOnrampTransferCreated =>
                    "blockchain_onramp_transfer.created",
                EventCategory.BlockchainOnrampTransferUpdated =>
                    "blockchain_onramp_transfer.updated",
                EventCategory.BookkeepingAccountCreated => "bookkeeping_account.created",
                EventCategory.BookkeepingAccountUpdated => "bookkeeping_account.updated",
                EventCategory.BookkeepingEntrySetUpdated => "bookkeeping_entry_set.updated",
                EventCategory.CardCreated => "card.created",
                EventCategory.CardUpdated => "card.updated",
                EventCategory.CardPaymentCreated => "card_payment.created",
                EventCategory.CardPaymentUpdated => "card_payment.updated",
                EventCategory.CardProfileCreated => "card_profile.created",
                EventCategory.CardProfileUpdated => "card_profile.updated",
                EventCategory.CardDisputeCreated => "card_dispute.created",
                EventCategory.CardDisputeUpdated => "card_dispute.updated",
                EventCategory.CheckDepositCreated => "check_deposit.created",
                EventCategory.CheckDepositUpdated => "check_deposit.updated",
                EventCategory.CheckTransferCreated => "check_transfer.created",
                EventCategory.CheckTransferUpdated => "check_transfer.updated",
                EventCategory.DeclinedTransactionCreated => "declined_transaction.created",
                EventCategory.DigitalCardProfileCreated => "digital_card_profile.created",
                EventCategory.DigitalCardProfileUpdated => "digital_card_profile.updated",
                EventCategory.DigitalWalletTokenCreated => "digital_wallet_token.created",
                EventCategory.DigitalWalletTokenUpdated => "digital_wallet_token.updated",
                EventCategory.DocumentCreated => "document.created",
                EventCategory.EntityCreated => "entity.created",
                EventCategory.EntityUpdated => "entity.updated",
                EventCategory.EventSubscriptionCreated => "event_subscription.created",
                EventCategory.EventSubscriptionUpdated => "event_subscription.updated",
                EventCategory.ExportCreated => "export.created",
                EventCategory.ExportUpdated => "export.updated",
                EventCategory.ExternalAccountCreated => "external_account.created",
                EventCategory.ExternalAccountUpdated => "external_account.updated",
                EventCategory.FednowTransferCreated => "fednow_transfer.created",
                EventCategory.FednowTransferUpdated => "fednow_transfer.updated",
                EventCategory.FileCreated => "file.created",
                EventCategory.GroupUpdated => "group.updated",
                EventCategory.GroupHeartbeat => "group.heartbeat",
                EventCategory.InboundAchTransferCreated => "inbound_ach_transfer.created",
                EventCategory.InboundAchTransferUpdated => "inbound_ach_transfer.updated",
                EventCategory.InboundAchTransferReturnCreated =>
                    "inbound_ach_transfer_return.created",
                EventCategory.InboundAchTransferReturnUpdated =>
                    "inbound_ach_transfer_return.updated",
                EventCategory.InboundCheckDepositCreated => "inbound_check_deposit.created",
                EventCategory.InboundCheckDepositUpdated => "inbound_check_deposit.updated",
                EventCategory.InboundFednowTransferCreated => "inbound_fednow_transfer.created",
                EventCategory.InboundFednowTransferUpdated => "inbound_fednow_transfer.updated",
                EventCategory.InboundMailItemCreated => "inbound_mail_item.created",
                EventCategory.InboundMailItemUpdated => "inbound_mail_item.updated",
                EventCategory.InboundRealTimePaymentsTransferCreated =>
                    "inbound_real_time_payments_transfer.created",
                EventCategory.InboundRealTimePaymentsTransferUpdated =>
                    "inbound_real_time_payments_transfer.updated",
                EventCategory.InboundWireDrawdownRequestCreated =>
                    "inbound_wire_drawdown_request.created",
                EventCategory.InboundWireTransferCreated => "inbound_wire_transfer.created",
                EventCategory.InboundWireTransferUpdated => "inbound_wire_transfer.updated",
                EventCategory.IntrafiAccountEnrollmentCreated =>
                    "intrafi_account_enrollment.created",
                EventCategory.IntrafiAccountEnrollmentUpdated =>
                    "intrafi_account_enrollment.updated",
                EventCategory.IntrafiExclusionCreated => "intrafi_exclusion.created",
                EventCategory.IntrafiExclusionUpdated => "intrafi_exclusion.updated",
                EventCategory.LegacyCardDisputeCreated => "legacy_card_dispute.created",
                EventCategory.LegacyCardDisputeUpdated => "legacy_card_dispute.updated",
                EventCategory.LockboxAddressCreated => "lockbox_address.created",
                EventCategory.LockboxAddressUpdated => "lockbox_address.updated",
                EventCategory.LockboxCreated => "lockbox.created",
                EventCategory.LockboxUpdated => "lockbox.updated",
                EventCategory.OAuthConnectionCreated => "oauth_connection.created",
                EventCategory.OAuthConnectionDeactivated => "oauth_connection.deactivated",
                EventCategory.CardPushTransferCreated => "card_push_transfer.created",
                EventCategory.CardPushTransferUpdated => "card_push_transfer.updated",
                EventCategory.CardValidationCreated => "card_validation.created",
                EventCategory.CardValidationUpdated => "card_validation.updated",
                EventCategory.PendingTransactionCreated => "pending_transaction.created",
                EventCategory.PendingTransactionUpdated => "pending_transaction.updated",
                EventCategory.PhysicalCardCreated => "physical_card.created",
                EventCategory.PhysicalCardUpdated => "physical_card.updated",
                EventCategory.PhysicalCardProfileCreated => "physical_card_profile.created",
                EventCategory.PhysicalCardProfileUpdated => "physical_card_profile.updated",
                EventCategory.PhysicalCheckCreated => "physical_check.created",
                EventCategory.PhysicalCheckUpdated => "physical_check.updated",
                EventCategory.ProgramCreated => "program.created",
                EventCategory.ProgramUpdated => "program.updated",
                EventCategory.ProofOfAuthorizationRequestCreated =>
                    "proof_of_authorization_request.created",
                EventCategory.ProofOfAuthorizationRequestUpdated =>
                    "proof_of_authorization_request.updated",
                EventCategory.RealTimeDecisionCardAuthorizationRequested =>
                    "real_time_decision.card_authorization_requested",
                EventCategory.RealTimeDecisionCardBalanceInquiryRequested =>
                    "real_time_decision.card_balance_inquiry_requested",
                EventCategory.RealTimeDecisionDigitalWalletTokenRequested =>
                    "real_time_decision.digital_wallet_token_requested",
                EventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested =>
                    "real_time_decision.digital_wallet_authentication_requested",
                EventCategory.RealTimeDecisionCardAuthenticationRequested =>
                    "real_time_decision.card_authentication_requested",
                EventCategory.RealTimeDecisionCardAuthenticationChallengeRequested =>
                    "real_time_decision.card_authentication_challenge_requested",
                EventCategory.RealTimePaymentsTransferCreated =>
                    "real_time_payments_transfer.created",
                EventCategory.RealTimePaymentsTransferUpdated =>
                    "real_time_payments_transfer.updated",
                EventCategory.RealTimePaymentsRequestForPaymentCreated =>
                    "real_time_payments_request_for_payment.created",
                EventCategory.RealTimePaymentsRequestForPaymentUpdated =>
                    "real_time_payments_request_for_payment.updated",
                EventCategory.SwiftTransferCreated => "swift_transfer.created",
                EventCategory.SwiftTransferUpdated => "swift_transfer.updated",
                EventCategory.TransactionCreated => "transaction.created",
                EventCategory.WireDrawdownRequestCreated => "wire_drawdown_request.created",
                EventCategory.WireDrawdownRequestUpdated => "wire_drawdown_request.updated",
                EventCategory.WireTransferCreated => "wire_transfer.created",
                EventCategory.WireTransferUpdated => "wire_transfer.updated",
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
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Event,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Events.Type>
{
    public override global::Increase.Api.Models.Events.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event" => global::Increase.Api.Models.Events.Type.Event,
            _ => (global::Increase.Api.Models.Events.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Events.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Events.Type.Event => "event",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
