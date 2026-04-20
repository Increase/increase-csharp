using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Entities;

namespace Increase.Api.Tests.Models.Entities;

public class EntityUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityUpdateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = "Unit 2",
                    State = "NY",
                    Zip = "10045",
                },
                Email = "dev@stainless.com",
                IncorporationState = "x",
                IndustryCode = "x",
                LegalIdentifier = new()
                {
                    Value = "x",
                    Category =
                        EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                },
                Name = "x",
            },
            DetailsConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                Name = "x",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "x",
                    Country = "x",
                    Line1 = "x",
                    Line2 = "x",
                    State = "x",
                    Zip = "x",
                },
                ConfirmedNoUsTaxID = true,
                Identification = new()
                {
                    Method =
                        EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    Number = "xxxx",
                    DriversLicense = new()
                    {
                        ExpirationDate = "2019-12-27",
                        FileID = "file_id",
                        State = "x",
                        BackFileID = "back_file_id",
                    },
                    Other = new()
                    {
                        Country = "x",
                        Description = "x",
                        FileID = "file_id",
                        BackFileID = "back_file_id",
                        ExpirationDate = "2019-12-27",
                    },
                    Passport = new()
                    {
                        Country = "x",
                        ExpirationDate = "2019-12-27",
                        FileID = "file_id",
                    },
                },
                Name = "x",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Rating = EntityUpdateParamsRiskRatingRating.Low,
            },
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IPAddress = "x",
                    TermsUrl = "x",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "x",
                Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                Name = "x",
            },
        };

        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        EntityUpdateParamsCorporation expectedCorporation = new()
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "Unit 2",
                State = "NY",
                Zip = "10045",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            LegalIdentifier = new()
            {
                Value = "x",
                Category =
                    EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            },
            Name = "x",
        };
        DateTimeOffset expectedDetailsConfirmedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        EntityUpdateParamsGovernmentAuthority expectedGovernmentAuthority = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };
        EntityUpdateParamsNaturalPerson expectedNaturalPerson = new()
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                Number = "xxxx",
                DriversLicense = new()
                {
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                    State = "x",
                    BackFileID = "back_file_id",
                },
                Other = new()
                {
                    Country = "x",
                    Description = "x",
                    FileID = "file_id",
                    BackFileID = "back_file_id",
                    ExpirationDate = "2019-12-27",
                },
                Passport = new()
                {
                    Country = "x",
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                },
            },
            Name = "x",
        };
        EntityUpdateParamsRiskRating expectedRiskRating = new()
        {
            RatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };
        List<EntityUpdateParamsTermsAgreement> expectedTermsAgreements =
        [
            new()
            {
                AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IPAddress = "x",
                TermsUrl = "x",
            },
        ];
        EntityUpdateParamsThirdPartyVerification expectedThirdPartyVerification = new()
        {
            Reference = "x",
            Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
        };
        EntityUpdateParamsTrust expectedTrust = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedCorporation, parameters.Corporation);
        Assert.Equal(expectedDetailsConfirmedAt, parameters.DetailsConfirmedAt);
        Assert.Equal(expectedGovernmentAuthority, parameters.GovernmentAuthority);
        Assert.Equal(expectedNaturalPerson, parameters.NaturalPerson);
        Assert.Equal(expectedRiskRating, parameters.RiskRating);
        Assert.NotNull(parameters.TermsAgreements);
        Assert.Equal(expectedTermsAgreements.Count, parameters.TermsAgreements.Count);
        for (int i = 0; i < expectedTermsAgreements.Count; i++)
        {
            Assert.Equal(expectedTermsAgreements[i], parameters.TermsAgreements[i]);
        }
        Assert.Equal(expectedThirdPartyVerification, parameters.ThirdPartyVerification);
        Assert.Equal(expectedTrust, parameters.Trust);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityUpdateParams { EntityID = "entity_n8y8tnk2p9339ti393yi" };

        Assert.Null(parameters.Corporation);
        Assert.False(parameters.RawBodyData.ContainsKey("corporation"));
        Assert.Null(parameters.DetailsConfirmedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("details_confirmed_at"));
        Assert.Null(parameters.GovernmentAuthority);
        Assert.False(parameters.RawBodyData.ContainsKey("government_authority"));
        Assert.Null(parameters.NaturalPerson);
        Assert.False(parameters.RawBodyData.ContainsKey("natural_person"));
        Assert.Null(parameters.RiskRating);
        Assert.False(parameters.RawBodyData.ContainsKey("risk_rating"));
        Assert.Null(parameters.TermsAgreements);
        Assert.False(parameters.RawBodyData.ContainsKey("terms_agreements"));
        Assert.Null(parameters.ThirdPartyVerification);
        Assert.False(parameters.RawBodyData.ContainsKey("third_party_verification"));
        Assert.Null(parameters.Trust);
        Assert.False(parameters.RawBodyData.ContainsKey("trust"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityUpdateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",

            // Null should be interpreted as omitted for these properties
            Corporation = null,
            DetailsConfirmedAt = null,
            GovernmentAuthority = null,
            NaturalPerson = null,
            RiskRating = null,
            TermsAgreements = null,
            ThirdPartyVerification = null,
            Trust = null,
        };

        Assert.Null(parameters.Corporation);
        Assert.False(parameters.RawBodyData.ContainsKey("corporation"));
        Assert.Null(parameters.DetailsConfirmedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("details_confirmed_at"));
        Assert.Null(parameters.GovernmentAuthority);
        Assert.False(parameters.RawBodyData.ContainsKey("government_authority"));
        Assert.Null(parameters.NaturalPerson);
        Assert.False(parameters.RawBodyData.ContainsKey("natural_person"));
        Assert.Null(parameters.RiskRating);
        Assert.False(parameters.RawBodyData.ContainsKey("risk_rating"));
        Assert.Null(parameters.TermsAgreements);
        Assert.False(parameters.RawBodyData.ContainsKey("terms_agreements"));
        Assert.Null(parameters.ThirdPartyVerification);
        Assert.False(parameters.RawBodyData.ContainsKey("third_party_verification"));
        Assert.Null(parameters.Trust);
        Assert.False(parameters.RawBodyData.ContainsKey("trust"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityUpdateParams parameters = new() { EntityID = "entity_n8y8tnk2p9339ti393yi" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/entities/entity_n8y8tnk2p9339ti393yi"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityUpdateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = "Unit 2",
                    State = "NY",
                    Zip = "10045",
                },
                Email = "dev@stainless.com",
                IncorporationState = "x",
                IndustryCode = "x",
                LegalIdentifier = new()
                {
                    Value = "x",
                    Category =
                        EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                },
                Name = "x",
            },
            DetailsConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                Name = "x",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "x",
                    Country = "x",
                    Line1 = "x",
                    Line2 = "x",
                    State = "x",
                    Zip = "x",
                },
                ConfirmedNoUsTaxID = true,
                Identification = new()
                {
                    Method =
                        EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    Number = "xxxx",
                    DriversLicense = new()
                    {
                        ExpirationDate = "2019-12-27",
                        FileID = "file_id",
                        State = "x",
                        BackFileID = "back_file_id",
                    },
                    Other = new()
                    {
                        Country = "x",
                        Description = "x",
                        FileID = "file_id",
                        BackFileID = "back_file_id",
                        ExpirationDate = "2019-12-27",
                    },
                    Passport = new()
                    {
                        Country = "x",
                        ExpirationDate = "2019-12-27",
                        FileID = "file_id",
                    },
                },
                Name = "x",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Rating = EntityUpdateParamsRiskRatingRating.Low,
            },
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IPAddress = "x",
                    TermsUrl = "x",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "x",
                Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                Name = "x",
            },
        };

        EntityUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntityUpdateParamsCorporationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            LegalIdentifier = new()
            {
                Value = "x",
                Category =
                    EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            },
            Name = "x",
        };

        EntityUpdateParamsCorporationAddress expectedAddress = new()
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };
        string expectedEmail = "dev@stainless.com";
        string expectedIncorporationState = "x";
        string expectedIndustryCode = "x";
        EntityUpdateParamsCorporationLegalIdentifier expectedLegalIdentifier = new()
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedIncorporationState, model.IncorporationState);
        Assert.Equal(expectedIndustryCode, model.IndustryCode);
        Assert.Equal(expectedLegalIdentifier, model.LegalIdentifier);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            LegalIdentifier = new()
            {
                Value = "x",
                Category =
                    EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            },
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            LegalIdentifier = new()
            {
                Value = "x",
                Category =
                    EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            },
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityUpdateParamsCorporationAddress expectedAddress = new()
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };
        string expectedEmail = "dev@stainless.com";
        string expectedIncorporationState = "x";
        string expectedIndustryCode = "x";
        EntityUpdateParamsCorporationLegalIdentifier expectedLegalIdentifier = new()
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedIncorporationState, deserialized.IncorporationState);
        Assert.Equal(expectedIndustryCode, deserialized.IndustryCode);
        Assert.Equal(expectedLegalIdentifier, deserialized.LegalIdentifier);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            LegalIdentifier = new()
            {
                Value = "x",
                Category =
                    EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            },
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsCorporation { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.IncorporationState);
        Assert.False(model.RawData.ContainsKey("incorporation_state"));
        Assert.Null(model.IndustryCode);
        Assert.False(model.RawData.ContainsKey("industry_code"));
        Assert.Null(model.LegalIdentifier);
        Assert.False(model.RawData.ContainsKey("legal_identifier"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsCorporation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            Email = null,
            IncorporationState = null,
            IndustryCode = null,
            LegalIdentifier = null,
            Name = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.IncorporationState);
        Assert.False(model.RawData.ContainsKey("incorporation_state"));
        Assert.Null(model.IndustryCode);
        Assert.False(model.RawData.ContainsKey("industry_code"));
        Assert.Null(model.LegalIdentifier);
        Assert.False(model.RawData.ContainsKey("legal_identifier"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            Email = null,
            IncorporationState = null,
            IndustryCode = null,
            LegalIdentifier = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            LegalIdentifier = new()
            {
                Value = "x",
                Category =
                    EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
            },
            Name = "x",
        };

        EntityUpdateParamsCorporation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsCorporationAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedState = "x";
        string expectedZip = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporationAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporationAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedState = "x";
        string expectedZip = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Zip);
        Assert.False(model.RawData.ContainsKey("zip"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            State = null,
            Zip = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Zip);
        Assert.False(model.RawData.ContainsKey("zip"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            State = null,
            Zip = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        EntityUpdateParamsCorporationAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsCorporationLegalIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };

        string expectedValue = "x";
        ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory> expectedCategory =
            EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber;

        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedCategory, model.Category);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporationLegalIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporationLegalIdentifier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedValue = "x";
        ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory> expectedCategory =
            EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber;

        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedCategory, deserialized.Category);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier { Value = "x" };

        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier { Value = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",

            // Null should be interpreted as omitted for these properties
            Category = null,
        };

        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",

            // Null should be interpreted as omitted for these properties
            Category = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsCorporationLegalIdentifier
        {
            Value = "x",
            Category =
                EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
        };

        EntityUpdateParamsCorporationLegalIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsCorporationLegalIdentifierCategoryTest : TestBase
{
    [Theory]
    [InlineData(
        EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber
    )]
    [InlineData(EntityUpdateParamsCorporationLegalIdentifierCategory.Other)]
    public void Validation_Works(EntityUpdateParamsCorporationLegalIdentifierCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntityUpdateParamsCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber
    )]
    [InlineData(EntityUpdateParamsCorporationLegalIdentifierCategory.Other)]
    public void SerializationRoundtrip_Works(
        EntityUpdateParamsCorporationLegalIdentifierCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsCorporationLegalIdentifierCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityUpdateParamsGovernmentAuthorityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        EntityUpdateParamsGovernmentAuthorityAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsGovernmentAuthority>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsGovernmentAuthority>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityUpdateParamsGovernmentAuthorityAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            Name = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        EntityUpdateParamsGovernmentAuthority copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsGovernmentAuthorityAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedState = "x";
        string expectedZip = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
        Assert.Equal(expectedLine2, model.Line2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsGovernmentAuthorityAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsGovernmentAuthorityAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedState = "x";
        string expectedZip = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
        Assert.Equal(expectedLine2, deserialized.Line2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsGovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        EntityUpdateParamsGovernmentAuthorityAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsNaturalPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                Number = "xxxx",
                DriversLicense = new()
                {
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                    State = "x",
                    BackFileID = "back_file_id",
                },
                Other = new()
                {
                    Country = "x",
                    Description = "x",
                    FileID = "file_id",
                    BackFileID = "back_file_id",
                    ExpirationDate = "2019-12-27",
                },
                Passport = new()
                {
                    Country = "x",
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                },
            },
            Name = "x",
        };

        EntityUpdateParamsNaturalPersonAddress expectedAddress = new()
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };
        bool expectedConfirmedNoUsTaxID = true;
        EntityUpdateParamsNaturalPersonIdentification expectedIdentification = new()
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedConfirmedNoUsTaxID, model.ConfirmedNoUsTaxID);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                Number = "xxxx",
                DriversLicense = new()
                {
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                    State = "x",
                    BackFileID = "back_file_id",
                },
                Other = new()
                {
                    Country = "x",
                    Description = "x",
                    FileID = "file_id",
                    BackFileID = "back_file_id",
                    ExpirationDate = "2019-12-27",
                },
                Passport = new()
                {
                    Country = "x",
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                },
            },
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsNaturalPerson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                Number = "xxxx",
                DriversLicense = new()
                {
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                    State = "x",
                    BackFileID = "back_file_id",
                },
                Other = new()
                {
                    Country = "x",
                    Description = "x",
                    FileID = "file_id",
                    BackFileID = "back_file_id",
                    ExpirationDate = "2019-12-27",
                },
                Passport = new()
                {
                    Country = "x",
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                },
            },
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsNaturalPerson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityUpdateParamsNaturalPersonAddress expectedAddress = new()
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };
        bool expectedConfirmedNoUsTaxID = true;
        EntityUpdateParamsNaturalPersonIdentification expectedIdentification = new()
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedConfirmedNoUsTaxID, deserialized.ConfirmedNoUsTaxID);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                Number = "xxxx",
                DriversLicense = new()
                {
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                    State = "x",
                    BackFileID = "back_file_id",
                },
                Other = new()
                {
                    Country = "x",
                    Description = "x",
                    FileID = "file_id",
                    BackFileID = "back_file_id",
                    ExpirationDate = "2019-12-27",
                },
                Passport = new()
                {
                    Country = "x",
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                },
            },
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
        Assert.Null(model.Identification);
        Assert.False(model.RawData.ContainsKey("identification"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            ConfirmedNoUsTaxID = null,
            Identification = null,
            Name = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
        Assert.Null(model.Identification);
        Assert.False(model.RawData.ContainsKey("identification"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            ConfirmedNoUsTaxID = null,
            Identification = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsNaturalPerson
        {
            Address = new()
            {
                City = "x",
                Country = "x",
                Line1 = "x",
                Line2 = "x",
                State = "x",
                Zip = "x",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
                Number = "xxxx",
                DriversLicense = new()
                {
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                    State = "x",
                    BackFileID = "back_file_id",
                },
                Other = new()
                {
                    Country = "x",
                    Description = "x",
                    FileID = "file_id",
                    BackFileID = "back_file_id",
                    ExpirationDate = "2019-12-27",
                },
                Passport = new()
                {
                    Country = "x",
                    ExpirationDate = "2019-12-27",
                    FileID = "file_id",
                },
            },
            Name = "x",
        };

        EntityUpdateParamsNaturalPerson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsNaturalPersonAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedState = "x";
        string expectedZip = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedState = "x";
        string expectedZip = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Zip);
        Assert.False(model.RawData.ContainsKey("zip"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            State = null,
            Zip = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Zip);
        Assert.False(model.RawData.ContainsKey("zip"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            State = null,
            Zip = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        EntityUpdateParamsNaturalPersonAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsNaturalPersonIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };

        ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod> expectedMethod =
            EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        EntityUpdateParamsNaturalPersonIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        EntityUpdateParamsNaturalPersonIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        EntityUpdateParamsNaturalPersonIdentificationPassport expectedPassport = new()
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedDriversLicense, model.DriversLicense);
        Assert.Equal(expectedOther, model.Other);
        Assert.Equal(expectedPassport, model.Passport);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod> expectedMethod =
            EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        EntityUpdateParamsNaturalPersonIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        EntityUpdateParamsNaturalPersonIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        EntityUpdateParamsNaturalPersonIdentificationPassport expectedPassport = new()
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedDriversLicense, deserialized.DriversLicense);
        Assert.Equal(expectedOther, deserialized.Other);
        Assert.Equal(expectedPassport, deserialized.Passport);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        Assert.Null(model.DriversLicense);
        Assert.False(model.RawData.ContainsKey("drivers_license"));
        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
        Assert.Null(model.Passport);
        Assert.False(model.RawData.ContainsKey("passport"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",

            // Null should be interpreted as omitted for these properties
            DriversLicense = null,
            Other = null,
            Passport = null,
        };

        Assert.Null(model.DriversLicense);
        Assert.False(model.RawData.ContainsKey("drivers_license"));
        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
        Assert.Null(model.Passport);
        Assert.False(model.RawData.ContainsKey("passport"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",

            // Null should be interpreted as omitted for these properties
            DriversLicense = null,
            Other = null,
            Passport = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentification
        {
            Method = EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
            DriversLicense = new()
            {
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
                State = "x",
                BackFileID = "back_file_id",
            },
            Other = new()
            {
                Country = "x",
                Description = "x",
                FileID = "file_id",
                BackFileID = "back_file_id",
                ExpirationDate = "2019-12-27",
            },
            Passport = new()
            {
                Country = "x",
                ExpirationDate = "2019-12-27",
                FileID = "file_id",
            },
        };

        EntityUpdateParamsNaturalPersonIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsNaturalPersonIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        EntityUpdateParamsNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.Passport)]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.DriversLicense)]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.Other)]
    public void Validation_Works(EntityUpdateParamsNaturalPersonIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        EntityUpdateParamsNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.Passport)]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.DriversLicense)]
    [InlineData(EntityUpdateParamsNaturalPersonIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        EntityUpdateParamsNaturalPersonIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsNaturalPersonIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityUpdateParamsNaturalPersonIdentificationDriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string expectedExpirationDate = "2019-12-27";
        string expectedFileID = "file_id";
        string expectedState = "x";
        string expectedBackFileID = "back_file_id";

        Assert.Equal(expectedExpirationDate, model.ExpirationDate);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedBackFileID, model.BackFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentificationDriversLicense>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentificationDriversLicense>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedExpirationDate = "2019-12-27";
        string expectedFileID = "file_id";
        string expectedState = "x";
        string expectedBackFileID = "back_file_id";

        Assert.Equal(expectedExpirationDate, deserialized.ExpirationDate);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedBackFileID, deserialized.BackFileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
        };

        Assert.Null(model.BackFileID);
        Assert.False(model.RawData.ContainsKey("back_file_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",

            // Null should be interpreted as omitted for these properties
            BackFileID = null,
        };

        Assert.Null(model.BackFileID);
        Assert.False(model.RawData.ContainsKey("back_file_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",

            // Null should be interpreted as omitted for these properties
            BackFileID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        EntityUpdateParamsNaturalPersonIdentificationDriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsNaturalPersonIdentificationOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string expectedCountry = "x";
        string expectedDescription = "x";
        string expectedFileID = "file_id";
        string expectedBackFileID = "back_file_id";
        string expectedExpirationDate = "2019-12-27";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedBackFileID, model.BackFileID);
        Assert.Equal(expectedExpirationDate, model.ExpirationDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentificationOther>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentificationOther>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "x";
        string expectedDescription = "x";
        string expectedFileID = "file_id";
        string expectedBackFileID = "back_file_id";
        string expectedExpirationDate = "2019-12-27";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedBackFileID, deserialized.BackFileID);
        Assert.Equal(expectedExpirationDate, deserialized.ExpirationDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
        };

        Assert.Null(model.BackFileID);
        Assert.False(model.RawData.ContainsKey("back_file_id"));
        Assert.Null(model.ExpirationDate);
        Assert.False(model.RawData.ContainsKey("expiration_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",

            // Null should be interpreted as omitted for these properties
            BackFileID = null,
            ExpirationDate = null,
        };

        Assert.Null(model.BackFileID);
        Assert.False(model.RawData.ContainsKey("back_file_id"));
        Assert.Null(model.ExpirationDate);
        Assert.False(model.RawData.ContainsKey("expiration_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",

            // Null should be interpreted as omitted for these properties
            BackFileID = null,
            ExpirationDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        EntityUpdateParamsNaturalPersonIdentificationOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsNaturalPersonIdentificationPassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string expectedCountry = "x";
        string expectedExpirationDate = "2019-12-27";
        string expectedFileID = "file_id";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedExpirationDate, model.ExpirationDate);
        Assert.Equal(expectedFileID, model.FileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentificationPassport>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonIdentificationPassport>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "x";
        string expectedExpirationDate = "2019-12-27";
        string expectedFileID = "file_id";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedExpirationDate, deserialized.ExpirationDate);
        Assert.Equal(expectedFileID, deserialized.FileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsNaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        EntityUpdateParamsNaturalPersonIdentificationPassport copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsRiskRatingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };

        DateTimeOffset expectedRatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EntityUpdateParamsRiskRatingRating> expectedRating =
            EntityUpdateParamsRiskRatingRating.Low;

        Assert.Equal(expectedRatedAt, model.RatedAt);
        Assert.Equal(expectedRating, model.Rating);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsRiskRating>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsRiskRating>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedRatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EntityUpdateParamsRiskRatingRating> expectedRating =
            EntityUpdateParamsRiskRatingRating.Low;

        Assert.Equal(expectedRatedAt, deserialized.RatedAt);
        Assert.Equal(expectedRating, deserialized.Rating);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };

        EntityUpdateParamsRiskRating copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsRiskRatingRatingTest : TestBase
{
    [Theory]
    [InlineData(EntityUpdateParamsRiskRatingRating.Low)]
    [InlineData(EntityUpdateParamsRiskRatingRating.Medium)]
    [InlineData(EntityUpdateParamsRiskRatingRating.High)]
    public void Validation_Works(EntityUpdateParamsRiskRatingRating rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsRiskRatingRating> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityUpdateParamsRiskRatingRating>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityUpdateParamsRiskRatingRating.Low)]
    [InlineData(EntityUpdateParamsRiskRatingRating.Medium)]
    [InlineData(EntityUpdateParamsRiskRatingRating.High)]
    public void SerializationRoundtrip_Works(EntityUpdateParamsRiskRatingRating rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsRiskRatingRating> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsRiskRatingRating>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityUpdateParamsRiskRatingRating>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsRiskRatingRating>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityUpdateParamsTermsAgreementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        DateTimeOffset expectedAgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIPAddress = "x";
        string expectedTermsUrl = "x";

        Assert.Equal(expectedAgreedAt, model.AgreedAt);
        Assert.Equal(expectedIPAddress, model.IPAddress);
        Assert.Equal(expectedTermsUrl, model.TermsUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsTermsAgreement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsTermsAgreement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIPAddress = "x";
        string expectedTermsUrl = "x";

        Assert.Equal(expectedAgreedAt, deserialized.AgreedAt);
        Assert.Equal(expectedIPAddress, deserialized.IPAddress);
        Assert.Equal(expectedTermsUrl, deserialized.TermsUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        EntityUpdateParamsTermsAgreement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsThirdPartyVerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsThirdPartyVerification
        {
            Reference = "x",
            Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
        };

        string expectedReference = "x";
        ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor> expectedVendor =
            EntityUpdateParamsThirdPartyVerificationVendor.Alloy;

        Assert.Equal(expectedReference, model.Reference);
        Assert.Equal(expectedVendor, model.Vendor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsThirdPartyVerification
        {
            Reference = "x",
            Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsThirdPartyVerification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsThirdPartyVerification
        {
            Reference = "x",
            Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsThirdPartyVerification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReference = "x";
        ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor> expectedVendor =
            EntityUpdateParamsThirdPartyVerificationVendor.Alloy;

        Assert.Equal(expectedReference, deserialized.Reference);
        Assert.Equal(expectedVendor, deserialized.Vendor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsThirdPartyVerification
        {
            Reference = "x",
            Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsThirdPartyVerification
        {
            Reference = "x",
            Vendor = EntityUpdateParamsThirdPartyVerificationVendor.Alloy,
        };

        EntityUpdateParamsThirdPartyVerification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsThirdPartyVerificationVendorTest : TestBase
{
    [Theory]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Alloy)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Middesk)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Oscilar)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Persona)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Taktile)]
    public void Validation_Works(EntityUpdateParamsThirdPartyVerificationVendor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Alloy)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Middesk)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Oscilar)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Persona)]
    [InlineData(EntityUpdateParamsThirdPartyVerificationVendor.Taktile)]
    public void SerializationRoundtrip_Works(
        EntityUpdateParamsThirdPartyVerificationVendor rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityUpdateParamsThirdPartyVerificationVendor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityUpdateParamsTrustTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        EntityUpdateParamsTrustAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsTrust>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsTrust>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityUpdateParamsTrustAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedName = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsTrust { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsTrust { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            Name = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsTrust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        EntityUpdateParamsTrust copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUpdateParamsTrustAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedState = "x";
        string expectedZip = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
        Assert.Equal(expectedLine2, model.Line2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsTrustAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsTrustAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedState = "x";
        string expectedZip = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
        Assert.Equal(expectedLine2, deserialized.Line2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUpdateParamsTrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        EntityUpdateParamsTrustAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}
