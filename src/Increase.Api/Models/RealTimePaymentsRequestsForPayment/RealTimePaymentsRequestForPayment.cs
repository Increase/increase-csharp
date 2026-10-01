using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.RealTimePaymentsRequestsForPayment;

/// <summary>
/// Real-Time Payments transfers move funds, within seconds, between your Increase
/// account and any other account on the Real-Time Payments network. A request for
/// payment is a request to the receiver to send funds to your account. The permitted
/// uses of Requests For Payment are limited by the Real-Time Payments network to
/// business-to-business payments and transfers between two accounts at different
/// banks owned by the same individual. Please contact [support@increase.com](mailto:support@increase.com)
/// to enable this API for your team.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsRequestForPayment,
        RealTimePaymentsRequestForPaymentFromRaw
    >)
)]
public sealed record class RealTimePaymentsRequestForPayment : JsonModel
{
    /// <summary>
    /// The Real-Time Payments Request for Payment's identifier.
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
    /// The Account in which a successful transfer will arrive.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The Account Number in which a successful transfer will arrive.
    /// </summary>
    public required string AccountNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number_id");
        }
        init { this._rawData.Set("account_number_id", value); }
    }

    /// <summary>
    /// The transfer amount in USD cents.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// If a cancellation has been requested, this will contain supplemental details.
    /// The request for payment moves to `canceled` once the recipient bank acknowledges
    /// the cancellation.
    /// </summary>
    public required Cancellation? Cancellation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cancellation>("cancellation");
        }
        init { this._rawData.Set("cancellation", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the request for payment was created.
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
    /// The name of the creditor requesting the payment.
    /// </summary>
    public required string CreditorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_name");
        }
        init { this._rawData.Set("creditor_name", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
    /// currency. For real-time payments transfers this is always equal to `USD`.
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Details of the person being requested to pay.
    /// </summary>
    public required RealTimePaymentsRequestForPaymentDebtor Debtor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimePaymentsRequestForPaymentDebtor>("debtor");
        }
        init { this._rawData.Set("debtor", value); }
    }

    /// <summary>
    /// The debtor's account number, which the request is sent to.
    /// </summary>
    public required string DebtorAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_account_number");
        }
        init { this._rawData.Set("debtor_account_number", value); }
    }

    /// <summary>
    /// The debtor's American Bankers' Association (ABA) Routing Transit Number (RTN).
    /// </summary>
    public required string DebtorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_routing_number");
        }
        init { this._rawData.Set("debtor_routing_number", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time after
    /// which the request for payment is no longer valid. After this time the debtor's
    /// bank should no longer allow the debtor to pay it.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The identifier of the Inbound Real-Time Payments Transfer that fulfilled
    /// this request.
    /// </summary>
    public required string? FulfillmentInboundRealTimePaymentsTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fulfillment_inbound_real_time_payments_transfer_id"
            );
        }
        init { this._rawData.Set("fulfillment_inbound_real_time_payments_transfer_id", value); }
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
    /// If the request for payment is refused by the destination financial institution
    /// or the receiving customer, this will contain supplemental details.
    /// </summary>
    public required Refusal? Refusal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Refusal>("refusal");
        }
        init { this._rawData.Set("refusal", value); }
    }

    /// <summary>
    /// If the request for payment is rejected by Real-Time Payments or the destination
    /// financial institution, this will contain supplemental details.
    /// </summary>
    public required Rejection? Rejection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rejection>("rejection");
        }
        init { this._rawData.Set("rejection", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time by which
    /// the payment was requested to be made.
    /// </summary>
    public required System::DateTimeOffset? RequestedExecutionAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "requested_execution_at"
            );
        }
        init { this._rawData.Set("requested_execution_at", value); }
    }

    /// <summary>
    /// The lifecycle status of the request for payment.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the request for payment is submitted to Real-Time Payments, this will
    /// contain supplemental details.
    /// </summary>
    public required Submission? Submission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Submission>("submission");
        }
        init { this._rawData.Set("submission", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `real_time_payments_request_for_payment`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.RealTimePaymentsRequestsForPayment.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.RealTimePaymentsRequestsForPayment.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Unstructured information that will show on the recipient's bank statement.
    /// </summary>
    public required string UnstructuredRemittanceInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unstructured_remittance_information");
        }
        init { this._rawData.Set("unstructured_remittance_information", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.AccountNumberID;
        _ = this.Amount;
        this.Cancellation?.Validate();
        _ = this.CreatedAt;
        _ = this.CreditorName;
        this.Currency.Validate();
        this.Debtor.Validate();
        _ = this.DebtorAccountNumber;
        _ = this.DebtorRoutingNumber;
        _ = this.ExpiresAt;
        _ = this.FulfillmentInboundRealTimePaymentsTransferID;
        _ = this.IdempotencyKey;
        this.Refusal?.Validate();
        this.Rejection?.Validate();
        _ = this.RequestedExecutionAt;
        this.Status.Validate();
        this.Submission?.Validate();
        this.Type.Validate();
        _ = this.UnstructuredRemittanceInformation;
    }

    public RealTimePaymentsRequestForPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestForPayment(
        RealTimePaymentsRequestForPayment realTimePaymentsRequestForPayment
    )
        : base(realTimePaymentsRequestForPayment) { }
#pragma warning restore CS8618

    public RealTimePaymentsRequestForPayment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsRequestForPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsRequestForPaymentFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsRequestForPayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsRequestForPaymentFromRaw : IFromRawJson<RealTimePaymentsRequestForPayment>
{
    /// <inheritdoc/>
    public RealTimePaymentsRequestForPayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsRequestForPayment.FromRawUnchecked(rawData);
}

/// <summary>
/// If a cancellation has been requested, this will contain supplemental details.
/// The request for payment moves to `canceled` once the recipient bank acknowledges
/// the cancellation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cancellation, CancellationFromRaw>))]
public sealed record class Cancellation : JsonModel
{
    /// <summary>
    /// Additional information about the cancellation, sent on to the recipient bank.
    /// </summary>
    public required string? AdditionalInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("additional_information");
        }
        init { this._rawData.Set("additional_information", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the cancellation was requested.
    /// </summary>
    public required System::DateTimeOffset CanceledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("canceled_at");
        }
        init { this._rawData.Set("canceled_at", value); }
    }

    /// <summary>
    /// The reason the request for payment was canceled.
    /// </summary>
    public required ApiEnum<string, CancellationReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CancellationReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdditionalInformation;
        _ = this.CanceledAt;
        this.Reason.Validate();
    }

    public Cancellation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cancellation(Cancellation cancellation)
        : base(cancellation) { }
#pragma warning restore CS8618

    public Cancellation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cancellation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CancellationFromRaw.FromRawUnchecked"/>
    public static Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CancellationFromRaw : IFromRawJson<Cancellation>
{
    /// <inheritdoc/>
    public Cancellation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cancellation.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the request for payment was canceled.
/// </summary>
[JsonConverter(typeof(CancellationReasonConverter))]
public enum CancellationReason
{
    /// <summary>
    /// The creditor no longer wants to be paid. Corresponds to the Real-Time Payments
    /// reason code `CUST`.
    /// </summary>
    RequestedByCustomer,

    /// <summary>
    /// The requested payment has already been made through another channel. Corresponds
    /// to the Real-Time Payments reason code `UPAY`.
    /// </summary>
    PaidByOtherMeans,

    /// <summary>
    /// The request for payment duplicated another request for payment. Corresponds
    /// to the Real-Time Payments reason code `DUPL`.
    /// </summary>
    Duplicate,

    /// <summary>
    /// The request for payment was sent for the wrong amount. Corresponds to the
    /// Real-Time Payments reason code `AM09`.
    /// </summary>
    WrongAmount,
}

sealed class CancellationReasonConverter : JsonConverter<CancellationReason>
{
    public override CancellationReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requested_by_customer" => CancellationReason.RequestedByCustomer,
            "paid_by_other_means" => CancellationReason.PaidByOtherMeans,
            "duplicate" => CancellationReason.Duplicate,
            "wrong_amount" => CancellationReason.WrongAmount,
            _ => (CancellationReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationReason.RequestedByCustomer => "requested_by_customer",
                CancellationReason.PaidByOtherMeans => "paid_by_other_means",
                CancellationReason.Duplicate => "duplicate",
                CancellationReason.WrongAmount => "wrong_amount",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the transfer's
/// currency. For real-time payments transfers this is always equal to `USD`.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    /// <summary>
    /// US Dollar (USD)
    /// </summary>
    Usd,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.Usd,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "USD",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the person being requested to pay.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsRequestForPaymentDebtor,
        RealTimePaymentsRequestForPaymentDebtorFromRaw
    >)
)]
public sealed record class RealTimePaymentsRequestForPaymentDebtor : JsonModel
{
    /// <summary>
    /// Address of the debtor.
    /// </summary>
    public required RealTimePaymentsRequestForPaymentDebtorAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RealTimePaymentsRequestForPaymentDebtorAddress>(
                "address"
            );
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The name of the debtor.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.Name;
    }

    public RealTimePaymentsRequestForPaymentDebtor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestForPaymentDebtor(
        RealTimePaymentsRequestForPaymentDebtor realTimePaymentsRequestForPaymentDebtor
    )
        : base(realTimePaymentsRequestForPaymentDebtor) { }
#pragma warning restore CS8618

    public RealTimePaymentsRequestForPaymentDebtor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsRequestForPaymentDebtor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsRequestForPaymentDebtorFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsRequestForPaymentDebtor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsRequestForPaymentDebtorFromRaw
    : IFromRawJson<RealTimePaymentsRequestForPaymentDebtor>
{
    /// <inheritdoc/>
    public RealTimePaymentsRequestForPaymentDebtor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsRequestForPaymentDebtor.FromRawUnchecked(rawData);
}

/// <summary>
/// Address of the debtor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RealTimePaymentsRequestForPaymentDebtorAddress,
        RealTimePaymentsRequestForPaymentDebtorAddressFromRaw
    >)
)]
public sealed record class RealTimePaymentsRequestForPaymentDebtorAddress : JsonModel
{
    /// <summary>
    /// A second address line, such as an apartment or suite number. The first address
    /// line is separated into `building_number` and `street_name`.
    /// </summary>
    public required string? AddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address_line2");
        }
        init { this._rawData.Set("address_line2", value); }
    }

    /// <summary>
    /// The number identifying the position of the building on the street.
    /// </summary>
    public required string? BuildingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("building_number");
        }
        init { this._rawData.Set("building_number", value); }
    }

    /// <summary>
    /// The town or city.
    /// </summary>
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The ISO 3166, Alpha-2 country code.
    /// </summary>
    public required string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The postal code or zip.
    /// </summary>
    public required string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The US state component of the address.
    /// </summary>
    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The street name without the street number.
    /// </summary>
    public required string? StreetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street_name");
        }
        init { this._rawData.Set("street_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddressLine2;
        _ = this.BuildingNumber;
        _ = this.City;
        _ = this.Country;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.StreetName;
    }

    public RealTimePaymentsRequestForPaymentDebtorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestForPaymentDebtorAddress(
        RealTimePaymentsRequestForPaymentDebtorAddress realTimePaymentsRequestForPaymentDebtorAddress
    )
        : base(realTimePaymentsRequestForPaymentDebtorAddress) { }
#pragma warning restore CS8618

    public RealTimePaymentsRequestForPaymentDebtorAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RealTimePaymentsRequestForPaymentDebtorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RealTimePaymentsRequestForPaymentDebtorAddressFromRaw.FromRawUnchecked"/>
    public static RealTimePaymentsRequestForPaymentDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RealTimePaymentsRequestForPaymentDebtorAddressFromRaw
    : IFromRawJson<RealTimePaymentsRequestForPaymentDebtorAddress>
{
    /// <inheritdoc/>
    public RealTimePaymentsRequestForPaymentDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RealTimePaymentsRequestForPaymentDebtorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// If the request for payment is refused by the destination financial institution
/// or the receiving customer, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Refusal, RefusalFromRaw>))]
public sealed record class Refusal : JsonModel
{
    /// <summary>
    /// Additional information about the refusal provided by the recipient bank or
    /// the customer. This is typically present when the `refusal_reason_code` is `other`.
    /// </summary>
    public required string? RefusalReasonAdditionalInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("refusal_reason_additional_information");
        }
        init { this._rawData.Set("refusal_reason_additional_information", value); }
    }

    /// <summary>
    /// The reason the request for payment was refused as provided by the recipient
    /// bank or the customer.
    /// </summary>
    public required ApiEnum<string, RefusalReasonCode> RefusalReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RefusalReasonCode>>(
                "refusal_reason_code"
            );
        }
        init { this._rawData.Set("refusal_reason_code", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the request for payment was refused.
    /// </summary>
    public required System::DateTimeOffset? RefusedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("refused_at");
        }
        init { this._rawData.Set("refused_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RefusalReasonAdditionalInformation;
        this.RefusalReasonCode.Validate();
        _ = this.RefusedAt;
    }

    public Refusal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Refusal(Refusal refusal)
        : base(refusal) { }
#pragma warning restore CS8618

    public Refusal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Refusal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefusalFromRaw.FromRawUnchecked"/>
    public static Refusal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefusalFromRaw : IFromRawJson<Refusal>
{
    /// <inheritdoc/>
    public Refusal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Refusal.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the request for payment was refused as provided by the recipient bank
/// or the customer.
/// </summary>
[JsonConverter(typeof(RefusalReasonCodeConverter))]
public enum RefusalReasonCode
{
    /// <summary>
    /// The destination account is currently blocked from receiving transactions.
    /// Corresponds to the Real-Time Payments reason code `AC06`.
    /// </summary>
    AccountBlocked,

    /// <summary>
    /// Real-Time Payments transfers are not allowed to the destination account.
    /// Corresponds to the Real-Time Payments reason code `AG01`.
    /// </summary>
    TransactionForbidden,

    /// <summary>
    /// Real-Time Payments transfers are not enabled for the destination account.
    /// Corresponds to the Real-Time Payments reason code `AG03`.
    /// </summary>
    TransactionTypeNotSupported,

    /// <summary>
    /// The amount of the transfer is different than expected by the recipient. Corresponds
    /// to the Real-Time Payments reason code `AM09`.
    /// </summary>
    UnexpectedAmount,

    /// <summary>
    /// The amount is higher than the recipient is authorized to send or receive.
    /// Corresponds to the Real-Time Payments reason code `AM14`.
    /// </summary>
    AmountExceedsBankLimits,

    /// <summary>
    /// The debtor's address is required, but missing or invalid. Corresponds to the
    /// Real-Time Payments reason code `BE07`.
    /// </summary>
    InvalidDebtorAddress,

    /// <summary>
    /// The creditor's address is required, but missing or invalid. Corresponds to
    /// the Real-Time Payments reason code `BE04`.
    /// </summary>
    InvalidCreditorAddress,

    /// <summary>
    /// Creditor identifier incorrect. Corresponds to the Real-Time Payments reason
    /// code `CH11`.
    /// </summary>
    CreditorIdentifierIncorrect,

    /// <summary>
    /// The customer refused the request. Corresponds to the Real-Time Payments reason
    /// code `CUST`.
    /// </summary>
    RequestedByCustomer,

    /// <summary>
    /// The order was rejected. Corresponds to the Real-Time Payments reason code `DS04`.
    /// </summary>
    OrderRejected,

    /// <summary>
    /// The destination account holder is deceased. Corresponds to the Real-Time
    /// Payments reason code `MD07`.
    /// </summary>
    EndCustomerDeceased,

    /// <summary>
    /// The customer has opted out of receiving requests for payments from this creditor.
    /// Corresponds to the Real-Time Payments reason code `SL12`.
    /// </summary>
    CustomerHasOptedOut,

    /// <summary>
    /// Some other error or issue has occurred.
    /// </summary>
    Other,
}

sealed class RefusalReasonCodeConverter : JsonConverter<RefusalReasonCode>
{
    public override RefusalReasonCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_blocked" => RefusalReasonCode.AccountBlocked,
            "transaction_forbidden" => RefusalReasonCode.TransactionForbidden,
            "transaction_type_not_supported" => RefusalReasonCode.TransactionTypeNotSupported,
            "unexpected_amount" => RefusalReasonCode.UnexpectedAmount,
            "amount_exceeds_bank_limits" => RefusalReasonCode.AmountExceedsBankLimits,
            "invalid_debtor_address" => RefusalReasonCode.InvalidDebtorAddress,
            "invalid_creditor_address" => RefusalReasonCode.InvalidCreditorAddress,
            "creditor_identifier_incorrect" => RefusalReasonCode.CreditorIdentifierIncorrect,
            "requested_by_customer" => RefusalReasonCode.RequestedByCustomer,
            "order_rejected" => RefusalReasonCode.OrderRejected,
            "end_customer_deceased" => RefusalReasonCode.EndCustomerDeceased,
            "customer_has_opted_out" => RefusalReasonCode.CustomerHasOptedOut,
            "other" => RefusalReasonCode.Other,
            _ => (RefusalReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RefusalReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RefusalReasonCode.AccountBlocked => "account_blocked",
                RefusalReasonCode.TransactionForbidden => "transaction_forbidden",
                RefusalReasonCode.TransactionTypeNotSupported => "transaction_type_not_supported",
                RefusalReasonCode.UnexpectedAmount => "unexpected_amount",
                RefusalReasonCode.AmountExceedsBankLimits => "amount_exceeds_bank_limits",
                RefusalReasonCode.InvalidDebtorAddress => "invalid_debtor_address",
                RefusalReasonCode.InvalidCreditorAddress => "invalid_creditor_address",
                RefusalReasonCode.CreditorIdentifierIncorrect => "creditor_identifier_incorrect",
                RefusalReasonCode.RequestedByCustomer => "requested_by_customer",
                RefusalReasonCode.OrderRejected => "order_rejected",
                RefusalReasonCode.EndCustomerDeceased => "end_customer_deceased",
                RefusalReasonCode.CustomerHasOptedOut => "customer_has_opted_out",
                RefusalReasonCode.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the request for payment is rejected by Real-Time Payments or the destination
/// financial institution, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rejection, RejectionFromRaw>))]
public sealed record class Rejection : JsonModel
{
    /// <summary>
    /// Additional information about the rejection provided by the recipient bank
    /// or the Real-Time Payments network. This is typically present when the `reject_reason_code`
    /// is `narrative`.
    /// </summary>
    public required string? RejectReasonAdditionalInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reject_reason_additional_information");
        }
        init { this._rawData.Set("reject_reason_additional_information", value); }
    }

    /// <summary>
    /// The reason the request for payment was rejected as provided by the recipient
    /// bank or the Real-Time Payments network.
    /// </summary>
    public required ApiEnum<string, RejectReasonCode> RejectReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RejectReasonCode>>(
                "reject_reason_code"
            );
        }
        init { this._rawData.Set("reject_reason_code", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the request for payment was rejected.
    /// </summary>
    public required System::DateTimeOffset? RejectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("rejected_at");
        }
        init { this._rawData.Set("rejected_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RejectReasonAdditionalInformation;
        this.RejectReasonCode.Validate();
        _ = this.RejectedAt;
    }

    public Rejection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rejection(Rejection rejection)
        : base(rejection) { }
#pragma warning restore CS8618

    public Rejection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rejection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RejectionFromRaw.FromRawUnchecked"/>
    public static Rejection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RejectionFromRaw : IFromRawJson<Rejection>
{
    /// <inheritdoc/>
    public Rejection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rejection.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the request for payment was rejected as provided by the recipient bank
/// or the Real-Time Payments network.
/// </summary>
[JsonConverter(typeof(RejectReasonCodeConverter))]
public enum RejectReasonCode
{
    /// <summary>
    /// The destination account is closed. Corresponds to the Real-Time Payments
    /// reason code "AC04".
    /// </summary>
    AccountClosed,

    /// <summary>
    /// The destination account is currently blocked from receiving transactions.
    /// Corresponds to the Real-Time Payments reason code "AC06".
    /// </summary>
    AccountBlocked,

    /// <summary>
    /// The destination account is ineligible to receive Real-Time Payments transfers.
    /// Corresponds to the Real-Time Payments reason code "AC14".
    /// </summary>
    InvalidCreditorAccountType,

    /// <summary>
    /// The destination account does not exist. Corresponds to the Real-Time Payments
    /// reason code "AC03".
    /// </summary>
    InvalidCreditorAccountNumber,

    /// <summary>
    /// The destination routing number is invalid. Corresponds to the Real-Time Payments
    /// reason code "RC04".
    /// </summary>
    InvalidCreditorFinancialInstitutionIdentifier,

    /// <summary>
    /// The destination account holder is deceased. Corresponds to the Real-Time
    /// Payments reason code "MD07".
    /// </summary>
    EndCustomerDeceased,

    /// <summary>
    /// The reason is provided as narrative information in the additional information field.
    /// </summary>
    Narrative,

    /// <summary>
    /// Real-Time Payments transfers are not allowed to the destination account.
    /// Corresponds to the Real-Time Payments reason code "AG01".
    /// </summary>
    TransactionForbidden,

    /// <summary>
    /// Real-Time Payments transfers are not enabled for the destination account.
    /// Corresponds to the Real-Time Payments reason code "AG03".
    /// </summary>
    TransactionTypeNotSupported,

    /// <summary>
    /// The amount of the transfer is different than expected by the recipient. Corresponds
    /// to the Real-Time Payments reason code "AM09".
    /// </summary>
    UnexpectedAmount,

    /// <summary>
    /// The amount is higher than the recipient is authorized to send or receive.
    /// Corresponds to the Real-Time Payments reason code "AM14".
    /// </summary>
    AmountExceedsBankLimits,

    /// <summary>
    /// The creditor's address is required, but missing or invalid. Corresponds to
    /// the Real-Time Payments reason code "BE04".
    /// </summary>
    InvalidCreditorAddress,

    /// <summary>
    /// The specified creditor is unknown. Corresponds to the Real-Time Payments
    /// reason code "BE06".
    /// </summary>
    UnknownEndCustomer,

    /// <summary>
    /// The debtor's address is required, but missing or invalid. Corresponds to the
    /// Real-Time Payments reason code "BE07".
    /// </summary>
    InvalidDebtorAddress,

    /// <summary>
    /// There was a timeout processing the transfer. Corresponds to the Real-Time
    /// Payments reason code "DS24".
    /// </summary>
    Timeout,

    /// <summary>
    /// Real-Time Payments transfers are not enabled for the destination account.
    /// Corresponds to the Real-Time Payments reason code "NOAT".
    /// </summary>
    UnsupportedMessageForRecipient,

    /// <summary>
    /// The destination financial institution is currently not connected to Real-Time
    /// Payments. Corresponds to the Real-Time Payments reason code "9912".
    /// </summary>
    RecipientConnectionNotAvailable,

    /// <summary>
    /// Real-Time Payments is currently unavailable. Corresponds to the Real-Time
    /// Payments reason code "9948".
    /// </summary>
    RealTimePaymentsSuspended,

    /// <summary>
    /// The destination financial institution is currently signed off of Real-Time
    /// Payments. Corresponds to the Real-Time Payments reason code "9910".
    /// </summary>
    InstructedAgentSignedOff,

    /// <summary>
    /// The transfer was rejected due to an internal Increase issue. We have been notified.
    /// </summary>
    ProcessingError,

    /// <summary>
    /// Some other error or issue has occurred.
    /// </summary>
    Other,
}

sealed class RejectReasonCodeConverter : JsonConverter<RejectReasonCode>
{
    public override RejectReasonCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_closed" => RejectReasonCode.AccountClosed,
            "account_blocked" => RejectReasonCode.AccountBlocked,
            "invalid_creditor_account_type" => RejectReasonCode.InvalidCreditorAccountType,
            "invalid_creditor_account_number" => RejectReasonCode.InvalidCreditorAccountNumber,
            "invalid_creditor_financial_institution_identifier" =>
                RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier,
            "end_customer_deceased" => RejectReasonCode.EndCustomerDeceased,
            "narrative" => RejectReasonCode.Narrative,
            "transaction_forbidden" => RejectReasonCode.TransactionForbidden,
            "transaction_type_not_supported" => RejectReasonCode.TransactionTypeNotSupported,
            "unexpected_amount" => RejectReasonCode.UnexpectedAmount,
            "amount_exceeds_bank_limits" => RejectReasonCode.AmountExceedsBankLimits,
            "invalid_creditor_address" => RejectReasonCode.InvalidCreditorAddress,
            "unknown_end_customer" => RejectReasonCode.UnknownEndCustomer,
            "invalid_debtor_address" => RejectReasonCode.InvalidDebtorAddress,
            "timeout" => RejectReasonCode.Timeout,
            "unsupported_message_for_recipient" => RejectReasonCode.UnsupportedMessageForRecipient,
            "recipient_connection_not_available" =>
                RejectReasonCode.RecipientConnectionNotAvailable,
            "real_time_payments_suspended" => RejectReasonCode.RealTimePaymentsSuspended,
            "instructed_agent_signed_off" => RejectReasonCode.InstructedAgentSignedOff,
            "processing_error" => RejectReasonCode.ProcessingError,
            "other" => RejectReasonCode.Other,
            _ => (RejectReasonCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RejectReasonCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RejectReasonCode.AccountClosed => "account_closed",
                RejectReasonCode.AccountBlocked => "account_blocked",
                RejectReasonCode.InvalidCreditorAccountType => "invalid_creditor_account_type",
                RejectReasonCode.InvalidCreditorAccountNumber => "invalid_creditor_account_number",
                RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier =>
                    "invalid_creditor_financial_institution_identifier",
                RejectReasonCode.EndCustomerDeceased => "end_customer_deceased",
                RejectReasonCode.Narrative => "narrative",
                RejectReasonCode.TransactionForbidden => "transaction_forbidden",
                RejectReasonCode.TransactionTypeNotSupported => "transaction_type_not_supported",
                RejectReasonCode.UnexpectedAmount => "unexpected_amount",
                RejectReasonCode.AmountExceedsBankLimits => "amount_exceeds_bank_limits",
                RejectReasonCode.InvalidCreditorAddress => "invalid_creditor_address",
                RejectReasonCode.UnknownEndCustomer => "unknown_end_customer",
                RejectReasonCode.InvalidDebtorAddress => "invalid_debtor_address",
                RejectReasonCode.Timeout => "timeout",
                RejectReasonCode.UnsupportedMessageForRecipient =>
                    "unsupported_message_for_recipient",
                RejectReasonCode.RecipientConnectionNotAvailable =>
                    "recipient_connection_not_available",
                RejectReasonCode.RealTimePaymentsSuspended => "real_time_payments_suspended",
                RejectReasonCode.InstructedAgentSignedOff => "instructed_agent_signed_off",
                RejectReasonCode.ProcessingError => "processing_error",
                RejectReasonCode.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lifecycle status of the request for payment.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The request for payment is queued to be submitted to Real-Time Payments.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The request for payment has been submitted and is pending a response from
    /// Real-Time Payments.
    /// </summary>
    PendingResponse,

    /// <summary>
    /// The request for payment was rejected by the network or the recipient.
    /// </summary>
    Rejected,

    /// <summary>
    /// The request for payment was accepted by the recipient but has not yet been paid.
    /// </summary>
    Accepted,

    /// <summary>
    /// The request for payment was refused by the recipient.
    /// </summary>
    Refused,

    /// <summary>
    /// The request for payment was fulfilled by the receiver.
    /// </summary>
    Fulfilled,

    /// <summary>
    /// The request for payment was canceled and can no longer be paid.
    /// </summary>
    Canceled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_submission" => Status.PendingSubmission,
            "pending_response" => Status.PendingResponse,
            "rejected" => Status.Rejected,
            "accepted" => Status.Accepted,
            "refused" => Status.Refused,
            "fulfilled" => Status.Fulfilled,
            "canceled" => Status.Canceled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.PendingSubmission => "pending_submission",
                Status.PendingResponse => "pending_response",
                Status.Rejected => "rejected",
                Status.Accepted => "accepted",
                Status.Refused => "refused",
                Status.Fulfilled => "fulfilled",
                Status.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the request for payment is submitted to Real-Time Payments, this will contain
/// supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The Real-Time Payments payment information identification of the request.
    /// </summary>
    public required string PaymentInformationIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("payment_information_identification");
        }
        init { this._rawData.Set("payment_information_identification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PaymentInformationIdentification;
    }

    public Submission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Submission(Submission submission)
        : base(submission) { }
#pragma warning restore CS8618

    public Submission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Submission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubmissionFromRaw.FromRawUnchecked"/>
    public static Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Submission(string paymentInformationIdentification)
        : this()
    {
        this.PaymentInformationIdentification = paymentInformationIdentification;
    }
}

class SubmissionFromRaw : IFromRawJson<Submission>
{
    /// <inheritdoc/>
    public Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Submission.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `real_time_payments_request_for_payment`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    RealTimePaymentsRequestForPayment,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.RealTimePaymentsRequestsForPayment.Type>
{
    public override global::Increase.Api.Models.RealTimePaymentsRequestsForPayment.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "real_time_payments_request_for_payment" => global::Increase
                .Api
                .Models
                .RealTimePaymentsRequestsForPayment
                .Type
                .RealTimePaymentsRequestForPayment,
            _ => (global::Increase.Api.Models.RealTimePaymentsRequestsForPayment.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.RealTimePaymentsRequestsForPayment.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase
                    .Api
                    .Models
                    .RealTimePaymentsRequestsForPayment
                    .Type
                    .RealTimePaymentsRequestForPayment => "real_time_payments_request_for_payment",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
