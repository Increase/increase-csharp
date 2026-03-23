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

namespace Increase.Api.Models.InboundMailItems;

/// <summary>
/// Action an Inbound Mail Item
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboundMailItemActionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InboundMailItemID { get; init; }

    /// <summary>
    /// The actions to perform on the Inbound Mail Item.
    /// </summary>
    public required IReadOnlyList<Check> Checks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Check>>("checks");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Check>>(
                "checks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public InboundMailItemActionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMailItemActionParams(InboundMailItemActionParams inboundMailItemActionParams)
        : base(inboundMailItemActionParams)
    {
        this.InboundMailItemID = inboundMailItemActionParams.InboundMailItemID;

        this._rawBodyData = new(inboundMailItemActionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboundMailItemActionParams(
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
    InboundMailItemActionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string inboundMailItemID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InboundMailItemID = inboundMailItemID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboundMailItemActionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string inboundMailItemID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            inboundMailItemID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InboundMailItemID"] = JsonSerializer.SerializeToElement(
                        this.InboundMailItemID
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

    public virtual bool Equals(InboundMailItemActionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.InboundMailItemID?.Equals(other.InboundMailItemID)
                ?? other.InboundMailItemID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/inbound_mail_items/{0}/action", this.InboundMailItemID)
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

[JsonConverter(typeof(JsonModelConverter<Check, CheckFromRaw>))]
public sealed record class Check : JsonModel
{
    /// <summary>
    /// The action to perform on the Inbound Mail Item.
    /// </summary>
    public required ApiEnum<string, Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Action>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// The identifier of the Account to deposit the check into. If not provided,
    /// the check will be deposited into the Account associated with the Lockbox.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        _ = this.AccountID;
    }

    public Check() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Check(Check check)
        : base(check) { }
#pragma warning restore CS8618

    public Check(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckFromRaw.FromRawUnchecked"/>
    public static Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Check(ApiEnum<string, Action> action)
        : this()
    {
        this.Action = action;
    }
}

class CheckFromRaw : IFromRawJson<Check>
{
    /// <inheritdoc/>
    public Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Check.FromRawUnchecked(rawData);
}

/// <summary>
/// The action to perform on the Inbound Mail Item.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    /// <summary>
    /// The check will be deposited.
    /// </summary>
    Deposit,

    /// <summary>
    /// The check will be ignored.
    /// </summary>
    Ignore,
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => Action.Deposit,
            "ignore" => Action.Ignore,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.Deposit => "deposit",
                Action.Ignore => "ignore",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
