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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        _ = this.Email;
        _ = this.IncorporationState;
        _ = this.IndustryCode;
        this.LegalIdentifier?.Validate();
        _ = this.Name;
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
    /// The identifier of the legal identifier. For US Employer Identification Numbers,
    /// submit nine digits with no dashes or other separators.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        _ = this.Name;
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
