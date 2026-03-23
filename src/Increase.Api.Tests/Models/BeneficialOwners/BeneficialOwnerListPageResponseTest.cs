using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using BeneficialOwners = Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Tests.Models.BeneficialOwners;

public class BeneficialOwnerListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwners::BeneficialOwnerListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
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
                                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        BeneficialOwners::EntityBeneficialOwnerProng.Control,
                        BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                    ],
                    Type = BeneficialOwners::Type.EntityBeneficialOwner,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<BeneficialOwners::EntityBeneficialOwner> expectedData =
        [
            new()
            {
                ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                CompanyTitle = "CEO",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                IdempotencyKey = null,
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
                            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "1120",
                    },
                    Name = "Ian Crease",
                },
                Prongs =
                [
                    BeneficialOwners::EntityBeneficialOwnerProng.Control,
                    BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                ],
                Type = BeneficialOwners::Type.EntityBeneficialOwner,
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
        var model = new BeneficialOwners::BeneficialOwnerListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
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
                                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        BeneficialOwners::EntityBeneficialOwnerProng.Control,
                        BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                    ],
                    Type = BeneficialOwners::Type.EntityBeneficialOwner,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwners::BeneficialOwnerListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwners::BeneficialOwnerListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
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
                                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        BeneficialOwners::EntityBeneficialOwnerProng.Control,
                        BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                    ],
                    Type = BeneficialOwners::Type.EntityBeneficialOwner,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwners::BeneficialOwnerListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<BeneficialOwners::EntityBeneficialOwner> expectedData =
        [
            new()
            {
                ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                CompanyTitle = "CEO",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                IdempotencyKey = null,
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
                            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                        NumberLast4 = "1120",
                    },
                    Name = "Ian Crease",
                },
                Prongs =
                [
                    BeneficialOwners::EntityBeneficialOwnerProng.Control,
                    BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                ],
                Type = BeneficialOwners::Type.EntityBeneficialOwner,
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
        var model = new BeneficialOwners::BeneficialOwnerListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
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
                                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        BeneficialOwners::EntityBeneficialOwnerProng.Control,
                        BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                    ],
                    Type = BeneficialOwners::Type.EntityBeneficialOwner,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BeneficialOwners::BeneficialOwnerListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
                    CompanyTitle = "CEO",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
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
                                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                            NumberLast4 = "1120",
                        },
                        Name = "Ian Crease",
                    },
                    Prongs =
                    [
                        BeneficialOwners::EntityBeneficialOwnerProng.Control,
                        BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
                    ],
                    Type = BeneficialOwners::Type.EntityBeneficialOwner,
                },
            ],
            NextCursor = "v57w5d",
        };

        BeneficialOwners::BeneficialOwnerListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
