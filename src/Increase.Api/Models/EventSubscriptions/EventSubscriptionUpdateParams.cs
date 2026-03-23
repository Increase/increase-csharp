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

namespace Increase.Api.Models.EventSubscriptions;

/// <summary>
/// Update an Event Subscription
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EventSubscriptionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EventSubscriptionID { get; init; }

    /// <summary>
    /// The status to update the Event Subscription with.
    /// </summary>
    public ApiEnum<string, EventSubscriptionUpdateParamsStatus>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, EventSubscriptionUpdateParamsStatus>
            >("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    public EventSubscriptionUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventSubscriptionUpdateParams(
        EventSubscriptionUpdateParams eventSubscriptionUpdateParams
    )
        : base(eventSubscriptionUpdateParams)
    {
        this.EventSubscriptionID = eventSubscriptionUpdateParams.EventSubscriptionID;

        this._rawBodyData = new(eventSubscriptionUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EventSubscriptionUpdateParams(
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
    EventSubscriptionUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string eventSubscriptionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EventSubscriptionID = eventSubscriptionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EventSubscriptionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string eventSubscriptionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            eventSubscriptionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EventSubscriptionID"] = JsonSerializer.SerializeToElement(
                        this.EventSubscriptionID
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

    public virtual bool Equals(EventSubscriptionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.EventSubscriptionID?.Equals(other.EventSubscriptionID)
                ?? other.EventSubscriptionID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/event_subscriptions/{0}", this.EventSubscriptionID)
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
/// The status to update the Event Subscription with.
/// </summary>
[JsonConverter(typeof(EventSubscriptionUpdateParamsStatusConverter))]
public enum EventSubscriptionUpdateParamsStatus
{
    /// <summary>
    /// The subscription is active and Events will be delivered normally.
    /// </summary>
    Active,

    /// <summary>
    /// The subscription is temporarily disabled and Events will not be delivered.
    /// </summary>
    Disabled,

    /// <summary>
    /// The subscription is permanently disabled and Events will not be delivered.
    /// </summary>
    Deleted,
}

sealed class EventSubscriptionUpdateParamsStatusConverter
    : JsonConverter<EventSubscriptionUpdateParamsStatus>
{
    public override EventSubscriptionUpdateParamsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => EventSubscriptionUpdateParamsStatus.Active,
            "disabled" => EventSubscriptionUpdateParamsStatus.Disabled,
            "deleted" => EventSubscriptionUpdateParamsStatus.Deleted,
            _ => (EventSubscriptionUpdateParamsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventSubscriptionUpdateParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventSubscriptionUpdateParamsStatus.Active => "active",
                EventSubscriptionUpdateParamsStatus.Disabled => "disabled",
                EventSubscriptionUpdateParamsStatus.Deleted => "deleted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
