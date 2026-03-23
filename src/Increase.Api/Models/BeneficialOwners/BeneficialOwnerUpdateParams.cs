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

namespace Increase.Api.Models.BeneficialOwners;

/// <summary>
/// Update a Beneficial Owner
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BeneficialOwnerUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EntityBeneficialOwnerID { get; init; }

    /// <summary>
    /// The individual's physical address. Mail receiving locations like PO Boxes
    /// and PMB's are disallowed.
    /// </summary>
    public BeneficialOwnerUpdateParamsAddress? Address
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BeneficialOwnerUpdateParamsAddress>(
                "address"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("address", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("confirmed_no_us_tax_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("confirmed_no_us_tax_id", value);
        }
    }

    /// <summary>
    /// A means of verifying the person's identity.
    /// </summary>
    public BeneficialOwnerUpdateParamsIdentification? Identification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BeneficialOwnerUpdateParamsIdentification>(
                "identification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("identification", value);
        }
    }

    /// <summary>
    /// The individual's legal name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    public BeneficialOwnerUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerUpdateParams(BeneficialOwnerUpdateParams beneficialOwnerUpdateParams)
        : base(beneficialOwnerUpdateParams)
    {
        this.EntityBeneficialOwnerID = beneficialOwnerUpdateParams.EntityBeneficialOwnerID;

        this._rawBodyData = new(beneficialOwnerUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BeneficialOwnerUpdateParams(
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
    BeneficialOwnerUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string entityBeneficialOwnerID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EntityBeneficialOwnerID = entityBeneficialOwnerID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BeneficialOwnerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string entityBeneficialOwnerID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            entityBeneficialOwnerID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EntityBeneficialOwnerID"] = JsonSerializer.SerializeToElement(
                        this.EntityBeneficialOwnerID
                    ),
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

    public virtual bool Equals(BeneficialOwnerUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.EntityBeneficialOwnerID?.Equals(other.EntityBeneficialOwnerID)
                ?? other.EntityBeneficialOwnerID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/entity_beneficial_owners/{0}", this.EntityBeneficialOwnerID)
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
/// The individual's physical address. Mail receiving locations like PO Boxes and
/// PMB's are disallowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BeneficialOwnerUpdateParamsAddress,
        BeneficialOwnerUpdateParamsAddressFromRaw
    >)
)]
public sealed record class BeneficialOwnerUpdateParamsAddress : JsonModel
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

    public BeneficialOwnerUpdateParamsAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerUpdateParamsAddress(
        BeneficialOwnerUpdateParamsAddress beneficialOwnerUpdateParamsAddress
    )
        : base(beneficialOwnerUpdateParamsAddress) { }
#pragma warning restore CS8618

    public BeneficialOwnerUpdateParamsAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerUpdateParamsAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerUpdateParamsAddressFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerUpdateParamsAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerUpdateParamsAddressFromRaw : IFromRawJson<BeneficialOwnerUpdateParamsAddress>
{
    /// <inheritdoc/>
    public BeneficialOwnerUpdateParamsAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerUpdateParamsAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// A means of verifying the person's identity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BeneficialOwnerUpdateParamsIdentification,
        BeneficialOwnerUpdateParamsIdentificationFromRaw
    >)
)]
public sealed record class BeneficialOwnerUpdateParamsIdentification : JsonModel
{
    /// <summary>
    /// A method that can be used to verify the individual's identity.
    /// </summary>
    public required ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod>
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
    public BeneficialOwnerUpdateParamsIdentificationDriversLicense? DriversLicense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BeneficialOwnerUpdateParamsIdentificationDriversLicense>(
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
    public BeneficialOwnerUpdateParamsIdentificationOther? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BeneficialOwnerUpdateParamsIdentificationOther>(
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
    public BeneficialOwnerUpdateParamsIdentificationPassport? Passport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BeneficialOwnerUpdateParamsIdentificationPassport>(
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

    public BeneficialOwnerUpdateParamsIdentification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerUpdateParamsIdentification(
        BeneficialOwnerUpdateParamsIdentification beneficialOwnerUpdateParamsIdentification
    )
        : base(beneficialOwnerUpdateParamsIdentification) { }
#pragma warning restore CS8618

    public BeneficialOwnerUpdateParamsIdentification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerUpdateParamsIdentification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerUpdateParamsIdentificationFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerUpdateParamsIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerUpdateParamsIdentificationFromRaw
    : IFromRawJson<BeneficialOwnerUpdateParamsIdentification>
{
    /// <inheritdoc/>
    public BeneficialOwnerUpdateParamsIdentification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerUpdateParamsIdentification.FromRawUnchecked(rawData);
}

/// <summary>
/// A method that can be used to verify the individual's identity.
/// </summary>
[JsonConverter(typeof(BeneficialOwnerUpdateParamsIdentificationMethodConverter))]
public enum BeneficialOwnerUpdateParamsIdentificationMethod
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

sealed class BeneficialOwnerUpdateParamsIdentificationMethodConverter
    : JsonConverter<BeneficialOwnerUpdateParamsIdentificationMethod>
{
    public override BeneficialOwnerUpdateParamsIdentificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "social_security_number" =>
                BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
            "individual_taxpayer_identification_number" =>
                BeneficialOwnerUpdateParamsIdentificationMethod.IndividualTaxpayerIdentificationNumber,
            "passport" => BeneficialOwnerUpdateParamsIdentificationMethod.Passport,
            "drivers_license" => BeneficialOwnerUpdateParamsIdentificationMethod.DriversLicense,
            "other" => BeneficialOwnerUpdateParamsIdentificationMethod.Other,
            _ => (BeneficialOwnerUpdateParamsIdentificationMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BeneficialOwnerUpdateParamsIdentificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber =>
                    "social_security_number",
                BeneficialOwnerUpdateParamsIdentificationMethod.IndividualTaxpayerIdentificationNumber =>
                    "individual_taxpayer_identification_number",
                BeneficialOwnerUpdateParamsIdentificationMethod.Passport => "passport",
                BeneficialOwnerUpdateParamsIdentificationMethod.DriversLicense => "drivers_license",
                BeneficialOwnerUpdateParamsIdentificationMethod.Other => "other",
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
        BeneficialOwnerUpdateParamsIdentificationDriversLicense,
        BeneficialOwnerUpdateParamsIdentificationDriversLicenseFromRaw
    >)
)]
public sealed record class BeneficialOwnerUpdateParamsIdentificationDriversLicense : JsonModel
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

    public BeneficialOwnerUpdateParamsIdentificationDriversLicense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerUpdateParamsIdentificationDriversLicense(
        BeneficialOwnerUpdateParamsIdentificationDriversLicense beneficialOwnerUpdateParamsIdentificationDriversLicense
    )
        : base(beneficialOwnerUpdateParamsIdentificationDriversLicense) { }
#pragma warning restore CS8618

    public BeneficialOwnerUpdateParamsIdentificationDriversLicense(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerUpdateParamsIdentificationDriversLicense(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerUpdateParamsIdentificationDriversLicenseFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerUpdateParamsIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerUpdateParamsIdentificationDriversLicenseFromRaw
    : IFromRawJson<BeneficialOwnerUpdateParamsIdentificationDriversLicense>
{
    /// <inheritdoc/>
    public BeneficialOwnerUpdateParamsIdentificationDriversLicense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerUpdateParamsIdentificationDriversLicense.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the identification document provided. Required if `method` is
/// equal to `other`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BeneficialOwnerUpdateParamsIdentificationOther,
        BeneficialOwnerUpdateParamsIdentificationOtherFromRaw
    >)
)]
public sealed record class BeneficialOwnerUpdateParamsIdentificationOther : JsonModel
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

    public BeneficialOwnerUpdateParamsIdentificationOther() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerUpdateParamsIdentificationOther(
        BeneficialOwnerUpdateParamsIdentificationOther beneficialOwnerUpdateParamsIdentificationOther
    )
        : base(beneficialOwnerUpdateParamsIdentificationOther) { }
#pragma warning restore CS8618

    public BeneficialOwnerUpdateParamsIdentificationOther(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerUpdateParamsIdentificationOther(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerUpdateParamsIdentificationOtherFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerUpdateParamsIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerUpdateParamsIdentificationOtherFromRaw
    : IFromRawJson<BeneficialOwnerUpdateParamsIdentificationOther>
{
    /// <inheritdoc/>
    public BeneficialOwnerUpdateParamsIdentificationOther FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerUpdateParamsIdentificationOther.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the passport used for identification. Required if `method`
/// is equal to `passport`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BeneficialOwnerUpdateParamsIdentificationPassport,
        BeneficialOwnerUpdateParamsIdentificationPassportFromRaw
    >)
)]
public sealed record class BeneficialOwnerUpdateParamsIdentificationPassport : JsonModel
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

    public BeneficialOwnerUpdateParamsIdentificationPassport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerUpdateParamsIdentificationPassport(
        BeneficialOwnerUpdateParamsIdentificationPassport beneficialOwnerUpdateParamsIdentificationPassport
    )
        : base(beneficialOwnerUpdateParamsIdentificationPassport) { }
#pragma warning restore CS8618

    public BeneficialOwnerUpdateParamsIdentificationPassport(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerUpdateParamsIdentificationPassport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BeneficialOwnerUpdateParamsIdentificationPassportFromRaw.FromRawUnchecked"/>
    public static BeneficialOwnerUpdateParamsIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BeneficialOwnerUpdateParamsIdentificationPassportFromRaw
    : IFromRawJson<BeneficialOwnerUpdateParamsIdentificationPassport>
{
    /// <inheritdoc/>
    public BeneficialOwnerUpdateParamsIdentificationPassport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BeneficialOwnerUpdateParamsIdentificationPassport.FromRawUnchecked(rawData);
}
