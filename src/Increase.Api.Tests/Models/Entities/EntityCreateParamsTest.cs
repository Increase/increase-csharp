using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Entities;

namespace Increase.Api.Tests.Models.Entities;

public class EntityCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityCreateParams
        {
            Structure = Structure.Corporation,
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    State = "NY",
                    Zip = "10045",
                    Line2 = "x",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "x",
                                Line1 = "33 Liberty Street",
                                Line2 = "x",
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method = Method.SocialSecurityNumber,
                                Number = "078051120",
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
                            Name = "Ian Crease",
                            ConfirmedNoUsTaxID = true,
                        },
                        Prongs = [Prong.Control],
                        CompanyTitle = "CEO",
                    },
                ],
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                BeneficialOwnershipExemptionReason =
                    BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
                Email = "dev@stainless.com",
                IncorporationState = "NY",
                IndustryCode = "x",
                Website = "https://example.com",
            },
            Description = "x",
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
                AuthorizedPersons = [new("x")],
                Category = Category.Municipality,
                Name = "x",
                TaxIdentifier = "x",
                Website = "website",
            },
            Joint = new(
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                ]
            ),
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Rating.Low,
            },
            SupplementalDocuments = [new("file_makxrc67oh9l6sg7w9yc")],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IPAddress = "x",
                    TermsUrl = "x",
                },
            ],
            ThirdPartyVerification = new() { Reference = "x", Vendor = Vendor.Alloy },
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
                Category = TrustCategory.Revocable,
                Name = "x",
                Trustees =
                [
                    new()
                    {
                        Structure = TrusteeStructure.Individual,
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "x",
                                Line1 = "x",
                                State = "x",
                                Zip = "x",
                                Line2 = "x",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                            ConfirmedNoUsTaxID = true,
                        },
                    },
                ],
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "x",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
                TaxIdentifier = "x",
            },
        };

        ApiEnum<string, Structure> expectedStructure = Structure.Corporation;
        Corporation expectedCorporation = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                State = "NY",
                Zip = "10045",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "x",
                            Line1 = "33 Liberty Street",
                            Line2 = "x",
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
                            Number = "078051120",
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
                        Name = "Ian Crease",
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Control],
                    CompanyTitle = "CEO",
                },
            ],
            Name = "National Phonograph Company",
            TaxIdentifier = "602214076",
            BeneficialOwnershipExemptionReason =
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            Email = "dev@stainless.com",
            IncorporationState = "NY",
            IndustryCode = "x",
            Website = "https://example.com",
        };
        string expectedDescription = "x";
        GovernmentAuthority expectedGovernmentAuthority = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
            Website = "website",
        };
        Joint expectedJoint = new(
            [
                new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            ]
        );
        NaturalPerson expectedNaturalPerson = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };
        RiskRating expectedRiskRating = new()
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Rating.Low,
        };
        List<SupplementalDocument> expectedSupplementalDocuments =
        [
            new("file_makxrc67oh9l6sg7w9yc"),
        ];
        List<TermsAgreement> expectedTermsAgreements =
        [
            new()
            {
                AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IPAddress = "x",
                TermsUrl = "x",
            },
        ];
        ThirdPartyVerification expectedThirdPartyVerification = new()
        {
            Reference = "x",
            Vendor = Vendor.Alloy,
        };
        Trust expectedTrust = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "x",
            Grantor = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            TaxIdentifier = "x",
        };

        Assert.Equal(expectedStructure, parameters.Structure);
        Assert.Equal(expectedCorporation, parameters.Corporation);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedGovernmentAuthority, parameters.GovernmentAuthority);
        Assert.Equal(expectedJoint, parameters.Joint);
        Assert.Equal(expectedNaturalPerson, parameters.NaturalPerson);
        Assert.Equal(expectedRiskRating, parameters.RiskRating);
        Assert.NotNull(parameters.SupplementalDocuments);
        Assert.Equal(expectedSupplementalDocuments.Count, parameters.SupplementalDocuments.Count);
        for (int i = 0; i < expectedSupplementalDocuments.Count; i++)
        {
            Assert.Equal(expectedSupplementalDocuments[i], parameters.SupplementalDocuments[i]);
        }
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
        var parameters = new EntityCreateParams { Structure = Structure.Corporation };

        Assert.Null(parameters.Corporation);
        Assert.False(parameters.RawBodyData.ContainsKey("corporation"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.GovernmentAuthority);
        Assert.False(parameters.RawBodyData.ContainsKey("government_authority"));
        Assert.Null(parameters.Joint);
        Assert.False(parameters.RawBodyData.ContainsKey("joint"));
        Assert.Null(parameters.NaturalPerson);
        Assert.False(parameters.RawBodyData.ContainsKey("natural_person"));
        Assert.Null(parameters.RiskRating);
        Assert.False(parameters.RawBodyData.ContainsKey("risk_rating"));
        Assert.Null(parameters.SupplementalDocuments);
        Assert.False(parameters.RawBodyData.ContainsKey("supplemental_documents"));
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
        var parameters = new EntityCreateParams
        {
            Structure = Structure.Corporation,

            // Null should be interpreted as omitted for these properties
            Corporation = null,
            Description = null,
            GovernmentAuthority = null,
            Joint = null,
            NaturalPerson = null,
            RiskRating = null,
            SupplementalDocuments = null,
            TermsAgreements = null,
            ThirdPartyVerification = null,
            Trust = null,
        };

        Assert.Null(parameters.Corporation);
        Assert.False(parameters.RawBodyData.ContainsKey("corporation"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.GovernmentAuthority);
        Assert.False(parameters.RawBodyData.ContainsKey("government_authority"));
        Assert.Null(parameters.Joint);
        Assert.False(parameters.RawBodyData.ContainsKey("joint"));
        Assert.Null(parameters.NaturalPerson);
        Assert.False(parameters.RawBodyData.ContainsKey("natural_person"));
        Assert.Null(parameters.RiskRating);
        Assert.False(parameters.RawBodyData.ContainsKey("risk_rating"));
        Assert.Null(parameters.SupplementalDocuments);
        Assert.False(parameters.RawBodyData.ContainsKey("supplemental_documents"));
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
        EntityCreateParams parameters = new() { Structure = Structure.Corporation };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/entities"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityCreateParams
        {
            Structure = Structure.Corporation,
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    State = "NY",
                    Zip = "10045",
                    Line2 = "x",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "x",
                                Line1 = "33 Liberty Street",
                                Line2 = "x",
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method = Method.SocialSecurityNumber,
                                Number = "078051120",
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
                            Name = "Ian Crease",
                            ConfirmedNoUsTaxID = true,
                        },
                        Prongs = [Prong.Control],
                        CompanyTitle = "CEO",
                    },
                ],
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                BeneficialOwnershipExemptionReason =
                    BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
                Email = "dev@stainless.com",
                IncorporationState = "NY",
                IndustryCode = "x",
                Website = "https://example.com",
            },
            Description = "x",
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
                AuthorizedPersons = [new("x")],
                Category = Category.Municipality,
                Name = "x",
                TaxIdentifier = "x",
                Website = "website",
            },
            Joint = new(
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                ]
            ),
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Rating.Low,
            },
            SupplementalDocuments = [new("file_makxrc67oh9l6sg7w9yc")],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IPAddress = "x",
                    TermsUrl = "x",
                },
            ],
            ThirdPartyVerification = new() { Reference = "x", Vendor = Vendor.Alloy },
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
                Category = TrustCategory.Revocable,
                Name = "x",
                Trustees =
                [
                    new()
                    {
                        Structure = TrusteeStructure.Individual,
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "x",
                                Line1 = "x",
                                State = "x",
                                Zip = "x",
                                Line2 = "x",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                            ConfirmedNoUsTaxID = true,
                        },
                    },
                ],
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "x",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
                TaxIdentifier = "x",
            },
        };

        EntityCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StructureTest : TestBase
{
    [Theory]
    [InlineData(Structure.Corporation)]
    [InlineData(Structure.NaturalPerson)]
    [InlineData(Structure.Joint)]
    [InlineData(Structure.Trust)]
    [InlineData(Structure.GovernmentAuthority)]
    public void Validation_Works(Structure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Structure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Structure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Structure.Corporation)]
    [InlineData(Structure.NaturalPerson)]
    [InlineData(Structure.Joint)]
    [InlineData(Structure.Trust)]
    [InlineData(Structure.GovernmentAuthority)]
    public void SerializationRoundtrip_Works(Structure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Structure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Structure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Structure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Structure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CorporationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
            BeneficialOwnershipExemptionReason =
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Website = "website",
        };

        Address expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        List<BeneficialOwner> expectedBeneficialOwners =
        [
            new()
            {
                Individual = new()
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
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = Method.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
                Prongs = [Prong.Ownership],
                CompanyTitle = "x",
            },
        ];
        string expectedName = "x";
        string expectedTaxIdentifier = "x";
        ApiEnum<
            string,
            BeneficialOwnershipExemptionReason
        > expectedBeneficialOwnershipExemptionReason =
            BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution;
        string expectedEmail = "dev@stainless.com";
        string expectedIncorporationState = "x";
        string expectedIndustryCode = "x";
        string expectedWebsite = "website";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedBeneficialOwners.Count, model.BeneficialOwners.Count);
        for (int i = 0; i < expectedBeneficialOwners.Count; i++)
        {
            Assert.Equal(expectedBeneficialOwners[i], model.BeneficialOwners[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTaxIdentifier, model.TaxIdentifier);
        Assert.Equal(
            expectedBeneficialOwnershipExemptionReason,
            model.BeneficialOwnershipExemptionReason
        );
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedIncorporationState, model.IncorporationState);
        Assert.Equal(expectedIndustryCode, model.IndustryCode);
        Assert.Equal(expectedWebsite, model.Website);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
            BeneficialOwnershipExemptionReason =
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Website = "website",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Corporation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
            BeneficialOwnershipExemptionReason =
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Website = "website",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Corporation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Address expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        List<BeneficialOwner> expectedBeneficialOwners =
        [
            new()
            {
                Individual = new()
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
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = Method.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
                Prongs = [Prong.Ownership],
                CompanyTitle = "x",
            },
        ];
        string expectedName = "x";
        string expectedTaxIdentifier = "x";
        ApiEnum<
            string,
            BeneficialOwnershipExemptionReason
        > expectedBeneficialOwnershipExemptionReason =
            BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution;
        string expectedEmail = "dev@stainless.com";
        string expectedIncorporationState = "x";
        string expectedIndustryCode = "x";
        string expectedWebsite = "website";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedBeneficialOwners.Count, deserialized.BeneficialOwners.Count);
        for (int i = 0; i < expectedBeneficialOwners.Count; i++)
        {
            Assert.Equal(expectedBeneficialOwners[i], deserialized.BeneficialOwners[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTaxIdentifier, deserialized.TaxIdentifier);
        Assert.Equal(
            expectedBeneficialOwnershipExemptionReason,
            deserialized.BeneficialOwnershipExemptionReason
        );
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedIncorporationState, deserialized.IncorporationState);
        Assert.Equal(expectedIndustryCode, deserialized.IndustryCode);
        Assert.Equal(expectedWebsite, deserialized.Website);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
            BeneficialOwnershipExemptionReason =
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Website = "website",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
        };

        Assert.Null(model.BeneficialOwnershipExemptionReason);
        Assert.False(model.RawData.ContainsKey("beneficial_ownership_exemption_reason"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.IncorporationState);
        Assert.False(model.RawData.ContainsKey("incorporation_state"));
        Assert.Null(model.IndustryCode);
        Assert.False(model.RawData.ContainsKey("industry_code"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",

            // Null should be interpreted as omitted for these properties
            BeneficialOwnershipExemptionReason = null,
            Email = null,
            IncorporationState = null,
            IndustryCode = null,
            Website = null,
        };

        Assert.Null(model.BeneficialOwnershipExemptionReason);
        Assert.False(model.RawData.ContainsKey("beneficial_ownership_exemption_reason"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.IncorporationState);
        Assert.False(model.RawData.ContainsKey("incorporation_state"));
        Assert.Null(model.IndustryCode);
        Assert.False(model.RawData.ContainsKey("industry_code"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",

            // Null should be interpreted as omitted for these properties
            BeneficialOwnershipExemptionReason = null,
            Email = null,
            IncorporationState = null,
            IndustryCode = null,
            Website = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Corporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            BeneficialOwners =
            [
                new()
                {
                    Individual = new()
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
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = Method.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                    Prongs = [Prong.Ownership],
                    CompanyTitle = "x",
                },
            ],
            Name = "x",
            TaxIdentifier = "x",
            BeneficialOwnershipExemptionReason =
                BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution,
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Website = "website",
        };

        Corporation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Address
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
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BeneficialOwnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
            CompanyTitle = "x",
        };

        Individual expectedIndividual = new()
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };
        List<ApiEnum<string, Prong>> expectedProngs = [Prong.Ownership];
        string expectedCompanyTitle = "x";

        Assert.Equal(expectedIndividual, model.Individual);
        Assert.Equal(expectedProngs.Count, model.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], model.Prongs[i]);
        }
        Assert.Equal(expectedCompanyTitle, model.CompanyTitle);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
            CompanyTitle = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BeneficialOwner>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
            CompanyTitle = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BeneficialOwner>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Individual expectedIndividual = new()
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };
        List<ApiEnum<string, Prong>> expectedProngs = [Prong.Ownership];
        string expectedCompanyTitle = "x";

        Assert.Equal(expectedIndividual, deserialized.Individual);
        Assert.Equal(expectedProngs.Count, deserialized.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], deserialized.Prongs[i]);
        }
        Assert.Equal(expectedCompanyTitle, deserialized.CompanyTitle);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
            CompanyTitle = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
        };

        Assert.Null(model.CompanyTitle);
        Assert.False(model.RawData.ContainsKey("company_title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],

            // Null should be interpreted as omitted for these properties
            CompanyTitle = null,
        };

        Assert.Null(model.CompanyTitle);
        Assert.False(model.RawData.ContainsKey("company_title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],

            // Null should be interpreted as omitted for these properties
            CompanyTitle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BeneficialOwner
        {
            Individual = new()
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
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Method.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            Prongs = [Prong.Ownership],
            CompanyTitle = "x",
        };

        BeneficialOwner copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        IndividualAddress expectedAddress = new()
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        Identification expectedIdentification = new()
        {
            Method = Method.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, model.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Individual>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Individual>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        IndividualAddress expectedAddress = new()
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        Identification expectedIdentification = new()
        {
            Method = Method.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, deserialized.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Individual
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
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Method.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        Individual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IndividualAddress
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
        var model = new IndividualAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndividualAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IndividualAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndividualAddress>(
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
        var model = new IndividualAddress
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
        var model = new IndividualAddress
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
        var model = new IndividualAddress
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
        var model = new IndividualAddress
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
        var model = new IndividualAddress
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
        var model = new IndividualAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        IndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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

        ApiEnum<string, Method> expectedMethod = Method.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        DriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        Other expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        Passport expectedPassport = new()
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
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<Identification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<Identification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Method> expectedMethod = Method.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        DriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        Other expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        Passport expectedPassport = new()
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
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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
        var model = new Identification { Method = Method.SocialSecurityNumber, Number = "xxxx" };

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
        var model = new Identification { Method = Method.SocialSecurityNumber, Number = "xxxx" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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
        var model = new Identification
        {
            Method = Method.SocialSecurityNumber,
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

        Identification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.SocialSecurityNumber)]
    [InlineData(Method.IndividualTaxpayerIdentificationNumber)]
    [InlineData(Method.Passport)]
    [InlineData(Method.DriversLicense)]
    [InlineData(Method.Other)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.SocialSecurityNumber)]
    [InlineData(Method.IndividualTaxpayerIdentificationNumber)]
    [InlineData(Method.Passport)]
    [InlineData(Method.DriversLicense)]
    [InlineData(Method.Other)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DriversLicense
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
        var model = new DriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DriversLicense>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DriversLicense>(
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
        var model = new DriversLicense
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
        var model = new DriversLicense
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
        var model = new DriversLicense
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
        var model = new DriversLicense
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
        var model = new DriversLicense
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
        var model = new DriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        DriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Other
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
        var model = new Other
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Other>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Other
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Other>(element, ModelBase.SerializerOptions);
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
        var model = new Other
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
        var model = new Other
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
        var model = new Other
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
        var model = new Other
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
        var model = new Other
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
        var model = new Other
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        Other copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Passport
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
        var model = new Passport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Passport>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Passport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Passport>(
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
        var model = new Passport
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
        var model = new Passport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        Passport copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProngTest : TestBase
{
    [Theory]
    [InlineData(Prong.Ownership)]
    [InlineData(Prong.Control)]
    public void Validation_Works(Prong rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Prong> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Prong>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Prong.Ownership)]
    [InlineData(Prong.Control)]
    public void SerializationRoundtrip_Works(Prong rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Prong> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Prong>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Prong>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Prong>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BeneficialOwnershipExemptionReasonTest : TestBase
{
    [Theory]
    [InlineData(BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution)]
    [InlineData(BeneficialOwnershipExemptionReason.PubliclyTradedCompany)]
    [InlineData(BeneficialOwnershipExemptionReason.PublicEntity)]
    [InlineData(BeneficialOwnershipExemptionReason.Other)]
    public void Validation_Works(BeneficialOwnershipExemptionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwnershipExemptionReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BeneficialOwnershipExemptionReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BeneficialOwnershipExemptionReason.RegulatedFinancialInstitution)]
    [InlineData(BeneficialOwnershipExemptionReason.PubliclyTradedCompany)]
    [InlineData(BeneficialOwnershipExemptionReason.PublicEntity)]
    [InlineData(BeneficialOwnershipExemptionReason.Other)]
    public void SerializationRoundtrip_Works(BeneficialOwnershipExemptionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwnershipExemptionReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwnershipExemptionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BeneficialOwnershipExemptionReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwnershipExemptionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GovernmentAuthorityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
            Website = "website",
        };

        GovernmentAuthorityAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        List<AuthorizedPerson> expectedAuthorizedPersons = [new("x")];
        ApiEnum<string, Category> expectedCategory = Category.Municipality;
        string expectedName = "x";
        string expectedTaxIdentifier = "x";
        string expectedWebsite = "website";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedAuthorizedPersons.Count, model.AuthorizedPersons.Count);
        for (int i = 0; i < expectedAuthorizedPersons.Count; i++)
        {
            Assert.Equal(expectedAuthorizedPersons[i], model.AuthorizedPersons[i]);
        }
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTaxIdentifier, model.TaxIdentifier);
        Assert.Equal(expectedWebsite, model.Website);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
            Website = "website",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GovernmentAuthority>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
            Website = "website",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GovernmentAuthority>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        GovernmentAuthorityAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        List<AuthorizedPerson> expectedAuthorizedPersons = [new("x")];
        ApiEnum<string, Category> expectedCategory = Category.Municipality;
        string expectedName = "x";
        string expectedTaxIdentifier = "x";
        string expectedWebsite = "website";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedAuthorizedPersons.Count, deserialized.AuthorizedPersons.Count);
        for (int i = 0; i < expectedAuthorizedPersons.Count; i++)
        {
            Assert.Equal(expectedAuthorizedPersons[i], deserialized.AuthorizedPersons[i]);
        }
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTaxIdentifier, deserialized.TaxIdentifier);
        Assert.Equal(expectedWebsite, deserialized.Website);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
            Website = "website",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
        };

        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",

            // Null should be interpreted as omitted for these properties
            Website = null,
        };

        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",

            // Null should be interpreted as omitted for these properties
            Website = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GovernmentAuthority
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            AuthorizedPersons = [new("x")],
            Category = Category.Municipality,
            Name = "x",
            TaxIdentifier = "x",
            Website = "website",
        };

        GovernmentAuthority copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GovernmentAuthorityAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GovernmentAuthorityAddress
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
        var model = new GovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GovernmentAuthorityAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GovernmentAuthorityAddress>(
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
        var model = new GovernmentAuthorityAddress
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
        var model = new GovernmentAuthorityAddress
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
        var model = new GovernmentAuthorityAddress
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
        var model = new GovernmentAuthorityAddress
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
        var model = new GovernmentAuthorityAddress
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
        var model = new GovernmentAuthorityAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        GovernmentAuthorityAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuthorizedPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthorizedPerson { Name = "x" };

        string expectedName = "x";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuthorizedPerson { Name = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthorizedPerson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthorizedPerson { Name = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthorizedPerson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuthorizedPerson { Name = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuthorizedPerson { Name = "x" };

        AuthorizedPerson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Municipality)]
    [InlineData(Category.StateAgency)]
    [InlineData(Category.StateGovernment)]
    [InlineData(Category.FederalAgency)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Municipality)]
    [InlineData(Category.StateAgency)]
    [InlineData(Category.StateGovernment)]
    [InlineData(Category.FederalAgency)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Joint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            ],
        };

        List<JointIndividual> expectedIndividuals =
        [
            new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        ];

        Assert.Equal(expectedIndividuals.Count, model.Individuals.Count);
        for (int i = 0; i < expectedIndividuals.Count; i++)
        {
            Assert.Equal(expectedIndividuals[i], model.Individuals[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Joint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Joint>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Joint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Joint>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<JointIndividual> expectedIndividuals =
        [
            new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        ];

        Assert.Equal(expectedIndividuals.Count, deserialized.Individuals.Count);
        for (int i = 0; i < expectedIndividuals.Count; i++)
        {
            Assert.Equal(expectedIndividuals[i], deserialized.Individuals[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Joint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Joint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            ],
        };

        Joint copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JointIndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        JointIndividualAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        JointIndividualIdentification expectedIdentification = new()
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, model.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividual>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividual>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JointIndividualAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        JointIndividualIdentification expectedIdentification = new()
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, deserialized.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JointIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        JointIndividual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JointIndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JointIndividualAddress
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
        var model = new JointIndividualAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JointIndividualAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualAddress>(
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
        var model = new JointIndividualAddress
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
        var model = new JointIndividualAddress
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
        var model = new JointIndividualAddress
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
        var model = new JointIndividualAddress
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
        var model = new JointIndividualAddress
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
        var model = new JointIndividualAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        JointIndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JointIndividualIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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

        ApiEnum<string, JointIndividualIdentificationMethod> expectedMethod =
            JointIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        JointIndividualIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        JointIndividualIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        JointIndividualIdentificationPassport expectedPassport = new()
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
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, JointIndividualIdentificationMethod> expectedMethod =
            JointIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        JointIndividualIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        JointIndividualIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        JointIndividualIdentificationPassport expectedPassport = new()
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
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new JointIndividualIdentification
        {
            Method = JointIndividualIdentificationMethod.SocialSecurityNumber,
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

        JointIndividualIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JointIndividualIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(JointIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(JointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(JointIndividualIdentificationMethod.Passport)]
    [InlineData(JointIndividualIdentificationMethod.DriversLicense)]
    [InlineData(JointIndividualIdentificationMethod.Other)]
    public void Validation_Works(JointIndividualIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JointIndividualIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JointIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JointIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(JointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(JointIndividualIdentificationMethod.Passport)]
    [InlineData(JointIndividualIdentificationMethod.DriversLicense)]
    [InlineData(JointIndividualIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(JointIndividualIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JointIndividualIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JointIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JointIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JointIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JointIndividualIdentificationDriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JointIndividualIdentificationDriversLicense
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
        var model = new JointIndividualIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentificationDriversLicense>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JointIndividualIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentificationDriversLicense>(
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
        var model = new JointIndividualIdentificationDriversLicense
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
        var model = new JointIndividualIdentificationDriversLicense
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
        var model = new JointIndividualIdentificationDriversLicense
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
        var model = new JointIndividualIdentificationDriversLicense
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
        var model = new JointIndividualIdentificationDriversLicense
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
        var model = new JointIndividualIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        JointIndividualIdentificationDriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JointIndividualIdentificationOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JointIndividualIdentificationOther
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
        var model = new JointIndividualIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentificationOther>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JointIndividualIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentificationOther>(
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
        var model = new JointIndividualIdentificationOther
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
        var model = new JointIndividualIdentificationOther
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
        var model = new JointIndividualIdentificationOther
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
        var model = new JointIndividualIdentificationOther
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
        var model = new JointIndividualIdentificationOther
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
        var model = new JointIndividualIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        JointIndividualIdentificationOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JointIndividualIdentificationPassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JointIndividualIdentificationPassport
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
        var model = new JointIndividualIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentificationPassport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JointIndividualIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JointIndividualIdentificationPassport>(
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
        var model = new JointIndividualIdentificationPassport
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
        var model = new JointIndividualIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        JointIndividualIdentificationPassport copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NaturalPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        NaturalPersonAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        NaturalPersonIdentification expectedIdentification = new()
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, model.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPerson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPerson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        NaturalPersonAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        NaturalPersonIdentification expectedIdentification = new()
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, deserialized.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NaturalPerson
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        NaturalPerson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NaturalPersonAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NaturalPersonAddress
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
        var model = new NaturalPersonAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NaturalPersonAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonAddress>(
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
        var model = new NaturalPersonAddress
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
        var model = new NaturalPersonAddress
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
        var model = new NaturalPersonAddress
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
        var model = new NaturalPersonAddress
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
        var model = new NaturalPersonAddress
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
        var model = new NaturalPersonAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        NaturalPersonAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NaturalPersonIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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

        ApiEnum<string, NaturalPersonIdentificationMethod> expectedMethod =
            NaturalPersonIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        NaturalPersonIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        NaturalPersonIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        NaturalPersonIdentificationPassport expectedPassport = new()
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
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NaturalPersonIdentificationMethod> expectedMethod =
            NaturalPersonIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        NaturalPersonIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        NaturalPersonIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        NaturalPersonIdentificationPassport expectedPassport = new()
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
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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
        var model = new NaturalPersonIdentification
        {
            Method = NaturalPersonIdentificationMethod.SocialSecurityNumber,
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

        NaturalPersonIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NaturalPersonIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(NaturalPersonIdentificationMethod.SocialSecurityNumber)]
    [InlineData(NaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(NaturalPersonIdentificationMethod.Passport)]
    [InlineData(NaturalPersonIdentificationMethod.DriversLicense)]
    [InlineData(NaturalPersonIdentificationMethod.Other)]
    public void Validation_Works(NaturalPersonIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NaturalPersonIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NaturalPersonIdentificationMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NaturalPersonIdentificationMethod.SocialSecurityNumber)]
    [InlineData(NaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(NaturalPersonIdentificationMethod.Passport)]
    [InlineData(NaturalPersonIdentificationMethod.DriversLicense)]
    [InlineData(NaturalPersonIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(NaturalPersonIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NaturalPersonIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NaturalPersonIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NaturalPersonIdentificationMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NaturalPersonIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NaturalPersonIdentificationDriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NaturalPersonIdentificationDriversLicense
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
        var model = new NaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentificationDriversLicense>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentificationDriversLicense>(
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
        var model = new NaturalPersonIdentificationDriversLicense
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
        var model = new NaturalPersonIdentificationDriversLicense
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
        var model = new NaturalPersonIdentificationDriversLicense
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
        var model = new NaturalPersonIdentificationDriversLicense
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
        var model = new NaturalPersonIdentificationDriversLicense
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
        var model = new NaturalPersonIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        NaturalPersonIdentificationDriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NaturalPersonIdentificationOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NaturalPersonIdentificationOther
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
        var model = new NaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentificationOther>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentificationOther>(
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
        var model = new NaturalPersonIdentificationOther
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
        var model = new NaturalPersonIdentificationOther
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
        var model = new NaturalPersonIdentificationOther
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
        var model = new NaturalPersonIdentificationOther
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
        var model = new NaturalPersonIdentificationOther
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
        var model = new NaturalPersonIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        NaturalPersonIdentificationOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NaturalPersonIdentificationPassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NaturalPersonIdentificationPassport
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
        var model = new NaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentificationPassport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NaturalPersonIdentificationPassport>(
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
        var model = new NaturalPersonIdentificationPassport
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
        var model = new NaturalPersonIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        NaturalPersonIdentificationPassport copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RiskRatingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Rating.Low,
        };

        DateTimeOffset expectedRatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Rating> expectedRating = Rating.Low;

        Assert.Equal(expectedRatedAt, model.RatedAt);
        Assert.Equal(expectedRating, model.Rating);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Rating.Low,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RiskRating>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Rating.Low,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RiskRating>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedRatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Rating> expectedRating = Rating.Low;

        Assert.Equal(expectedRatedAt, deserialized.RatedAt);
        Assert.Equal(expectedRating, deserialized.Rating);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Rating.Low,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Rating.Low,
        };

        RiskRating copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RatingTest : TestBase
{
    [Theory]
    [InlineData(Rating.Low)]
    [InlineData(Rating.Medium)]
    [InlineData(Rating.High)]
    public void Validation_Works(Rating rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Rating> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Rating>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Rating.Low)]
    [InlineData(Rating.Medium)]
    [InlineData(Rating.High)]
    public void SerializationRoundtrip_Works(Rating rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Rating> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Rating>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Rating>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Rating>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SupplementalDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SupplementalDocument { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, model.FileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SupplementalDocument { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SupplementalDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SupplementalDocument { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SupplementalDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, deserialized.FileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SupplementalDocument { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SupplementalDocument { FileID = "file_id" };

        SupplementalDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TermsAgreementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TermsAgreement
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
        var model = new TermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TermsAgreement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TermsAgreement>(
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
        var model = new TermsAgreement
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
        var model = new TermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "x",
            TermsUrl = "x",
        };

        TermsAgreement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThirdPartyVerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThirdPartyVerification { Reference = "x", Vendor = Vendor.Alloy };

        string expectedReference = "x";
        ApiEnum<string, Vendor> expectedVendor = Vendor.Alloy;

        Assert.Equal(expectedReference, model.Reference);
        Assert.Equal(expectedVendor, model.Vendor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThirdPartyVerification { Reference = "x", Vendor = Vendor.Alloy };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThirdPartyVerification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThirdPartyVerification { Reference = "x", Vendor = Vendor.Alloy };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThirdPartyVerification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReference = "x";
        ApiEnum<string, Vendor> expectedVendor = Vendor.Alloy;

        Assert.Equal(expectedReference, deserialized.Reference);
        Assert.Equal(expectedVendor, deserialized.Vendor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThirdPartyVerification { Reference = "x", Vendor = Vendor.Alloy };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThirdPartyVerification { Reference = "x", Vendor = Vendor.Alloy };

        ThirdPartyVerification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VendorTest : TestBase
{
    [Theory]
    [InlineData(Vendor.Alloy)]
    [InlineData(Vendor.Middesk)]
    [InlineData(Vendor.Oscilar)]
    [InlineData(Vendor.Persona)]
    [InlineData(Vendor.Taktile)]
    public void Validation_Works(Vendor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Vendor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Vendor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Vendor.Alloy)]
    [InlineData(Vendor.Middesk)]
    [InlineData(Vendor.Oscilar)]
    [InlineData(Vendor.Persona)]
    [InlineData(Vendor.Taktile)]
    public void SerializationRoundtrip_Works(Vendor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Vendor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Vendor>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Vendor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Vendor>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrustTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "x",
            Grantor = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            TaxIdentifier = "x",
        };

        TrustAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        ApiEnum<string, TrustCategory> expectedCategory = TrustCategory.Revocable;
        string expectedName = "x";
        List<Trustee> expectedTrustees =
        [
            new()
            {
                Structure = TrusteeStructure.Individual,
                Individual = new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            },
        ];
        string expectedFormationDocumentFileID = "formation_document_file_id";
        string expectedFormationState = "x";
        Grantor expectedGrantor = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };
        string expectedTaxIdentifier = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTrustees.Count, model.Trustees.Count);
        for (int i = 0; i < expectedTrustees.Count; i++)
        {
            Assert.Equal(expectedTrustees[i], model.Trustees[i]);
        }
        Assert.Equal(expectedFormationDocumentFileID, model.FormationDocumentFileID);
        Assert.Equal(expectedFormationState, model.FormationState);
        Assert.Equal(expectedGrantor, model.Grantor);
        Assert.Equal(expectedTaxIdentifier, model.TaxIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "x",
            Grantor = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            TaxIdentifier = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trust>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "x",
            Grantor = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            TaxIdentifier = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trust>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        TrustAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        ApiEnum<string, TrustCategory> expectedCategory = TrustCategory.Revocable;
        string expectedName = "x";
        List<Trustee> expectedTrustees =
        [
            new()
            {
                Structure = TrusteeStructure.Individual,
                Individual = new()
                {
                    Address = new()
                    {
                        City = "x",
                        Line1 = "x",
                        State = "x",
                        Zip = "x",
                        Line2 = "x",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                    ConfirmedNoUsTaxID = true,
                },
            },
        ];
        string expectedFormationDocumentFileID = "formation_document_file_id";
        string expectedFormationState = "x";
        Grantor expectedGrantor = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };
        string expectedTaxIdentifier = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTrustees.Count, deserialized.Trustees.Count);
        for (int i = 0; i < expectedTrustees.Count; i++)
        {
            Assert.Equal(expectedTrustees[i], deserialized.Trustees[i]);
        }
        Assert.Equal(expectedFormationDocumentFileID, deserialized.FormationDocumentFileID);
        Assert.Equal(expectedFormationState, deserialized.FormationState);
        Assert.Equal(expectedGrantor, deserialized.Grantor);
        Assert.Equal(expectedTaxIdentifier, deserialized.TaxIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "x",
            Grantor = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            TaxIdentifier = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
        };

        Assert.Null(model.FormationDocumentFileID);
        Assert.False(model.RawData.ContainsKey("formation_document_file_id"));
        Assert.Null(model.FormationState);
        Assert.False(model.RawData.ContainsKey("formation_state"));
        Assert.Null(model.Grantor);
        Assert.False(model.RawData.ContainsKey("grantor"));
        Assert.Null(model.TaxIdentifier);
        Assert.False(model.RawData.ContainsKey("tax_identifier"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            FormationDocumentFileID = null,
            FormationState = null,
            Grantor = null,
            TaxIdentifier = null,
        };

        Assert.Null(model.FormationDocumentFileID);
        Assert.False(model.RawData.ContainsKey("formation_document_file_id"));
        Assert.Null(model.FormationState);
        Assert.False(model.RawData.ContainsKey("formation_state"));
        Assert.Null(model.Grantor);
        Assert.False(model.RawData.ContainsKey("grantor"));
        Assert.Null(model.TaxIdentifier);
        Assert.False(model.RawData.ContainsKey("tax_identifier"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            FormationDocumentFileID = null,
            FormationState = null,
            Grantor = null,
            TaxIdentifier = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Trust
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Category = TrustCategory.Revocable,
            Name = "x",
            Trustees =
            [
                new()
                {
                    Structure = TrusteeStructure.Individual,
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "x",
                            Line1 = "x",
                            State = "x",
                            Zip = "x",
                            Line2 = "x",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                        ConfirmedNoUsTaxID = true,
                    },
                },
            ],
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "x",
            Grantor = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
            TaxIdentifier = "x",
        };

        Trust copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrustAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrustAddress
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
        var model = new TrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrustAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrustAddress>(
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
        var model = new TrustAddress
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
        var model = new TrustAddress
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
        var model = new TrustAddress
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
        var model = new TrustAddress
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
        var model = new TrustAddress
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
        var model = new TrustAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        TrustAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrustCategoryTest : TestBase
{
    [Theory]
    [InlineData(TrustCategory.Revocable)]
    [InlineData(TrustCategory.Irrevocable)]
    public void Validation_Works(TrustCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrustCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrustCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrustCategory.Revocable)]
    [InlineData(TrustCategory.Irrevocable)]
    public void SerializationRoundtrip_Works(TrustCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrustCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrustCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrustCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrustCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrusteeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,
            Individual = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        };

        ApiEnum<string, TrusteeStructure> expectedStructure = TrusteeStructure.Individual;
        TrusteeIndividual expectedIndividual = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        Assert.Equal(expectedStructure, model.Structure);
        Assert.Equal(expectedIndividual, model.Individual);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,
            Individual = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trustee>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,
            Individual = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trustee>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TrusteeStructure> expectedStructure = TrusteeStructure.Individual;
        TrusteeIndividual expectedIndividual = new()
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        Assert.Equal(expectedStructure, deserialized.Structure);
        Assert.Equal(expectedIndividual, deserialized.Individual);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,
            Individual = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trustee { Structure = TrusteeStructure.Individual };

        Assert.Null(model.Individual);
        Assert.False(model.RawData.ContainsKey("individual"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Trustee { Structure = TrusteeStructure.Individual };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,

            // Null should be interpreted as omitted for these properties
            Individual = null,
        };

        Assert.Null(model.Individual);
        Assert.False(model.RawData.ContainsKey("individual"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,

            // Null should be interpreted as omitted for these properties
            Individual = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Trustee
        {
            Structure = TrusteeStructure.Individual,
            Individual = new()
            {
                Address = new()
                {
                    City = "x",
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
                ConfirmedNoUsTaxID = true,
            },
        };

        Trustee copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrusteeStructureTest : TestBase
{
    [Theory]
    [InlineData(TrusteeStructure.Individual)]
    public void Validation_Works(TrusteeStructure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrusteeStructure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrusteeStructure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrusteeStructure.Individual)]
    public void SerializationRoundtrip_Works(TrusteeStructure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrusteeStructure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrusteeStructure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrusteeStructure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrusteeStructure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrusteeIndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        TrusteeIndividualAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        TrusteeIndividualIdentification expectedIdentification = new()
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, model.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividual>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividual>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TrusteeIndividualAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        TrusteeIndividualIdentification expectedIdentification = new()
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, deserialized.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TrusteeIndividual
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        TrusteeIndividual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrusteeIndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrusteeIndividualAddress
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
        var model = new TrusteeIndividualAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrusteeIndividualAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualAddress>(
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
        var model = new TrusteeIndividualAddress
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
        var model = new TrusteeIndividualAddress
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
        var model = new TrusteeIndividualAddress
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
        var model = new TrusteeIndividualAddress
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
        var model = new TrusteeIndividualAddress
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
        var model = new TrusteeIndividualAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        TrusteeIndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrusteeIndividualIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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

        ApiEnum<string, TrusteeIndividualIdentificationMethod> expectedMethod =
            TrusteeIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        TrusteeIndividualIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        TrusteeIndividualIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        TrusteeIndividualIdentificationPassport expectedPassport = new()
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
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TrusteeIndividualIdentificationMethod> expectedMethod =
            TrusteeIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        TrusteeIndividualIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        TrusteeIndividualIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        TrusteeIndividualIdentificationPassport expectedPassport = new()
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
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new TrusteeIndividualIdentification
        {
            Method = TrusteeIndividualIdentificationMethod.SocialSecurityNumber,
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

        TrusteeIndividualIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrusteeIndividualIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(TrusteeIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(TrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(TrusteeIndividualIdentificationMethod.Passport)]
    [InlineData(TrusteeIndividualIdentificationMethod.DriversLicense)]
    [InlineData(TrusteeIndividualIdentificationMethod.Other)]
    public void Validation_Works(TrusteeIndividualIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrusteeIndividualIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TrusteeIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrusteeIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(TrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(TrusteeIndividualIdentificationMethod.Passport)]
    [InlineData(TrusteeIndividualIdentificationMethod.DriversLicense)]
    [InlineData(TrusteeIndividualIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(TrusteeIndividualIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrusteeIndividualIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TrusteeIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TrusteeIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TrusteeIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TrusteeIndividualIdentificationDriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrusteeIndividualIdentificationDriversLicense
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
        var model = new TrusteeIndividualIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TrusteeIndividualIdentificationDriversLicense>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrusteeIndividualIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TrusteeIndividualIdentificationDriversLicense>(
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
        var model = new TrusteeIndividualIdentificationDriversLicense
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
        var model = new TrusteeIndividualIdentificationDriversLicense
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
        var model = new TrusteeIndividualIdentificationDriversLicense
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
        var model = new TrusteeIndividualIdentificationDriversLicense
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
        var model = new TrusteeIndividualIdentificationDriversLicense
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
        var model = new TrusteeIndividualIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        TrusteeIndividualIdentificationDriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrusteeIndividualIdentificationOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrusteeIndividualIdentificationOther
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
        var model = new TrusteeIndividualIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualIdentificationOther>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrusteeIndividualIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualIdentificationOther>(
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
        var model = new TrusteeIndividualIdentificationOther
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
        var model = new TrusteeIndividualIdentificationOther
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
        var model = new TrusteeIndividualIdentificationOther
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
        var model = new TrusteeIndividualIdentificationOther
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
        var model = new TrusteeIndividualIdentificationOther
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
        var model = new TrusteeIndividualIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        TrusteeIndividualIdentificationOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrusteeIndividualIdentificationPassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrusteeIndividualIdentificationPassport
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
        var model = new TrusteeIndividualIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualIdentificationPassport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrusteeIndividualIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrusteeIndividualIdentificationPassport>(
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
        var model = new TrusteeIndividualIdentificationPassport
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
        var model = new TrusteeIndividualIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        TrusteeIndividualIdentificationPassport copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        GrantorAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        GrantorIdentification expectedIdentification = new()
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, model.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Grantor>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Grantor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        GrantorAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedDateOfBirth = "2019-12-27";
        GrantorIdentification expectedIdentification = new()
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        bool expectedConfirmedNoUsTaxID = true;

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedConfirmedNoUsTaxID, deserialized.ConfirmedNoUsTaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        Assert.Null(model.ConfirmedNoUsTaxID);
        Assert.False(model.RawData.ContainsKey("confirmed_no_us_tax_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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

            // Null should be interpreted as omitted for these properties
            ConfirmedNoUsTaxID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Grantor
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
            ConfirmedNoUsTaxID = true,
        };

        Grantor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantorAddress
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
        var model = new GrantorAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantorAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorAddress>(
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
        var model = new GrantorAddress
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
        var model = new GrantorAddress
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
        var model = new GrantorAddress
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
        var model = new GrantorAddress
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
        var model = new GrantorAddress
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
        var model = new GrantorAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        GrantorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantorIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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

        ApiEnum<string, GrantorIdentificationMethod> expectedMethod =
            GrantorIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        GrantorIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        GrantorIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        GrantorIdentificationPassport expectedPassport = new()
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
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<GrantorIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<GrantorIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, GrantorIdentificationMethod> expectedMethod =
            GrantorIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        GrantorIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        GrantorIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        GrantorIdentificationPassport expectedPassport = new()
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
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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
        var model = new GrantorIdentification
        {
            Method = GrantorIdentificationMethod.SocialSecurityNumber,
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

        GrantorIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantorIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(GrantorIdentificationMethod.SocialSecurityNumber)]
    [InlineData(GrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(GrantorIdentificationMethod.Passport)]
    [InlineData(GrantorIdentificationMethod.DriversLicense)]
    [InlineData(GrantorIdentificationMethod.Other)]
    public void Validation_Works(GrantorIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantorIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantorIdentificationMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantorIdentificationMethod.SocialSecurityNumber)]
    [InlineData(GrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber)]
    [InlineData(GrantorIdentificationMethod.Passport)]
    [InlineData(GrantorIdentificationMethod.DriversLicense)]
    [InlineData(GrantorIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(GrantorIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantorIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantorIdentificationMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantorIdentificationMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantorIdentificationMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GrantorIdentificationDriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantorIdentificationDriversLicense
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
        var model = new GrantorIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorIdentificationDriversLicense>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantorIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorIdentificationDriversLicense>(
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
        var model = new GrantorIdentificationDriversLicense
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
        var model = new GrantorIdentificationDriversLicense
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
        var model = new GrantorIdentificationDriversLicense
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
        var model = new GrantorIdentificationDriversLicense
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
        var model = new GrantorIdentificationDriversLicense
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
        var model = new GrantorIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        GrantorIdentificationDriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantorIdentificationOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantorIdentificationOther
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
        var model = new GrantorIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorIdentificationOther>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantorIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorIdentificationOther>(
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
        var model = new GrantorIdentificationOther
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
        var model = new GrantorIdentificationOther
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
        var model = new GrantorIdentificationOther
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
        var model = new GrantorIdentificationOther
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
        var model = new GrantorIdentificationOther
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
        var model = new GrantorIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        GrantorIdentificationOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantorIdentificationPassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantorIdentificationPassport
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
        var model = new GrantorIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorIdentificationPassport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantorIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantorIdentificationPassport>(
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
        var model = new GrantorIdentificationPassport
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
        var model = new GrantorIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        GrantorIdentificationPassport copied = new(model);

        Assert.Equal(model, copied);
    }
}
