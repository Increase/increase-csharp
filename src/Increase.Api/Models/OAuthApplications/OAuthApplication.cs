using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.OAuthApplications;

/// <summary>
/// An OAuth Application lets you build an application for others to use with their
/// Increase data. You can create an OAuth Application via the Dashboard and read
/// information about it with the API. Learn more about OAuth [here](https://increase.com/documentation/oauth).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OAuthApplication, OAuthApplicationFromRaw>))]
public sealed record class OAuthApplication : JsonModel
{
    /// <summary>
    /// The OAuth Application's identifier.
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
    /// The OAuth Application's client_id. Use this to authenticate with the OAuth Application.
    /// </summary>
    public required string ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_id");
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp when the
    /// OAuth Application was created.
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
    /// OAuth Application was deleted.
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
    /// The name you chose for this OAuth Application.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Whether the application is active.
    /// </summary>
    public required ApiEnum<string, OAuthApplicationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OAuthApplicationStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `oauth_application`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.OAuthApplications.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.OAuthApplications.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ClientID;
        _ = this.CreatedAt;
        _ = this.DeletedAt;
        _ = this.Name;
        this.Status.Validate();
        this.Type.Validate();
    }

    public OAuthApplication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthApplication(OAuthApplication oauthApplication)
        : base(oauthApplication) { }
#pragma warning restore CS8618

    public OAuthApplication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthApplication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthApplicationFromRaw.FromRawUnchecked"/>
    public static OAuthApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OAuthApplicationFromRaw : IFromRawJson<OAuthApplication>
{
    /// <inheritdoc/>
    public OAuthApplication FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OAuthApplication.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the application is active.
/// </summary>
[JsonConverter(typeof(OAuthApplicationStatusConverter))]
public enum OAuthApplicationStatus
{
    /// <summary>
    /// The application is active and can be used by your users.
    /// </summary>
    Active,

    /// <summary>
    /// The application is deleted.
    /// </summary>
    Deleted,
}

sealed class OAuthApplicationStatusConverter : JsonConverter<OAuthApplicationStatus>
{
    public override OAuthApplicationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => OAuthApplicationStatus.Active,
            "deleted" => OAuthApplicationStatus.Deleted,
            _ => (OAuthApplicationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OAuthApplicationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OAuthApplicationStatus.Active => "active",
                OAuthApplicationStatus.Deleted => "deleted",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `oauth_application`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    OAuthApplication,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.OAuthApplications.Type>
{
    public override global::Increase.Api.Models.OAuthApplications.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "oauth_application" => global::Increase
                .Api
                .Models
                .OAuthApplications
                .Type
                .OAuthApplication,
            _ => (global::Increase.Api.Models.OAuthApplications.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.OAuthApplications.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.OAuthApplications.Type.OAuthApplication =>
                    "oauth_application",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
