using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.PhysicalCardProfiles;

/// <summary>
/// This contains artwork and metadata relating to a Physical Card's appearance. For
/// more information, see our guide on [physical card artwork](https://increase.com/documentation/card-art-physical-cards).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhysicalCardProfile, PhysicalCardProfileFromRaw>))]
public sealed record class PhysicalCardProfile : JsonModel
{
    /// <summary>
    /// The Card Profile identifier.
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
    /// The identifier of the File containing the physical card's back image. This
    /// will be missing until the image has been post-processed.
    /// </summary>
    public required string? BackImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_image_file_id");
        }
        init { this._rawData.Set("back_image_file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the physical card's carrier image. This
    /// will be missing until the image has been post-processed.
    /// </summary>
    public required string? CarrierImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("carrier_image_file_id");
        }
        init { this._rawData.Set("carrier_image_file_id", value); }
    }

    /// <summary>
    /// A phone number the user can contact to receive support for their card.
    /// </summary>
    public required string? ContactPhone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_phone");
        }
        init { this._rawData.Set("contact_phone", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Physical Card Profile was created.
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
    /// The creator of this Physical Card Profile.
    /// </summary>
    public required ApiEnum<string, Creator> Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Creator>>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    /// <summary>
    /// A description you can use to identify the Physical Card Profile.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The identifier of the File containing the physical card's front image. This
    /// will be missing until the image has been post-processed.
    /// </summary>
    public required string? FrontImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("front_image_file_id");
        }
        init { this._rawData.Set("front_image_file_id", value); }
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
    /// Whether this Physical Card Profile is the default for all cards in its Increase group.
    /// </summary>
    public required bool IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_default");
        }
        init { this._rawData.Set("is_default", value); }
    }

    /// <summary>
    /// The identifier for the Program this Physical Card Profile belongs to.
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
    /// The status of the Physical Card Profile.
    /// </summary>
    public required ApiEnum<string, PhysicalCardProfileStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhysicalCardProfileStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `physical_card_profile`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.PhysicalCardProfiles.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.PhysicalCardProfiles.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BackImageFileID;
        _ = this.CarrierImageFileID;
        _ = this.ContactPhone;
        _ = this.CreatedAt;
        this.Creator.Validate();
        _ = this.Description;
        _ = this.FrontImageFileID;
        _ = this.IdempotencyKey;
        _ = this.IsDefault;
        _ = this.ProgramID;
        this.Status.Validate();
        this.Type.Validate();
    }

    public PhysicalCardProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardProfile(PhysicalCardProfile physicalCardProfile)
        : base(physicalCardProfile) { }
#pragma warning restore CS8618

    public PhysicalCardProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardProfileFromRaw.FromRawUnchecked"/>
    public static PhysicalCardProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCardProfileFromRaw : IFromRawJson<PhysicalCardProfile>
{
    /// <inheritdoc/>
    public PhysicalCardProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhysicalCardProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// The creator of this Physical Card Profile.
/// </summary>
[JsonConverter(typeof(CreatorConverter))]
public enum Creator
{
    /// <summary>
    /// This Physical Card Profile was created by Increase.
    /// </summary>
    Increase,

    /// <summary>
    /// This Physical Card Profile was created by you.
    /// </summary>
    User,
}

sealed class CreatorConverter : JsonConverter<Creator>
{
    public override Creator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increase" => Creator.Increase,
            "user" => Creator.User,
            _ => (Creator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Creator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Creator.Increase => "increase",
                Creator.User => "user",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the Physical Card Profile.
/// </summary>
[JsonConverter(typeof(PhysicalCardProfileStatusConverter))]
public enum PhysicalCardProfileStatus
{
    /// <summary>
    /// The Card Profile has not yet been processed by Increase.
    /// </summary>
    PendingCreating,

    /// <summary>
    /// The card profile is awaiting review by Increase.
    /// </summary>
    PendingReviewing,

    /// <summary>
    /// There is an issue with the Physical Card Profile preventing it from use.
    /// </summary>
    Rejected,

    /// <summary>
    /// The card profile is awaiting submission to the fulfillment provider.
    /// </summary>
    PendingSubmitting,

    /// <summary>
    /// The Physical Card Profile has been submitted to the fulfillment provider and
    /// is ready to use.
    /// </summary>
    Active,

    /// <summary>
    /// The Physical Card Profile has been archived.
    /// </summary>
    Archived,
}

sealed class PhysicalCardProfileStatusConverter : JsonConverter<PhysicalCardProfileStatus>
{
    public override PhysicalCardProfileStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_creating" => PhysicalCardProfileStatus.PendingCreating,
            "pending_reviewing" => PhysicalCardProfileStatus.PendingReviewing,
            "rejected" => PhysicalCardProfileStatus.Rejected,
            "pending_submitting" => PhysicalCardProfileStatus.PendingSubmitting,
            "active" => PhysicalCardProfileStatus.Active,
            "archived" => PhysicalCardProfileStatus.Archived,
            _ => (PhysicalCardProfileStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhysicalCardProfileStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhysicalCardProfileStatus.PendingCreating => "pending_creating",
                PhysicalCardProfileStatus.PendingReviewing => "pending_reviewing",
                PhysicalCardProfileStatus.Rejected => "rejected",
                PhysicalCardProfileStatus.PendingSubmitting => "pending_submitting",
                PhysicalCardProfileStatus.Active => "active",
                PhysicalCardProfileStatus.Archived => "archived",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `physical_card_profile`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    PhysicalCardProfile,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.PhysicalCardProfiles.Type>
{
    public override global::Increase.Api.Models.PhysicalCardProfiles.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical_card_profile" => global::Increase
                .Api
                .Models
                .PhysicalCardProfiles
                .Type
                .PhysicalCardProfile,
            _ => (global::Increase.Api.Models.PhysicalCardProfiles.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.PhysicalCardProfiles.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.PhysicalCardProfiles.Type.PhysicalCardProfile =>
                    "physical_card_profile",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
