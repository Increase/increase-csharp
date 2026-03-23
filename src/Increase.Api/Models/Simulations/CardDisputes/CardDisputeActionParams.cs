using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.CardDisputes;

/// <summary>
/// After a [Card Dispute](#card-disputes) is created in production, the dispute
/// will initially be in a `pending_user_submission_reviewing` state. Since no review
/// or further action happens in sandbox, this endpoint simulates moving a Card Dispute
/// through its various states.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardDisputeActionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CardDisputeID { get; init; }

    /// <summary>
    /// The network of the Card Dispute. Details specific to the network are required
    /// under the sub-object with the same identifier as the network.
    /// </summary>
    public required ApiEnum<string, Network> Network
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Network>>("network");
        }
        init { this._rawBodyData.Set("network", value); }
    }

    /// <summary>
    /// The Visa-specific parameters for the taking action on the dispute. Required
    /// if and only if `network` is `visa`.
    /// </summary>
    public Visa? Visa
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Visa>("visa");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("visa", value);
        }
    }

    public CardDisputeActionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardDisputeActionParams(CardDisputeActionParams cardDisputeActionParams)
        : base(cardDisputeActionParams)
    {
        this.CardDisputeID = cardDisputeActionParams.CardDisputeID;

        this._rawBodyData = new(cardDisputeActionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardDisputeActionParams(
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
    CardDisputeActionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string cardDisputeID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CardDisputeID = cardDisputeID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardDisputeActionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string cardDisputeID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            cardDisputeID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CardDisputeID"] = JsonSerializer.SerializeToElement(this.CardDisputeID),
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

    public virtual bool Equals(CardDisputeActionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CardDisputeID?.Equals(other.CardDisputeID) ?? other.CardDisputeID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/simulations/card_disputes/{0}/action", this.CardDisputeID)
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
/// The network of the Card Dispute. Details specific to the network are required
/// under the sub-object with the same identifier as the network.
/// </summary>
[JsonConverter(typeof(NetworkConverter))]
public enum Network
{
    /// <summary>
    /// Visa
    /// </summary>
    Visa,
}

sealed class NetworkConverter : JsonConverter<Network>
{
    public override Network Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa" => Network.Visa,
            _ => (Network)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Network value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Network.Visa => "visa",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The Visa-specific parameters for the taking action on the dispute. Required if
/// and only if `network` is `visa`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Visa, VisaFromRaw>))]
public sealed record class Visa : JsonModel
{
    /// <summary>
    /// The action to take. Details specific to the action are required under the
    /// sub-object with the same identifier as the action.
    /// </summary>
    public required ApiEnum<
        string,
        global::Increase.Api.Models.Simulations.CardDisputes.Action
    > Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Simulations.CardDisputes.Action>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// The parameters for accepting the chargeback. Required if and only if `action`
    /// is `accept_chargeback`.
    /// </summary>
    public AcceptChargeback? AcceptChargeback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AcceptChargeback>("accept_chargeback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accept_chargeback", value);
        }
    }

    /// <summary>
    /// The parameters for accepting the user submission. Required if and only if
    /// `action` is `accept_user_submission`.
    /// </summary>
    public AcceptUserSubmission? AcceptUserSubmission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AcceptUserSubmission>("accept_user_submission");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accept_user_submission", value);
        }
    }

    /// <summary>
    /// The parameters for declining the prearbitration. Required if and only if `action`
    /// is `decline_user_prearbitration`.
    /// </summary>
    public DeclineUserPrearbitration? DeclineUserPrearbitration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DeclineUserPrearbitration>(
                "decline_user_prearbitration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decline_user_prearbitration", value);
        }
    }

    /// <summary>
    /// The parameters for receiving the prearbitration. Required if and only if `action`
    /// is `receive_merchant_prearbitration`.
    /// </summary>
    public ReceiveMerchantPrearbitration? ReceiveMerchantPrearbitration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReceiveMerchantPrearbitration>(
                "receive_merchant_prearbitration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("receive_merchant_prearbitration", value);
        }
    }

    /// <summary>
    /// The parameters for re-presenting the dispute. Required if and only if `action`
    /// is `represent`.
    /// </summary>
    public Represent? Represent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Represent>("represent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("represent", value);
        }
    }

    /// <summary>
    /// The parameters for requesting further information from the user. Required
    /// if and only if `action` is `request_further_information`.
    /// </summary>
    public RequestFurtherInformation? RequestFurtherInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RequestFurtherInformation>(
                "request_further_information"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("request_further_information", value);
        }
    }

    /// <summary>
    /// The parameters for timing out the chargeback. Required if and only if `action`
    /// is `time_out_chargeback`.
    /// </summary>
    public TimeOutChargeback? TimeOutChargeback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TimeOutChargeback>("time_out_chargeback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_out_chargeback", value);
        }
    }

    /// <summary>
    /// The parameters for timing out the merchant prearbitration. Required if and
    /// only if `action` is `time_out_merchant_prearbitration`.
    /// </summary>
    public TimeOutMerchantPrearbitration? TimeOutMerchantPrearbitration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TimeOutMerchantPrearbitration>(
                "time_out_merchant_prearbitration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_out_merchant_prearbitration", value);
        }
    }

    /// <summary>
    /// The parameters for timing out the re-presentment. Required if and only if
    /// `action` is `time_out_representment`.
    /// </summary>
    public TimeOutRepresentment? TimeOutRepresentment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TimeOutRepresentment>("time_out_representment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_out_representment", value);
        }
    }

    /// <summary>
    /// The parameters for timing out the user prearbitration. Required if and only
    /// if `action` is `time_out_user_prearbitration`.
    /// </summary>
    public TimeOutUserPrearbitration? TimeOutUserPrearbitration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TimeOutUserPrearbitration>(
                "time_out_user_prearbitration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_out_user_prearbitration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        this.AcceptChargeback?.Validate();
        this.AcceptUserSubmission?.Validate();
        this.DeclineUserPrearbitration?.Validate();
        this.ReceiveMerchantPrearbitration?.Validate();
        this.Represent?.Validate();
        this.RequestFurtherInformation?.Validate();
        this.TimeOutChargeback?.Validate();
        this.TimeOutMerchantPrearbitration?.Validate();
        this.TimeOutRepresentment?.Validate();
        this.TimeOutUserPrearbitration?.Validate();
    }

    public Visa() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Visa(Visa visa)
        : base(visa) { }
#pragma warning restore CS8618

    public Visa(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Visa(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VisaFromRaw.FromRawUnchecked"/>
    public static Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Visa(ApiEnum<string, global::Increase.Api.Models.Simulations.CardDisputes.Action> action)
        : this()
    {
        this.Action = action;
    }
}

class VisaFromRaw : IFromRawJson<Visa>
{
    /// <inheritdoc/>
    public Visa FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Visa.FromRawUnchecked(rawData);
}

/// <summary>
/// The action to take. Details specific to the action are required under the sub-object
/// with the same identifier as the action.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    /// <summary>
    /// Simulate the merchant accepting the chargeback. This will move the dispute
    /// to a `won` state.
    /// </summary>
    AcceptChargeback,

    /// <summary>
    /// Accept the user's submission and transmit it to the network. This will move
    /// the dispute to a `pending_response` state.
    /// </summary>
    AcceptUserSubmission,

    /// <summary>
    /// Simulate the merchant declining the user's pre-arbitration. This will move
    /// the dispute to a `lost` state.
    /// </summary>
    DeclineUserPrearbitration,

    /// <summary>
    /// Simulate the merchant issuing pre-arbitration. This will move the dispute
    /// to a `user_submission_required` state.
    /// </summary>
    ReceiveMerchantPrearbitration,

    /// <summary>
    /// Simulate the merchant re-presenting the dispute. This will move the dispute
    /// to a `user_submission_required` state.
    /// </summary>
    Represent,

    /// <summary>
    /// Simulate further information being requested from the user. This will move
    /// the dispute to a `user_submission_required` state.
    /// </summary>
    RequestFurtherInformation,

    /// <summary>
    /// Simulate the merchant timing out responding to the chargeback. This will move
    /// the dispute to a `won` state.
    /// </summary>
    TimeOutChargeback,

    /// <summary>
    /// Simulate the user timing out responding to a merchant pre-arbitration. This
    /// will move the dispute to a `lost` state.
    /// </summary>
    TimeOutMerchantPrearbitration,

    /// <summary>
    /// Simulate the user timing out responding to a merchant re-presentment. This
    /// will move the dispute to a `lost` state.
    /// </summary>
    TimeOutRepresentment,

    /// <summary>
    /// Simulate the merchant timing out responding to a user pre-arbitration. This
    /// will move the dispute to a `win` state.
    /// </summary>
    TimeOutUserPrearbitration,
}

sealed class ActionConverter
    : JsonConverter<global::Increase.Api.Models.Simulations.CardDisputes.Action>
{
    public override global::Increase.Api.Models.Simulations.CardDisputes.Action Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accept_chargeback" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .AcceptChargeback,
            "accept_user_submission" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .AcceptUserSubmission,
            "decline_user_prearbitration" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .DeclineUserPrearbitration,
            "receive_merchant_prearbitration" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .ReceiveMerchantPrearbitration,
            "represent" => global::Increase.Api.Models.Simulations.CardDisputes.Action.Represent,
            "request_further_information" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .RequestFurtherInformation,
            "time_out_chargeback" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .TimeOutChargeback,
            "time_out_merchant_prearbitration" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .TimeOutMerchantPrearbitration,
            "time_out_representment" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .TimeOutRepresentment,
            "time_out_user_prearbitration" => global::Increase
                .Api
                .Models
                .Simulations
                .CardDisputes
                .Action
                .TimeOutUserPrearbitration,
            _ => (global::Increase.Api.Models.Simulations.CardDisputes.Action)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Simulations.CardDisputes.Action value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Simulations.CardDisputes.Action.AcceptChargeback =>
                    "accept_chargeback",
                global::Increase.Api.Models.Simulations.CardDisputes.Action.AcceptUserSubmission =>
                    "accept_user_submission",
                global::Increase
                    .Api
                    .Models
                    .Simulations
                    .CardDisputes
                    .Action
                    .DeclineUserPrearbitration => "decline_user_prearbitration",
                global::Increase
                    .Api
                    .Models
                    .Simulations
                    .CardDisputes
                    .Action
                    .ReceiveMerchantPrearbitration => "receive_merchant_prearbitration",
                global::Increase.Api.Models.Simulations.CardDisputes.Action.Represent =>
                    "represent",
                global::Increase
                    .Api
                    .Models
                    .Simulations
                    .CardDisputes
                    .Action
                    .RequestFurtherInformation => "request_further_information",
                global::Increase.Api.Models.Simulations.CardDisputes.Action.TimeOutChargeback =>
                    "time_out_chargeback",
                global::Increase
                    .Api
                    .Models
                    .Simulations
                    .CardDisputes
                    .Action
                    .TimeOutMerchantPrearbitration => "time_out_merchant_prearbitration",
                global::Increase.Api.Models.Simulations.CardDisputes.Action.TimeOutRepresentment =>
                    "time_out_representment",
                global::Increase
                    .Api
                    .Models
                    .Simulations
                    .CardDisputes
                    .Action
                    .TimeOutUserPrearbitration => "time_out_user_prearbitration",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The parameters for accepting the chargeback. Required if and only if `action`
/// is `accept_chargeback`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AcceptChargeback, AcceptChargebackFromRaw>))]
public sealed record class AcceptChargeback : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public AcceptChargeback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AcceptChargeback(AcceptChargeback acceptChargeback)
        : base(acceptChargeback) { }
#pragma warning restore CS8618

    public AcceptChargeback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AcceptChargeback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcceptChargebackFromRaw.FromRawUnchecked"/>
    public static AcceptChargeback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AcceptChargebackFromRaw : IFromRawJson<AcceptChargeback>
{
    /// <inheritdoc/>
    public AcceptChargeback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AcceptChargeback.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for accepting the user submission. Required if and only if `action`
/// is `accept_user_submission`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AcceptUserSubmission, AcceptUserSubmissionFromRaw>))]
public sealed record class AcceptUserSubmission : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public AcceptUserSubmission() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AcceptUserSubmission(AcceptUserSubmission acceptUserSubmission)
        : base(acceptUserSubmission) { }
#pragma warning restore CS8618

    public AcceptUserSubmission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AcceptUserSubmission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AcceptUserSubmissionFromRaw.FromRawUnchecked"/>
    public static AcceptUserSubmission FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AcceptUserSubmissionFromRaw : IFromRawJson<AcceptUserSubmission>
{
    /// <inheritdoc/>
    public AcceptUserSubmission FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AcceptUserSubmission.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for declining the prearbitration. Required if and only if `action`
/// is `decline_user_prearbitration`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DeclineUserPrearbitration, DeclineUserPrearbitrationFromRaw>)
)]
public sealed record class DeclineUserPrearbitration : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public DeclineUserPrearbitration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeclineUserPrearbitration(DeclineUserPrearbitration declineUserPrearbitration)
        : base(declineUserPrearbitration) { }
#pragma warning restore CS8618

    public DeclineUserPrearbitration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeclineUserPrearbitration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeclineUserPrearbitrationFromRaw.FromRawUnchecked"/>
    public static DeclineUserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeclineUserPrearbitrationFromRaw : IFromRawJson<DeclineUserPrearbitration>
{
    /// <inheritdoc/>
    public DeclineUserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeclineUserPrearbitration.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for receiving the prearbitration. Required if and only if `action`
/// is `receive_merchant_prearbitration`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ReceiveMerchantPrearbitration, ReceiveMerchantPrearbitrationFromRaw>)
)]
public sealed record class ReceiveMerchantPrearbitration : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ReceiveMerchantPrearbitration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReceiveMerchantPrearbitration(
        ReceiveMerchantPrearbitration receiveMerchantPrearbitration
    )
        : base(receiveMerchantPrearbitration) { }
#pragma warning restore CS8618

    public ReceiveMerchantPrearbitration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReceiveMerchantPrearbitration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReceiveMerchantPrearbitrationFromRaw.FromRawUnchecked"/>
    public static ReceiveMerchantPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReceiveMerchantPrearbitrationFromRaw : IFromRawJson<ReceiveMerchantPrearbitration>
{
    /// <inheritdoc/>
    public ReceiveMerchantPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReceiveMerchantPrearbitration.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for re-presenting the dispute. Required if and only if `action`
/// is `represent`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Represent, RepresentFromRaw>))]
public sealed record class Represent : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public Represent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Represent(Represent represent)
        : base(represent) { }
#pragma warning restore CS8618

    public Represent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Represent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepresentFromRaw.FromRawUnchecked"/>
    public static Represent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepresentFromRaw : IFromRawJson<Represent>
{
    /// <inheritdoc/>
    public Represent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Represent.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for requesting further information from the user. Required if and
/// only if `action` is `request_further_information`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RequestFurtherInformation, RequestFurtherInformationFromRaw>)
)]
public sealed record class RequestFurtherInformation : JsonModel
{
    /// <summary>
    /// The reason for requesting further information from the user.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public RequestFurtherInformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestFurtherInformation(RequestFurtherInformation requestFurtherInformation)
        : base(requestFurtherInformation) { }
#pragma warning restore CS8618

    public RequestFurtherInformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestFurtherInformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestFurtherInformationFromRaw.FromRawUnchecked"/>
    public static RequestFurtherInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RequestFurtherInformation(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class RequestFurtherInformationFromRaw : IFromRawJson<RequestFurtherInformation>
{
    /// <inheritdoc/>
    public RequestFurtherInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestFurtherInformation.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for timing out the chargeback. Required if and only if `action`
/// is `time_out_chargeback`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TimeOutChargeback, TimeOutChargebackFromRaw>))]
public sealed record class TimeOutChargeback : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public TimeOutChargeback() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeOutChargeback(TimeOutChargeback timeOutChargeback)
        : base(timeOutChargeback) { }
#pragma warning restore CS8618

    public TimeOutChargeback(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeOutChargeback(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeOutChargebackFromRaw.FromRawUnchecked"/>
    public static TimeOutChargeback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeOutChargebackFromRaw : IFromRawJson<TimeOutChargeback>
{
    /// <inheritdoc/>
    public TimeOutChargeback FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TimeOutChargeback.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for timing out the merchant prearbitration. Required if and only
/// if `action` is `time_out_merchant_prearbitration`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TimeOutMerchantPrearbitration, TimeOutMerchantPrearbitrationFromRaw>)
)]
public sealed record class TimeOutMerchantPrearbitration : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public TimeOutMerchantPrearbitration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeOutMerchantPrearbitration(
        TimeOutMerchantPrearbitration timeOutMerchantPrearbitration
    )
        : base(timeOutMerchantPrearbitration) { }
#pragma warning restore CS8618

    public TimeOutMerchantPrearbitration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeOutMerchantPrearbitration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeOutMerchantPrearbitrationFromRaw.FromRawUnchecked"/>
    public static TimeOutMerchantPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeOutMerchantPrearbitrationFromRaw : IFromRawJson<TimeOutMerchantPrearbitration>
{
    /// <inheritdoc/>
    public TimeOutMerchantPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TimeOutMerchantPrearbitration.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for timing out the re-presentment. Required if and only if `action`
/// is `time_out_representment`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TimeOutRepresentment, TimeOutRepresentmentFromRaw>))]
public sealed record class TimeOutRepresentment : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public TimeOutRepresentment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeOutRepresentment(TimeOutRepresentment timeOutRepresentment)
        : base(timeOutRepresentment) { }
#pragma warning restore CS8618

    public TimeOutRepresentment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeOutRepresentment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeOutRepresentmentFromRaw.FromRawUnchecked"/>
    public static TimeOutRepresentment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeOutRepresentmentFromRaw : IFromRawJson<TimeOutRepresentment>
{
    /// <inheritdoc/>
    public TimeOutRepresentment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TimeOutRepresentment.FromRawUnchecked(rawData);
}

/// <summary>
/// The parameters for timing out the user prearbitration. Required if and only if
/// `action` is `time_out_user_prearbitration`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TimeOutUserPrearbitration, TimeOutUserPrearbitrationFromRaw>)
)]
public sealed record class TimeOutUserPrearbitration : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public TimeOutUserPrearbitration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeOutUserPrearbitration(TimeOutUserPrearbitration timeOutUserPrearbitration)
        : base(timeOutUserPrearbitration) { }
#pragma warning restore CS8618

    public TimeOutUserPrearbitration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeOutUserPrearbitration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeOutUserPrearbitrationFromRaw.FromRawUnchecked"/>
    public static TimeOutUserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeOutUserPrearbitrationFromRaw : IFromRawJson<TimeOutUserPrearbitration>
{
    /// <inheritdoc/>
    public TimeOutUserPrearbitration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TimeOutUserPrearbitration.FromRawUnchecked(rawData);
}
