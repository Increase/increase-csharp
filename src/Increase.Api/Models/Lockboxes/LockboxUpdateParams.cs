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

namespace Increase.Api.Models.Lockboxes;

/// <summary>
/// Update a Lockbox
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LockboxUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? LockboxID { get; init; }

    /// <summary>
    /// This indicates if checks mailed to this lockbox will be deposited.
    /// </summary>
    public ApiEnum<string, CheckDepositBehavior>? CheckDepositBehavior
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CheckDepositBehavior>>(
                "check_deposit_behavior"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("check_deposit_behavior", value);
        }
    }

    /// <summary>
    /// The description you choose for the Lockbox.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// The recipient name you choose for the Lockbox.
    /// </summary>
    public string? RecipientName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("recipient_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("recipient_name", value);
        }
    }

    public LockboxUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LockboxUpdateParams(LockboxUpdateParams lockboxUpdateParams)
        : base(lockboxUpdateParams)
    {
        this.LockboxID = lockboxUpdateParams.LockboxID;

        this._rawBodyData = new(lockboxUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public LockboxUpdateParams(
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
    LockboxUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string lockboxID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.LockboxID = lockboxID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LockboxUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string lockboxID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            lockboxID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["LockboxID"] = JsonSerializer.SerializeToElement(this.LockboxID),
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

    public virtual bool Equals(LockboxUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.LockboxID?.Equals(other.LockboxID) ?? other.LockboxID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/lockboxes/{0}", this.LockboxID)
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
/// This indicates if checks mailed to this lockbox will be deposited.
/// </summary>
[JsonConverter(typeof(CheckDepositBehaviorConverter))]
public enum CheckDepositBehavior
{
    /// <summary>
    /// Checks mailed to this Lockbox will be deposited.
    /// </summary>
    Enabled,

    /// <summary>
    /// Checks mailed to this Lockbox will not be deposited.
    /// </summary>
    Disabled,

    /// <summary>
    /// Checks mailed to this Lockbox will be pending until actioned.
    /// </summary>
    PendForProcessing,
}

sealed class CheckDepositBehaviorConverter : JsonConverter<CheckDepositBehavior>
{
    public override CheckDepositBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled" => CheckDepositBehavior.Enabled,
            "disabled" => CheckDepositBehavior.Disabled,
            "pend_for_processing" => CheckDepositBehavior.PendForProcessing,
            _ => (CheckDepositBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CheckDepositBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CheckDepositBehavior.Enabled => "enabled",
                CheckDepositBehavior.Disabled => "disabled",
                CheckDepositBehavior.PendForProcessing => "pend_for_processing",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
