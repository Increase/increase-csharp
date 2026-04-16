using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Events;

/// <summary>
/// List Events
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EventListParams : ParamsBase
{
    /// <summary>
    /// Filter Events to those belonging to the object with the provided identifier.
    /// </summary>
    public string? AssociatedObjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("associated_object_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("associated_object_id", value);
        }
    }

    public Category? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Category>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    public CreatedAt? CreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Return the page of entries after this one.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Limit the size of the list that is returned. The default (and maximum) is
    /// 100 objects.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public OrderBy? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<OrderBy>("order_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("order_by", value);
        }
    }

    public EventListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventListParams(EventListParams eventListParams)
        : base(eventListParams) { }
#pragma warning restore CS8618

    public EventListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EventListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EventListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<Category, CategoryFromRaw>))]
public sealed record class Category : JsonModel
{
    /// <summary>
    /// Filter Events for those with the specified category or categories. For GET
    /// requests, this should be encoded as a comma-delimited string, such as `?in=one,two,three`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, In>>? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, In>>>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, In>>?>(
                "in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.In ?? [])
        {
            item.Validate();
        }
    }

    public Category() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Category(Category category)
        : base(category) { }
#pragma warning restore CS8618

    public Category(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Category(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryFromRaw.FromRawUnchecked"/>
    public static Category FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryFromRaw : IFromRawJson<Category>
{
    /// <inheritdoc/>
    public Category FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Category.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
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

sealed class InConverter : JsonConverter<In>
{
    public override In Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account.created" => In.AccountCreated,
            "account.updated" => In.AccountUpdated,
            "account_number.created" => In.AccountNumberCreated,
            "account_number.updated" => In.AccountNumberUpdated,
            "account_statement.created" => In.AccountStatementCreated,
            "account_transfer.created" => In.AccountTransferCreated,
            "account_transfer.updated" => In.AccountTransferUpdated,
            "ach_prenotification.created" => In.AchPrenotificationCreated,
            "ach_prenotification.updated" => In.AchPrenotificationUpdated,
            "ach_transfer.created" => In.AchTransferCreated,
            "ach_transfer.updated" => In.AchTransferUpdated,
            "blockchain_address.created" => In.BlockchainAddressCreated,
            "blockchain_address.updated" => In.BlockchainAddressUpdated,
            "blockchain_offramp_transfer.created" => In.BlockchainOfframpTransferCreated,
            "blockchain_offramp_transfer.updated" => In.BlockchainOfframpTransferUpdated,
            "blockchain_onramp_transfer.created" => In.BlockchainOnrampTransferCreated,
            "blockchain_onramp_transfer.updated" => In.BlockchainOnrampTransferUpdated,
            "bookkeeping_account.created" => In.BookkeepingAccountCreated,
            "bookkeeping_account.updated" => In.BookkeepingAccountUpdated,
            "bookkeeping_entry_set.updated" => In.BookkeepingEntrySetUpdated,
            "card.created" => In.CardCreated,
            "card.updated" => In.CardUpdated,
            "card_payment.created" => In.CardPaymentCreated,
            "card_payment.updated" => In.CardPaymentUpdated,
            "card_purchase_supplement.created" => In.CardPurchaseSupplementCreated,
            "card_profile.created" => In.CardProfileCreated,
            "card_profile.updated" => In.CardProfileUpdated,
            "card_dispute.created" => In.CardDisputeCreated,
            "card_dispute.updated" => In.CardDisputeUpdated,
            "check_deposit.created" => In.CheckDepositCreated,
            "check_deposit.updated" => In.CheckDepositUpdated,
            "check_transfer.created" => In.CheckTransferCreated,
            "check_transfer.updated" => In.CheckTransferUpdated,
            "declined_transaction.created" => In.DeclinedTransactionCreated,
            "digital_card_profile.created" => In.DigitalCardProfileCreated,
            "digital_card_profile.updated" => In.DigitalCardProfileUpdated,
            "digital_wallet_token.created" => In.DigitalWalletTokenCreated,
            "digital_wallet_token.updated" => In.DigitalWalletTokenUpdated,
            "document.created" => In.DocumentCreated,
            "entity.created" => In.EntityCreated,
            "entity.updated" => In.EntityUpdated,
            "event_subscription.created" => In.EventSubscriptionCreated,
            "event_subscription.updated" => In.EventSubscriptionUpdated,
            "export.created" => In.ExportCreated,
            "export.updated" => In.ExportUpdated,
            "external_account.created" => In.ExternalAccountCreated,
            "external_account.updated" => In.ExternalAccountUpdated,
            "fednow_transfer.created" => In.FednowTransferCreated,
            "fednow_transfer.updated" => In.FednowTransferUpdated,
            "file.created" => In.FileCreated,
            "group.updated" => In.GroupUpdated,
            "group.heartbeat" => In.GroupHeartbeat,
            "inbound_ach_transfer.created" => In.InboundAchTransferCreated,
            "inbound_ach_transfer.updated" => In.InboundAchTransferUpdated,
            "inbound_ach_transfer_return.created" => In.InboundAchTransferReturnCreated,
            "inbound_ach_transfer_return.updated" => In.InboundAchTransferReturnUpdated,
            "inbound_check_deposit.created" => In.InboundCheckDepositCreated,
            "inbound_check_deposit.updated" => In.InboundCheckDepositUpdated,
            "inbound_fednow_transfer.created" => In.InboundFednowTransferCreated,
            "inbound_fednow_transfer.updated" => In.InboundFednowTransferUpdated,
            "inbound_mail_item.created" => In.InboundMailItemCreated,
            "inbound_mail_item.updated" => In.InboundMailItemUpdated,
            "inbound_real_time_payments_transfer.created" =>
                In.InboundRealTimePaymentsTransferCreated,
            "inbound_real_time_payments_transfer.updated" =>
                In.InboundRealTimePaymentsTransferUpdated,
            "inbound_wire_drawdown_request.created" => In.InboundWireDrawdownRequestCreated,
            "inbound_wire_transfer.created" => In.InboundWireTransferCreated,
            "inbound_wire_transfer.updated" => In.InboundWireTransferUpdated,
            "intrafi_account_enrollment.created" => In.IntrafiAccountEnrollmentCreated,
            "intrafi_account_enrollment.updated" => In.IntrafiAccountEnrollmentUpdated,
            "intrafi_exclusion.created" => In.IntrafiExclusionCreated,
            "intrafi_exclusion.updated" => In.IntrafiExclusionUpdated,
            "legacy_card_dispute.created" => In.LegacyCardDisputeCreated,
            "legacy_card_dispute.updated" => In.LegacyCardDisputeUpdated,
            "lockbox.created" => In.LockboxCreated,
            "lockbox.updated" => In.LockboxUpdated,
            "oauth_connection.created" => In.OAuthConnectionCreated,
            "oauth_connection.deactivated" => In.OAuthConnectionDeactivated,
            "card_push_transfer.created" => In.CardPushTransferCreated,
            "card_push_transfer.updated" => In.CardPushTransferUpdated,
            "card_validation.created" => In.CardValidationCreated,
            "card_validation.updated" => In.CardValidationUpdated,
            "pending_transaction.created" => In.PendingTransactionCreated,
            "pending_transaction.updated" => In.PendingTransactionUpdated,
            "physical_card.created" => In.PhysicalCardCreated,
            "physical_card.updated" => In.PhysicalCardUpdated,
            "physical_card_profile.created" => In.PhysicalCardProfileCreated,
            "physical_card_profile.updated" => In.PhysicalCardProfileUpdated,
            "physical_check.created" => In.PhysicalCheckCreated,
            "physical_check.updated" => In.PhysicalCheckUpdated,
            "program.created" => In.ProgramCreated,
            "program.updated" => In.ProgramUpdated,
            "proof_of_authorization_request.created" => In.ProofOfAuthorizationRequestCreated,
            "proof_of_authorization_request.updated" => In.ProofOfAuthorizationRequestUpdated,
            "real_time_decision.card_authorization_requested" =>
                In.RealTimeDecisionCardAuthorizationRequested,
            "real_time_decision.card_balance_inquiry_requested" =>
                In.RealTimeDecisionCardBalanceInquiryRequested,
            "real_time_decision.digital_wallet_token_requested" =>
                In.RealTimeDecisionDigitalWalletTokenRequested,
            "real_time_decision.digital_wallet_authentication_requested" =>
                In.RealTimeDecisionDigitalWalletAuthenticationRequested,
            "real_time_decision.card_authentication_requested" =>
                In.RealTimeDecisionCardAuthenticationRequested,
            "real_time_decision.card_authentication_challenge_requested" =>
                In.RealTimeDecisionCardAuthenticationChallengeRequested,
            "real_time_payments_transfer.created" => In.RealTimePaymentsTransferCreated,
            "real_time_payments_transfer.updated" => In.RealTimePaymentsTransferUpdated,
            "real_time_payments_request_for_payment.created" =>
                In.RealTimePaymentsRequestForPaymentCreated,
            "real_time_payments_request_for_payment.updated" =>
                In.RealTimePaymentsRequestForPaymentUpdated,
            "swift_transfer.created" => In.SwiftTransferCreated,
            "swift_transfer.updated" => In.SwiftTransferUpdated,
            "transaction.created" => In.TransactionCreated,
            "wire_drawdown_request.created" => In.WireDrawdownRequestCreated,
            "wire_drawdown_request.updated" => In.WireDrawdownRequestUpdated,
            "wire_transfer.created" => In.WireTransferCreated,
            "wire_transfer.updated" => In.WireTransferUpdated,
            _ => (In)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, In value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                In.AccountCreated => "account.created",
                In.AccountUpdated => "account.updated",
                In.AccountNumberCreated => "account_number.created",
                In.AccountNumberUpdated => "account_number.updated",
                In.AccountStatementCreated => "account_statement.created",
                In.AccountTransferCreated => "account_transfer.created",
                In.AccountTransferUpdated => "account_transfer.updated",
                In.AchPrenotificationCreated => "ach_prenotification.created",
                In.AchPrenotificationUpdated => "ach_prenotification.updated",
                In.AchTransferCreated => "ach_transfer.created",
                In.AchTransferUpdated => "ach_transfer.updated",
                In.BlockchainAddressCreated => "blockchain_address.created",
                In.BlockchainAddressUpdated => "blockchain_address.updated",
                In.BlockchainOfframpTransferCreated => "blockchain_offramp_transfer.created",
                In.BlockchainOfframpTransferUpdated => "blockchain_offramp_transfer.updated",
                In.BlockchainOnrampTransferCreated => "blockchain_onramp_transfer.created",
                In.BlockchainOnrampTransferUpdated => "blockchain_onramp_transfer.updated",
                In.BookkeepingAccountCreated => "bookkeeping_account.created",
                In.BookkeepingAccountUpdated => "bookkeeping_account.updated",
                In.BookkeepingEntrySetUpdated => "bookkeeping_entry_set.updated",
                In.CardCreated => "card.created",
                In.CardUpdated => "card.updated",
                In.CardPaymentCreated => "card_payment.created",
                In.CardPaymentUpdated => "card_payment.updated",
                In.CardPurchaseSupplementCreated => "card_purchase_supplement.created",
                In.CardProfileCreated => "card_profile.created",
                In.CardProfileUpdated => "card_profile.updated",
                In.CardDisputeCreated => "card_dispute.created",
                In.CardDisputeUpdated => "card_dispute.updated",
                In.CheckDepositCreated => "check_deposit.created",
                In.CheckDepositUpdated => "check_deposit.updated",
                In.CheckTransferCreated => "check_transfer.created",
                In.CheckTransferUpdated => "check_transfer.updated",
                In.DeclinedTransactionCreated => "declined_transaction.created",
                In.DigitalCardProfileCreated => "digital_card_profile.created",
                In.DigitalCardProfileUpdated => "digital_card_profile.updated",
                In.DigitalWalletTokenCreated => "digital_wallet_token.created",
                In.DigitalWalletTokenUpdated => "digital_wallet_token.updated",
                In.DocumentCreated => "document.created",
                In.EntityCreated => "entity.created",
                In.EntityUpdated => "entity.updated",
                In.EventSubscriptionCreated => "event_subscription.created",
                In.EventSubscriptionUpdated => "event_subscription.updated",
                In.ExportCreated => "export.created",
                In.ExportUpdated => "export.updated",
                In.ExternalAccountCreated => "external_account.created",
                In.ExternalAccountUpdated => "external_account.updated",
                In.FednowTransferCreated => "fednow_transfer.created",
                In.FednowTransferUpdated => "fednow_transfer.updated",
                In.FileCreated => "file.created",
                In.GroupUpdated => "group.updated",
                In.GroupHeartbeat => "group.heartbeat",
                In.InboundAchTransferCreated => "inbound_ach_transfer.created",
                In.InboundAchTransferUpdated => "inbound_ach_transfer.updated",
                In.InboundAchTransferReturnCreated => "inbound_ach_transfer_return.created",
                In.InboundAchTransferReturnUpdated => "inbound_ach_transfer_return.updated",
                In.InboundCheckDepositCreated => "inbound_check_deposit.created",
                In.InboundCheckDepositUpdated => "inbound_check_deposit.updated",
                In.InboundFednowTransferCreated => "inbound_fednow_transfer.created",
                In.InboundFednowTransferUpdated => "inbound_fednow_transfer.updated",
                In.InboundMailItemCreated => "inbound_mail_item.created",
                In.InboundMailItemUpdated => "inbound_mail_item.updated",
                In.InboundRealTimePaymentsTransferCreated =>
                    "inbound_real_time_payments_transfer.created",
                In.InboundRealTimePaymentsTransferUpdated =>
                    "inbound_real_time_payments_transfer.updated",
                In.InboundWireDrawdownRequestCreated => "inbound_wire_drawdown_request.created",
                In.InboundWireTransferCreated => "inbound_wire_transfer.created",
                In.InboundWireTransferUpdated => "inbound_wire_transfer.updated",
                In.IntrafiAccountEnrollmentCreated => "intrafi_account_enrollment.created",
                In.IntrafiAccountEnrollmentUpdated => "intrafi_account_enrollment.updated",
                In.IntrafiExclusionCreated => "intrafi_exclusion.created",
                In.IntrafiExclusionUpdated => "intrafi_exclusion.updated",
                In.LegacyCardDisputeCreated => "legacy_card_dispute.created",
                In.LegacyCardDisputeUpdated => "legacy_card_dispute.updated",
                In.LockboxCreated => "lockbox.created",
                In.LockboxUpdated => "lockbox.updated",
                In.OAuthConnectionCreated => "oauth_connection.created",
                In.OAuthConnectionDeactivated => "oauth_connection.deactivated",
                In.CardPushTransferCreated => "card_push_transfer.created",
                In.CardPushTransferUpdated => "card_push_transfer.updated",
                In.CardValidationCreated => "card_validation.created",
                In.CardValidationUpdated => "card_validation.updated",
                In.PendingTransactionCreated => "pending_transaction.created",
                In.PendingTransactionUpdated => "pending_transaction.updated",
                In.PhysicalCardCreated => "physical_card.created",
                In.PhysicalCardUpdated => "physical_card.updated",
                In.PhysicalCardProfileCreated => "physical_card_profile.created",
                In.PhysicalCardProfileUpdated => "physical_card_profile.updated",
                In.PhysicalCheckCreated => "physical_check.created",
                In.PhysicalCheckUpdated => "physical_check.updated",
                In.ProgramCreated => "program.created",
                In.ProgramUpdated => "program.updated",
                In.ProofOfAuthorizationRequestCreated => "proof_of_authorization_request.created",
                In.ProofOfAuthorizationRequestUpdated => "proof_of_authorization_request.updated",
                In.RealTimeDecisionCardAuthorizationRequested =>
                    "real_time_decision.card_authorization_requested",
                In.RealTimeDecisionCardBalanceInquiryRequested =>
                    "real_time_decision.card_balance_inquiry_requested",
                In.RealTimeDecisionDigitalWalletTokenRequested =>
                    "real_time_decision.digital_wallet_token_requested",
                In.RealTimeDecisionDigitalWalletAuthenticationRequested =>
                    "real_time_decision.digital_wallet_authentication_requested",
                In.RealTimeDecisionCardAuthenticationRequested =>
                    "real_time_decision.card_authentication_requested",
                In.RealTimeDecisionCardAuthenticationChallengeRequested =>
                    "real_time_decision.card_authentication_challenge_requested",
                In.RealTimePaymentsTransferCreated => "real_time_payments_transfer.created",
                In.RealTimePaymentsTransferUpdated => "real_time_payments_transfer.updated",
                In.RealTimePaymentsRequestForPaymentCreated =>
                    "real_time_payments_request_for_payment.created",
                In.RealTimePaymentsRequestForPaymentUpdated =>
                    "real_time_payments_request_for_payment.updated",
                In.SwiftTransferCreated => "swift_transfer.created",
                In.SwiftTransferUpdated => "swift_transfer.updated",
                In.TransactionCreated => "transaction.created",
                In.WireDrawdownRequestCreated => "wire_drawdown_request.created",
                In.WireDrawdownRequestUpdated => "wire_drawdown_request.updated",
                In.WireTransferCreated => "wire_transfer.created",
                In.WireTransferUpdated => "wire_transfer.updated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public CreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt(CreatedAt createdAt)
        : base(createdAt) { }
#pragma warning restore CS8618

    public CreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OrderBy, OrderByFromRaw>))]
public sealed record class OrderBy : JsonModel
{
    /// <summary>
    /// The direction to order in.
    /// </summary>
    public ApiEnum<string, Direction>? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Direction>>("direction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// The field to order by.
    /// </summary>
    public ApiEnum<string, Field>? Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Field>>("field");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("field", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Direction?.Validate();
        this.Field?.Validate();
    }

    public OrderBy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrderBy(OrderBy orderBy)
        : base(orderBy) { }
#pragma warning restore CS8618

    public OrderBy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrderBy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrderByFromRaw.FromRawUnchecked"/>
    public static OrderBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrderByFromRaw : IFromRawJson<OrderBy>
{
    /// <inheritdoc/>
    public OrderBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OrderBy.FromRawUnchecked(rawData);
}

/// <summary>
/// The direction to order in.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    /// <summary>
    /// Ascending in value.
    /// </summary>
    Ascending,

    /// <summary>
    /// Descending in value.
    /// </summary>
    Descending,
}

sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ascending" => Direction.Ascending,
            "descending" => Direction.Descending,
            _ => (Direction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Direction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Direction.Ascending => "ascending",
                Direction.Descending => "descending",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The field to order by.
/// </summary>
[JsonConverter(typeof(FieldConverter))]
public enum Field
{
    /// <summary>
    /// The time the Event was created.
    /// </summary>
    CreatedAt,
}

sealed class FieldConverter : JsonConverter<Field>
{
    public override Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at" => Field.CreatedAt,
            _ => (Field)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field.CreatedAt => "created_at",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
