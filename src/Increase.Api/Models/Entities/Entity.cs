using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.SupplementalDocuments;
using System = System;

namespace Increase.Api.Models.Entities;

/// <summary>
/// Entities are the legal entities that own accounts. They can be people, corporations,
/// partnerships, government authorities, or trusts. To learn more, see [Entities](/documentation/entities).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entity, EntityFromRaw>))]
public sealed record class Entity : JsonModel
{
    /// <summary>
    /// The entity's identifier.
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
    /// Details of the corporation entity. Will be present if `structure` is equal
    /// to `corporation`.
    /// </summary>
    public required EntityCorporation? Corporation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityCorporation>("corporation");
        }
        init { this._rawData.Set("corporation", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Entity
    /// was created.
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
    /// The identifier of the Entity Onboarding Session that was used to create this
    /// Entity, if any.
    /// </summary>
    public required string? CreatingEntityOnboardingSessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creating_entity_onboarding_session_id");
        }
        init { this._rawData.Set("creating_entity_onboarding_session_id", value); }
    }

    /// <summary>
    /// The entity's description for display purposes.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Entity's
    /// details were most recently confirmed.
    /// </summary>
    public required System::DateTimeOffset? DetailsConfirmedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("details_confirmed_at");
        }
        init { this._rawData.Set("details_confirmed_at", value); }
    }

    /// <summary>
    /// Details of the government authority entity. Will be present if `structure`
    /// is equal to `government_authority`.
    /// </summary>
    public required EntityGovernmentAuthority? GovernmentAuthority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityGovernmentAuthority>(
                "government_authority"
            );
        }
        init { this._rawData.Set("government_authority", value); }
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
    /// Details of the joint entity. Will be present if `structure` is equal to `joint`.
    /// </summary>
    public required EntityJoint? Joint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityJoint>("joint");
        }
        init { this._rawData.Set("joint", value); }
    }

    /// <summary>
    /// Details of the natural person entity. Will be present if `structure` is equal
    /// to `natural_person`.
    /// </summary>
    public required EntityNaturalPerson? NaturalPerson
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityNaturalPerson>("natural_person");
        }
        init { this._rawData.Set("natural_person", value); }
    }

    /// <summary>
    /// An assessment of the entity’s potential risk of involvement in financial crimes,
    /// such as money laundering.
    /// </summary>
    public required EntityRiskRating? RiskRating
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityRiskRating>("risk_rating");
        }
        init { this._rawData.Set("risk_rating", value); }
    }

    /// <summary>
    /// The status of the entity.
    /// </summary>
    public required ApiEnum<string, EntityStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The entity's legal structure.
    /// </summary>
    public required ApiEnum<string, EntityStructure> Structure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityStructure>>("structure");
        }
        init { this._rawData.Set("structure", value); }
    }

    /// <summary>
    /// Additional documentation associated with the entity. This is limited to the
    /// first 10 documents for an entity. If an entity has more than 10 documents,
    /// use the GET /entity_supplemental_documents list endpoint to retrieve them.
    /// </summary>
    public required IReadOnlyList<EntitySupplementalDocument> SupplementalDocuments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitySupplementalDocument>>(
                "supplemental_documents"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitySupplementalDocument>>(
                "supplemental_documents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The terms that the Entity agreed to. Not all programs are required to submit
    /// this data.
    /// </summary>
    public required IReadOnlyList<EntityTermsAgreement> TermsAgreements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityTermsAgreement>>(
                "terms_agreements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityTermsAgreement>>(
                "terms_agreements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If you are using a third-party service for identity verification, you can
    /// use this field to associate this Entity with the identifier that represents
    /// them in that service.
    /// </summary>
    public required EntityThirdPartyVerification? ThirdPartyVerification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityThirdPartyVerification>(
                "third_party_verification"
            );
        }
        init { this._rawData.Set("third_party_verification", value); }
    }

    /// <summary>
    /// Details of the trust entity. Will be present if `structure` is equal to `trust`.
    /// </summary>
    public required EntityTrust? Trust
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityTrust>("trust");
        }
        init { this._rawData.Set("trust", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `entity`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Entities.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Entities.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The validation results for the entity. Learn more about [validations](/documentation/entity-validation).
    /// </summary>
    public required Validation? Validation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Validation>("validation");
        }
        init { this._rawData.Set("validation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Corporation?.Validate();
        _ = this.CreatedAt;
        _ = this.CreatingEntityOnboardingSessionID;
        _ = this.Description;
        _ = this.DetailsConfirmedAt;
        this.GovernmentAuthority?.Validate();
        _ = this.IdempotencyKey;
        this.Joint?.Validate();
        this.NaturalPerson?.Validate();
        this.RiskRating?.Validate();
        this.Status.Validate();
        this.Structure.Validate();
        foreach (var item in this.SupplementalDocuments)
        {
            item.Validate();
        }
        foreach (var item in this.TermsAgreements)
        {
            item.Validate();
        }
        this.ThirdPartyVerification?.Validate();
        this.Trust?.Validate();
        this.Type.Validate();
        this.Validation?.Validate();
    }

    public Entity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entity(Entity entity)
        : base(entity) { }
#pragma warning restore CS8618

    public Entity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityFromRaw.FromRawUnchecked"/>
    public static Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityFromRaw : IFromRawJson<Entity>
{
    /// <inheritdoc/>
    public Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entity.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the corporation entity. Will be present if `structure` is equal to `corporation`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityCorporation, EntityCorporationFromRaw>))]
public sealed record class EntityCorporation : JsonModel
{
    /// <summary>
    /// The corporation's address.
    /// </summary>
    public required EntityCorporationAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityCorporationAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The identifying details of anyone controlling or owning 25% or more of the corporation.
    /// </summary>
    public required IReadOnlyList<EntityCorporationBeneficialOwner> BeneficialOwners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityCorporationBeneficialOwner>>(
                "beneficial_owners"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityCorporationBeneficialOwner>>(
                "beneficial_owners",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An email address for the business.
    /// </summary>
    public required string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the corporation's
    /// state of incorporation.
    /// </summary>
    public required string? IncorporationState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("incorporation_state");
        }
        init { this._rawData.Set("incorporation_state", value); }
    }

    /// <summary>
    /// The numeric North American Industry Classification System (NAICS) code submitted
    /// for the corporation.
    /// </summary>
    public required string? IndustryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("industry_code");
        }
        init { this._rawData.Set("industry_code", value); }
    }

    /// <summary>
    /// The legal identifier of the corporation.
    /// </summary>
    public required EntityCorporationLegalIdentifier? LegalIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityCorporationLegalIdentifier>(
                "legal_identifier"
            );
        }
        init { this._rawData.Set("legal_identifier", value); }
    }

    /// <summary>
    /// The legal name of the corporation.
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

    /// <summary>
    /// The website of the corporation.
    /// </summary>
    public required string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        foreach (var item in this.BeneficialOwners)
        {
            item.Validate();
        }
        _ = this.Email;
        _ = this.IncorporationState;
        _ = this.IndustryCode;
        this.LegalIdentifier?.Validate();
        _ = this.Name;
        _ = this.Website;
    }

    public EntityCorporation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporation(EntityCorporation entityCorporation)
        : base(entityCorporation) { }
#pragma warning restore CS8618

    public EntityCorporation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationFromRaw.FromRawUnchecked"/>
    public static EntityCorporation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationFromRaw : IFromRawJson<EntityCorporation>
{
    /// <inheritdoc/>
    public EntityCorporation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityCorporation.FromRawUnchecked(rawData);
}

/// <summary>
/// The corporation's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityCorporationAddress, EntityCorporationAddressFromRaw>)
)]
public sealed record class EntityCorporationAddress : JsonModel
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

    public EntityCorporationAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporationAddress(EntityCorporationAddress entityCorporationAddress)
        : base(entityCorporationAddress) { }
#pragma warning restore CS8618

    public EntityCorporationAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporationAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationAddressFromRaw.FromRawUnchecked"/>
    public static EntityCorporationAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationAddressFromRaw : IFromRawJson<EntityCorporationAddress>
{
    /// <inheritdoc/>
    public EntityCorporationAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityCorporationAddress.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntityCorporationBeneficialOwner,
        EntityCorporationBeneficialOwnerFromRaw
    >)
)]
public sealed record class EntityCorporationBeneficialOwner : JsonModel
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
    /// Personal details for the beneficial owner.
    /// </summary>
    public required EntityCorporationBeneficialOwnerIndividual Individual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityCorporationBeneficialOwnerIndividual>(
                "individual"
            );
        }
        init { this._rawData.Set("individual", value); }
    }

    /// <summary>
    /// Why this person is considered a beneficial owner of the entity.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EntityCorporationBeneficialOwnerProng>> Prongs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntityCorporationBeneficialOwnerProng>>
            >("prongs");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, EntityCorporationBeneficialOwnerProng>>
            >("prongs", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompanyTitle;
        this.Individual.Validate();
        foreach (var item in this.Prongs)
        {
            item.Validate();
        }
    }

    public EntityCorporationBeneficialOwner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporationBeneficialOwner(
        EntityCorporationBeneficialOwner entityCorporationBeneficialOwner
    )
        : base(entityCorporationBeneficialOwner) { }
#pragma warning restore CS8618

    public EntityCorporationBeneficialOwner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporationBeneficialOwner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationBeneficialOwnerFromRaw.FromRawUnchecked"/>
    public static EntityCorporationBeneficialOwner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationBeneficialOwnerFromRaw : IFromRawJson<EntityCorporationBeneficialOwner>
{
    /// <inheritdoc/>
    public EntityCorporationBeneficialOwner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityCorporationBeneficialOwner.FromRawUnchecked(rawData);
}

/// <summary>
/// Personal details for the beneficial owner.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityCorporationBeneficialOwnerIndividual,
        EntityCorporationBeneficialOwnerIndividualFromRaw
    >)
)]
public sealed record class EntityCorporationBeneficialOwnerIndividual : JsonModel
{
    /// <summary>
    /// The person's address.
    /// </summary>
    public required EntityCorporationBeneficialOwnerIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityCorporationBeneficialOwnerIndividualAddress>(
                "address"
            );
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
    public required EntityCorporationBeneficialOwnerIndividualIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityCorporationBeneficialOwnerIndividualIdentification>(
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
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityCorporationBeneficialOwnerIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporationBeneficialOwnerIndividual(
        EntityCorporationBeneficialOwnerIndividual entityCorporationBeneficialOwnerIndividual
    )
        : base(entityCorporationBeneficialOwnerIndividual) { }
#pragma warning restore CS8618

    public EntityCorporationBeneficialOwnerIndividual(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporationBeneficialOwnerIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationBeneficialOwnerIndividualFromRaw.FromRawUnchecked"/>
    public static EntityCorporationBeneficialOwnerIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationBeneficialOwnerIndividualFromRaw
    : IFromRawJson<EntityCorporationBeneficialOwnerIndividual>
{
    /// <inheritdoc/>
    public EntityCorporationBeneficialOwnerIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityCorporationBeneficialOwnerIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The person's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityCorporationBeneficialOwnerIndividualAddress,
        EntityCorporationBeneficialOwnerIndividualAddressFromRaw
    >)
)]
public sealed record class EntityCorporationBeneficialOwnerIndividualAddress : JsonModel
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

    public EntityCorporationBeneficialOwnerIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporationBeneficialOwnerIndividualAddress(
        EntityCorporationBeneficialOwnerIndividualAddress entityCorporationBeneficialOwnerIndividualAddress
    )
        : base(entityCorporationBeneficialOwnerIndividualAddress) { }
#pragma warning restore CS8618

    public EntityCorporationBeneficialOwnerIndividualAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporationBeneficialOwnerIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationBeneficialOwnerIndividualAddressFromRaw.FromRawUnchecked"/>
    public static EntityCorporationBeneficialOwnerIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationBeneficialOwnerIndividualAddressFromRaw
    : IFromRawJson<EntityCorporationBeneficialOwnerIndividualAddress>
{
    /// <inheritdoc/>
    public EntityCorporationBeneficialOwnerIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityCorporationBeneficialOwnerIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityCorporationBeneficialOwnerIndividualIdentification,
        EntityCorporationBeneficialOwnerIndividualIdentificationFromRaw
    >)
)]
public sealed record class EntityCorporationBeneficialOwnerIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<
        string,
        EntityCorporationBeneficialOwnerIndividualIdentificationMethod
    > Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityCorporationBeneficialOwnerIndividualIdentificationMethod>
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

    public EntityCorporationBeneficialOwnerIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporationBeneficialOwnerIndividualIdentification(
        EntityCorporationBeneficialOwnerIndividualIdentification entityCorporationBeneficialOwnerIndividualIdentification
    )
        : base(entityCorporationBeneficialOwnerIndividualIdentification) { }
#pragma warning restore CS8618

    public EntityCorporationBeneficialOwnerIndividualIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporationBeneficialOwnerIndividualIdentification(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationBeneficialOwnerIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityCorporationBeneficialOwnerIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationBeneficialOwnerIndividualIdentificationFromRaw
    : IFromRawJson<EntityCorporationBeneficialOwnerIndividualIdentification>
{
    /// <inheritdoc/>
    public EntityCorporationBeneficialOwnerIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityCorporationBeneficialOwnerIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityCorporationBeneficialOwnerIndividualIdentificationMethodConverter))]
public enum EntityCorporationBeneficialOwnerIndividualIdentificationMethod
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

sealed class EntityCorporationBeneficialOwnerIndividualIdentificationMethodConverter
    : JsonConverter<EntityCorporationBeneficialOwnerIndividualIdentificationMethod>
{
    public override EntityCorporationBeneficialOwnerIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Passport,
            "drivers_license" =>
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.DriversLicense,
            "other" => EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Other,
            _ => (EntityCorporationBeneficialOwnerIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityCorporationBeneficialOwnerIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Passport =>
                    "passport",
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntityCorporationBeneficialOwnerProngConverter))]
public enum EntityCorporationBeneficialOwnerProng
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

sealed class EntityCorporationBeneficialOwnerProngConverter
    : JsonConverter<EntityCorporationBeneficialOwnerProng>
{
    public override EntityCorporationBeneficialOwnerProng Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ownership" => EntityCorporationBeneficialOwnerProng.Ownership,
            "control" => EntityCorporationBeneficialOwnerProng.Control,
            _ => (EntityCorporationBeneficialOwnerProng)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityCorporationBeneficialOwnerProng value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityCorporationBeneficialOwnerProng.Ownership => "ownership",
                EntityCorporationBeneficialOwnerProng.Control => "control",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The legal identifier of the corporation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityCorporationLegalIdentifier,
        EntityCorporationLegalIdentifierFromRaw
    >)
)]
public sealed record class EntityCorporationLegalIdentifier : JsonModel
{
    /// <summary>
    /// The category of the legal identifier.
    /// </summary>
    public required ApiEnum<string, EntityCorporationLegalIdentifierCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityCorporationLegalIdentifierCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The identifier of the legal identifier.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        _ = this.Value;
    }

    public EntityCorporationLegalIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCorporationLegalIdentifier(
        EntityCorporationLegalIdentifier entityCorporationLegalIdentifier
    )
        : base(entityCorporationLegalIdentifier) { }
#pragma warning restore CS8618

    public EntityCorporationLegalIdentifier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityCorporationLegalIdentifier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityCorporationLegalIdentifierFromRaw.FromRawUnchecked"/>
    public static EntityCorporationLegalIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityCorporationLegalIdentifierFromRaw : IFromRawJson<EntityCorporationLegalIdentifier>
{
    /// <inheritdoc/>
    public EntityCorporationLegalIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityCorporationLegalIdentifier.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the legal identifier.
/// </summary>
[JsonConverter(typeof(EntityCorporationLegalIdentifierCategoryConverter))]
public enum EntityCorporationLegalIdentifierCategory
{
    /// <summary>
    /// The Employer Identification Number (EIN) for the company. The EIN is a 9-digit
    /// number assigned by the IRS.
    /// </summary>
    UsEmployerIdentificationNumber,

    /// <summary>
    /// A legal identifier issued by a foreign government, like a tax identification
    /// number or registration number.
    /// </summary>
    Other,
}

sealed class EntityCorporationLegalIdentifierCategoryConverter
    : JsonConverter<EntityCorporationLegalIdentifierCategory>
{
    public override EntityCorporationLegalIdentifierCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us_employer_identification_number" =>
                EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            "other" => EntityCorporationLegalIdentifierCategory.Other,
            _ => (EntityCorporationLegalIdentifierCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityCorporationLegalIdentifierCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber =>
                    "us_employer_identification_number",
                EntityCorporationLegalIdentifierCategory.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the government authority entity. Will be present if `structure` is
/// equal to `government_authority`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityGovernmentAuthority, EntityGovernmentAuthorityFromRaw>)
)]
public sealed record class EntityGovernmentAuthority : JsonModel
{
    /// <summary>
    /// The government authority's address.
    /// </summary>
    public required EntityGovernmentAuthorityAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityGovernmentAuthorityAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The identifying details of authorized persons of the government authority.
    /// </summary>
    public required IReadOnlyList<EntityGovernmentAuthorityAuthorizedPerson> AuthorizedPersons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<EntityGovernmentAuthorityAuthorizedPerson>
            >("authorized_persons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityGovernmentAuthorityAuthorizedPerson>>(
                "authorized_persons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The category of the government authority.
    /// </summary>
    public required ApiEnum<string, EntityGovernmentAuthorityCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityGovernmentAuthorityCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The government authority's name.
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

    /// <summary>
    /// The Employer Identification Number (EIN) of the government authority.
    /// </summary>
    public required string? TaxIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_identifier");
        }
        init { this._rawData.Set("tax_identifier", value); }
    }

    /// <summary>
    /// The government authority's website.
    /// </summary>
    public required string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        foreach (var item in this.AuthorizedPersons)
        {
            item.Validate();
        }
        this.Category.Validate();
        _ = this.Name;
        _ = this.TaxIdentifier;
        _ = this.Website;
    }

    public EntityGovernmentAuthority() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityGovernmentAuthority(EntityGovernmentAuthority entityGovernmentAuthority)
        : base(entityGovernmentAuthority) { }
#pragma warning restore CS8618

    public EntityGovernmentAuthority(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityGovernmentAuthority(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityGovernmentAuthorityFromRaw.FromRawUnchecked"/>
    public static EntityGovernmentAuthority FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityGovernmentAuthorityFromRaw : IFromRawJson<EntityGovernmentAuthority>
{
    /// <inheritdoc/>
    public EntityGovernmentAuthority FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityGovernmentAuthority.FromRawUnchecked(rawData);
}

/// <summary>
/// The government authority's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityGovernmentAuthorityAddress,
        EntityGovernmentAuthorityAddressFromRaw
    >)
)]
public sealed record class EntityGovernmentAuthorityAddress : JsonModel
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

    public EntityGovernmentAuthorityAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityGovernmentAuthorityAddress(
        EntityGovernmentAuthorityAddress entityGovernmentAuthorityAddress
    )
        : base(entityGovernmentAuthorityAddress) { }
#pragma warning restore CS8618

    public EntityGovernmentAuthorityAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityGovernmentAuthorityAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityGovernmentAuthorityAddressFromRaw.FromRawUnchecked"/>
    public static EntityGovernmentAuthorityAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityGovernmentAuthorityAddressFromRaw : IFromRawJson<EntityGovernmentAuthorityAddress>
{
    /// <inheritdoc/>
    public EntityGovernmentAuthorityAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityGovernmentAuthorityAddress.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntityGovernmentAuthorityAuthorizedPerson,
        EntityGovernmentAuthorityAuthorizedPersonFromRaw
    >)
)]
public sealed record class EntityGovernmentAuthorityAuthorizedPerson : JsonModel
{
    /// <summary>
    /// The identifier of this authorized person.
    /// </summary>
    public required string AuthorizedPersonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorized_person_id");
        }
        init { this._rawData.Set("authorized_person_id", value); }
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
        _ = this.AuthorizedPersonID;
        _ = this.Name;
    }

    public EntityGovernmentAuthorityAuthorizedPerson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityGovernmentAuthorityAuthorizedPerson(
        EntityGovernmentAuthorityAuthorizedPerson entityGovernmentAuthorityAuthorizedPerson
    )
        : base(entityGovernmentAuthorityAuthorizedPerson) { }
#pragma warning restore CS8618

    public EntityGovernmentAuthorityAuthorizedPerson(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityGovernmentAuthorityAuthorizedPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityGovernmentAuthorityAuthorizedPersonFromRaw.FromRawUnchecked"/>
    public static EntityGovernmentAuthorityAuthorizedPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityGovernmentAuthorityAuthorizedPersonFromRaw
    : IFromRawJson<EntityGovernmentAuthorityAuthorizedPerson>
{
    /// <inheritdoc/>
    public EntityGovernmentAuthorityAuthorizedPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityGovernmentAuthorityAuthorizedPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the government authority.
/// </summary>
[JsonConverter(typeof(EntityGovernmentAuthorityCategoryConverter))]
public enum EntityGovernmentAuthorityCategory
{
    /// <summary>
    /// A municipality.
    /// </summary>
    Municipality,

    /// <summary>
    /// A state agency.
    /// </summary>
    StateAgency,

    /// <summary>
    /// A state government.
    /// </summary>
    StateGovernment,

    /// <summary>
    /// A federal agency.
    /// </summary>
    FederalAgency,
}

sealed class EntityGovernmentAuthorityCategoryConverter
    : JsonConverter<EntityGovernmentAuthorityCategory>
{
    public override EntityGovernmentAuthorityCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "municipality" => EntityGovernmentAuthorityCategory.Municipality,
            "state_agency" => EntityGovernmentAuthorityCategory.StateAgency,
            "state_government" => EntityGovernmentAuthorityCategory.StateGovernment,
            "federal_agency" => EntityGovernmentAuthorityCategory.FederalAgency,
            _ => (EntityGovernmentAuthorityCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityGovernmentAuthorityCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityGovernmentAuthorityCategory.Municipality => "municipality",
                EntityGovernmentAuthorityCategory.StateAgency => "state_agency",
                EntityGovernmentAuthorityCategory.StateGovernment => "state_government",
                EntityGovernmentAuthorityCategory.FederalAgency => "federal_agency",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the joint entity. Will be present if `structure` is equal to `joint`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityJoint, EntityJointFromRaw>))]
public sealed record class EntityJoint : JsonModel
{
    /// <summary>
    /// The two individuals that share control of the entity.
    /// </summary>
    public required IReadOnlyList<EntityJointIndividual> Individuals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityJointIndividual>>(
                "individuals"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityJointIndividual>>(
                "individuals",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The entity's name.
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
        foreach (var item in this.Individuals)
        {
            item.Validate();
        }
        _ = this.Name;
    }

    public EntityJoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityJoint(EntityJoint entityJoint)
        : base(entityJoint) { }
#pragma warning restore CS8618

    public EntityJoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityJoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityJointFromRaw.FromRawUnchecked"/>
    public static EntityJoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityJointFromRaw : IFromRawJson<EntityJoint>
{
    /// <inheritdoc/>
    public EntityJoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityJoint.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EntityJointIndividual, EntityJointIndividualFromRaw>))]
public sealed record class EntityJointIndividual : JsonModel
{
    /// <summary>
    /// The person's address.
    /// </summary>
    public required EntityJointIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityJointIndividualAddress>("address");
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
    public required EntityJointIndividualIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityJointIndividualIdentification>(
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
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityJointIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityJointIndividual(EntityJointIndividual entityJointIndividual)
        : base(entityJointIndividual) { }
#pragma warning restore CS8618

    public EntityJointIndividual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityJointIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityJointIndividualFromRaw.FromRawUnchecked"/>
    public static EntityJointIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityJointIndividualFromRaw : IFromRawJson<EntityJointIndividual>
{
    /// <inheritdoc/>
    public EntityJointIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityJointIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The person's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityJointIndividualAddress, EntityJointIndividualAddressFromRaw>)
)]
public sealed record class EntityJointIndividualAddress : JsonModel
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

    public EntityJointIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityJointIndividualAddress(EntityJointIndividualAddress entityJointIndividualAddress)
        : base(entityJointIndividualAddress) { }
#pragma warning restore CS8618

    public EntityJointIndividualAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityJointIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityJointIndividualAddressFromRaw.FromRawUnchecked"/>
    public static EntityJointIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityJointIndividualAddressFromRaw : IFromRawJson<EntityJointIndividualAddress>
{
    /// <inheritdoc/>
    public EntityJointIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityJointIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityJointIndividualIdentification,
        EntityJointIndividualIdentificationFromRaw
    >)
)]
public sealed record class EntityJointIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, EntityJointIndividualIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityJointIndividualIdentificationMethod>
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

    public EntityJointIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityJointIndividualIdentification(
        EntityJointIndividualIdentification entityJointIndividualIdentification
    )
        : base(entityJointIndividualIdentification) { }
#pragma warning restore CS8618

    public EntityJointIndividualIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityJointIndividualIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityJointIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityJointIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityJointIndividualIdentificationFromRaw : IFromRawJson<EntityJointIndividualIdentification>
{
    /// <inheritdoc/>
    public EntityJointIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityJointIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityJointIndividualIdentificationMethodConverter))]
public enum EntityJointIndividualIdentificationMethod
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

sealed class EntityJointIndividualIdentificationMethodConverter
    : JsonConverter<EntityJointIndividualIdentificationMethod>
{
    public override EntityJointIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityJointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityJointIndividualIdentificationMethod.Passport,
            "drivers_license" => EntityJointIndividualIdentificationMethod.DriversLicense,
            "other" => EntityJointIndividualIdentificationMethod.Other,
            _ => (EntityJointIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityJointIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityJointIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityJointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityJointIndividualIdentificationMethod.Passport => "passport",
                EntityJointIndividualIdentificationMethod.DriversLicense => "drivers_license",
                EntityJointIndividualIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the natural person entity. Will be present if `structure` is equal
/// to `natural_person`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityNaturalPerson, EntityNaturalPersonFromRaw>))]
public sealed record class EntityNaturalPerson : JsonModel
{
    /// <summary>
    /// The person's address.
    /// </summary>
    public required EntityNaturalPersonAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityNaturalPersonAddress>("address");
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
    public required EntityNaturalPersonIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityNaturalPersonIdentification>(
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
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityNaturalPerson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityNaturalPerson(EntityNaturalPerson entityNaturalPerson)
        : base(entityNaturalPerson) { }
#pragma warning restore CS8618

    public EntityNaturalPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityNaturalPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityNaturalPersonFromRaw.FromRawUnchecked"/>
    public static EntityNaturalPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityNaturalPersonFromRaw : IFromRawJson<EntityNaturalPerson>
{
    /// <inheritdoc/>
    public EntityNaturalPerson FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityNaturalPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// The person's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityNaturalPersonAddress, EntityNaturalPersonAddressFromRaw>)
)]
public sealed record class EntityNaturalPersonAddress : JsonModel
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

    public EntityNaturalPersonAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityNaturalPersonAddress(EntityNaturalPersonAddress entityNaturalPersonAddress)
        : base(entityNaturalPersonAddress) { }
#pragma warning restore CS8618

    public EntityNaturalPersonAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityNaturalPersonAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityNaturalPersonAddressFromRaw.FromRawUnchecked"/>
    public static EntityNaturalPersonAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityNaturalPersonAddressFromRaw : IFromRawJson<EntityNaturalPersonAddress>
{
    /// <inheritdoc/>
    public EntityNaturalPersonAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityNaturalPersonAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityNaturalPersonIdentification,
        EntityNaturalPersonIdentificationFromRaw
    >)
)]
public sealed record class EntityNaturalPersonIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, EntityNaturalPersonIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityNaturalPersonIdentificationMethod>
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

    public EntityNaturalPersonIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityNaturalPersonIdentification(
        EntityNaturalPersonIdentification entityNaturalPersonIdentification
    )
        : base(entityNaturalPersonIdentification) { }
#pragma warning restore CS8618

    public EntityNaturalPersonIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityNaturalPersonIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityNaturalPersonIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityNaturalPersonIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityNaturalPersonIdentificationFromRaw : IFromRawJson<EntityNaturalPersonIdentification>
{
    /// <inheritdoc/>
    public EntityNaturalPersonIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityNaturalPersonIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityNaturalPersonIdentificationMethodConverter))]
public enum EntityNaturalPersonIdentificationMethod
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

sealed class EntityNaturalPersonIdentificationMethodConverter
    : JsonConverter<EntityNaturalPersonIdentificationMethod>
{
    public override EntityNaturalPersonIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityNaturalPersonIdentificationMethod.Passport,
            "drivers_license" => EntityNaturalPersonIdentificationMethod.DriversLicense,
            "other" => EntityNaturalPersonIdentificationMethod.Other,
            _ => (EntityNaturalPersonIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityNaturalPersonIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityNaturalPersonIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityNaturalPersonIdentificationMethod.Passport => "passport",
                EntityNaturalPersonIdentificationMethod.DriversLicense => "drivers_license",
                EntityNaturalPersonIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An assessment of the entity’s potential risk of involvement in financial crimes,
/// such as money laundering.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityRiskRating, EntityRiskRatingFromRaw>))]
public sealed record class EntityRiskRating : JsonModel
{
    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the risk
    /// rating was performed.
    /// </summary>
    public required System::DateTimeOffset RatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("rated_at");
        }
        init { this._rawData.Set("rated_at", value); }
    }

    /// <summary>
    /// The rating given to this entity.
    /// </summary>
    public required ApiEnum<string, EntityRiskRatingRating> Rating
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityRiskRatingRating>>("rating");
        }
        init { this._rawData.Set("rating", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RatedAt;
        this.Rating.Validate();
    }

    public EntityRiskRating() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityRiskRating(EntityRiskRating entityRiskRating)
        : base(entityRiskRating) { }
#pragma warning restore CS8618

    public EntityRiskRating(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityRiskRating(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityRiskRatingFromRaw.FromRawUnchecked"/>
    public static EntityRiskRating FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityRiskRatingFromRaw : IFromRawJson<EntityRiskRating>
{
    /// <inheritdoc/>
    public EntityRiskRating FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityRiskRating.FromRawUnchecked(rawData);
}

/// <summary>
/// The rating given to this entity.
/// </summary>
[JsonConverter(typeof(EntityRiskRatingRatingConverter))]
public enum EntityRiskRatingRating
{
    /// <summary>
    /// Minimal risk of involvement in financial crime.
    /// </summary>
    Low,

    /// <summary>
    /// Moderate risk of involvement in financial crime.
    /// </summary>
    Medium,

    /// <summary>
    /// Elevated risk of involvement in financial crime.
    /// </summary>
    High,
}

sealed class EntityRiskRatingRatingConverter : JsonConverter<EntityRiskRatingRating>
{
    public override EntityRiskRatingRating Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => EntityRiskRatingRating.Low,
            "medium" => EntityRiskRatingRating.Medium,
            "high" => EntityRiskRatingRating.High,
            _ => (EntityRiskRatingRating)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityRiskRatingRating value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityRiskRatingRating.Low => "low",
                EntityRiskRatingRating.Medium => "medium",
                EntityRiskRatingRating.High => "high",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the entity.
/// </summary>
[JsonConverter(typeof(EntityStatusConverter))]
public enum EntityStatus
{
    /// <summary>
    /// The entity is active.
    /// </summary>
    Active,

    /// <summary>
    /// The entity is archived, and can no longer be used to create accounts.
    /// </summary>
    Archived,

    /// <summary>
    /// The entity is temporarily disabled and cannot be used for financial activity.
    /// </summary>
    Disabled,
}

sealed class EntityStatusConverter : JsonConverter<EntityStatus>
{
    public override EntityStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => EntityStatus.Active,
            "archived" => EntityStatus.Archived,
            "disabled" => EntityStatus.Disabled,
            _ => (EntityStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityStatus.Active => "active",
                EntityStatus.Archived => "archived",
                EntityStatus.Disabled => "disabled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The entity's legal structure.
/// </summary>
[JsonConverter(typeof(EntityStructureConverter))]
public enum EntityStructure
{
    /// <summary>
    /// A corporation.
    /// </summary>
    Corporation,

    /// <summary>
    /// An individual person.
    /// </summary>
    NaturalPerson,

    /// <summary>
    /// Multiple individual people.
    /// </summary>
    Joint,

    /// <summary>
    /// A trust.
    /// </summary>
    Trust,

    /// <summary>
    /// A government authority.
    /// </summary>
    GovernmentAuthority,
}

sealed class EntityStructureConverter : JsonConverter<EntityStructure>
{
    public override EntityStructure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporation" => EntityStructure.Corporation,
            "natural_person" => EntityStructure.NaturalPerson,
            "joint" => EntityStructure.Joint,
            "trust" => EntityStructure.Trust,
            "government_authority" => EntityStructure.GovernmentAuthority,
            _ => (EntityStructure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityStructure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityStructure.Corporation => "corporation",
                EntityStructure.NaturalPerson => "natural_person",
                EntityStructure.Joint => "joint",
                EntityStructure.Trust => "trust",
                EntityStructure.GovernmentAuthority => "government_authority",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<EntityTermsAgreement, EntityTermsAgreementFromRaw>))]
public sealed record class EntityTermsAgreement : JsonModel
{
    /// <summary>
    /// The timestamp of when the Entity agreed to the terms.
    /// </summary>
    public required System::DateTimeOffset AgreedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("agreed_at");
        }
        init { this._rawData.Set("agreed_at", value); }
    }

    /// <summary>
    /// The IP address the Entity accessed reviewed the terms from.
    /// </summary>
    public required string IPAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ip_address");
        }
        init { this._rawData.Set("ip_address", value); }
    }

    /// <summary>
    /// The URL of the terms agreement. This link will be provided by your bank partner.
    /// </summary>
    public required string TermsUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("terms_url");
        }
        init { this._rawData.Set("terms_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgreedAt;
        _ = this.IPAddress;
        _ = this.TermsUrl;
    }

    public EntityTermsAgreement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTermsAgreement(EntityTermsAgreement entityTermsAgreement)
        : base(entityTermsAgreement) { }
#pragma warning restore CS8618

    public EntityTermsAgreement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTermsAgreement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTermsAgreementFromRaw.FromRawUnchecked"/>
    public static EntityTermsAgreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTermsAgreementFromRaw : IFromRawJson<EntityTermsAgreement>
{
    /// <inheritdoc/>
    public EntityTermsAgreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTermsAgreement.FromRawUnchecked(rawData);
}

/// <summary>
/// If you are using a third-party service for identity verification, you can use
/// this field to associate this Entity with the identifier that represents them in
/// that service.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityThirdPartyVerification, EntityThirdPartyVerificationFromRaw>)
)]
public sealed record class EntityThirdPartyVerification : JsonModel
{
    /// <summary>
    /// The reference identifier for the third party verification.
    /// </summary>
    public required string Reference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reference");
        }
        init { this._rawData.Set("reference", value); }
    }

    /// <summary>
    /// The vendor that was used to perform the verification.
    /// </summary>
    public required ApiEnum<string, EntityThirdPartyVerificationVendor> Vendor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityThirdPartyVerificationVendor>
            >("vendor");
        }
        init { this._rawData.Set("vendor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reference;
        this.Vendor.Validate();
    }

    public EntityThirdPartyVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityThirdPartyVerification(EntityThirdPartyVerification entityThirdPartyVerification)
        : base(entityThirdPartyVerification) { }
#pragma warning restore CS8618

    public EntityThirdPartyVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityThirdPartyVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityThirdPartyVerificationFromRaw.FromRawUnchecked"/>
    public static EntityThirdPartyVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityThirdPartyVerificationFromRaw : IFromRawJson<EntityThirdPartyVerification>
{
    /// <inheritdoc/>
    public EntityThirdPartyVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityThirdPartyVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor that was used to perform the verification.
/// </summary>
[JsonConverter(typeof(EntityThirdPartyVerificationVendorConverter))]
public enum EntityThirdPartyVerificationVendor
{
    /// <summary>
    /// Alloy. See https://alloy.com for more information.
    /// </summary>
    Alloy,

    /// <summary>
    /// Middesk. See https://middesk.com for more information.
    /// </summary>
    Middesk,

    /// <summary>
    /// Oscilar. See https://oscilar.com for more information.
    /// </summary>
    Oscilar,

    /// <summary>
    /// Persona. See https://withpersona.com for more information.
    /// </summary>
    Persona,

    /// <summary>
    /// Taktile. See https://taktile.com for more information.
    /// </summary>
    Taktile,
}

sealed class EntityThirdPartyVerificationVendorConverter
    : JsonConverter<EntityThirdPartyVerificationVendor>
{
    public override EntityThirdPartyVerificationVendor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "alloy" => EntityThirdPartyVerificationVendor.Alloy,
            "middesk" => EntityThirdPartyVerificationVendor.Middesk,
            "oscilar" => EntityThirdPartyVerificationVendor.Oscilar,
            "persona" => EntityThirdPartyVerificationVendor.Persona,
            "taktile" => EntityThirdPartyVerificationVendor.Taktile,
            _ => (EntityThirdPartyVerificationVendor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityThirdPartyVerificationVendor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityThirdPartyVerificationVendor.Alloy => "alloy",
                EntityThirdPartyVerificationVendor.Middesk => "middesk",
                EntityThirdPartyVerificationVendor.Oscilar => "oscilar",
                EntityThirdPartyVerificationVendor.Persona => "persona",
                EntityThirdPartyVerificationVendor.Taktile => "taktile",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the trust entity. Will be present if `structure` is equal to `trust`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityTrust, EntityTrustFromRaw>))]
public sealed record class EntityTrust : JsonModel
{
    /// <summary>
    /// The trust's address.
    /// </summary>
    public required EntityTrustAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityTrustAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Whether the trust is `revocable` or `irrevocable`.
    /// </summary>
    public required ApiEnum<string, EntityTrustCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityTrustCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The ID for the File containing the formation document of the trust.
    /// </summary>
    public required string? FormationDocumentFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formation_document_file_id");
        }
        init { this._rawData.Set("formation_document_file_id", value); }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// in which the trust was formed.
    /// </summary>
    public required string? FormationState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formation_state");
        }
        init { this._rawData.Set("formation_state", value); }
    }

    /// <summary>
    /// The grantor of the trust. Will be present if the `category` is `revocable`.
    /// </summary>
    public required EntityTrustGrantor? Grantor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityTrustGrantor>("grantor");
        }
        init { this._rawData.Set("grantor", value); }
    }

    /// <summary>
    /// The trust's name.
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

    /// <summary>
    /// The Employer Identification Number (EIN) of the trust itself.
    /// </summary>
    public required string? TaxIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_identifier");
        }
        init { this._rawData.Set("tax_identifier", value); }
    }

    /// <summary>
    /// The trustees of the trust.
    /// </summary>
    public required IReadOnlyList<EntityTrustTrustee> Trustees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityTrustTrustee>>("trustees");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityTrustTrustee>>(
                "trustees",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        this.Category.Validate();
        _ = this.FormationDocumentFileID;
        _ = this.FormationState;
        this.Grantor?.Validate();
        _ = this.Name;
        _ = this.TaxIdentifier;
        foreach (var item in this.Trustees)
        {
            item.Validate();
        }
    }

    public EntityTrust() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrust(EntityTrust entityTrust)
        : base(entityTrust) { }
#pragma warning restore CS8618

    public EntityTrust(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrust(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustFromRaw.FromRawUnchecked"/>
    public static EntityTrust FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustFromRaw : IFromRawJson<EntityTrust>
{
    /// <inheritdoc/>
    public EntityTrust FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityTrust.FromRawUnchecked(rawData);
}

/// <summary>
/// The trust's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityTrustAddress, EntityTrustAddressFromRaw>))]
public sealed record class EntityTrustAddress : JsonModel
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

    public EntityTrustAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustAddress(EntityTrustAddress entityTrustAddress)
        : base(entityTrustAddress) { }
#pragma warning restore CS8618

    public EntityTrustAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustAddressFromRaw.FromRawUnchecked"/>
    public static EntityTrustAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustAddressFromRaw : IFromRawJson<EntityTrustAddress>
{
    /// <inheritdoc/>
    public EntityTrustAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityTrustAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the trust is `revocable` or `irrevocable`.
/// </summary>
[JsonConverter(typeof(EntityTrustCategoryConverter))]
public enum EntityTrustCategory
{
    /// <summary>
    /// The trust is revocable by the grantor.
    /// </summary>
    Revocable,

    /// <summary>
    /// The trust cannot be revoked.
    /// </summary>
    Irrevocable,
}

sealed class EntityTrustCategoryConverter : JsonConverter<EntityTrustCategory>
{
    public override EntityTrustCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "revocable" => EntityTrustCategory.Revocable,
            "irrevocable" => EntityTrustCategory.Irrevocable,
            _ => (EntityTrustCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityTrustCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityTrustCategory.Revocable => "revocable",
                EntityTrustCategory.Irrevocable => "irrevocable",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The grantor of the trust. Will be present if the `category` is `revocable`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityTrustGrantor, EntityTrustGrantorFromRaw>))]
public sealed record class EntityTrustGrantor : JsonModel
{
    /// <summary>
    /// The person's address.
    /// </summary>
    public required EntityTrustGrantorAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityTrustGrantorAddress>("address");
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
    public required EntityTrustGrantorIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityTrustGrantorIdentification>(
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
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityTrustGrantor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustGrantor(EntityTrustGrantor entityTrustGrantor)
        : base(entityTrustGrantor) { }
#pragma warning restore CS8618

    public EntityTrustGrantor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustGrantor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustGrantorFromRaw.FromRawUnchecked"/>
    public static EntityTrustGrantor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustGrantorFromRaw : IFromRawJson<EntityTrustGrantor>
{
    /// <inheritdoc/>
    public EntityTrustGrantor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityTrustGrantor.FromRawUnchecked(rawData);
}

/// <summary>
/// The person's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityTrustGrantorAddress, EntityTrustGrantorAddressFromRaw>)
)]
public sealed record class EntityTrustGrantorAddress : JsonModel
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

    public EntityTrustGrantorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustGrantorAddress(EntityTrustGrantorAddress entityTrustGrantorAddress)
        : base(entityTrustGrantorAddress) { }
#pragma warning restore CS8618

    public EntityTrustGrantorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustGrantorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustGrantorAddressFromRaw.FromRawUnchecked"/>
    public static EntityTrustGrantorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustGrantorAddressFromRaw : IFromRawJson<EntityTrustGrantorAddress>
{
    /// <inheritdoc/>
    public EntityTrustGrantorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTrustGrantorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityTrustGrantorIdentification,
        EntityTrustGrantorIdentificationFromRaw
    >)
)]
public sealed record class EntityTrustGrantorIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, EntityTrustGrantorIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityTrustGrantorIdentificationMethod>
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

    public EntityTrustGrantorIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustGrantorIdentification(
        EntityTrustGrantorIdentification entityTrustGrantorIdentification
    )
        : base(entityTrustGrantorIdentification) { }
#pragma warning restore CS8618

    public EntityTrustGrantorIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustGrantorIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustGrantorIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityTrustGrantorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustGrantorIdentificationFromRaw : IFromRawJson<EntityTrustGrantorIdentification>
{
    /// <inheritdoc/>
    public EntityTrustGrantorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTrustGrantorIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityTrustGrantorIdentificationMethodConverter))]
public enum EntityTrustGrantorIdentificationMethod
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

sealed class EntityTrustGrantorIdentificationMethodConverter
    : JsonConverter<EntityTrustGrantorIdentificationMethod>
{
    public override EntityTrustGrantorIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" => EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityTrustGrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityTrustGrantorIdentificationMethod.Passport,
            "drivers_license" => EntityTrustGrantorIdentificationMethod.DriversLicense,
            "other" => EntityTrustGrantorIdentificationMethod.Other,
            _ => (EntityTrustGrantorIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityTrustGrantorIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityTrustGrantorIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityTrustGrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityTrustGrantorIdentificationMethod.Passport => "passport",
                EntityTrustGrantorIdentificationMethod.DriversLicense => "drivers_license",
                EntityTrustGrantorIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<EntityTrustTrustee, EntityTrustTrusteeFromRaw>))]
public sealed record class EntityTrustTrustee : JsonModel
{
    /// <summary>
    /// The individual trustee of the trust. Will be present if the trustee's `structure`
    /// is equal to `individual`.
    /// </summary>
    public required EntityTrustTrusteeIndividual? Individual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityTrustTrusteeIndividual>("individual");
        }
        init { this._rawData.Set("individual", value); }
    }

    /// <summary>
    /// The structure of the trustee. Will always be equal to `individual`.
    /// </summary>
    public required ApiEnum<string, EntityTrustTrusteeStructure> Structure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityTrustTrusteeStructure>>(
                "structure"
            );
        }
        init { this._rawData.Set("structure", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Individual?.Validate();
        this.Structure.Validate();
    }

    public EntityTrustTrustee() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustTrustee(EntityTrustTrustee entityTrustTrustee)
        : base(entityTrustTrustee) { }
#pragma warning restore CS8618

    public EntityTrustTrustee(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustTrustee(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustTrusteeFromRaw.FromRawUnchecked"/>
    public static EntityTrustTrustee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustTrusteeFromRaw : IFromRawJson<EntityTrustTrustee>
{
    /// <inheritdoc/>
    public EntityTrustTrustee FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityTrustTrustee.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual trustee of the trust. Will be present if the trustee's `structure`
/// is equal to `individual`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityTrustTrusteeIndividual, EntityTrustTrusteeIndividualFromRaw>)
)]
public sealed record class EntityTrustTrusteeIndividual : JsonModel
{
    /// <summary>
    /// The person's address.
    /// </summary>
    public required EntityTrustTrusteeIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityTrustTrusteeIndividualAddress>("address");
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
    public required EntityTrustTrusteeIndividualIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityTrustTrusteeIndividualIdentification>(
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
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityTrustTrusteeIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustTrusteeIndividual(EntityTrustTrusteeIndividual entityTrustTrusteeIndividual)
        : base(entityTrustTrusteeIndividual) { }
#pragma warning restore CS8618

    public EntityTrustTrusteeIndividual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustTrusteeIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustTrusteeIndividualFromRaw.FromRawUnchecked"/>
    public static EntityTrustTrusteeIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustTrusteeIndividualFromRaw : IFromRawJson<EntityTrustTrusteeIndividual>
{
    /// <inheritdoc/>
    public EntityTrustTrusteeIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTrustTrusteeIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The person's address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityTrustTrusteeIndividualAddress,
        EntityTrustTrusteeIndividualAddressFromRaw
    >)
)]
public sealed record class EntityTrustTrusteeIndividualAddress : JsonModel
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

    public EntityTrustTrusteeIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustTrusteeIndividualAddress(
        EntityTrustTrusteeIndividualAddress entityTrustTrusteeIndividualAddress
    )
        : base(entityTrustTrusteeIndividualAddress) { }
#pragma warning restore CS8618

    public EntityTrustTrusteeIndividualAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustTrusteeIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustTrusteeIndividualAddressFromRaw.FromRawUnchecked"/>
    public static EntityTrustTrusteeIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustTrusteeIndividualAddressFromRaw : IFromRawJson<EntityTrustTrusteeIndividualAddress>
{
    /// <inheritdoc/>
    public EntityTrustTrusteeIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTrustTrusteeIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityTrustTrusteeIndividualIdentification,
        EntityTrustTrusteeIndividualIdentificationFromRaw
    >)
)]
public sealed record class EntityTrustTrusteeIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, EntityTrustTrusteeIndividualIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityTrustTrusteeIndividualIdentificationMethod>
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

    public EntityTrustTrusteeIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTrustTrusteeIndividualIdentification(
        EntityTrustTrusteeIndividualIdentification entityTrustTrusteeIndividualIdentification
    )
        : base(entityTrustTrusteeIndividualIdentification) { }
#pragma warning restore CS8618

    public EntityTrustTrusteeIndividualIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTrustTrusteeIndividualIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTrustTrusteeIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityTrustTrusteeIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTrustTrusteeIndividualIdentificationFromRaw
    : IFromRawJson<EntityTrustTrusteeIndividualIdentification>
{
    /// <inheritdoc/>
    public EntityTrustTrusteeIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTrustTrusteeIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityTrustTrusteeIndividualIdentificationMethodConverter))]
public enum EntityTrustTrusteeIndividualIdentificationMethod
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

sealed class EntityTrustTrusteeIndividualIdentificationMethodConverter
    : JsonConverter<EntityTrustTrusteeIndividualIdentificationMethod>
{
    public override EntityTrustTrusteeIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityTrustTrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityTrustTrusteeIndividualIdentificationMethod.Passport,
            "drivers_license" => EntityTrustTrusteeIndividualIdentificationMethod.DriversLicense,
            "other" => EntityTrustTrusteeIndividualIdentificationMethod.Other,
            _ => (EntityTrustTrusteeIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityTrustTrusteeIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityTrustTrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityTrustTrusteeIndividualIdentificationMethod.Passport => "passport",
                EntityTrustTrusteeIndividualIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityTrustTrusteeIndividualIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The structure of the trustee. Will always be equal to `individual`.
/// </summary>
[JsonConverter(typeof(EntityTrustTrusteeStructureConverter))]
public enum EntityTrustTrusteeStructure
{
    /// <summary>
    /// The trustee is an individual.
    /// </summary>
    Individual,
}

sealed class EntityTrustTrusteeStructureConverter : JsonConverter<EntityTrustTrusteeStructure>
{
    public override EntityTrustTrusteeStructure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => EntityTrustTrusteeStructure.Individual,
            _ => (EntityTrustTrusteeStructure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityTrustTrusteeStructure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityTrustTrusteeStructure.Individual => "individual",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `entity`.
/// </summary>
[JsonConverter(typeof(global::Increase.Api.Models.Entities.TypeConverter))]
public enum Type
{
    Entity,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Entities.Type>
{
    public override global::Increase.Api.Models.Entities.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entity" => global::Increase.Api.Models.Entities.Type.Entity,
            _ => (global::Increase.Api.Models.Entities.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Entities.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Entities.Type.Entity => "entity",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The validation results for the entity. Learn more about [validations](/documentation/entity-validation).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Validation, ValidationFromRaw>))]
public sealed record class Validation : JsonModel
{
    /// <summary>
    /// The list of issues that need to be addressed.
    /// </summary>
    public required IReadOnlyList<Issue> Issues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Issue>>("issues");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Issue>>(
                "issues",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The validation status for the entity. If the status is `invalid`, the `issues`
    /// array will be populated.
    /// </summary>
    public required ApiEnum<string, ValidationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ValidationStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Issues)
        {
            item.Validate();
        }
        this.Status.Validate();
    }

    public Validation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Validation(Validation validation)
        : base(validation) { }
#pragma warning restore CS8618

    public Validation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Validation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidationFromRaw.FromRawUnchecked"/>
    public static Validation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidationFromRaw : IFromRawJson<Validation>
{
    /// <inheritdoc/>
    public Validation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Validation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Issue, IssueFromRaw>))]
public sealed record class Issue : JsonModel
{
    /// <summary>
    /// Details when the issue is with a beneficial owner's address.
    /// </summary>
    public required BeneficialOwnerAddress? BeneficialOwnerAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BeneficialOwnerAddress>(
                "beneficial_owner_address"
            );
        }
        init { this._rawData.Set("beneficial_owner_address", value); }
    }

    /// <summary>
    /// Details when the issue is with a beneficial owner's identity verification.
    /// </summary>
    public required BeneficialOwnerIdentity? BeneficialOwnerIdentity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BeneficialOwnerIdentity>(
                "beneficial_owner_identity"
            );
        }
        init { this._rawData.Set("beneficial_owner_identity", value); }
    }

    /// <summary>
    /// The type of issue. We may add additional possible values for this enum over
    /// time; your application should be able to handle such additions gracefully.
    /// </summary>
    public required ApiEnum<string, IssueCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IssueCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Details when the issue is with the entity's address.
    /// </summary>
    public required EntityAddress? EntityAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityAddress>("entity_address");
        }
        init { this._rawData.Set("entity_address", value); }
    }

    /// <summary>
    /// Details when the issue is with the entity's tax ID.
    /// </summary>
    public required EntityTaxIdentifier? EntityTaxIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityTaxIdentifier>("entity_tax_identifier");
        }
        init { this._rawData.Set("entity_tax_identifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BeneficialOwnerAddress?.Validate();
        this.BeneficialOwnerIdentity?.Validate();
        this.Category.Validate();
        this.EntityAddress?.Validate();
        this.EntityTaxIdentifier?.Validate();
    }

    public Issue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Issue(Issue issue)
        : base(issue) { }
#pragma warning restore CS8618

    public Issue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Issue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IssueFromRaw.FromRawUnchecked"/>
    public static Issue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IssueFromRaw : IFromRawJson<Issue>
{
    /// <inheritdoc/>
    public Issue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Issue.FromRawUnchecked(rawData);
}

/// <summary>
/// Details when the issue is with a beneficial owner's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BeneficialOwnerAddress, BeneficialOwnerAddressFromRaw>))]
public sealed record class BeneficialOwnerAddress : JsonModel
{
    /// <summary>
    /// The ID of the beneficial owner.
    /// </summary>
    public required string BeneficialOwnerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("beneficial_owner_id");
        }
        init { this._rawData.Set("beneficial_owner_id", value); }
    }

    /// <summary>
    /// The reason the address is invalid.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BeneficialOwnerID;
        this.Reason.Validate();
    }

    public BeneficialOwnerAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerAddress(BeneficialOwnerAddress beneficialOwnerAddress)
        : base(beneficialOwnerAddress) { }
#pragma warning restore CS8618

    public BeneficialOwnerAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerAddressFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerAddressFromRaw : IFromRawJson<BeneficialOwnerAddress>
{
    /// <inheritdoc/>
    public BeneficialOwnerAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the address is invalid.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    /// <summary>
    /// The address is a mailbox or other non-physical address.
    /// </summary>
    MailboxAddress,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mailbox_address" => Reason.MailboxAddress,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.MailboxAddress => "mailbox_address",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details when the issue is with a beneficial owner's identity verification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BeneficialOwnerIdentity, BeneficialOwnerIdentityFromRaw>))]
public sealed record class BeneficialOwnerIdentity : JsonModel
{
    /// <summary>
    /// The ID of the beneficial owner.
    /// </summary>
    public required string BeneficialOwnerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("beneficial_owner_id");
        }
        init { this._rawData.Set("beneficial_owner_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BeneficialOwnerID;
    }

    public BeneficialOwnerIdentity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerIdentity(BeneficialOwnerIdentity beneficialOwnerIdentity)
        : base(beneficialOwnerIdentity) { }
#pragma warning restore CS8618

    public BeneficialOwnerIdentity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerIdentity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerIdentityFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerIdentity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BeneficialOwnerIdentity(string beneficialOwnerID)
        : this()
    {
        this.BeneficialOwnerID = beneficialOwnerID;
    }
}

class BeneficialOwnerIdentityFromRaw : IFromRawJson<BeneficialOwnerIdentity>
{
    /// <inheritdoc/>
    public BeneficialOwnerIdentity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerIdentity.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of issue. We may add additional possible values for this enum over time;
/// your application should be able to handle such additions gracefully.
/// </summary>
[JsonConverter(typeof(IssueCategoryConverter))]
public enum IssueCategory
{
    /// <summary>
    /// The entity's tax identifier could not be validated. Update the tax ID with
    /// the [update an entity API](/documentation/api/entities#update-an-entity.corporation.legal_identifier).
    /// </summary>
    EntityTaxIdentifier,

    /// <summary>
    /// The entity's address could not be validated. Update the address with the
    /// [update an entity API](/documentation/api/entities#update-an-entity.corporation.address).
    /// </summary>
    EntityAddress,

    /// <summary>
    /// A beneficial owner's identity could not be verified. Update the identification
    /// with the [update a beneficial owner API](/documentation/api/beneficial-owners#update-a-beneficial-owner).
    /// </summary>
    BeneficialOwnerIdentity,

    /// <summary>
    /// A beneficial owner's address could not be validated. Update the address with
    /// the [update a beneficial owner API](/documentation/api/beneficial-owners#update-a-beneficial-owner).
    /// </summary>
    BeneficialOwnerAddress,
}

sealed class IssueCategoryConverter : JsonConverter<IssueCategory>
{
    public override IssueCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entity_tax_identifier" => IssueCategory.EntityTaxIdentifier,
            "entity_address" => IssueCategory.EntityAddress,
            "beneficial_owner_identity" => IssueCategory.BeneficialOwnerIdentity,
            "beneficial_owner_address" => IssueCategory.BeneficialOwnerAddress,
            _ => (IssueCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IssueCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IssueCategory.EntityTaxIdentifier => "entity_tax_identifier",
                IssueCategory.EntityAddress => "entity_address",
                IssueCategory.BeneficialOwnerIdentity => "beneficial_owner_identity",
                IssueCategory.BeneficialOwnerAddress => "beneficial_owner_address",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details when the issue is with the entity's address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityAddress, EntityAddressFromRaw>))]
public sealed record class EntityAddress : JsonModel
{
    /// <summary>
    /// The reason the address is invalid.
    /// </summary>
    public required ApiEnum<string, EntityAddressReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityAddressReason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
    }

    public EntityAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityAddress(EntityAddress entityAddress)
        : base(entityAddress) { }
#pragma warning restore CS8618

    public EntityAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityAddressFromRaw.FromRawUnchecked"/>
    public static EntityAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityAddress(ApiEnum<string, EntityAddressReason> reason)
        : this()
    {
        this.Reason = reason;
    }
}

class EntityAddressFromRaw : IFromRawJson<EntityAddress>
{
    /// <inheritdoc/>
    public EntityAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason the address is invalid.
/// </summary>
[JsonConverter(typeof(EntityAddressReasonConverter))]
public enum EntityAddressReason
{
    /// <summary>
    /// The address is a mailbox or other non-physical address.
    /// </summary>
    MailboxAddress,
}

sealed class EntityAddressReasonConverter : JsonConverter<EntityAddressReason>
{
    public override EntityAddressReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mailbox_address" => EntityAddressReason.MailboxAddress,
            _ => (EntityAddressReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityAddressReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityAddressReason.MailboxAddress => "mailbox_address",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details when the issue is with the entity's tax ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityTaxIdentifier, EntityTaxIdentifierFromRaw>))]
public sealed record class EntityTaxIdentifier : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public EntityTaxIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTaxIdentifier(EntityTaxIdentifier entityTaxIdentifier)
        : base(entityTaxIdentifier) { }
#pragma warning restore CS8618

    public EntityTaxIdentifier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTaxIdentifier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTaxIdentifierFromRaw.FromRawUnchecked"/>
    public static EntityTaxIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTaxIdentifierFromRaw : IFromRawJson<EntityTaxIdentifier>
{
    /// <inheritdoc/>
    public EntityTaxIdentifier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityTaxIdentifier.FromRawUnchecked(rawData);
}

/// <summary>
/// The validation status for the entity. If the status is `invalid`, the `issues`
/// array will be populated.
/// </summary>
[JsonConverter(typeof(ValidationStatusConverter))]
public enum ValidationStatus
{
    /// <summary>
    /// The submitted data is being validated.
    /// </summary>
    Pending,

    /// <summary>
    /// The submitted data is valid.
    /// </summary>
    Valid,

    /// <summary>
    /// Additional information is required to validate the data.
    /// </summary>
    Invalid,
}

sealed class ValidationStatusConverter : JsonConverter<ValidationStatus>
{
    public override ValidationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => ValidationStatus.Pending,
            "valid" => ValidationStatus.Valid,
            "invalid" => ValidationStatus.Invalid,
            _ => (ValidationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ValidationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ValidationStatus.Pending => "pending",
                ValidationStatus.Valid => "valid",
                ValidationStatus.Invalid => "invalid",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
