using System.Collections.Frozen;
using System.Collections.Generic;
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
    /// The Employer Identification Number (EIN) for the corporation.
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
        this.Address?.Validate();
        _ = this.Email;
        _ = this.IncorporationState;
        _ = this.IndustryCode;
        _ = this.Name;
        _ = this.TaxIdentifier;
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
