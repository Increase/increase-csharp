using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.Entities;

namespace Increase.Api.Tests.Models.Simulations.Entities;

public class EntityUpdateValidationParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityUpdateValidationParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Issues = [new(Category.EntityTaxIdentifier)],
        };

        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        List<Issue> expectedIssues = [new(Category.EntityTaxIdentifier)];

        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedIssues.Count, parameters.Issues.Count);
        for (int i = 0; i < expectedIssues.Count; i++)
        {
            Assert.Equal(expectedIssues[i], parameters.Issues[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        EntityUpdateValidationParams parameters = new()
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Issues = [new(Category.EntityTaxIdentifier)],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/entities/entity_n8y8tnk2p9339ti393yi/update_validation"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityUpdateValidationParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            Issues = [new(Category.EntityTaxIdentifier)],
        };

        EntityUpdateValidationParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IssueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Issue { Category = Category.EntityTaxIdentifier };

        ApiEnum<string, Category> expectedCategory = Category.EntityTaxIdentifier;

        Assert.Equal(expectedCategory, model.Category);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Issue { Category = Category.EntityTaxIdentifier };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Issue>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Issue { Category = Category.EntityTaxIdentifier };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Issue>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.EntityTaxIdentifier;

        Assert.Equal(expectedCategory, deserialized.Category);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Issue { Category = Category.EntityTaxIdentifier };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Issue { Category = Category.EntityTaxIdentifier };

        Issue copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.EntityTaxIdentifier)]
    [InlineData(Category.EntityAddress)]
    [InlineData(Category.BeneficialOwnerIdentity)]
    [InlineData(Category.BeneficialOwnerAddress)]
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
    [InlineData(Category.EntityTaxIdentifier)]
    [InlineData(Category.EntityAddress)]
    [InlineData(Category.BeneficialOwnerIdentity)]
    [InlineData(Category.BeneficialOwnerAddress)]
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
