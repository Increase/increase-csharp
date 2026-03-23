using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.WireDrawdownRequests;

/// <summary>
/// Wire drawdown requests enable you to request that someone else send you a wire.
/// Because there is nuance to making sure your counterparty's bank processes these
/// correctly, we ask that you reach out to [support@increase.com](mailto:support@increase.com)
/// to enable this feature so we can help you plan your integration. For more information,
/// see our [Wire Drawdown Requests documentation](/documentation/wire-drawdown-requests).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WireDrawdownRequest, WireDrawdownRequestFromRaw>))]
public sealed record class WireDrawdownRequest : JsonModel
{
    /// <summary>
    /// The Wire drawdown request identifier.
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
    /// The Account Number to which the debtor—the recipient of this request—is being
    /// requested to send funds.
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
    /// The amount being requested in cents.
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
    /// the wire drawdown request was created.
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
    /// The creditor's address.
    /// </summary>
    public required WireDrawdownRequestCreditorAddress CreditorAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WireDrawdownRequestCreditorAddress>(
                "creditor_address"
            );
        }
        init { this._rawData.Set("creditor_address", value); }
    }

    /// <summary>
    /// The creditor's name.
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
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the amount
    /// being requested. Will always be "USD".
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The debtor's account number.
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
    /// The debtor's address.
    /// </summary>
    public required WireDrawdownRequestDebtorAddress DebtorAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WireDrawdownRequestDebtorAddress>(
                "debtor_address"
            );
        }
        init { this._rawData.Set("debtor_address", value); }
    }

    /// <summary>
    /// The debtor's external account identifier.
    /// </summary>
    public required string? DebtorExternalAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debtor_external_account_id");
        }
        init { this._rawData.Set("debtor_external_account_id", value); }
    }

    /// <summary>
    /// The debtor's name.
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
    /// The debtor's routing number.
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
    /// If the recipient fulfills the drawdown request by sending funds, then this
    /// will be the identifier of the corresponding Transaction.
    /// </summary>
    public required string? FulfillmentInboundWireTransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fulfillment_inbound_wire_transfer_id");
        }
        init { this._rawData.Set("fulfillment_inbound_wire_transfer_id", value); }
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
    /// The lifecycle status of the drawdown request.
    /// </summary>
    public required ApiEnum<string, WireDrawdownRequestStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WireDrawdownRequestStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// After the drawdown request is submitted to Fedwire, this will contain supplemental details.
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
    /// be `wire_drawdown_request`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.WireDrawdownRequests.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.WireDrawdownRequests.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Remittance information the debtor will see as part of the drawdown request.
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
        _ = this.AccountNumberID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.CreditorAddress.Validate();
        _ = this.CreditorName;
        _ = this.Currency;
        _ = this.DebtorAccountNumber;
        this.DebtorAddress.Validate();
        _ = this.DebtorExternalAccountID;
        _ = this.DebtorName;
        _ = this.DebtorRoutingNumber;
        _ = this.FulfillmentInboundWireTransferID;
        _ = this.IdempotencyKey;
        this.Status.Validate();
        this.Submission?.Validate();
        this.Type.Validate();
        _ = this.UnstructuredRemittanceInformation;
    }

    public WireDrawdownRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequest(WireDrawdownRequest wireDrawdownRequest)
        : base(wireDrawdownRequest) { }
#pragma warning restore CS8618

    public WireDrawdownRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireDrawdownRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireDrawdownRequestFromRaw.FromRawUnchecked"/>
    public static WireDrawdownRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireDrawdownRequestFromRaw : IFromRawJson<WireDrawdownRequest>
{
    /// <inheritdoc/>
    public WireDrawdownRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WireDrawdownRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// The creditor's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WireDrawdownRequestCreditorAddress,
        WireDrawdownRequestCreditorAddressFromRaw
    >)
)]
public sealed record class WireDrawdownRequestCreditorAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The two-letter [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code for the country of the address.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The first line of the address.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
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
    /// The address state.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public WireDrawdownRequestCreditorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequestCreditorAddress(
        WireDrawdownRequestCreditorAddress wireDrawdownRequestCreditorAddress
    )
        : base(wireDrawdownRequestCreditorAddress) { }
#pragma warning restore CS8618

    public WireDrawdownRequestCreditorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireDrawdownRequestCreditorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireDrawdownRequestCreditorAddressFromRaw.FromRawUnchecked"/>
    public static WireDrawdownRequestCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireDrawdownRequestCreditorAddressFromRaw : IFromRawJson<WireDrawdownRequestCreditorAddress>
{
    /// <inheritdoc/>
    public WireDrawdownRequestCreditorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireDrawdownRequestCreditorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The debtor's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WireDrawdownRequestDebtorAddress,
        WireDrawdownRequestDebtorAddressFromRaw
    >)
)]
public sealed record class WireDrawdownRequestDebtorAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The two-letter [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code for the country of the address.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The first line of the address.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
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
    /// The address state.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public WireDrawdownRequestDebtorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireDrawdownRequestDebtorAddress(
        WireDrawdownRequestDebtorAddress wireDrawdownRequestDebtorAddress
    )
        : base(wireDrawdownRequestDebtorAddress) { }
#pragma warning restore CS8618

    public WireDrawdownRequestDebtorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WireDrawdownRequestDebtorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WireDrawdownRequestDebtorAddressFromRaw.FromRawUnchecked"/>
    public static WireDrawdownRequestDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WireDrawdownRequestDebtorAddressFromRaw : IFromRawJson<WireDrawdownRequestDebtorAddress>
{
    /// <inheritdoc/>
    public WireDrawdownRequestDebtorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WireDrawdownRequestDebtorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The lifecycle status of the drawdown request.
/// </summary>
[JsonConverter(typeof(WireDrawdownRequestStatusConverter))]
public enum WireDrawdownRequestStatus
{
    /// <summary>
    /// The drawdown request is queued to be submitted to Fedwire.
    /// </summary>
    PendingSubmission,

    /// <summary>
    /// The drawdown request has been fulfilled by the recipient.
    /// </summary>
    Fulfilled,

    /// <summary>
    /// The drawdown request has been sent and the recipient should respond in some way.
    /// </summary>
    PendingResponse,

    /// <summary>
    /// The drawdown request has been refused by the recipient.
    /// </summary>
    Refused,
}

sealed class WireDrawdownRequestStatusConverter : JsonConverter<WireDrawdownRequestStatus>
{
    public override WireDrawdownRequestStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_submission" => WireDrawdownRequestStatus.PendingSubmission,
            "fulfilled" => WireDrawdownRequestStatus.Fulfilled,
            "pending_response" => WireDrawdownRequestStatus.PendingResponse,
            "refused" => WireDrawdownRequestStatus.Refused,
            _ => (WireDrawdownRequestStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WireDrawdownRequestStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WireDrawdownRequestStatus.PendingSubmission => "pending_submission",
                WireDrawdownRequestStatus.Fulfilled => "fulfilled",
                WireDrawdownRequestStatus.PendingResponse => "pending_response",
                WireDrawdownRequestStatus.Refused => "refused",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// After the drawdown request is submitted to Fedwire, this will contain supplemental details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Submission, SubmissionFromRaw>))]
public sealed record class Submission : JsonModel
{
    /// <summary>
    /// The input message accountability data (IMAD) uniquely identifying the submission
    /// with Fedwire.
    /// </summary>
    public required string InputMessageAccountabilityData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input_message_accountability_data");
        }
        init { this._rawData.Set("input_message_accountability_data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputMessageAccountabilityData;
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
    public Submission(string inputMessageAccountabilityData)
        : this()
    {
        this.InputMessageAccountabilityData = inputMessageAccountabilityData;
    }
}

class SubmissionFromRaw : IFromRawJson<Submission>
{
    /// <inheritdoc/>
    public Submission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Submission.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `wire_drawdown_request`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    WireDrawdownRequest,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.WireDrawdownRequests.Type>
{
    public override global::Increase.Api.Models.WireDrawdownRequests.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wire_drawdown_request" => global::Increase
                .Api
                .Models
                .WireDrawdownRequests
                .Type
                .WireDrawdownRequest,
            _ => (global::Increase.Api.Models.WireDrawdownRequests.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.WireDrawdownRequests.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.WireDrawdownRequests.Type.WireDrawdownRequest =>
                    "wire_drawdown_request",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
