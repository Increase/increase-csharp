using System;
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
                    Line1 = "33 Liberty Street",
                    State = "NY",
                    Zip = "10045",
                    Line2 = "Unit 2",
                },
                Email = "dev@stainless.com",
                IncorporationState = "x",
                IndustryCode = "x",
                Name = "x",
                TaxIdentifier = "x",
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
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                Name = "x",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Rating = EntityUpdateParamsRiskRatingRating.Low,
            },
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
                Line1 = "33 Liberty Street",
                State = "NY",
                Zip = "10045",
                Line2 = "Unit 2",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Name = "x",
            TaxIdentifier = "x",
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
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };
        EntityUpdateParamsRiskRating expectedRiskRating = new()
        {
            RatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Rating = EntityUpdateParamsRiskRatingRating.Low,
        };
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

        Assert.Equal(new Uri("https://api.increase.com/entities/entity_n8y8tnk2p9339ti393yi"), url);
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
                    Line1 = "33 Liberty Street",
                    State = "NY",
                    Zip = "10045",
                    Line2 = "Unit 2",
                },
                Email = "dev@stainless.com",
                IncorporationState = "x",
                IndustryCode = "x",
                Name = "x",
                TaxIdentifier = "x",
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
                    Line1 = "x",
                    State = "x",
                    Zip = "x",
                    Line2 = "x",
                },
                Name = "x",
            },
            RiskRating = new()
            {
                RatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Rating = EntityUpdateParamsRiskRatingRating.Low,
            },
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
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Name = "x",
            TaxIdentifier = "x",
        };

        EntityUpdateParamsCorporationAddress expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedEmail = "dev@stainless.com";
        string expectedIncorporationState = "x";
        string expectedIndustryCode = "x";
        string expectedName = "x";
        string expectedTaxIdentifier = "x";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedIncorporationState, model.IncorporationState);
        Assert.Equal(expectedIndustryCode, model.IndustryCode);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTaxIdentifier, model.TaxIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Name = "x",
            TaxIdentifier = "x",
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
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Name = "x",
            TaxIdentifier = "x",
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
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };
        string expectedEmail = "dev@stainless.com";
        string expectedIncorporationState = "x";
        string expectedIndustryCode = "x";
        string expectedName = "x";
        string expectedTaxIdentifier = "x";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedIncorporationState, deserialized.IncorporationState);
        Assert.Equal(expectedIndustryCode, deserialized.IndustryCode);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTaxIdentifier, deserialized.TaxIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUpdateParamsCorporation
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Name = "x",
            TaxIdentifier = "x",
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
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.TaxIdentifier);
        Assert.False(model.RawData.ContainsKey("tax_identifier"));
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
            Name = null,
            TaxIdentifier = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.IncorporationState);
        Assert.False(model.RawData.ContainsKey("incorporation_state"));
        Assert.Null(model.IndustryCode);
        Assert.False(model.RawData.ContainsKey("industry_code"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.TaxIdentifier);
        Assert.False(model.RawData.ContainsKey("tax_identifier"));
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
            Name = null,
            TaxIdentifier = null,
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
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Email = "dev@stainless.com",
            IncorporationState = "x",
            IndustryCode = "x",
            Name = "x",
            TaxIdentifier = "x",
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
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
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
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsCorporationAddress>(
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
        var model = new EntityUpdateParamsCorporationAddress
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
        var model = new EntityUpdateParamsCorporationAddress
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
        var model = new EntityUpdateParamsCorporationAddress
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
        var model = new EntityUpdateParamsCorporationAddress
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
        var model = new EntityUpdateParamsCorporationAddress
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
        var model = new EntityUpdateParamsCorporationAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        EntityUpdateParamsCorporationAddress copied = new(model);

        Assert.Equal(model, copied);
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
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
            },
            Name = "x",
        };

        EntityUpdateParamsNaturalPersonAddress expectedAddress = new()
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
        var model = new EntityUpdateParamsNaturalPerson
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
                Line1 = "x",
                State = "x",
                Zip = "x",
                Line2 = "x",
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
        var model = new EntityUpdateParamsNaturalPerson
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
        var model = new EntityUpdateParamsNaturalPerson { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
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
        var model = new EntityUpdateParamsNaturalPerson
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
        var model = new EntityUpdateParamsNaturalPerson
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
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
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
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUpdateParamsNaturalPersonAddress>(
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
        var model = new EntityUpdateParamsNaturalPersonAddress
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
        var model = new EntityUpdateParamsNaturalPersonAddress
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
        var model = new EntityUpdateParamsNaturalPersonAddress
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
        var model = new EntityUpdateParamsNaturalPersonAddress
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
        var model = new EntityUpdateParamsNaturalPersonAddress
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
        var model = new EntityUpdateParamsNaturalPersonAddress
        {
            City = "x",
            Line1 = "x",
            State = "x",
            Zip = "x",
            Line2 = "x",
        };

        EntityUpdateParamsNaturalPersonAddress copied = new(model);

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
