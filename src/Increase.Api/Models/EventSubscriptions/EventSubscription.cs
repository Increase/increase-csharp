using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.EventSubscriptions;

/// <summary>
/// Webhooks are event notifications we send to you by HTTPS POST requests. Event
/// Subscriptions are how you configure your application to listen for them. You can
/// create an Event Subscription through your [developer dashboard](https://dashboard.increase.com/developers/webhooks)
/// or the API. For more information, see our [webhooks guide](https://increase.com/documentation/webhooks).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EventSubscription, EventSubscriptionFromRaw>))]
public sealed record class EventSubscription : JsonModel
{
    /// <summary>
    /// The event subscription identifier.
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
    /// The time the event subscription was created.
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
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// If specified, this subscription will only receive webhooks for Events associated
    /// with this OAuth Connection.
    /// </summary>
    public required string? OAuthConnectionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("oauth_connection_id");
        }
        init { this._rawData.Set("oauth_connection_id", value); }
    }

    /// <summary>
    /// If specified, this subscription will only receive webhooks for Events with
    /// the specified `category`.
    /// </summary>
    public required IReadOnlyList<EventSubscriptionSelectedEventCategory>? SelectedEventCategories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<EventSubscriptionSelectedEventCategory>
            >("selected_event_categories");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EventSubscriptionSelectedEventCategory>?>(
                "selected_event_categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// This indicates if we'll send notifications to this subscription.
    /// </summary>
    public required ApiEnum<string, EventSubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventSubscriptionStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `event_subscription`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.EventSubscriptions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.EventSubscriptions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The webhook url where we'll send notifications.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.IdempotencyKey;
        _ = this.OAuthConnectionID;
        foreach (var item in this.SelectedEventCategories ?? [])
        {
            item.Validate();
        }
        this.Status.Validate();
        this.Type.Validate();
        _ = this.Url;
    }

    public EventSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventSubscription(EventSubscription eventSubscription)
        : base(eventSubscription) { }
#pragma warning restore CS8618

    public EventSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventSubscriptionFromRaw.FromRawUnchecked"/>
    public static EventSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventSubscriptionFromRaw : IFromRawJson<EventSubscription>
{
    /// <inheritdoc/>
    public EventSubscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventSubscription.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EventSubscriptionSelectedEventCategory,
        EventSubscriptionSelectedEventCategoryFromRaw
    >)
)]
public sealed record class EventSubscriptionSelectedEventCategory : JsonModel
{
    /// <summary>
    /// The category of the Event.
    /// </summary>
    public required ApiEnum<
        string,
        EventSubscriptionSelectedEventCategoryEventCategory
    >? EventCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EventSubscriptionSelectedEventCategoryEventCategory>
            >("event_category");
        }
        init { this._rawData.Set("event_category", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.EventCategory?.Validate();
    }

    public EventSubscriptionSelectedEventCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventSubscriptionSelectedEventCategory(
        EventSubscriptionSelectedEventCategory eventSubscriptionSelectedEventCategory
    )
        : base(eventSubscriptionSelectedEventCategory) { }
#pragma warning restore CS8618

    public EventSubscriptionSelectedEventCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSubscriptionSelectedEventCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventSubscriptionSelectedEventCategoryFromRaw.FromRawUnchecked"/>
    public static EventSubscriptionSelectedEventCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventSubscriptionSelectedEventCategory(
        ApiEnum<string, EventSubscriptionSelectedEventCategoryEventCategory>? eventCategory
    )
        : this()
    {
        this.EventCategory = eventCategory;
    }
}

class EventSubscriptionSelectedEventCategoryFromRaw
    : IFromRawJson<EventSubscriptionSelectedEventCategory>
{
    /// <inheritdoc/>
    public EventSubscriptionSelectedEventCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventSubscriptionSelectedEventCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the Event.
/// </summary>
[JsonConverter(typeof(EventSubscriptionSelectedEventCategoryEventCategoryConverter))]
public enum EventSubscriptionSelectedEventCategoryEventCategory
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

sealed class EventSubscriptionSelectedEventCategoryEventCategoryConverter
    : JsonConverter<EventSubscriptionSelectedEventCategoryEventCategory>
{
    public override EventSubscriptionSelectedEventCategoryEventCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account.created" => EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated,
            "account.updated" => EventSubscriptionSelectedEventCategoryEventCategory.AccountUpdated,
            "account_number.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberCreated,
            "account_number.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberUpdated,
            "account_statement.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AccountStatementCreated,
            "account_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferCreated,
            "account_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferUpdated,
            "ach_prenotification.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationCreated,
            "ach_prenotification.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationUpdated,
            "ach_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AchTransferCreated,
            "ach_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.AchTransferUpdated,
            "blockchain_address.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressCreated,
            "blockchain_address.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressUpdated,
            "blockchain_offramp_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferCreated,
            "blockchain_offramp_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferUpdated,
            "blockchain_onramp_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferCreated,
            "blockchain_onramp_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferUpdated,
            "bookkeeping_account.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountCreated,
            "bookkeeping_account.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountUpdated,
            "bookkeeping_entry_set.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingEntrySetUpdated,
            "card.created" => EventSubscriptionSelectedEventCategoryEventCategory.CardCreated,
            "card.updated" => EventSubscriptionSelectedEventCategoryEventCategory.CardUpdated,
            "card_payment.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentCreated,
            "card_payment.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentUpdated,
            "card_purchase_supplement.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardPurchaseSupplementCreated,
            "card_profile.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardProfileCreated,
            "card_profile.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardProfileUpdated,
            "card_dispute.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeCreated,
            "card_dispute.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeUpdated,
            "check_deposit.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositCreated,
            "check_deposit.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositUpdated,
            "check_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferCreated,
            "check_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferUpdated,
            "declined_transaction.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.DeclinedTransactionCreated,
            "digital_card_profile.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileCreated,
            "digital_card_profile.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileUpdated,
            "digital_wallet_token.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenCreated,
            "digital_wallet_token.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenUpdated,
            "document.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.DocumentCreated,
            "entity.created" => EventSubscriptionSelectedEventCategoryEventCategory.EntityCreated,
            "entity.updated" => EventSubscriptionSelectedEventCategoryEventCategory.EntityUpdated,
            "event_subscription.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionCreated,
            "event_subscription.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionUpdated,
            "export.created" => EventSubscriptionSelectedEventCategoryEventCategory.ExportCreated,
            "export.updated" => EventSubscriptionSelectedEventCategoryEventCategory.ExportUpdated,
            "external_account.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountCreated,
            "external_account.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountUpdated,
            "fednow_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferCreated,
            "fednow_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferUpdated,
            "file.created" => EventSubscriptionSelectedEventCategoryEventCategory.FileCreated,
            "group.updated" => EventSubscriptionSelectedEventCategoryEventCategory.GroupUpdated,
            "group.heartbeat" => EventSubscriptionSelectedEventCategoryEventCategory.GroupHeartbeat,
            "inbound_ach_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferCreated,
            "inbound_ach_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferUpdated,
            "inbound_ach_transfer_return.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnCreated,
            "inbound_ach_transfer_return.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnUpdated,
            "inbound_check_deposit.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositCreated,
            "inbound_check_deposit.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositUpdated,
            "inbound_fednow_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferCreated,
            "inbound_fednow_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferUpdated,
            "inbound_mail_item.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemCreated,
            "inbound_mail_item.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemUpdated,
            "inbound_real_time_payments_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferCreated,
            "inbound_real_time_payments_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferUpdated,
            "inbound_wire_drawdown_request.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundWireDrawdownRequestCreated,
            "inbound_wire_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferCreated,
            "inbound_wire_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferUpdated,
            "intrafi_account_enrollment.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentCreated,
            "intrafi_account_enrollment.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentUpdated,
            "intrafi_exclusion.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionCreated,
            "intrafi_exclusion.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionUpdated,
            "legacy_card_dispute.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.LegacyCardDisputeCreated,
            "legacy_card_dispute.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.LegacyCardDisputeUpdated,
            "lockbox.created" => EventSubscriptionSelectedEventCategoryEventCategory.LockboxCreated,
            "lockbox.updated" => EventSubscriptionSelectedEventCategoryEventCategory.LockboxUpdated,
            "oauth_connection.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionCreated,
            "oauth_connection.deactivated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionDeactivated,
            "card_push_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferCreated,
            "card_push_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferUpdated,
            "card_validation.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardValidationCreated,
            "card_validation.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.CardValidationUpdated,
            "pending_transaction.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionCreated,
            "pending_transaction.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionUpdated,
            "physical_card.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardCreated,
            "physical_card.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardUpdated,
            "physical_card_profile.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileCreated,
            "physical_card_profile.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileUpdated,
            "physical_check.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckCreated,
            "physical_check.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckUpdated,
            "program.created" => EventSubscriptionSelectedEventCategoryEventCategory.ProgramCreated,
            "program.updated" => EventSubscriptionSelectedEventCategoryEventCategory.ProgramUpdated,
            "proof_of_authorization_request.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestCreated,
            "proof_of_authorization_request.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestUpdated,
            "real_time_decision.card_authorization_requested" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthorizationRequested,
            "real_time_decision.card_balance_inquiry_requested" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardBalanceInquiryRequested,
            "real_time_decision.digital_wallet_token_requested" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletTokenRequested,
            "real_time_decision.digital_wallet_authentication_requested" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested,
            "real_time_decision.card_authentication_requested" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationRequested,
            "real_time_decision.card_authentication_challenge_requested" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested,
            "real_time_payments_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferCreated,
            "real_time_payments_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferUpdated,
            "real_time_payments_request_for_payment.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentCreated,
            "real_time_payments_request_for_payment.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentUpdated,
            "swift_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferCreated,
            "swift_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferUpdated,
            "transaction.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.TransactionCreated,
            "wire_drawdown_request.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestCreated,
            "wire_drawdown_request.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestUpdated,
            "wire_transfer.created" =>
                EventSubscriptionSelectedEventCategoryEventCategory.WireTransferCreated,
            "wire_transfer.updated" =>
                EventSubscriptionSelectedEventCategoryEventCategory.WireTransferUpdated,
            _ => (EventSubscriptionSelectedEventCategoryEventCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventSubscriptionSelectedEventCategoryEventCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventSubscriptionSelectedEventCategoryEventCategory.AccountCreated =>
                    "account.created",
                EventSubscriptionSelectedEventCategoryEventCategory.AccountUpdated =>
                    "account.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberCreated =>
                    "account_number.created",
                EventSubscriptionSelectedEventCategoryEventCategory.AccountNumberUpdated =>
                    "account_number.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.AccountStatementCreated =>
                    "account_statement.created",
                EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferCreated =>
                    "account_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.AccountTransferUpdated =>
                    "account_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationCreated =>
                    "ach_prenotification.created",
                EventSubscriptionSelectedEventCategoryEventCategory.AchPrenotificationUpdated =>
                    "ach_prenotification.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.AchTransferCreated =>
                    "ach_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.AchTransferUpdated =>
                    "ach_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressCreated =>
                    "blockchain_address.created",
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainAddressUpdated =>
                    "blockchain_address.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferCreated =>
                    "blockchain_offramp_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOfframpTransferUpdated =>
                    "blockchain_offramp_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferCreated =>
                    "blockchain_onramp_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.BlockchainOnrampTransferUpdated =>
                    "blockchain_onramp_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountCreated =>
                    "bookkeeping_account.created",
                EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingAccountUpdated =>
                    "bookkeeping_account.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.BookkeepingEntrySetUpdated =>
                    "bookkeeping_entry_set.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CardCreated => "card.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardUpdated => "card.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentCreated =>
                    "card_payment.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardPaymentUpdated =>
                    "card_payment.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CardPurchaseSupplementCreated =>
                    "card_purchase_supplement.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardProfileCreated =>
                    "card_profile.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardProfileUpdated =>
                    "card_profile.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeCreated =>
                    "card_dispute.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardDisputeUpdated =>
                    "card_dispute.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositCreated =>
                    "check_deposit.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CheckDepositUpdated =>
                    "check_deposit.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferCreated =>
                    "check_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CheckTransferUpdated =>
                    "check_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.DeclinedTransactionCreated =>
                    "declined_transaction.created",
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileCreated =>
                    "digital_card_profile.created",
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalCardProfileUpdated =>
                    "digital_card_profile.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenCreated =>
                    "digital_wallet_token.created",
                EventSubscriptionSelectedEventCategoryEventCategory.DigitalWalletTokenUpdated =>
                    "digital_wallet_token.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.DocumentCreated =>
                    "document.created",
                EventSubscriptionSelectedEventCategoryEventCategory.EntityCreated =>
                    "entity.created",
                EventSubscriptionSelectedEventCategoryEventCategory.EntityUpdated =>
                    "entity.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionCreated =>
                    "event_subscription.created",
                EventSubscriptionSelectedEventCategoryEventCategory.EventSubscriptionUpdated =>
                    "event_subscription.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.ExportCreated =>
                    "export.created",
                EventSubscriptionSelectedEventCategoryEventCategory.ExportUpdated =>
                    "export.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountCreated =>
                    "external_account.created",
                EventSubscriptionSelectedEventCategoryEventCategory.ExternalAccountUpdated =>
                    "external_account.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferCreated =>
                    "fednow_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.FednowTransferUpdated =>
                    "fednow_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.FileCreated => "file.created",
                EventSubscriptionSelectedEventCategoryEventCategory.GroupUpdated => "group.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.GroupHeartbeat =>
                    "group.heartbeat",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferCreated =>
                    "inbound_ach_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferUpdated =>
                    "inbound_ach_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnCreated =>
                    "inbound_ach_transfer_return.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundAchTransferReturnUpdated =>
                    "inbound_ach_transfer_return.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositCreated =>
                    "inbound_check_deposit.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundCheckDepositUpdated =>
                    "inbound_check_deposit.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferCreated =>
                    "inbound_fednow_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundFednowTransferUpdated =>
                    "inbound_fednow_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemCreated =>
                    "inbound_mail_item.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundMailItemUpdated =>
                    "inbound_mail_item.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferCreated =>
                    "inbound_real_time_payments_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundRealTimePaymentsTransferUpdated =>
                    "inbound_real_time_payments_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundWireDrawdownRequestCreated =>
                    "inbound_wire_drawdown_request.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferCreated =>
                    "inbound_wire_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.InboundWireTransferUpdated =>
                    "inbound_wire_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentCreated =>
                    "intrafi_account_enrollment.created",
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiAccountEnrollmentUpdated =>
                    "intrafi_account_enrollment.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionCreated =>
                    "intrafi_exclusion.created",
                EventSubscriptionSelectedEventCategoryEventCategory.IntrafiExclusionUpdated =>
                    "intrafi_exclusion.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.LegacyCardDisputeCreated =>
                    "legacy_card_dispute.created",
                EventSubscriptionSelectedEventCategoryEventCategory.LegacyCardDisputeUpdated =>
                    "legacy_card_dispute.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.LockboxCreated =>
                    "lockbox.created",
                EventSubscriptionSelectedEventCategoryEventCategory.LockboxUpdated =>
                    "lockbox.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionCreated =>
                    "oauth_connection.created",
                EventSubscriptionSelectedEventCategoryEventCategory.OAuthConnectionDeactivated =>
                    "oauth_connection.deactivated",
                EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferCreated =>
                    "card_push_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardPushTransferUpdated =>
                    "card_push_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.CardValidationCreated =>
                    "card_validation.created",
                EventSubscriptionSelectedEventCategoryEventCategory.CardValidationUpdated =>
                    "card_validation.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionCreated =>
                    "pending_transaction.created",
                EventSubscriptionSelectedEventCategoryEventCategory.PendingTransactionUpdated =>
                    "pending_transaction.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardCreated =>
                    "physical_card.created",
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardUpdated =>
                    "physical_card.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileCreated =>
                    "physical_card_profile.created",
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCardProfileUpdated =>
                    "physical_card_profile.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckCreated =>
                    "physical_check.created",
                EventSubscriptionSelectedEventCategoryEventCategory.PhysicalCheckUpdated =>
                    "physical_check.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.ProgramCreated =>
                    "program.created",
                EventSubscriptionSelectedEventCategoryEventCategory.ProgramUpdated =>
                    "program.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestCreated =>
                    "proof_of_authorization_request.created",
                EventSubscriptionSelectedEventCategoryEventCategory.ProofOfAuthorizationRequestUpdated =>
                    "proof_of_authorization_request.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthorizationRequested =>
                    "real_time_decision.card_authorization_requested",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardBalanceInquiryRequested =>
                    "real_time_decision.card_balance_inquiry_requested",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletTokenRequested =>
                    "real_time_decision.digital_wallet_token_requested",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionDigitalWalletAuthenticationRequested =>
                    "real_time_decision.digital_wallet_authentication_requested",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationRequested =>
                    "real_time_decision.card_authentication_requested",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimeDecisionCardAuthenticationChallengeRequested =>
                    "real_time_decision.card_authentication_challenge_requested",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferCreated =>
                    "real_time_payments_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsTransferUpdated =>
                    "real_time_payments_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentCreated =>
                    "real_time_payments_request_for_payment.created",
                EventSubscriptionSelectedEventCategoryEventCategory.RealTimePaymentsRequestForPaymentUpdated =>
                    "real_time_payments_request_for_payment.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferCreated =>
                    "swift_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.SwiftTransferUpdated =>
                    "swift_transfer.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.TransactionCreated =>
                    "transaction.created",
                EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestCreated =>
                    "wire_drawdown_request.created",
                EventSubscriptionSelectedEventCategoryEventCategory.WireDrawdownRequestUpdated =>
                    "wire_drawdown_request.updated",
                EventSubscriptionSelectedEventCategoryEventCategory.WireTransferCreated =>
                    "wire_transfer.created",
                EventSubscriptionSelectedEventCategoryEventCategory.WireTransferUpdated =>
                    "wire_transfer.updated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This indicates if we'll send notifications to this subscription.
/// </summary>
[JsonConverter(typeof(EventSubscriptionStatusConverter))]
public enum EventSubscriptionStatus
{
    /// <summary>
    /// The subscription is active and Events will be delivered normally.
    /// </summary>
    Active,

    /// <summary>
    /// The subscription is temporarily disabled and Events will not be delivered.
    /// </summary>
    Disabled,

    /// <summary>
    /// The subscription is permanently disabled and Events will not be delivered.
    /// </summary>
    Deleted,

    /// <summary>
    /// The subscription is temporarily disabled due to delivery errors and Events
    /// will not be delivered.
    /// </summary>
    RequiresAttention,
}

sealed class EventSubscriptionStatusConverter : JsonConverter<EventSubscriptionStatus>
{
    public override EventSubscriptionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => EventSubscriptionStatus.Active,
            "disabled" => EventSubscriptionStatus.Disabled,
            "deleted" => EventSubscriptionStatus.Deleted,
            "requires_attention" => EventSubscriptionStatus.RequiresAttention,
            _ => (EventSubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventSubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventSubscriptionStatus.Active => "active",
                EventSubscriptionStatus.Disabled => "disabled",
                EventSubscriptionStatus.Deleted => "deleted",
                EventSubscriptionStatus.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `event_subscription`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    EventSubscription,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.EventSubscriptions.Type>
{
    public override global::Increase.Api.Models.EventSubscriptions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event_subscription" => global::Increase
                .Api
                .Models
                .EventSubscriptions
                .Type
                .EventSubscription,
            _ => (global::Increase.Api.Models.EventSubscriptions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.EventSubscriptions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.EventSubscriptions.Type.EventSubscription =>
                    "event_subscription",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
