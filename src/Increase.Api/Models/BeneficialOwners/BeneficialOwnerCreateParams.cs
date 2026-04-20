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

namespace Increase.Api.Models.BeneficialOwners;

/// <summary>
/// Create a Beneficial Owner
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BeneficialOwnerCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Entity to associate with the new Beneficial Owner.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("entity_id");
        }
        init { this._rawBodyData.Set("entity_id", value); }
    }

    /// <summary>
    /// Personal details for the beneficial owner.
    /// </summary>
    public required Individual Individual
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Individual>("individual");
        }
        init { this._rawBodyData.Set("individual", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Prong>>>(
                "prongs"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, Prong>>>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("company_title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("company_title", value);
        }
    }

    public BeneficialOwnerCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerCreateParams(BeneficialOwnerCreateParams beneficialOwnerCreateParams)
        : base(beneficialOwnerCreateParams)
    {
        this._rawBodyData = new(beneficialOwnerCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BeneficialOwnerCreateParams(
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
    BeneficialOwnerCreateParams(
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
    public static BeneficialOwnerCreateParams FromRawUnchecked(
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

    public virtual bool Equals(BeneficialOwnerCreateParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/entity_beneficial_owners"
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
/// Personal details for the beneficial owner.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Individual, IndividualFromRaw>))]
public sealed record class Individual : JsonModel
{
    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
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
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
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
