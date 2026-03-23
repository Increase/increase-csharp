using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.InboundAchTransfers;

/// <summary>
/// Return an Inbound ACH Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundAchTransferTransferReturnParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InboundAchTransferID { get; init; }

    /// <summary>
    /// The reason why this transfer will be returned. The most usual return codes
    /// are `payment_stopped` for debits and `credit_entry_refused_by_receiver` for credits.
    /// </summary>
    public required ApiEnum<string, InboundAchTransferTransferReturnParamsReason> Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, InboundAchTransferTransferReturnParamsReason>
            >("reason");
        }
        init { this._rawBodyData.Set("reason", value); }
    }

    public InboundAchTransferTransferReturnParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransferTransferReturnParams(
        InboundAchTransferTransferReturnParams inboundAchTransferTransferReturnParams
    )
        : base(inboundAchTransferTransferReturnParams)
    {
        this.InboundAchTransferID = inboundAchTransferTransferReturnParams.InboundAchTransferID;

        this._rawBodyData = new(inboundAchTransferTransferReturnParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundAchTransferTransferReturnParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundAchTransferTransferReturnParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string inboundAchTransferID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InboundAchTransferID = inboundAchTransferID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboundAchTransferTransferReturnParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string inboundAchTransferID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            inboundAchTransferID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InboundAchTransferID"] = JsonSerializer.SerializeToElement(
                        this.InboundAchTransferID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InboundAchTransferTransferReturnParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.InboundAchTransferID?.Equals(other.InboundAchTransferID)
                ?? other.InboundAchTransferID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/inbound_ach_transfers/{0}/transfer_return",
                    this.InboundAchTransferID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// The reason why this transfer will be returned. The most usual return codes are
/// `payment_stopped` for debits and `credit_entry_refused_by_receiver` for credits.
/// </summary>
[JsonConverter(typeof(InboundAchTransferTransferReturnParamsReasonConverter))]
public enum InboundAchTransferTransferReturnParamsReason
{
    /// <summary>
    /// The customer's account has insufficient funds. This reason is only allowed
    /// for debits. The Nacha return code is R01.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// The customer no longer authorizes this transaction. The Nacha return code
    /// is R07.
    /// </summary>
    AuthorizationRevokedByCustomer,

    /// <summary>
    /// The customer asked for the payment to be stopped. This reason is only allowed
    /// for debits. The Nacha return code is R08.
    /// </summary>
    PaymentStopped,

    /// <summary>
    /// The customer advises that the debit was unauthorized. The Nacha return code
    /// is R10.
    /// </summary>
    CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,

    /// <summary>
    /// The payee is deceased. The Nacha return code is R14.
    /// </summary>
    RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,

    /// <summary>
    /// The account holder is deceased. The Nacha return code is R15.
    /// </summary>
    BeneficiaryOrAccountHolderDeceased,

    /// <summary>
    /// The customer refused a credit entry. This reason is only allowed for credits.
    /// The Nacha return code is R23.
    /// </summary>
    CreditEntryRefusedByReceiver,

    /// <summary>
    /// The account holder identified this transaction as a duplicate. The Nacha return
    /// code is R24.
    /// </summary>
    DuplicateEntry,

    /// <summary>
    /// The corporate customer no longer authorizes this transaction. The Nacha return
    /// code is R29.
    /// </summary>
    CorporateCustomerAdvisedNotAuthorized,
}

sealed class InboundAchTransferTransferReturnParamsReasonConverter
    : JsonConverter<InboundAchTransferTransferReturnParamsReason>
{
    public override InboundAchTransferTransferReturnParamsReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => InboundAchTransferTransferReturnParamsReason.InsufficientFunds,
            "authorization_revoked_by_customer" =>
                InboundAchTransferTransferReturnParamsReason.AuthorizationRevokedByCustomer,
            "payment_stopped" => InboundAchTransferTransferReturnParamsReason.PaymentStopped,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                InboundAchTransferTransferReturnParamsReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                InboundAchTransferTransferReturnParamsReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "beneficiary_or_account_holder_deceased" =>
                InboundAchTransferTransferReturnParamsReason.BeneficiaryOrAccountHolderDeceased,
            "credit_entry_refused_by_receiver" =>
                InboundAchTransferTransferReturnParamsReason.CreditEntryRefusedByReceiver,
            "duplicate_entry" => InboundAchTransferTransferReturnParamsReason.DuplicateEntry,
            "corporate_customer_advised_not_authorized" =>
                InboundAchTransferTransferReturnParamsReason.CorporateCustomerAdvisedNotAuthorized,
            _ => (InboundAchTransferTransferReturnParamsReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundAchTransferTransferReturnParamsReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InboundAchTransferTransferReturnParamsReason.InsufficientFunds =>
                    "insufficient_funds",
                InboundAchTransferTransferReturnParamsReason.AuthorizationRevokedByCustomer =>
                    "authorization_revoked_by_customer",
                InboundAchTransferTransferReturnParamsReason.PaymentStopped => "payment_stopped",
                InboundAchTransferTransferReturnParamsReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                InboundAchTransferTransferReturnParamsReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                InboundAchTransferTransferReturnParamsReason.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                InboundAchTransferTransferReturnParamsReason.CreditEntryRefusedByReceiver =>
                    "credit_entry_refused_by_receiver",
                InboundAchTransferTransferReturnParamsReason.DuplicateEntry => "duplicate_entry",
                InboundAchTransferTransferReturnParamsReason.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
