using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

/// <summary>
/// An Inbound Real-Time Payments Request for Payment is a request initiated outside
/// of Increase for one of your accounts to send a Real-Time Payments transfer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InboundRealTimePaymentsRequestForPayment,
        InboundRealTimePaymentsRequestForPaymentFromRaw
    >)
)]
public sealed record class InboundRealTimePaymentsRequestForPayment : JsonModel
{
    /// <summary>
    /// The inbound Real-Time Payments request for payment's identifier.
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
    /// The Account the request for payment is for.
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
    /// The identifier of the Account Number the request for payment is for.
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
    /// The requested amount in USD cents.
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
    /// Details of the party requesting payment.
    /// </summary>
    public required Creditor Creditor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Creditor>("creditor");
        }
        init { this._rawData.Set("creditor", value); }
    }

    /// <summary>
    /// The creditor's account number.
    /// </summary>
    public required string CreditorAccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_account_number");
        }
        init { this._rawData.Set("creditor_account_number", value); }
    }

    /// <summary>
    /// The creditor's American Bankers' Association (ABA) Routing Transit Number (RTN).
    /// </summary>
    public required string CreditorRoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditor_routing_number");
        }
        init { this._rawData.Set("creditor_routing_number", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the requested
    /// currency. This will always be "USD" for a Real-Time Payments request for payment.
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
    /// The name of the account holder the payment is requested from, as provided
    /// by the creditor.
    /// </summary>
    public required string DebtorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("debtor_name");
        }
        init { this._rawData.Set("debtor_name", value); }
    }

    /// <summary>
    /// A free-form reference string set by the creditor, to help identify the request
    /// for payment.
    /// </summary>
    public required string EndToEndIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("end_to_end_identification");
        }
        init { this._rawData.Set("end_to_end_identification", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time after
    /// which the request for payment is no longer valid and should no longer be paid.
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
    /// The identifier of the Real-Time Payments Transfer that fulfilled this request
    /// for payment. This is set once a transfer sent in response to the request for
    /// payment has been acknowledged by the Real-Time Payments network.
    /// </summary>
    public required string? FulfillmentRealTimePaymentsTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fulfillment_real_time_payments_transfer_id"
            );
        }
        init { this._rawData.Set("fulfillment_real_time_payments_transfer_id", value); }
    }

    /// <summary>
    /// An identifier for the party that issued the invoice, for requests for payment
    /// sent on behalf of another party.
    /// </summary>
    public required string? InvoicerIdentification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoicer_identification");
        }
        init { this._rawData.Set("invoicer_identification", value); }
    }

    /// <summary>
    /// The Real-Time Payments network identification of the request for payment.
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

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time by which
    /// the creditor requests the payment to be made.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `inbound_real_time_payments_request_for_payment`.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment.Type
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Unstructured information included with the request for payment.
    /// </summary>
    public required string? UnstructuredRemittanceInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unstructured_remittance_information");
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
        _ = this.CreatedAt;
        this.Creditor.Validate();
        _ = this.CreditorAccountNumber;
        _ = this.CreditorRoutingNumber;
        this.Currency.Validate();
        _ = this.DebtorName;
        _ = this.EndToEndIdentification;
        _ = this.ExpiresAt;
        _ = this.FulfillmentRealTimePaymentsTransferID;
        _ = this.InvoicerIdentification;
        _ = this.PaymentInformationIdentification;
        _ = this.RequestedExecutionAt;
        this.Type.Validate();
        _ = this.UnstructuredRemittanceInformation;
    }

    public InboundRealTimePaymentsRequestForPayment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundRealTimePaymentsRequestForPayment(
        InboundRealTimePaymentsRequestForPayment inboundRealTimePaymentsRequestForPayment
    )
        : base(inboundRealTimePaymentsRequestForPayment) { }
#pragma warning restore CS8618

    public InboundRealTimePaymentsRequestForPayment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundRealTimePaymentsRequestForPayment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundRealTimePaymentsRequestForPaymentFromRaw.FromRawUnchecked"/>
    public static InboundRealTimePaymentsRequestForPayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundRealTimePaymentsRequestForPaymentFromRaw
    : IFromRawJson<InboundRealTimePaymentsRequestForPayment>
{
    /// <inheritdoc/>
    public InboundRealTimePaymentsRequestForPayment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundRealTimePaymentsRequestForPayment.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the party requesting payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Creditor, CreditorFromRaw>))]
public sealed record class Creditor : JsonModel
{
    /// <summary>
    /// The name of the account that would receive the payment, as provided by the creditor.
    /// </summary>
    public required string? AccountName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_name");
        }
        init { this._rawData.Set("account_name", value); }
    }

    /// <summary>
    /// Address of the creditor.
    /// </summary>
    public required Address Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The name of the creditor.
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
        _ = this.AccountName;
        this.Address.Validate();
        _ = this.Name;
    }

    public Creditor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Creditor(Creditor creditor)
        : base(creditor) { }
#pragma warning restore CS8618

    public Creditor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Creditor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditorFromRaw.FromRawUnchecked"/>
    public static Creditor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditorFromRaw : IFromRawJson<Creditor>
{
    /// <inheritdoc/>
    public Creditor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Creditor.FromRawUnchecked(rawData);
}

/// <summary>
/// Address of the creditor.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
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

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}

/// <summary>
/// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code of the requested currency.
/// This will always be "USD" for a Real-Time Payments request for payment.
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
/// A constant representing the object's type. For this resource it will always be `inbound_real_time_payments_request_for_payment`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    InboundRealTimePaymentsRequestForPayment,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment.Type>
{
    public override global::Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_real_time_payments_request_for_payment" => global::Increase
                .Api
                .Models
                .InboundRealTimePaymentsRequestsForPayment
                .Type
                .InboundRealTimePaymentsRequestForPayment,
            _ => (global::Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment.Type value,
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
                    .InboundRealTimePaymentsRequestsForPayment
                    .Type
                    .InboundRealTimePaymentsRequestForPayment =>
                    "inbound_real_time_payments_request_for_payment",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
