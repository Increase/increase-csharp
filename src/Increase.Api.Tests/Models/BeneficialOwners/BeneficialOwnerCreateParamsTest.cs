using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Tests.Models.BeneficialOwners;

public class BeneficialOwnerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BeneficialOwnerCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
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
                        State = "xx",
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
        };

        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        Individual expectedIndividual = new()
        {
            Address = new()
            {
                City = "New York",
                Country = "US",
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
                    State = "xx",
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
        };
        List<ApiEnum<string, Prong>> expectedProngs = [Prong.Control];
        string expectedCompanyTitle = "CEO";

        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedIndividual, parameters.Individual);
        Assert.Equal(expectedProngs.Count, parameters.Prongs.Count);
        for (int i = 0; i < expectedProngs.Count; i++)
        {
            Assert.Equal(expectedProngs[i], parameters.Prongs[i]);
        }
        Assert.Equal(expectedCompanyTitle, parameters.CompanyTitle);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BeneficialOwnerCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
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
                        State = "xx",
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
        };

        Assert.Null(parameters.CompanyTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("company_title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BeneficialOwnerCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
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
                        State = "xx",
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

            // Null should be interpreted as omitted for these properties
            CompanyTitle = null,
        };

        Assert.Null(parameters.CompanyTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("company_title"));
    }

    [Fact]
    public void Url_Works()
    {
        BeneficialOwnerCreateParams parameters = new()
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
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
                        State = "xx",
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/entity_beneficial_owners"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BeneficialOwnerCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Individual = new()
            {
                Address = new()
                {
                    City = "New York",
                    Country = "US",
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
                        State = "xx",
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
        };

        BeneficialOwnerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
                    State = "xx",
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

        Address expectedAddress = new()
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
                State = "xx",
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
                    State = "xx",
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
                    State = "xx",
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

        Address expectedAddress = new()
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
                State = "xx",
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
                    State = "xx",
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
                    State = "xx",
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
                    State = "xx",
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
                    State = "xx",
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
                    State = "xx",
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
                    State = "xx",
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

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Address
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
        var model = new Address
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
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
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
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
        var model = new Address
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        Address copied = new(model);

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
                State = "xx",
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
            State = "xx",
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
                State = "xx",
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
                State = "xx",
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
            State = "xx",
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
                State = "xx",
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
                State = "xx",
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
            State = "xx",
            BackFileID = "back_file_id",
        };

        string expectedExpirationDate = "2019-12-27";
        string expectedFileID = "file_id";
        string expectedState = "xx";
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
            State = "xx",
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
            State = "xx",
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
        string expectedState = "xx";
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
            State = "xx",
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
            State = "xx",
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
            State = "xx",
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
            State = "xx",

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
            State = "xx",

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
            State = "xx",
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
