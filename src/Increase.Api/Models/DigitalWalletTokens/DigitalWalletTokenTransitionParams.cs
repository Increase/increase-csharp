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

namespace Increase.Api.Models.DigitalWalletTokens;

/// <summary>
/// Submit a Digital Wallet Token status transition to the card network. The Digital
/// Wallet Token will move to `pending_transitioning` until the card network confirms
/// the transition, and a `digital_wallet_token.updated` webhook will be sent once
/// the transition has been confirmed.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DigitalWalletTokenTransitionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DigitalWalletTokenID { get; init; }

    /// <summary>
    /// The status to transition the Digital Wallet Token to.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawBodyData.Set("status", value); }
    }

    public DigitalWalletTokenTransitionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalWalletTokenTransitionParams(
        DigitalWalletTokenTransitionParams digitalWalletTokenTransitionParams
    )
        : base(digitalWalletTokenTransitionParams)
    {
        this.DigitalWalletTokenID = digitalWalletTokenTransitionParams.DigitalWalletTokenID;

        this._rawBodyData = new(digitalWalletTokenTransitionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DigitalWalletTokenTransitionParams(
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
    DigitalWalletTokenTransitionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string digitalWalletTokenID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DigitalWalletTokenID = digitalWalletTokenID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DigitalWalletTokenTransitionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string digitalWalletTokenID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            digitalWalletTokenID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DigitalWalletTokenID"] = JsonSerializer.SerializeToElement(
                        this.DigitalWalletTokenID
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

    public virtual bool Equals(DigitalWalletTokenTransitionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.DigitalWalletTokenID?.Equals(other.DigitalWalletTokenID)
                ?? other.DigitalWalletTokenID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/digital_wallet_tokens/{0}/transition", this.DigitalWalletTokenID)
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
/// The status to transition the Digital Wallet Token to.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// Reactivate a suspended Digital Wallet Token.
    /// </summary>
    Active,

    /// <summary>
    /// Temporarily pause an active Digital Wallet Token.
    /// </summary>
    Suspended,

    /// <summary>
    /// Permanently cancel an active, inactive, or suspended Digital Wallet Token.
    /// </summary>
    Deactivated,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "suspended" => Status.Suspended,
            "deactivated" => Status.Deactivated,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Suspended => "suspended",
                Status.Deactivated => "deactivated",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
