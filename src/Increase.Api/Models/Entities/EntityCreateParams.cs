using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Entities;

/// <summary>
/// Create an Entity
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntityCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The type of Entity to create.
    /// </summary>
    public required ApiEnum<string, Structure> Structure
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Structure>>("structure");
        }
        init { this._rawBodyData.Set("structure", value); }
    }

    /// <summary>
    /// Details of the corporation entity to create. Required if `structure` is equal
    /// to `corporation`.
    /// </summary>
    public Corporation? Corporation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Corporation>("corporation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("corporation", value);
        }
    }

    /// <summary>
    /// The description you choose to give the entity.
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
    /// Details of the Government Authority entity to create. Required if `structure`
    /// is equal to `government_authority`.
    /// </summary>
    public GovernmentAuthority? GovernmentAuthority
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<GovernmentAuthority>("government_authority");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("government_authority", value);
        }
    }

    /// <summary>
    /// Details of the joint entity to create. Required if `structure` is equal to `joint`.
    /// </summary>
    public Joint? Joint
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Joint>("joint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("joint", value);
        }
    }

    /// <summary>
    /// Details of the natural person entity to create. Required if `structure` is
    /// equal to `natural_person`. Natural people entities should be submitted with
    /// `social_security_number` or `individual_taxpayer_identification_number` identification methods.
    /// </summary>
    public NaturalPerson? NaturalPerson
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NaturalPerson>("natural_person");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("natural_person", value);
        }
    }

    /// <summary>
    /// An assessment of the entity's potential risk of involvement in financial crimes,
    /// such as money laundering.
    /// </summary>
    public RiskRating? RiskRating
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<RiskRating>("risk_rating");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("risk_rating", value);
        }
    }

    /// <summary>
    /// Additional documentation associated with the entity.
    /// </summary>
    public IReadOnlyList<SupplementalDocument>? SupplementalDocuments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<SupplementalDocument>>(
                "supplemental_documents"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SupplementalDocument>?>(
                "supplemental_documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The terms that the Entity agreed to. Not all programs are required to submit
    /// this data.
    /// </summary>
    public IReadOnlyList<TermsAgreement>? TermsAgreements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<TermsAgreement>>(
                "terms_agreements"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<TermsAgreement>?>(
                "terms_agreements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If you are using a third-party service for identity verification, you can
    /// use this field to associate this Entity with the identifier that represents
    /// them in that service.
    /// </summary>
    public ThirdPartyVerification? ThirdPartyVerification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ThirdPartyVerification>(
                "third_party_verification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("third_party_verification", value);
        }
    }

    /// <summary>
    /// Details of the trust entity to create. Required if `structure` is equal to `trust`.
    /// </summary>
    public Trust? Trust
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Trust>("trust");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("trust", value);
        }
    }

    public EntityCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityCreateParams(EntityCreateParams entityCreateParams)
        : base(entityCreateParams)
    {
        this._rawBodyData = new(entityCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntityCreateParams(
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
    EntityCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntityCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(EntityCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/entities")
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
/// The type of Entity to create.
/// </summary>
[JsonConverter(typeof(StructureConverter))]
public enum Structure
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

sealed class StructureConverter : JsonConverter<Structure>
{
    public override Structure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporation" => Structure.Corporation,
            "natural_person" => Structure.NaturalPerson,
            "joint" => Structure.Joint,
            "trust" => Structure.Trust,
            "government_authority" => Structure.GovernmentAuthority,
            _ => (Structure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Structure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Structure.Corporation => "corporation",
                Structure.NaturalPerson => "natural_person",
                Structure.Joint => "joint",
                Structure.Trust => "trust",
                Structure.GovernmentAuthority => "government_authority",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the corporation entity to create. Required if `structure` is equal
/// to `corporation`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Corporation, CorporationFromRaw>))]
public sealed record class Corporation : JsonModel
{
    /// <summary>
    /// The entity's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public required Address Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The identifying details of each person who owns 25% or more of the business
    /// and one control person, like the CEO, CFO, or other executive. You can submit
    /// between 1 and 5 people to this list.
    /// </summary>
    public required IReadOnlyList<BeneficialOwner> BeneficialOwners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BeneficialOwner>>(
                "beneficial_owners"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BeneficialOwner>>(
                "beneficial_owners",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// The Employer Identification Number (EIN) for the corporation.
    /// </summary>
    public required string TaxIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tax_identifier");
        }
        init { this._rawData.Set("tax_identifier", value); }
    }

    /// <summary>
    /// If the entity is exempt from the requirement to submit beneficial owners,
    /// provide the justification. If a reason is provided, you do not need to submit
    /// a list of beneficial owners.
    /// </summary>
    public ApiEnum<string, BeneficialOwnershipExemptionReason>? BeneficialOwnershipExemptionReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BeneficialOwnershipExemptionReason>
            >("beneficial_ownership_exemption_reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("beneficial_ownership_exemption_reason", value);
        }
    }

    /// <summary>
    /// An email address for the business. Not every program requires an email for
    /// submitted Entities.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the corporation's
    /// state of incorporation.
    /// </summary>
    public string? IncorporationState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("incorporation_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("incorporation_state", value);
        }
    }

    /// <summary>
    /// The North American Industry Classification System (NAICS) code for the corporation's
    /// primary line of business. This is a number, like `5132` for `Software Publishers`.
    /// A full list of classification codes is available [here](https://increase.com/documentation/data-dictionary#north-american-industry-classification-system-codes).
    /// </summary>
    public string? IndustryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("industry_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("industry_code", value);
        }
    }

    /// <summary>
    /// The website of the corporation.
    /// </summary>
    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("website", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        foreach (var item in this.BeneficialOwners)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.TaxIdentifier;
        this.BeneficialOwnershipExemptionReason?.Validate();
        _ = this.Email;
        _ = this.IncorporationState;
        _ = this.IndustryCode;
        _ = this.Website;
    }

    public Corporation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Corporation(Corporation corporation)
        : base(corporation) { }
#pragma warning restore CS8618

    public Corporation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Corporation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CorporationFromRaw.FromRawUnchecked"/>
    public static Corporation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CorporationFromRaw : IFromRawJson<Corporation>
{
    /// <inheritdoc/>
    public Corporation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Corporation.FromRawUnchecked(rawData);
}

/// <summary>
/// The entity's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BeneficialOwner, BeneficialOwnerFromRaw>))]
public sealed record class BeneficialOwner : JsonModel
{
    /// <summary>
    /// Personal details for the beneficial owner.
    /// </summary>
    public required Individual Individual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Individual>("individual");
        }
        init { this._rawData.Set("individual", value); }
    }

    /// <summary>
    /// Why this person is considered a beneficial owner of the entity. At least one
    /// option is required, if a person is both a control person and owner, submit
    /// an array containing both.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Prong>> Prongs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Prong>>>("prongs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Prong>>>(
                "prongs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// This person's role or title within the entity.
    /// </summary>
    public string? CompanyTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Individual.Validate();
        foreach (var item in this.Prongs)
        {
            item.Validate();
        }
        _ = this.CompanyTitle;
    }

    public BeneficialOwner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwner(BeneficialOwner beneficialOwner)
        : base(beneficialOwner) { }
#pragma warning restore CS8618

    public BeneficialOwner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerFromRaw.FromRawUnchecked"/>
    public static BeneficialOwner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerFromRaw : IFromRawJson<BeneficialOwner>
{
    /// <inheritdoc/>
    public BeneficialOwner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BeneficialOwner.FromRawUnchecked(rawData);
}

/// <summary>
/// Personal details for the beneficial owner.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Individual, IndividualFromRaw>))]
public sealed record class Individual : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public required IndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IndividualAddress>("address");
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
    public required Identification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Identification>("identification");
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

    /// <summary>
    /// The identification method for an individual can only be a passport, driver's
    /// license, or other document if you've confirmed the individual does not have
    /// a US tax id (either a Social Security Number or Individual Taxpayer Identification Number).
    /// </summary>
    public bool? ConfirmedNoUsTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confirmed_no_us_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmed_no_us_tax_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.DateOfBirth;
        this.Identification.Validate();
        _ = this.Name;
        _ = this.ConfirmedNoUsTaxID;
    }

    public Individual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Individual(Individual individual)
        : base(individual) { }
#pragma warning restore CS8618

    public Individual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Individual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndividualFromRaw.FromRawUnchecked"/>
    public static Individual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualFromRaw : IFromRawJson<Individual>
{
    /// <inheritdoc/>
    public Individual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Individual.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IndividualAddress, IndividualAddressFromRaw>))]
public sealed record class IndividualAddress : JsonModel
{
    /// <summary>
    /// The city, district, town, or village of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
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
    /// The first line of the address. This is usually the street number and street.
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
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the US
    /// state, province, or region of the address. Required in certain countries.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// The ZIP or postal code of the address. Required in certain countries.
    /// </summary>
    public string? Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("zip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("zip", value);
        }
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

    public IndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IndividualAddress(IndividualAddress individualAddress)
        : base(individualAddress) { }
#pragma warning restore CS8618

    public IndividualAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndividualAddressFromRaw.FromRawUnchecked"/>
    public static IndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualAddressFromRaw : IFromRawJson<IndividualAddress>
{
    /// <inheritdoc/>
    public IndividualAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Identification, IdentificationFromRaw>))]
public sealed record class Identification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Method>>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number.
    /// </summary>
    public required string Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// Information about the United States driver's license used for identification.
    /// Required if `method` is equal to `drivers_license`.
    /// </summary>
    public DriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DriversLicense>("drivers_license");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drivers_license", value);
        }
    }

    /// <summary>
    /// Information about the identification document provided. Required if `method`
    /// is equal to `other`.
    /// </summary>
    public Other? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Other>("other");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other", value);
        }
    }

    /// <summary>
    /// Information about the passport used for identification. Required if `method`
    /// is equal to `passport`.
    /// </summary>
    public Passport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Passport>("passport");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Number;
        this.DriversLicense?.Validate();
        this.Other?.Validate();
        this.Passport?.Validate();
    }

    public Identification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Identification(Identification identification)
        : base(identification) { }
#pragma warning restore CS8618

    public Identification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Identification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentificationFromRaw.FromRawUnchecked"/>
    public static Identification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentificationFromRaw : IFromRawJson<Identification>
{
    /// <inheritdoc/>
    public Identification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Identification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
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

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" => Method.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                Method.IndividualTaxpayerIdentificationNumber,
            "passport" => Method.Passport,
            "drivers_license" => Method.DriversLicense,
            "other" => Method.Other,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.SocialSecurityNumber => "social_security_number",
                Method.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                Method.Passport => "passport",
                Method.DriversLicense => "drivers_license",
                Method.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the United States driver's license used for identification.
/// Required if `method` is equal to `drivers_license`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DriversLicense, DriversLicenseFromRaw>))]
public sealed record class DriversLicense : JsonModel
{
    /// <summary>
    /// The driver's license's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the front of the driver's license.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The state that issued the provided driver's license.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the driver's license.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpirationDate;
        _ = this.FileID;
        _ = this.State;
        _ = this.BackFileID;
    }

    public DriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DriversLicense(DriversLicense driversLicense)
        : base(driversLicense) { }
#pragma warning restore CS8618

    public DriversLicense(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DriversLicense(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DriversLicenseFromRaw.FromRawUnchecked"/>
    public static DriversLicense FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DriversLicenseFromRaw : IFromRawJson<DriversLicense>
{
    /// <inheritdoc/>
    public DriversLicense FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Other, OtherFromRaw>))]
public sealed record class Other : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// A description of the document submitted.
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
    /// The identifier of the File containing the front of the document.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the document. Not every
    /// document has a reverse side.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <summary>
    /// The document's expiration date in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.Description;
        _ = this.FileID;
        _ = this.BackFileID;
        _ = this.ExpirationDate;
    }

    public Other() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Other(Other other)
        : base(other) { }
#pragma warning restore CS8618

    public Other(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Other(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OtherFromRaw.FromRawUnchecked"/>
    public static Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OtherFromRaw : IFromRawJson<Other>
{
    /// <inheritdoc/>
    public Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Other.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Passport, PassportFromRaw>))]
public sealed record class Passport : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// The passport's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the passport.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.ExpirationDate;
        _ = this.FileID;
    }

    public Passport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Passport(Passport passport)
        : base(passport) { }
#pragma warning restore CS8618

    public Passport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Passport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PassportFromRaw.FromRawUnchecked"/>
    public static Passport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PassportFromRaw : IFromRawJson<Passport>
{
    /// <inheritdoc/>
    public Passport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Passport.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProngConverter))]
public enum Prong
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

sealed class ProngConverter : JsonConverter<Prong>
{
    public override Prong Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ownership" => Prong.Ownership,
            "control" => Prong.Control,
            _ => (Prong)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Prong value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Prong.Ownership => "ownership",
                Prong.Control => "control",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If the entity is exempt from the requirement to submit beneficial owners, provide
/// the justification. If a reason is provided, you do not need to submit a list
/// of beneficial owners.
/// </summary>
[JsonConverter(typeof(BeneficialOwnershipExemptionReasonConverter))]
public enum BeneficialOwnershipExemptionReason
{
    /// <summary>
    /// A regulated financial institution.
    /// </summary>
    RegulatedFinancialInstitution,

    /// <summary>
    /// A publicly traded company.
    /// </summary>
    PubliclyTradedCompany,

    /// <summary>
    /// A public entity acting on behalf of the federal or a state government.
    /// </summary>
    PublicEntity,

    /// <summary>
    /// Any other reason why this entity is exempt from the requirement to submit
    /// beneficial owners. You can only use this exemption after approval from your
    /// bank partner.
    /// </summary>
    Other,
}

sealed class BeneficialOwnershipExemptionReasonConverter
    : JsonConverter<BeneficialOwnershipExemptionReason>
{
    public override BeneficialOwnershipExemptionReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "regulated_financial_institution" =>
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            "publicly_traded_company" => BeneficialOwnershipExemptionReason.PubliclyTradedCompany,
            "public_entity" => BeneficialOwnershipExemptionReason.PublicEntity,
            "other" => BeneficialOwnershipExemptionReason.Other,
            _ => (BeneficialOwnershipExemptionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BeneficialOwnershipExemptionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution =>
                    "regulated_financial_institution",
                BeneficialOwnershipExemptionReason.PubliclyTradedCompany =>
                    "publicly_traded_company",
                BeneficialOwnershipExemptionReason.PublicEntity => "public_entity",
                BeneficialOwnershipExemptionReason.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the Government Authority entity to create. Required if `structure`
/// is equal to `government_authority`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GovernmentAuthority, GovernmentAuthorityFromRaw>))]
public sealed record class GovernmentAuthority : JsonModel
{
    /// <summary>
    /// The entity's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public required GovernmentAuthorityAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GovernmentAuthorityAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The identifying details of authorized officials acting on the entity's behalf.
    /// </summary>
    public required IReadOnlyList<AuthorizedPerson> AuthorizedPersons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AuthorizedPerson>>(
                "authorized_persons"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AuthorizedPerson>>(
                "authorized_persons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The category of the government authority.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The legal name of the government authority.
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
    /// The Employer Identification Number (EIN) for the government authority.
    /// </summary>
    public required string TaxIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tax_identifier");
        }
        init { this._rawData.Set("tax_identifier", value); }
    }

    /// <summary>
    /// The website of the government authority.
    /// </summary>
    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("website", value);
        }
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

    public GovernmentAuthority() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GovernmentAuthority(GovernmentAuthority governmentAuthority)
        : base(governmentAuthority) { }
#pragma warning restore CS8618

    public GovernmentAuthority(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GovernmentAuthority(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GovernmentAuthorityFromRaw.FromRawUnchecked"/>
    public static GovernmentAuthority FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GovernmentAuthorityFromRaw : IFromRawJson<GovernmentAuthority>
{
    /// <inheritdoc/>
    public GovernmentAuthority FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GovernmentAuthority.FromRawUnchecked(rawData);
}

/// <summary>
/// The entity's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GovernmentAuthorityAddress, GovernmentAuthorityAddressFromRaw>)
)]
public sealed record class GovernmentAuthorityAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public GovernmentAuthorityAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GovernmentAuthorityAddress(GovernmentAuthorityAddress governmentAuthorityAddress)
        : base(governmentAuthorityAddress) { }
#pragma warning restore CS8618

    public GovernmentAuthorityAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GovernmentAuthorityAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GovernmentAuthorityAddressFromRaw.FromRawUnchecked"/>
    public static GovernmentAuthorityAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GovernmentAuthorityAddressFromRaw : IFromRawJson<GovernmentAuthorityAddress>
{
    /// <inheritdoc/>
    public GovernmentAuthorityAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GovernmentAuthorityAddress.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AuthorizedPerson, AuthorizedPersonFromRaw>))]
public sealed record class AuthorizedPerson : JsonModel
{
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
        _ = this.Name;
    }

    public AuthorizedPerson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthorizedPerson(AuthorizedPerson authorizedPerson)
        : base(authorizedPerson) { }
#pragma warning restore CS8618

    public AuthorizedPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthorizedPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthorizedPersonFromRaw.FromRawUnchecked"/>
    public static AuthorizedPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AuthorizedPerson(string name)
        : this()
    {
        this.Name = name;
    }
}

class AuthorizedPersonFromRaw : IFromRawJson<AuthorizedPerson>
{
    /// <inheritdoc/>
    public AuthorizedPerson FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuthorizedPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the government authority.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "municipality" => Category.Municipality,
            "state_agency" => Category.StateAgency,
            "state_government" => Category.StateGovernment,
            "federal_agency" => Category.FederalAgency,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Municipality => "municipality",
                Category.StateAgency => "state_agency",
                Category.StateGovernment => "state_government",
                Category.FederalAgency => "federal_agency",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the joint entity to create. Required if `structure` is equal to `joint`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Joint, JointFromRaw>))]
public sealed record class Joint : JsonModel
{
    /// <summary>
    /// The two individuals that share control of the entity.
    /// </summary>
    public required IReadOnlyList<JointIndividual> Individuals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JointIndividual>>("individuals");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JointIndividual>>(
                "individuals",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Individuals)
        {
            item.Validate();
        }
    }

    public Joint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Joint(Joint joint)
        : base(joint) { }
#pragma warning restore CS8618

    public Joint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Joint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointFromRaw.FromRawUnchecked"/>
    public static Joint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Joint(IReadOnlyList<JointIndividual> individuals)
        : this()
    {
        this.Individuals = individuals;
    }
}

class JointFromRaw : IFromRawJson<Joint>
{
    /// <inheritdoc/>
    public Joint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Joint.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<JointIndividual, JointIndividualFromRaw>))]
public sealed record class JointIndividual : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public required JointIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JointIndividualAddress>("address");
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
    public required JointIndividualIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JointIndividualIdentification>("identification");
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

    /// <summary>
    /// The identification method for an individual can only be a passport, driver's
    /// license, or other document if you've confirmed the individual does not have
    /// a US tax id (either a Social Security Number or Individual Taxpayer Identification Number).
    /// </summary>
    public bool? ConfirmedNoUsTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confirmed_no_us_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmed_no_us_tax_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.DateOfBirth;
        this.Identification.Validate();
        _ = this.Name;
        _ = this.ConfirmedNoUsTaxID;
    }

    public JointIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JointIndividual(JointIndividual jointIndividual)
        : base(jointIndividual) { }
#pragma warning restore CS8618

    public JointIndividual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JointIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointIndividualFromRaw.FromRawUnchecked"/>
    public static JointIndividual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JointIndividualFromRaw : IFromRawJson<JointIndividual>
{
    /// <inheritdoc/>
    public JointIndividual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JointIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JointIndividualAddress, JointIndividualAddressFromRaw>))]
public sealed record class JointIndividualAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public JointIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JointIndividualAddress(JointIndividualAddress jointIndividualAddress)
        : base(jointIndividualAddress) { }
#pragma warning restore CS8618

    public JointIndividualAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JointIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointIndividualAddressFromRaw.FromRawUnchecked"/>
    public static JointIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JointIndividualAddressFromRaw : IFromRawJson<JointIndividualAddress>
{
    /// <inheritdoc/>
    public JointIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JointIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JointIndividualIdentification, JointIndividualIdentificationFromRaw>)
)]
public sealed record class JointIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, JointIndividualIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JointIndividualIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number.
    /// </summary>
    public required string Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// Information about the United States driver's license used for identification.
    /// Required if `method` is equal to `drivers_license`.
    /// </summary>
    public JointIndividualIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JointIndividualIdentificationDriversLicense>(
                "drivers_license"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drivers_license", value);
        }
    }

    /// <summary>
    /// Information about the identification document provided. Required if `method`
    /// is equal to `other`.
    /// </summary>
    public JointIndividualIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JointIndividualIdentificationOther>("other");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other", value);
        }
    }

    /// <summary>
    /// Information about the passport used for identification. Required if `method`
    /// is equal to `passport`.
    /// </summary>
    public JointIndividualIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JointIndividualIdentificationPassport>(
                "passport"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Number;
        this.DriversLicense?.Validate();
        this.Other?.Validate();
        this.Passport?.Validate();
    }

    public JointIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JointIndividualIdentification(
        JointIndividualIdentification jointIndividualIdentification
    )
        : base(jointIndividualIdentification) { }
#pragma warning restore CS8618

    public JointIndividualIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JointIndividualIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static JointIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JointIndividualIdentificationFromRaw : IFromRawJson<JointIndividualIdentification>
{
    /// <inheritdoc/>
    public JointIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JointIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(JointIndividualIdentificationMethodConverter))]
public enum JointIndividualIdentificationMethod
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

sealed class JointIndividualIdentificationMethodConverter
    : JsonConverter<JointIndividualIdentificationMethod>
{
    public override JointIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" => JointIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                JointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => JointIndividualIdentificationMethod.Passport,
            "drivers_license" => JointIndividualIdentificationMethod.DriversLicense,
            "other" => JointIndividualIdentificationMethod.Other,
            _ => (JointIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JointIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JointIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                JointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                JointIndividualIdentificationMethod.Passport => "passport",
                JointIndividualIdentificationMethod.DriversLicense => "drivers_license",
                JointIndividualIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the United States driver's license used for identification.
/// Required if `method` is equal to `drivers_license`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        JointIndividualIdentificationDriversLicense,
        JointIndividualIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class JointIndividualIdentificationDriversLicense : JsonModel
{
    /// <summary>
    /// The driver's license's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the front of the driver's license.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The state that issued the provided driver's license.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the driver's license.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpirationDate;
        _ = this.FileID;
        _ = this.State;
        _ = this.BackFileID;
    }

    public JointIndividualIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JointIndividualIdentificationDriversLicense(
        JointIndividualIdentificationDriversLicense jointIndividualIdentificationDriversLicense
    )
        : base(jointIndividualIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public JointIndividualIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JointIndividualIdentificationDriversLicense(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointIndividualIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static JointIndividualIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JointIndividualIdentificationDriversLicenseFromRaw
    : IFromRawJson<JointIndividualIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public JointIndividualIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JointIndividualIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        JointIndividualIdentificationOther,
        JointIndividualIdentificationOtherFromRaw
    >)
)]
public sealed record class JointIndividualIdentificationOther : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// A description of the document submitted.
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
    /// The identifier of the File containing the front of the document.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the document. Not every
    /// document has a reverse side.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <summary>
    /// The document's expiration date in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.Description;
        _ = this.FileID;
        _ = this.BackFileID;
        _ = this.ExpirationDate;
    }

    public JointIndividualIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JointIndividualIdentificationOther(
        JointIndividualIdentificationOther jointIndividualIdentificationOther
    )
        : base(jointIndividualIdentificationOther) { }
#pragma warning restore CS8618

    public JointIndividualIdentificationOther(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JointIndividualIdentificationOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointIndividualIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static JointIndividualIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JointIndividualIdentificationOtherFromRaw : IFromRawJson<JointIndividualIdentificationOther>
{
    /// <inheritdoc/>
    public JointIndividualIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JointIndividualIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        JointIndividualIdentificationPassport,
        JointIndividualIdentificationPassportFromRaw
    >)
)]
public sealed record class JointIndividualIdentificationPassport : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// The passport's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the passport.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.ExpirationDate;
        _ = this.FileID;
    }

    public JointIndividualIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JointIndividualIdentificationPassport(
        JointIndividualIdentificationPassport jointIndividualIdentificationPassport
    )
        : base(jointIndividualIdentificationPassport) { }
#pragma warning restore CS8618

    public JointIndividualIdentificationPassport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JointIndividualIdentificationPassport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JointIndividualIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static JointIndividualIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JointIndividualIdentificationPassportFromRaw
    : IFromRawJson<JointIndividualIdentificationPassport>
{
    /// <inheritdoc/>
    public JointIndividualIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JointIndividualIdentificationPassport.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the natural person entity to create. Required if `structure` is equal
/// to `natural_person`. Natural people entities should be submitted with `social_security_number`
/// or `individual_taxpayer_identification_number` identification methods.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NaturalPerson, NaturalPersonFromRaw>))]
public sealed record class NaturalPerson : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public required NaturalPersonAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NaturalPersonAddress>("address");
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
    public required NaturalPersonIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NaturalPersonIdentification>("identification");
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

    /// <summary>
    /// The identification method for an individual can only be a passport, driver's
    /// license, or other document if you've confirmed the individual does not have
    /// a US tax id (either a Social Security Number or Individual Taxpayer Identification Number).
    /// </summary>
    public bool? ConfirmedNoUsTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confirmed_no_us_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmed_no_us_tax_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.DateOfBirth;
        this.Identification.Validate();
        _ = this.Name;
        _ = this.ConfirmedNoUsTaxID;
    }

    public NaturalPerson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NaturalPerson(NaturalPerson naturalPerson)
        : base(naturalPerson) { }
#pragma warning restore CS8618

    public NaturalPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NaturalPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NaturalPersonFromRaw.FromRawUnchecked"/>
    public static NaturalPerson FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NaturalPersonFromRaw : IFromRawJson<NaturalPerson>
{
    /// <inheritdoc/>
    public NaturalPerson FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NaturalPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NaturalPersonAddress, NaturalPersonAddressFromRaw>))]
public sealed record class NaturalPersonAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public NaturalPersonAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NaturalPersonAddress(NaturalPersonAddress naturalPersonAddress)
        : base(naturalPersonAddress) { }
#pragma warning restore CS8618

    public NaturalPersonAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NaturalPersonAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NaturalPersonAddressFromRaw.FromRawUnchecked"/>
    public static NaturalPersonAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NaturalPersonAddressFromRaw : IFromRawJson<NaturalPersonAddress>
{
    /// <inheritdoc/>
    public NaturalPersonAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NaturalPersonAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NaturalPersonIdentification, NaturalPersonIdentificationFromRaw>)
)]
public sealed record class NaturalPersonIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, NaturalPersonIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NaturalPersonIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number.
    /// </summary>
    public required string Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// Information about the United States driver's license used for identification.
    /// Required if `method` is equal to `drivers_license`.
    /// </summary>
    public NaturalPersonIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NaturalPersonIdentificationDriversLicense>(
                "drivers_license"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drivers_license", value);
        }
    }

    /// <summary>
    /// Information about the identification document provided. Required if `method`
    /// is equal to `other`.
    /// </summary>
    public NaturalPersonIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NaturalPersonIdentificationOther>("other");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other", value);
        }
    }

    /// <summary>
    /// Information about the passport used for identification. Required if `method`
    /// is equal to `passport`.
    /// </summary>
    public NaturalPersonIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NaturalPersonIdentificationPassport>("passport");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Number;
        this.DriversLicense?.Validate();
        this.Other?.Validate();
        this.Passport?.Validate();
    }

    public NaturalPersonIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NaturalPersonIdentification(NaturalPersonIdentification naturalPersonIdentification)
        : base(naturalPersonIdentification) { }
#pragma warning restore CS8618

    public NaturalPersonIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NaturalPersonIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NaturalPersonIdentificationFromRaw.FromRawUnchecked"/>
    public static NaturalPersonIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NaturalPersonIdentificationFromRaw : IFromRawJson<NaturalPersonIdentification>
{
    /// <inheritdoc/>
    public NaturalPersonIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NaturalPersonIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(NaturalPersonIdentificationMethodConverter))]
public enum NaturalPersonIdentificationMethod
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

sealed class NaturalPersonIdentificationMethodConverter
    : JsonConverter<NaturalPersonIdentificationMethod>
{
    public override NaturalPersonIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" => NaturalPersonIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                NaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => NaturalPersonIdentificationMethod.Passport,
            "drivers_license" => NaturalPersonIdentificationMethod.DriversLicense,
            "other" => NaturalPersonIdentificationMethod.Other,
            _ => (NaturalPersonIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NaturalPersonIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NaturalPersonIdentificationMethod.SocialSecurityNumber => "social_security_number",
                NaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                NaturalPersonIdentificationMethod.Passport => "passport",
                NaturalPersonIdentificationMethod.DriversLicense => "drivers_license",
                NaturalPersonIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the United States driver's license used for identification.
/// Required if `method` is equal to `drivers_license`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NaturalPersonIdentificationDriversLicense,
        NaturalPersonIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class NaturalPersonIdentificationDriversLicense : JsonModel
{
    /// <summary>
    /// The driver's license's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the front of the driver's license.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The state that issued the provided driver's license.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the driver's license.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpirationDate;
        _ = this.FileID;
        _ = this.State;
        _ = this.BackFileID;
    }

    public NaturalPersonIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NaturalPersonIdentificationDriversLicense(
        NaturalPersonIdentificationDriversLicense naturalPersonIdentificationDriversLicense
    )
        : base(naturalPersonIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public NaturalPersonIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NaturalPersonIdentificationDriversLicense(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NaturalPersonIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static NaturalPersonIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NaturalPersonIdentificationDriversLicenseFromRaw
    : IFromRawJson<NaturalPersonIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public NaturalPersonIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NaturalPersonIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NaturalPersonIdentificationOther,
        NaturalPersonIdentificationOtherFromRaw
    >)
)]
public sealed record class NaturalPersonIdentificationOther : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// A description of the document submitted.
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
    /// The identifier of the File containing the front of the document.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the document. Not every
    /// document has a reverse side.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <summary>
    /// The document's expiration date in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.Description;
        _ = this.FileID;
        _ = this.BackFileID;
        _ = this.ExpirationDate;
    }

    public NaturalPersonIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NaturalPersonIdentificationOther(
        NaturalPersonIdentificationOther naturalPersonIdentificationOther
    )
        : base(naturalPersonIdentificationOther) { }
#pragma warning restore CS8618

    public NaturalPersonIdentificationOther(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NaturalPersonIdentificationOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NaturalPersonIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static NaturalPersonIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NaturalPersonIdentificationOtherFromRaw : IFromRawJson<NaturalPersonIdentificationOther>
{
    /// <inheritdoc/>
    public NaturalPersonIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NaturalPersonIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NaturalPersonIdentificationPassport,
        NaturalPersonIdentificationPassportFromRaw
    >)
)]
public sealed record class NaturalPersonIdentificationPassport : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// The passport's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the passport.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.ExpirationDate;
        _ = this.FileID;
    }

    public NaturalPersonIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NaturalPersonIdentificationPassport(
        NaturalPersonIdentificationPassport naturalPersonIdentificationPassport
    )
        : base(naturalPersonIdentificationPassport) { }
#pragma warning restore CS8618

    public NaturalPersonIdentificationPassport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NaturalPersonIdentificationPassport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NaturalPersonIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static NaturalPersonIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NaturalPersonIdentificationPassportFromRaw : IFromRawJson<NaturalPersonIdentificationPassport>
{
    /// <inheritdoc/>
    public NaturalPersonIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NaturalPersonIdentificationPassport.FromRawUnchecked(rawData);
}

/// <summary>
/// An assessment of the entity's potential risk of involvement in financial crimes,
/// such as money laundering.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RiskRating, RiskRatingFromRaw>))]
public sealed record class RiskRating : JsonModel
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
    public required ApiEnum<string, Rating> Rating
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Rating>>("rating");
        }
        init { this._rawData.Set("rating", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RatedAt;
        this.Rating.Validate();
    }

    public RiskRating() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RiskRating(RiskRating riskRating)
        : base(riskRating) { }
#pragma warning restore CS8618

    public RiskRating(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RiskRating(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RiskRatingFromRaw.FromRawUnchecked"/>
    public static RiskRating FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RiskRatingFromRaw : IFromRawJson<RiskRating>
{
    /// <inheritdoc/>
    public RiskRating FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RiskRating.FromRawUnchecked(rawData);
}

/// <summary>
/// The rating given to this entity.
/// </summary>
[JsonConverter(typeof(RatingConverter))]
public enum Rating
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

sealed class RatingConverter : JsonConverter<Rating>
{
    public override Rating Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => Rating.Low,
            "medium" => Rating.Medium,
            "high" => Rating.High,
            _ => (Rating)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Rating value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Rating.Low => "low",
                Rating.Medium => "medium",
                Rating.High => "high",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SupplementalDocument, SupplementalDocumentFromRaw>))]
public sealed record class SupplementalDocument : JsonModel
{
    /// <summary>
    /// The identifier of the File containing the document.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
    }

    public SupplementalDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SupplementalDocument(SupplementalDocument supplementalDocument)
        : base(supplementalDocument) { }
#pragma warning restore CS8618

    public SupplementalDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SupplementalDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SupplementalDocumentFromRaw.FromRawUnchecked"/>
    public static SupplementalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SupplementalDocument(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class SupplementalDocumentFromRaw : IFromRawJson<SupplementalDocument>
{
    /// <inheritdoc/>
    public SupplementalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SupplementalDocument.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TermsAgreement, TermsAgreementFromRaw>))]
public sealed record class TermsAgreement : JsonModel
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

    public TermsAgreement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TermsAgreement(TermsAgreement termsAgreement)
        : base(termsAgreement) { }
#pragma warning restore CS8618

    public TermsAgreement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TermsAgreement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TermsAgreementFromRaw.FromRawUnchecked"/>
    public static TermsAgreement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TermsAgreementFromRaw : IFromRawJson<TermsAgreement>
{
    /// <inheritdoc/>
    public TermsAgreement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TermsAgreement.FromRawUnchecked(rawData);
}

/// <summary>
/// If you are using a third-party service for identity verification, you can use
/// this field to associate this Entity with the identifier that represents them in
/// that service.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThirdPartyVerification, ThirdPartyVerificationFromRaw>))]
public sealed record class ThirdPartyVerification : JsonModel
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
    public required ApiEnum<string, Vendor> Vendor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Vendor>>("vendor");
        }
        init { this._rawData.Set("vendor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reference;
        this.Vendor.Validate();
    }

    public ThirdPartyVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThirdPartyVerification(ThirdPartyVerification thirdPartyVerification)
        : base(thirdPartyVerification) { }
#pragma warning restore CS8618

    public ThirdPartyVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThirdPartyVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThirdPartyVerificationFromRaw.FromRawUnchecked"/>
    public static ThirdPartyVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThirdPartyVerificationFromRaw : IFromRawJson<ThirdPartyVerification>
{
    /// <inheritdoc/>
    public ThirdPartyVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThirdPartyVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor that was used to perform the verification.
/// </summary>
[JsonConverter(typeof(VendorConverter))]
public enum Vendor
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

sealed class VendorConverter : JsonConverter<Vendor>
{
    public override Vendor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "alloy" => Vendor.Alloy,
            "middesk" => Vendor.Middesk,
            "oscilar" => Vendor.Oscilar,
            "persona" => Vendor.Persona,
            "taktile" => Vendor.Taktile,
            _ => (Vendor)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Vendor value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Vendor.Alloy => "alloy",
                Vendor.Middesk => "middesk",
                Vendor.Oscilar => "oscilar",
                Vendor.Persona => "persona",
                Vendor.Taktile => "taktile",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the trust entity to create. Required if `structure` is equal to `trust`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Trust, TrustFromRaw>))]
public sealed record class Trust : JsonModel
{
    /// <summary>
    /// The trust's physical address. Mail receiving locations like PO Boxes and PMB's
    /// are disallowed.
    /// </summary>
    public required TrustAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TrustAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Whether the trust is `revocable` or `irrevocable`. Irrevocable trusts require
    /// their own Employer Identification Number. Revocable trusts require information
    /// about the individual `grantor` who created the trust.
    /// </summary>
    public required ApiEnum<string, TrustCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TrustCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// The legal name of the trust.
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
    /// The trustees of the trust.
    /// </summary>
    public required IReadOnlyList<Trustee> Trustees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Trustee>>("trustees");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Trustee>>(
                "trustees",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The identifier of the File containing the formation document of the trust.
    /// </summary>
    public string? FormationDocumentFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formation_document_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formation_document_file_id", value);
        }
    }

    /// <summary>
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// in which the trust was formed.
    /// </summary>
    public string? FormationState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formation_state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formation_state", value);
        }
    }

    /// <summary>
    /// The grantor of the trust. Required if `category` is equal to `revocable`.
    /// </summary>
    public Grantor? Grantor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Grantor>("grantor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("grantor", value);
        }
    }

    /// <summary>
    /// The Employer Identification Number (EIN) for the trust. Required if `category`
    /// is equal to `irrevocable`.
    /// </summary>
    public string? TaxIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_identifier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_identifier", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        this.Category.Validate();
        _ = this.Name;
        foreach (var item in this.Trustees)
        {
            item.Validate();
        }
        _ = this.FormationDocumentFileID;
        _ = this.FormationState;
        this.Grantor?.Validate();
        _ = this.TaxIdentifier;
    }

    public Trust() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trust(Trust trust)
        : base(trust) { }
#pragma warning restore CS8618

    public Trust(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trust(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrustFromRaw.FromRawUnchecked"/>
    public static Trust FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrustFromRaw : IFromRawJson<Trust>
{
    /// <inheritdoc/>
    public Trust FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trust.FromRawUnchecked(rawData);
}

/// <summary>
/// The trust's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TrustAddress, TrustAddressFromRaw>))]
public sealed record class TrustAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public TrustAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrustAddress(TrustAddress trustAddress)
        : base(trustAddress) { }
#pragma warning restore CS8618

    public TrustAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrustAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrustAddressFromRaw.FromRawUnchecked"/>
    public static TrustAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrustAddressFromRaw : IFromRawJson<TrustAddress>
{
    /// <inheritdoc/>
    public TrustAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrustAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the trust is `revocable` or `irrevocable`. Irrevocable trusts require
/// their own Employer Identification Number. Revocable trusts require information
/// about the individual `grantor` who created the trust.
/// </summary>
[JsonConverter(typeof(TrustCategoryConverter))]
public enum TrustCategory
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

sealed class TrustCategoryConverter : JsonConverter<TrustCategory>
{
    public override TrustCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "revocable" => TrustCategory.Revocable,
            "irrevocable" => TrustCategory.Irrevocable,
            _ => (TrustCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrustCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrustCategory.Revocable => "revocable",
                TrustCategory.Irrevocable => "irrevocable",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Trustee, TrusteeFromRaw>))]
public sealed record class Trustee : JsonModel
{
    /// <summary>
    /// The structure of the trustee.
    /// </summary>
    public required ApiEnum<string, TrusteeStructure> Structure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TrusteeStructure>>("structure");
        }
        init { this._rawData.Set("structure", value); }
    }

    /// <summary>
    /// Details of the individual trustee. Within the trustee object, this is required
    /// if `structure` is equal to `individual`.
    /// </summary>
    public TrusteeIndividual? Individual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrusteeIndividual>("individual");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("individual", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Structure.Validate();
        this.Individual?.Validate();
    }

    public Trustee() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trustee(Trustee trustee)
        : base(trustee) { }
#pragma warning restore CS8618

    public Trustee(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trustee(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeFromRaw.FromRawUnchecked"/>
    public static Trustee FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Trustee(ApiEnum<string, TrusteeStructure> structure)
        : this()
    {
        this.Structure = structure;
    }
}

class TrusteeFromRaw : IFromRawJson<Trustee>
{
    /// <inheritdoc/>
    public Trustee FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trustee.FromRawUnchecked(rawData);
}

/// <summary>
/// The structure of the trustee.
/// </summary>
[JsonConverter(typeof(TrusteeStructureConverter))]
public enum TrusteeStructure
{
    /// <summary>
    /// The trustee is an individual.
    /// </summary>
    Individual,
}

sealed class TrusteeStructureConverter : JsonConverter<TrusteeStructure>
{
    public override TrusteeStructure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => TrusteeStructure.Individual,
            _ => (TrusteeStructure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrusteeStructure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrusteeStructure.Individual => "individual",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the individual trustee. Within the trustee object, this is required
/// if `structure` is equal to `individual`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TrusteeIndividual, TrusteeIndividualFromRaw>))]
public sealed record class TrusteeIndividual : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public required TrusteeIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TrusteeIndividualAddress>("address");
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
    public required TrusteeIndividualIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TrusteeIndividualIdentification>("identification");
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

    /// <summary>
    /// The identification method for an individual can only be a passport, driver's
    /// license, or other document if you've confirmed the individual does not have
    /// a US tax id (either a Social Security Number or Individual Taxpayer Identification Number).
    /// </summary>
    public bool? ConfirmedNoUsTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confirmed_no_us_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmed_no_us_tax_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.DateOfBirth;
        this.Identification.Validate();
        _ = this.Name;
        _ = this.ConfirmedNoUsTaxID;
    }

    public TrusteeIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrusteeIndividual(TrusteeIndividual trusteeIndividual)
        : base(trusteeIndividual) { }
#pragma warning restore CS8618

    public TrusteeIndividual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrusteeIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeIndividualFromRaw.FromRawUnchecked"/>
    public static TrusteeIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrusteeIndividualFromRaw : IFromRawJson<TrusteeIndividual>
{
    /// <inheritdoc/>
    public TrusteeIndividual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrusteeIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TrusteeIndividualAddress, TrusteeIndividualAddressFromRaw>)
)]
public sealed record class TrusteeIndividualAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public TrusteeIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrusteeIndividualAddress(TrusteeIndividualAddress trusteeIndividualAddress)
        : base(trusteeIndividualAddress) { }
#pragma warning restore CS8618

    public TrusteeIndividualAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrusteeIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeIndividualAddressFromRaw.FromRawUnchecked"/>
    public static TrusteeIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrusteeIndividualAddressFromRaw : IFromRawJson<TrusteeIndividualAddress>
{
    /// <inheritdoc/>
    public TrusteeIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrusteeIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TrusteeIndividualIdentification,
        TrusteeIndividualIdentificationFromRaw
    >)
)]
public sealed record class TrusteeIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, TrusteeIndividualIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TrusteeIndividualIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number.
    /// </summary>
    public required string Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// Information about the United States driver's license used for identification.
    /// Required if `method` is equal to `drivers_license`.
    /// </summary>
    public TrusteeIndividualIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrusteeIndividualIdentificationDriversLicense>(
                "drivers_license"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drivers_license", value);
        }
    }

    /// <summary>
    /// Information about the identification document provided. Required if `method`
    /// is equal to `other`.
    /// </summary>
    public TrusteeIndividualIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrusteeIndividualIdentificationOther>("other");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other", value);
        }
    }

    /// <summary>
    /// Information about the passport used for identification. Required if `method`
    /// is equal to `passport`.
    /// </summary>
    public TrusteeIndividualIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrusteeIndividualIdentificationPassport>(
                "passport"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Number;
        this.DriversLicense?.Validate();
        this.Other?.Validate();
        this.Passport?.Validate();
    }

    public TrusteeIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrusteeIndividualIdentification(
        TrusteeIndividualIdentification trusteeIndividualIdentification
    )
        : base(trusteeIndividualIdentification) { }
#pragma warning restore CS8618

    public TrusteeIndividualIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrusteeIndividualIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static TrusteeIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrusteeIndividualIdentificationFromRaw : IFromRawJson<TrusteeIndividualIdentification>
{
    /// <inheritdoc/>
    public TrusteeIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrusteeIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(TrusteeIndividualIdentificationMethodConverter))]
public enum TrusteeIndividualIdentificationMethod
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

sealed class TrusteeIndividualIdentificationMethodConverter
    : JsonConverter<TrusteeIndividualIdentificationMethod>
{
    public override TrusteeIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" => TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                TrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => TrusteeIndividualIdentificationMethod.Passport,
            "drivers_license" => TrusteeIndividualIdentificationMethod.DriversLicense,
            "other" => TrusteeIndividualIdentificationMethod.Other,
            _ => (TrusteeIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrusteeIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrusteeIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                TrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                TrusteeIndividualIdentificationMethod.Passport => "passport",
                TrusteeIndividualIdentificationMethod.DriversLicense => "drivers_license",
                TrusteeIndividualIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the United States driver's license used for identification.
/// Required if `method` is equal to `drivers_license`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TrusteeIndividualIdentificationDriversLicense,
        TrusteeIndividualIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class TrusteeIndividualIdentificationDriversLicense : JsonModel
{
    /// <summary>
    /// The driver's license's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the front of the driver's license.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The state that issued the provided driver's license.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the driver's license.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpirationDate;
        _ = this.FileID;
        _ = this.State;
        _ = this.BackFileID;
    }

    public TrusteeIndividualIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrusteeIndividualIdentificationDriversLicense(
        TrusteeIndividualIdentificationDriversLicense trusteeIndividualIdentificationDriversLicense
    )
        : base(trusteeIndividualIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public TrusteeIndividualIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrusteeIndividualIdentificationDriversLicense(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeIndividualIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static TrusteeIndividualIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrusteeIndividualIdentificationDriversLicenseFromRaw
    : IFromRawJson<TrusteeIndividualIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public TrusteeIndividualIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrusteeIndividualIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TrusteeIndividualIdentificationOther,
        TrusteeIndividualIdentificationOtherFromRaw
    >)
)]
public sealed record class TrusteeIndividualIdentificationOther : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// A description of the document submitted.
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
    /// The identifier of the File containing the front of the document.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the document. Not every
    /// document has a reverse side.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <summary>
    /// The document's expiration date in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.Description;
        _ = this.FileID;
        _ = this.BackFileID;
        _ = this.ExpirationDate;
    }

    public TrusteeIndividualIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrusteeIndividualIdentificationOther(
        TrusteeIndividualIdentificationOther trusteeIndividualIdentificationOther
    )
        : base(trusteeIndividualIdentificationOther) { }
#pragma warning restore CS8618

    public TrusteeIndividualIdentificationOther(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrusteeIndividualIdentificationOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeIndividualIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static TrusteeIndividualIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrusteeIndividualIdentificationOtherFromRaw
    : IFromRawJson<TrusteeIndividualIdentificationOther>
{
    /// <inheritdoc/>
    public TrusteeIndividualIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrusteeIndividualIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TrusteeIndividualIdentificationPassport,
        TrusteeIndividualIdentificationPassportFromRaw
    >)
)]
public sealed record class TrusteeIndividualIdentificationPassport : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// The passport's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the passport.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.ExpirationDate;
        _ = this.FileID;
    }

    public TrusteeIndividualIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrusteeIndividualIdentificationPassport(
        TrusteeIndividualIdentificationPassport trusteeIndividualIdentificationPassport
    )
        : base(trusteeIndividualIdentificationPassport) { }
#pragma warning restore CS8618

    public TrusteeIndividualIdentificationPassport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrusteeIndividualIdentificationPassport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrusteeIndividualIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static TrusteeIndividualIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrusteeIndividualIdentificationPassportFromRaw
    : IFromRawJson<TrusteeIndividualIdentificationPassport>
{
    /// <inheritdoc/>
    public TrusteeIndividualIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrusteeIndividualIdentificationPassport.FromRawUnchecked(rawData);
}

/// <summary>
/// The grantor of the trust. Required if `category` is equal to `revocable`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Grantor, GrantorFromRaw>))]
public sealed record class Grantor : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public required GrantorAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GrantorAddress>("address");
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
    public required GrantorIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GrantorIdentification>("identification");
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

    /// <summary>
    /// The identification method for an individual can only be a passport, driver's
    /// license, or other document if you've confirmed the individual does not have
    /// a US tax id (either a Social Security Number or Individual Taxpayer Identification Number).
    /// </summary>
    public bool? ConfirmedNoUsTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confirmed_no_us_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmed_no_us_tax_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
        _ = this.DateOfBirth;
        this.Identification.Validate();
        _ = this.Name;
        _ = this.ConfirmedNoUsTaxID;
    }

    public Grantor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Grantor(Grantor grantor)
        : base(grantor) { }
#pragma warning restore CS8618

    public Grantor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Grantor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantorFromRaw.FromRawUnchecked"/>
    public static Grantor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantorFromRaw : IFromRawJson<Grantor>
{
    /// <inheritdoc/>
    public Grantor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Grantor.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GrantorAddress, GrantorAddressFromRaw>))]
public sealed record class GrantorAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address. This is usually the street number and street.
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
    /// The two-letter United States Postal Service (USPS) abbreviation for the state
    /// of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The ZIP code of the address.
    /// </summary>
    public required string Zip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("zip");
        }
        init { this._rawData.Set("zip", value); }
    }

    /// <summary>
    /// The second line of the address. This might be the floor or room number.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.State;
        _ = this.Zip;
        _ = this.Line2;
    }

    public GrantorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantorAddress(GrantorAddress grantorAddress)
        : base(grantorAddress) { }
#pragma warning restore CS8618

    public GrantorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantorAddressFromRaw.FromRawUnchecked"/>
    public static GrantorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantorAddressFromRaw : IFromRawJson<GrantorAddress>
{
    /// <inheritdoc/>
    public GrantorAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GrantorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GrantorIdentification, GrantorIdentificationFromRaw>))]
public sealed record class GrantorIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, GrantorIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GrantorIdentificationMethod>>(
                "method"
            );
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number.
    /// </summary>
    public required string Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// Information about the United States driver's license used for identification.
    /// Required if `method` is equal to `drivers_license`.
    /// </summary>
    public GrantorIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GrantorIdentificationDriversLicense>(
                "drivers_license"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drivers_license", value);
        }
    }

    /// <summary>
    /// Information about the identification document provided. Required if `method`
    /// is equal to `other`.
    /// </summary>
    public GrantorIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GrantorIdentificationOther>("other");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("other", value);
        }
    }

    /// <summary>
    /// Information about the passport used for identification. Required if `method`
    /// is equal to `passport`.
    /// </summary>
    public GrantorIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GrantorIdentificationPassport>("passport");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passport", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Number;
        this.DriversLicense?.Validate();
        this.Other?.Validate();
        this.Passport?.Validate();
    }

    public GrantorIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantorIdentification(GrantorIdentification grantorIdentification)
        : base(grantorIdentification) { }
#pragma warning restore CS8618

    public GrantorIdentification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantorIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantorIdentificationFromRaw.FromRawUnchecked"/>
    public static GrantorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantorIdentificationFromRaw : IFromRawJson<GrantorIdentification>
{
    /// <inheritdoc/>
    public GrantorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantorIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(GrantorIdentificationMethodConverter))]
public enum GrantorIdentificationMethod
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

sealed class GrantorIdentificationMethodConverter : JsonConverter<GrantorIdentificationMethod>
{
    public override GrantorIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" => GrantorIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                GrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => GrantorIdentificationMethod.Passport,
            "drivers_license" => GrantorIdentificationMethod.DriversLicense,
            "other" => GrantorIdentificationMethod.Other,
            _ => (GrantorIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantorIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantorIdentificationMethod.SocialSecurityNumber => "social_security_number",
                GrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                GrantorIdentificationMethod.Passport => "passport",
                GrantorIdentificationMethod.DriversLicense => "drivers_license",
                GrantorIdentificationMethod.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the United States driver's license used for identification.
/// Required if `method` is equal to `drivers_license`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        GrantorIdentificationDriversLicense,
        GrantorIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class GrantorIdentificationDriversLicense : JsonModel
{
    /// <summary>
    /// The driver's license's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the front of the driver's license.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The state that issued the provided driver's license.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the driver's license.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpirationDate;
        _ = this.FileID;
        _ = this.State;
        _ = this.BackFileID;
    }

    public GrantorIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantorIdentificationDriversLicense(
        GrantorIdentificationDriversLicense grantorIdentificationDriversLicense
    )
        : base(grantorIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public GrantorIdentificationDriversLicense(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantorIdentificationDriversLicense(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantorIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static GrantorIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantorIdentificationDriversLicenseFromRaw : IFromRawJson<GrantorIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public GrantorIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantorIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GrantorIdentificationOther, GrantorIdentificationOtherFromRaw>)
)]
public sealed record class GrantorIdentificationOther : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// A description of the document submitted.
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
    /// The identifier of the File containing the front of the document.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the back of the document. Not every
    /// document has a reverse side.
    /// </summary>
    public string? BackFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_file_id", value);
        }
    }

    /// <summary>
    /// The document's expiration date in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.Description;
        _ = this.FileID;
        _ = this.BackFileID;
        _ = this.ExpirationDate;
    }

    public GrantorIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantorIdentificationOther(GrantorIdentificationOther grantorIdentificationOther)
        : base(grantorIdentificationOther) { }
#pragma warning restore CS8618

    public GrantorIdentificationOther(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantorIdentificationOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantorIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static GrantorIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantorIdentificationOtherFromRaw : IFromRawJson<GrantorIdentificationOther>
{
    /// <inheritdoc/>
    public GrantorIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantorIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GrantorIdentificationPassport, GrantorIdentificationPassportFromRaw>)
)]
public sealed record class GrantorIdentificationPassport : JsonModel
{
    /// <summary>
    /// The two-character ISO 3166-1 code representing the country that issued the
    /// document (e.g., `US`).
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
    /// The passport's expiration date in YYYY-MM-DD format.
    /// </summary>
    public required string ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiration_date");
        }
        init { this._rawData.Set("expiration_date", value); }
    }

    /// <summary>
    /// The identifier of the File containing the passport.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.ExpirationDate;
        _ = this.FileID;
    }

    public GrantorIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantorIdentificationPassport(
        GrantorIdentificationPassport grantorIdentificationPassport
    )
        : base(grantorIdentificationPassport) { }
#pragma warning restore CS8618

    public GrantorIdentificationPassport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantorIdentificationPassport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantorIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static GrantorIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantorIdentificationPassportFromRaw : IFromRawJson<GrantorIdentificationPassport>
{
    /// <inheritdoc/>
    public GrantorIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantorIdentificationPassport.FromRawUnchecked(rawData);
}
