using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CheckTransfers;

/// <summary>
/// Create a Check Transfer
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CheckTransferCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier for the account that will send the transfer.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_id");
        }
        init { this._rawBodyData.Set("account_id", value); }
    }

    /// <summary>
    /// The transfer amount in USD cents.
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// Whether Increase will print and mail the check or if you will do it yourself.
    /// </summary>
    public required ApiEnum<string, FulfillmentMethod> FulfillmentMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, FulfillmentMethod>>(
                "fulfillment_method"
            );
        }
        init { this._rawBodyData.Set("fulfillment_method", value); }
    }

    /// <summary>
    /// The identifier of the Account Number from which to send the transfer and print
    /// on the check.
    /// </summary>
    public required string SourceAccountNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("source_account_number_id");
        }
        init { this._rawBodyData.Set("source_account_number_id", value); }
    }

    /// <summary>
    /// How the account's available balance should be checked. If omitted, the default
    /// behavior is `balance_check: full`.
    /// </summary>
    public ApiEnum<string, BalanceCheck>? BalanceCheck
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BalanceCheck>>(
                "balance_check"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("balance_check", value);
        }
    }

    /// <summary>
    /// The check number Increase should use for the check. This should not contain
    /// leading zeroes and must be unique across the `source_account_number`. If this
    /// is omitted, Increase will generate a check number for you.
    /// </summary>
    public string? CheckNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("check_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("check_number", value);
        }
    }

    /// <summary>
    /// Details relating to the physical check that Increase will print and mail.
    /// This is required if `fulfillment_method` is equal to `physical_check`. It
    /// must not be included if any other `fulfillment_method` is provided.
    /// </summary>
    public PhysicalCheck? PhysicalCheck
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PhysicalCheck>("physical_check");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("physical_check", value);
        }
    }

    /// <summary>
    /// Whether the transfer requires explicit approval via the dashboard or API.
    /// </summary>
    public bool? RequireApproval
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("require_approval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("require_approval", value);
        }
    }

    /// <summary>
    /// Details relating to the custom fulfillment you will perform. This is required
    /// if `fulfillment_method` is equal to `third_party`. It must not be included
    /// if any other `fulfillment_method` is provided.
    /// </summary>
    public ThirdParty? ThirdParty
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ThirdParty>("third_party");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("third_party", value);
        }
    }

    /// <summary>
    /// If provided, the check will be valid on or before this date. After this date,
    /// the check transfer will be automatically stopped and deposits will not be
    /// accepted. For checks printed by Increase, this date is included on the check
    /// as its expiry.
    /// </summary>
    public string? ValidUntilDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("valid_until_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("valid_until_date", value);
        }
    }

    public CheckTransferCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckTransferCreateParams(CheckTransferCreateParams checkTransferCreateParams)
        : base(checkTransferCreateParams)
    {
        this._rawBodyData = new(checkTransferCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CheckTransferCreateParams(
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
    CheckTransferCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CheckTransferCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CheckTransferCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/check_transfers")
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
/// Whether Increase will print and mail the check or if you will do it yourself.
/// </summary>
[JsonConverter(typeof(FulfillmentMethodConverter))]
public enum FulfillmentMethod
{
    /// <summary>
    /// Increase will print and mail a physical check.
    /// </summary>
    PhysicalCheck,

    /// <summary>
    /// Increase will not print a check; you are responsible for printing and mailing
    /// a check with the provided account number, routing number, check number, and amount.
    /// </summary>
    ThirdParty,
}

sealed class FulfillmentMethodConverter : JsonConverter<FulfillmentMethod>
{
    public override FulfillmentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical_check" => FulfillmentMethod.PhysicalCheck,
            "third_party" => FulfillmentMethod.ThirdParty,
            _ => (FulfillmentMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FulfillmentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FulfillmentMethod.PhysicalCheck => "physical_check",
                FulfillmentMethod.ThirdParty => "third_party",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How the account's available balance should be checked. If omitted, the default
/// behavior is `balance_check: full`.
/// </summary>
[JsonConverter(typeof(BalanceCheckConverter))]
public enum BalanceCheck
{
    /// <summary>
    /// The available balance of the account must be at least the amount of the check,
    /// and a Pending Transaction will be created for the full amount. This is the
    /// default behavior if `balance_check` is omitted.
    /// </summary>
    Full,

    /// <summary>
    /// No balance check will performed when the check transfer is initiated. A zero-dollar
    /// Pending Transaction will be created. The balance will still be checked when
    /// the Inbound Check Deposit is created.
    /// </summary>
    None,
}

sealed class BalanceCheckConverter : JsonConverter<BalanceCheck>
{
    public override BalanceCheck Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => BalanceCheck.Full,
            "none" => BalanceCheck.None,
            _ => (BalanceCheck)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceCheck value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceCheck.Full => "full",
                BalanceCheck.None => "none",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details relating to the physical check that Increase will print and mail. This
/// is required if `fulfillment_method` is equal to `physical_check`. It must not
/// be included if any other `fulfillment_method` is provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhysicalCheck, PhysicalCheckFromRaw>))]
public sealed record class PhysicalCheck : JsonModel
{
    /// <summary>
    /// Details for where Increase will mail the check.
    /// </summary>
    public required MailingAddress MailingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MailingAddress>("mailing_address");
        }
        init { this._rawData.Set("mailing_address", value); }
    }

    /// <summary>
    /// The descriptor that will be printed on the memo field on the check.
    /// </summary>
    public required string Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
    }

    /// <summary>
    /// The name that will be printed on the check in the 'To:' field.
    /// </summary>
    public required string RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient_name");
        }
        init { this._rawData.Set("recipient_name", value); }
    }

    /// <summary>
    /// The ID of a File to be attached to the check. This must have `purpose: check_attachment`.
    /// For details on pricing and restrictions, see https://increase.com/documentation/originating-checks#printing-checks .
    /// </summary>
    public string? AttachmentFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("attachment_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attachment_file_id", value);
        }
    }

    /// <summary>
    /// The ID of a File to be used as the check voucher image. This must have `purpose:
    /// check_voucher_image`. For details on pricing and restrictions, see https://increase.com/documentation/originating-checks#printing-checks .
    /// </summary>
    public string? CheckVoucherImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("check_voucher_image_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("check_voucher_image_file_id", value);
        }
    }

    /// <summary>
    /// The descriptor that will be printed on the letter included with the check.
    /// </summary>
    public string? Note
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("note");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("note", value);
        }
    }

    /// <summary>
    /// The payer of the check. This will be printed on the top-left portion of the
    /// check and defaults to the return address if unspecified. This should be an
    /// array of up to 4 elements, each of which represents a line of the payer.
    /// </summary>
    public IReadOnlyList<Payer>? Payer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Payer>>("payer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Payer>?>(
                "payer",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The return address to be printed on the check. If omitted this will default
    /// to an Increase-owned address that will mark checks as delivery failed and
    /// shred them.
    /// </summary>
    public ReturnAddress? ReturnAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReturnAddress>("return_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("return_address", value);
        }
    }

    /// <summary>
    /// How to ship the check. For details on pricing, timing, and restrictions,
    /// see https://increase.com/documentation/originating-checks#printing-checks .
    /// </summary>
    public ApiEnum<string, ShippingMethod>? ShippingMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ShippingMethod>>(
                "shipping_method"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_method", value);
        }
    }

    /// <summary>
    /// The signature that will appear on the check. If not provided, the check will
    /// be printed with 'No Signature Required'. At most one of `text` and `image_file_id`
    /// may be provided.
    /// </summary>
    public Signature? Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Signature>("signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signature", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MailingAddress.Validate();
        _ = this.Memo;
        _ = this.RecipientName;
        _ = this.AttachmentFileID;
        _ = this.CheckVoucherImageFileID;
        _ = this.Note;
        foreach (var item in this.Payer ?? [])
        {
            item.Validate();
        }
        this.ReturnAddress?.Validate();
        this.ShippingMethod?.Validate();
        this.Signature?.Validate();
    }

    public PhysicalCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCheck(PhysicalCheck physicalCheck)
        : base(physicalCheck) { }
#pragma warning restore CS8618

    public PhysicalCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCheckFromRaw.FromRawUnchecked"/>
    public static PhysicalCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCheckFromRaw : IFromRawJson<PhysicalCheck>
{
    /// <inheritdoc/>
    public PhysicalCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhysicalCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// Details for where Increase will mail the check.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MailingAddress, MailingAddressFromRaw>))]
public sealed record class MailingAddress : JsonModel
{
    /// <summary>
    /// The city component of the check's destination address.
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
    /// The first line of the address component of the check's destination address.
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
    /// The postal code component of the check's destination address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The US state component of the check's destination address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The second line of the address component of the check's destination address.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <summary>
    /// The name component of the check's destination address. Defaults to the provided
    /// `recipient_name` parameter if `name` is not provided.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The phone number to associate with the check's destination address. The phone
    /// number is only used when `shipping_method` is `fedex_overnight` and will
    /// be supplied to FedEx to be used in case of delivery issues.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line2;
        _ = this.Name;
        _ = this.Phone;
    }

    public MailingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MailingAddress(MailingAddress mailingAddress)
        : base(mailingAddress) { }
#pragma warning restore CS8618

    public MailingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MailingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MailingAddressFromRaw.FromRawUnchecked"/>
    public static MailingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MailingAddressFromRaw : IFromRawJson<MailingAddress>
{
    /// <inheritdoc/>
    public MailingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MailingAddress.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Payer, PayerFromRaw>))]
public sealed record class Payer : JsonModel
{
    /// <summary>
    /// The contents of the line.
    /// </summary>
    public required string Contents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contents");
        }
        init { this._rawData.Set("contents", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contents;
    }

    public Payer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payer(Payer payer)
        : base(payer) { }
#pragma warning restore CS8618

    public Payer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayerFromRaw.FromRawUnchecked"/>
    public static Payer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Payer(string contents)
        : this()
    {
        this.Contents = contents;
    }
}

class PayerFromRaw : IFromRawJson<Payer>
{
    /// <inheritdoc/>
    public Payer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Payer.FromRawUnchecked(rawData);
}

/// <summary>
/// The return address to be printed on the check. If omitted this will default to
/// an Increase-owned address that will mark checks as delivery failed and shred them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReturnAddress, ReturnAddressFromRaw>))]
public sealed record class ReturnAddress : JsonModel
{
    /// <summary>
    /// The city of the return address.
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
    /// The first line of the return address.
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
    /// The name of the return address.
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

    /// <summary>
    /// The postal code of the return address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The US state of the return address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The second line of the return address.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <summary>
    /// The phone number to associate with the shipper. The phone number is only used
    /// when `shipping_method` is `fedex_overnight` and will be supplied to FedEx
    /// to be used in case of delivery issues.
    /// </summary>
    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Name;
        _ = this.PostalCode;
        _ = this.State;
        _ = this.Line2;
        _ = this.Phone;
    }

    public ReturnAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReturnAddress(ReturnAddress returnAddress)
        : base(returnAddress) { }
#pragma warning restore CS8618

    public ReturnAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReturnAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReturnAddressFromRaw.FromRawUnchecked"/>
    public static ReturnAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReturnAddressFromRaw : IFromRawJson<ReturnAddress>
{
    /// <inheritdoc/>
    public ReturnAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReturnAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// How to ship the check. For details on pricing, timing, and restrictions, see https://increase.com/documentation/originating-checks#printing-checks .
/// </summary>
[JsonConverter(typeof(ShippingMethodConverter))]
public enum ShippingMethod
{
    /// <summary>
    /// USPS First Class
    /// </summary>
    UspsFirstClass,

    /// <summary>
    /// FedEx Overnight
    /// </summary>
    FedexOvernight,
}

sealed class ShippingMethodConverter : JsonConverter<ShippingMethod>
{
    public override ShippingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usps_first_class" => ShippingMethod.UspsFirstClass,
            "fedex_overnight" => ShippingMethod.FedexOvernight,
            _ => (ShippingMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShippingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShippingMethod.UspsFirstClass => "usps_first_class",
                ShippingMethod.FedexOvernight => "fedex_overnight",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The signature that will appear on the check. If not provided, the check will
/// be printed with 'No Signature Required'. At most one of `text` and `image_file_id`
/// may be provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Signature, SignatureFromRaw>))]
public sealed record class Signature : JsonModel
{
    /// <summary>
    /// The ID of a File containing a PNG of the signature. This must have `purpose:
    /// check_signature` and be a 1320x120 pixel PNG.
    /// </summary>
    public string? ImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("image_file_id", value);
        }
    }

    /// <summary>
    /// The text that will appear as the signature on the check in cursive font.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImageFileID;
        _ = this.Text;
    }

    public Signature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Signature(Signature signature)
        : base(signature) { }
#pragma warning restore CS8618

    public Signature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Signature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SignatureFromRaw.FromRawUnchecked"/>
    public static Signature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SignatureFromRaw : IFromRawJson<Signature>
{
    /// <inheritdoc/>
    public Signature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Signature.FromRawUnchecked(rawData);
}

/// <summary>
/// Details relating to the custom fulfillment you will perform. This is required
/// if `fulfillment_method` is equal to `third_party`. It must not be included if
/// any other `fulfillment_method` is provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThirdParty, ThirdPartyFromRaw>))]
public sealed record class ThirdParty : JsonModel
{
    /// <summary>
    /// The pay-to name you will print on the check. If provided, this is used for
    /// [Positive Pay](/documentation/positive-pay). If this is omitted, Increase
    /// will be unable to validate the payer name when the check is deposited.
    /// </summary>
    public string? RecipientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recipient_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientName;
    }

    public ThirdParty() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThirdParty(ThirdParty thirdParty)
        : base(thirdParty) { }
#pragma warning restore CS8618

    public ThirdParty(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThirdParty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThirdPartyFromRaw.FromRawUnchecked"/>
    public static ThirdParty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThirdPartyFromRaw : IFromRawJson<ThirdParty>
{
    /// <inheritdoc/>
    public ThirdParty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThirdParty.FromRawUnchecked(rawData);
}
