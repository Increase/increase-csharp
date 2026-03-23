using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.BeneficialOwners;

/// <summary>
/// Beneficial owners are the individuals who control or own 25% or more of a `corporation`
/// entity. Beneficial owners are always people, and never organizations. Generally,
/// you will need to submit between 1 and 5 beneficial owners for every `corporation`
/// entity. You should update and archive beneficial owners for a corporation entity
/// as their details change.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityBeneficialOwner, EntityBeneficialOwnerFromRaw>))]
public sealed record class EntityBeneficialOwner : JsonModel
{
    /// <summary>
    /// The identifier of this beneficial owner.
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
    /// This person's role or title within the entity.
    /// </summary>
    public required string? CompanyTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_title");
        }
        init { this._rawData.Set("company_title", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Beneficial
    /// Owner was created.
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
    /// The identifier of the Entity to which this beneficial owner belongs.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entity_id");
        }
        init { this._rawData.Set("entity_id", value); }
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
    /// Personal details for the beneficial owner.
    /// </summary>
    public required EntityBeneficialOwnerIndividual Individual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityBeneficialOwnerIndividual>("individual");
        }
        init { this._rawData.Set("individual", value); }
    }

    /// <summary>
    /// Why this person is considered a beneficial owner of the entity.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EntityBeneficialOwnerProng>> Prongs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntityBeneficialOwnerProng>>
            >("prongs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, EntityBeneficialOwnerProng>>>(
                "prongs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `entity_beneficial_owner`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.BeneficialOwners.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.BeneficialOwners.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompanyTitle;
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.IdempotencyKey;
        this.Individual.Validate();
        foreach (var item in this.Prongs)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public EntityBeneficialOwner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBeneficialOwner(EntityBeneficialOwner entityBeneficialOwner)
        : base(entityBeneficialOwner) { }
#pragma warning restore CS8618

    public EntityBeneficialOwner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBeneficialOwner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBeneficialOwnerFromRaw.FromRawUnchecked"/>
    public static EntityBeneficialOwner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBeneficialOwnerFromRaw : IFromRawJson<EntityBeneficialOwner>
{
    /// <inheritdoc/>
    public EntityBeneficialOwner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBeneficialOwner.FromRawUnchecked(rawData);
}

/// <summary>
/// Personal details for the beneficial owner.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityBeneficialOwnerIndividual,
        EntityBeneficialOwnerIndividualFromRaw
    >)
)]
public sealed record class EntityBeneficialOwnerIndividual : JsonModel
{
    /// <summary>
    /// The person's address.
    /// </summary>
    public required EntityBeneficialOwnerIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityBeneficialOwnerIndividualAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The person's date of birth in YYYY-MM-DD format.
    /// </summary>
    public required string DateOfBirth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("date_of_birth");
        }
        init { this._rawData.Set("date_of_birth", value); }
    }

    /// <summary>
    /// A means of verifying the person's identity.
    /// </summary>
    public required EntityBeneficialOwnerIndividualIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityBeneficialOwnerIndividualIdentification>(
                "identification"
            );
        }
        init { this._rawData.Set("identification", value); }
    }

    /// <summary>
    /// The person's legal name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.DateOfBirth;
        this.Identification.Validate();
        _ = this.Name;
    }

    public EntityBeneficialOwnerIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBeneficialOwnerIndividual(
        EntityBeneficialOwnerIndividual entityBeneficialOwnerIndividual
    )
        : base(entityBeneficialOwnerIndividual) { }
#pragma warning restore CS8618

    public EntityBeneficialOwnerIndividual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBeneficialOwnerIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBeneficialOwnerIndividualFromRaw.FromRawUnchecked"/>
    public static EntityBeneficialOwnerIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBeneficialOwnerIndividualFromRaw : IFromRawJson<EntityBeneficialOwnerIndividual>
{
    /// <inheritdoc/>
    public EntityBeneficialOwnerIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBeneficialOwnerIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The person's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityBeneficialOwnerIndividualAddress,
        EntityBeneficialOwnerIndividualAddressFromRaw
    >)
)]
public sealed record class EntityBeneficialOwnerIndividualAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
    /// </summary>
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The two-letter ISO 3166-1 alpha-2 code for the country of the address.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The first line of the address.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of the address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the US
    /// state, province, or region of the address.
    /// </summary>
    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP or postal code of the address.
    /// </summary>
    public required string? Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.State;
        _ = this.Zip;
    }

    public EntityBeneficialOwnerIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBeneficialOwnerIndividualAddress(
        EntityBeneficialOwnerIndividualAddress entityBeneficialOwnerIndividualAddress
    )
        : base(entityBeneficialOwnerIndividualAddress) { }
#pragma warning restore CS8618

    public EntityBeneficialOwnerIndividualAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBeneficialOwnerIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBeneficialOwnerIndividualAddressFromRaw.FromRawUnchecked"/>
    public static EntityBeneficialOwnerIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBeneficialOwnerIndividualAddressFromRaw
    : IFromRawJson<EntityBeneficialOwnerIndividualAddress>
{
    /// <inheritdoc/>
    public EntityBeneficialOwnerIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBeneficialOwnerIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityBeneficialOwnerIndividualIdentification,
        EntityBeneficialOwnerIndividualIdentificationFromRaw
    >)
)]
public sealed record class EntityBeneficialOwnerIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, EntityBeneficialOwnerIndividualIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityBeneficialOwnerIndividualIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// The last 4 digits of the identification number that can be used to verify
    /// the individual's identity.
    /// </summary>
    public required string NumberLast4
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("number_last4");
        }
        init { this._rawData.Set("number_last4", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.NumberLast4;
    }

    public EntityBeneficialOwnerIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityBeneficialOwnerIndividualIdentification(
        EntityBeneficialOwnerIndividualIdentification entityBeneficialOwnerIndividualIdentification
    )
        : base(entityBeneficialOwnerIndividualIdentification) { }
#pragma warning restore CS8618

    public EntityBeneficialOwnerIndividualIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityBeneficialOwnerIndividualIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityBeneficialOwnerIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityBeneficialOwnerIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityBeneficialOwnerIndividualIdentificationFromRaw
    : IFromRawJson<EntityBeneficialOwnerIndividualIdentification>
{
    /// <inheritdoc/>
    public EntityBeneficialOwnerIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityBeneficialOwnerIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityBeneficialOwnerIndividualIdentificationMethodConverter))]
public enum EntityBeneficialOwnerIndividualIdentificationMethod
{
    /// <summary>
    /// A social security number.
    /// </summary>
    SocialSecurityNumber,

    /// <summary>
    /// An individual taxpayer identification number (ITIN).
    /// </summary>
    IndividualTaxpayerIdentificationNumber,

    /// <summary>
    /// A passport number.
    /// </summary>
    Passport,

    /// <summary>
    /// A driver's license number.
    /// </summary>
    DriversLicense,

    /// <summary>
    /// Another identifying document.
    /// </summary>
    Other,
}

sealed class EntityBeneficialOwnerIndividualIdentificationMethodConverter
    : JsonConverter<EntityBeneficialOwnerIndividualIdentificationMethod>
{
    public override EntityBeneficialOwnerIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityBeneficialOwnerIndividualIdentificationMethod.Passport,
            "drivers_license" => EntityBeneficialOwnerIndividualIdentificationMethod.DriversLicense,
            "other" => EntityBeneficialOwnerIndividualIdentificationMethod.Other,
            _ => (EntityBeneficialOwnerIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityBeneficialOwnerIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityBeneficialOwnerIndividualIdentificationMethod.Passport => "passport",
                EntityBeneficialOwnerIndividualIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityBeneficialOwnerIndividualIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntityBeneficialOwnerProngConverter))]
public enum EntityBeneficialOwnerProng
{
    /// <summary>
    /// A person with 25% or greater direct or indirect ownership of the entity.
    /// </summary>
    Ownership,

    /// <summary>
    /// A person who manages, directs, or has significant control of the entity.
    /// </summary>
    Control,
}

sealed class EntityBeneficialOwnerProngConverter : JsonConverter<EntityBeneficialOwnerProng>
{
    public override EntityBeneficialOwnerProng Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ownership" => EntityBeneficialOwnerProng.Ownership,
            "control" => EntityBeneficialOwnerProng.Control,
            _ => (EntityBeneficialOwnerProng)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityBeneficialOwnerProng value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityBeneficialOwnerProng.Ownership => "ownership",
                EntityBeneficialOwnerProng.Control => "control",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `entity_beneficial_owner`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    EntityBeneficialOwner,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.BeneficialOwners.Type>
{
    public override global::Increase.Api.Models.BeneficialOwners.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entity_beneficial_owner" => global::Increase
                .Api
                .Models
                .BeneficialOwners
                .Type
                .EntityBeneficialOwner,
            _ => (global::Increase.Api.Models.BeneficialOwners.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.BeneficialOwners.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.BeneficialOwners.Type.EntityBeneficialOwner =>
                    "entity_beneficial_owner",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
