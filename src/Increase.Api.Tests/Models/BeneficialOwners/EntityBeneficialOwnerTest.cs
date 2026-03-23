using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using BeneficialOwners = Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Tests.Models.BeneficialOwners;

public class EntityBeneficialOwnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwner
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
        };

        string expectedID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6";
        string expectedCompanyTitle = "CEO";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        BeneficialOwners::EntityBeneficialOwnerIndividual expectedIndividual = new()
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
        };
        List<ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng>> expectedProngs =
        [
            BeneficialOwners::EntityBeneficialOwnerProng.Control,
            BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
        ];
        ApiEnum<string, BeneficialOwners::Type> expectedType =
            BeneficialOwners::Type.EntityBeneficialOwner;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompanyTitle, model.CompanyTitle);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedIndividual, model.Individual);
        Assert.Equal(expectedProngs.Count, model.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], model.Prongs[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwner
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwner>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwner
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwner>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6";
        string expectedCompanyTitle = "CEO";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        BeneficialOwners::EntityBeneficialOwnerIndividual expectedIndividual = new()
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
        };
        List<ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng>> expectedProngs =
        [
            BeneficialOwners::EntityBeneficialOwnerProng.Control,
            BeneficialOwners::EntityBeneficialOwnerProng.Ownership,
        ];
        ApiEnum<string, BeneficialOwners::Type> expectedType =
            BeneficialOwners::Type.EntityBeneficialOwner;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompanyTitle, deserialized.CompanyTitle);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedIndividual, deserialized.Individual);
        Assert.Equal(expectedProngs.Count, deserialized.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], deserialized.Prongs[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwner
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwner
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
        };

        BeneficialOwners::EntityBeneficialOwner copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityBeneficialOwnerIndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividual
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
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        BeneficialOwners::EntityBeneficialOwnerIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentification expectedIdentification =
            new()
            {
                Method =
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividual
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
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwnerIndividual>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividual
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
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwnerIndividual>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BeneficialOwners::EntityBeneficialOwnerIndividualAddress expectedAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };
        string expectedDateOfBirth = "2019-12-27";
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentification expectedIdentification =
            new()
            {
                Method =
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
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
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividual
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
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividual
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
                    BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
                NumberLast4 = "number_last4",
            },
            Name = "name",
        };

        BeneficialOwners::EntityBeneficialOwnerIndividual copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityBeneficialOwnerIndividualAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualAddress
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
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualAddress
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
            JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwnerIndividualAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualAddress
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
            JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwnerIndividualAddress>(
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
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualAddress
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
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualAddress
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            State = "NY",
            Zip = "10045",
        };

        BeneficialOwners::EntityBeneficialOwnerIndividualAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityBeneficialOwnerIndividualIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualIdentification
        {
            Method =
                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        ApiEnum<
            string,
            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod
        > expectedMethod =
            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNumberLast4, model.NumberLast4);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualIdentification
        {
            Method =
                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwnerIndividualIdentification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualIdentification
        {
            Method =
                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwners::EntityBeneficialOwnerIndividualIdentification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod
        > expectedMethod =
            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber;
        string expectedNumberLast4 = "number_last4";

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNumberLast4, deserialized.NumberLast4);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualIdentification
        {
            Method =
                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BeneficialOwners::EntityBeneficialOwnerIndividualIdentification
        {
            Method =
                BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber,
            NumberLast4 = "number_last4",
        };

        BeneficialOwners::EntityBeneficialOwnerIndividualIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityBeneficialOwnerIndividualIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber
    )]
    [InlineData(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.Passport)]
    [InlineData(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.DriversLicense
    )]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.Other)]
    public void Validation_Works(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.SocialSecurityNumber
    )]
    [InlineData(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.Passport)]
    [InlineData(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.DriversLicense
    )]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerIndividualIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntityBeneficialOwnerProngTest : TestBase
{
    [Theory]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerProng.Ownership)]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerProng.Control)]
    public void Validation_Works(BeneficialOwners::EntityBeneficialOwnerProng rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerProng.Ownership)]
    [InlineData(BeneficialOwners::EntityBeneficialOwnerProng.Control)]
    public void SerializationRoundtrip_Works(BeneficialOwners::EntityBeneficialOwnerProng rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwners::EntityBeneficialOwnerProng>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(BeneficialOwners::Type.EntityBeneficialOwner)]
    public void Validation_Works(BeneficialOwners::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwners::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BeneficialOwners::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BeneficialOwners::Type.EntityBeneficialOwner)]
    public void SerializationRoundtrip_Works(BeneficialOwners::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwners::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BeneficialOwners::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BeneficialOwners::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BeneficialOwners::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
