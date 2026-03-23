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
/// Decline an Inbound ACH Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundAchTransferDeclineParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InboundAchTransferID { get; init; }

    /// <summary>
    /// The reason why this transfer will be returned. If this parameter is unset,
    /// the return codes will be `payment_stopped` for debits and `credit_entry_refused_by_receiver`
    /// for credits.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reason", value);
        }
    }

    public InboundAchTransferDeclineParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundAchTransferDeclineParams(
        InboundAchTransferDeclineParams inboundAchTransferDeclineParams
    )
        : base(inboundAchTransferDeclineParams)
    {
        this.InboundAchTransferID = inboundAchTransferDeclineParams.InboundAchTransferID;

        this._rawBodyData = new(inboundAchTransferDeclineParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundAchTransferDeclineParams(
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
    InboundAchTransferDeclineParams(
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
    public static InboundAchTransferDeclineParams FromRawUnchecked(
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

    public virtual bool Equals(InboundAchTransferDeclineParams? other)
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
                + string.Format("/inbound_ach_transfers/{0}/decline", this.InboundAchTransferID)
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
/// The reason why this transfer will be returned. If this parameter is unset, the
/// return codes will be `payment_stopped` for debits and `credit_entry_refused_by_receiver`
/// for credits.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The customer's account has insufficient funds. This reason is only allowed
    /// for debits. The Nacha return code is R01.
    /// </summary>
    InsufficientFunds,

    /// <summary>
    /// The originating financial institution asked for this transfer to be returned.
    /// The receiving bank is complying with the request. The Nacha return code is R06.
    /// </summary>
    ReturnedPerOdfiRequest,

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

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_funds" => Reason.InsufficientFunds,
            "returned_per_odfi_request" => Reason.ReturnedPerOdfiRequest,
            "authorization_revoked_by_customer" => Reason.AuthorizationRevokedByCustomer,
            "payment_stopped" => Reason.PaymentStopped,
            "customer_advised_unauthorized_improper_ineligible_or_incomplete" =>
                Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete,
            "representative_payee_deceased_or_unable_to_continue_in_that_capacity" =>
                Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity,
            "beneficiary_or_account_holder_deceased" => Reason.BeneficiaryOrAccountHolderDeceased,
            "credit_entry_refused_by_receiver" => Reason.CreditEntryRefusedByReceiver,
            "duplicate_entry" => Reason.DuplicateEntry,
            "corporate_customer_advised_not_authorized" =>
                Reason.CorporateCustomerAdvisedNotAuthorized,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.InsufficientFunds => "insufficient_funds",
                Reason.ReturnedPerOdfiRequest => "returned_per_odfi_request",
                Reason.AuthorizationRevokedByCustomer => "authorization_revoked_by_customer",
                Reason.PaymentStopped => "payment_stopped",
                Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete =>
                    "customer_advised_unauthorized_improper_ineligible_or_incomplete",
                Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity =>
                    "representative_payee_deceased_or_unable_to_continue_in_that_capacity",
                Reason.BeneficiaryOrAccountHolderDeceased =>
                    "beneficiary_or_account_holder_deceased",
                Reason.CreditEntryRefusedByReceiver => "credit_entry_refused_by_receiver",
                Reason.DuplicateEntry => "duplicate_entry",
                Reason.CorporateCustomerAdvisedNotAuthorized =>
                    "corporate_customer_advised_not_authorized",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
