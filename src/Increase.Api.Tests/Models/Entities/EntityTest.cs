using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Entities = Increase.Api.Models.Entities;
using SupplementalDocuments = Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Tests.Models.Entities;

public class EntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::Entity
        {
            ID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                        CompanyTitle = "CEO",
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "US",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "1120",
                            },
                            Name = "Ian Crease",
                        },
                        Prongs =
                        [
                            Entities::EntityCorporationBeneficialOwnerProng.Control,
                            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                        ],
                    },
                ],
                Email = null,
                IncorporationState = "NY",
                IndustryCode = null,
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                Website = "https://example.com",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = null,
            DetailsConfirmedAt = null,
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                AuthorizedPersons =
                [
                    new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
                ],
                Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Website = "website",
            },
            IdempotencyKey = null,
            Joint = new()
            {
                Individuals =
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                ],
                Name = "name",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Entities::EntityRiskRatingRating.Low,
            },
            Status = Entities::EntityStatus.Active,
            Structure = Entities::EntityStructure.Corporation,
            SupplementalDocuments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IPAddress = "128.32.0.1",
                    TermsUrl = "https://increase.com/example_terms",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "reference",
                Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                Category = Entities::EntityTrustCategory.Revocable,
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "formation_state",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Trustees =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "number_last4",
                            },
                            Name = "name",
                        },
                        Structure = Entities::EntityTrustTrusteeStructure.Individual,
                    },
                ],
            },
            Type = Entities::Type.Entity,
            Validation = new()
            {
                Issues =
                [
                    new()
                    {
                        BeneficialOwnerAddress = new()
                        {
                            BeneficialOwnerID = "beneficial_owner_id",
                            Reason = Entities::Reason.MailboxAddress,
                        },
                        BeneficialOwnerIdentity = new("beneficial_owner_id"),
                        Category = Entities::IssueCategory.EntityTaxIdentifier,
                        EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                        EntityTaxIdentifier = new(),
                    },
                ],
                Status = Entities::ValidationStatus.Pending,
            },
        };

        string expectedID = "entity_n8y8tnk2p9339ti393yi";
        Entities::EntityCorporation expectedCorporation = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = null,
            IncorporationState = "NY",
            IndustryCode = null,
            Name = "National Phonograph Company",
            TaxIdentifier = "602214076",
            Website = "https://example.com",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        Entities::EntityGovernmentAuthority expectedGovernmentAuthority = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };
        Entities::EntityJoint expectedJoint = new()
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };
        Entities::EntityNaturalPerson expectedNaturalPerson = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };
        Entities::EntityRiskRating expectedRiskRating = new()
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };
        ApiEnum<string, Entities::EntityStatus> expectedStatus = Entities::EntityStatus.Active;
        ApiEnum<string, Entities::EntityStructure> expectedStructure =
            Entities::EntityStructure.Corporation;
        List<SupplementalDocuments::EntitySupplementalDocument> expectedSupplementalDocuments =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                FileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                Type = SupplementalDocuments::Type.EntitySupplementalDocument,
            },
        ];
        List<Entities::EntityTermsAgreement> expectedTermsAgreements =
        [
            new()
            {
                AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IPAddress = "128.32.0.1",
                TermsUrl = "https://increase.com/example_terms",
            },
        ];
        Entities::EntityThirdPartyVerification expectedThirdPartyVerification = new()
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };
        Entities::EntityTrust expectedTrust = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };
        ApiEnum<string, Entities::Type> expectedType = Entities::Type.Entity;
        Entities::Validation expectedValidation = new()
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCorporation, model.Corporation);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.Description);
        Assert.Null(model.DetailsConfirmedAt);
        Assert.Equal(expectedGovernmentAuthority, model.GovernmentAuthority);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedJoint, model.Joint);
        Assert.Equal(expectedNaturalPerson, model.NaturalPerson);
        Assert.Equal(expectedRiskRating, model.RiskRating);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStructure, model.Structure);
        Assert.Equal(expectedSupplementalDocuments.Count, model.SupplementalDocuments.Count);
        for (int i = 0; i < expectedSupplementalDocuments.Count; i++)
        {
            Assert.Equal(expectedSupplementalDocuments[i], model.SupplementalDocuments[i]);
        }
        Assert.Equal(expectedTermsAgreements.Count, model.TermsAgreements.Count);
        for (int i = 0; i < expectedTermsAgreements.Count; i++)
        {
            Assert.Equal(expectedTermsAgreements[i], model.TermsAgreements[i]);
        }
        Assert.Equal(expectedThirdPartyVerification, model.ThirdPartyVerification);
        Assert.Equal(expectedTrust, model.Trust);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValidation, model.Validation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::Entity
        {
            ID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                        CompanyTitle = "CEO",
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "US",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "1120",
                            },
                            Name = "Ian Crease",
                        },
                        Prongs =
                        [
                            Entities::EntityCorporationBeneficialOwnerProng.Control,
                            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                        ],
                    },
                ],
                Email = null,
                IncorporationState = "NY",
                IndustryCode = null,
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                Website = "https://example.com",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = null,
            DetailsConfirmedAt = null,
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                AuthorizedPersons =
                [
                    new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
                ],
                Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Website = "website",
            },
            IdempotencyKey = null,
            Joint = new()
            {
                Individuals =
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                ],
                Name = "name",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Entities::EntityRiskRatingRating.Low,
            },
            Status = Entities::EntityStatus.Active,
            Structure = Entities::EntityStructure.Corporation,
            SupplementalDocuments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IPAddress = "128.32.0.1",
                    TermsUrl = "https://increase.com/example_terms",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "reference",
                Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                Category = Entities::EntityTrustCategory.Revocable,
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "formation_state",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Trustees =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "number_last4",
                            },
                            Name = "name",
                        },
                        Structure = Entities::EntityTrustTrusteeStructure.Individual,
                    },
                ],
            },
            Type = Entities::Type.Entity,
            Validation = new()
            {
                Issues =
                [
                    new()
                    {
                        BeneficialOwnerAddress = new()
                        {
                            BeneficialOwnerID = "beneficial_owner_id",
                            Reason = Entities::Reason.MailboxAddress,
                        },
                        BeneficialOwnerIdentity = new("beneficial_owner_id"),
                        Category = Entities::IssueCategory.EntityTaxIdentifier,
                        EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                        EntityTaxIdentifier = new(),
                    },
                ],
                Status = Entities::ValidationStatus.Pending,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::Entity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::Entity
        {
            ID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                        CompanyTitle = "CEO",
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "US",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "1120",
                            },
                            Name = "Ian Crease",
                        },
                        Prongs =
                        [
                            Entities::EntityCorporationBeneficialOwnerProng.Control,
                            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                        ],
                    },
                ],
                Email = null,
                IncorporationState = "NY",
                IndustryCode = null,
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                Website = "https://example.com",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = null,
            DetailsConfirmedAt = null,
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                AuthorizedPersons =
                [
                    new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
                ],
                Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Website = "website",
            },
            IdempotencyKey = null,
            Joint = new()
            {
                Individuals =
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                ],
                Name = "name",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Entities::EntityRiskRatingRating.Low,
            },
            Status = Entities::EntityStatus.Active,
            Structure = Entities::EntityStructure.Corporation,
            SupplementalDocuments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IPAddress = "128.32.0.1",
                    TermsUrl = "https://increase.com/example_terms",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "reference",
                Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                Category = Entities::EntityTrustCategory.Revocable,
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "formation_state",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Trustees =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "number_last4",
                            },
                            Name = "name",
                        },
                        Structure = Entities::EntityTrustTrusteeStructure.Individual,
                    },
                ],
            },
            Type = Entities::Type.Entity,
            Validation = new()
            {
                Issues =
                [
                    new()
                    {
                        BeneficialOwnerAddress = new()
                        {
                            BeneficialOwnerID = "beneficial_owner_id",
                            Reason = Entities::Reason.MailboxAddress,
                        },
                        BeneficialOwnerIdentity = new("beneficial_owner_id"),
                        Category = Entities::IssueCategory.EntityTaxIdentifier,
                        EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                        EntityTaxIdentifier = new(),
                    },
                ],
                Status = Entities::ValidationStatus.Pending,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::Entity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "entity_n8y8tnk2p9339ti393yi";
        Entities::EntityCorporation expectedCorporation = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = null,
            IncorporationState = "NY",
            IndustryCode = null,
            Name = "National Phonograph Company",
            TaxIdentifier = "602214076",
            Website = "https://example.com",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        Entities::EntityGovernmentAuthority expectedGovernmentAuthority = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };
        Entities::EntityJoint expectedJoint = new()
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };
        Entities::EntityNaturalPerson expectedNaturalPerson = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };
        Entities::EntityRiskRating expectedRiskRating = new()
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };
        ApiEnum<string, Entities::EntityStatus> expectedStatus = Entities::EntityStatus.Active;
        ApiEnum<string, Entities::EntityStructure> expectedStructure =
            Entities::EntityStructure.Corporation;
        List<SupplementalDocuments::EntitySupplementalDocument> expectedSupplementalDocuments =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                FileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                Type = SupplementalDocuments::Type.EntitySupplementalDocument,
            },
        ];
        List<Entities::EntityTermsAgreement> expectedTermsAgreements =
        [
            new()
            {
                AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IPAddress = "128.32.0.1",
                TermsUrl = "https://increase.com/example_terms",
            },
        ];
        Entities::EntityThirdPartyVerification expectedThirdPartyVerification = new()
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };
        Entities::EntityTrust expectedTrust = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };
        ApiEnum<string, Entities::Type> expectedType = Entities::Type.Entity;
        Entities::Validation expectedValidation = new()
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCorporation, deserialized.Corporation);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.Description);
        Assert.Null(deserialized.DetailsConfirmedAt);
        Assert.Equal(expectedGovernmentAuthority, deserialized.GovernmentAuthority);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedJoint, deserialized.Joint);
        Assert.Equal(expectedNaturalPerson, deserialized.NaturalPerson);
        Assert.Equal(expectedRiskRating, deserialized.RiskRating);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStructure, deserialized.Structure);
        Assert.Equal(expectedSupplementalDocuments.Count, deserialized.SupplementalDocuments.Count);
        for (int i = 0; i < expectedSupplementalDocuments.Count; i++)
        {
            Assert.Equal(expectedSupplementalDocuments[i], deserialized.SupplementalDocuments[i]);
        }
        Assert.Equal(expectedTermsAgreements.Count, deserialized.TermsAgreements.Count);
        for (int i = 0; i < expectedTermsAgreements.Count; i++)
        {
            Assert.Equal(expectedTermsAgreements[i], deserialized.TermsAgreements[i]);
        }
        Assert.Equal(expectedThirdPartyVerification, deserialized.ThirdPartyVerification);
        Assert.Equal(expectedTrust, deserialized.Trust);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValidation, deserialized.Validation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::Entity
        {
            ID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                        CompanyTitle = "CEO",
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "US",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "1120",
                            },
                            Name = "Ian Crease",
                        },
                        Prongs =
                        [
                            Entities::EntityCorporationBeneficialOwnerProng.Control,
                            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                        ],
                    },
                ],
                Email = null,
                IncorporationState = "NY",
                IndustryCode = null,
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                Website = "https://example.com",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = null,
            DetailsConfirmedAt = null,
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                AuthorizedPersons =
                [
                    new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
                ],
                Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Website = "website",
            },
            IdempotencyKey = null,
            Joint = new()
            {
                Individuals =
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                ],
                Name = "name",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Entities::EntityRiskRatingRating.Low,
            },
            Status = Entities::EntityStatus.Active,
            Structure = Entities::EntityStructure.Corporation,
            SupplementalDocuments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IPAddress = "128.32.0.1",
                    TermsUrl = "https://increase.com/example_terms",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "reference",
                Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                Category = Entities::EntityTrustCategory.Revocable,
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "formation_state",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Trustees =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "number_last4",
                            },
                            Name = "name",
                        },
                        Structure = Entities::EntityTrustTrusteeStructure.Individual,
                    },
                ],
            },
            Type = Entities::Type.Entity,
            Validation = new()
            {
                Issues =
                [
                    new()
                    {
                        BeneficialOwnerAddress = new()
                        {
                            BeneficialOwnerID = "beneficial_owner_id",
                            Reason = Entities::Reason.MailboxAddress,
                        },
                        BeneficialOwnerIdentity = new("beneficial_owner_id"),
                        Category = Entities::IssueCategory.EntityTaxIdentifier,
                        EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                        EntityTaxIdentifier = new(),
                    },
                ],
                Status = Entities::ValidationStatus.Pending,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::Entity
        {
            ID = "entity_n8y8tnk2p9339ti393yi",
            Corporation = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                BeneficialOwners =
                [
                    new()
                    {
                        ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                        CompanyTitle = "CEO",
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Country = "US",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "1970-01-31",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "1120",
                            },
                            Name = "Ian Crease",
                        },
                        Prongs =
                        [
                            Entities::EntityCorporationBeneficialOwnerProng.Control,
                            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                        ],
                    },
                ],
                Email = null,
                IncorporationState = "NY",
                IndustryCode = null,
                Name = "National Phonograph Company",
                TaxIdentifier = "602214076",
                Website = "https://example.com",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = null,
            DetailsConfirmedAt = null,
            GovernmentAuthority = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                AuthorizedPersons =
                [
                    new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
                ],
                Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Website = "website",
            },
            IdempotencyKey = null,
            Joint = new()
            {
                Individuals =
                [
                    new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                ],
                Name = "name",
            },
            NaturalPerson = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Rating = Entities::EntityRiskRatingRating.Low,
            },
            Status = Entities::EntityStatus.Active,
            Structure = Entities::EntityStructure.Corporation,
            SupplementalDocuments =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            TermsAgreements =
            [
                new()
                {
                    AgreedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IPAddress = "128.32.0.1",
                    TermsUrl = "https://increase.com/example_terms",
                },
            ],
            ThirdPartyVerification = new()
            {
                Reference = "reference",
                Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
            },
            Trust = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                Category = Entities::EntityTrustCategory.Revocable,
                FormationDocumentFileID = "formation_document_file_id",
                FormationState = "formation_state",
                Grantor = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Name = "name",
                TaxIdentifier = "tax_identifier",
                Trustees =
                [
                    new()
                    {
                        Individual = new()
                        {
                            Address = new()
                            {
                                City = "New York",
                                Line1 = "33 Liberty Street",
                                Line2 = null,
                                State = "NY",
                                Zip = "10045",
                            },
                            DateOfBirth = "2019-12-27",
                            Identification = new()
                            {
                                Method =
                                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                                NumberLast4 = "number_last4",
                            },
                            Name = "name",
                        },
                        Structure = Entities::EntityTrustTrusteeStructure.Individual,
                    },
                ],
            },
            Type = Entities::Type.Entity,
            Validation = new()
            {
                Issues =
                [
                    new()
                    {
                        BeneficialOwnerAddress = new()
                        {
                            BeneficialOwnerID = "beneficial_owner_id",
                            Reason = Entities::Reason.MailboxAddress,
                        },
                        BeneficialOwnerIdentity = new("beneficial_owner_id"),
                        Category = Entities::IssueCategory.EntityTaxIdentifier,
                        EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                        EntityTaxIdentifier = new(),
                    },
                ],
                Status = Entities::ValidationStatus.Pending,
            },
        };

        Entities::Entity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityCorporation
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = "email",
            IncorporationState = "incorporation_state",
            IndustryCode = "industry_code",
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        Entities::EntityCorporationAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        List<Entities::EntityCorporationBeneficialOwner> expectedBeneficialOwners =
        [
            new()
            {
                ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                CompanyTitle = "CEO",
                Individual = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "1970-01-31",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "1120",
                    },
                    Name = "Ian Crease",
                },
                Prongs =
                [
                    Entities::EntityCorporationBeneficialOwnerProng.Control,
                    Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                ],
            },
        ];
        string expectedEmail = "email";
        string expectedIncorporationState = "incorporation_state";
        string expectedIndustryCode = "industry_code";
        string expectedName = "name";
        string expectedTaxIdentifier = "tax_identifier";
        string expectedWebsite = "website";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedBeneficialOwners.Count, model.BeneficialOwners.Count);
        for (int i = 0; i < expectedBeneficialOwners.Count; i++)
        {
            Assert.Equal(expectedBeneficialOwners[i], model.BeneficialOwners[i]);
        }
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedIncorporationState, model.IncorporationState);
        Assert.Equal(expectedIndustryCode, model.IndustryCode);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTaxIdentifier, model.TaxIdentifier);
        Assert.Equal(expectedWebsite, model.Website);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityCorporation
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = "email",
            IncorporationState = "incorporation_state",
            IndustryCode = "industry_code",
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityCorporation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityCorporation
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = "email",
            IncorporationState = "incorporation_state",
            IndustryCode = "industry_code",
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityCorporation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityCorporationAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        List<Entities::EntityCorporationBeneficialOwner> expectedBeneficialOwners =
        [
            new()
            {
                ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                CompanyTitle = "CEO",
                Individual = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "1970-01-31",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "1120",
                    },
                    Name = "Ian Crease",
                },
                Prongs =
                [
                    Entities::EntityCorporationBeneficialOwnerProng.Control,
                    Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                ],
            },
        ];
        string expectedEmail = "email";
        string expectedIncorporationState = "incorporation_state";
        string expectedIndustryCode = "industry_code";
        string expectedName = "name";
        string expectedTaxIdentifier = "tax_identifier";
        string expectedWebsite = "website";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedBeneficialOwners.Count, deserialized.BeneficialOwners.Count);
        for (int i = 0; i < expectedBeneficialOwners.Count; i++)
        {
            Assert.Equal(expectedBeneficialOwners[i], deserialized.BeneficialOwners[i]);
        }
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedIncorporationState, deserialized.IncorporationState);
        Assert.Equal(expectedIndustryCode, deserialized.IndustryCode);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTaxIdentifier, deserialized.TaxIdentifier);
        Assert.Equal(expectedWebsite, deserialized.Website);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityCorporation
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = "email",
            IncorporationState = "incorporation_state",
            IndustryCode = "industry_code",
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityCorporation
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            BeneficialOwners =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "1970-01-31",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        Entities::EntityCorporationBeneficialOwnerProng.Control,
                        Entities::EntityCorporationBeneficialOwnerProng.Ownership,
                    ],
                },
            ],
            Email = "email",
            IncorporationState = "incorporation_state",
            IndustryCode = "industry_code",
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        Entities::EntityCorporation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityCorporationAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityCorporationAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityCorporationAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityCorporationAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityCorporationAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityCorporationAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationBeneficialOwnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwner
        {
            ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            CompanyTitle = "CEO",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "1970-01-31",
                Identification = new()
                {
                    Method =
                        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "1120",
                },
                Name = "Ian Crease",
            },
            Prongs =
            [
                Entities::EntityCorporationBeneficialOwnerProng.Control,
                Entities::EntityCorporationBeneficialOwnerProng.Ownership,
            ],
        };

        string expectedID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6";
        string expectedCompanyTitle = "CEO";
        Entities::EntityCorporationBeneficialOwnerIndividual expectedIndividual = new()
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "1970-01-31",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "1120",
            },
            Name = "Ian Crease",
        };
        List<ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng>> expectedProngs =
        [
            Entities::EntityCorporationBeneficialOwnerProng.Control,
            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompanyTitle, model.CompanyTitle);
        Assert.Equal(expectedIndividual, model.Individual);
        Assert.Equal(expectedProngs.Count, model.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], model.Prongs[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwner
        {
            ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            CompanyTitle = "CEO",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "1970-01-31",
                Identification = new()
                {
                    Method =
                        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "1120",
                },
                Name = "Ian Crease",
            },
            Prongs =
            [
                Entities::EntityCorporationBeneficialOwnerProng.Control,
                Entities::EntityCorporationBeneficialOwnerProng.Ownership,
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwner>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwner
        {
            ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            CompanyTitle = "CEO",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "1970-01-31",
                Identification = new()
                {
                    Method =
                        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "1120",
                },
                Name = "Ian Crease",
            },
            Prongs =
            [
                Entities::EntityCorporationBeneficialOwnerProng.Control,
                Entities::EntityCorporationBeneficialOwnerProng.Ownership,
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwner>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6";
        string expectedCompanyTitle = "CEO";
        Entities::EntityCorporationBeneficialOwnerIndividual expectedIndividual = new()
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "1970-01-31",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "1120",
            },
            Name = "Ian Crease",
        };
        List<ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng>> expectedProngs =
        [
            Entities::EntityCorporationBeneficialOwnerProng.Control,
            Entities::EntityCorporationBeneficialOwnerProng.Ownership,
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompanyTitle, deserialized.CompanyTitle);
        Assert.Equal(expectedIndividual, deserialized.Individual);
        Assert.Equal(expectedProngs.Count, deserialized.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], deserialized.Prongs[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwner
        {
            ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            CompanyTitle = "CEO",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "1970-01-31",
                Identification = new()
                {
                    Method =
                        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "1120",
                },
                Name = "Ian Crease",
            },
            Prongs =
            [
                Entities::EntityCorporationBeneficialOwnerProng.Control,
                Entities::EntityCorporationBeneficialOwnerProng.Ownership,
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwner
        {
            ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            CompanyTitle = "CEO",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "1970-01-31",
                Identification = new()
                {
                    Method =
                        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "1120",
                },
                Name = "Ian Crease",
            },
            Prongs =
            [
                Entities::EntityCorporationBeneficialOwnerProng.Control,
                Entities::EntityCorporationBeneficialOwnerProng.Ownership,
            ],
        };

        Entities::EntityCorporationBeneficialOwner copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationBeneficialOwnerIndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividual
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityCorporationBeneficialOwnerIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityCorporationBeneficialOwnerIndividualIdentification expectedIdentification =
            new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividual
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwnerIndividual>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividual
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwnerIndividual>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Entities::EntityCorporationBeneficialOwnerIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityCorporationBeneficialOwnerIndividualIdentification expectedIdentification =
            new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividual
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividual
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityCorporationBeneficialOwnerIndividual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationBeneficialOwnerIndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualAddress
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedCountry = "US";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualAddress
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwnerIndividualAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualAddress
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwnerIndividualAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedCountry = "US";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualAddress
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualAddress
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityCorporationBeneficialOwnerIndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationBeneficialOwnerIndividualIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualIdentification
        {
            Method =
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        ApiEnum<
            string,
            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
        > expectedMethod =
            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumberLast4, model.NumberLast4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualIdentification
        {
            Method =
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwnerIndividualIdentification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualIdentification
        {
            Method =
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityCorporationBeneficialOwnerIndividualIdentification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
        > expectedMethod =
            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumberLast4, deserialized.NumberLast4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualIdentification
        {
            Method =
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityCorporationBeneficialOwnerIndividualIdentification
        {
            Method =
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        Entities::EntityCorporationBeneficialOwnerIndividualIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityCorporationBeneficialOwnerIndividualIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber
    )]
    [InlineData(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Passport)]
    [InlineData(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.DriversLicense
    )]
    [InlineData(Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Other)]
    public void Validation_Works(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber
    )]
    [InlineData(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Passport)]
    [InlineData(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.DriversLicense
    )]
    [InlineData(Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Entities::EntityCorporationBeneficialOwnerIndividualIdentificationMethod
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityCorporationBeneficialOwnerProngTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityCorporationBeneficialOwnerProng.Ownership)]
    [InlineData(Entities::EntityCorporationBeneficialOwnerProng.Control)]
    public void Validation_Works(Entities::EntityCorporationBeneficialOwnerProng rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityCorporationBeneficialOwnerProng.Ownership)]
    [InlineData(Entities::EntityCorporationBeneficialOwnerProng.Control)]
    public void SerializationRoundtrip_Works(
        Entities::EntityCorporationBeneficialOwnerProng rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityCorporationBeneficialOwnerProng>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityGovernmentAuthorityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityGovernmentAuthority
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        Entities::EntityGovernmentAuthorityAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        List<Entities::EntityGovernmentAuthorityAuthorizedPerson> expectedAuthorizedPersons =
        [
            new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
        ];
        ApiEnum<string, Entities::EntityGovernmentAuthorityCategory> expectedCategory =
            Entities::EntityGovernmentAuthorityCategory.Municipality;
        string expectedName = "name";
        string expectedTaxIdentifier = "tax_identifier";
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
        var model = new Entities::EntityGovernmentAuthority
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityGovernmentAuthority>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityGovernmentAuthority
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityGovernmentAuthority>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityGovernmentAuthorityAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        List<Entities::EntityGovernmentAuthorityAuthorizedPerson> expectedAuthorizedPersons =
        [
            new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
        ];
        ApiEnum<string, Entities::EntityGovernmentAuthorityCategory> expectedCategory =
            Entities::EntityGovernmentAuthorityCategory.Municipality;
        string expectedName = "name";
        string expectedTaxIdentifier = "tax_identifier";
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
        var model = new Entities::EntityGovernmentAuthority
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityGovernmentAuthority
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            AuthorizedPersons =
            [
                new() { AuthorizedPersonID = "authorized_person_id", Name = "name" },
            ],
            Category = Entities::EntityGovernmentAuthorityCategory.Municipality,
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Website = "website",
        };

        Entities::EntityGovernmentAuthority copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityGovernmentAuthorityAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityGovernmentAuthorityAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityGovernmentAuthorityAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityGovernmentAuthorityAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityGovernmentAuthorityAuthorizedPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAuthorizedPerson
        {
            AuthorizedPersonID = "authorized_person_id",
            Name = "name",
        };

        string expectedAuthorizedPersonID = "authorized_person_id";
        string expectedName = "name";

        Assert.Equal(expectedAuthorizedPersonID, model.AuthorizedPersonID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAuthorizedPerson
        {
            AuthorizedPersonID = "authorized_person_id",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityGovernmentAuthorityAuthorizedPerson>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAuthorizedPerson
        {
            AuthorizedPersonID = "authorized_person_id",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityGovernmentAuthorityAuthorizedPerson>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAuthorizedPersonID = "authorized_person_id";
        string expectedName = "name";

        Assert.Equal(expectedAuthorizedPersonID, deserialized.AuthorizedPersonID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAuthorizedPerson
        {
            AuthorizedPersonID = "authorized_person_id",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityGovernmentAuthorityAuthorizedPerson
        {
            AuthorizedPersonID = "authorized_person_id",
            Name = "name",
        };

        Entities::EntityGovernmentAuthorityAuthorizedPerson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityGovernmentAuthorityCategoryTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.Municipality)]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.StateAgency)]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.StateGovernment)]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.FederalAgency)]
    public void Validation_Works(Entities::EntityGovernmentAuthorityCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityGovernmentAuthorityCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityGovernmentAuthorityCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.Municipality)]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.StateAgency)]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.StateGovernment)]
    [InlineData(Entities::EntityGovernmentAuthorityCategory.FederalAgency)]
    public void SerializationRoundtrip_Works(Entities::EntityGovernmentAuthorityCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityGovernmentAuthorityCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityGovernmentAuthorityCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityGovernmentAuthorityCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityGovernmentAuthorityCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityJointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityJoint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };

        List<Entities::EntityJointIndividual> expectedIndividuals =
        [
            new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
        ];
        string expectedName = "name";

        Assert.Equal(expectedIndividuals.Count, model.Individuals.Count);
        for (int i = 0; i < expectedIndividuals.Count; i++)
        {
            Assert.Equal(expectedIndividuals[i], model.Individuals[i]);
        }
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityJoint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityJoint>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityJoint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityJoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Entities::EntityJointIndividual> expectedIndividuals =
        [
            new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
        ];
        string expectedName = "name";

        Assert.Equal(expectedIndividuals.Count, deserialized.Individuals.Count);
        for (int i = 0; i < expectedIndividuals.Count; i++)
        {
            Assert.Equal(expectedIndividuals[i], deserialized.Individuals[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityJoint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityJoint
        {
            Individuals =
            [
                new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
            ],
            Name = "name",
        };

        Entities::EntityJoint copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityJointIndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityJointIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityJointIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityJointIndividualIdentification expectedIdentification = new()
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityJointIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityJointIndividual>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityJointIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityJointIndividual>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityJointIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityJointIndividualIdentification expectedIdentification = new()
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityJointIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityJointIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityJointIndividual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityJointIndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityJointIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityJointIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityJointIndividualAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityJointIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityJointIndividualAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityJointIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityJointIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityJointIndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityJointIndividualIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityJointIndividualIdentification
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod> expectedMethod =
            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumberLast4, model.NumberLast4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityJointIndividualIdentification
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityJointIndividualIdentification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityJointIndividualIdentification
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityJointIndividualIdentification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod> expectedMethod =
            Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumberLast4, deserialized.NumberLast4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityJointIndividualIdentification
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityJointIndividualIdentification
        {
            Method = Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        Entities::EntityJointIndividualIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityJointIndividualIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityJointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.Passport)]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.Other)]
    public void Validation_Works(Entities::EntityJointIndividualIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityJointIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.Passport)]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityJointIndividualIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        Entities::EntityJointIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityJointIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityNaturalPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityNaturalPerson
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityNaturalPersonAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityNaturalPersonIdentification expectedIdentification = new()
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityNaturalPerson
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityNaturalPerson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityNaturalPerson
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityNaturalPerson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityNaturalPersonAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityNaturalPersonIdentification expectedIdentification = new()
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityNaturalPerson
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityNaturalPerson
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityNaturalPerson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityNaturalPersonAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityNaturalPersonAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityNaturalPersonAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityNaturalPersonAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityNaturalPersonAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityNaturalPersonAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityNaturalPersonAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityNaturalPersonAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityNaturalPersonAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityNaturalPersonIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityNaturalPersonIdentification
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod> expectedMethod =
            Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumberLast4, model.NumberLast4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityNaturalPersonIdentification
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityNaturalPersonIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityNaturalPersonIdentification
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityNaturalPersonIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod> expectedMethod =
            Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumberLast4, deserialized.NumberLast4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityNaturalPersonIdentification
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityNaturalPersonIdentification
        {
            Method = Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        Entities::EntityNaturalPersonIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityNaturalPersonIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.Passport)]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.Other)]
    public void Validation_Works(Entities::EntityNaturalPersonIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityNaturalPersonIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.Passport)]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityNaturalPersonIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        Entities::EntityNaturalPersonIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityNaturalPersonIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityRiskRatingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };

        DateTimeOffset expectedRatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Entities::EntityRiskRatingRating> expectedRating =
            Entities::EntityRiskRatingRating.Low;

        Assert.Equal(expectedRatedAt, model.RatedAt);
        Assert.Equal(expectedRating, model.Rating);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityRiskRating>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityRiskRating>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedRatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Entities::EntityRiskRatingRating> expectedRating =
            Entities::EntityRiskRatingRating.Low;

        Assert.Equal(expectedRatedAt, deserialized.RatedAt);
        Assert.Equal(expectedRating, deserialized.Rating);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityRiskRating
        {
            RatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rating = Entities::EntityRiskRatingRating.Low,
        };

        Entities::EntityRiskRating copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityRiskRatingRatingTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityRiskRatingRating.Low)]
    [InlineData(Entities::EntityRiskRatingRating.Medium)]
    [InlineData(Entities::EntityRiskRatingRating.High)]
    public void Validation_Works(Entities::EntityRiskRatingRating rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityRiskRatingRating> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityRiskRatingRating>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityRiskRatingRating.Low)]
    [InlineData(Entities::EntityRiskRatingRating.Medium)]
    [InlineData(Entities::EntityRiskRatingRating.High)]
    public void SerializationRoundtrip_Works(Entities::EntityRiskRatingRating rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityRiskRatingRating> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityRiskRatingRating>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityRiskRatingRating>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityRiskRatingRating>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityStatusTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityStatus.Active)]
    [InlineData(Entities::EntityStatus.Archived)]
    [InlineData(Entities::EntityStatus.Disabled)]
    public void Validation_Works(Entities::EntityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityStatus.Active)]
    [InlineData(Entities::EntityStatus.Archived)]
    [InlineData(Entities::EntityStatus.Disabled)]
    public void SerializationRoundtrip_Works(Entities::EntityStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntityStructureTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityStructure.Corporation)]
    [InlineData(Entities::EntityStructure.NaturalPerson)]
    [InlineData(Entities::EntityStructure.Joint)]
    [InlineData(Entities::EntityStructure.Trust)]
    [InlineData(Entities::EntityStructure.GovernmentAuthority)]
    public void Validation_Works(Entities::EntityStructure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityStructure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStructure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityStructure.Corporation)]
    [InlineData(Entities::EntityStructure.NaturalPerson)]
    [InlineData(Entities::EntityStructure.Joint)]
    [InlineData(Entities::EntityStructure.Trust)]
    [InlineData(Entities::EntityStructure.GovernmentAuthority)]
    public void SerializationRoundtrip_Works(Entities::EntityStructure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityStructure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStructure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStructure>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityStructure>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntityTermsAgreementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "ip_address",
            TermsUrl = "terms_url",
        };

        DateTimeOffset expectedAgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIPAddress = "ip_address";
        string expectedTermsUrl = "terms_url";

        Assert.Equal(expectedAgreedAt, model.AgreedAt);
        Assert.Equal(expectedIPAddress, model.IPAddress);
        Assert.Equal(expectedTermsUrl, model.TermsUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "ip_address",
            TermsUrl = "terms_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTermsAgreement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "ip_address",
            TermsUrl = "terms_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTermsAgreement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIPAddress = "ip_address";
        string expectedTermsUrl = "terms_url";

        Assert.Equal(expectedAgreedAt, deserialized.AgreedAt);
        Assert.Equal(expectedIPAddress, deserialized.IPAddress);
        Assert.Equal(expectedTermsUrl, deserialized.TermsUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "ip_address",
            TermsUrl = "terms_url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTermsAgreement
        {
            AgreedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IPAddress = "ip_address",
            TermsUrl = "terms_url",
        };

        Entities::EntityTermsAgreement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityThirdPartyVerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityThirdPartyVerification
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };

        string expectedReference = "reference";
        ApiEnum<string, Entities::EntityThirdPartyVerificationVendor> expectedVendor =
            Entities::EntityThirdPartyVerificationVendor.Alloy;

        Assert.Equal(expectedReference, model.Reference);
        Assert.Equal(expectedVendor, model.Vendor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityThirdPartyVerification
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityThirdPartyVerification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityThirdPartyVerification
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityThirdPartyVerification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReference = "reference";
        ApiEnum<string, Entities::EntityThirdPartyVerificationVendor> expectedVendor =
            Entities::EntityThirdPartyVerificationVendor.Alloy;

        Assert.Equal(expectedReference, deserialized.Reference);
        Assert.Equal(expectedVendor, deserialized.Vendor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityThirdPartyVerification
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityThirdPartyVerification
        {
            Reference = "reference",
            Vendor = Entities::EntityThirdPartyVerificationVendor.Alloy,
        };

        Entities::EntityThirdPartyVerification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityThirdPartyVerificationVendorTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Alloy)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Middesk)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Oscilar)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Persona)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Taktile)]
    public void Validation_Works(Entities::EntityThirdPartyVerificationVendor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityThirdPartyVerificationVendor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityThirdPartyVerificationVendor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Alloy)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Middesk)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Oscilar)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Persona)]
    [InlineData(Entities::EntityThirdPartyVerificationVendor.Taktile)]
    public void SerializationRoundtrip_Works(Entities::EntityThirdPartyVerificationVendor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityThirdPartyVerificationVendor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityThirdPartyVerificationVendor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityThirdPartyVerificationVendor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityThirdPartyVerificationVendor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityTrustTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrust
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };

        Entities::EntityTrustAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        ApiEnum<string, Entities::EntityTrustCategory> expectedCategory =
            Entities::EntityTrustCategory.Revocable;
        string expectedFormationDocumentFileID = "formation_document_file_id";
        string expectedFormationState = "formation_state";
        Entities::EntityTrustGrantor expectedGrantor = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };
        string expectedName = "name";
        string expectedTaxIdentifier = "tax_identifier";
        List<Entities::EntityTrustTrustee> expectedTrustees =
        [
            new()
            {
                Individual = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Structure = Entities::EntityTrustTrusteeStructure.Individual,
            },
        ];

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedFormationDocumentFileID, model.FormationDocumentFileID);
        Assert.Equal(expectedFormationState, model.FormationState);
        Assert.Equal(expectedGrantor, model.Grantor);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTaxIdentifier, model.TaxIdentifier);
        Assert.Equal(expectedTrustees.Count, model.Trustees.Count);
        for (int i = 0; i < expectedTrustees.Count; i++)
        {
            Assert.Equal(expectedTrustees[i], model.Trustees[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrust
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrust>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrust
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrust>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityTrustAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        ApiEnum<string, Entities::EntityTrustCategory> expectedCategory =
            Entities::EntityTrustCategory.Revocable;
        string expectedFormationDocumentFileID = "formation_document_file_id";
        string expectedFormationState = "formation_state";
        Entities::EntityTrustGrantor expectedGrantor = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };
        string expectedName = "name";
        string expectedTaxIdentifier = "tax_identifier";
        List<Entities::EntityTrustTrustee> expectedTrustees =
        [
            new()
            {
                Individual = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "2019-12-27",
                    Identification = new()
                    {
                        Method =
                            Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "number_last4",
                    },
                    Name = "name",
                },
                Structure = Entities::EntityTrustTrusteeStructure.Individual,
            },
        ];

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedFormationDocumentFileID, deserialized.FormationDocumentFileID);
        Assert.Equal(expectedFormationState, deserialized.FormationState);
        Assert.Equal(expectedGrantor, deserialized.Grantor);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTaxIdentifier, deserialized.TaxIdentifier);
        Assert.Equal(expectedTrustees.Count, deserialized.Trustees.Count);
        for (int i = 0; i < expectedTrustees.Count; i++)
        {
            Assert.Equal(expectedTrustees[i], deserialized.Trustees[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrust
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrust
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            Category = Entities::EntityTrustCategory.Revocable,
            FormationDocumentFileID = "formation_document_file_id",
            FormationState = "formation_state",
            Grantor = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Name = "name",
            TaxIdentifier = "tax_identifier",
            Trustees =
            [
                new()
                {
                    Individual = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            State = "NY",
                            Zip = "10045",
                        },
                        DateOfBirth = "2019-12-27",
                        Identification = new()
                        {
                            Method =
                                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "number_last4",
                        },
                        Name = "name",
                    },
                    Structure = Entities::EntityTrustTrusteeStructure.Individual,
                },
            ],
        };

        Entities::EntityTrust copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityTrustAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustCategoryTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityTrustCategory.Revocable)]
    [InlineData(Entities::EntityTrustCategory.Irrevocable)]
    public void Validation_Works(Entities::EntityTrustCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityTrustCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityTrustCategory.Revocable)]
    [InlineData(Entities::EntityTrustCategory.Irrevocable)]
    public void SerializationRoundtrip_Works(Entities::EntityTrustCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityTrustCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityTrustGrantorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustGrantor
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityTrustGrantorAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityTrustGrantorIdentification expectedIdentification = new()
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustGrantor
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustGrantor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustGrantor
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustGrantor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityTrustGrantorAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityTrustGrantorIdentification expectedIdentification = new()
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustGrantor
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustGrantor
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityTrustGrantor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustGrantorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustGrantorAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustGrantorAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustGrantorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustGrantorAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustGrantorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustGrantorAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustGrantorAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityTrustGrantorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustGrantorIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustGrantorIdentification
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod> expectedMethod =
            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumberLast4, model.NumberLast4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustGrantorIdentification
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustGrantorIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustGrantorIdentification
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustGrantorIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod> expectedMethod =
            Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumberLast4, deserialized.NumberLast4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustGrantorIdentification
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustGrantorIdentification
        {
            Method = Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        Entities::EntityTrustGrantorIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustGrantorIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityTrustGrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.Passport)]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.Other)]
    public void Validation_Works(Entities::EntityTrustGrantorIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityTrustGrantorIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.Passport)]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityTrustGrantorIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        Entities::EntityTrustGrantorIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustGrantorIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityTrustTrusteeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrustee
        {
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Structure = Entities::EntityTrustTrusteeStructure.Individual,
        };

        Entities::EntityTrustTrusteeIndividual expectedIndividual = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };
        ApiEnum<string, Entities::EntityTrustTrusteeStructure> expectedStructure =
            Entities::EntityTrustTrusteeStructure.Individual;

        Assert.Equal(expectedIndividual, model.Individual);
        Assert.Equal(expectedStructure, model.Structure);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrustee
        {
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Structure = Entities::EntityTrustTrusteeStructure.Individual,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustTrustee>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustTrustee
        {
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Structure = Entities::EntityTrustTrusteeStructure.Individual,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustTrustee>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityTrustTrusteeIndividual expectedIndividual = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };
        ApiEnum<string, Entities::EntityTrustTrusteeStructure> expectedStructure =
            Entities::EntityTrustTrusteeStructure.Individual;

        Assert.Equal(expectedIndividual, deserialized.Individual);
        Assert.Equal(expectedStructure, deserialized.Structure);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustTrustee
        {
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Structure = Entities::EntityTrustTrusteeStructure.Individual,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustTrustee
        {
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    State = "NY",
                    Zip = "10045",
                },
                DateOfBirth = "2019-12-27",
                Identification = new()
                {
                    Method =
                        Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                    NumberLast4 = "number_last4",
                },
                Name = "name",
            },
            Structure = Entities::EntityTrustTrusteeStructure.Individual,
        };

        Entities::EntityTrustTrustee copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustTrusteeIndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityTrustTrusteeIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityTrustTrusteeIndividualIdentification expectedIdentification = new()
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedIdentification, model.Identification);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustTrusteeIndividual>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTrustTrusteeIndividual>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::EntityTrustTrusteeIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        Entities::EntityTrustTrusteeIndividualIdentification expectedIdentification = new()
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedIdentification, deserialized.Identification);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividual
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                State = "NY",
                Zip = "10045",
            },
            DateOfBirth = "2019-12-27",
            Identification = new()
            {
                Method =
                    Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        Entities::EntityTrustTrusteeIndividual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustTrusteeIndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityTrustTrusteeIndividualAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityTrustTrusteeIndividualAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedState = "NY";
        string expectedZip = "10045";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        Entities::EntityTrustTrusteeIndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustTrusteeIndividualIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualIdentification
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod> expectedMethod =
            Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumberLast4, model.NumberLast4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualIdentification
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityTrustTrusteeIndividualIdentification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualIdentification
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Entities::EntityTrustTrusteeIndividualIdentification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod> expectedMethod =
            Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumberLast4, deserialized.NumberLast4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualIdentification
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTrustTrusteeIndividualIdentification
        {
            Method =
                Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        Entities::EntityTrustTrusteeIndividualIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTrustTrusteeIndividualIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityTrustTrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.Passport)]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.Other)]
    public void Validation_Works(
        Entities::EntityTrustTrusteeIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        Entities::EntityTrustTrusteeIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.Passport)]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.DriversLicense)]
    [InlineData(Entities::EntityTrustTrusteeIndividualIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        Entities::EntityTrustTrusteeIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityTrustTrusteeStructureTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityTrustTrusteeStructure.Individual)]
    public void Validation_Works(Entities::EntityTrustTrusteeStructure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustTrusteeStructure> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeStructure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityTrustTrusteeStructure.Individual)]
    public void SerializationRoundtrip_Works(Entities::EntityTrustTrusteeStructure rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityTrustTrusteeStructure> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeStructure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeStructure>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityTrustTrusteeStructure>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Entities::Type.Entity)]
    public void Validation_Works(Entities::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::Type.Entity)]
    public void SerializationRoundtrip_Works(Entities::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ValidationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::Validation
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        List<Entities::Issue> expectedIssues =
        [
            new()
            {
                BeneficialOwnerAddress = new()
                {
                    BeneficialOwnerID = "beneficial_owner_id",
                    Reason = Entities::Reason.MailboxAddress,
                },
                BeneficialOwnerIdentity = new("beneficial_owner_id"),
                Category = Entities::IssueCategory.EntityTaxIdentifier,
                EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                EntityTaxIdentifier = new(),
            },
        ];
        ApiEnum<string, Entities::ValidationStatus> expectedStatus =
            Entities::ValidationStatus.Pending;

        Assert.Equal(expectedIssues.Count, model.Issues.Count);
        for (int i = 0; i < expectedIssues.Count; i++)
        {
            Assert.Equal(expectedIssues[i], model.Issues[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::Validation
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::Validation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::Validation
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::Validation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Entities::Issue> expectedIssues =
        [
            new()
            {
                BeneficialOwnerAddress = new()
                {
                    BeneficialOwnerID = "beneficial_owner_id",
                    Reason = Entities::Reason.MailboxAddress,
                },
                BeneficialOwnerIdentity = new("beneficial_owner_id"),
                Category = Entities::IssueCategory.EntityTaxIdentifier,
                EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                EntityTaxIdentifier = new(),
            },
        ];
        ApiEnum<string, Entities::ValidationStatus> expectedStatus =
            Entities::ValidationStatus.Pending;

        Assert.Equal(expectedIssues.Count, deserialized.Issues.Count);
        for (int i = 0; i < expectedIssues.Count; i++)
        {
            Assert.Equal(expectedIssues[i], deserialized.Issues[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::Validation
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::Validation
        {
            Issues =
            [
                new()
                {
                    BeneficialOwnerAddress = new()
                    {
                        BeneficialOwnerID = "beneficial_owner_id",
                        Reason = Entities::Reason.MailboxAddress,
                    },
                    BeneficialOwnerIdentity = new("beneficial_owner_id"),
                    Category = Entities::IssueCategory.EntityTaxIdentifier,
                    EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
                    EntityTaxIdentifier = new(),
                },
            ],
            Status = Entities::ValidationStatus.Pending,
        };

        Entities::Validation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IssueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::Issue
        {
            BeneficialOwnerAddress = new()
            {
                BeneficialOwnerID = "beneficial_owner_id",
                Reason = Entities::Reason.MailboxAddress,
            },
            BeneficialOwnerIdentity = new("beneficial_owner_id"),
            Category = Entities::IssueCategory.EntityTaxIdentifier,
            EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
            EntityTaxIdentifier = new(),
        };

        Entities::BeneficialOwnerAddress expectedBeneficialOwnerAddress = new()
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };
        Entities::BeneficialOwnerIdentity expectedBeneficialOwnerIdentity = new(
            "beneficial_owner_id"
        );
        ApiEnum<string, Entities::IssueCategory> expectedCategory =
            Entities::IssueCategory.EntityTaxIdentifier;
        Entities::EntityAddress expectedEntityAddress = new(
            Entities::EntityAddressReason.MailboxAddress
        );
        Entities::EntityTaxIdentifier expectedEntityTaxIdentifier = new();

        Assert.Equal(expectedBeneficialOwnerAddress, model.BeneficialOwnerAddress);
        Assert.Equal(expectedBeneficialOwnerIdentity, model.BeneficialOwnerIdentity);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedEntityAddress, model.EntityAddress);
        Assert.Equal(expectedEntityTaxIdentifier, model.EntityTaxIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::Issue
        {
            BeneficialOwnerAddress = new()
            {
                BeneficialOwnerID = "beneficial_owner_id",
                Reason = Entities::Reason.MailboxAddress,
            },
            BeneficialOwnerIdentity = new("beneficial_owner_id"),
            Category = Entities::IssueCategory.EntityTaxIdentifier,
            EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
            EntityTaxIdentifier = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::Issue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::Issue
        {
            BeneficialOwnerAddress = new()
            {
                BeneficialOwnerID = "beneficial_owner_id",
                Reason = Entities::Reason.MailboxAddress,
            },
            BeneficialOwnerIdentity = new("beneficial_owner_id"),
            Category = Entities::IssueCategory.EntityTaxIdentifier,
            EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
            EntityTaxIdentifier = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::Issue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entities::BeneficialOwnerAddress expectedBeneficialOwnerAddress = new()
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };
        Entities::BeneficialOwnerIdentity expectedBeneficialOwnerIdentity = new(
            "beneficial_owner_id"
        );
        ApiEnum<string, Entities::IssueCategory> expectedCategory =
            Entities::IssueCategory.EntityTaxIdentifier;
        Entities::EntityAddress expectedEntityAddress = new(
            Entities::EntityAddressReason.MailboxAddress
        );
        Entities::EntityTaxIdentifier expectedEntityTaxIdentifier = new();

        Assert.Equal(expectedBeneficialOwnerAddress, deserialized.BeneficialOwnerAddress);
        Assert.Equal(expectedBeneficialOwnerIdentity, deserialized.BeneficialOwnerIdentity);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedEntityAddress, deserialized.EntityAddress);
        Assert.Equal(expectedEntityTaxIdentifier, deserialized.EntityTaxIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::Issue
        {
            BeneficialOwnerAddress = new()
            {
                BeneficialOwnerID = "beneficial_owner_id",
                Reason = Entities::Reason.MailboxAddress,
            },
            BeneficialOwnerIdentity = new("beneficial_owner_id"),
            Category = Entities::IssueCategory.EntityTaxIdentifier,
            EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
            EntityTaxIdentifier = new(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::Issue
        {
            BeneficialOwnerAddress = new()
            {
                BeneficialOwnerID = "beneficial_owner_id",
                Reason = Entities::Reason.MailboxAddress,
            },
            BeneficialOwnerIdentity = new("beneficial_owner_id"),
            Category = Entities::IssueCategory.EntityTaxIdentifier,
            EntityAddress = new(Entities::EntityAddressReason.MailboxAddress),
            EntityTaxIdentifier = new(),
        };

        Entities::Issue copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BeneficialOwnerAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::BeneficialOwnerAddress
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };

        string expectedBeneficialOwnerID = "beneficial_owner_id";
        ApiEnum<string, Entities::Reason> expectedReason = Entities::Reason.MailboxAddress;

        Assert.Equal(expectedBeneficialOwnerID, model.BeneficialOwnerID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::BeneficialOwnerAddress
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::BeneficialOwnerAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::BeneficialOwnerAddress
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::BeneficialOwnerAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBeneficialOwnerID = "beneficial_owner_id";
        ApiEnum<string, Entities::Reason> expectedReason = Entities::Reason.MailboxAddress;

        Assert.Equal(expectedBeneficialOwnerID, deserialized.BeneficialOwnerID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::BeneficialOwnerAddress
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::BeneficialOwnerAddress
        {
            BeneficialOwnerID = "beneficial_owner_id",
            Reason = Entities::Reason.MailboxAddress,
        };

        Entities::BeneficialOwnerAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Entities::Reason.MailboxAddress)]
    public void Validation_Works(Entities::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::Reason.MailboxAddress)]
    public void SerializationRoundtrip_Works(Entities::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BeneficialOwnerIdentityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::BeneficialOwnerIdentity
        {
            BeneficialOwnerID = "beneficial_owner_id",
        };

        string expectedBeneficialOwnerID = "beneficial_owner_id";

        Assert.Equal(expectedBeneficialOwnerID, model.BeneficialOwnerID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::BeneficialOwnerIdentity
        {
            BeneficialOwnerID = "beneficial_owner_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::BeneficialOwnerIdentity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::BeneficialOwnerIdentity
        {
            BeneficialOwnerID = "beneficial_owner_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::BeneficialOwnerIdentity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBeneficialOwnerID = "beneficial_owner_id";

        Assert.Equal(expectedBeneficialOwnerID, deserialized.BeneficialOwnerID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::BeneficialOwnerIdentity
        {
            BeneficialOwnerID = "beneficial_owner_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::BeneficialOwnerIdentity
        {
            BeneficialOwnerID = "beneficial_owner_id",
        };

        Entities::BeneficialOwnerIdentity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IssueCategoryTest : TestBase
{
    [Theory]
    [InlineData(Entities::IssueCategory.EntityTaxIdentifier)]
    [InlineData(Entities::IssueCategory.EntityAddress)]
    [InlineData(Entities::IssueCategory.BeneficialOwnerIdentity)]
    [InlineData(Entities::IssueCategory.BeneficialOwnerAddress)]
    public void Validation_Works(Entities::IssueCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::IssueCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::IssueCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::IssueCategory.EntityTaxIdentifier)]
    [InlineData(Entities::IssueCategory.EntityAddress)]
    [InlineData(Entities::IssueCategory.BeneficialOwnerIdentity)]
    [InlineData(Entities::IssueCategory.BeneficialOwnerAddress)]
    public void SerializationRoundtrip_Works(Entities::IssueCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::IssueCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::IssueCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::IssueCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::IssueCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntityAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityAddress
        {
            Reason = Entities::EntityAddressReason.MailboxAddress,
        };

        ApiEnum<string, Entities::EntityAddressReason> expectedReason =
            Entities::EntityAddressReason.MailboxAddress;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityAddress
        {
            Reason = Entities::EntityAddressReason.MailboxAddress,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityAddress
        {
            Reason = Entities::EntityAddressReason.MailboxAddress,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entities::EntityAddressReason> expectedReason =
            Entities::EntityAddressReason.MailboxAddress;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityAddress
        {
            Reason = Entities::EntityAddressReason.MailboxAddress,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityAddress
        {
            Reason = Entities::EntityAddressReason.MailboxAddress,
        };

        Entities::EntityAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityAddressReasonTest : TestBase
{
    [Theory]
    [InlineData(Entities::EntityAddressReason.MailboxAddress)]
    public void Validation_Works(Entities::EntityAddressReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityAddressReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityAddressReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::EntityAddressReason.MailboxAddress)]
    public void SerializationRoundtrip_Works(Entities::EntityAddressReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::EntityAddressReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityAddressReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::EntityAddressReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entities::EntityAddressReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityTaxIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityTaxIdentifier { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityTaxIdentifier { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTaxIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityTaxIdentifier { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityTaxIdentifier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityTaxIdentifier { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityTaxIdentifier { };

        Entities::EntityTaxIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ValidationStatusTest : TestBase
{
    [Theory]
    [InlineData(Entities::ValidationStatus.Pending)]
    [InlineData(Entities::ValidationStatus.Valid)]
    [InlineData(Entities::ValidationStatus.Invalid)]
    public void Validation_Works(Entities::ValidationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::ValidationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::ValidationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entities::ValidationStatus.Pending)]
    [InlineData(Entities::ValidationStatus.Valid)]
    [InlineData(Entities::ValidationStatus.Invalid)]
    public void SerializationRoundtrip_Works(Entities::ValidationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entities::ValidationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::ValidationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entities::ValidationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entities::ValidationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
