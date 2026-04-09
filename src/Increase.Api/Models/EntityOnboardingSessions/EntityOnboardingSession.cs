using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.EntityOnboardingSessions;

/// <summary>
/// Entity Onboarding Sessions let your customers onboard themselves by completing
/// Increase-hosted forms. Create a session and redirect your customer to the returned
/// URL. When they're done, they'll be redirected back to your site. This API is
/// used for [hosted onboarding](/documentation/hosted-onboarding).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityOnboardingSession, EntityOnboardingSessionFromRaw>))]
public sealed record class EntityOnboardingSession : JsonModel
{
    /// <summary>
    /// The Entity Onboarding Session's identifier.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Entity Onboarding Session was created.
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
    /// The identifier of the Entity associated with this session, if one has been
    /// created or was provided when creating the session.
    /// </summary>
    public required string? EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Entity Onboarding Session will expire.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// The identifier of the Program the Entity will be onboarded to.
    /// </summary>
    public required string ProgramID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("program_id");
        }
        init { this._rawData.Set("program_id", value); }
    }

    /// <summary>
    /// The URL to redirect to after the onboarding session is complete. Increase
    /// will include the query parameters `entity_onboarding_session_id` and `entity_id`
    /// when redirecting.
    /// </summary>
    public required string RedirectUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("redirect_url");
        }
        init { this._rawData.Set("redirect_url", value); }
    }

    /// <summary>
    /// The URL containing the onboarding form. You should share this link with your
    /// customer. Only present when the session is active.
    /// </summary>
    public required string? SessionUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_url");
        }
        init { this._rawData.Set("session_url", value); }
    }

    /// <summary>
    /// The status of the onboarding session.
    /// </summary>
    public required ApiEnum<string, EntityOnboardingSessionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityOnboardingSessionStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `entity_onboarding_session`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.EntityOnboardingSessions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.EntityOnboardingSessions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.ExpiresAt;
        _ = this.IdempotencyKey;
        _ = this.ProgramID;
        _ = this.RedirectUrl;
        _ = this.SessionUrl;
        this.Status.Validate();
        this.Type.Validate();
    }

    public EntityOnboardingSession() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityOnboardingSession(EntityOnboardingSession entityOnboardingSession)
        : base(entityOnboardingSession) { }
#pragma warning restore CS8618

    public EntityOnboardingSession(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityOnboardingSession(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityOnboardingSessionFromRaw.FromRawUnchecked"/>
    public static EntityOnboardingSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityOnboardingSessionFromRaw : IFromRawJson<EntityOnboardingSession>
{
    /// <inheritdoc/>
    public EntityOnboardingSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityOnboardingSession.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the onboarding session.
/// </summary>
[JsonConverter(typeof(EntityOnboardingSessionStatusConverter))]
public enum EntityOnboardingSessionStatus
{
    /// <summary>
    /// The Entity Onboarding Session is active.
    /// </summary>
    Active,

    /// <summary>
    /// The Entity Onboarding Session has expired.
    /// </summary>
    Expired,
}

sealed class EntityOnboardingSessionStatusConverter : JsonConverter<EntityOnboardingSessionStatus>
{
    public override EntityOnboardingSessionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => EntityOnboardingSessionStatus.Active,
            "expired" => EntityOnboardingSessionStatus.Expired,
            _ => (EntityOnboardingSessionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityOnboardingSessionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityOnboardingSessionStatus.Active => "active",
                EntityOnboardingSessionStatus.Expired => "expired",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `entity_onboarding_session`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    EntityOnboardingSession,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.EntityOnboardingSessions.Type>
{
    public override global::Increase.Api.Models.EntityOnboardingSessions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entity_onboarding_session" => global::Increase
                .Api
                .Models
                .EntityOnboardingSessions
                .Type
                .EntityOnboardingSession,
            _ => (global::Increase.Api.Models.EntityOnboardingSessions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.EntityOnboardingSessions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.EntityOnboardingSessions.Type.EntityOnboardingSession =>
                    "entity_onboarding_session",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
