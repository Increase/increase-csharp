using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.OAuthConnections;

/// <summary>
/// When a user authorizes your OAuth application, an OAuth Connection object is
/// created. Learn more about OAuth [here](https://increase.com/documentation/oauth).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OAuthConnection, OAuthConnectionFromRaw>))]
public sealed record class OAuthConnection : JsonModel
{
    /// <summary>
    /// The OAuth Connection's identifier.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp when the
    /// OAuth Connection was created.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp when the
    /// OAuth Connection was deleted.
    /// </summary>
    public required System::DateTimeOffset? DeletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("deleted_at");
        }
        init { this._rawData.Set("deleted_at", value); }
    }

    /// <summary>
    /// The identifier of the Group that has authorized your OAuth application.
    /// </summary>
    public required string GroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_id");
        }
        init { this._rawData.Set("group_id", value); }
    }

    /// <summary>
    /// The identifier of the OAuth application this connection is for.
    /// </summary>
    public required string OAuthApplicationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("oauth_application_id");
        }
        init { this._rawData.Set("oauth_application_id", value); }
    }

    /// <summary>
    /// Whether the connection is active.
    /// </summary>
    public required ApiEnum<string, OAuthConnectionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OAuthConnectionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `oauth_connection`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.OAuthConnections.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.OAuthConnections.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DeletedAt;
        _ = this.GroupID;
        _ = this.OAuthApplicationID;
        this.Status.Validate();
        this.Type.Validate();
    }

    public OAuthConnection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthConnection(OAuthConnection oauthConnection)
        : base(oauthConnection) { }
#pragma warning restore CS8618

    public OAuthConnection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthConnection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthConnectionFromRaw.FromRawUnchecked"/>
    public static OAuthConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OAuthConnectionFromRaw : IFromRawJson<OAuthConnection>
{
    /// <inheritdoc/>
    public OAuthConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OAuthConnection.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the connection is active.
/// </summary>
[JsonConverter(typeof(OAuthConnectionStatusConverter))]
public enum OAuthConnectionStatus
{
    /// <summary>
    /// The OAuth connection is active.
    /// </summary>
    Active,

    /// <summary>
    /// The OAuth connection is permanently deactivated.
    /// </summary>
    Inactive,
}

sealed class OAuthConnectionStatusConverter : JsonConverter<OAuthConnectionStatus>
{
    public override OAuthConnectionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => OAuthConnectionStatus.Active,
            "inactive" => OAuthConnectionStatus.Inactive,
            _ => (OAuthConnectionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OAuthConnectionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OAuthConnectionStatus.Active => "active",
                OAuthConnectionStatus.Inactive => "inactive",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `oauth_connection`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    OAuthConnection,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.OAuthConnections.Type>
{
    public override global::Increase.Api.Models.OAuthConnections.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "oauth_connection" => global::Increase.Api.Models.OAuthConnections.Type.OAuthConnection,
            _ => (global::Increase.Api.Models.OAuthConnections.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.OAuthConnections.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.OAuthConnections.Type.OAuthConnection =>
                    "oauth_connection",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
