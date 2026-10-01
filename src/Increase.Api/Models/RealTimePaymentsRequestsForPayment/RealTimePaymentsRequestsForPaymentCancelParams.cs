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

namespace Increase.Api.Models.RealTimePaymentsRequestsForPayment;

/// <summary>
/// Cancels a Real-Time Payments Request for Payment that is still awaiting payment.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RealTimePaymentsRequestsForPaymentCancelParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? RealTimePaymentsRequestForPaymentID { get; init; }

    /// <summary>
    /// Additional information about the cancellation to pass on to the recipient bank.
    /// </summary>
    public string? AdditionalInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("additional_information");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("additional_information", value);
        }
    }

    /// <summary>
    /// The reason the request for payment is being canceled. Defaults to `requested_by_customer`.
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

    public RealTimePaymentsRequestsForPaymentCancelParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RealTimePaymentsRequestsForPaymentCancelParams(
        RealTimePaymentsRequestsForPaymentCancelParams realTimePaymentsRequestsForPaymentCancelParams
    )
        : base(realTimePaymentsRequestsForPaymentCancelParams)
    {
        this.RealTimePaymentsRequestForPaymentID =
            realTimePaymentsRequestsForPaymentCancelParams.RealTimePaymentsRequestForPaymentID;

        this._rawBodyData = new(realTimePaymentsRequestsForPaymentCancelParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RealTimePaymentsRequestsForPaymentCancelParams(
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
    RealTimePaymentsRequestsForPaymentCancelParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string realTimePaymentsRequestForPaymentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.RealTimePaymentsRequestForPaymentID = realTimePaymentsRequestForPaymentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RealTimePaymentsRequestsForPaymentCancelParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string realTimePaymentsRequestForPaymentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            realTimePaymentsRequestForPaymentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RealTimePaymentsRequestForPaymentID"] = JsonSerializer.SerializeToElement(
                        this.RealTimePaymentsRequestForPaymentID
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

    public virtual bool Equals(RealTimePaymentsRequestsForPaymentCancelParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.RealTimePaymentsRequestForPaymentID?.Equals(
                    other.RealTimePaymentsRequestForPaymentID
                )
                ?? other.RealTimePaymentsRequestForPaymentID == null
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
                    "/real_time_payments_requests_for_payment/{0}/cancel",
                    this.RealTimePaymentsRequestForPaymentID
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
/// The reason the request for payment is being canceled. Defaults to `requested_by_customer`.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
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
            "requested_by_customer" => Reason.RequestedByCustomer,
            "paid_by_other_means" => Reason.PaidByOtherMeans,
            "duplicate" => Reason.Duplicate,
            "wrong_amount" => Reason.WrongAmount,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.RequestedByCustomer => "requested_by_customer",
                Reason.PaidByOtherMeans => "paid_by_other_means",
                Reason.Duplicate => "duplicate",
                Reason.WrongAmount => "wrong_amount",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
