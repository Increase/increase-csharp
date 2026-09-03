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
/// Update an Entity
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntityUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EntityID { get; init; }

    /// <summary>
    /// Details of the corporation entity to update. If you specify this parameter
    /// and the entity is not a corporation, the request will fail.
    /// </summary>
    public EntityUpdateParamsCorporation? Corporation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsCorporation>("corporation");
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
    /// When your user last confirmed the Entity's details. Depending on your program,
    /// you may be required to affirmatively confirm details with your users on an
    /// annual basis.
    /// </summary>
    public System::DateTimeOffset? DetailsConfirmedAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>(
                "details_confirmed_at"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("details_confirmed_at", value);
        }
    }

    /// <summary>
    /// Details of the government authority entity to update. If you specify this
    /// parameter and the entity is not a government authority, the request will fail.
    /// </summary>
    public EntityUpdateParamsGovernmentAuthority? GovernmentAuthority
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsGovernmentAuthority>(
                "government_authority"
            );
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
    /// Details of the natural person entity to update. If you specify this parameter
    /// and the entity is not a natural person, the request will fail.
    /// </summary>
    public EntityUpdateParamsNaturalPerson? NaturalPerson
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsNaturalPerson>(
                "natural_person"
            );
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
    /// An assessment of the entity’s potential risk of involvement in financial crimes,
    /// such as money laundering.
    /// </summary>
    public EntityUpdateParamsRiskRating? RiskRating
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsRiskRating>("risk_rating");
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
    /// Details of the sole proprietorship entity to update. If you specify this
    /// parameter and the entity is not a sole proprietorship, the request will fail.
    /// </summary>
    public EntityUpdateParamsSoleProprietorship? SoleProprietorship
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsSoleProprietorship>(
                "sole_proprietorship"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sole_proprietorship", value);
        }
    }

    /// <summary>
    /// New terms that the Entity agreed to. Not all programs are required to submit
    /// this data. This will not archive previously submitted terms.
    /// </summary>
    public IReadOnlyList<EntityUpdateParamsTermsAgreement>? TermsAgreements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<EntityUpdateParamsTermsAgreement>
            >("terms_agreements");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<EntityUpdateParamsTermsAgreement>?>(
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
    public EntityUpdateParamsThirdPartyVerification? ThirdPartyVerification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsThirdPartyVerification>(
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
    /// Details of the trust entity to update. If you specify this parameter and the
    /// entity is not a trust, the request will fail.
    /// </summary>
    public EntityUpdateParamsTrust? Trust
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntityUpdateParamsTrust>("trust");
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

    public EntityUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParams(EntityUpdateParams entityUpdateParams)
        : base(entityUpdateParams)
    {
        this.EntityID = entityUpdateParams.EntityID;

        this._rawBodyData = new(entityUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntityUpdateParams(
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
    EntityUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string entityID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EntityID = entityID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntityUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string entityID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            entityID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EntityID"] = JsonSerializer.SerializeToElement(this.EntityID),
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

    public virtual bool Equals(EntityUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EntityID?.Equals(other.EntityID) ?? other.EntityID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/entities/{0}", this.EntityID)
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
/// Details of the corporation entity to update. If you specify this parameter and
/// the entity is not a corporation, the request will fail.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityUpdateParamsCorporation, EntityUpdateParamsCorporationFromRaw>)
)]
public sealed record class EntityUpdateParamsCorporation : JsonModel
{
    /// <summary>
    /// The entity's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public EntityUpdateParamsCorporationAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsCorporationAddress>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
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
    /// The legal identifier of the corporation. This is usually the Employer Identification
    /// Number (EIN).
    /// </summary>
    public EntityUpdateParamsCorporationLegalIdentifier? LegalIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsCorporationLegalIdentifier>(
                "legal_identifier"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("legal_identifier", value);
        }
    }

    /// <summary>
    /// The legal name of the corporation.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// A website for the business. Not every program requires a website for submitted Entities.
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
        this.Address?.Validate();
        _ = this.Email;
        _ = this.IncorporationState;
        _ = this.IndustryCode;
        this.LegalIdentifier?.Validate();
        _ = this.Name;
        _ = this.Website;
    }

    public EntityUpdateParamsCorporation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsCorporation(
        EntityUpdateParamsCorporation entityUpdateParamsCorporation
    )
        : base(entityUpdateParamsCorporation) { }
#pragma warning restore CS8618

    public EntityUpdateParamsCorporation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsCorporation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsCorporationFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsCorporation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsCorporationFromRaw : IFromRawJson<EntityUpdateParamsCorporation>
{
    /// <inheritdoc/>
    public EntityUpdateParamsCorporation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsCorporation.FromRawUnchecked(rawData);
}

/// <summary>
/// The entity's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsCorporationAddress,
        EntityUpdateParamsCorporationAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsCorporationAddress : JsonModel
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
    ///
    /// <para>Defaults to `US`.</para>
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

    public EntityUpdateParamsCorporationAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsCorporationAddress(
        EntityUpdateParamsCorporationAddress entityUpdateParamsCorporationAddress
    )
        : base(entityUpdateParamsCorporationAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsCorporationAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsCorporationAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsCorporationAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsCorporationAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsCorporationAddressFromRaw
    : IFromRawJson<EntityUpdateParamsCorporationAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsCorporationAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsCorporationAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The legal identifier of the corporation. This is usually the Employer Identification
/// Number (EIN).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsCorporationLegalIdentifier,
        EntityUpdateParamsCorporationLegalIdentifierFromRaw
    >)
)]
public sealed record class EntityUpdateParamsCorporationLegalIdentifier : JsonModel
{
    /// <summary>
    /// The legal identifier itself. For US Employer Identification Numbers, submit
    /// nine digits with no dashes or other separators.
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

    /// <summary>
    /// The category of the legal identifier.
    ///
    /// <para>Defaults to `us_employer_identification_number`.</para>
    /// </summary>
    public ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory>? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory>
            >("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Value;
        this.Category?.Validate();
    }

    public EntityUpdateParamsCorporationLegalIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsCorporationLegalIdentifier(
        EntityUpdateParamsCorporationLegalIdentifier entityUpdateParamsCorporationLegalIdentifier
    )
        : base(entityUpdateParamsCorporationLegalIdentifier) { }
#pragma warning restore CS8618

    public EntityUpdateParamsCorporationLegalIdentifier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsCorporationLegalIdentifier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsCorporationLegalIdentifierFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsCorporationLegalIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityUpdateParamsCorporationLegalIdentifier(string value)
        : this()
    {
        this.Value = value;
    }
}

class EntityUpdateParamsCorporationLegalIdentifierFromRaw
    : IFromRawJson<EntityUpdateParamsCorporationLegalIdentifier>
{
    /// <inheritdoc/>
    public EntityUpdateParamsCorporationLegalIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsCorporationLegalIdentifier.FromRawUnchecked(rawData);
}

/// <summary>
/// The category of the legal identifier.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsCorporationLegalIdentifierCategoryConverter))]
public enum EntityUpdateParamsCorporationLegalIdentifierCategory
{
    /// <summary>
    /// The Employer Identification Number (EIN) for the company. The EIN is a 9-digit
    /// number assigned by the IRS; submit it as nine digits with no dashes or other separators.
    /// </summary>
    UsEmployerIdentificationNumber,

    /// <summary>
    /// A legal identifier issued by a foreign government, like a tax identification
    /// number or registration number.
    /// </summary>
    Other,
}

sealed class EntityUpdateParamsCorporationLegalIdentifierCategoryConverter
    : JsonConverter<EntityUpdateParamsCorporationLegalIdentifierCategory>
{
    public override EntityUpdateParamsCorporationLegalIdentifierCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us_employer_identification_number" =>
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            "other" => EntityUpdateParamsCorporationLegalIdentifierCategory.Other,
            _ => (EntityUpdateParamsCorporationLegalIdentifierCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsCorporationLegalIdentifierCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber =>
                    "us_employer_identification_number",
                EntityUpdateParamsCorporationLegalIdentifierCategory.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the government authority entity to update. If you specify this parameter
/// and the entity is not a government authority, the request will fail.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsGovernmentAuthority,
        EntityUpdateParamsGovernmentAuthorityFromRaw
    >)
)]
public sealed record class EntityUpdateParamsGovernmentAuthority : JsonModel
{
    /// <summary>
    /// The entity's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public EntityUpdateParamsGovernmentAuthorityAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsGovernmentAuthorityAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// The legal name of the government authority.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        _ = this.Name;
    }

    public EntityUpdateParamsGovernmentAuthority() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsGovernmentAuthority(
        EntityUpdateParamsGovernmentAuthority entityUpdateParamsGovernmentAuthority
    )
        : base(entityUpdateParamsGovernmentAuthority) { }
#pragma warning restore CS8618

    public EntityUpdateParamsGovernmentAuthority(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsGovernmentAuthority(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsGovernmentAuthorityFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsGovernmentAuthority FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsGovernmentAuthorityFromRaw
    : IFromRawJson<EntityUpdateParamsGovernmentAuthority>
{
    /// <inheritdoc/>
    public EntityUpdateParamsGovernmentAuthority FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsGovernmentAuthority.FromRawUnchecked(rawData);
}

/// <summary>
/// The entity's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsGovernmentAuthorityAddress,
        EntityUpdateParamsGovernmentAuthorityAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsGovernmentAuthorityAddress : JsonModel
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

    public EntityUpdateParamsGovernmentAuthorityAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsGovernmentAuthorityAddress(
        EntityUpdateParamsGovernmentAuthorityAddress entityUpdateParamsGovernmentAuthorityAddress
    )
        : base(entityUpdateParamsGovernmentAuthorityAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsGovernmentAuthorityAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsGovernmentAuthorityAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsGovernmentAuthorityAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsGovernmentAuthorityAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsGovernmentAuthorityAddressFromRaw
    : IFromRawJson<EntityUpdateParamsGovernmentAuthorityAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsGovernmentAuthorityAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsGovernmentAuthorityAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the natural person entity to update. If you specify this parameter
/// and the entity is not a natural person, the request will fail.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsNaturalPerson,
        EntityUpdateParamsNaturalPersonFromRaw
    >)
)]
public sealed record class EntityUpdateParamsNaturalPerson : JsonModel
{
    /// <summary>
    /// The entity's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public EntityUpdateParamsNaturalPersonAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsNaturalPersonAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
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

    /// <summary>
    /// A means of verifying the person's identity.
    /// </summary>
    public EntityUpdateParamsNaturalPersonIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsNaturalPersonIdentification>(
                "identification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identification", value);
        }
    }

    /// <summary>
    /// The legal name of the natural person.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        _ = this.ConfirmedNoUsTaxID;
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityUpdateParamsNaturalPerson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsNaturalPerson(
        EntityUpdateParamsNaturalPerson entityUpdateParamsNaturalPerson
    )
        : base(entityUpdateParamsNaturalPerson) { }
#pragma warning restore CS8618

    public EntityUpdateParamsNaturalPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsNaturalPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsNaturalPersonFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsNaturalPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsNaturalPersonFromRaw : IFromRawJson<EntityUpdateParamsNaturalPerson>
{
    /// <inheritdoc/>
    public EntityUpdateParamsNaturalPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsNaturalPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// The entity's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsNaturalPersonAddress,
        EntityUpdateParamsNaturalPersonAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsNaturalPersonAddress : JsonModel
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
    ///
    /// <para>Defaults to `US`.</para>
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

    public EntityUpdateParamsNaturalPersonAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsNaturalPersonAddress(
        EntityUpdateParamsNaturalPersonAddress entityUpdateParamsNaturalPersonAddress
    )
        : base(entityUpdateParamsNaturalPersonAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsNaturalPersonAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsNaturalPersonAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsNaturalPersonAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsNaturalPersonAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsNaturalPersonAddressFromRaw
    : IFromRawJson<EntityUpdateParamsNaturalPersonAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsNaturalPersonAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsNaturalPersonAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsNaturalPersonIdentification,
        EntityUpdateParamsNaturalPersonIdentificationFromRaw
    >)
)]
public sealed record class EntityUpdateParamsNaturalPersonIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    ///
    /// <para>Defaults to `social_security_number`.</para>
    /// </summary>
    public required ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number. For Social Security Numbers and Individual
    /// Taxpayer Identification Numbers, submit nine digits with no dashes or other separators.
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
    public EntityUpdateParamsNaturalPersonIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsNaturalPersonIdentificationDriversLicense>(
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
    public EntityUpdateParamsNaturalPersonIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsNaturalPersonIdentificationOther>(
                "other"
            );
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
    public EntityUpdateParamsNaturalPersonIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsNaturalPersonIdentificationPassport>(
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

    public EntityUpdateParamsNaturalPersonIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsNaturalPersonIdentification(
        EntityUpdateParamsNaturalPersonIdentification entityUpdateParamsNaturalPersonIdentification
    )
        : base(entityUpdateParamsNaturalPersonIdentification) { }
#pragma warning restore CS8618

    public EntityUpdateParamsNaturalPersonIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsNaturalPersonIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsNaturalPersonIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsNaturalPersonIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsNaturalPersonIdentificationFromRaw
    : IFromRawJson<EntityUpdateParamsNaturalPersonIdentification>
{
    /// <inheritdoc/>
    public EntityUpdateParamsNaturalPersonIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsNaturalPersonIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsNaturalPersonIdentificationMethodConverter))]
public enum EntityUpdateParamsNaturalPersonIdentificationMethod
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

sealed class EntityUpdateParamsNaturalPersonIdentificationMethodConverter
    : JsonConverter<EntityUpdateParamsNaturalPersonIdentificationMethod>
{
    public override EntityUpdateParamsNaturalPersonIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityUpdateParamsNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityUpdateParamsNaturalPersonIdentificationMethod.Passport,
            "drivers_license" => EntityUpdateParamsNaturalPersonIdentificationMethod.DriversLicense,
            "other" => EntityUpdateParamsNaturalPersonIdentificationMethod.Other,
            _ => (EntityUpdateParamsNaturalPersonIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsNaturalPersonIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityUpdateParamsNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityUpdateParamsNaturalPersonIdentificationMethod.Passport => "passport",
                EntityUpdateParamsNaturalPersonIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityUpdateParamsNaturalPersonIdentificationMethod.Other => "other",
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
        EntityUpdateParamsNaturalPersonIdentificationDriversLicense,
        EntityUpdateParamsNaturalPersonIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class EntityUpdateParamsNaturalPersonIdentificationDriversLicense : JsonModel
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

    public EntityUpdateParamsNaturalPersonIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsNaturalPersonIdentificationDriversLicense(
        EntityUpdateParamsNaturalPersonIdentificationDriversLicense entityUpdateParamsNaturalPersonIdentificationDriversLicense
    )
        : base(entityUpdateParamsNaturalPersonIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public EntityUpdateParamsNaturalPersonIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsNaturalPersonIdentificationDriversLicense(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsNaturalPersonIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsNaturalPersonIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsNaturalPersonIdentificationDriversLicenseFromRaw
    : IFromRawJson<EntityUpdateParamsNaturalPersonIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public EntityUpdateParamsNaturalPersonIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsNaturalPersonIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsNaturalPersonIdentificationOther,
        EntityUpdateParamsNaturalPersonIdentificationOtherFromRaw
    >)
)]
public sealed record class EntityUpdateParamsNaturalPersonIdentificationOther : JsonModel
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

    public EntityUpdateParamsNaturalPersonIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsNaturalPersonIdentificationOther(
        EntityUpdateParamsNaturalPersonIdentificationOther entityUpdateParamsNaturalPersonIdentificationOther
    )
        : base(entityUpdateParamsNaturalPersonIdentificationOther) { }
#pragma warning restore CS8618

    public EntityUpdateParamsNaturalPersonIdentificationOther(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsNaturalPersonIdentificationOther(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsNaturalPersonIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsNaturalPersonIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsNaturalPersonIdentificationOtherFromRaw
    : IFromRawJson<EntityUpdateParamsNaturalPersonIdentificationOther>
{
    /// <inheritdoc/>
    public EntityUpdateParamsNaturalPersonIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsNaturalPersonIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsNaturalPersonIdentificationPassport,
        EntityUpdateParamsNaturalPersonIdentificationPassportFromRaw
    >)
)]
public sealed record class EntityUpdateParamsNaturalPersonIdentificationPassport : JsonModel
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

    public EntityUpdateParamsNaturalPersonIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsNaturalPersonIdentificationPassport(
        EntityUpdateParamsNaturalPersonIdentificationPassport entityUpdateParamsNaturalPersonIdentificationPassport
    )
        : base(entityUpdateParamsNaturalPersonIdentificationPassport) { }
#pragma warning restore CS8618

    public EntityUpdateParamsNaturalPersonIdentificationPassport(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsNaturalPersonIdentificationPassport(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsNaturalPersonIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsNaturalPersonIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsNaturalPersonIdentificationPassportFromRaw
    : IFromRawJson<EntityUpdateParamsNaturalPersonIdentificationPassport>
{
    /// <inheritdoc/>
    public EntityUpdateParamsNaturalPersonIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsNaturalPersonIdentificationPassport.FromRawUnchecked(rawData);
}

/// <summary>
/// An assessment of the entity’s potential risk of involvement in financial crimes,
/// such as money laundering.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityUpdateParamsRiskRating, EntityUpdateParamsRiskRatingFromRaw>)
)]
public sealed record class EntityUpdateParamsRiskRating : JsonModel
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
    public required ApiEnum<string, EntityUpdateParamsRiskRatingRating> Rating
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityUpdateParamsRiskRatingRating>
            >("rating");
        }
        init { this._rawData.Set("rating", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RatedAt;
        this.Rating.Validate();
    }

    public EntityUpdateParamsRiskRating() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsRiskRating(EntityUpdateParamsRiskRating entityUpdateParamsRiskRating)
        : base(entityUpdateParamsRiskRating) { }
#pragma warning restore CS8618

    public EntityUpdateParamsRiskRating(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsRiskRating(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsRiskRatingFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsRiskRating FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsRiskRatingFromRaw : IFromRawJson<EntityUpdateParamsRiskRating>
{
    /// <inheritdoc/>
    public EntityUpdateParamsRiskRating FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsRiskRating.FromRawUnchecked(rawData);
}

/// <summary>
/// The rating given to this entity.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsRiskRatingRatingConverter))]
public enum EntityUpdateParamsRiskRatingRating
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

sealed class EntityUpdateParamsRiskRatingRatingConverter
    : JsonConverter<EntityUpdateParamsRiskRatingRating>
{
    public override EntityUpdateParamsRiskRatingRating Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => EntityUpdateParamsRiskRatingRating.Low,
            "medium" => EntityUpdateParamsRiskRatingRating.Medium,
            "high" => EntityUpdateParamsRiskRatingRating.High,
            _ => (EntityUpdateParamsRiskRatingRating)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsRiskRatingRating value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsRiskRatingRating.Low => "low",
                EntityUpdateParamsRiskRatingRating.Medium => "medium",
                EntityUpdateParamsRiskRatingRating.High => "high",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the sole proprietorship entity to update. If you specify this parameter
/// and the entity is not a sole proprietorship, the request will fail.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorship,
        EntityUpdateParamsSoleProprietorshipFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorship : JsonModel
{
    /// <summary>
    /// The sole proprietorship's business address. Mail receiving locations like
    /// PO Boxes and PMB's are disallowed.
    /// </summary>
    public EntityUpdateParamsSoleProprietorshipAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// An email address for the sole proprietorship. Not every program requires an
    /// email for submitted Entities.
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
    /// Details of the individual who operates the sole proprietorship.
    /// </summary>
    public EntityUpdateParamsSoleProprietorshipSoleProprietor? SoleProprietor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipSoleProprietor>(
                "sole_proprietor"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sole_proprietor", value);
        }
    }

    /// <summary>
    /// The United States Employer Identification Number (EIN) for the sole proprietorship.
    /// Submit nine digits with no dashes or other separators.
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

    /// <summary>
    /// A website for the sole proprietorship. Not every program requires a website
    /// for submitted Entities.
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
        this.Address?.Validate();
        _ = this.Email;
        this.SoleProprietor?.Validate();
        _ = this.TaxIdentifier;
        _ = this.Website;
    }

    public EntityUpdateParamsSoleProprietorship() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorship(
        EntityUpdateParamsSoleProprietorship entityUpdateParamsSoleProprietorship
    )
        : base(entityUpdateParamsSoleProprietorship) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorship(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorship(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorship>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsSoleProprietorship.FromRawUnchecked(rawData);
}

/// <summary>
/// The sole proprietorship's business address. Mail receiving locations like PO
/// Boxes and PMB's are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorshipAddress,
        EntityUpdateParamsSoleProprietorshipAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipAddress : JsonModel
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

    public EntityUpdateParamsSoleProprietorshipAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipAddress(
        EntityUpdateParamsSoleProprietorshipAddress entityUpdateParamsSoleProprietorshipAddress
    )
        : base(entityUpdateParamsSoleProprietorshipAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipAddressFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsSoleProprietorshipAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Details of the individual who operates the sole proprietorship.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorshipSoleProprietor,
        EntityUpdateParamsSoleProprietorshipSoleProprietorFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipSoleProprietor : JsonModel
{
    /// <summary>
    /// The sole proprietor's physical address. Mail receiving locations like PO
    /// Boxes and PMB's are disallowed.
    /// </summary>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipSoleProprietorAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// A means of verifying the sole proprietor's identity. Unlike at creation, an
    /// identity document is accepted here.
    /// </summary>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification? Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification>(
                "identification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identification", value);
        }
    }

    /// <summary>
    /// The sole proprietor's legal name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        this.Identification?.Validate();
        _ = this.Name;
    }

    public EntityUpdateParamsSoleProprietorshipSoleProprietor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipSoleProprietor(
        EntityUpdateParamsSoleProprietorshipSoleProprietor entityUpdateParamsSoleProprietorshipSoleProprietor
    )
        : base(entityUpdateParamsSoleProprietorshipSoleProprietor) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipSoleProprietor(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipSoleProprietor(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipSoleProprietorFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipSoleProprietor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipSoleProprietorFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipSoleProprietor>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipSoleProprietor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsSoleProprietorshipSoleProprietor.FromRawUnchecked(rawData);
}

/// <summary>
/// The sole proprietor's physical address. Mail receiving locations like PO Boxes
/// and PMB's are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorshipSoleProprietorAddress,
        EntityUpdateParamsSoleProprietorshipSoleProprietorAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipSoleProprietorAddress : JsonModel
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
    ///
    /// <para>Defaults to `US`.</para>
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

    public EntityUpdateParamsSoleProprietorshipSoleProprietorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipSoleProprietorAddress(
        EntityUpdateParamsSoleProprietorshipSoleProprietorAddress entityUpdateParamsSoleProprietorshipSoleProprietorAddress
    )
        : base(entityUpdateParamsSoleProprietorshipSoleProprietorAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipSoleProprietorAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipSoleProprietorAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipSoleProprietorAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipSoleProprietorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipSoleProprietorAddressFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipSoleProprietorAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsSoleProprietorshipSoleProprietorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the sole proprietor's identity. Unlike at creation, an identity
/// document is accepted here.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification,
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification
    : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    ///
    /// <para>Defaults to `social_security_number`.</para>
    /// </summary>
    public required ApiEnum<
        string,
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod
    > Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod
                >
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number. For Social Security Numbers and Individual
    /// Taxpayer Identification Numbers, submit nine digits with no dashes or other separators.
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
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense>(
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
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther>(
                "other"
            );
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
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport>(
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

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification(
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification entityUpdateParamsSoleProprietorshipSoleProprietorIdentification
    )
        : base(entityUpdateParamsSoleProprietorshipSoleProprietorIdentification) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsSoleProprietorshipSoleProprietorIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(
    typeof(EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethodConverter)
)]
public enum EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod
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

sealed class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethodConverter
    : JsonConverter<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod>
{
    public override EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" =>
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.Passport,
            "drivers_license" =>
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.DriversLicense,
            "other" => EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.Other,
            _ => (EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.Passport =>
                    "passport",
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationMethod.Other =>
                    "other",
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
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense,
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense
    : JsonModel
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

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense(
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense entityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense
    )
        : base(entityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicenseFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationDriversLicense.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther,
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOtherFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther
    : JsonModel
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

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther(
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther entityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther
    )
        : base(entityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOtherFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationOther.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport,
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassportFromRaw
    >)
)]
public sealed record class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport
    : JsonModel
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

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport(
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport entityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport
    )
        : base(entityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport) { }
#pragma warning restore CS8618

    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassportFromRaw
    : IFromRawJson<EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport>
{
    /// <inheritdoc/>
    public EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntityUpdateParamsSoleProprietorshipSoleProprietorIdentificationPassport.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTermsAgreement,
        EntityUpdateParamsTermsAgreementFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTermsAgreement : JsonModel
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
    /// The IP address the Entity reviewed the terms from.
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

    public EntityUpdateParamsTermsAgreement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTermsAgreement(
        EntityUpdateParamsTermsAgreement entityUpdateParamsTermsAgreement
    )
        : base(entityUpdateParamsTermsAgreement) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTermsAgreement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTermsAgreement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTermsAgreementFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTermsAgreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTermsAgreementFromRaw : IFromRawJson<EntityUpdateParamsTermsAgreement>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTermsAgreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTermsAgreement.FromRawUnchecked(rawData);
}

/// <summary>
/// If you are using a third-party service for identity verification, you can use
/// this field to associate this Entity with the identifier that represents them in
/// that service.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsThirdPartyVerification,
        EntityUpdateParamsThirdPartyVerificationFromRaw
    >)
)]
public sealed record class EntityUpdateParamsThirdPartyVerification : JsonModel
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
    public required ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor> Vendor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor>
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

    public EntityUpdateParamsThirdPartyVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsThirdPartyVerification(
        EntityUpdateParamsThirdPartyVerification entityUpdateParamsThirdPartyVerification
    )
        : base(entityUpdateParamsThirdPartyVerification) { }
#pragma warning restore CS8618

    public EntityUpdateParamsThirdPartyVerification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsThirdPartyVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsThirdPartyVerificationFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsThirdPartyVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsThirdPartyVerificationFromRaw
    : IFromRawJson<EntityUpdateParamsThirdPartyVerification>
{
    /// <inheritdoc/>
    public EntityUpdateParamsThirdPartyVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsThirdPartyVerification.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor that was used to perform the verification.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsThirdPartyVerificationVendorConverter))]
public enum EntityUpdateParamsThirdPartyVerificationVendor
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

sealed class EntityUpdateParamsThirdPartyVerificationVendorConverter
    : JsonConverter<EntityUpdateParamsThirdPartyVerificationVendor>
{
    public override EntityUpdateParamsThirdPartyVerificationVendor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "alloy" => EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
            "middesk" => EntityUpdateParamsThirdPartyVerificationVendor.Middesk,
            "oscilar" => EntityUpdateParamsThirdPartyVerificationVendor.Oscilar,
            "persona" => EntityUpdateParamsThirdPartyVerificationVendor.Persona,
            "taktile" => EntityUpdateParamsThirdPartyVerificationVendor.Taktile,
            _ => (EntityUpdateParamsThirdPartyVerificationVendor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsThirdPartyVerificationVendor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsThirdPartyVerificationVendor.Alloy => "alloy",
                EntityUpdateParamsThirdPartyVerificationVendor.Middesk => "middesk",
                EntityUpdateParamsThirdPartyVerificationVendor.Oscilar => "oscilar",
                EntityUpdateParamsThirdPartyVerificationVendor.Persona => "persona",
                EntityUpdateParamsThirdPartyVerificationVendor.Taktile => "taktile",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details of the trust entity to update. If you specify this parameter and the
/// entity is not a trust, the request will fail.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityUpdateParamsTrust, EntityUpdateParamsTrustFromRaw>))]
public sealed record class EntityUpdateParamsTrust : JsonModel
{
    /// <summary>
    /// The entity's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public EntityUpdateParamsTrustAddress? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustAddress>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// The grantor of the trust. If you specify this parameter, the trust's existing
    /// grantor will be archived and replaced with the grantor you provide.
    /// </summary>
    public EntityUpdateParamsTrustGrantor? Grantor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustGrantor>("grantor");
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
    /// The legal name of the trust.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The trustees of the trust. If you specify this parameter, the trust's existing
    /// trustees will be archived and replaced with the trustees you provide.
    /// </summary>
    public IReadOnlyList<EntityUpdateParamsTrustTrustee>? Trustees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EntityUpdateParamsTrustTrustee>>(
                "trustees"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EntityUpdateParamsTrustTrustee>?>(
                "trustees",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        this.Grantor?.Validate();
        _ = this.Name;
        foreach (var item in this.Trustees ?? [])
        {
            item.Validate();
        }
    }

    public EntityUpdateParamsTrust() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrust(EntityUpdateParamsTrust entityUpdateParamsTrust)
        : base(entityUpdateParamsTrust) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrust(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrust(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrust FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustFromRaw : IFromRawJson<EntityUpdateParamsTrust>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrust FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrust.FromRawUnchecked(rawData);
}

/// <summary>
/// The entity's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustAddress,
        EntityUpdateParamsTrustAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustAddress : JsonModel
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

    public EntityUpdateParamsTrustAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustAddress(
        EntityUpdateParamsTrustAddress entityUpdateParamsTrustAddress
    )
        : base(entityUpdateParamsTrustAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustAddressFromRaw : IFromRawJson<EntityUpdateParamsTrustAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The grantor of the trust. If you specify this parameter, the trust's existing
/// grantor will be archived and replaced with the grantor you provide.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustGrantor,
        EntityUpdateParamsTrustGrantorFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustGrantor : JsonModel
{
    /// <summary>
    /// The grantor's physical address. Mail receiving locations like PO Boxes and
    /// PMB's are disallowed.
    /// </summary>
    public required EntityUpdateParamsTrustGrantorAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityUpdateParamsTrustGrantorAddress>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// The grantor's date of birth in YYYY-MM-DD format.
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
    public required EntityUpdateParamsTrustGrantorIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityUpdateParamsTrustGrantorIdentification>(
                "identification"
            );
        }
        init { this._rawData.Set("identification", value); }
    }

    /// <summary>
    /// The grantor's legal name.
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

    public EntityUpdateParamsTrustGrantor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustGrantor(
        EntityUpdateParamsTrustGrantor entityUpdateParamsTrustGrantor
    )
        : base(entityUpdateParamsTrustGrantor) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustGrantor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustGrantor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustGrantorFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustGrantor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustGrantorFromRaw : IFromRawJson<EntityUpdateParamsTrustGrantor>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustGrantor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustGrantor.FromRawUnchecked(rawData);
}

/// <summary>
/// The grantor's physical address. Mail receiving locations like PO Boxes and PMB's
/// are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustGrantorAddress,
        EntityUpdateParamsTrustGrantorAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustGrantorAddress : JsonModel
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
    ///
    /// <para>Defaults to `US`.</para>
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

    public EntityUpdateParamsTrustGrantorAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustGrantorAddress(
        EntityUpdateParamsTrustGrantorAddress entityUpdateParamsTrustGrantorAddress
    )
        : base(entityUpdateParamsTrustGrantorAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustGrantorAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustGrantorAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustGrantorAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustGrantorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustGrantorAddressFromRaw
    : IFromRawJson<EntityUpdateParamsTrustGrantorAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustGrantorAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustGrantorAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustGrantorIdentification,
        EntityUpdateParamsTrustGrantorIdentificationFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustGrantorIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    ///
    /// <para>Defaults to `social_security_number`.</para>
    /// </summary>
    public required ApiEnum<string, EntityUpdateParamsTrustGrantorIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityUpdateParamsTrustGrantorIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number. For Social Security Numbers and Individual
    /// Taxpayer Identification Numbers, submit nine digits with no dashes or other separators.
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
    public EntityUpdateParamsTrustGrantorIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustGrantorIdentificationDriversLicense>(
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
    public EntityUpdateParamsTrustGrantorIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustGrantorIdentificationOther>(
                "other"
            );
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
    public EntityUpdateParamsTrustGrantorIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustGrantorIdentificationPassport>(
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

    public EntityUpdateParamsTrustGrantorIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustGrantorIdentification(
        EntityUpdateParamsTrustGrantorIdentification entityUpdateParamsTrustGrantorIdentification
    )
        : base(entityUpdateParamsTrustGrantorIdentification) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustGrantorIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustGrantorIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustGrantorIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustGrantorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustGrantorIdentificationFromRaw
    : IFromRawJson<EntityUpdateParamsTrustGrantorIdentification>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustGrantorIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustGrantorIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsTrustGrantorIdentificationMethodConverter))]
public enum EntityUpdateParamsTrustGrantorIdentificationMethod
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

sealed class EntityUpdateParamsTrustGrantorIdentificationMethodConverter
    : JsonConverter<EntityUpdateParamsTrustGrantorIdentificationMethod>
{
    public override EntityUpdateParamsTrustGrantorIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityUpdateParamsTrustGrantorIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityUpdateParamsTrustGrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityUpdateParamsTrustGrantorIdentificationMethod.Passport,
            "drivers_license" => EntityUpdateParamsTrustGrantorIdentificationMethod.DriversLicense,
            "other" => EntityUpdateParamsTrustGrantorIdentificationMethod.Other,
            _ => (EntityUpdateParamsTrustGrantorIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsTrustGrantorIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsTrustGrantorIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityUpdateParamsTrustGrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityUpdateParamsTrustGrantorIdentificationMethod.Passport => "passport",
                EntityUpdateParamsTrustGrantorIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityUpdateParamsTrustGrantorIdentificationMethod.Other => "other",
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
        EntityUpdateParamsTrustGrantorIdentificationDriversLicense,
        EntityUpdateParamsTrustGrantorIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustGrantorIdentificationDriversLicense : JsonModel
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

    public EntityUpdateParamsTrustGrantorIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustGrantorIdentificationDriversLicense(
        EntityUpdateParamsTrustGrantorIdentificationDriversLicense entityUpdateParamsTrustGrantorIdentificationDriversLicense
    )
        : base(entityUpdateParamsTrustGrantorIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustGrantorIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustGrantorIdentificationDriversLicense(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustGrantorIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustGrantorIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustGrantorIdentificationDriversLicenseFromRaw
    : IFromRawJson<EntityUpdateParamsTrustGrantorIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustGrantorIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustGrantorIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustGrantorIdentificationOther,
        EntityUpdateParamsTrustGrantorIdentificationOtherFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustGrantorIdentificationOther : JsonModel
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

    public EntityUpdateParamsTrustGrantorIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustGrantorIdentificationOther(
        EntityUpdateParamsTrustGrantorIdentificationOther entityUpdateParamsTrustGrantorIdentificationOther
    )
        : base(entityUpdateParamsTrustGrantorIdentificationOther) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustGrantorIdentificationOther(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustGrantorIdentificationOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustGrantorIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustGrantorIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustGrantorIdentificationOtherFromRaw
    : IFromRawJson<EntityUpdateParamsTrustGrantorIdentificationOther>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustGrantorIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustGrantorIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustGrantorIdentificationPassport,
        EntityUpdateParamsTrustGrantorIdentificationPassportFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustGrantorIdentificationPassport : JsonModel
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

    public EntityUpdateParamsTrustGrantorIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustGrantorIdentificationPassport(
        EntityUpdateParamsTrustGrantorIdentificationPassport entityUpdateParamsTrustGrantorIdentificationPassport
    )
        : base(entityUpdateParamsTrustGrantorIdentificationPassport) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustGrantorIdentificationPassport(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustGrantorIdentificationPassport(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustGrantorIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustGrantorIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustGrantorIdentificationPassportFromRaw
    : IFromRawJson<EntityUpdateParamsTrustGrantorIdentificationPassport>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustGrantorIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustGrantorIdentificationPassport.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustTrustee,
        EntityUpdateParamsTrustTrusteeFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrustee : JsonModel
{
    /// <summary>
    /// The structure of the trustee.
    /// </summary>
    public required ApiEnum<string, EntityUpdateParamsTrustTrusteeStructure> Structure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityUpdateParamsTrustTrusteeStructure>
            >("structure");
        }
        init { this._rawData.Set("structure", value); }
    }

    /// <summary>
    /// Details of the individual trustee. Within the trustee object, this is required
    /// if `structure` is equal to `individual`.
    /// </summary>
    public EntityUpdateParamsTrustTrusteeIndividual? Individual
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustTrusteeIndividual>(
                "individual"
            );
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

    public EntityUpdateParamsTrustTrustee() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrustee(
        EntityUpdateParamsTrustTrustee entityUpdateParamsTrustTrustee
    )
        : base(entityUpdateParamsTrustTrustee) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrustee(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrustee(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrustee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrustee(
        ApiEnum<string, EntityUpdateParamsTrustTrusteeStructure> structure
    )
        : this()
    {
        this.Structure = structure;
    }
}

class EntityUpdateParamsTrustTrusteeFromRaw : IFromRawJson<EntityUpdateParamsTrustTrustee>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrustee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustTrustee.FromRawUnchecked(rawData);
}

/// <summary>
/// The structure of the trustee.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsTrustTrusteeStructureConverter))]
public enum EntityUpdateParamsTrustTrusteeStructure
{
    /// <summary>
    /// The trustee is an individual.
    /// </summary>
    Individual,
}

sealed class EntityUpdateParamsTrustTrusteeStructureConverter
    : JsonConverter<EntityUpdateParamsTrustTrusteeStructure>
{
    public override EntityUpdateParamsTrustTrusteeStructure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => EntityUpdateParamsTrustTrusteeStructure.Individual,
            _ => (EntityUpdateParamsTrustTrusteeStructure)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsTrustTrusteeStructure value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsTrustTrusteeStructure.Individual => "individual",
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
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustTrusteeIndividual,
        EntityUpdateParamsTrustTrusteeIndividualFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrusteeIndividual : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public required EntityUpdateParamsTrustTrusteeIndividualAddress Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityUpdateParamsTrustTrusteeIndividualAddress>(
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
    public required EntityUpdateParamsTrustTrusteeIndividualIdentification Identification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityUpdateParamsTrustTrusteeIndividualIdentification>(
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

    public EntityUpdateParamsTrustTrusteeIndividual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrusteeIndividual(
        EntityUpdateParamsTrustTrusteeIndividual entityUpdateParamsTrustTrusteeIndividual
    )
        : base(entityUpdateParamsTrustTrusteeIndividual) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrusteeIndividual(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrusteeIndividual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeIndividualFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrusteeIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustTrusteeIndividualFromRaw
    : IFromRawJson<EntityUpdateParamsTrustTrusteeIndividual>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrusteeIndividual FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustTrusteeIndividual.FromRawUnchecked(rawData);
}

/// <summary>
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustTrusteeIndividualAddress,
        EntityUpdateParamsTrustTrusteeIndividualAddressFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrusteeIndividualAddress : JsonModel
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
    ///
    /// <para>Defaults to `US`.</para>
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

    public EntityUpdateParamsTrustTrusteeIndividualAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrusteeIndividualAddress(
        EntityUpdateParamsTrustTrusteeIndividualAddress entityUpdateParamsTrustTrusteeIndividualAddress
    )
        : base(entityUpdateParamsTrustTrusteeIndividualAddress) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrusteeIndividualAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrusteeIndividualAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeIndividualAddressFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrusteeIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustTrusteeIndividualAddressFromRaw
    : IFromRawJson<EntityUpdateParamsTrustTrusteeIndividualAddress>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrusteeIndividualAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustTrusteeIndividualAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustTrusteeIndividualIdentification,
        EntityUpdateParamsTrustTrusteeIndividualIdentificationFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrusteeIndividualIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    ///
    /// <para>Defaults to `social_security_number`.</para>
    /// </summary>
    public required ApiEnum<
        string,
        EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod
    > Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// An identification number that can be used to verify the individual's identity,
    /// such as a social security number. For Social Security Numbers and Individual
    /// Taxpayer Identification Numbers, submit nine digits with no dashes or other separators.
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
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense>(
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
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustTrusteeIndividualIdentificationOther>(
                "other"
            );
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
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport>(
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

    public EntityUpdateParamsTrustTrusteeIndividualIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrusteeIndividualIdentification(
        EntityUpdateParamsTrustTrusteeIndividualIdentification entityUpdateParamsTrustTrusteeIndividualIdentification
    )
        : base(entityUpdateParamsTrustTrusteeIndividualIdentification) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrusteeIndividualIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrusteeIndividualIdentification(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeIndividualIdentificationFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrusteeIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustTrusteeIndividualIdentificationFromRaw
    : IFromRawJson<EntityUpdateParamsTrustTrusteeIndividualIdentification>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrusteeIndividualIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustTrusteeIndividualIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(EntityUpdateParamsTrustTrusteeIndividualIdentificationMethodConverter))]
public enum EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod
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

sealed class EntityUpdateParamsTrustTrusteeIndividualIdentificationMethodConverter
    : JsonConverter<EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod>
{
    public override EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.Passport,
            "drivers_license" =>
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.DriversLicense,
            "other" => EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.Other,
            _ => (EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.Passport => "passport",
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.DriversLicense =>
                    "drivers_license",
                EntityUpdateParamsTrustTrusteeIndividualIdentificationMethod.Other => "other",
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
        EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense,
        EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense
    : JsonModel
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

    public EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense(
        EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense entityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense
    )
        : base(entityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicenseFromRaw
    : IFromRawJson<EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntityUpdateParamsTrustTrusteeIndividualIdentificationDriversLicense.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustTrusteeIndividualIdentificationOther,
        EntityUpdateParamsTrustTrusteeIndividualIdentificationOtherFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrusteeIndividualIdentificationOther : JsonModel
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

    public EntityUpdateParamsTrustTrusteeIndividualIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationOther(
        EntityUpdateParamsTrustTrusteeIndividualIdentificationOther entityUpdateParamsTrustTrusteeIndividualIdentificationOther
    )
        : base(entityUpdateParamsTrustTrusteeIndividualIdentificationOther) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrusteeIndividualIdentificationOther(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrusteeIndividualIdentificationOther(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeIndividualIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrusteeIndividualIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustTrusteeIndividualIdentificationOtherFromRaw
    : IFromRawJson<EntityUpdateParamsTrustTrusteeIndividualIdentificationOther>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustTrusteeIndividualIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport,
        EntityUpdateParamsTrustTrusteeIndividualIdentificationPassportFromRaw
    >)
)]
public sealed record class EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport
    : JsonModel
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

    public EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport(
        EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport entityUpdateParamsTrustTrusteeIndividualIdentificationPassport
    )
        : base(entityUpdateParamsTrustTrusteeIndividualIdentificationPassport) { }
#pragma warning restore CS8618

    public EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpdateParamsTrustTrusteeIndividualIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpdateParamsTrustTrusteeIndividualIdentificationPassportFromRaw
    : IFromRawJson<EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport>
{
    /// <inheritdoc/>
    public EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpdateParamsTrustTrusteeIndividualIdentificationPassport.FromRawUnchecked(rawData);
}
