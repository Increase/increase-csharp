using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Tests.Models.BeneficialOwners;

public class BeneficialOwnerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BeneficialOwnerUpdateParams
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "Unit 2",
                State = "NY",
                Zip = "10045",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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

        string expectedEntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6";
        BeneficialOwnerUpdateParamsAddress expectedAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = "Unit 2",
            State = "NY",
            Zip = "10045",
        };
        bool expectedConfirmedNoUsTaxID = true;
        BeneficialOwnerUpdateParamsIdentification expectedIdentification = new()
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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

        Assert.Equal(expectedEntityBeneficialOwnerID, parameters.EntityBeneficialOwnerID);
        Assert.Equal(expectedAddress, parameters.Address);
        Assert.Equal(expectedConfirmedNoUsTaxID, parameters.ConfirmedNoUsTaxID);
        Assert.Equal(expectedIdentification, parameters.Identification);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BeneficialOwnerUpdateParams
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
        };

        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.ConfirmedNoUsTaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("confirmed_no_us_tax_id"));
        Assert.Null(parameters.Identification);
        Assert.False(parameters.RawBodyData.ContainsKey("identification"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BeneficialOwnerUpdateParams
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",

            // Null should be interpreted as omitted for these properties
            Address = null,
            ConfirmedNoUsTaxID = null,
            Identification = null,
            Name = null,
        };

        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.ConfirmedNoUsTaxID);
        Assert.False(parameters.RawBodyData.ContainsKey("confirmed_no_us_tax_id"));
        Assert.Null(parameters.Identification);
        Assert.False(parameters.RawBodyData.ContainsKey("identification"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        BeneficialOwnerUpdateParams parameters = new()
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/entity_beneficial_owners/entity_beneficial_owner_vozma8szzu1sxezp5zq6"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BeneficialOwnerUpdateParams
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            Address = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "Unit 2",
                State = "NY",
                Zip = "10045",
            },
            ConfirmedNoUsTaxID = true,
            Identification = new()
            {
                Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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

        BeneficialOwnerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BeneficialOwnerUpdateParamsAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwnerUpdateParamsAddress
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
        var model = new BeneficialOwnerUpdateParamsAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwnerUpdateParamsAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsAddress>(
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
        var model = new BeneficialOwnerUpdateParamsAddress
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
        var model = new BeneficialOwnerUpdateParamsAddress
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
        var model = new BeneficialOwnerUpdateParamsAddress
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
        var model = new BeneficialOwnerUpdateParamsAddress
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
        var model = new BeneficialOwnerUpdateParamsAddress
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
        var model = new BeneficialOwnerUpdateParamsAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            State = "x",
            Zip = "x",
        };

        BeneficialOwnerUpdateParamsAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BeneficialOwnerUpdateParamsIdentificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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

        ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod> expectedMethod =
            BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        BeneficialOwnerUpdateParamsIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        BeneficialOwnerUpdateParamsIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        BeneficialOwnerUpdateParamsIdentificationPassport expectedPassport = new()
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
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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
        var deserialized = JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod> expectedMethod =
            BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber;
        string expectedNumber = "xxxx";
        BeneficialOwnerUpdateParamsIdentificationDriversLicense expectedDriversLicense = new()
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };
        BeneficialOwnerUpdateParamsIdentificationOther expectedOther = new()
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };
        BeneficialOwnerUpdateParamsIdentificationPassport expectedPassport = new()
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
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
            Number = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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
        var model = new BeneficialOwnerUpdateParamsIdentification
        {
            Method = BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber,
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

        BeneficialOwnerUpdateParamsIdentification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BeneficialOwnerUpdateParamsIdentificationMethodTest : TestBase
{
    [Theory]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        BeneficialOwnerUpdateParamsIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.Passport)]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.DriversLicense)]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.Other)]
    public void Validation_Works(BeneficialOwnerUpdateParamsIdentificationMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.SocialSecurityNumber)]
    [InlineData(
        BeneficialOwnerUpdateParamsIdentificationMethod.IndividualTaxpayerIdentificationNumber
    )]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.Passport)]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.DriversLicense)]
    [InlineData(BeneficialOwnerUpdateParamsIdentificationMethod.Other)]
    public void SerializationRoundtrip_Works(
        BeneficialOwnerUpdateParamsIdentificationMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BeneficialOwnerUpdateParamsIdentificationMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BeneficialOwnerUpdateParamsIdentificationDriversLicenseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentificationDriversLicense>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentificationDriversLicense>(
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
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
        var model = new BeneficialOwnerUpdateParamsIdentificationDriversLicense
        {
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
            State = "x",
            BackFileID = "back_file_id",
        };

        BeneficialOwnerUpdateParamsIdentificationDriversLicense copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BeneficialOwnerUpdateParamsIdentificationOtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentificationOther>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentificationOther>(
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
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
        var model = new BeneficialOwnerUpdateParamsIdentificationOther
        {
            Country = "x",
            Description = "x",
            FileID = "file_id",
            BackFileID = "back_file_id",
            ExpirationDate = "2019-12-27",
        };

        BeneficialOwnerUpdateParamsIdentificationOther copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BeneficialOwnerUpdateParamsIdentificationPassportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentificationPassport
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
        var model = new BeneficialOwnerUpdateParamsIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentificationPassport>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BeneficialOwnerUpdateParamsIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BeneficialOwnerUpdateParamsIdentificationPassport>(
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
        var model = new BeneficialOwnerUpdateParamsIdentificationPassport
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
        var model = new BeneficialOwnerUpdateParamsIdentificationPassport
        {
            Country = "x",
            ExpirationDate = "2019-12-27",
            FileID = "file_id",
        };

        BeneficialOwnerUpdateParamsIdentificationPassport copied = new(model);

        Assert.Equal(model, copied);
    }
}
