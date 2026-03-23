using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.DigitalCardProfiles;

/// <summary>
/// This contains artwork and metadata relating to a Card's appearance in digital
/// wallet apps like Apple Pay and Google Pay. For more information, see our guide
/// on [digital card artwork](https://increase.com/documentation/card-art).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DigitalCardProfile, DigitalCardProfileFromRaw>))]
public sealed record class DigitalCardProfile : JsonModel
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
    /// The identifier of the File containing the card's icon image.
    /// </summary>
    public required string AppIconFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("app_icon_file_id");
        }
        init { this._rawData.Set("app_icon_file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the card's front image.
    /// </summary>
    public required string BackgroundImageFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("background_image_file_id");
        }
        init { this._rawData.Set("background_image_file_id", value); }
    }

    /// <summary>
    /// A user-facing description for the card itself.
    /// </summary>
    public required string CardDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("card_description");
        }
        init { this._rawData.Set("card_description", value); }
    }

    /// <summary>
    /// An email address the user can contact to receive support for their card.
    /// </summary>
    public required string? ContactEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_email");
        }
        init { this._rawData.Set("contact_email", value); }
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
    /// A website the user can visit to view and receive support for their card.
    /// </summary>
    public required string? ContactWebsite
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_website");
        }
        init { this._rawData.Set("contact_website", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Digital Card Profile was created.
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
    /// A description you can use to identify the Card Profile.
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
    /// A user-facing description for whoever is issuing the card.
    /// </summary>
    public required string IssuerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("issuer_name");
        }
        init { this._rawData.Set("issuer_name", value); }
    }

    /// <summary>
    /// The status of the Card Profile.
    /// </summary>
    public required ApiEnum<string, DigitalCardProfileStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DigitalCardProfileStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The Card's text color, specified as an RGB triple.
    /// </summary>
    public required DigitalCardProfileTextColor TextColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DigitalCardProfileTextColor>("text_color");
        }
        init { this._rawData.Set("text_color", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `digital_card_profile`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.DigitalCardProfiles.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.DigitalCardProfiles.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AppIconFileID;
        _ = this.BackgroundImageFileID;
        _ = this.CardDescription;
        _ = this.ContactEmail;
        _ = this.ContactPhone;
        _ = this.ContactWebsite;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.IdempotencyKey;
        _ = this.IssuerName;
        this.Status.Validate();
        this.TextColor.Validate();
        this.Type.Validate();
    }

    public DigitalCardProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfile(DigitalCardProfile digitalCardProfile)
        : base(digitalCardProfile) { }
#pragma warning restore CS8618

    public DigitalCardProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalCardProfileFromRaw : IFromRawJson<DigitalCardProfile>
{
    /// <inheritdoc/>
    public DigitalCardProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigitalCardProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the Card Profile.
/// </summary>
[JsonConverter(typeof(DigitalCardProfileStatusConverter))]
public enum DigitalCardProfileStatus
{
    /// <summary>
    /// The Card Profile is awaiting review from Increase and/or processing by card networks.
    /// </summary>
    Pending,

    /// <summary>
    /// There is an issue with the Card Profile preventing it from use.
    /// </summary>
    Rejected,

    /// <summary>
    /// The Card Profile can be assigned to Cards.
    /// </summary>
    Active,

    /// <summary>
    /// The Card Profile is no longer in use.
    /// </summary>
    Archived,
}

sealed class DigitalCardProfileStatusConverter : JsonConverter<DigitalCardProfileStatus>
{
    public override DigitalCardProfileStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => DigitalCardProfileStatus.Pending,
            "rejected" => DigitalCardProfileStatus.Rejected,
            "active" => DigitalCardProfileStatus.Active,
            "archived" => DigitalCardProfileStatus.Archived,
            _ => (DigitalCardProfileStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DigitalCardProfileStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DigitalCardProfileStatus.Pending => "pending",
                DigitalCardProfileStatus.Rejected => "rejected",
                DigitalCardProfileStatus.Active => "active",
                DigitalCardProfileStatus.Archived => "archived",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The Card's text color, specified as an RGB triple.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DigitalCardProfileTextColor, DigitalCardProfileTextColorFromRaw>)
)]
public sealed record class DigitalCardProfileTextColor : JsonModel
{
    /// <summary>
    /// The value of the blue channel in the RGB color.
    /// </summary>
    public required long Blue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("blue");
        }
        init { this._rawData.Set("blue", value); }
    }

    /// <summary>
    /// The value of the green channel in the RGB color.
    /// </summary>
    public required long Green
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("green");
        }
        init { this._rawData.Set("green", value); }
    }

    /// <summary>
    /// The value of the red channel in the RGB color.
    /// </summary>
    public required long Red
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("red");
        }
        init { this._rawData.Set("red", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Blue;
        _ = this.Green;
        _ = this.Red;
    }

    public DigitalCardProfileTextColor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileTextColor(DigitalCardProfileTextColor digitalCardProfileTextColor)
        : base(digitalCardProfileTextColor) { }
#pragma warning restore CS8618

    public DigitalCardProfileTextColor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfileTextColor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileTextColorFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfileTextColor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalCardProfileTextColorFromRaw : IFromRawJson<DigitalCardProfileTextColor>
{
    /// <inheritdoc/>
    public DigitalCardProfileTextColor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalCardProfileTextColor.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `digital_card_profile`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    DigitalCardProfile,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.DigitalCardProfiles.Type>
{
    public override global::Increase.Api.Models.DigitalCardProfiles.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "digital_card_profile" => global::Increase
                .Api
                .Models
                .DigitalCardProfiles
                .Type
                .DigitalCardProfile,
            _ => (global::Increase.Api.Models.DigitalCardProfiles.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.DigitalCardProfiles.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.DigitalCardProfiles.Type.DigitalCardProfile =>
                    "digital_card_profile",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
