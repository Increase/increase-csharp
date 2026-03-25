using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Entities = Increase.Api.Models.Entities;
using SupplementalDocuments = Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Tests.Models.Entities;

public class EntityListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entities::EntityListPageResponse
        {
            Data =
            [
                new()
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
                        LegalIdentifier = new()
                        {
                            Category =
                                Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                            Value = "602214076",
                        },
                        Name = "National Phonograph Company",
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
                            Method =
                                Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Entities::Entity> expectedData =
        [
            new()
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
                    LegalIdentifier = new()
                    {
                        Category =
                            Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                        Value = "602214076",
                    },
                    Name = "National Phonograph Company",
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
                        Method =
                            Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entities::EntityListPageResponse
        {
            Data =
            [
                new()
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
                        LegalIdentifier = new()
                        {
                            Category =
                                Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                            Value = "602214076",
                        },
                        Name = "National Phonograph Company",
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
                            Method =
                                Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entities::EntityListPageResponse
        {
            Data =
            [
                new()
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
                        LegalIdentifier = new()
                        {
                            Category =
                                Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                            Value = "602214076",
                        },
                        Name = "National Phonograph Company",
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
                            Method =
                                Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entities::EntityListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Entities::Entity> expectedData =
        [
            new()
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
                    LegalIdentifier = new()
                    {
                        Category =
                            Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                        Value = "602214076",
                    },
                    Name = "National Phonograph Company",
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
                        Method =
                            Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entities::EntityListPageResponse
        {
            Data =
            [
                new()
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
                        LegalIdentifier = new()
                        {
                            Category =
                                Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                            Value = "602214076",
                        },
                        Name = "National Phonograph Company",
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
                            Method =
                                Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entities::EntityListPageResponse
        {
            Data =
            [
                new()
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
                        LegalIdentifier = new()
                        {
                            Category =
                                Entities::EntityCorporationLegalIdentifierCategory.UsEmployerIdentificationNumber,
                            Value = "602214076",
                        },
                        Name = "National Phonograph Company",
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
                            Method =
                                Entities::EntityNaturalPersonIdentificationMethod.SocialSecurityNumber,
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
                },
            ],
            NextCursor = "v57w5d",
        };

        Entities::EntityListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
